using System;
using System.Collections.Generic;
using System.Linq;

namespace Absa.Hire.Newbies.PowerConverter.Logic
{
    public sealed class ParserConfiguration
    {
        internal ParserConfiguration()
        {
            TextComparison = StringComparison.InvariantCulture;
            CultureInfo = System.Globalization.CultureInfo.InvariantCulture;
        }

        private readonly HashSet<Unit> _units = new();

        public StringComparison TextComparison { get; set; }

        public IFormatProvider CultureInfo { get; set; }

        public void AddUnit(Unit unit)
        {
            _units.Add(unit);
        }

        /// <exception cref="UnitNotFoundException"/>
        internal Unit FindUnitByText(string unitPhrase, bool isSource)
        {
            var unit = _units
                .FirstOrDefault(i => i.GetUnitNames().Any(j => string.Equals(j, unitPhrase, TextComparison))) ??
                       CorrelateSI(unitPhrase, isSource);
            if (unit == null)
            {
                throw new UnitNotFoundException(unitPhrase);
            }

            return unit;
        }

        private readonly IDictionary<string, int> SI = new Dictionary<string, int>
        {
            {"kilo", 3},
            {"mega", 6},
            {"mili", -3},
            {"deci", -1},
            {"centi", -2},
        };

        private Unit CorrelateSI(string unitPhrase, bool isSource)
        {
            var candidateSi = SI.FirstOrDefault(i => unitPhrase.StartsWith(i.Key, StringComparison.InvariantCultureIgnoreCase));
            if (candidateSi.Key != null)
            {
                var convertingValue = (decimal)Math.Pow(10, candidateSi.Value);
                var rest = unitPhrase.Substring(candidateSi.Key.Length);
                var originUnit = _units.FirstOrDefault(i => i.GetUnitNames().Any(j => string.Equals(j, rest, TextComparison)));
                if (originUnit != null)
                {
                    return new SIUnit(originUnit, candidateSi.Key, isSource ? input => input * convertingValue : input => input / convertingValue);
                }
            }

            return null;
        }
    }
}
