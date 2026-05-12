using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    public class DashboardController : Controller
    {

        [Area("AdminPanel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
