using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8_AD_webapp.Models;
using Group8AD_WebAPI.BusinessLogic;

namespace Group8_AD_webapp
{
    public partial class Notifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateNotifs();
        }

        protected void PopulateNotifs()
        {
            List<NotificationVM> notifs = NotificationBL.GetNotifications((int)Session["empId"]);
            notifs.ForEach(x => x.FromEmpName = (EmployeeBL.GetEmp(x.FromEmp) as EmployeeVM).EmpName);
            lstFullNof.DataSource = notifs;
            lstFullNof.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            switch (Session["role"])
            {
                case "Department Head": Response.Redirect("~/DepartmentHead/Dashboard.aspx"); break;
                case "Delegate": Response.Redirect("~/DepartmentHead/Dashboard.aspx"); break;
                case "Representative": Response.Redirect("~/Employee/CatalogueDash.aspx"); break;
                case "Employee": Response.Redirect("~/Employee/CatalogueDash.aspx"); break;
                case "Store Manager": Response.Redirect("~/Manager/StoreDashboard.aspx"); break;
                case "Store Supervisor": Response.Redirect("~/Manager/StoreDashboard.aspx"); break;
                case "Store Clerk": Response.Redirect("~/Manager/StoreDashboard.aspx"); break;
                default:  break;       
            }
        }

        protected void btnReq_Click(object sender, EventArgs e)
        {
            string s = ((Button)sender).CommandArgument;
            NotificationBL.MarkOneAsRead(Convert.ToInt32(s));

            Main master = (Main)this.Master;
            master.FillNotifications();

            switch (Session["role"])
            {
                case "Department Head": Response.Redirect("~/DepartmentHead/Submitted-Requests.aspx"); break;
                case "Delegate": Response.Redirect("~/DepartmentHead/Submitted-Requests.aspx"); break;
                case "Representative": Response.Redirect("~/Employee/RequestHistory.aspx"); break;
                case "Employee": Response.Redirect("~/Employee/RequestHistory.aspx"); break;
                case "Store Manager": Response.Redirect("~/Manager/AdjRequestHistory.aspx"); break;
                case "Store Supervisor": Response.Redirect("~/Manager/AdjRequestHistory.aspx"); break;
                case "Store Clerk": break;
                default: break;
            }
        }

        protected void btnRow_Click(object sender, EventArgs e)
        {
            string s = ((LinkButton)sender).CommandArgument;
            NotificationBL.ToggleReadNotification(Convert.ToInt32(s));

            Main master = (Main)this.Master;
            master.FillNotifications();
            PopulateNotifs();

        }
    }
}