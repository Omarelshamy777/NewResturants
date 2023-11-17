using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Contracts.AuthApp.Dtos
{
    public class SignUPDto
    {
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "هذا الحقل  الزامي و يجب استيفاء بيانه")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "هذا الحقل  الزامي و يجب استيفاء بيانه")]
        [RegularExpression("(?!.* )(?=.*\\d).{10,}", ErrorMessage = ".برجاء اعادة المحاولة")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
