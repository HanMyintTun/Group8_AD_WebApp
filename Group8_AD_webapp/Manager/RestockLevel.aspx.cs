using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp.Manager
{
    public partial class RestockLevel : System.Web.UI.Page
    {
        static List<Item> items = new List<Item>();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
              
                //BindGrids();

                List<String> productList = new List<String> { "Pen", "Exercise", "Folder" };
                ddlCategory.DataSource = productList;
                ddlCategory.DataBind();

                List<String> threshold = new List<String> { "20%", "30%", "50%" };
                ddlThreshold.DataSource = threshold;
                ddlThreshold.DataBind();

                AddItems();
                BindGrids();

            }
        }
        protected void AddItems()
        {
            items.Add(new Item("A001", "Pen", "Pencil 2B", 50, 1.02, "pack of 12"));

            items.Add(new Item("A002", "Pen", "Pencil 2B, With Eraser End", 50, 1.02, "pack of 12"));

        }
        protected void btnReLevel_Click(object sender, EventArgs e)
        {
            
        }

        protected void BindGrids()
        {
            grdRestockItem.DataSource = items;
            grdRestockItem.DataBind();
        }
        protected void txtSearch_Changed(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
        }
    }
}