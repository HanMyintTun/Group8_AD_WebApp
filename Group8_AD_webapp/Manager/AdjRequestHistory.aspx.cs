using Group8_AD_webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp.Manager
{
    public partial class AdjRequestHistory : System.Web.UI.Page
    {
        static string access_token;
        List<AdjustmentVM> adj = new List<AdjustmentVM>();
        string status = "";
        string voucherno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> statuses = new List<string> { "Submitted", "Approved", "Rejected" };
                ddlStatus.DataSource = statuses;
                ddlStatus.DataBind();

                access_token = Session["Token"].ToString();

                adj = Controllers.AdjustmentCtrl.GetAdjustmentList("all");
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
            if (status == "Submitted")
            {
                txtComments.Visible = true;
            }
            else
            {
                txtComments.Visible = false;
            }

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
        { }
        protected void btnReject_Click(object sender, EventArgs e)
        {
        }

        protected void PopulateDetailList(string voucherno)
        {
            AdjustmentVM adj = Controllers.AdjustmentCtrl.GetAdjByVoucher(voucherno);
            lblstatus.Text = adj.Status.ToString();
         //  List<AdjItemVM > showList = BusinessLogic.AddItemDescToAdj(voucherno);
            //lstShow.DataSource = ;
            //lstShow.DataBind();
            //<RequestDetailVM> showList = BusinessLogic.GetItemDetailList(1);

            //lstShow.DataSource = adj;
            //lstShow.DataBind();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);//modal popup
        }
    }
}