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
            return View();
        }
    }
}