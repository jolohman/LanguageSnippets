using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSnippets.Data
{
    public class Snippet
    {
        [Key]
        public int      SnippetId           { get; set; }

        [Required]
        public Guid     OwnerId             { get; set; }

        [Required]
        public string   Phrase              { get; set; }

        [Required]
        public string   Language            { get; set; }

        [Required]
        public string   Meaning             { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc    { get; set; }

        
        public DateTimeOffset ModifiedUtc   { get; set; }
    }
}
