namespace Absa.Hire.Newbies.PowerConverter
{
    internal interface IUnitConverter
    {
        /// <summary>
        /// Converts value in source unit to destination unit.
        /// </summary>
        /// <exception cref="MappingNotFoundException"/>
        decimal Convert(decimal value, Unit destination, Unit source);
    }
}
