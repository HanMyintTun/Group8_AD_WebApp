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
    
    public partial class RequestDetail
    {
        public int ReqId { get; set; }
        public int ReqLineNo { get; set; }
        public string ItemCode { get; set; }
        public int ReqQty { get; set; }
        public int AwaitQty { get; set; }
        public int FulfilledQty { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Request Request { get; set; }
    }
}