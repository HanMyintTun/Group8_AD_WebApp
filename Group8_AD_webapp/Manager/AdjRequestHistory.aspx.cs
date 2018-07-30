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
        static List<AdjustmentVM> adj = new List<AdjustmentVM>();
        string status = "All";
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
                //access_token = Session["Token"].ToString();
                //if (Session["Message"] != null)
                //{
                //    lblMessage.Text = Session["Message"].ToString();
                //    Session["Message"] = null;
                //}
                //else
                //{
                //    divAlert.Visible = false;
                //}

                BindGrid();

            }
        }

        protected void BindGrid()
        {
            adj = AdjustmentBL.GetAdjList(status);
            List<AdjustmentVM> adj2 = new List<AdjustmentVM>();
            List<string> voucherno = adj.Select(a => a.VoucherNo).Distinct().ToList();

            foreach (string vnum in voucherno)
            {
                AdjustmentVM adjj = adj.Where(a => a.VoucherNo.Equals(vnum)).FirstOrDefault();
                adj2.Add(adjj);
            }
            // adj = adj.OrderByDescending(x => x.DateTimeIssued).ToList();

            lstRequests.DataSource = adj2.OrderByDescending(x => x.DateTimeIssued).ToList();
            lstRequests.DataBind();
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = ddlStatus.Text;
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
        //accept
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlConfirm').modal();", true);//modal popup
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            cmt = txtComments.Text.ToString();
            bool success = AdjustmentBL.AcceptRequest(voucherno, empid, cmt);
            if (success)
            {
                BindGrid();
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Request has been accepted!"), "Successfully approved!", "success");
               
            }
            else
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Changes not Submitted"), "Something Went Wrong!", "error");
            }

        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlConfirm').modal('toggle');", true);//modal popup
        }

        //reject
        protected void btnReject_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlRejConfirm').modal();", true);//modal popup
        }

        protected void btnRejConfirm_Click(object sender, EventArgs e)
        {

            cmt = txtComments.Text.ToString();
            bool success = AdjustmentBL.RejectRequest(voucherno, empid, cmt);
            if (success)
            {
                BindGrid();
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Request has been rejected!"), "Successfully rejected!", "success");
                
            }
            else
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Changes not Submitted"), "Something Went Wrong!", "error");
            }
        }

        protected void btnRejNo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlRejConfirm').modal('toggle');", true);//modal popup
        }

        protected void PopulateDetailList(string voucherno)
        {
            // List<AdjustmentVM> adj = AdjustmentBL.GetAdj(voucherno);
            List<AdjustmentVM> showList = BusinessLogic.GetItemAdjustList(voucherno, empid);
            foreach (AdjustmentVM aj in showList)
            {
                cmt = txtComments.Text.ToString();

                lblvnum.Text = voucherno.ToString();
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
                    if (aj.ApproverComment == null)
                    {
                        txtComments.Text = " ";
                    }
                    else
                    {
                        txtComments.Visible = true;
                        txtComments.ReadOnly = true;
                        txtComments.Text = aj.ApproverComment.ToString();
                    }

                    btnAccept.Visible = false;
                    btnReject.Visible = false;
                    //txtComments.Visible = false;
                }
                else if (aj.Status == "Approved")
                {
                    if (aj.ApproverComment == null)
                    {
                        txtComments.Text = " ";
                    }
                    else
                    {
                        txtComments.Visible = true;
                        txtComments.ReadOnly = true;
                        txtComments.Text = aj.ApproverComment.ToString();
                    }

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

        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}