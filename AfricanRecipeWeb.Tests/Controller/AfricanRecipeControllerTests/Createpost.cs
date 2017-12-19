using AfricanRecipe.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AfricanRecipeWeb.Tests.Controller.AfricanRecipeControllerTests
{
    [TestClass]
    public class Createpost: AfricanRecipeControllerTestsBase
    {
      [TestMethod]
      public void ShouldReturnRedirectToRouteResult()
      {
        //Act
        var result = Controller.Create(new AfricanRecipeCreateModel());
        Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
      }

      [TestMethod]
      public void ShouldCallCreateOnce()
      {
        var result = Controller.Create(new AfricanRecipeCreateModel());
        Assert.AreEqual(1, Service.CreateAfricanRecipeCallCount);
      }
    }
}
