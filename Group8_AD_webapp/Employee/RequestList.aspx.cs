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
        static List<RequestDetailVM> showList = new List<RequestDetailVM>();
        static List<RequestDetailVM> bookmarkList = new List<RequestDetailVM>();
        
        static int reqid;
        string status ="";
        static public bool IsEditable = false;
        static public bool IsNotSubmitted = false;
        static public bool IsApproved = false;
        static public bool IsEmpty = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["empId"] = 42;
            Session["empId"] = 31;
            int empId = (int)Session["empId"];

            if (!IsPostBack) { 
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

                        BindGrids();

                    }
                    else
                    {
                        showList = new List<RequestDetailVM>();
                        bookmarkList = new List<RequestDetailVM>();
                        IsEmpty = true;
                        // TO DO: custom empty cart message - currently: EmptyDataTemplate
                    }
                    if (bookmarks != null)
                    {
                        int bmkreqid = bookmarks.ReqId;
                        PopulateBookmarks(bmkreqid);
                    }
                    BindGrids();
                }

                lblStatus.Text = status.ToUpper() + " REQID:"+reqid;    // TODO: REMOVE REQID

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

        protected void PopulateBookmarks(int reqid)
        {
            List<RequestDetailVM> reqDetails = Controllers.RequestDetailCtrl.GetReqDetList(reqid, access_token);
            reqDetails = BusinessLogic.AddItemDescToReqDet(reqDetails);
            bookmarkList = reqDetails;
            bookmarkList = bookmarkList.OrderByDescending(x => x.ReqLineNo).ToList();
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
            //BindGrids();
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

        // EDIT AFTER WEBAPI UP
        protected void btnBookmark_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            var item = (ListViewItem)btn.NamingContainer;
            Label lblItemCode = (Label)item.FindControl("lblItemCode");
            Label lblDescription = (Label)item.FindControl("lblDescription");
            string itemCode = lblItemCode.Text;
            string description = lblDescription.Text;

            int empId = (int)Session["empId"];
            bool success = Controllers.RequestDetailCtrl.AddBookmark(empId, itemCode, access_token);

            if (success)
            {
                //btnShowBmk_Click(btnShowBmk, EventArgs.Empty);

                // TEMPORARY: REMOVE AFTER WEBAPI UP
                RequestDetailVM addtobmktemp = new RequestDetailVM();
                addtobmktemp.ReqLineNo = 100;
                addtobmktemp.ItemCode = "P020";
                addtobmktemp.Desc = "Paper Photostat A3";
                bookmarkList.Add(addtobmktemp);
                // TEMPORARY: REMOVE AFTER WEBAPI UP
                
                // TODO: Update List from DB
                bookmarkList = bookmarkList.OrderByDescending(x => x.ReqLineNo).ToList();
                lstBookmark.DataSource = bookmarkList;
                lstBookmark.DataBind();

                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("{0} Added to Bookmarks", description), "Item Added Successfully", "success");

            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            var item = (ListViewItem)btn.NamingContainer;
            Label lblList = (Label)item.FindControl("lblList");
            Label lblReqId = (Label)item.FindControl("lblReqId");
            Label lblItemCode = (Label)item.FindControl("lblItemCode");
            Label lblDescription = (Label)item.FindControl("lblDescription");
            string list = lblList.Text;
            string description = lblDescription.Text;
            string itemCode = lblItemCode.Text;
            int reqId = Convert.ToInt32(lblReqId.Text);

            bool success = Controllers.RequestDetailCtrl.RemoveReqDet(reqId, itemCode, access_token);
            if (list == "Cart") { PopulateList(reqId); }
            else if (list == "Bookmark") { PopulateBookmarks(reqId); }
            BindGrids();

            Main master = (Main)this.Master;
            master.ShowToastr(this, String.Format("{0}", description), "Item Removed", "success");
        }

        protected void btnReqList_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestHistory.aspx");
        }


        // NEEDS TO BE EDITED AFTER WEBAPI UP
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (ListViewItem)btn.NamingContainer;
            Label lblItemCode = (Label)item.FindControl("lblItemCode");
            Label lblDescription = (Label)item.FindControl("lblDescription");
            string itemCode = lblItemCode.Text;
            int reqQty = 1;
            string description = lblDescription.Text;

            int empId = (int)Session["empId"];
            bool success = Controllers.RequestDetailCtrl.AddToCart(empId, itemCode, reqQty, access_token);
            Main master = (Main)this.Master;

            if (success)
            {
                // TEMPORARY: REMOVE AFTER WEBAPI UP
                RequestDetailVM addtocarttemp = new RequestDetailVM();
                addtocarttemp.ReqLineNo = 100;
                addtocarttemp.ItemCode = "F020";
                addtocarttemp.Desc = "File Separator";
                addtocarttemp.ReqQty = 1;
                Main.cartDetailList.Add(addtocarttemp);
                showList.Add(addtocarttemp);
                // TEMPORARY: REMOVE AFTER WEBAPI UP

                // TODO: update list from DB
                lstShow.DataSource = showList;
                lstShow.DataBind();

                (master.FindControl("lstCart") as ListView).DataSource = Main.cartDetailList;
                (master.FindControl("lstCart") as ListView).DataBind();
                master.UpdateCartCount();

                master.ShowToastr(this, String.Format("{0} Qty:{1} Added to Order", itemCode, reqQty), "Item Added Successfully", "success");
            }
            else
            {
                master.ShowToastr(this, String.Format("Item {0} Not Added", description), "Something Went Wrong!", "error");
            }
        }
    }
}