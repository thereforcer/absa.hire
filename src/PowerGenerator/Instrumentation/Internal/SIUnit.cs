using System;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal sealed class SIUnit : Unit
    {
        private readonly Func<decimal, decimal> _callback;

        public SIUnit(Unit unit, string siPrefix, Func<decimal, decimal> callback) : base(unit.UnitId, siPrefix + unit.UnitName, unit.Category)
        {
            _callback = callback;
        }

        public decimal Correlate(decimal input) => _callback.Invoke(input);
    }
}
