using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using LanguageSnippets.Models;
using LanguageSnippets.Services;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace LanguageSnippets.Web.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Snippets")]
    public class SnippetsController : ApiController 
    {
        private bool SetStarState(int snippetId, bool newState)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SnippetService(userId);

            var detail = service.GetSnippetById(snippetId);

            var updatedSnippet =
                new SnippetEdit
                {
                    SnippetId = detail.SnippetId,
                    IsStarred = newState,
                    Phrase = detail.Phrase,
                    Language = detail.Language,
                    Meaning = detail.Meaning,
                };

            return service.EditSnippet(updatedSnippet);
        }

        [Route("{id}/Star")]
        public bool Put(int id)
        {
            return SetStarState(id, true);
        }

        [Route("{id}/Star")]
        public bool Delete(int id)
        {
            return SetStarState(id, false);
        }
    }
}