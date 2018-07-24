namespace Group8_AD_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request()
        {
            RequestDetails = new HashSet<RequestDetail>();
        }

        [Key]
        public int ReqId { get; set; }

        public int EmpId { get; set; }

        public int? ApproverId { get; set; }

        [StringLength(100)]
        public string ApproverComment { get; set; }

        public DateTime? ReqDateTime { get; set; }

        public DateTime? ApprovedDateTime { get; set; }

        public DateTime? CancelledDateTime { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public DateTime? FulfilledDateTime { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Employee Employee1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
    }
}
