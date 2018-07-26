using Group8_AD_webapp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp
{
    public partial class Rejected_Requests : System.Web.UI.Page
    {
        static int rid;
        static string access_token;
        int empId = 1;
        string status = "Rejected";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                access_token = Session["Token"].ToString();
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            List<EmpReqVM> requestlists = BusinessLogic.GetEmpReqList(empId, status, access_token);
            lstCancel.DataSource = requestlists;
            lstCancel.DataBind();
        }

        // populate cancel detail in modal
        protected void PopulateDetailList(int rid)
        {
            RequestVM req = Controllers.RequestCtrl.GetRequestByReqId(rid, access_token);
            EmployeeVM emp = Controllers.EmployeeCtrl.getEmployeebyId(req.EmpId, access_token);

            List<RequestDetailVM> showList = BusinessLogic.GetItemDetailList(rid);
            lblReqid.Text = req.ReqId.ToString();
            lblEmpName.Text = emp.EmpName.ToString();
            lblSubmitteddate.Text = req.ReqDateTime.ToString("dd'/'MM'/'yyyy");
            lblReject.Text = req.CancelledDateTime.ToString("dd'/'MM'/'yyyy");
            txtComments.Text = req.ApproverComment.ToString();
            lstShow.DataSource = showList;
            lstShow.DataBind();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);//modal popup
        }

        //detail buttom action 
        protected void lstOrder_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ReqDetail")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    rid = Convert.ToInt32(e.CommandArgument);
                    PopulateDetailList(rid);
                }
            }
        }
    }
}