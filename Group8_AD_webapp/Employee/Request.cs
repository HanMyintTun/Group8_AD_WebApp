using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group8_AD_webapp
{
    public class Request
    {
        int reqId;
        int empId;
        int approverId;
        string approverComment;
        DateTime reqDateTime;
        DateTime approvedDateTime;
        DateTime cancelledDateTime;
        string status;

        public int ReqId { get => reqId; set => reqId = value; }
        public int EmpId { get => empId; set => empId = value; }
        public int ApproverId { get => approverId; set => approverId = value; }
        public string ApproverComment { get => approverComment; set => approverComment = value; }
        public DateTime ReqDateTime { get => reqDateTime; set => reqDateTime = value; }
        public DateTime ApprovedDateTime { get => approvedDateTime; set => approvedDateTime = value; }
        public DateTime CancelledDateTime { get => cancelledDateTime; set => cancelledDateTime = value; }
        public string Status { get => status; set => status = value; }

        public Request(int reqId, int empId, int approverId, string approverComment, DateTime reqDateTime, DateTime approvedDateTime, string status)
        {
            ReqId = reqId;
            EmpId = empId;
            ApproverId = approverId;
            ApproverComment = approverComment;
            ReqDateTime = reqDateTime;
            ApprovedDateTime = approvedDateTime;
            Status = status;
        }

        public Request()
        {

        }
    }
}