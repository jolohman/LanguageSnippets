using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSnippets.Models
{
    public class SnippetCreate
    {
        [Required]
        [MaxLength(120)]
        public string Phrase { get; set; }

        [Display(Name = "Useful")]
        public bool IsStarred { get; set; }

        [MaxLength(140)]
        public string Meaning { get; set; }

        [Required]
        [MaxLength(50)]
        public string Language { get; set; }

        public override string ToString() => Phrase;
    }
}
