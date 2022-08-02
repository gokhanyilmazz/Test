using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

using Test.Data;
using Test.Models;

namespace Test.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly TestContext db;
        public UserController(TestContext _db)
        {
            db = _db;
        }
        [Authorize(Roles = "1")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User _user)
        {
            Test.Models.User user = db.Users.FirstOrDefault(x => x.UserName == _user.UserName && x.PassWord == _user.PassWord && x.IsActive == true && x.IsDeleted == false);

            if (user != null)
            {
                List<Claim> userClaims = new List<Claim>();

                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Name, user.UserName));
                userClaims.Add(new Claim(ClaimTypes.GivenName, user.FullName));
                userClaims.Add(new Claim(ClaimTypes.Role, user.UserTypeId.ToString()));

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
       authProperties);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                TempData.Add("success", "Alt bölge eklendi");
                return View();
            }
        }

    }

}

