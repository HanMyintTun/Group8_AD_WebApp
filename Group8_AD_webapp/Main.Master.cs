using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>();
            if (!IsPostBack)
            {
                items.Add(new Item("C007", "Stapler", "Stapler 1in", 150, 1.50, "box"));
                items.Add(new Item("A002", "Pen", "Pencil 2B, With Eraser End", 50, 1.02, "pack of 12"));
                items.Add(new Item("B054", "File", "File, Blue", 100, 1.23, "each"));
                items.Add(new Item("C008", "Stapler", "Stapler 2in", 150, 1.50, "box"));
            }
            lstCart.DataSource = items;
            lstCart.DataBind();
        }

        public void ShowToastr(object sender, string message, string title, string type)
        {
            ScriptManager.RegisterStartupScript((Page)sender, sender.GetType(), "toastr_message",
            String.Format("toastr.{0}('{1}', '{2}', {{positionClass: 'toast-bottom-right'}});", type.ToLower(), message, title), true);
        }

        protected void lstCart_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}