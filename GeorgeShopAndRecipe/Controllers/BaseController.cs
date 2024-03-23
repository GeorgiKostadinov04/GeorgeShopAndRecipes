using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeorgeShopAndRecipe.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
