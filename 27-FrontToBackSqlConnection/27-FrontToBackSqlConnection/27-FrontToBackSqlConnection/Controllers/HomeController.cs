
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appContext;


        public HomeController(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        List<Sliders> _sliders = new List<Sliders>
        {
          new Sliders {Id=1,Title="Basliq-1",Subtitle="komekci basliq-1",Description="GullerdenQalmadi",Image="1-1-524x617.png" },
          new Sliders {Id=2,Title="Basliq-2",Subtitle="komekci basliq-2",Description="Mohtesem endirim",Image="1-2-524x617.png" },
          new Sliders {Id=3,Title="Basliq-3",Subtitle="komekci basliq-3",Description="Mohtesem guleer",Image="78c2642b95d9adcb4d586cce1b56a416.jpg" }
        };


        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                Sliders = _sliders,
            };
            
            return View(homeVM);
        }

    }
}
