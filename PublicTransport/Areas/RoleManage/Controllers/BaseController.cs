using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;

namespace PublicTransport.Areas.RoleManage.Controllers
{
    [Authorize(Roles = UserConstants.Administrator)]
    [Area("RoleManage")]
    public class BaseController : Controller
    {

    }
}
