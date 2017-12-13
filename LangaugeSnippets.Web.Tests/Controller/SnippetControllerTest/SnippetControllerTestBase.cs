using LanguageSnippets.Contracts;
using LanguageSnippets.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangaugeSnippets.Web.Tests.Controller.SnippetControllerTest
{ 
    [TestClass]
    public abstract class SnippetControllerTestBase
    {
        protected SnippetController Controller;

        protected FakeSnippetService Service;

        //Arrange
        //Act
        //Assert

        [TestInitialize]
        public virtual void Arrange()
        {
            Service = new FakeSnippetService();

            Controller = new SnippetController(
                new Lazy<ISnippetService>(() => Service));
         } 
    }
}
