using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GeorgeShopAndRecipe.Core.Constants.RoleConstants;
namespace GeorgeShopAndRecipe.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRole)]
    [Area("Admin")]
    public class AdminBaseController : Controller
    {
       
    }
}
