using System.IO;
using System.Xml.Serialization;

namespace Nordea.CodingExercise.Parsers
{
    internal class XmlParser : Parser
    {
        internal override string Parse(string input)
        {
            string result = string.Empty;
            XmlSerializer xmlSerializer;
            StringWriter stringWriter;
            try
            {
                var text = base.GetText(input);

                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);

                xmlSerializer = new XmlSerializer(text.GetType());
                stringWriter = new StringWriter();

                xmlSerializer.Serialize(stringWriter, text, ns);
                result = stringWriter.ToString();
            }
            finally
            {
                xmlSerializer = null;
                stringWriter = null;
            }
            return result;
        }
    }
}
