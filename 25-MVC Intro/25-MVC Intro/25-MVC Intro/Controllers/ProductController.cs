using Microsoft.AspNetCore.Mvc;

namespace _25_MVC_Intro.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
