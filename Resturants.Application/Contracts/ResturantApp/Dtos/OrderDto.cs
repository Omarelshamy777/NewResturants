
using Resturants.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Contracts.ResturantApp.Dtos
{
    public class OrderDto
    {

        public int? Id { get; set; }

        public string? Number { get; set; }

        public double? Price { get; set; }
        public OrderStatus? Status { get; set; }


        public CustomrerDto? Customr { get; set; }
        public ResturantDto? Resturant { get; set; }

        public List<ItemDto>? Items { get; set; }

    }
}
