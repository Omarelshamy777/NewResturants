using Castle.DynamicProxy;
using Resturants.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Contracts.AuthApp.Dtos
{
    public class SignUpDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "هذا الحقل  الزامي و يجب استيفاء بيانه")]
        [StringLength(Consts.CustomerConsts.UserNameLength)]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "هذا الحقل  الزامي و يجب استيفاء بيانه")]
        //[RegularExpression("(?!.* )(?=.*\\d).{10,}", ErrorMessage = ".برجاء اعادة المحاولة")]
        [DataType(DataType.Password)]
        [StringLength(Consts.CustomerConsts.PasswordLength)]
        
        public string Password { get; set; } = string.Empty;
        public string? Address { get; set; }
    }
}
