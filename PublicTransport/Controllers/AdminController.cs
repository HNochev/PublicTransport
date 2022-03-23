using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;

namespace PublicTransport.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public async Task<IActionResult> ManageUsers()
        {
            return View();
        }

        public async Task<IActionResult> CreateRole()
        {
            /*await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Administrator"
            });     */

            return Ok();
        }
    }
}
