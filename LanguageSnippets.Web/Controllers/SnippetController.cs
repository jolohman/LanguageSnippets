using LanguageSnippets.Models;
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
            var model = new SnippetListItem[0];
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
            if(ModelState.IsValid)
            {

            }

            return View(model);
        }
    }
}