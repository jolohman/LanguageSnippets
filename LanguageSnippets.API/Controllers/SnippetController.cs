using LanguageSnippets.Models;
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
        public IHttpActionResult GetAll()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var snippetService = new SnippetService(userId);
            var snippets = snippetService.GetSnippet();

            return Ok(snippets);
        }

        //Get /api/Snippet/3
        public IHttpActionResult Get(int id)
        {
            SnippetService snippetService = CreateSnippetService();
            var snippet = snippetService.GetSnippetById(id);

            return Ok(snippet);
        }

        //Put /api/Snippet
        public IHttpActionResult Post(SnippetCreate snippet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateSnippetService();

            if (!service.CreateSnippet(snippet))
                return InternalServerError();

            return Ok();

        }
        
        //Put /api/Snippet
        public IHttpActionResult Put(SnippetEdit snippet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateSnippetService();

            if (!service.EditSnippet(snippet))
                return InternalServerError();

            return Ok();
        }

        //Delete /api/Snippet/3
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSnippetService();

            if (!service.DeleteSnippet(id))
                return InternalServerError();

            return Ok();
        }

        private SnippetService CreateSnippetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var snippetService = new SnippetService(userId);
            return snippetService;
        }
    }
}
