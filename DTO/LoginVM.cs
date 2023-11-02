using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class LoginVM 
    {

        public int? UserId { get; set; }
        [Required(ErrorMessage = "هذا الحقل  الزامي و يجب استيفاء بيانه")]
        public string userName { get; set; }
        [Required(ErrorMessage = "هذا الحقل  الزامي و يجب استيفاء بيانه")]
        //[RegularExpression("(?!.* )(?=.*\\d).{10,}", ErrorMessage = ".برجاء اعادة المحاولة")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
