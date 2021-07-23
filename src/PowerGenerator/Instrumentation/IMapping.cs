namespace Absa.Hire.Newbies.PowerConverter
{
    public interface IMapping
    {
        Unit Left { get; }

        Unit Right { get; }

        decimal ConvertToRight(decimal value);

        decimal ConvertToLeft(decimal value);
    }
}
