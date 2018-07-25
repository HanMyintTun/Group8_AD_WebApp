using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool IsValid = Int32.TryParse(TextBox1.Text, out int empId);
            string password = "";
            if (!IsValid)
            {
                Label1.Text = "Please Type a Number";
            }
            else
            {
                bool success = Service.UtilityService.Authenticate(empId, password);
                if (!success)
                {
                    Label1.Text = "Invalid Number";
                }
                else
                {
                    switch (Session["role"])
                    {
                        case "Department Head": Response.Redirect("~/Dashboard.aspx"); break;   //Change when in DeptHead folder
                        case "Delegate": Response.Redirect("~/Dashboard.aspx"); break;          //Change when in DeptHead folder
                        case "Representative": Response.Redirect("~/Employee/CatalogueDash.aspx"); break;
                        case "Employee": Response.Redirect("~/Employee/CatalogueDash.aspx"); break;
                        case "Store Manager": Response.Redirect("~/Manager/StoreDashboard.aspx"); break;
                        case "Store Supervisor": Response.Redirect("~/Manager/StoreDashboard.aspx"); break;
                        case "Store Clerk": Response.Redirect("~/Manager/StoreDashboard.aspx"); break;
                        default: Label1.Text = "Not a Valid Role"; break;
                    }
                }
            }
        }
    }
}