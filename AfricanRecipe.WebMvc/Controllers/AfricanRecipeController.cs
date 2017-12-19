using AfricanRecipe.Contracts;
using AfricanRecipe.Models;
using AfricanRecipe.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AfricanRecipe.WebMvc.Controllers
{
    
    public class AfricanRecipeController : Controller
    {
        private readonly Lazy<IAfricanRecipeService> _africanRecipeService;

        public AfricanRecipeController()
        {
            _africanRecipeService = new Lazy<IAfricanRecipeService>(AfricanRecipeService);
        }

        /// <summary>
        /// Principally used for testing
        /// </summary>
        /// <param name="africanRecipeService"></param>
        public AfricanRecipeController(Lazy<IAfricanRecipeService> africanRecipeService)
        {
            _africanRecipeService = africanRecipeService;
        }

           // GET: AfricanRecipe
            public ActionResult Index()
            {
        
              var model = _africanRecipeService.Value.GetAfricanRecipe();
            return View(model);
            }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AfricanRecipeCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_africanRecipeService.Value.CreateAfricanRecipe(model))
            {
                TempData["SaveResult"] = "Hey! You Just Created A New Recipe.";

                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "You Just Failed Adding A Recipe,Please Try Again.");
            return View(model);
        }


        //Get method for Edit
        public ActionResult Edit(int id)
        {
            var detail = _africanRecipeService.Value.GetAfricanRecipeById(id);
            var model =
                  new AfricanRecipeEditModel
                  {
                      RecipeId = detail.RecipeId,
                      RecipeName = detail.RecipeName,
                      Ingredients = detail.Ingredients,
                      RecipeTribe = detail.RecipeTribe

                  };
            return View(model);

        }


        //Post method for Edit

        public ActionResult Details(int id)
        {
            var model = _africanRecipeService.Value.GetAfricanRecipeById(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AfricanRecipeEditModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RecipeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_africanRecipeService.Value.UpdateAfricanRecipe(model))
            {
                TempData["SaveResult"] = "Your Recipe was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Recipe could not be updated. Are You Missing Something?");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = _africanRecipeService.Value.GetAfricanRecipeById(id);
            return View(model);
        }

        //Action result for Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            //TODO: Handle failure
            _africanRecipeService.Value.DeleteAfricanRecipe(id);

            TempData["SaveResult"] = "You Successfully Deleted Your Recipe";

            return RedirectToAction("Index");
        }


        private IAfricanRecipeService AfricanRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AfricanRecipeService(userId);
            return service;
        }
    }
}