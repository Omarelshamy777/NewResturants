using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Contracts.ResturantApp.Dtos
{
    public class GetCustomerOrderDto
    {
        public int OrderId { get; set; }

     

        public List<ItemDto>? Item { get; set; }
    }
}
