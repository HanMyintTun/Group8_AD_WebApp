using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
                

                d = DateTime.Today.AddYears(-1);
                d2 = DateTime.Today;
                volumeList = Controllers.TransactionCtrl.GetVolume(d,d2);
                SortAndBindGrids();
                lblDateRange.Text = "Date Range: "+d.ToString("dd-MMM-yyyy") + " to " + d2.ToString("dd-MMM-yyyy");
            }
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
    }
}