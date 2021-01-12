namespace Xlkdma.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            CustomerWorkers = new HashSet<CustomerWorker>();
            Dones = new HashSet<Done>();
            Orders = new HashSet<Order>();
            Waits = new HashSet<Wait>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long customerSsn { get; set; }
        [Required(ErrorMessage = "*")]

        [StringLength(100)]
        public string customerName { get; set; }
        [Required(ErrorMessage = "*")]

        [StringLength(150)]
        public string customerCity { get; set; }
        [Required(ErrorMessage = "*")]

        [StringLength(200)]
        public string customerEmail { get; set; }

        [StringLength(100)]
        public string customerPassword { get; set; }


        [NotMapped]
        public string confirm_password { get; set; }
        [Required(ErrorMessage ="*")]

        public long? customerPhone { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerWorker> CustomerWorkers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Done> Dones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wait> Waits { get; set; }
    }
}
