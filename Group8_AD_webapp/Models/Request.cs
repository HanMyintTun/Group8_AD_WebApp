//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Group8_AD_webapp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request()
        {
            this.RequestDetails = new HashSet<RequestDetail>();
        }
    
        public int ReqId { get; set; }
        public int EmpId { get; set; }
        public Nullable<int> ApproverId { get; set; }
        public string ApproverComment { get; set; }
        public Nullable<System.DateTime> ReqDateTime { get; set; }
        public Nullable<System.DateTime> ApprovedDateTime { get; set; }
        public Nullable<System.DateTime> CancelledDateTime { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> FulfilledDateTime { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
    }
}