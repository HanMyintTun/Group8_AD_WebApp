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
                requests.Add(new Request(0, 3, 1, "", new DateTime(2018, 07, 12), new DateTime(2018, 07, 15), "Bookmarked"));
                requests.Add(new Request(1, 3, 1, "", new DateTime(2018, 07, 12), new DateTime(2018, 07, 15), "Unsubmitted"));
                requests.Add(new Request(2, 3, 1, "", new DateTime(2018, 07, 12), new DateTime(2018, 07, 15), "Submitted"));
                requests.Add(new Request(3, 3, 1, "", new DateTime(2018, 07, 12), new DateTime(2018, 07, 15), "Approved"));
                requests.Add(new Request(4, 3, 1, "", new DateTime(2018, 07, 12), new DateTime(2018, 07, 15), "Fulfilled"));
                requests.Add(new Request(5, 3, 1, "", new DateTime(2018, 07, 12), new DateTime(2018, 07, 15), "Cancelled"));
                lstRequests.DataSource = requests;
                lstRequests.DataBind();
            }

        }
    }
}