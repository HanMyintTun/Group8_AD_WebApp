using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp
{
    public partial class RequestList : System.Web.UI.Page
    {
        List<Item> cartList = new List<Item>();
        List<Item> bookmarkList = new List<Item>();
        int reqid;
        string status ="";
        public bool IsEditable = false;
        public bool IsNotSubmitted = false;
        public bool IsApproved = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["reqid"] != "" || Request.QueryString["reqid"] != null)
                {
                    reqid = Convert.ToInt32(Request.QueryString["reqid"]);
                    // Retrieve Request from database by reqid
                    AddItems();
                    BindGrid();
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
                    // Create new order
                    reqid = 100;
                    status = "unsubmitted";
                    IsEditable = true;
                    AddItems();
                    BindGrid();
                }
                lblStatus.Text = status.ToUpper();
                if (IsNotSubmitted)
                {
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                }
                else
                {
                    btnSubmit.Visible = false;
                    btnUpdate.Visible = true;
                }
                if (!IsEditable)
                {
                    lstCart.FindControl("thdRemove").Visible = false;
                }
                if (!IsApproved)
                {
                    lstCart.FindControl("thdFulfQty").Visible = false;
                    lstCart.FindControl("thdBalQty").Visible = false;
                    lstCart.FindControl("thdFulf").Visible = false;
                }
            }
        }

        protected void AddItems()
        {
            cartList.Add(new Item("A001", "Pen", "Pencil 2B", 50, 1.02, "pack of 12"));
            cartList.Add(new Item("B053", "File", "File, Yellow", 100, 1.23, "each"));
            cartList.Add(new Item("C007", "Stapler", "Stapler 1in", 150, 1.50, "box"));
            cartList.Add(new Item("A002", "Pen", "Pencil 2B, With Eraser End", 50, 1.02, "pack of 12"));
            cartList.Add(new Item("B054", "File", "File, Blue", 100, 1.23, "each"));
            cartList.Add(new Item("C008", "Stapler", "Stapler 2in", 150, 1.50, "box"));

            bookmarkList.Add(new Item("A002", "Pen", "Pencil 2B, With Eraser End", 50, 1.02, "pack of 12"));
            bookmarkList.Add(new Item("B054", "File", "File, Blue", 100, 1.23, "each"));
            bookmarkList.Add(new Item("C008", "Stapler", "Stapler 2in", 150, 1.50, "box"));
        }

        protected void BindGrid()
        {
            lstCart.DataSource = cartList;
            lstCart.DataBind();

            lstBookmark.DataSource = bookmarkList;
            lstBookmark.DataBind();
        }

        protected void lstCatalogue_PagePropertiesChanged(object sender, EventArgs e)
        {
            BindGrid();
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