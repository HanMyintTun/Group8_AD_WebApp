namespace Group8_AD_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adjustment")]
    public partial class Adjustment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string VoucherNo { get; set; }

        public int EmpId { get; set; }

        public DateTime DateTimeIssued { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Reason { get; set; }

        public int QtyChange { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public int? ApproverId { get; set; }

        [StringLength(100)]
        public string ApproverComment { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual Item Item { get; set; }
    }
}
