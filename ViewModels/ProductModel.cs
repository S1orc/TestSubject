using TestSubject.Models;

namespace TestSubject.ViewModels
{
    public record class ProductModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public int CategoryId { get; init; }
        public Category Category { get; init; }
    }
}
