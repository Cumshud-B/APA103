using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace _27_FrontToBackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
            
        }
         



        //List<Slider> _sliders = new List<Slider>
        //{
        //    new Slider{Id=1, Title="Basliq-1", Subtitle="Komekci Basliq-1", Description= "Gullerden qalmadi", Image="1-1-524x617.png ", Order=1, isDeleted=false},
        //    new Slider{Id=2, Title="Basliq-2", Subtitle="Komekci Basliq-2", Description= "Mohtesem endirim", Image="1-2-524x617.png", Order=2, isDeleted=true},
        //    new Slider{Id=3, Title="Basliq-3", Subtitle="Komekci Basliq-3", Description= "Xirdalana manatdan", Image="1-3-570x633.jpg", Order=3, isDeleted=false}

        //};
        public IActionResult Index()
        {
            
            //_context.AddRange(_sliders);
            //_context.SaveChanges(); 

            //Product product = _context.Products.Include(p => p.Category).FirstOrDefault();
            //Category category = _context.Categories.FirstOrDefault(c => c.Id == product.CategoryId);


            List<Slider> sliders = _context.Sliders.OrderBy(s => s.Order).Where(s => !s.isDeleted).Take(2).ToList();

            HomeVM homeVM = new()
            {
                Sliders = sliders
            };

            return View(homeVM);
        }
    }
}
