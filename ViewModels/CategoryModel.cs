using TestSubject.Models;

namespace TestSubject.ViewModels
{
    public record class CategoryModel (int Id, string Name, int? ParentId, Category? Parent);
}
