using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanRecipe.Models
{
    public class AfricanRecipeDetailsModel
    {
  
      
            public int RecipeId { get; set; }

            public string RecipeName { get; set; }

            public string Ingredients { get; set; }

            public string RecipeTribe  { get; set; }

            public DateTimeOffset CreatedUtc { get; set; }

            public DateTimeOffset? ModifiedUtc { get; set; }

            public override string ToString() => $"[{RecipeId}] {RecipeName}";
        
    }
}
