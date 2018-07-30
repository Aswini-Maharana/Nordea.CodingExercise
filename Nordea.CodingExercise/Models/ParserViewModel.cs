using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nordea.CodingExercise.Models
{
    public class ParserViewModel
    {
        [DisplayName("Enter a string to parse:")]
        [Required]
        public string TextToParse { get; set; }

        [DisplayName("Parser output:")]
        public string ParsedText { get; set; }

        [DisplayName("Select a parser:")]
        [Required]
        public string[] Parsers { get; set; }
    }
}