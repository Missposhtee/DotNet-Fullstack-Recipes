using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanRecipe.Models
{
   public  class AfricanRecipeListModel
   {
        public int RecipeId { get; set; }

        public string RecipeName { get; set; }

        public string RecipeTribe { get; set; }

        [Display(Name = "Created")]

        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => $"[{RecipeId}] {RecipeName}";
   }
}

