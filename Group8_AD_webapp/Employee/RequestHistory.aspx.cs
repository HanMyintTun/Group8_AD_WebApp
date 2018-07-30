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
        List<RequestVM> requests = new List<RequestVM>();
        string status = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Service.UtilityService.CheckRoles("Employee");
            int empId = Convert.ToInt32(Session["empId"]);

            if (Session["Message"] == null)
            {
                lblMessage.Text = "";
                divAlert.Visible = false;
            }

            if (!IsPostBack)
            {
                Main master = (Main)this.Master;
                master.ActiveMenu("reqhistory");

                List<string> statuses = new List<string> { "Submitted", "Approved", "Fulfilled", "Cancelled"};
                ddlStatus.DataSource = statuses;
                ddlStatus.DataBind();

                requests = Controllers.RequestCtrl.GetReq(empId, "All");
                BindGrid();

                if(Session["Message"] != null){
                    lblMessage.Text = Session["Message"].ToString();
                    Session["Message"] = null;
                    divAlert.Visible = true;
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
            int empId = Convert.ToInt32(Session["empId"]);
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
            int empId = Convert.ToInt32(Session["empId"]);
            status = ddlStatus.Text;
            if (txtStartDate.Text != "" && txtEndDate.Text != "")
            {
                DateTime startDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime endDate = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                if (endDate.CompareTo(startDate) >= 0)
                {

                    requests = Controllers.RequestCtrl.GetRequestByDateRange(empId, status, startDate, endDate);

                    BindGrid();
                }
                else
                {
                    Main master = (Main)this.Master;
                    master.ShowToastr(this, "", "End Date must be after Start Date", "error");
                }
             }
            else
            {
                requests = Controllers.RequestCtrl.GetReq(empId, status);
                BindGrid();
            }
        }
    }
}