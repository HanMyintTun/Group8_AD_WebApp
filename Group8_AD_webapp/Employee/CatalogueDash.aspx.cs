using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8_AD_webapp.Models;
using RestSharp;

namespace Group8_AD_webapp
{
    public partial class CatalogueDash : System.Web.UI.Page
    {
        static List<ItemVM> items = new List<ItemVM>();
        static List<RequestDetailVM> bookmarkList = new List<RequestDetailVM>();
        static string access_token;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PopulateDropDowns();
                DoSearch();
                BindSidePanel();

                showgrid.Visible = true;
                showlist.Visible = false;
                
                lstSearch.DataSource = items;
                lstSearch.DataBind();
                
            }

            ddlsearchcontent.Visible = false;
        }


        protected void DoSearch()
        {
            items = new List<ItemVM>();
            if (Request.QueryString["s"] == "1")
            {
                lblCatTitle.Text = "Frequently Ordered Items";
                // Insert method for finding frequent items
                BindGrids();
            }
            else if (Request.QueryString["s"] == "2")
            {
                lblCatTitle.Text = "Search Results";
                // use Session["cataloguequery"] and Session["querycategory"] to search
                items = new List<ItemVM>();
                //items.Add(new Item("A001", "Pen", "Kittens", 50, 1.02, "pack of 12"));
                //items.Add(new Item("B053", "Exercise", "Puppies", 100, 1.23, "each"));
                BindGrids();
            }
            else
            {
                lblCatTitle.Text = "Catalogue";
                // Display all
                items = Controllers.ItemCtrl.GetAllItems(access_token);
                BindGrids();
            }
        }

        protected void PopulateDropDowns()
        {
            ddlCategory.DataSource = Controllers.ItemCtrl.GetCategory(access_token);
            ddlCategory.DataBind();

            List<string> pagecounts = new List<string> { "6", "9", "12", "All" };
            ddlPageCount.DataSource = pagecounts;
            ddlPageCount.SelectedIndex = 1;
            ddlPageCount.DataBind();
        }

        protected void BindGrids()
        {
            lstCatalogue.DataSource = items;
            lstCatalogue.DataBind();

            grdCatalogue.DataSource = items;
            grdCatalogue.DataBind();

            lblPageCount.Text = "Showing " + (dpgGrdCatalogue.StartRowIndex + 1) + " to " + (dpgGrdCatalogue.StartRowIndex + dpgGrdCatalogue.MaximumRows) + " of " + items.Count();
        }

        protected void BindSidePanel() {
            int empId = 31;
            RequestVM bookmarkReq = Controllers.RequestCtrl.GetReq(empId, "Bookmarked", access_token).FirstOrDefault();
            if (bookmarkReq != null)
            {
                int bmkid = bookmarkReq.ReqId;
                List<RequestDetailVM> bookmarkDetails = Controllers.RequestDetailCtrl.GetReqDetList(bmkid, access_token);
                bookmarkDetails = BusinessLogic.AddItemDescToReqDet(bookmarkDetails);
                bookmarkList = bookmarkDetails.OrderBy(x => x.Desc).ToList();
            }
            lstBookmarks.DataSource = bookmarkList;
            lstBookmarks.DataBind();
        }

        protected void ListPager_PreRender(object sender, EventArgs e)
        {
            //lstCatalogue.DataSource = items;
            //lstCatalogue.DataBind();

            //grdCatalogue.DataSource = items;
            //grdCatalogue.DataBind();
        }

        protected void lstCatalogue_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dpgGrdCatalogue.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            dpgLstCatalogue.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            dpgGrdCatalogue2.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            dpgLstCatalogue2.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindGrids();

            //int pageNumber = Convert.ToInt32(Request["pageNumber"]);

            //(grdCatalogue.FindControl("dpgGrdCatalogue") as DataPager).SetPageProperties(pageNumber * e.StartRowIndex, e.MaximumRows, false);

            //grdCatalogue.DataSource = items;
            //grdCatalogue.DataBind();

            //(lstCatalogue.FindControl("dpgLstCatalogue") as DataPager).SetPageProperties(pageNumber*e.StartRowIndex, e.MaximumRows, false);

            //lstCatalogue.DataSource = items;
            //lstCatalogue.DataBind();

            lblPageCount.Text = "Showing "+ (e.StartRowIndex+1) +" to "+(e.StartRowIndex+ e.MaximumRows) +" of "+items.Count();
            // e.MaximumRows
        }

        protected void lstCatalogue_PagePropertiesChanged(object sender, EventArgs e)
        {
            //(grdCatalogue.FindControl("dpgGrdCatalogue") as DataPager).SetPageProperties(pageNumber * e.StartRowIndex, e.MaximumRows, false);

            //lstCatalogue.DataSource = items;
            //lstCatalogue.DataBind();

            //(lstCatalogue.FindControl("dpgLstCatalogue") as DataPager).SetPageProperties(pageNumber*e.StartRowIndex, e.MaximumRows, false);

            //grdCatalogue.DataSource = items;
            //grdCatalogue.DataBind();
        }

        protected void btnBookmark_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            var item = (ListViewItem)btn.NamingContainer;
            Label lblItemCode = (Label)item.FindControl("lblItemCode");
            Label lblDescription = (Label)item.FindControl("lblDescription");
            string description = lblDescription.Text;

            Main master = (Main)this.Master;
            master.ShowToastr(this, String.Format("{0} Added to Bookmarks", description), "Item Added Successfully", "success");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (ListViewItem)btn.NamingContainer;
            TextBox txtQty = (TextBox)item.FindControl("spnQty");
            Label lblItemCode = (Label)item.FindControl("lblItemCode");
            Label lblDescription = (Label)item.FindControl("lblDescription");
            int quantity = Convert.ToInt32(txtQty.Text);
            string description = lblDescription.Text;

            Main master = (Main)this.Master;
            master.ShowToastr(this, String.Format("{0} Qty:{1} Added to Order", description, quantity), "Item Added Successfully", "success");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Main master = (Main)this.Master;
            master.ShowToastr(this, "", "Test Message", "success");
        }
        protected void btnGrid_Click(object sender, EventArgs e)
        {
            showgrid.Visible = true;
            showlist.Visible = false;
            btnGrid.CssClass = "listbutton active";
            btnList.CssClass = "listbutton";
        }
        protected void btnList_Click(object sender, EventArgs e)
        {
            showgrid.Visible = false;
            showlist.Visible = true;
            btnList.CssClass = "listbutton active";
            btnGrid.CssClass = "listbutton";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetSearchQuery();
            DoSearch();
        }

        protected void GetSearchQuery()
        {
            Session["cataloguequery"] = txtSearch.Text;
            Session["querycategory"] = ddlCategory.Text;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSearchQuery();
            DoSearch();
        }

        protected void txtSearch_Changed(object sender, EventArgs e)
        {
            //Main master = (Main)this.Master;
            //master.ShowToastr(this, "", "Cat: " + ddlCategory.Text + " Query: " + txtSearch.Text, "success");

            string searchquery = txtSearch.Text;
            List<ItemVM> searchitems = items.Where(x => x.Desc.ToLower().Contains(searchquery)).Take(5).ToList();
            lstSearch.DataSource = searchitems;
            lstSearch.DataBind();
            ddlsearchcontent.Visible = true;
            //GetSearchQuery();
            //DoSearch();
        }

        protected void lstSearch_PagePropertiesChanged(object sender, EventArgs e)
        {
            items = new List<ItemVM>();
            string searchquery = txtSearch.Text;
            List<ItemVM> searchitems = items.Where(x => x.Desc.ToLower().Contains(searchquery)).Take(5).ToList();
            lstSearch.DataSource = searchitems;
            lstSearch.DataBind();
            ddlsearchcontent.Visible = true;
        }


        protected void lstSearchbtnAdd_Click(object sender, EventArgs e)
        {
            //var btn = (Button)sender;
            //var item = (ListViewItem)btn.NamingContainer;
            //TextBox txtQty = (TextBox)item.FindControl("lstSearchspnQty");
            //Label lblItemCode = (Label)item.FindControl("lstSearchlblItemCode");
            //Label lblDescription = (Label)item.FindControl("lstSearchlblDescription");
            //int quantity = Convert.ToInt32(txtQty.Text);
            //string description = lblDescription.Text;

            Main master = (Main)this.Master;
            master.ShowToastr(this, String.Format("{0} Qty:{1} Added to Order", "A","B"), "Item Added Successfully", "success");
        }

        protected void lstBookmarks_PagePropertiesChanged(object sender, EventArgs e)
        {
            lstBookmarks.DataSource = items;
            lstBookmarks.DataBind();
        }

        protected void ddlPageCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlPageCount.SelectedValue == "All"){
                dpgGrdCatalogue.PageSize = Convert.ToInt32(items.Count());
                dpgLstCatalogue.PageSize = Convert.ToInt32(items.Count());
                lblPageCount.Text = ddlPageCount.SelectedValue;
            }
            else
            {
                dpgGrdCatalogue.PageSize = Convert.ToInt32(ddlPageCount.SelectedValue);
                dpgLstCatalogue.PageSize = Convert.ToInt32(ddlPageCount.SelectedValue);
            }

            dpgGrdCatalogue.SetPageProperties(dpgGrdCatalogue.StartRowIndex, dpgGrdCatalogue.MaximumRows, true);
            dpgLstCatalogue.SetPageProperties(dpgGrdCatalogue.StartRowIndex, dpgGrdCatalogue.MaximumRows, true);
            dpgGrdCatalogue2.SetPageProperties(dpgGrdCatalogue.StartRowIndex, dpgGrdCatalogue.MaximumRows, true);
            dpgLstCatalogue2.SetPageProperties(dpgGrdCatalogue.StartRowIndex, dpgGrdCatalogue.MaximumRows, true);
            BindGrids();
        }
    }
}