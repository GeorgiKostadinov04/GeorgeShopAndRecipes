using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GeorgeShopAndRecipe.Core.Constants.AdministratorConstants;
namespace GeorgeShopAndRecipe.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRole)]
    [Area(AdminAreaName)]
    public class AdminBaseController : Controller
    {
       
    }
}
