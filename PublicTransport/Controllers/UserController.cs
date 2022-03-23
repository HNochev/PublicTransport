using Microsoft.AspNetCore.Mvc;

namespace PublicTransport.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
