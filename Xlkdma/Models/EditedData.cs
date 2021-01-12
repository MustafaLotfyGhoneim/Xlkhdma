using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Xlkdma.Models
{
    public class EditedData
    {
        
        [Required(ErrorMessage = "*")]
        public string customerName { get; set; }
        [Required(ErrorMessage = "*")]
        public string customerCity { get; set; }
        [Required(ErrorMessage = "*")]
        public string customerEmail { get; set; }
        [Required(ErrorMessage = "*")]
        public long customerPhone { get; set; }

    }
}