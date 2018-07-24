namespace Group8_AD_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        [Key]
        public int TranId { get; set; }

        public DateTime TranDateTime { get; set; }

        [Required]
        [StringLength(4)]
        public string ItemCode { get; set; }

        public int QtyChange { get; set; }

        public double? UnitPrice { get; set; }

        [StringLength(100)]
        public string Desc { get; set; }

        [StringLength(4)]
        public string DeptCode { get; set; }

        [StringLength(4)]
        public string SuppCode { get; set; }

        [StringLength(20)]
        public string VoucherNo { get; set; }
    }
}
