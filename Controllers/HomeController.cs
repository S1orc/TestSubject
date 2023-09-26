using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestSubject.Models;
using TestSubject.ViewModels;

namespace TestSubject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController (ApplicationContext context)
        {
            db = context;
        }

        public async Task <IActionResult> Index(int? categoryId)
        {
            var products = db.Products.Where(p => p.Category.Id == categoryId).ToList();
            var categories = db.Categories.ToList();

            List<CategoryModel> categModels = categories
                .Select(c => new CategoryModel(c.Id, c.Name, c.ParentId, c.Parent, c.Children)).ToList();

            categModels.Insert(0, new CategoryModel(0, "все", null, null, null));

            IndexViewModel viewModel = new() { CategoriesModels = categModels, ProductsModels = products };

            if (categoryId != null && categoryId > 0)
            {
                viewModel.ProductsModels = products.Where(p => p.Category.Id == categoryId);
            }

            return View(viewModel);
        }
    }
}
