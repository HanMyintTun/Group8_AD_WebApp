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
        static List<ItemVM> allItems = new List<ItemVM>();
        static List<ItemVM> items = new List<ItemVM>();
        static public bool IsBmkTab;

        static List<RequestDetailVM> bookmarkList = new List<RequestDetailVM>();
        static List<ItemVM> frequentList = new List<ItemVM>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["empId"] = 42;

            if (!IsPostBack)
            {
                PopulateDropDowns();
                PopulateCatalogue();
                IsBmkTab = true;
                
                PopulateSidePanel();
                BindSidePanel();

                showgrid.Visible = true;
                showlist.Visible = false;
                IsClean.Value = "false";

                allItems = Controllers.ItemCtrl.GetAllItems();
                lstSearch.DataSource = allItems;
                lstSearch.DataBind();
            }

            ddlsearchcontent.Visible = false;
        }

        protected void PopulateCatalogue()
        {
            lblCatTitle.Text = "Catalogue";
            items = Controllers.ItemCtrl.GetAllItems();

            BindGrids();
        }

        protected void DoSearch()
        {
            string cataloguequery = (string)Session["Query"];
            string querycat = (string)Session["QueryCat"];

            if (cataloguequery != "")
            {
                if (querycat == "All")
                {
                    items = allItems.Where(x => x.Desc.ToLower().Contains(cataloguequery)).ToList(); 
                    //Label1.Text = items.ToString(); //for testing purposes
                }
                else
                {
                    items = allItems.Where(x => x.Cat == querycat && x.Desc.Contains(cataloguequery)).ToList(); 
                }
            }
            else
            {
                if (querycat == "All")
                {
                    items = new List<ItemVM>(allItems);
                }
                else
                {
                    items = allItems.Where(x => x.Cat == querycat).ToList();  
                }
            }

            lblCatTitle.Text = "Search Results";
            BindGrids();
        }

        protected void PopulateDropDowns()
        {
            ddlCategory.DataSource = Controllers.ItemCtrl.GetCategory();
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

            int max = dpgGrdCatalogue.StartRowIndex + dpgGrdCatalogue.MaximumRows;
            if (items.Count < max)
            {
                max = items.Count;
            }
            lblPageCount.Text = "Showing " + (dpgGrdCatalogue.StartRowIndex + 1) + " to " + max + " of " + items.Count();
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

            //int max = e.StartRowIndex + e.MaximumRows;
            //if(items.Count < max)
            //{
            //    max = items.Count;
            //}

            //lblPageCount.Text = "Showing "+ (e.StartRowIndex+1) +" to "+ max +" of "+items.Count();
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

        // NEEDS TO BE EDITED AFTER WEBAPI UP
        protected void btnBookmark_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            var item = (ListViewItem)btn.NamingContainer;
            Label lblItemCode = (Label)item.FindControl("lblItemCode");
            Label lblDescription = (Label)item.FindControl("lblDescription");
            string itemCode = lblItemCode.Text;
            string description = lblDescription.Text;

            int empId = (int)Session["empId"];
            RequestDetailVM success = Group8AD_WebAPI.BusinessLogic.RequestDetailBL.AddReqDet(empId, itemCode, 1, "Bookmarked");
                //Controllers.RequestDetailCtrl.AddBookmark(empId, itemCode);

            if (success != null)
            {
                //btnShowBmk_Click(btnShowBmk, EventArgs.Empty);

                //// TEMPORARY: REMOVE AFTER WEBAPI UP
                //RequestDetailVM addtobmktemp = new RequestDetailVM();
                //addtobmktemp.ReqLineNo = 100;
                //addtobmktemp.ItemCode = "P020";
                //addtobmktemp.Desc = "Paper Photostat A3";
                //bookmarkList.Add(addtobmktemp);
                //// TEMPORARY: REMOVE AFTER WEBAPI UP

                RequestVM bookmarks = Controllers.RequestCtrl.GetReq(empId, "Bookmarked").FirstOrDefault();
                PopulateSidePanel();
                bookmarkList = bookmarkList.OrderByDescending(x => x.ReqLineNo).ToList();
                btnShowBmk_Click(btnShowBmk,EventArgs.Empty);

                //bookmarkPanel.Visible = true;

                //lstBookmarks.DataSource = bookmarkList;
                //lstBookmarks.DataBind();

                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("{0} Added to Bookmarks",description), "Item Added Successfully", "success");

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (ListViewItem)btn.NamingContainer;
            TextBox txtQty = (TextBox)item.FindControl("spnQty");
            Label lblItemCode = (Label)item.FindControl("lblItemCode");
            Label lblDescription = (Label)item.FindControl("lblDescription");
            string itemCode = lblItemCode.Text;
            int reqQty = Convert.ToInt32(txtQty.Text);
            string description = lblDescription.Text;

            int empId = (int)Session["empId"];
            RequestDetailVM success = Group8AD_WebAPI.BusinessLogic.RequestDetailBL.AddReqDet(empId, itemCode, reqQty, "Unsubmitted");
            //bool success = Controllers.RequestDetailCtrl.AddToCart(empId, itemCode, reqQty);
            Main master = (Main)this.Master;
            if (success != null)
            {
                //// TEMPORARY: REMOVE AFTER WEBAPI UP
                //RequestDetailVM addtocarttemp = new RequestDetailVM();
                //addtocarttemp.ReqLineNo = 100;
                //addtocarttemp.ItemCode = "F020";
                //addtocarttemp.Desc = "File Separator";
                //addtocarttemp.ReqQty = 1;
                //Main.cartDetailList.Add(addtocarttemp);
                //// TEMPORARY: REMOVE AFTER WEBAPI UP

                master.FillCart();
                //(master.FindControl("lstCart") as ListView).DataSource = Main.cartDetailList;
                //(master.FindControl("lstCart") as ListView).DataBind();
                master.UpdateCartCount();

                master.ShowToastr(this, String.Format("{0} Qty:{1} Added to Order", description, reqQty), "Item Added Successfully", "success");
            }
            else
            {
                master.ShowToastr(this, String.Format("Item {0} Not Added", description), "Something Went Wrong!", "error");
            }
        }

        protected void btnGrid_Click(object sender, EventArgs e)
        {
            showgrid.Visible = true;
            showlist.Visible = false;
            if (IsClean.Value == "true")
            {
                sidepanelarea.Style.Add("display", "none");
            }
            else
            {
                sidepanelarea.Style.Add("display", "block");
            }
        }
        protected void btnList_Click(object sender, EventArgs e)
        {
            showgrid.Visible = false;
            showlist.Visible = true;
            if (IsClean.Value == "true")
            {
                sidepanelarea.Style.Add("display", "none");
            }
            else
            {
                sidepanelarea.Style.Add("display", "block");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetSearchQuery();
            DoSearch();
        }

        protected void GetSearchQuery()
        {
            Session["Query"] = txtSearch.Text.ToLower();
            Session["QueryCat"] = ddlCategory.Text;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Query"] = "";
            Session["QueryCat"] = ddlCategory.Text;
            DoSearch();
        }

        protected void txtSearch_Changed(object sender, EventArgs e)
        {
            string cataloguequery = txtSearch.Text.ToLower();
            string querycat = ddlCategory.Text;
            List<ItemVM> searchitems = new List<ItemVM>();
            if (querycat == "All")
            {
                searchitems = allItems.Where(x => x.Desc.ToLower().Contains(cataloguequery)).Take(5).ToList();
            } 
            else{
                searchitems = allItems.Where(x => x.Cat == querycat && x.Desc.Contains(cataloguequery)).ToList();
            }
            lstSearch.DataSource = searchitems;
            lstSearch.DataBind();
            ddlsearchcontent.Visible = true;
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
        protected void lstBookmarks_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void PopulateSidePanel()
        {
            int empId = (int)Session["empId"];
            RequestVM bookmarkReq = Controllers.RequestCtrl.GetReq(empId, "Bookmarked").FirstOrDefault();
            if (bookmarkReq != null)
            {
                int bmkid = bookmarkReq.ReqId;
                List<RequestDetailVM> bookmarkDetails = Controllers.RequestDetailCtrl.GetReqDetList(bmkid);
                bookmarkDetails = BusinessLogic.AddItemDescToReqDet(bookmarkDetails);
                bookmarkList = bookmarkDetails.OrderBy(x => x.Desc).ToList();
            }
            
            frequentList = Controllers.ItemCtrl.GetFrequentList(empId);
        }

        protected void BindSidePanel()
        {
            if(IsBmkTab == true)
            {
                lstBookmarks.DataSource = bookmarkList;
                lstBookmarks.DataBind();
            }
            else
            {
                lstBookmarks.DataSource = frequentList;
                lstBookmarks.DataBind();
            }
        }

        protected void btnOpenBmk_Click(object sender, EventArgs e)
        {
            sidepanelarea.Style.Add("display", "block");
            if (bookmarkPanel.Visible == true)
            {
                bookmarkPanel.Visible = false;
            }
            else
            {
                bookmarkPanel.Visible = true;
                BindSidePanel();
            }
        }

        protected void btnShowBmk_Click(object sender, EventArgs e)
        {
            IsBmkTab = true;
            sidepanelarea.Style.Add("display", "block");
            BindSidePanel();
            btnShowBmk.CssClass = "active";
            btnShowRecc.CssClass = "";
            if (bookmarkPanel.Visible == false)
            {
                bookmarkPanel.Visible = true;
            }
        }

        protected void btnShowRecc_Click(object sender, EventArgs e)
        {
            IsBmkTab = false;
            sidepanelarea.Style.Add("display", "block");
            BindSidePanel();
            btnShowBmk.CssClass = "";
            btnShowRecc.CssClass = "active";
            if (bookmarkPanel.Visible == false)
            {
                bookmarkPanel.Visible = true;
            }
        }

        ////protected void btnClean_Click(object sender, EventArgs e)
        ////{
        ////    if(IsClean == false)
        ////    {
        ////        IsClean = true; 
        ////    }
        ////    else
        ////    {
        ////        IsClean = false;
        ////    }
        ////    if(IsClean)
        ////    {
        ////        this.Master.FindControl("nav").Visible = false;
        ////        this.Master.FindControl("side").Visible = false;
        ////        sidepanelarea.Visible = false;
        ////        clean.Visible = true;
        ////    }
        ////    else
        ////    {
        ////        this.Master.FindControl("nav").Visible = true;
        ////        this.Master.FindControl("side").Visible = true;
        ////        sidepanelarea.Visible = true;
        ////        clean.Visible = false;
        ////    }

        ////}
    }
}