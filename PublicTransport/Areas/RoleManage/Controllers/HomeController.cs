using Microsoft.AspNetCore.Mvc;

namespace PublicTransport.Areas.RoleManage.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
