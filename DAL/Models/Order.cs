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

        public ICollection<Food>? Foods { get; set; }

        public ICollection<Resturant>? Resturants { get; set; }
        [ForeignKey("Customers")]
        public int CustomerID { get; set; }
        public Customer? Customers { get; set; }
    }
}
