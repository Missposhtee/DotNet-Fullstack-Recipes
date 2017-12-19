using AfricanRecipe.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AfricanRecipe.Models;

namespace AfricanRecipeWeb.Tests.Controller.AfricanRecipeControllerTests
{
    public class FakeAfricanRecipeService :IAfricanRecipeService
    {
        public int CreateAfricanRecipeCallCount { get; private set; }
        public bool CreateAfricanRecipeReturnValue { private get; set; } = true;

        public bool CreateAfricanRecipe(AfricanRecipeCreateModel model)
        {
            CreateAfricanRecipeCallCount++;

            return CreateAfricanRecipeReturnValue;
        }


        public IEnumerable<AfricanRecipeListModel> GetAfricanRecipe()
        {
            throw new NotImplementedException();
        }

        public AfricanRecipeDetailsModel GetAfricanRecipeById(int RecipeId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAfricanRecipe(AfricanRecipeEditModel model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAfricanRecipe(int RecipeId)
        {
            throw new NotImplementedException();
        }
    }
}
