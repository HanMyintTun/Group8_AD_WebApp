using Group8_AD_webapp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp
{

    public partial class Dashboard : System.Web.UI.Page
    {
        static string access_token;
        int empId = 1;
        string deptCode = "ENGL";
        protected void Page_Load(object sender, EventArgs e)
        {


            var lastSixMonths = Enumerable.Range(0, 6).Select(i => DateTime.Now.AddMonths(i - 6).ToString("MMMM" + " yyyy", CultureInfo.InvariantCulture));
            List<string> monthslist = lastSixMonths.ToList();
            // monthslist.Sort();
            GetDeleRep();
            if (!IsPostBack)
            {
                access_token = Session["Token"].ToString();
                BindEmpDDL();

               
                ddlMonth.DataSource = monthslist;

                ddlMonth.DataBind();
            }
           
        }

        protected void GetDeleRep()
        {
            int dphId;
            int delId;
            int repId;
            DepartmentVM dept = Controllers.DepartmentCtrl.GetDept(empId, access_token);

            if (dept.DelegateApproverId == null)
            {
                txtCurDelegate.Text = "-";

            }
            else
            {
                delId = Convert.ToInt32(dept.DelegateApproverId);
                EmployeeVM empDel = Controllers.EmployeeCtrl.getEmployeebyId(delId, access_token);
                txtCurDelegate.Text = empDel.EmpName;
            }
            dphId = Convert.ToInt32(dept.DeptHeadId);
            repId = Convert.ToInt32(dept.DeptRepId);
            EmployeeVM emp = Controllers.EmployeeCtrl.getEmployeebyId(dphId, access_token);
            EmployeeVM empRep = Controllers.EmployeeCtrl.getEmployeebyId(repId, access_token);
            txtRep.Text = empRep.EmpName;
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
            Controllers.DepartmentCtrl.RemoveDelegate(deptCode, access_token);
            GetDeleRep();
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "removewarning();", true);

        }
        protected void AddDelegate(object sender, EventArgs e)
        {
            int delId = Convert.ToInt32(ddlDelegate.SelectedValue);
            string fromdate = txtFromDate.Text;
            string todate = txtToDate.Text;
            Controllers.DepartmentCtrl.SetDelegate(deptCode, fromdate, todate, delId, access_token);
            GetDeleRep();
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
        }
        protected void AddRep(object sender, EventArgs e)
        {
            int repId = Convert.ToInt32(ddlRep.SelectedValue);
            Controllers.DepartmentCtrl.SetRep(deptCode, repId, access_token);
            GetDeleRep();
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalertrep();", true);
        }

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DateTime date = DateTime.Parse(ddlMonth.SelectedItem.ToString());
        //    DateTime date2 = date.AddMonths(-3);

        //    Controllers.TransactionController.GetCBByMth(deptCode, date, date2, access_token);
        //}
        [WebMethod]
        public static string GetChart(DateTime month)
        {
            string deptCode = "COMM";
            string accesstoken = "";

            DateTime fromDate = month;
            DateTime toDate = fromDate.AddMonths(-2);
            
            List<ReportItemVM> resultlists = Controllers.TransactionController.GetCBByMth(deptCode, fromDate, toDate, accesstoken);
            List<ReportItemVM> datatodisplay = new List<ReportItemVM>();
            foreach (ReportItemVM r in resultlists)
            {
                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));

                ReportItemVM reportItemVM = new ReportItemVM();
                reportItemVM.Period = r.Period;
                reportItemVM.Label = r.Label;
                reportItemVM.Val1 = r.Val1;
                reportItemVM.Val2 = r.Val2;
                reportItemVM.color = color;
                datatodisplay.Add(reportItemVM);
            }

            var jsondata = JsonConvert.SerializeObject(datatodisplay); //Converting the Object Lists to json format

            return jsondata;
        }
    }
}