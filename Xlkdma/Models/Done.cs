namespace Xlkdma.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Done")]
    public partial class Done
    {
        public int doneId { get; set; }

        public int? waitId { get; set; }

        public int? workerId { get; set; }

        public long? workerSSN { get; set; }

        public long? customerSSN { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Wait Wait { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
