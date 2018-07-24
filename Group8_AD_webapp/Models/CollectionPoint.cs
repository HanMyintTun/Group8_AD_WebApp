namespace Group8_AD_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CollectionPoint")]
    public partial class CollectionPoint
    {
        [Key]
        public int ColPtId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Time { get; set; }

        public int ClerkId { get; set; }
    }
}
