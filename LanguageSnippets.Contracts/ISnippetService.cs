using LanguageSnippets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSnippets.Contracts
{
    public interface ISnippetService
    {
        
        bool CreateSnippet(SnippetCreate model);
        IEnumerable<SnippetListItem> GetSnippet();
        
    }
}
