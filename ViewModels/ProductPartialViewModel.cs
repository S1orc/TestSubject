namespace TestSubject.ViewModels
{
    public class ProductPartialViewModel
    {
        public IEnumerable<ProductModel> ProductsModels { get; set; } = new List<ProductModel>();
        public IEnumerable<CategoryModel> CategoriesModels { get; set; } = new List<CategoryModel>();
    }
}
