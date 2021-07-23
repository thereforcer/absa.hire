namespace Absa.Hire.Newbies.PowerConverter
{
    internal interface IUnitConverter
    {
        decimal Convert(decimal value, Unit destination, Unit source);
    }
}
