using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp.Employee
{
    public partial class RequestHistory : System.Web.UI.Page
    {
        List<Request> requests = new List<Request>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                requests.Add(new Employee.Request(1, "2018-07-12", "Unsubmitted"));
                requests.Add(new Employee.Request(2, "2018-07-13", "Submitted"));
                requests.Add(new Employee.Request(3, "2018-07-14", "Approved"));
                requests.Add(new Employee.Request(4, "2018-07-15", "Fulfilled"));
                lstRequests.DataSource = requests;
                lstRequests.DataBind();
            }
        }
    }
}