using Microsoft.EntityFrameworkCore;
using Resturants.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.DAL.Models
{
    public class Order
    {
        public Order()
        {
                this.ItemOrder = new HashSet<ItemOrder>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public string? Number { get; set; }
       
        public double? TotalPrice { get; set; }
        public OrderStatus OrderStaus { get; set; }



        public virtual ICollection<ItemOrder>? ItemOrder { get; set; } 

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }


    }
}
