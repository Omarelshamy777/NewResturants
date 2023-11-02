
using NewResturants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderRequestVM
    {

        public int OrderID { get; set; }
        public int CustomerId { get; set; }
        public string OrderNumber { get; set; }

        public double? Price { get; set; }
        public OrderStatusEnum OrderStaus { get; set; }
        public int FoodId { get; set; }
        public string? FoodName { get; set; }
        public string? Categories { get; set; }

        public int ResturantNameID { get; set; }
        public string ResturantName { get; set; }


    }
}
