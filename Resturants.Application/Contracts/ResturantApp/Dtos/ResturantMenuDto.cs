using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Contracts.ResturantApp.Dtos
{
    public class ResturantMenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
     
        public int ResturantID { get; set; }
        public string? ResturantName { get; set; }
        public List<ResturantsMenuItemDto> ResturantsMenuItems { get; set; } = new List<ResturantsMenuItemDto>();

    }
}
