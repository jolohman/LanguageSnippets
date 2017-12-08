using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSnippets.Models
{
    public class SnippetDetail 
    {
        [Display(Name ="Important")]
        public bool IsStarred { get; set; }

        public string Phrase { get; set; }
       
        public string Language { get; set; }
        
        public string Meaning { get; set; }
        
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public int SnippetId { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }


        public override string ToString() => $"[{SnippetId}] {Phrase}";
    }
}
