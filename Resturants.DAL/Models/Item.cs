
using Castle.DynamicProxy;
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
        public int Id { get; set; }
        [Required]
        [StringLength(Consts.ItemConsts.NameLength)]

        public string Name { get; set; } = string.Empty;
        [Required]
 
        public double Price { get; set; }
        [Required]
        [StringLength(Consts.ItemConsts.CategoryLength)]
        public string Category { get; set; }=string.Empty;

        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu? Menus { get; set; }
        public ICollection<Resturant>? Resturants { get; set; }
        public ICollection<Order>? Order { get; set; }
    }
}
