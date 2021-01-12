using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Xlkdma.Models
{
    public class WeditedData
    {
        [Required(ErrorMessage = "*")]
        public string workerName { get; set; }
        [Required(ErrorMessage = "*")]
        public string workerCity { get; set; }
        [Required(ErrorMessage = "*")]
        public double jobPrice { get; set; }
        [Required(ErrorMessage = "*")]
        public int jobId { get; set; }
        [Required(ErrorMessage = "*")]
        public long? workerPhone { get; set; }

    }
}