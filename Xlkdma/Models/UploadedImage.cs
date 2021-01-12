using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Xlkdma.Models
{
    public class UploadedImage
    {
        [Required(ErrorMessage = "*")]
        public string workerImage { get; set; }
    }
}