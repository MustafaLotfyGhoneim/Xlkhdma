using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLoginApp.Models
{
    public class loginData
    {
        [DisplayName("إسم المستخدم")]
        [Required(ErrorMessage ="*")]
        public string userName { get; set; }

        [DisplayName("كلمة المرور")]
        [Required(ErrorMessage = "*")]
        public string password { get; set; }
    }
}