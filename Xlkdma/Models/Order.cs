namespace Xlkdma.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Waits = new HashSet<Wait>();
        }

        public int orderId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? orderDate { get; set; }

        [StringLength(100)]
        public string orderName { get; set; }

        public string orderDesc { get; set; }

        public int? acheivingTime { get; set; }

        public long? workerSsn { get; set; }

        public long? customerSsn { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Worker Worker { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wait> Waits { get; set; }
    }
}
