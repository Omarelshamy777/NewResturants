using System.ComponentModel.DataAnnotations;

namespace Resturants.Application.Contracts.ResturantApp.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string? Categories { get; set; }

        public double TotalPrice { get; set; }
    }
}
