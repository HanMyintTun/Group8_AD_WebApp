using Group8_AD_webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8AD_WebAPI.BusinessLogic;
namespace Group8_AD_webapp.Manager
{
    public partial class AdjRequestHistory : System.Web.UI.Page
    {
        static string access_token;
        List<AdjustmentVM> adj = new List<AdjustmentVM>();
        string status = "";
        static string voucherno;
        int empid = 104;
        static string cmt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> statuses = new List<string> { "Submitted", "Approved", "Rejected" };
                ddlStatus.DataSource = statuses;
                ddlStatus.DataBind();

                access_token = Session["Token"].ToString();

                adj = Controllers.AdjustmentCtrl.GetAdjustmentList("All");
                BindGrid();

                if (Session["Message"] != null)
                {
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
            adj = adj.OrderByDescending(x => x.DateTimeIssued).ToList();
            lstRequests.DataSource = adj;
            lstRequests.DataBind();
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = ddlStatus.Text;
            adj = Controllers.AdjustmentCtrl.GetAdjustmentList(status);
            BindGrid();
          
        }

        //detail buttom action 
        protected void lstRequests_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (e.CommandName == "Detail")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    voucherno = e.CommandArgument.ToString();

                    PopulateDetailList(voucherno);
                }

            }


        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            AcceptReq();
        }

        protected void AcceptReq()
        {

            AdjustmentBL.AcceptRequest(voucherno, empid, cmt);
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            RejectReq();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('toggle');", true);//modal popup
        }
        protected void RejectReq()
        {
            AdjustmentBL.RejectRequest(voucherno, empid, cmt);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('toggle');", true);//modal popup
        }
        protected void PopulateDetailList(string voucherno)
        {
            List<AdjItemVM> adj = Controllers.AdjustmentCtrl.GetAdjByVoucher(voucherno);
            List<AdjItemVM> showList = BusinessLogic.GetItemAdjustList(voucherno);
            foreach (AdjItemVM aj in adj)
            {
                cmt = txtComments.Text.ToString();


                lblstatus.Text = aj.Status;
                if (aj.Status == "Submitted")
                {
                    txtComments.Visible = true;
                    btnAccept.Visible = true;
                    btnReject.Visible = true;
                    txtComments.ReadOnly = false;
                }
                else if (aj.Status == "Rejected")
                {
                    txtComments.Visible = true;
                    txtComments.ReadOnly = true;
                    btnAccept.Visible = false;
                    btnReject.Visible = false;
                    //txtComments.Visible = false;
                }
                else
                {
                    btnAccept.Visible = false;
                    btnReject.Visible = false;
                }


                if (aj.ApproverComment == null)
                {
                    txtComments.Text = " ";
                }
                else
                {
                    txtComments.Text = aj.ApproverComment.ToString();
                }
            }
            lstShow.DataSource = showList;
            lstShow.DataBind();

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);//modal popup
        }
    }
}