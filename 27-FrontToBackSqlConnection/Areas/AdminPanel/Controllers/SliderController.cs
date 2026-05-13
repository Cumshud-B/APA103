using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private readonly AppDbContext context;

        public SliderController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {

            List<Slider> sliders = await context.Sliders.Where(s => !s.isDeleted).ToListAsync();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Test()
        {
            return Content(Guid.NewGuid().ToString());
        }

        [HttpPost]

        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError(nameof(Slider.Photo), "File type must be image");
                return View(slider);
            }

            if(slider.Photo.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError(nameof(Slider.Photo), "File size must be less than 2MB");
                return View(slider);
            }

            string fileName = string.Concat(Guid.NewGuid().ToString(), slider.Photo.FileName);

            string path = Path.Combine(_env.WebRootPath, "assets", "images", "website-images", slider.Photo.FileName);

            FileStream fileStream = new FileStream(Path.Combine("wwwroot", "uploads", slider.Photo.FileName), FileMode.Create);

            await slider.Photo.CopyToAsync(fileStream);

            fileStream.Close();

            slider.Image= fileName;

            await context.AddAsync(slider);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }
    }
}
