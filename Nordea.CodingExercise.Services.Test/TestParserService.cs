using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nordea.CodingExercise.Services.Test
{
    [TestClass]
    public class TestParserService
    {
        IParserService _parserService;
        public TestParserService()
                : this(new ParserService())
        {
        }

        public TestParserService(IParserService parserService)
        {
            _parserService = parserService;
        }

        [TestMethod]
        public void ParserService_GetAllParsers_ShouldReturnAllParser()
        {
            var expectedParsers = new[] { "Xml",
                "Csv" };
            var actualparsers = _parserService.GetAllParsers();
            Assert.AreEqual(expectedParsers[0], actualparsers[0]);
            Assert.AreEqual(expectedParsers[1], actualparsers[1]);
        }

        [TestMethod]
        public void ParserService_Parse_ShouldParseTheTextAsXml()
        {
            var expected = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Text>\r\n  <Sentence>\r\n    <Word>a</Word>\r\n    <Word>had</Word>\r\n    <Word>lamb</Word>\r\n    <Word>little</Word>\r\n    <Word>Mary</Word>\r\n  </Sentence>\r\n  <Sentence>\r\n    <Word>Aesop</Word>\r\n    <Word>and</Word>\r\n    <Word>called</Word>\r\n    <Word>came</Word>\r\n    <Word>for</Word>\r\n    <Word>Peter</Word>\r\n    <Word>the</Word>\r\n    <Word>wolf</Word>\r\n  </Sentence>\r\n  <Sentence>\r\n    <Word>Cinderella</Word>\r\n    <Word>likes</Word>\r\n    <Word>shoes</Word>\r\n  </Sentence>\r\n</Text>";

            var input1 = "Mary had a little lamb. Peter called for the wolf, and Aesop came.\r\nCinderella likes shoes.";
            var actual1 = _parserService.Parse(input1, "Xml");
            Assert.AreEqual(expected, actual1);

            var input2 = "    Mary had a little lamb.\r\nPeter called for the wolf, and Aesop came.\r\nCinderella likes shoes.     ";
            var actual2 = _parserService.Parse(input2, "Xml");
            Assert.AreEqual(expected, actual2);
        }

        [TestMethod]
        public void ParserService_Parse_ShouldParseTheTextAsCsv()
        {
            var expected = ", Word 1, Word 2, Word 3, Word 4, Word 5, Word 6, Word 7, Word 8\r\nSentence 1, a, had, lamb, little, Mary\r\nSentence 2, Aesop, and, called, came, for, Peter, the, wolf\r\nSentence 3, Cinderella, likes, shoes\r\n";

            var input1 = "Mary had a little lamb. Peter called for the wolf, and Aesop came.\r\nCinderella likes shoes.";
            var actual1 = _parserService.Parse(input1, "Csv");
            Assert.AreEqual(expected, actual1);

            var input2 = "  Mary had a little lamb.\r\nPeter called for the wolf, and Aesop came.\r\nCinderella likes shoes.    ";
            var actual2 = _parserService.Parse(input2, "Csv");
            Assert.AreEqual(expected, actual2);
        }
    }
}
