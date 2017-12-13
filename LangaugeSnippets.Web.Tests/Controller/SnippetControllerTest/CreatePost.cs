using LanguageSnippets.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LangaugeSnippets.Web.Tests.Controller.SnippetControllerTest
{
    [TestClass]
    public class CreatePost : SnippetControllerTestBase
    {
        [TestMethod]
        public void ShouldReturnRedirectToRouteResult()
        {
            //Act
            var result = Controller.Create(new SnippetCreate());

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void ShouldCallCreateOnce()
        {
            var result = Controller.Create(new SnippetCreate());

            Assert.AreEqual(1, Service.CreateSnippetCallCount);
        }
    }
}
