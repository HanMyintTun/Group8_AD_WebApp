using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp
{
    public partial class EditSupplierPrice : System.Web.UI.Page
    {
        List<Item> items = new List<Item>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                List<String> productList = new List<String> { "Pen", "Exercise", "Folder" };
                //ddlCategory.DataSource = productList;
                //ddlCategory.DataBind();

                AddItems();
                BindGrid();

                List<String> suppliers = new List<String>();
                suppliers.Add("ALPA");
                suppliers.Add("BETA");
                suppliers.Add("GAMA");
                suppliers.Add("DLTA");

                ClearTextBoxes(this.Controls);

                foreach (GridViewRow gr in grdSupplier.Rows)
                {
                    DropDownList ddlSupplier1 = gr.FindControl("ddlSupplier1") as DropDownList;
                    ddlSupplier1.DataSource = suppliers; ;
                    ddlSupplier1.DataBind();
                    DropDownList ddlSupplier2 = gr.FindControl("ddlSupplier2") as DropDownList;
                    ddlSupplier2.DataSource = suppliers; ;
                    ddlSupplier2.DataBind();
                    DropDownList ddlSupplier3 = gr.FindControl("ddlSupplier3") as DropDownList;
                    ddlSupplier3.DataSource = suppliers; ;
                    ddlSupplier3.DataBind();

                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this.Controls);
        }

        private void ClearTextBoxes(ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                TextBox tb = ctrl as TextBox;
                if (tb != null)
                    tb.Text = "";
                else
                    ClearTextBoxes(ctrl.Controls);
            }
        }

        protected void BindGrid()
        {
            grdSupplier.DataSource = items;
            grdSupplier.DataBind();
        }

        protected void AddItems()
        {
            items.Add(new Item("A001", "Pen", "Pencil, 2B"));
            items.Add(new Item("A002", "Pen", "Pencil, HB"));
            items.Add(new Item("A003", "Pen", "Pencil, 3B"));
            items.Add(new Item("A004", "Pen", "Pencil, 4B"));
            items.Add(new Item("A005", "Pen", "Pencil, B"));
            items.Add(new Item("A006", "Exercise", "Exercise, 100pg"));
            items.Add(new Item("A007", "Exercise", "Exercise, 200pg"));
            items.Add(new Item("A008", "Exercise", "Exercise, 300pg"));
            items.Add(new Item("A009", "Exercise", "Exercise, 400pg"));
        }

        protected void grdSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSupplier.PageIndex = e.NewPageIndex;

            items = new List<Item>();
            AddItems();
            //rebind your gridview - GetSource(),Datasource of your GirdView
            BindGrid();

        }

        protected void grdSupplier_Sorting(object sender, GridViewSortEventArgs e)
        {
            items = new List<Item>();
            AddItems();

            string Sortdir = GetSortDirection(e.SortExpression);
            string SortExp = e.SortExpression;
            var list = items;
            if (Sortdir == "ASC")
            {
                list = Sort<Item>(list, SortExp, SortDirection.Ascending);
            }
            else
            {
                list = Sort<Item>(list, SortExp, SortDirection.Descending);
            }
            this.grdSupplier.DataSource = list;
            this.grdSupplier.DataBind();
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";
            string sortExpression = ViewState["SortExpression"] as string;
            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;
            return sortDirection;
        }

        public List<Item> Sort<TKey>(List<Item> list, string sortBy, SortDirection direction)
        {
            PropertyInfo property = list.GetType().GetGenericArguments()[0].GetProperty(sortBy);
            if (direction == SortDirection.Ascending)
            {
                return list.OrderBy(e => property.GetValue(e, null)).ToList<Item>();
            }
            else
            {
                return list.OrderByDescending(e => property.GetValue(e, null)).ToList<Item>();
            }
        }
    }
}