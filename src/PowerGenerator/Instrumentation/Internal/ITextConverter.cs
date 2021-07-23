namespace Absa.Hire.Newbies.PowerConverter
{
    public interface ITextConverter
    {
        /// <summary>
        /// Converts input value unit phrase into destination unit phrase.
        /// </summary>
        /// <exception cref="UnitNotFoundException"/>
        /// <exception cref="MappingNotFoundException"/>
        string Convert(string input, string expectedUnit);
    }
}
