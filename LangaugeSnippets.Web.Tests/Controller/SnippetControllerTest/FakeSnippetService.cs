using LanguageSnippets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSnippets.Models;

namespace LangaugeSnippets.Web.Tests.Controller.SnippetControllerTest
{
    public class FakeSnippetService : ISnippetService
    {
        public int CreateSnippetCallCount { get; private set; }
        public bool CreateNoteReturnValue { private get; set; } = true;

        public bool CreateSnippet(SnippetCreate model)
        {
            CreateSnippetCallCount++;

            return CreateNoteReturnValue;
        }

        public bool DeleteSnippet(int snippetId)
        {
            throw new NotImplementedException();
        }

        public bool EditSnippet(SnippetEdit model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SnippetListItem> GetSnippet()
        {
            throw new NotImplementedException();
        }

        public SnippetDetail GetSnippetById(int SnippetId)
        {
            throw new NotImplementedException();
        }
    }
}
