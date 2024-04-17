using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GeorgeShopAndRecipe.Attributes
{
    public class NotARecipeDeveloperAttribute : ActionFilterAttribute
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

        }
    }
}
