using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8_AD_webapp.Models;
using RestSharp;

namespace Group8_AD_webapp
{
    public partial class RequestHistory : System.Web.UI.Page
    {
        static string access_token;
        List<RequestVM> requests = new List<RequestVM>();
        string status = "";
        int empId = 42;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> statuses = new List<string> { "Submitted", "Approved", "Fulfilled", "Cancelled"};
                ddlStatus.DataSource = statuses;
                ddlStatus.DataBind();
                
                access_token = Session["Token"].ToString();

                requests = Controllers.RequestCtrl.GetReq(empId, "All");
                BindGrid();

                if(Session["Message"] != null){
                    lblMessage.Text = Session["Message"].ToString();
                    Session["Message"] = null;
                }
                else
                {
                    divAlert.Visible = false;
                }
            }
        }

        protected void BindGrid()
        {
            requests = requests.OrderByDescending(x => x.ReqDateTime).ToList();
            lstRequests.DataSource = requests;
            lstRequests.DataBind();
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtStartDate.Text != "" && txtEndDate.Text != "")
            {
                DoSearch();
            }
            else
            {
                status = ddlStatus.Text;
                requests = Controllers.RequestCtrl.GetReq(empId, status);
                BindGrid();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        protected void DoSearch()
        {
            status = ddlStatus.Text.ToString();
            if (txtStartDate.Text != "" && txtEndDate.Text != "")
            {
                DateTime startDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime endDate = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                requests = Controllers.RequestCtrl.GetRequestByDateRange(31, status, startDate, endDate, "");

                BindGrid();
            }
        }
    }
}