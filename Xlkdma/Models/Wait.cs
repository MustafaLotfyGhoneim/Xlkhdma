namespace Xlkdma.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wait")]
    public partial class Wait
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wait()
        {
            Dones = new HashSet<Done>();
        }

        public int waitId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? waitDate { get; set; }

        [StringLength(150)]
        public string waitName { get; set; }

        public string waitDesc { get; set; }

        public int? waitAchievingTime { get; set; }

        public bool accept { get; set; }

        public bool done { get; set; }

        public long workerSSN { get; set; }

        public long customerSSN { get; set; }

        public int? orderId { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Done> Dones { get; set; }

        public virtual Order Order { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
