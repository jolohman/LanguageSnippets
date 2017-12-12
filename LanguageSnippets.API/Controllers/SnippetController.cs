using LanguageSnippets.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LanguageSnippets.API.Controllers
{
    [Authorize]
    public class SnippetController : ApiController
    {
        //GET /api/Snippet
        public IHttpActionResult Get()
        {
            SnippetService snippetService = CreateSnippetService();
            var snippets = snippetService.GetSnippet();
            return Ok(snippets);
        }

        private SnippetService CreateSnippetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var snippetService = new SnippetService(userId);
            return snippetService;
        }
    }
}
