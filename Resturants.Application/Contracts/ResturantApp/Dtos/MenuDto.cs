using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Contracts.ResturantApp.Dtos
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemDto> ResturantsMenuItems { get; set; } = new List<ItemDto>();


    }
}
