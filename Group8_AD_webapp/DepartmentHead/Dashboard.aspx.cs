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
using Group8AD_WebAPI.BusinessLogic;

namespace Group8_AD_webapp
{

    public partial class Dashboard : System.Web.UI.Page
    {
        int empId = 1;
        string deptCode = "ENGL";
        protected void Page_Load(object sender, EventArgs e)
        {


            var lastSixMonths = Enumerable.Range(0, 6).Select(i => DateTime.Now.AddMonths(i - 6).ToString("MMMM" + " yyyy", CultureInfo.InvariantCulture)).Reverse();
            List<string> monthslist = lastSixMonths.ToList();
            // monthslist.Sort
            GetDeleRep();
            if (!IsPostBack)
            {
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
            DepartmentVM dept = DepartmentBL.GetDept(empId);

            if (dept.DelegateApproverId == null)
            {
                txtCurDelegate.Text = "-";

            }
            else
            {
                delId = Convert.ToInt32(dept.DelegateApproverId);
                EmployeeVM empDel = Controllers.EmployeeCtrl.getEmployeebyId(delId);
                txtCurDelegate.Text = empDel.EmpName;
                lblCurrentDel.Text = txtCurDelegate.Text.ToString();
            }
            dphId = Convert.ToInt32(dept.DeptHeadId);
            repId = Convert.ToInt32(dept.DeptRepId);
            EmployeeVM emp = Controllers.EmployeeCtrl.getEmployeebyId(dphId);
            EmployeeVM empRep = Controllers.EmployeeCtrl.getEmployeebyId(repId);
            txtRep.Text = empRep.EmpName;
        }


        protected void BindEmpDDL()
        {
            DepartmentVM dp = DepartmentBL.GetDept(empId);
            List<EmployeeVM> replist = Controllers.EmployeeCtrl.getEmployeeList().Where(x => x.DeptCode == deptCode && x.Role != "Department Head" && x.EmpId != dp.DelegateApproverId).ToList();
            List<EmployeeVM> delist = Controllers.EmployeeCtrl.getEmployeeList().Where(x => x.DeptCode == deptCode && x.Role != "Department Head" && x.EmpId != dp.DeptRepId).ToList();
            ddlRep.DataSource = replist;
            ddlRep.DataTextField = "empName";
            ddlRep.DataValueField = "empId";
            ddlRep.DataBind();
            ddlDelegate.DataSource = delist;
            ddlDelegate.DataTextField = "empName";
            ddlDelegate.DataValueField = "empId";
            ddlDelegate.DataBind();
        }
        protected void RemoveDelegate(object sender, EventArgs e)
        {
            GetDeleRep();
            if (txtCurDelegate.Text == "-")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "removeemptydelwarning();", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlDeleRemove').modal();", true);//modal popup
            }




            //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "removewarning();", true);

        }
        protected void AddDelegate(object sender, EventArgs e)
        {
            //if (!ddlDelegate.SelectedValue.Equals(0)||!ddlDelegate.SelectedValue.Equals("0") && !txtFromDate.Text.Equals(null)||!txtFromDate.Text.Equals("") && !txtToDate.Text.Equals(null)||!txtToDate.Text.Equals(""))
            if(ddlDelegate.SelectedItem.Text != "Select Employee" && txtFromDate.Text != "" && txtToDate.Text!="")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlDeleSet').modal();", true);//modal popup
            }
           


        }
        protected void AddRep(object sender, EventArgs e)
        {
            if (ddlDelegate.SelectedItem.Text != "Select Employee")
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlRepSet').modal();", true);
            }
           
        }


        protected void btnRemovDelYes_Click(object sender, EventArgs e)
        {


            bool success = DepartmentBL.removeDelegate(deptCode);

            if (success)
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Current delegate has been successfully removed!"), "Successfully Removed!", "success");
                GetDeleRep();
            }
            else
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Current delegate changes not Submitted"), "Something Went Wrong!", "error");
            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlDeleRemove').modal('toggle');", true);//modal popup
        }

        protected void btnRemovDelNo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlConfirm').modal('toggle');", true);//modal popup
        }

        protected void btnSetDelYes_Click(object sender, EventArgs e)
        {
            int delId = Convert.ToInt32(ddlDelegate.SelectedValue);
            DateTime fromdate = DateTime.Parse(txtFromDate.Text);
            DateTime todate = DateTime.Parse(txtToDate.Text);
           
            bool success = DepartmentBL.setDelegate(deptCode, fromdate, todate, delId);

            if (success)
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Delegate has been successfully added!"), "Successfully Added!", "success");
                GetDeleRep();
            }
            else
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Current delegate changes not Submitted"), "Something Went Wrong!", "error");
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlRepSet').modal('toggle');", true);//modal popup
        }
        protected void btnSetDelNo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlRepSet').modal('toggle');", true);//modal popup
        }
        protected void btnSetRepYes_Click(object sender, EventArgs e)
        {
            int repId = Convert.ToInt32(ddlRep.SelectedValue);

            bool success = DepartmentBL.setRep(deptCode, repId);

            if (success)
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Representative has been successfully added!"), "Successfully added!", "success");
                GetDeleRep();
            }
            else
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Representative changes not Submitted"), "Something Went Wrong!", "error");
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlDeleSet').modal('toggle');", true);//modal popup
        }
        protected void btnSetRepNo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#mdlDeleSet').modal('toggle');", true);//modal popup
        }

        [WebMethod]
        public static string GetChart(DateTime month)
        {
            string deptCode = "COMM";
            DateTime fromDate = month;
            DateTime toDate = fromDate.AddMonths(-2);

            List<ReportItemVM> resultlists = ReportItemBL.GetCBByMth(deptCode, fromDate, toDate);
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