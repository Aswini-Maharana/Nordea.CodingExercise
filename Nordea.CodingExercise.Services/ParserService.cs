using Nordea.CodingExercise.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nordea.CodingExercise.Services
{
    public class ParserService : IParserService
    {
        public string[] GetAllParsers()
        {
            return ParserRepository.GetAllParsers();
        }

        public string Parse(string input, string parserType)
        {
            var parserStrategy = ParserRepository.GetParser(parserType);
            return ParserRepository.Parse(parserStrategy, input);
        }
    }
}
