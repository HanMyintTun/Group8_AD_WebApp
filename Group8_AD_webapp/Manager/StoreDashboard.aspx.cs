using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8_AD_webapp.Models;

namespace Group8_AD_webapp
{
    public partial class StoreDashboard : System.Web.UI.Page
    {
        static List<ItemVM> volumeList;
        static DateTime d;
        static DateTime d2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["Message"] != null)
                {
                    Main master = (Main)this.Master;
                    master.ShowToastr(this, String.Format(""), (string)Session["Message"], "success");
                    Session["Message"] = null;
                }
                if (Request.QueryString["d"] != null && Request.QueryString["d2"] != null)
                {
                    d = DateTime.Parse(Request.QueryString["d"]);
                    d2 = DateTime.Parse(Request.QueryString["d2"]);
                }
                else
                {
                    d = DateTime.Today.AddYears(-1);
                    d2 = DateTime.Today;
                }

                volumeList = Controllers.TransactionCtrl.GetVolume(d,d2);
                SortAndBindGrids();
                lblDateRange.Text = "Date Range: "+d.ToString("dd-MMM-yyyy") + " to " + d2.ToString("dd-MMM-yyyy");
                PopulateCBChart();
            }
        }

        protected void PopulateCBChart()
        {
            List<ReportItemVM> cbList = Group8AD_WebAPI.BusinessLogic.ReportItemBL.GetCBMonthly(d, d2);
        }

        protected void txtMonthPick_TextChanged(object sender, EventArgs e)
        {
            string s = txtMonthPick.Text.ToString();
            d = DateTime.ParseExact(s, "MMMM yyyy", CultureInfo.InvariantCulture);
            int n = DateTime.DaysInMonth(d.Year, d.Month);
            d2 = d.AddDays(n - d.Day);
            volumeList = Controllers.TransactionCtrl.GetVolume(d,d2);
            SortAndBindGrids();
            lblDateRange.Text = "Date Range: " + d.ToString("dd-MMM-yyyy") + " to " + d2.ToString("dd-MMM-yyyy");
        }

        protected void SortAndBindGrids()
        {
            grdTopProducts.DataSource = volumeList.OrderByDescending(x => x.TempQtyReq).Take(10); 
            grdBotProducts.DataSource = volumeList.OrderBy(x => x.TempQtyReq).Take(10); 
            grdTopProducts.DataBind();
            grdBotProducts.DataBind();
        }

        protected void btnMore_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductVolume.aspx?sort=desc&d1="+ d.ToString("dd-MMM-yyyy") + "&d2="+ d2.ToString("dd-MMM-yyyy"));
        }

        protected void btnMore2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductVolume.aspx?sort=asc&d1=" + d.ToString("dd-MMM-yyyy") + "&d2=" + d2.ToString("dd-MMM-yyyy"));
        }

        [System.Web.Services.WebMethod]
        public static List<string> getChartData()
        {
            List<ItemVM> items = Controllers.ItemCtrl.GetAllItems();
            var returnData = new List<string>();
            DateTime d1 = DateTime.Today.AddYears(-1);
            DateTime d2 = DateTime.Today;
            List<ReportItemVM> cbList = Group8AD_WebAPI.BusinessLogic.ReportItemBL.GetCBMonthly(d1, d2);

            List<string> deptCodeList;
            using (SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext())
            {
                deptCodeList = entities.Departments.Select(x => x.DeptCode).ToList();
            }

            var chartLabel = new StringBuilder();
            var chartData = new StringBuilder();
            chartLabel.Append("[");
            chartData.Append("[");
            //chartLabel.Append("'CLAI', 'COMM', 'CPSC', 'ENGL', 'FINN', 'ESTS', 'REGR', 'SCIC', 'STOR', 'TREA'");
            for (int i = 0; i < 10; i++)
            {
                if (i < 9)
                {
                    chartLabel.Append("'" + cbList[i].Label + "', ");
                }
                else
                {
                    chartLabel.Append("'" + cbList[i].Label + "'");
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (i < 10)
                {
                    chartData.Append(cbList[i].Val1 + ", ");
                }
                else
                {
                    chartData.Append(cbList[i].Val1);
                }
            }
            //chartData.Append("12, 19, 3, 17, 6, 3");

            //foreach (DataRow row in dataset.Tables[0].Rows)
            //{
            //    chartLabel.Append(string.Format("'{0}',", row["Date"].ToString()));
            //    chartData.Append(string.Format("{0},", row["Qty"].ToString()));
            //}
            chartData.Append("]");
            //chartLabel.Length--; //For removing ',' 
            chartLabel.Append("]");

            returnData.Add(chartLabel.ToString());
            returnData.Add(chartData.ToString());
            return returnData;
        }
    }
}