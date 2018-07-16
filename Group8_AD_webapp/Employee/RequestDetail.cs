using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group8_AD_webapp
{
    public class RequestDetail
    {
        int reqId;
        int reqLineNo;
        string itemCode;
        int reqQty;
        int awaitQy;
        int fulfilledQty;

        public int ReqId { get => reqId; set => reqId = value; }
        public int ReqLineNo { get => reqLineNo; set => reqLineNo = value; }
        public string ItemCode { get => itemCode; set => itemCode = value; }
        public int ReqQty { get => reqQty; set => reqQty = value; }
        public int AwaitQy { get => awaitQy; set => awaitQy = value; }
        public int FulfilledQty { get => fulfilledQty; set => fulfilledQty = value; }

        public RequestDetail(int reqId, int reqLineNo, string itemCode, int reqQty, int awaitQy, int fulfilledQty)
        {
            ReqId = reqId;
            ReqLineNo = reqLineNo;
            ItemCode = itemCode;
            ReqQty = reqQty;
            AwaitQy = awaitQy;
            FulfilledQty = fulfilledQty;
        }

        public RequestDetail()
        {

        }
    }
}