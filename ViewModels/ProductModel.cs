using TestSubject.Models;

namespace TestSubject.ViewModels
{
    public record class ProductModel(int Id, string Name, string Description, int ParentId, Category Parent);
}
