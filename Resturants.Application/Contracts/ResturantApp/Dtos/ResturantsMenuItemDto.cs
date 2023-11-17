namespace Resturants.Application.Contracts.ResturantApp.Dtos
{
    public class ResturantsMenuItemDto
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public double? ItemPrice { get; set; }
        public string? Categories { get; set; }
    }
}
