using System;
using TestSubject.Models;

namespace TestSubject.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ProductModel> ProductsModels { get; set; } = new List<ProductModel>();
        public IEnumerable<CategoryModel> CategoriesModels { get; set; } = new List<CategoryModel>();
    }
}
