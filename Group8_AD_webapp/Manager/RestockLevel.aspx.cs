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
        static string itemcode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<String> productList = ItemBL.GetCatList();
                ddlCategory.DataSource = productList;
                ddlCategory.DataBind();
                items = ItemBL.GetAllItems();
                editedItems = items.ToList();
                // List<String> threshold = new List<String> { 5 10 15 30 50 75  100};
                // ddlThreshold.DataSource = threshold;
                //ddlThreshold.DataBind();
                BindGrid();


            }
        }
        protected void BindGrid()
        {
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
            cat = ddlCategory.Text;
            desc = txtSearch.Text;
            thres = Convert.ToDouble(ddlThreshold.SelectedValue);
            grdRestockItem.DataSource = ItemBL.GetItems(cat, desc, thres);
            grdRestockItem.DataBind();
        }

        protected void txtSearch_Changed(object sender, EventArgs e)
        {
            SearchList();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchList();
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchList();
        }

        protected void ddlThreshold_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchList();
        }

        protected void grdRestockItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            saveList();
            grdRestockItem.PageIndex = e.NewPageIndex;
            BindGrid();
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
                    editedItems[i].ReccReorderLvl = Convert.ToInt32(((TextBox)row.FindControl("txtChangeReLevel")).Text);
                   // editedItems[i].ReccReorderQty = Convert.ToInt32(((TextBox)row.FindControl("txtChangeRestockQty")).Text);
                }

                  


            }
        }

        protected void grdRestockItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int RowIndex = int.Parse(e.CommandArgument.ToString()); // getting row index

                if (e.CommandName == "ReLevel")
                    if (e.CommandArgument.ToString() != "")
                    {
                        Label lb = (Label)grdRestockItem.Rows[RowIndex].FindControl("lblRecomLevel");
                        string l = lb.Text;
                        TextBox tb = (TextBox)grdRestockItem.Rows[RowIndex].FindControl("txtChangeReLevel");
                        tb.Text = l;
                     
                    }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlConfirm').modal();", true);//modal popup
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlConfirm').modal('toggle');", true);//modal popup
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlConfirm').modal('toggle');", true);//modal popup
        }


    }
}
      
