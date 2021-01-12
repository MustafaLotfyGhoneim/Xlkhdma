namespace Xlkdma.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkerPhone")]
    public partial class WorkerPhone
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long workerSsn { get; set; }

        [Key]
        [Column("workerPhone", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long workerPhone1 { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
