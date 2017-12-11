using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSnippets.Models
{
    public class SnippetEdit
    {
        [Required]
        public int SnippetId { get; set; }

        public bool IsStarred { get; set; }

        [MaxLength(120)]
        public string Phrase { get; set; }

        [MaxLength(50)]
        public string Language { get; set; }

        [MaxLength(140)]
        public string Meaning { get; set; }

    }
}
