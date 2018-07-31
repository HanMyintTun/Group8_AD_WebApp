using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8_AD_webapp.Models;
using Group8AD_WebAPI.BusinessLogic;

namespace Group8_AD_webapp.Manager
{
    public partial class RestockLevel : System.Web.UI.Page
    {
        static List<ItemVM> items = new List<ItemVM>();
        static List<ItemVM> editedItems = new List<ItemVM>();
        static string cat;
        static string desc;
        static double thres;
        protected void Page_Load(object sender, EventArgs e)
        {
            Service.UtilityService.CheckRoles("Store");
            int empid = Convert.ToInt32(Session["empId"]);
            if (!IsPostBack)
            {

                // Adds active class to menu Item (sidebar)
                Main master = (Main)this.Master;
                master.ActiveMenu("storerestock");

                List<String> productList = ItemBL.GetCatList();
                ddlCategory.DataSource = productList;
                ddlCategory.DataBind();
                
                BindGrid();

            }
        }

        //public List<ItemVM> GetAllIteminfo(List<ItemVM> list)
        //{
        //    items = ItemBL.GetAllItemsbyThreshold();
        //    foreach (ItemVM item in list)
        //    {
        //        item.NewReorderLvl = item.ReorderLevel;
        //        item.NewReorderQty = item.ReorderQty;
        //    }
        //    return list;

        //}
        protected void BindGrid()
        {

            // items = ItemBL.GetAllItems();
            editedItems = ItemBL.GetAllItemsbyThreshold();
            grdRestockItem.DataSource = editedItems;
            grdRestockItem.DataBind();
            int min = (grdRestockItem.PageIndex) * grdRestockItem.PageSize;
            int max = (min + grdRestockItem.PageSize);
            if (editedItems.Count < max)
            {
                max = editedItems.Count;
            }
            lblPageCount.Text = "Showing " + (min + 1) + " to " + max + " of " + editedItems.Count.ToString();
        }

        protected void SearchList()
        {
            cat = ddlCategory.SelectedValue;
            desc = txtSearch.Text;
            thres = Convert.ToDouble(ddlThreshold.SelectedValue);
            grdRestockItem.DataSource = ItemBL.GetItems(cat, desc, thres);
            grdRestockItem.DataBind();
        }

        protected void txtSearch_Changed(object sender, EventArgs e)
        {

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchList();
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlThreshold_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdRestockItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            saveList();
            grdRestockItem.PageIndex = e.NewPageIndex;

        }

        protected void saveList()
        {
            lblPageCount.Text = "";
            foreach (GridViewRow row in grdRestockItem.Rows)
            {
                int pagestart = grdRestockItem.PageIndex * grdRestockItem.PageSize;
                int i = pagestart + row.RowIndex;
                if (editedItems[i].ItemCode == ((Label)row.FindControl("lblItemCode")).Text)
                {
                    editedItems[i].NewReorderLvl = Convert.ToInt32(((TextBox)row.FindControl("txtChangeReLevel")).Text);
                    editedItems[i].NewReorderQty = Convert.ToInt32(((TextBox)row.FindControl("txtChangeRestockQty")).Text);
                }
                grdRestockItem.DataSource = editedItems;
                grdRestockItem.DataBind();



            }
        }

        protected void grdRestockItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int RowIndex = int.Parse(e.CommandArgument.ToString()); // getting row index

            if (e.CommandName == "ReLevel")
            {

                if (e.CommandArgument.ToString() != "")
                {
                    Label lb = (Label)grdRestockItem.Rows[RowIndex].FindControl("lblRecomLevel");
                    string l = lb.Text;
                    TextBox tb = (TextBox)grdRestockItem.Rows[RowIndex].FindControl("txtChangeReLevel");
                    tb.Text = l;

                }

            }

            if (e.CommandName == "ReQty")
            {

                if (e.CommandArgument.ToString() != "")
                {
                    Label lb1 = (Label)grdRestockItem.Rows[RowIndex].FindControl("lblRecomQty");
                    string l1 = lb1.Text;
                    TextBox tb1 = (TextBox)grdRestockItem.Rows[RowIndex].FindControl("txtChangeRestockQty");
                    tb1.Text = l1;

                }

            }

            if (e.CommandName == "Trend")
            {

                if (e.CommandArgument.ToString() != "")
                {
                    Label icode = (Label)grdRestockItem.Rows[RowIndex].FindControl("lblItemCode");
                    string itmcode = icode.Text;
                    ItemVM itm = new ItemVM();
                    itm =  Controllers.ItemCtrl.GetItem(itmcode);
                    lblDesc.Text = itm.Desc.ToString();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlTrend').modal();", true);//modal popup
                }

            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            saveList();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlConfirm').modal();", true);//modal popup
        }
      
        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            List<ItemVM> updateitem = new List<ItemVM>();

            foreach (ItemVM item in editedItems)
            {
                ItemVM i = ItemBL.GetItem(item.ItemCode);
                i.ReorderLevel = item.NewReorderLvl;
                i.ReorderQty = item.NewReorderQty;
                updateitem.Add(i);
            }


            bool success = Controllers.ItemCtrl.UpdateItems(updateitem);
            if (success)
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Item Reorder Level and Quantity are updated"), "Successfully update!", "success");
                //BindGrid();
            }
            else
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Item Reorder Level and Quantity Changes not Submitted"), "Something Went Wrong!", "error");
            }
            
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlConfirm').modal('toggle');", true);//modal popup
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlConfirm').modal('toggle');", true);//modal popup
        }

    }
}

