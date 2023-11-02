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
        public string? FoodPrice { get; set; }
        public string? Categories { get; set; }

        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public Order? Orders { get; set; }


        [ForeignKey("Resturants")]
        public int ResturantID { get; set; }
        public ICollection<Resturant>? Resturants { get; set; }
    }
}
