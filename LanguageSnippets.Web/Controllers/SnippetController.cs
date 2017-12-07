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
        // GET: Snippet
        public ActionResult Index()
        {
           
            var service = CreateSnippetService();
            var model = service.GetSnippet();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SnippetCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateSnippetService();

            if (service.CreateSnippet(model))
            {
                TempData["SaveResult"] = "Snippet was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Sorry, your snippet could not be created. Please try again.");

            return View(model);
        }

        private SnippetService CreateSnippetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SnippetService(userId);
            return service;
        }
    }
}