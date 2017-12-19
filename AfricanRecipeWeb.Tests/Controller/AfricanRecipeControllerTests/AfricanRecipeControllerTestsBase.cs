using AfricanRecipe.Contracts;
using AfricanRecipe.WebMvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanRecipeWeb.Tests.Controller.AfricanRecipeControllerTests
{
   [TestClass]
   public abstract class AfricanRecipeControllerTestsBase
   {
        //Arrange
        //Need a AfricanRecipe Controller Instantiated
        //Protected - Only base class and inheritors can see it.
        protected AfricanRecipeController Controller;
        protected FakeAfricanRecipeService Service;




        //Virtual means that it can be overridden
        //Arrange is what we're doing -> Good name for this method would be Arrange
        [TestInitialize]
        public virtual void Arrange()
        {
            Service = new FakeAfricanRecipeService();
            Controller = new AfricanRecipeController(
                new Lazy<IAfricanRecipeService>(() => Service));
        }
   }
}
