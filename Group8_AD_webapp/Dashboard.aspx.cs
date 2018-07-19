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
        static string access_token;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                access_token = Session["Token"].ToString();
               
                ddlRep.DataSource = Controllers.EmployeeCtrl.getEmployeeList(access_token);
                ddlRep.DataTextField = "empName";
                ddlRep.DataValueField = "empId";
                ddlRep.DataBind();

                ddlDelegate.DataSource = Controllers.EmployeeCtrl.getEmployeeList(access_token);
                ddlDelegate.DataTextField = "empName";
                ddlDelegate.DataValueField = "empId";
                ddlDelegate.DataBind();
            }
            
        }

        protected void RemoveDelegate(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "removewarning();", true);
        }
        protected void AddDelegate(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
        }
        protected void AddRep(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalertrep();", true);
        }
    }
}