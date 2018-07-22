using Group8_AD_webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp
{
    
    public partial class Dashboard : System.Web.UI.Page
    {
        static string access_token;
        int empId = 2;
        string deptCode = "CPSC";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                access_token = Session["Token"].ToString();
                BindEmpDDL();
                GetDeleRep();

            }
            
        }

        protected void GetDeleRep()
        {
            int dphId;
            int delId;
            int repId;
            DepartmentVM dept = Controllers.DepartmentCtrl.GetDept(empId, access_token);

            if (!dept.DelegateApproverId.Equals(null) || !dept.DeptRepId.Equals(null))
            {
                dphId = Convert.ToInt32(dept.DeptHeadId);
                delId = Convert.ToInt32(dept.DelegateApproverId);
                repId = Convert.ToInt32(dept.DeptRepId);
                EmployeeVM emp = Controllers.EmployeeCtrl.getEmployeebyId(dphId, access_token);
                EmployeeVM empDel = Controllers.EmployeeCtrl.getEmployeebyId(delId, access_token);
                EmployeeVM empRep = Controllers.EmployeeCtrl.getEmployeebyId(repId, access_token);
                txtCurDelegate.Text = empDel.EmpName;
                txtRep.Text = empRep.EmpName;
            }
            else 
            {
                txtCurDelegate.Text = "-";
                txtRep.Text = "-";
            }

        }


        protected void BindEmpDDL()
        {

            ddlRep.DataSource = Controllers.EmployeeCtrl.getEmployeeList(access_token);
            ddlRep.DataTextField = "empName";
            ddlRep.DataValueField = "empId";
            ddlRep.DataBind();
            ddlDelegate.DataSource = Controllers.EmployeeCtrl.getEmployeeList(access_token);
            ddlDelegate.DataTextField = "empName";
            ddlDelegate.DataValueField = "empId";
            ddlDelegate.DataBind();
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