using Microsoft.EntityFrameworkCore;
using NewResturants.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
      
        public string? OrderNumber { get; set; }
       
        public double? TotalPrice { get; set; }
        public OrderStatusEnum OrderStaus { get; set; }


       
        public int FoodsId { get; set; }
        [ForeignKey("FoodsId")]
        public Item? Foods { get; set; }


        
        public int ResturantID { get; set; }
        [ForeignKey("ResturantID")]
        public Resturant? Resturants { get; set; }

      
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer? Customers { get; set; }
    }
}
