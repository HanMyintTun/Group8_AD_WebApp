namespace Group8_AD_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        public int NotificationId { get; set; }

        public DateTime NotificationDateTime { get; set; }

        public int FromEmp { get; set; }

        public int ToEmp { get; set; }

        [StringLength(100)]
        public string RouteUri { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }

        [Required]
        [StringLength(100)]
        public string Content { get; set; }

        public bool IsRead { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Employee Employee1 { get; set; }
    }
}
