using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8_AD_webapp.Models;

namespace Group8_AD_webapp
{
    public partial class RequestHistory : System.Web.UI.Page
    {
        static string access_token;
        List<RequestVM> requests = new List<RequestVM>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> statuses = new List<string> { "Submitted", "Approved", "Fulfilled", "Cancelled"};
                ddlStatus.DataSource = statuses;
                ddlStatus.DataBind();


                access_token = Session["Token"].ToString();
                string status = "";
                int empId = 31; //hard-coded for now
                if (Request.QueryString["status"] == "" || Request.QueryString["status"] == null)
                {
                    status = "Submitted";
                }
                else
                {
                    status = Request.QueryString["status"];
                }
                
                 requests = Controllers.RequestCtrl.GetReq(empId, status, access_token);
                BindGrid();
            }

        }

        protected void BindGrid()
        {
            lstRequests.DataSource = requests;
            lstRequests.DataBind();
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}