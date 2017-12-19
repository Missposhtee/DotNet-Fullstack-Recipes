using AfricanRecipe.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AfricanRecipe.Models;
using AfricanRecipe.Data;

namespace AfricanRecipe.Services
{


    public class AfricanRecipeService : IAfricanRecipeService
    {

        private readonly Guid _userId;
        public AfricanRecipeService(Guid userId)
        {
            _userId = userId;
        }

       



        public bool CreateAfricanRecipe(AfricanRecipeCreateModel model)
        {
            var entity =
       new AfricanRecipeEntity
       {
           OwnerId = _userId,
           RecipeName = model.RecipeName,
           Ingredients = model.Ingredients,
           RecipeTribe = model.RecipeTribe,
           CreatedUtc = DateTimeOffset.Now

       };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.AfricanRecipe.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAfricanRecipe(int RecipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                          .AfricanRecipe
                           .Single(e => e.RecipeId == RecipeId && e.OwnerId == _userId);


                //Mark for deletion
                ctx.AfricanRecipe.Remove(entity);

                //Only do one change
                return ctx.SaveChanges() == 1;

            }
        }


        public IEnumerable<AfricanRecipeListModel> GetAfricanRecipe()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                      .AfricanRecipe
                      .Where(e => e.OwnerId == _userId)
                      .Select(
                        e =>
                            new AfricanRecipeListModel
                            {
                                RecipeId = e.RecipeId,
                                RecipeName = e.RecipeName,
                                RecipeTribe = e.RecipeTribe,
                                CreatedUtc = e.CreatedUtc
                            }
                        );
                return query.ToArray();
            }
        }

        public AfricanRecipeDetailsModel GetAfricanRecipeById(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AfricanRecipe
                        .Single(e => e.RecipeId == recipeId && e.OwnerId == _userId);

                return
                     new AfricanRecipeDetailsModel
                     {
                         RecipeId = entity.RecipeId,
                         RecipeName= entity.RecipeName,
                         Ingredients = entity.Ingredients,
                         RecipeTribe = entity.RecipeTribe,
                         CreatedUtc = entity.CreatedUtc,
                         ModifiedUtc = entity.ModifiedUtc
                     };
            }
        }

        public bool UpdateAfricanRecipe(AfricanRecipeEditModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AfricanRecipe
                        .Single(e => e.RecipeId== model.RecipeId && e.OwnerId == _userId);

                entity.RecipeName = model.RecipeName;
                entity.Ingredients = model.Ingredients;
                entity.RecipeTribe = model.RecipeTribe;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }




        }
    }
}
















