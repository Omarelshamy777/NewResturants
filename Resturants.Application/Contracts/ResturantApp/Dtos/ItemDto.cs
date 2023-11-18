namespace Resturants.Application.Contracts.ResturantApp.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string? Categories { get; set; }
    }
}
