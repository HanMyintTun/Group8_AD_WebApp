namespace Group8_AD_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestDetail")]
    public partial class RequestDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReqId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReqLineNo { get; set; }

        [Required]
        [StringLength(4)]
        public string ItemCode { get; set; }

        public int ReqQty { get; set; }

        public int AwaitQty { get; set; }

        public int FulfilledQty { get; set; }

        public virtual Item Item { get; set; }

        public virtual Request Request { get; set; }
    }
}
