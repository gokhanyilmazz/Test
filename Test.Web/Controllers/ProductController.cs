using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Models;

namespace Test.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly TestContext db;
        public ProductController(TestContext _db)
        {
            db = _db;
        }
        [Authorize(Roles = "1,2,3")]
        public IActionResult Index()
        {
            List<Product> list = db.Products.ToList();
            return View(list);
        }
        
    }
}
