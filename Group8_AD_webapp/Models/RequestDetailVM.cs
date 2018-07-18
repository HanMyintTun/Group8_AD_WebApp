using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group8_AD_webapp.Models
{
    public class RequestDetailVM
    {
        int reqId;
        int reqLineNo;
        string itemCode;
        int reqQty;
        int AwaitQty;
        int fulfilledQty;

        public int ReqId { get => reqId; set => reqId = value; }
        public int ReqLineNo { get => reqLineNo; set => reqLineNo = value; }
        public string ItemCode { get => itemCode; set => itemCode = value; }
        public int ReqQty { get => reqQty; set => reqQty = value; }
        public int AwaitQty1 { get => AwaitQty; set => AwaitQty = value; }
        public int FulfilledQty { get => fulfilledQty; set => fulfilledQty = value; }

        public RequestDetailVM(int reqId, int reqLineNo, string itemCode, int reqQty, int awaitQty1, int fulfilledQty)
        {
            ReqId = reqId;
            ReqLineNo = reqLineNo;
            ItemCode = itemCode;
            ReqQty = reqQty;
            AwaitQty1 = awaitQty1;
            FulfilledQty = fulfilledQty;
        }

        public RequestDetailVM()
        {

        }
    }
}