namespace Catalog.DTOs
{
    public record UpdateItemDto
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}