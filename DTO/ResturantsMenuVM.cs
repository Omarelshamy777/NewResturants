using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ResturantsMenuVM
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int FoodId { get; set; }
        public string? FoodName { get; set; }
        public int ResturantID { get; set; }
        public string? ResturantName { get; set; }
        public List<ResturantsMenuItemsVM> ResturantsMenuItems { get; set; } = new List<ResturantsMenuItemsVM>();

    }
    public class ResturantsMenuItemsVM
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public double? ItemPrice { get; set; }
        public string? Categories { get; set; }
    }
}
