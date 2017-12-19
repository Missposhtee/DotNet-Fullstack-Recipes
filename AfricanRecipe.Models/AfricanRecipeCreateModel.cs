using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanRecipe.Models
{
    public class AfricanRecipeCreateModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least two characters.")]
        [MaxLength(250)]
        public string RecipeName { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Ingredients { get; set; }

        [Required]
        [MaxLength(20)]
        public string RecipeTribe { get; set; }

        public override string ToString() => RecipeName;
    }
}

