using System.Xml.Serialization;

namespace Nordea.CodingExercise.Models
{
    public class Text
    {
        [XmlElement("Sentence")]
        public Sentence[] Sentences { get; set; }
    }
}
