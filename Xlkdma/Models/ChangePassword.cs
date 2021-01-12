using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Xlkdma.Models
{
    public class ChangePassword
    {
    
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        [DataType(DataType.Password)]
        public string oldPassword{ get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DataType(DataType.Password)]
        [ Compare(otherProperty: "newPassword",ErrorMessage ="كلمة المرور غير متطابقة")]
        public string confirmPassword { get; set; }
    }
}