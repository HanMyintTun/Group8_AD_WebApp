using System;
using System.Collections.Generic;
using System.Linq;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<String> productList = ItemBL.GetCatList();
                ddlCategory.DataSource = productList;
                ddlCategory.DataBind();

               // List<String> threshold = new List<String> { 5 10 15 30 50 75  100};
               
               // ddlThreshold.DataSource = threshold;
                //ddlThreshold.DataBind();


                BindGrid();

            }
        }

        protected void btnReLevel_Click(object sender, EventArgs e)
        {

        }

        protected void BindGrid()
        {
            grdRestockItem.DataSource = ItemBL.GetAllItemsbyThreshold();
            grdRestockItem.DataBind();
        }
        protected void txtSearch_Changed(object sender, EventArgs e)
        {
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string cat = ddlCategory.Text;
            string desc = txtSearch.Text;
            double thrs = Convert.ToDouble(ddlThreshold.SelectedValue);
            grdRestockItem.DataSource = ItemBL.GetItems(cat, desc, thrs);
            grdRestockItem.DataBind();
        }

        protected void grdRestockItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRestockItem.PageIndex = e.NewPageIndex + 1;
            BindGrid();
        }

        protected void saveList()
        {

            foreach (GridViewRow row in grdRestockItem.Rows)
            {
                int pagestart = grdRestockItem.PageIndex * grdRestockItem.PageSize;
                int i = pagestart + row.RowIndex;


                //editedItems[i].Price1 = Convert.ToDouble(((TextBox)row.FindControl("txtChangeReLevel")).Text);
                //editedItems[i].Price2 = Convert.ToDouble(((TextBox)row.FindControl("txtChangeRestockQty")).Text);


            }
        }

        protected void grdRestockItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            foreach (GridViewRow row in grdRestockItem.Rows)
            {
                if (e.CommandName == "ReLevel")
                {
                        Label lb = (Label)row.FindControl("lblRecomLevel");
                        string s = lb.Text;
                       //  TextBox tb = (TextBox)grdRestockItem.SelectedRow.FindControl("txtChangeReLevel");
                    //tb.Text = s;
                }
                else if (e.CommandName == "ReQty")
                {

                    txtSearch.Text = "ReQty";
                }
                else { txtSearch.Text = "nth"; }
            }

           
            
        }

        protected void SetTexBox(string itemcode)
        {
            
            
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat = ddlCategory.Text;
            string desc = txtSearch.Text;
            double thrs = Convert.ToDouble(ddlThreshold.SelectedValue);
            grdRestockItem.DataSource = ItemBL.GetItems(cat, desc, thrs);
            grdRestockItem.DataBind();
        }

        protected void ddlThreshold_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat = ddlCategory.Text;
            string desc = txtSearch.Text;
            double thrs = Convert.ToDouble(ddlThreshold.SelectedValue);
            grdRestockItem.DataSource = ItemBL.GetItems(cat, desc, thrs);
            grdRestockItem.DataBind();
        }

       
    }
}