using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Sliders;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.Utilities.Extensions;
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

        public async Task<IActionResult> Create(SliderCreateVM sliderCreateVM)
        {
            if (!sliderCreateVM.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(SliderCreateVM.Photo), "Photo is required");
                return View(sliderCreateVM);
            }


            if (!sliderCreateVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError(nameof(SliderCreateVM.Photo), "File type must be image");
                return View(sliderCreateVM);
            }

            if (!FileValidator.CheckFileSize(sliderCreateVM.Photo, FileSize.MB, 2))
            {


                Slider slider = new()
                {
                    Title = sliderCreateVM.Title,
                    Subtitle = sliderCreateVM.Subtitle,
                    Description = sliderCreateVM.Description,
                    Order = sliderCreateVM.Order,
                    Image = await sliderCreateVM.Photo.CreateFile(_env.WebRootPath, "assets", "images", "sliders"),

                };



                await context.AddAsync(sliderCreateVM);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(nameof(SliderCreateVM.Photo), "File size must be less than 2MB");
            return View(sliderCreateVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id is null || id < 1) return BadRequest();

            Slider? slider = await context.Sliders.Where(s => !s.isDeleted).FirstOrDefaultAsync(s => s.Id == id);

            if (slider == null) return NotFound();

            slider.Image.DeleteFile(_env.WebRootPath, "assets", "images", "sliders");

            context.Remove(slider);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();
            Slider? slider = await context.Sliders.Where(s => !s.isDeleted).FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();
            SliderUpdateVM sliderUpdateVM = new()
            {
                Title = slider.Title,
                Subtitle = slider.Subtitle,
                Description = slider.Description,
                Order = slider.Order,
                Image = slider.Image

            };
            return View(sliderUpdateVM);
        }
    }
}
