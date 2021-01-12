namespace Xlkdma.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Worker")]
    public partial class Worker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Worker()
        {
            CustomerWorkers = new HashSet<CustomerWorker>();
            Dones = new HashSet<Done>();
            Orders = new HashSet<Order>();
            Waits = new HashSet<Wait>();
            WorkerSkills = new HashSet<WorkerSkill>();
        }
        [Required(ErrorMessage ="*")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long workerSsn { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int workerId { get; set; }
        [Required(ErrorMessage = "*")]

        [StringLength(100)]
        public string workerName { get; set; }
        [Required(ErrorMessage = "*")]

        [StringLength(150)]
        public string workerCity { get; set; }
        [Required(ErrorMessage = "*")]

        public double? jobPrice { get; set; }
        [Required(ErrorMessage = "*")]

        public int? jobId { get; set; }
        [Required(ErrorMessage = "*")]

        [StringLength(100)]
        public string workerPassword { get; set; }

        [NotMapped]
        public string confirm_password { get; set; }
        [StringLength(100)]
        public string workerImage { get; set; }
        [Required(ErrorMessage = "*")]

        public long? workerPhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerWorker> CustomerWorkers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Done> Dones { get; set; }

        public virtual Job Job { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wait> Waits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkerSkill> WorkerSkills { get; set; }
    }
}
