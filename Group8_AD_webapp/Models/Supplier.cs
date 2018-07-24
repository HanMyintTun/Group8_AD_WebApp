namespace Group8_AD_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Items = new HashSet<Item>();
            Items1 = new HashSet<Item>();
            Items2 = new HashSet<Item>();
        }

        [Key]
        [StringLength(4)]
        public string SuppCode { get; set; }

        [Required]
        [StringLength(80)]
        public string SuppName { get; set; }

        [Required]
        [StringLength(80)]
        public string SuppCtcName { get; set; }

        [Required]
        [StringLength(20)]
        public string SuppCtcNo { get; set; }

        [Required]
        [StringLength(20)]
        public string SuppFaxNo { get; set; }

        [Required]
        [StringLength(200)]
        public string SuppAddr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items2 { get; set; }
    }
}
