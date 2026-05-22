using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Product;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<ProductGetVM> productGetVMs = await _context.Products
                .Where(p => !p.isDeleted)
                .Include(P => P.ProductImages)
                .Include(p => p.Category)
                .Select(p => new ProductGetVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    SKU = p.SKU,
                    Image = p.ProductImages.FirstOrDefault().Image,
                })

                .ToListAsync();

            //List<ProductGetVM> productGetVMs = new();

            //foreach (var product in products)
            //{

            //    productGetVMs.Add(new ProductGetVM
            //    {
            //        Id = product.Id,
            //        Name = product.Name,
            //        Price = product.Price,
            //        CategoryName = product.Category.Name,
            //        SKU = product.SKU,
            //        Image = product.ProductImages.FirstOrDefault()?.Image,
            //    });

            //}


            return View(productGetVMs);
        }

        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new()
            {
                Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.isDeleted).ToListAsync()
            };

            return View(productCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {

            productCreateVM.Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync();
            productCreateVM.Tags = await _context.Tags.Where(t => !t.isDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productCreateVM);


            if (productCreateVM.MainPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(ProductCreateVM.MainPhoto), "Please select an image file.");
                return View(productCreateVM);
            }

            if (productCreateVM.HoverPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(ProductCreateVM.HoverPhoto), "Please select an image file.");
                return View(productCreateVM);
            }

            if (productCreateVM.MainPhoto.CheckFileSize(FileSize.MB,1))
            {
                ModelState.AddModelError(nameof(ProductCreateVM.MainPhoto), "Please select an image file.");
                return View(productCreateVM);
            }

            if (productCreateVM.HoverPhoto.CheckFileSize(FileSize.MB,1))
            {
                ModelState.AddModelError(nameof(ProductCreateVM.HoverPhoto), "Please select an image file.");
                return View(productCreateVM);
            }

            bool existCategory = productCreateVM.Categories.Any(c => c.Id == productCreateVM.CategoryId);

            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.CategoryId), "Category does not exist.");
                return View(productCreateVM);
            }


            bool existTag = productCreateVM.TagIds.Any(tagId => productCreateVM.Tags.Exists(t => t.Id == tagId));

            if(!existTag)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.TagIds), "One or more selected tags do not exist.");
                return View(productCreateVM);
            }

            ProductImage mainImage = new()
            {
                Image = await productCreateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets" , "images", "website-images"),
                IsPrimary = true
            };
            ProductImage hoverImage = new()
            {
                Image = await productCreateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = false
            };

            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                SKU = productCreateVM.SKU,
                Description = productCreateVM.Description,
                CategoryId = productCreateVM.CategoryId.Value,
                ProductImages = new List<ProductImage> { mainImage, hoverImage }

            };

            if(productCreateVM.TagIds != null)
            {
                product.ProductTags = productCreateVM.TagIds.Select(tagId => new ProductTag
                {
                    TagId = tagId
                }).ToList();
            }

            string info = string.Empty;

            if(productCreateVM.AdditionalPhoto != null)
            {
                foreach (var file in productCreateVM.AdditionalPhoto)
                {
                    if (!file.CheckFileType("image/"))
                    {
                        info += $"<p class=\"text-danger\">File {file.FileName} is not an image.</p>";
                        continue;
                    }

                    if (!file.CheckFileSize(FileSize.MB, 1))
                    {
                        info += $"<p class=\"text-danger\>File {file.FileName} exceeds the size limit.</p>";
                        continue;
                    }

                    product.ProductImages.Add(new ProductImage
                    {
                        Image = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                        IsPrimary = null
                    });
                }
            }
           

           

            TempData["FileInfo"] = info;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null || Id < 1) BadRequest();
            Product? existProduct = await _context.Products.Include(p=>p.ProductImages).Include(p=>p.ProductTags).FirstOrDefaultAsync(p => p.Id == Id);

            if (existProduct == null) return NotFound();

            if (!ModelState.IsValid) return View();

            ProductUpdateVM productUpdateVM = new()
            {
                Name = existProduct.Name,
                Price = existProduct.Price,
                SKU = existProduct.SKU,
                Description = existProduct.Description,
                CategoryId = existProduct.CategoryId,
                TagIds = existProduct.ProductTags?.Select(pt => pt.TagId).ToList(),
                Categories = await _context.Categories.ToListAsync(),
                Tags = await _context.Tags.ToListAsync()ç
                productİmages = existProduct.ProductImages
            };

            return View(productUpdateVM);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int? Id, ProductUpdateVM productUpdateVM)
        {
            if (Id == null || Id < 1) return BadRequest();
            productUpdateVM.Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync();
            Product? existProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (existProduct == null) return NotFound();

            if (!ModelState.IsValid) return View(productUpdateVM);
            bool existCategory = productUpdateVM.Categories.Any(c => c.Id == productUpdateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductUpdateVM.CategoryId), "Category does not exist.");
                return View(productUpdateVM);
            }

            if(productUpdateVM.TagIds != null)
            {
                bool existTag = productUpdateVM.TagIds.Any(tagId => productUpdateVM.TagIds.Exists(t => t == tagId));
                if (!existTag)
                {
                    ModelState.AddModelError(nameof(ProductUpdateVM.TagIds), "One or more selected tags do not exist.");
                    return View(productUpdateVM);
                }
            }


            if (productUpdateVM.TagIds == null)
            {
                productUpdateVM.TagIds = new();
            }

            if (productUpdateVM.TagIds != null)
            {


             



                _context.ProductTags.RemoveRange(existProduct.ProductTags.Where(pTag => !productUpdateVM.TagIds.Exists(tId => tId == pTag.TagId)).ToList());
                _context.ProductTags.AddRange(productUpdateVM.TagIds
                    .Where(tId => !existProduct.ProductTags
                    .Exists(pTag => pTag.TagId == tId))
                    .Select(tId => new ProductTag { TagId = tId, ProductId = existProduct.Id }).ToList());

            }
           


            existProduct.Name = productUpdateVM.Name;
            existProduct.Price = productUpdateVM.Price;
            existProduct.SKU = productUpdateVM.SKU;
            existProduct.Description = productUpdateVM.Description;
            existProduct.CategoryId = productUpdateVM.CategoryId.Value;
           


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
