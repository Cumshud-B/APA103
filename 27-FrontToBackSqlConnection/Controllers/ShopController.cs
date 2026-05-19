using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.Where(p=>!p.isDeleted).Include(p=>p.ProductImages.Where(pi=>pi.IsPrimary != null)).ToListAsync();

            ShopVM shopVM = new()
            {
                Products = products
            };

            return View(shopVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Where(p=>!p.isDeleted)
                .Include(p=>p.ProductImages
                .Where(pi=>pi.IsPrimary != null))
                .Include(p=>p.Category)
                .Include(p=>p.ProductTags)
                .ThenInclude(pt=>pt.Tag)
                .FirstOrDefaultAsync(p=> p.Id == id);

            List<Product> relatedProducts = await _context.Products.Where(p => !p.isDeleted).Include(p=>p.ProductImages).Where(p => p.CategoryId == product.CategoryId && p.Id != id).Take(2).ToListAsync();

            if (product == null) return NotFound();

            DetailsVM detailsVM = new DetailsVM
            {
                Product = product,
                RelatedProducts = relatedProducts,
            };
            return View(detailsVM);
        }
    }
}
