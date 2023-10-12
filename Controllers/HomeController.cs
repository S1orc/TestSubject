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

        public async Task<IActionResult> Index()
        {
            List<Category> categories = db.Categories.ToList();
            List<Product> products = db.Products.ToList();
            List<CategoryModel> categoryModels = categories.Select(c => new CategoryModel(c.Id, c.Name, c.ParentId, c.Parent)).ToList();
            List<ProductModel> productModels = products.Select(p => new ProductModel(p.Id, p.Name, p.Description, p.CategoryId, p.Category)).ToList();

            IndexViewModel viewModel = new() { CategoriesModels= categoryModels, ProductsModels = productModels };
            return View(viewModel);
        }

        /*        public IActionResult Index()
                {
                    var rootCategories = db.Categories.Where(c => c.ParentId == null).ToList();
                    return View(rootCategories);
                }*/
    }
}
