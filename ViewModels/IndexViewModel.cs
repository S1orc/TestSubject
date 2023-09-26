using System;
using TestSubject.Models;

namespace TestSubject.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> ProductsModels { get; set; } = new List<Product>();
        public IEnumerable<CategoryModel> CategoriesModels { get; set; } = new List<CategoryModel>();
    }
}
