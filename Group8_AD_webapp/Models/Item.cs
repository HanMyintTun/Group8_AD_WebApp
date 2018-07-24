namespace Group8_AD_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            Adjustments = new HashSet<Adjustment>();
            RequestDetails = new HashSet<RequestDetail>();
        }

        [Key]
        [StringLength(4)]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(20)]
        public string Cat { get; set; }

        [Required]
        [StringLength(100)]
        public string Desc { get; set; }

        [Required]
        [StringLength(3)]
        public string Location { get; set; }

        [Required]
        [StringLength(20)]
        public string UOM { get; set; }

        public bool IsActive { get; set; }

        public int Balance { get; set; }

        public int ReorderLevel { get; set; }

        public int ReorderQty { get; set; }

        public int? TempQtyDisb { get; set; }

        public int? TempQtyCheck { get; set; }

        [StringLength(4)]
        public string SuppCode1 { get; set; }

        public double? Price1 { get; set; }

        [StringLength(4)]
        public string SuppCode2 { get; set; }

        public double? Price2 { get; set; }

        [StringLength(4)]
        public string SuppCode3 { get; set; }

        public double? Price3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjustment> Adjustments { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Supplier Supplier1 { get; set; }

        public virtual Supplier Supplier2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
    }
}
