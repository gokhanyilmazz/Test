using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test.Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "1,2,3")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
