using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group8_AD_webapp.model
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


    }
}