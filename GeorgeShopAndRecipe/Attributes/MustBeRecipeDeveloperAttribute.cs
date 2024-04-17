using GeorgeShopAndRecipe.Core.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using GeorgeShopAndRecipe.Extensions;
using GeorgeShopAndRecipe.Controllers;

namespace GeorgeShopAndRecipe.Attributes
{
    public class MustBeRecipeDeveloperAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            IRecipeDeveloperService? recipeDeveloperService = context.HttpContext
                .RequestServices.GetService<IRecipeDeveloperService>();

            if (recipeDeveloperService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (recipeDeveloperService != null && recipeDeveloperService.ExistByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(RecipeDeveloperController.Become), "RecipeDeveloper", null);
            }

        }
    }
}
