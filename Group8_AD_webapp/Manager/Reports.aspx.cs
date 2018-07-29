using Group8_AD_webapp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8AD_WebAPI.BusinessLogic;
using Newtonsoft.Json;
using System.Text;
using System.Globalization;

namespace Group8_AD_webapp
{
    public partial class Reports : System.Web.UI.Page
    {
        static List<DateTime> datesList;
        static List<DateTime> monthsList;
        static List<ReportItemVM> cbList;
        static string lbl0;
        static string lbl1;
        static string lbl2;
        static string lbl3;
        Main master;

        protected void Page_Load(object sender, EventArgs e)
        {
            master = (Main)this.Master;
            if (!IsPostBack)
            {
                Service.UtilityService.CheckRoles("Store");

                datesList = new List<DateTime>();
                monthsList = new List<DateTime>();
                cbList = new List<ReportItemVM>();
                FillDropDowns();
                DemoChart();
                lblReportTitle.Text = "Welcome";
                showlist.Visible = false;
            }


        }


        protected void DemoChart()
        {
            List<DateTime> demoList = new List<DateTime>() { new DateTime(2018, 07, 01), new DateTime(2018, 06, 01), new DateTime(2018, 05, 01) };
            lbl1 = "Claims";
            lbl2 = "Commerce";
            lbl0 = "Month";
            lbl3 = "Chargeback(SGD)";
            cbList = ReportItemBL.ShowCostReport("CLAI", "COMM", null, null, "All", demoList, true);
            lblSubtitle.Text = "Claims Department vs Commerce Department";
            lblSubtitle2.Text = "Chargeback (SGD)";
            FillDataList();
        }

        protected void FillDataList()
        {
            lstData.DataSource = cbList;
            lstData.DataBind();
            lstData.HeaderRow.Cells[0].Text = lbl0;
            lstData.HeaderRow.Cells[1].Text = lbl1+ " Department";
            lstData.HeaderRow.Cells[2].Text = lbl2+ " Department";
        }

        protected void FillDropDowns()
        {
            ddlCategory.DataSource = Controllers.ItemCtrl.GetCategory();
            ddlCategory.DataBind();

            List<SupplierVM> suppliers = SupplierBL.GetAllSupp();
            foreach (SupplierVM s in suppliers)
            {
                ddlSupplier1.Items.Add(new ListItem(s.SuppName, s.SuppCode));
                ddlSupplier2.Items.Add(new ListItem(s.SuppName, s.SuppCode));

            }

            List<DepartmentVM> departments = DepartmentBL.GetAllDept();
            foreach (DepartmentVM d in departments)
            {
                ddlDepartment1.Items.Add(new ListItem(d.DeptName, d.DeptCode));
                ddlDepartment2.Items.Add(new ListItem(d.DeptName, d.DeptCode));
            }
        }



        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            var item = (ListViewItem)btn.NamingContainer;
            Label lblMonth = (Label)item.FindControl("lblMonths");
            DateTime month = DateTime.ParseExact(lblMonth.Text, "MMM-yyyy", CultureInfo.InvariantCulture);
            monthsList.Remove(month);
            lstMonths.DataSource = monthsList;
            lstMonths.DataBind();
        }

        protected void btnMonth_Click(object sender, EventArgs e)
        {
            GenerateGraph(true);
        }

        protected void btnRange_Click(object sender, EventArgs e)
        {
            GenerateGraph(false);
        }

        protected void GenerateGraph(bool byMonth)
        {
            string cat = ddlCategory.Text;

            if (IsDept.Value == "true")
            {
                if (ddlDepartment1.SelectedValue != "0" && ddlDepartment2.SelectedValue != "0")
                {
                    string dept1 = ddlDepartment1.SelectedValue;
                    string dept2 = ddlDepartment2.SelectedValue;

                    if (dept1 != dept2)
                    {
                        if (byMonth)
                        {
                            if (monthsList.Count != 0)
                            {
                                lbl1 = (ddlDepartment1.SelectedItem.Text).Replace("Department", "");
                                lbl2 = (ddlDepartment2.SelectedItem.Text).Replace("Department", "");
                                lbl0 = "Month";
                                lbl3 = "Chargeback (SGD)";
                                cbList = ReportItemBL.ShowCostReport(dept1, dept2, null, null, cat, monthsList, byMonth);
                                FillDataList();
                                lblReportTitle.Text = "Department Cost Report for Category:" + cat;

                                lblSubtitle.Text = ddlDepartment1.SelectedItem.Text + " vs " + ddlDepartment2.SelectedItem.Text;
                                lblSubtitle2.Text = "Chargeback (SGD)";
                            }
                            else
                            {
                                master.ShowToastr(this, "", "Month List is Empty!", "error");
                            }
                        }
                        else
                        {
                            if (txtFromDate.Text != "" && txtToDate.Text != "")
                            {
                                lbl1 = (ddlDepartment1.SelectedItem.Text).Replace("Department", "");
                                lbl2 = (ddlDepartment2.SelectedItem.Text).Replace("Department", "");
                                lbl0 = "Week Of";
                                lbl3 = "Chargeback (SGD)";
                                datesList = new List<DateTime>();
                                datesList.Add(DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                                datesList.Add(DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                                cbList = ReportItemBL.ShowCostReport(dept1, dept2, null, null, cat, datesList, byMonth);
                                FillDataList();
                                lblReportTitle.Text = "Department Cost Report for Category:" + cat;
                                lblSubtitle.Text = ddlDepartment1.SelectedItem.Text + " vs " + ddlDepartment2.SelectedItem.Text;
                                lblSubtitle2.Text = "Chargeback (SGD)";
                            }
                            else
                            {
                                master.ShowToastr(this, "", "Dates cannot be Empty!", "error");
                            }
                        }
                    }
                    else
                    {
                        master.ShowToastr(this, "", "Please select 2 different departments!", "error");
                    }

                }
                else
                {
                    master.ShowToastr(this, "", "Please select 2 departments!", "error");
                }
            }
            else
            {
                if (ddlSupplier1.SelectedValue != "0" && ddlSupplier2.SelectedValue != "0")
                {
                    string supp1 = ddlSupplier1.SelectedValue;
                    string supp2 = ddlSupplier2.SelectedValue;
                    if (supp1 != supp2)
                    {
                        if (byMonth)
                        {
                            if (monthsList.Count != 0)
                            {
                                lbl1 = ddlSupplier1.SelectedItem.Text;
                                lbl2 = ddlSupplier2.SelectedItem.Text;
                                lbl0 = "Month";
                                lbl3 = "Amount Paid (SGD)";
                                cbList = ReportItemBL.ShowCostReport(null, null, supp1, supp2, cat, monthsList, byMonth);
                                FillDataList();
                                lblReportTitle.Text = "Supplier Cost Report for Category:" + cat;
                                lblSubtitle.Text = ddlSupplier1.SelectedItem.Text + " vs " + ddlSupplier2.SelectedItem.Text;
                                lblSubtitle2.Text = "Amount Paid (SGD)";
                            }
                            else
                            {
                                master.ShowToastr(this, "", "Month List is Empty!", "error");
                            }
                        }
                        else
                        {
                            if (txtFromDate.Text != "" && txtToDate.Text != "")
                            {
                                lbl1 = ddlSupplier1.SelectedItem.Text;
                                lbl2 = ddlSupplier2.SelectedItem.Text;
                                lbl0 = "Week Of";
                                lbl3 = "Amount Paid (SGD)";
                                datesList = new List<DateTime>();
                                datesList.Add(DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                                datesList.Add(DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                                cbList = ReportItemBL.ShowCostReport(null, null, supp1, supp2, cat, datesList, byMonth);
                                FillDataList();
                                lblReportTitle.Text = "Supplier Cost Report for Category:" + cat;
                                lblSubtitle.Text = ddlSupplier1.SelectedItem.Text + " vs " + ddlSupplier2.SelectedItem.Text;
                                lblSubtitle2.Text = "Amount Paid (SGD)";
                            }
                            else
                            {
                                master.ShowToastr(this, "", "Dates cannot be Empty!", "error");
                            }
                        }

                    }
                    else
                    {
                        master.ShowToastr(this, "", "Please select 2 different suppliers!", "error");
                    }
                }
                else
                {
                    master.ShowToastr(this, "", "Please select 2 suppliers!", "error");
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static List<string> getChartData()
        {
            var returnData = new List<string>();

            var chartLabel = new StringBuilder();
            var chartData = new StringBuilder();
            var chartData2 = new StringBuilder();
            chartLabel.Append("[");
            chartData.Append("[");
            chartData2.Append("[");
            for (int i = 0; i < cbList.Count; i++)
            {
                if (i < cbList.Count - 1)
                {
                    string s = (cbList[i].Label);
                    chartLabel.Append("'" + s + "', ");
                }
                else
                {
                    string s = (cbList[i].Label);
                    chartLabel.Append("'" + s + "'");
                }
            }
            for (int i = 0; i < cbList.Count; i++)
            {
                if (i < cbList.Count - 1)
                {
                    chartData.Append(cbList[i].Val1 + ", ");
                }
                else
                {
                    chartData.Append(cbList[i].Val1);
                }
            }
            for (int i = 0; i < cbList.Count; i++)
            {
                if (i < cbList.Count - 1)
                {
                    chartData2.Append(cbList[i].Val2 + ", ");
                }
                else
                {
                    chartData2.Append(cbList[i].Val2);
                }
            }
            chartData.Append("]");
            chartData2.Append("]");
            chartLabel.Append("]");

            returnData.Add(chartLabel.ToString());
            returnData.Add(chartData.ToString());
            returnData.Add(chartData2.ToString());
            returnData.Add(lbl1);
            returnData.Add(lbl2);
            returnData.Add(lbl3);
            return returnData;
        }

        protected void txtMonthPick_TextChanged(object sender, EventArgs e)
        {
            if (txtMonthPick.Text != "")
            {
                string d = txtMonthPick.Text;
                DateTime tempDate = DateTime.ParseExact(txtMonthPick.Text, "MMMM yyyy", CultureInfo.InvariantCulture);
                if (!monthsList.Contains(tempDate))
                {
                    monthsList.Add(tempDate);
                    monthsList = monthsList.OrderBy(x => x.Date).ToList();
                }
                else
                {
                    master.ShowToastr(this, "", "Month already added", "error");
                }
                txtMonthPick.Text = "";
                lstMonths.DataSource = monthsList;
                lstMonths.DataBind();

            }
            ClearChart();
        }

        protected void ClearChart()
        {
            cbList = new List<ReportItemVM>();
            lbl1 = "";
            lbl2 = "";
            lstData.DataSource = cbList;
            lstData.DataBind();
        }

        protected void OnChange(object sender, EventArgs e)
        {
            ClearChart();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            monthsList = new List<DateTime>();
            lstMonths.DataSource = monthsList;
            lstMonths.DataBind();
            ClearChart();
        }

        protected void btnBar_Click(object sender, EventArgs e)
        {
            showchart.Visible = true;
            showlist.Visible = false;
            btnList.CssClass = "listbutton";
            btnBar.CssClass = "listbutton active";

        }
        protected void btnList_Click(object sender, EventArgs e)
        {
            showchart.Visible = false;
            showlist.Visible = true;
            btnBar.CssClass = "listbutton";
            btnList.CssClass = "listbutton active";
        }
    }
}