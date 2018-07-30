using System.Xml.Serialization;

namespace Nordea.CodingExercise.Models
{
    public class Sentence
    {
        [XmlElement("Word")]
        public string[] Words { get; set; }
    }
}
