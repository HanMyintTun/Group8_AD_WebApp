using System;
using System.Collections.Generic;
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
            List<NotificationVM> notifs = NotificationBL.GetNotifications((int)Session["empId"]);
            notifs.ForEach(x => x.FromEmpName = (EmployeeBL.GetEmp(x.FromEmp) as EmployeeVM).EmpName);
            lstFullNof.DataSource = notifs;
            lstFullNof.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}