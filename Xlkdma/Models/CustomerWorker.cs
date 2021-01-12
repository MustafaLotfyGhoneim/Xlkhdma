namespace Xlkdma.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerWorker")]
    public partial class CustomerWorker
    {
        public long customerSsn { get; set; }

        public long workerSsn { get; set; }

        [Required]
        [StringLength(150)]
        public string skill { get; set; }

        public int id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
