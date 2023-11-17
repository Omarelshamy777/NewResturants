
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.DAL.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public double? ItemPrice { get; set; }
        public string? Categories { get; set; }
        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu? Menus { get; set; }
        public ICollection<Resturant>? Resturants { get; set; }
        public ICollection<Order>? Order { get; set; }
    }
}
