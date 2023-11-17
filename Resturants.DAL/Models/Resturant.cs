

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.DAL.Models
{
    public class Resturant
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResturantID { get; set; }
        public string? ResturantName { get; set; }
        public ICollection<Order>? Orders { get; set; }


        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu? Menus { get; set; }



    }
}
