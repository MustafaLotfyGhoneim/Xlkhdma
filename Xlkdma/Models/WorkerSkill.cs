namespace Xlkdma.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkerSkill
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long workerSsn { get; set; }

        [Key]
        [Column("workerSkill", Order = 1)]
        [StringLength(150)]
        public string workerSkill1 { get; set; }

        public int? skillPrice { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
