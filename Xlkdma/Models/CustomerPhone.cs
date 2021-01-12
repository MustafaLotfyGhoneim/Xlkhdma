namespace Xlkdma.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerPhone")]
    public partial class CustomerPhone
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long customerSsn { get; set; }

        [Key]
        [Column("customerPhone", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long customerPhone1 { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
