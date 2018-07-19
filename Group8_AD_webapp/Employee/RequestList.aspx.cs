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
        public bool IsEmpty = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            empId = 31;

            if (!IsPostBack)
            {
                // If a request ID is present
                if (Request.QueryString["reqid"] != null)
                {
                    reqid = Convert.ToInt32(Request.QueryString["reqid"]);
                    RequestVM request = Controllers.RequestCtrl.GetRequestByReqId(reqid, access_token);
                    if (request != null)
                    {
                        reqid = request.ReqId;
                        status = request.Status;
                        PopulateList(reqid);
                        BindGrids();
                    }
                    else
                    {
                        BindGrids();
                        // Custom Error Message
                    }
                }

                // Default: Show Unsubmitted List and Bookmarks
                else
                {
                    IsEditable = true;
                    IsNotSubmitted = true;

                    RequestVM unsubRequest = Controllers.RequestCtrl.GetReq(empId, "Unsubmitted", access_token).FirstOrDefault();
                    RequestVM bookmarks = Controllers.RequestCtrl.GetReq(empId, "Bookmarked", access_token).FirstOrDefault();
                    if (unsubRequest != null)
                    {
                        reqid = unsubRequest.ReqId;
                        status = unsubRequest.Status;
                        PopulateList(reqid);
                        //lstShow.FindControl("thdBookmark").Visible = true;

                        BindGrids();

                    }
                    else
                    {
                        showList = new List<RequestDetailVM>();
                        bookmarkList = new List<RequestDetailVM>();
                        IsEmpty = true;
                        // TO DO: custom empty cart message - currently: EmptyDataTemplate
                    }
                    if(bookmarks != null)
                    {
                        reqid = bookmarks.ReqId;
                        List<RequestDetailVM> bookmarkDetails = Controllers.RequestDetailCtrl.GetReqDetList(reqid, access_token);
                        bookmarkDetails = BusinessLogic.AddItemDescToReqDet(bookmarkDetails);
                        bookmarkList = bookmarkDetails.OrderBy(x => x.Desc).ToList();
                    }
                    BindGrids();
                }

                lblStatus.Text = status.ToUpper();

                if (status == "Submitted" || status == "Approved" || status == "Fulfilled" || status == "Cancelled")
                {
                    IsApproved = true;
                    lstShow.FindControl("thdBookmark").Visible = false;
                    btnSubmit.Visible = false;
                    btnUpdate.Visible = false;
                    if (status == "Submitted")
                    {
                        IsEditable = true;
                    }
                }

                if (!IsEmpty && IsNotSubmitted)
                {
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    lstShow.FindControl("thdFulfQty").Visible = false;
                    lstShow.FindControl("thdBalQty").Visible = false;
                    lstShow.FindControl("thdFulf").Visible = false;
                }
                if (!IsEmpty && !IsNotSubmitted && !IsApproved)
                {
                    btnUpdate.Visible = true;
                }
                if (!IsEmpty && !IsEditable)
                {
                    lstShow.FindControl("thdRemove").Visible = false;
                }
                if (!IsEmpty && !IsApproved)
                {
                    lstShow.FindControl("thdFulfQty").Visible = false;
                    lstShow.FindControl("thdBalQty").Visible = false;
                    lstShow.FindControl("thdFulf").Visible = false;
                }
            }
        }

        protected void PopulateList(int reqid)
        {
            List<RequestDetailVM> reqDetails = Controllers.RequestDetailCtrl.GetReqDetList(reqid, access_token);
            reqDetails = BusinessLogic.AddItemDescToReqDet(reqDetails);
            showList = reqDetails;
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