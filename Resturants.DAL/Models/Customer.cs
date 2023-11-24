
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.DAL.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(Consts.CustomerConsts.UserNameLength)]
        public string? Name { get; set; }
        public string? Address { get; set; }
        [Required]
        [StringLength(Consts.CustomerConsts.UserNameLength)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [StringLength(Consts.CustomerConsts.UserNameLength)]
        public string Password { get; set; } = string.Empty;










    }
}
