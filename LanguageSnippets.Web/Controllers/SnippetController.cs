using LanguageSnippets.Contracts;
using LanguageSnippets.Models;
using LanguageSnippets.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanguageSnippets.Web.Controllers
{
    [Authorize]
    public class SnippetController : Controller
    {
        private readonly Lazy<ISnippetService> _snippetService;

        public SnippetController()
        {
            _snippetService = new Lazy<ISnippetService>(CreateSnippetService);
        }

        /// <summary>
        /// Pricipally used for testing
        /// </summary>
        /// <param name="snippetService"></param>
        public SnippetController(Lazy<ISnippetService> snippetService)
        {
            _snippetService = snippetService;
        }


        // GET: Snippet
        public ActionResult Index()
        {
           
            var model = _snippetService.Value.GetSnippet();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new SnippetCreate();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SnippetCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_snippetService.Value.CreateSnippet(model))
            {
                TempData["SaveResult"] = "Snippet was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Sorry, your snippet could not be created. Please try again.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _snippetService.Value.GetSnippetById(id);

            return View(model);
        }

        public ActionResult Edit (int id)
        {
            var detail = _snippetService.Value.GetSnippetById(id);
            var model =
                new SnippetEdit
                {
                    SnippetId = detail.SnippetId,                   
                    Phrase = detail.Phrase,
                    Language = detail.Language,
                    Meaning = detail.Meaning,
                };

            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SnippetEdit model)
        {
            if(model.SnippetId != id)
            {
                ModelState.AddModelError("", "Id Mismatch... Better luck next time");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_snippetService.Value.EditSnippet(model))
            {
                TempData["SaveResult"] = "Your note was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model =_snippetService.Value.GetSnippetById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {

            _snippetService.Value.DeleteSnippet(id);

            TempData["SaveResult"] = "Your snippet was deleted";

            return RedirectToAction("Index");
        }

        private SnippetService CreateSnippetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SnippetService(userId);
            return service;
        }
    }
}