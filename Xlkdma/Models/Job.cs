namespace Xlkdma.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Job")]
    public partial class Job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Job()
        {
            Workers = new HashSet<Worker>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int jobId { get; set; }

        [StringLength(150)]
        public string jobName { get; set; }

        public string jobDescription { get; set; }

        public int? categoryId { get; set; }

        [StringLength(100)]
        public string jobImage { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
