using AfricanRecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanRecipe.Contracts
{
   public interface IAfricanRecipeService
    {
        bool CreateAfricanRecipe(AfricanRecipeCreateModel model);
        IEnumerable<AfricanRecipeListModel> GetAfricanRecipe();
        AfricanRecipeDetailsModel GetAfricanRecipeById(int RecipeId);
        bool UpdateAfricanRecipe(AfricanRecipeEditModel model);
        bool DeleteAfricanRecipe(int RecipeId);
    }
}
