namespace Nordea.CodingExercise.Services
{
    public interface IParserService
    {
        string Parse(string input, string parserType);

        string[] GetAllParsers();
    }
}
