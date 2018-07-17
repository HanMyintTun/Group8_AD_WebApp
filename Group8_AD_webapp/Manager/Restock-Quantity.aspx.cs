using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp.Manager
{
    public partial class Restock_Quantity : System.Web.UI.Page
    {
        static List<Item> items = new List<Item>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
            if (!IsPostBack)
            {
                AddItems();
                BindGrids();
            }
        }
        protected void AddItems()
        {
            items.Add(new Item("A001", "Pen", "Pencil 2B", 50, 1.02, "pack of 12"));
        
            items.Add(new Item("A002", "Pen", "Pencil 2B, With Eraser End", 50, 1.02, "pack of 12"));
           
        }

        protected void BindGrids()
        {
            grdCatalogue.DataSource = items;
            grdCatalogue.DataBind();
        }
    }
}