using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Contracts.ResturantApp.Dtos
{
    public class ItemOrderDto
    {
        public int Id { get; set; }

        public ItemDto? Item { get; set; }
    }
}
