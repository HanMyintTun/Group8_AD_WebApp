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

                List<String> threshold = new List<String> { "20%", "30%", "50%" };
                ddlThreshold.DataSource = threshold;
                ddlThreshold.DataBind();

                
                BindGrid();

            }
        }
        //protected void AddItems()
        //{
        //    items.Add(new Item("A001", "Pen", "Pencil 2B", 50, 1.02, "pack of 12"));

        //    items.Add(new Item("A002", "Pen", "Pencil 2B, With Eraser End", 50, 1.02, "pack of 12"));

        //}
        
        protected void btnReLevel_Click(object sender, EventArgs e)
        {
           
        }

        protected void BindGrid()
        {
            items = ItemBL.GetAllItems();
            grdRestockItem.DataSource = items;
            grdRestockItem.DataBind();
        }
        protected void txtSearch_Changed(object sender, EventArgs e)
        {
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
        }

        protected void grdRestockItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRestockItem.PageIndex = e.NewPageIndex;
           BindGrid();
        }

        protected void saveList()
        {
          
            foreach (GridViewRow row in grdRestockItem.Rows)
            {
                int pagestart = grdRestockItem.PageIndex * grdRestockItem.PageSize;
                int i = pagestart + row.RowIndex;
                if (editedItems[i].ItemCode == ((Label)row.FindControl("lblItemCode")).Text)
                {
                    
                    editedItems[i].Price1 = Convert.ToDouble(((TextBox)row.FindControl("txtChangeReLevel")).Text);
                    editedItems[i].Price2 = Convert.ToDouble(((TextBox)row.FindControl("txtChangeRestockQty")).Text);
                  
                }
            }
        }

    }
}