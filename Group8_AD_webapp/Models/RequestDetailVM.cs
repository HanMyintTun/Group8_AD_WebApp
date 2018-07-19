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
        int awaitQty;
        int fulfilledQty;

        public int ReqId { get => reqId; set => reqId = value; }
        public int ReqLineNo { get => reqLineNo; set => reqLineNo = value; }
        public string ItemCode { get => itemCode; set => itemCode = value; }
        public int ReqQty { get => reqQty; set => reqQty = value; }
        public int AwaitQty { get => awaitQty; set => awaitQty = value; }
        public int FulfilledQty { get => fulfilledQty; set => fulfilledQty = value; }

        public RequestDetailVM(int reqId, int reqLineNo, string itemCode, int reqQty, int awaitQty, int fulfilledQty)
        {
            ReqId = reqId;
            ReqLineNo = reqLineNo;
            ItemCode = itemCode;
            ReqQty = reqQty;
            AwaitQty = awaitQty;
            FulfilledQty = fulfilledQty;
        }

        public RequestDetailVM()
        {

        }
    }
}