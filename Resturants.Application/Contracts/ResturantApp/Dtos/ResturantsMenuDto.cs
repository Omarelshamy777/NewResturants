using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Contracts.ResturantApp.Dtos
{
    public class ResturantsMenuDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int FoodId { get; set; }
        public string? FoodName { get; set; }
        public int ResturantID { get; set; }
        public string? ResturantName { get; set; }
        public List<ResturantsMenuItemDto> ResturantsMenuItems { get; set; } = new List<ResturantsMenuItemDto>();

    }
}
