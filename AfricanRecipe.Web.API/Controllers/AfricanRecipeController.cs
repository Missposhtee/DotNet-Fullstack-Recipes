using AfricanRecipe.Models;
using AfricanRecipe.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AfricanRecipe.Web.API.Controllers
{
    [Authorize]
    public class AfricanRecipeController : ApiController
    {
       //Get/api/AfricanRecipe

            public IHttpActionResult GetAll()
            {
            var AfricanRecipeService = CreateAfricanRecipeService();
            var AfricanRecipe = AfricanRecipeService.GetAfricanRecipe();
            return Ok(AfricanRecipe);
            }

        public IHttpActionResult Get(int id)
        {
            var AfricanRecipeService = CreateAfricanRecipeService();
            var AfricanRecipe = AfricanRecipeService.GetAfricanRecipeById(id);
            return Ok(AfricanRecipe);
        }

        public IHttpActionResult Post(AfricanRecipeCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateAfricanRecipeService();

            if (!service.CreateAfricanRecipe(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(AfricanRecipeEditModel africanRecipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAfricanRecipeService();

            if (!service.UpdateAfricanRecipe(africanRecipe))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAfricanRecipeService();

            if (!service.DeleteAfricanRecipe(id))
                return InternalServerError();

            return Ok();
        }

        

        private AfricanRecipeService CreateAfricanRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var AfricanRecipeService = new AfricanRecipeService(userId);
            return AfricanRecipeService;
        }

    }
}
