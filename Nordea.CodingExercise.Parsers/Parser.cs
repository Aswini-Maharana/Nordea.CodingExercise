using Nordea.CodingExercise.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nordea.CodingExercise.Parsers
{
    public abstract class Parser
    {
        internal abstract string Parse(string input);

        protected virtual Text GetText(string input)
        {
            input = Regex.Replace(input, @"\r\n", " ");
            input = Regex.Replace(input, @",", " ");

            var setences = input.Split(new[] { '.' }).Where(a => !string.IsNullOrWhiteSpace(a)).Select((s) =>
            {
                var words = s.Split(new[] { ' ' }).Where(a => !string.IsNullOrWhiteSpace(a)).OrderBy(o => o).
                ToArray();
                var sentence = new Sentence { Words = words };
                return sentence;
            }).ToArray();

            var text = new Text { Sentences = setences };
            return text;
        }
    }
}
