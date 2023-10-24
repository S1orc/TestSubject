using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;
using TestSubject.Models;
using TestSubject.ViewModels;

namespace TestSubject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        /*        public async Task<IActionResult> Index()
                {
                    List<Category> categories = db.Categories.ToList();
                    List<Product> products = db.Products.ToList();
                    List<CategoryModel> categoryModels = categories.Select(c => new CategoryModel(c.Id, c.Name, c.ParentId, c.Parent)).ToList();
                    List<ProductModel> productModels = products.Select(p => new ProductModel(p.Id, p.Name, p.Description, p.CategoryId, p.Category)).ToList();

                    IndexViewModel viewModel = new() { CategoriesModels= categoryModels, ProductsModels = productModels };
                    return View(viewModel);
                }*/

        public async Task<IActionResult> Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory(int? ParentId)
        {
            var ResultingCategories = await db.Categories.Where(c => c.ParentId == ParentId).ToListAsync();
            return PartialView(ResultingCategories);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int? categoryId)
        {
            var ResultingProducts = await db.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
            return PartialView("ProductPartial", ResultingProducts);
        }

/*        [HttpPost]
        public JsonResult AddProduct(ProductModel newProduct)
        {
            return View();
        }*/

        [HttpPost]
        public async Task<JsonResult> DeleteProduct(int? productId)
        {
            if (productId == null)
            {
                return Json(new { success = false, message = "Произошла ошибка при удалении товара!" });
            }

            var product = await db.Products.Where(p => p.Id == productId).FirstOrDefaultAsync();

            if (product == null)
            {
                return Json(new { success = false, message = "Продукт не найден!" });
            }

            try
            {
                db.Products.Remove(product);
                await db.SaveChangesAsync();
                return Json(new { success = true, message = "Продукт успешно удален!" });
            }
            catch(Exception ex)
            {
                return Json(new {success = false, message = ex.Message});
            }
        }
    }
}
