using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }
        public string? FoodName { get; set; }
        public double? FoodPrice { get; set; }
        public string? Categories { get; set; }

  

        public ICollection<Order>? Order { get; set; }

        
        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu? Menus { get; set; }

        public ICollection<Resturant>? Resturants { get; set; }
    }
}
