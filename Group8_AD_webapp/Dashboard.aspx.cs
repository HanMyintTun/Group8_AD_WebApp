using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp.DepartmentHead
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RemoveDelegate(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "removewarning();", true);
        }
        protected void AddDelegate(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
        }
    }
}