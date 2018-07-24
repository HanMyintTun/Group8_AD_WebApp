using Group8_AD_webapp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp.Manager
{
    public partial class ProductVolume : System.Web.UI.Page
    {
        static List<ItemVM> productList;

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlCategory.DataSource = Controllers.ItemCtrl.GetCategory();
            ddlCategory.DataBind();

            DateTime d1, d2;
            if (Request.QueryString["d1"] != null && Request.QueryString["d2"] != null)
            {
                d1 = DateTime.Parse(Request.QueryString["d1"]);
                d2 = DateTime.Parse(Request.QueryString["d2"]);
            }
            else
            {
                d1 = DateTime.Today.AddYears(-1);
                d2 = DateTime.Today;
            }
            productList = Controllers.TransactionCtrl.GetVolume(d1, d2);
            SortAndBindGrid();
        }

        protected void SortAndBindGrid()
        {
            if(Request.QueryString["sort"] == "desc")
            {
                productList = productList.OrderByDescending(x => x.TempQtyReq).ToList();
                lstProductVolume.DataSource = productList; 
                lstProductVolume.DataBind();
            }
            else
            {
                productList = productList.OrderBy(x => x.TempQtyReq).ToList();
                lstProductVolume.DataSource = productList; 
                lstProductVolume.DataBind();
            }

            int min = (lstProductVolume.PageIndex) * lstProductVolume.PageSize;
            int max = (min + lstProductVolume.PageSize);
            if (productList.Count < max)
            {
                max = productList.Count;
            }
            lblPageCount.Text = "Showing " + (min + 1) + " to " + max + " of " + productList.Count.ToString();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtStartDate.Text != "" && txtEndDate.Text != "")
            {
                //DoSearch();
            }
            else
            {
                //status = ddlStatus.Text;
                //requests = Controllers.RequestCtrl.GetReq(empId, status);
                //BindGrid();
            }

        }

        protected void txtMonthPick_TextChanged(object sender, EventArgs e)
        {
            //string s = txtMonthPick.Text.ToString();
            //DateTime d = DateTime.ParseExact(s, "MMMM yyyy", CultureInfo.InvariantCulture);
            //int n = DateTime.DaysInMonth(d.Year, d.Month);
            //DateTime d2 = d.AddDays(n - d.Day);
            //volumeList = Controllers.TransactionCtrl.GetVolume(d, d2);
            //SortAndBindGrids();
            //lblDateRange.Text = "Date Range: " + d.ToString("dd-MMM-yyyy") + " to " + d2.ToString("dd-MMM-yyyy");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //DoSearch();
        }

        protected void DoSearch()
        {
            //status = ddlStatus.Text.ToString();
            //if (txtStartDate.Text != "" && txtEndDate.Text != "")
            //{
            //    DateTime startDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //    DateTime endDate = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //    requests = Controllers.RequestCtrl.GetRequestByDateRange(31, status, startDate, endDate, "");

            //    BindGrid();
            //}
        }

        protected void lstProductVolume_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lstProductVolume.PageIndex = e.NewPageIndex;
            SortAndBindGrid();
        }
    }
}