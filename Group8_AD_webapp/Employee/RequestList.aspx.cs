using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8_AD_webapp.Models;

namespace Group8_AD_webapp
{
    public partial class RequestList : System.Web.UI.Page
    {
        static string access_token;
        List<RequestVM> requests = new List<RequestVM>();
        List<RequestDetailVM> showList = new List<RequestDetailVM>();
        List<RequestDetailVM> bookmarkList = new List<RequestDetailVM>();

        int empId;
        int reqid;
        string status ="";
        public bool IsEditable = false;
        public bool IsNotSubmitted = false;
        public bool IsApproved = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                empId = 31;

                if (Request.QueryString["reqid"] != null)
                {
                    Label1.Text = "NOT EMPTY";
                    reqid = Convert.ToInt32(Request.QueryString["reqid"]);
                    //RequestVM myRequest = Controllers.RequestCtrl.GetRequestByReqId(reqid, access_token);
                    AddItems();
                    BindGrids();
                    if (reqid == 1)
                    {
                        status = "unsubmitted";
                        IsEditable = true;
                        IsNotSubmitted = true;
                    }
                    if (reqid == 2)
                    {
                        status = "submitted";
                        IsEditable = true;
                    }
                    if (reqid == 3)
                    {
                        status = "approved";
                        IsApproved = true;
                    }
                    if (reqid == 4)
                    {
                        status = "fulfilled";
                        IsApproved = true;
                    }
                }
                else
                {
                    IsEditable = true;
                    IsNotSubmitted = true;
                    // Default: Show Cart
                    RequestVM unsubRequest = Controllers.RequestCtrl.GetReq(empId, "Unsubmitted", access_token).FirstOrDefault();
                    RequestVM bookmarks = Controllers.RequestCtrl.GetReq(empId, "Bookmarked", access_token).FirstOrDefault();
                    if (unsubRequest != null)
                    {
                        reqid = unsubRequest.ReqId;
                        List<RequestDetailVM> unsubReqDetails = Controllers.RequestDetailCtrl.GetReqDetList(reqid, access_token);
                        showList = unsubReqDetails;
                        status = unsubRequest.Status;
                    }
                    else
                    {
                        // TO DO: custom empty cart message - currently: EmptyDataTemplate
                    }
                    if(bookmarks != null)
                    {
                        reqid = bookmarks.ReqId;
                        List<RequestDetailVM> bookmarkDetails = Controllers.RequestDetailCtrl.GetReqDetList(reqid, access_token);
                        Label1.Text = bookmarkDetails.ToString();
                        bookmarkList = bookmarkDetails;
                    }
                    BindGrids();
                }
                lblStatus.Text = status.ToUpper();
                lstShow.FindControl("thdBookmark").Visible = false;
                if (IsNotSubmitted)
                {
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    lstShow.FindControl("thdBookmark").Visible = true;
                }
                else
                {
                    btnSubmit.Visible = false;
                    btnUpdate.Visible = true;
                }
                if (!IsEditable)
                {
                    lstShow.FindControl("thdRemove").Visible = false;
                }
                if (!IsApproved)
                {
                    lstShow.FindControl("thdFulfQty").Visible = false;
                    lstShow.FindControl("thdBalQty").Visible = false;
                    lstShow.FindControl("thdFulf").Visible = false;
                }
            }
        }

        protected void AddItems()
        {

        }

        protected void BindGrids()
        {
            lstShow.DataSource = showList;
            lstShow.DataBind();

            lstBookmark.DataSource = bookmarkList;
            lstBookmark.DataBind();
        }

        protected void lstCatalogue_PagePropertiesChanged(object sender, EventArgs e)
        {
            BindGrids();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (ListViewItem)btn.NamingContainer;
            TextBox txtQty = (TextBox)item.FindControl("spnQty");
            Label lblItemCode = (Label)item.FindControl("lblItemCode");
            Label lblDescription = (Label)item.FindControl("lblDescription");
            int quantity = Convert.ToInt32(txtQty.Text);
            string description = lblDescription.Text;

            Main master = (Main)this.Master;
            master.ShowToastr(this, String.Format("{0} Qty:{1}", description, quantity), "Order Updated", "success");
        }

        protected void btnBookmark_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (ListViewItem)btn.NamingContainer;
            Label lblItemCode = (Label)item.FindControl("lblItemCode");
            Label lblDescription = (Label)item.FindControl("lblDescription");
            string description = lblDescription.Text;

            Main master = (Main)this.Master;
            master.ShowToastr(this, String.Format("{0}", description), "Item Moved to Bookmarks", "success");
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            var item = (ListViewItem)btn.NamingContainer;
            Label lblItemCode = (Label)item.FindControl("lblItemCode");
            Label lblDescription = (Label)item.FindControl("lblDescription");
            string description = lblDescription.Text;

            Main master = (Main)this.Master;
            master.ShowToastr(this, String.Format("{0}", description), "Item Removed", "success");
        }

        protected void btnReqList_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestHistory.aspx");
        }
    }
}