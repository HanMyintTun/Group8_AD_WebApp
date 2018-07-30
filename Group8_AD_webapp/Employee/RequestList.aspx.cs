using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8_AD_webapp.Models;
using Newtonsoft.Json;

namespace Group8_AD_webapp
{
    public partial class RequestList : System.Web.UI.Page
    {
        List<RequestVM> requests = new List<RequestVM>();
        static List<RequestDetailVM> showList = new List<RequestDetailVM>();
        static List<RequestDetailVM> bookmarkList = new List<RequestDetailVM>();
        static List<RequestDetailVM> submitList = new List<RequestDetailVM>();
        
        static int reqid;
        static int bmkid;
        static string status = "";
        static public bool IsEditable = false;
        static public bool IsNotSubmitted = false;
        static public bool IsApproved = false;
        static public bool IsEmpty = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Service.UtilityService.CheckRoles("Employee");
            int empId = Convert.ToInt32(Session["empId"]);

            if (!IsPostBack)
            {
                Main master = (Main)this.Master;
                master.ActiveMenu("none");

                reqid = 0;
                bmkid = 0;
                // If a request ID is present
                if (Request.QueryString["reqid"] != null)
                {
                    reqid = Convert.ToInt32(Request.QueryString["reqid"]);
                    RequestVM request = Controllers.RequestCtrl.GetRequestByReqId(reqid);
                    if (request != null)
                    {
                        reqid = request.ReqId;
                        status = request.Status;
                        PopulateList(reqid);
                        BindGrids();
                        IsEmpty = false;
                    }
                    else
                    {
                        BindGrids();
                    }
                }

                // Default: Show Unsubmitted List and Bookmarks
                else
                {
                    RequestVM unsubRequest = Controllers.RequestCtrl.GetReq(empId, "Unsubmitted").FirstOrDefault();
                    RequestVM bookmarks = Controllers.RequestCtrl.GetReq(empId, "Bookmarked").FirstOrDefault();
                    if (unsubRequest != null)
                    {
                        reqid = unsubRequest.ReqId;
                        status = unsubRequest.Status;
                        PopulateList(reqid);
                        BindGrids();
                        IsEmpty = false;

                    }
                    else
                    {
                        showList = new List<RequestDetailVM>();
                        status = "Unsubmitted";
                        IsEmpty = true;
                        // TO DO: custom empty cart message - currently: EmptyDataTemplate
                    }
                    if (bookmarks != null)
                    {
                        bmkid = bookmarks.ReqId;
                        PopulateBookmarks(bmkid);
                    }
                    else
                    {
                        bookmarkList = new List<RequestDetailVM>();
                    }
                    BindGrids();
                }

                lblStatus.Text = status.ToUpper(); 

                if (status == "Unsubmitted")
                {
                    UnsubSettings();
                }

                if (status == "Submitted")
                {
                    IsEditable = true;
                    IsNotSubmitted = false;
                    IsApproved = false;
                    btnSubmit.Text = "Update";
                    btnSubmit.Visible = true;
                    btnCancel.Visible = true;
                    btnCatalogue.Visible = false;
                    lstShow.FindControl("thdBookmark").Visible = false;
                }

                if (status == "Approved" || status == "Fulfilled" || status == "Cancelled" || status == "Rejected")
                {
                    IsEditable = false;
                    IsApproved = true;
                    IsNotSubmitted = false;
                    lstShow.FindControl("thdBookmark").Visible = false;
                    btnSubmit.Visible = false;
                    btnCancel.Visible = false;
                    btnCatalogue.Visible = false;
                    //btnUpdate.Visible = false;
                    lstShow.FindControl("thdRemove").Visible = false;
                }

                if (!IsEmpty && !IsApproved)
                {
                    HideHeaders();
                }
            }

        }

        protected void UnsubSettings()
        {
            IsEditable = true;
            IsNotSubmitted = true;
            btnCancel.Visible = true;
            btnSubmit.Visible = true;
            //btnUpdate.Visible = false;
            btnCatalogue.Visible = true;
            btnReqList.Visible = false;
        }

        protected void HideHeaders()
        {
            lstShow.FindControl("thdFulfQty").Visible = false;
            lstShow.FindControl("thdBalQty").Visible = false;
            lstShow.FindControl("thdFulf").Visible = false;
        }

    protected void PopulateList(int reqid)
        {
            List<RequestDetailVM> reqDetails = Controllers.RequestDetailCtrl.GetReqDetList(reqid);
            reqDetails = BusinessLogic.AddItemDescToReqDet(reqDetails);
            showList = reqDetails;
        }

        protected void PopulateBookmarks(int reqid)
        {
            List<RequestDetailVM> reqDetails = Controllers.RequestDetailCtrl.GetReqDetList(reqid);
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

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    var btn = (Button)sender;
        //    var item = (ListViewItem)btn.NamingContainer;
        //    TextBox txtQty = (TextBox)item.FindControl("spnQty");
        //    Label lblItemCode = (Label)item.FindControl("lblItemCode");
        //    Label lblDescription = (Label)item.FindControl("lblDescription");
        //    int quantity = Convert.ToInt32(txtQty.Text);
        //    string description = lblDescription.Text;

        //    Main master = (Main)this.Master;
        //    master.ShowToastr(this, String.Format("{0} Qty:{1}", description, quantity), "Order Updated", "success");
        //}

        protected void btnBookmark_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            var item = (ListViewItem)btn.NamingContainer;
            Label lblItemCode = (Label)item.FindControl("lblItemCode");
            Label lblDescription = (Label)item.FindControl("lblDescription");
            string itemCode = lblItemCode.Text;
            string description = lblDescription.Text;

            int empId = (int)Session["empId"];
            bool success = Controllers.RequestDetailCtrl.AddBookmark(empId, itemCode);

            if (success)
            {
                RequestVM bookmarks = Controllers.RequestCtrl.GetReq(empId, "Bookmarked").FirstOrDefault();
                PopulateBookmarks(bookmarks.ReqId);
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

            bool success = Controllers.RequestDetailCtrl.RemoveReqDet(reqId, itemCode);
            if (list == "Cart") { PopulateList(reqId); }
            else if (list == "Bookmark") { PopulateBookmarks(reqId); }
            BindGrids();

            Main master = (Main)this.Master;
            master.FillCart();
            master.UpdateCartCount();
            
            master.ShowToastr(this, String.Format("{0}", description), "Item Removed", "success");
        }

        protected void btnCatalogue_Click(object sender, EventArgs e)
        {
            Response.Redirect("CatalogueDash.aspx");
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
            bool success = Controllers.RequestDetailCtrl.AddToCart(empId, itemCode, reqQty);
            Main master = (Main)this.Master;

            if (success)
            {
                //// TEMPORARY: REMOVE AFTER WEBAPI UP
                //RequestDetailVM addtocarttemp = new RequestDetailVM();
                //addtocarttemp.ReqLineNo = 100;
                //addtocarttemp.ItemCode = "F020";
                //addtocarttemp.Desc = "File Separator";
                //addtocarttemp.ReqQty = 1;
                //Main.cartDetailList.Add(addtocarttemp);
                //showList.Add(addtocarttemp);
                //// TEMPORARY: REMOVE AFTER WEBAPI UP

                RequestVM unsubRequest = Controllers.RequestCtrl.GetReq(empId, "Unsubmitted").FirstOrDefault();
                PopulateList(unsubRequest.ReqId);
                lstShow.DataSource = showList;
                lstShow.DataBind();
                UnsubSettings();
                HideHeaders();

                
                master.FillCart();
                master.UpdateCartCount();

                //(master.FindControl("lstCart") as ListView).DataSource = Main.cartDetailList;
                //(master.FindControl("lstCart") as ListView).DataBind();
                //master.UpdateCartCount();

                master.ShowToastr(this, String.Format("{0} Qty:{1} Added to Order", description, reqQty), "Item Added Successfully", "success");
            }
            else
            {
                master.ShowToastr(this, String.Format("Item {0} Not Added", description), "Something Went Wrong!", "error");
            }
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            submitList = new List<RequestDetailVM>();
            foreach (ListViewItem item in lstShow.Items)
            {
                RequestDetailVM addItem = new RequestDetailVM();
                Label lblReqId = (Label)item.FindControl("lblReqId");
                addItem.ReqId = Convert.ToInt32(lblReqId.Text);
                Label lblReqLineNo = (Label)item.FindControl("lblReqLineNo");
                addItem.ReqLineNo = Convert.ToInt32(lblReqLineNo.Text);
                Label lblItemCode = (Label)item.FindControl("lblItemCode");
                addItem.ItemCode = lblItemCode.Text;
                TextBox txtQty = (TextBox)item.FindControl("spnQty");
                addItem.ReqQty = Convert.ToInt32(txtQty.Text);
                Label lblDesc = (Label)item.FindControl("lblDescription");
                addItem.Desc = lblDesc.Text;
                addItem.AwaitQty = 0;
                addItem.FulfilledQty = 0;

                submitList.Add(addItem);
            }
            
            lstConfirm.DataSource = submitList;
            lstConfirm.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }


        // NEEDS TO BE FIXED
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            bool success = Controllers.RequestCtrl.SubmitRequest(reqid, submitList);
            //int empId = 42;
            //RequestVM unsubRequest = Controllers.RequestCtrl.GetReq(empId, "Unsubmitted").FirstOrDefault();
            //List<RequestDetailVM> reqDetails = Controllers.RequestDetailCtrl.GetReqDetList(unsubRequest.ReqId);

            //Label1.Text = reqid+" ***"+JsonConvert.SerializeObject(reqDetails);      //success; // for testing purposes
            //RequestVM success = Group8AD_WebAPI.BusinessLogic.RequestBL.SubmitReq(unsubRequest.ReqId, reqDetails); // Controllers.RequestCtrl.SubmitRequest(unsubRequest.ReqId, reqDetails);
            //Label1.Text = success.ToString();

            if (success && status == "Unsubmitted")
            {
                Session["Message"] = "Request Submitted Successfully";
                Response.Redirect("RequestHistory.aspx");
            }
            else if (success)
            {
                Session["Message"] = "Request Updated Successfully";
                Response.Redirect("RequestHistory.aspx");
            }
            else
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Request not Submitted"), "Something Went Wrong!", "error");
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openCancelModal();", true);
        }

        protected void btnConfirmCancel_Click(object sender, EventArgs e)
        {
            bool success = Controllers.RequestCtrl.CancelRequest(reqid);
            if (success)
            {
                Session["Message"] = "Request Cancelled Successfully";
                Response.Redirect("RequestHistory.aspx");
            }
            else
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Request not Cancelled"), "Something Went Wrong!", "error");
            }
        }

        protected void btnConfirm_Click1(object sender, EventArgs e)
        {
            //bool success = Controllers.RequestCtrl.SubmitRequest(reqid, submitList);
            Label1.Text = JsonConvert.SerializeObject(submitList);      //success; // for testing purposes

            //if (success && status == "Unsubmitted")
            //{
            //    Session["Message"] = "Request Submitted Successfully";
            //    Response.Redirect("RequestHistory.aspx");
            //}
            //else if (success)
            //{
            //    Session["Message"] = "Request Updated Successfully";
            //    Response.Redirect("RequestHistory.aspx");
            //}
            //else
            //{
            //    Main master = (Main)this.Master;
            //    master.ShowToastr(this, String.Format("Request not Submitted"), "Something Went Wrong!", "error");
            //}
        }
    }
}