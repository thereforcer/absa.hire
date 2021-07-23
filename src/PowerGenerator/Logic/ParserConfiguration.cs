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
        internal Unit FindUnitByText(string unitPhrase)
        {
            var unit = _units.FirstOrDefault(i => i.GetUnitNames().Any(j => string.Equals(j, unitPhrase, TextComparison)));
            if (unit == null)
            {
                throw new UnitNotFoundException(unitPhrase);
            }

            return unit;
        }
    }
}
