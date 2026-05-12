using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [Area("AdminPanel")]
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.Include(c=>c.).Where(c => !c.isDeleted).ToListAsync();

            return View(categories);
        }
    }
}
