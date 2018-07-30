using Group8_AD_webapp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp
{
    public partial class ProductVolume : System.Web.UI.Page
    {
        static List<ItemVM> staticpList;
        static List<ItemVM> productList;
        static DateTime d1;
        static DateTime d2;

        protected void Page_Load(object sender, EventArgs e)
        {
            Service.UtilityService.CheckRoles("Store");

            if (!IsPostBack)
            {
                ddlCategory.DataSource = Controllers.ItemCtrl.GetCategory();
                ddlCategory.DataBind();

                if (Request.QueryString["sort"] == "asc")
                {
                    IsDesc.Value = "false";
                }
                else
                {
                    IsDesc.Value = "true";
                    ddlSortDirection.SelectedValue = "desc";
                }
                
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
                staticpList = Controllers.TransactionCtrl.GetVolume(d1, d2);
                foreach(ItemVM i in staticpList)
                {
                    i.Price1 = Math.Round(i.Price1, 2);
                }

                productList = new List<ItemVM>(staticpList);
                SortAndBindGrid();
            }

        }

        protected void SortAndBindGrid()
        {
            if (IsDesc.Value == "true")
            {
                lstProductVolume.DataSource = productList;
                lstProductVolume.DataBind();
            }
            else
            {
                lstProductVolume.DataSource = productList;
                lstProductVolume.DataBind();
            }

            int min = (lstProductVolume.PageIndex) * lstProductVolume.PageSize;
            int max = (min + lstProductVolume.PageSize);
            if (productList.Count < max)
            {
                max = productList.Count;
            }
            lblDateRange.Text = "Date Range: " + d1.ToString("dd-MMM-yyyy") + " to " + d2.ToString("dd-MMM-yyyy");
        }


        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch_Click(btnSearch, EventArgs.Empty);
        }

        protected List<ItemVM> DoSearch()
        {
            d1 = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            d2 = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (d2.CompareTo(d1) >= 0 )
            {
                return Controllers.TransactionCtrl.GetVolume(d1, d2);
            }
            else
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, "", "End Date must be after Start Date", "error");
                return new List<ItemVM>();
            }

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string cat = ddlCategory.Text;
            if (txtStartDate.Text != "" && txtEndDate.Text != "")
            {
                if (cat == "All")
                {
                    productList = DoSearch();
                }
                else
                {
                    List<ItemVM> searchList = DoSearch();
                    productList = searchList.Where(x => x.Cat == cat).ToList();
                }
                SortAndBindGrid();
            }
            else
            {
                if (cat == "All")
                {
                    productList = new List<ItemVM>(staticpList);
                }
                else
                {
                    productList = staticpList.Where(x => x.Cat == cat).ToList();
                }
                SortAndBindGrid();
            }
        }

        protected void ddlSortDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sort = ddlSortDirection.SelectedValue;
            if (sort == "asc")
            {
                IsDesc.Value = "false";
                SortAndBindGrid();
            }
            else
            {
                IsDesc.Value = "true";
                SortAndBindGrid();
            }
        }
        

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["d1"] != null && Request.QueryString["d2"] != null)
            {
                d1 = DateTime.Parse(Request.QueryString["d1"]);
                d2 = DateTime.Parse(Request.QueryString["d2"]);
            }

            Response.Redirect("StoreDashboard.aspx?d=" + d1.ToString("dd-MMM-yyyy") + "&d2=" + d2.ToString("dd-MMM-yyyy"));
        }
    }
}