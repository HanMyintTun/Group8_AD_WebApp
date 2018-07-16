using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group8_AD_webapp.Employee
{
    public class Request
    {
        int reqId;
        string reqDate;
        string status;

        public int ReqId { get => reqId; set => reqId = value; }
        public string ReqDate { get => reqDate; set => reqDate = value; }
        public string Status { get => status; set => status = value; }

        public Request(int reqId, string reqDate, string status)
        {
            ReqId = reqId;
            ReqDate = reqDate;
            Status = status;
        }
    }
}