using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8_AD_webapp.Models;

namespace Group8_AD_webapp
{
    public partial class EditSupplierPrice : System.Web.UI.Page
    {
        static List<ItemVM> items = new List<ItemVM>();
        static List<ItemVM> editedItems = new List<ItemVM>();
        static string access_token;
        static List<String> suppliers;
        static bool isClear = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                suppliers = Controllers.SupplierCtrl.getSupplierCodes();
                access_token = Session["Token"].ToString();
                ddlCategory.DataSource = Controllers.ItemCtrl.GetCategory();
                ddlCategory.DataBind();

                items = Controllers.ItemCtrl.GetAllItems();
                editedItems = items.ToList();
                BindGrid();
            }
        }

        protected void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddl1 = (DropDownList)e.Row.FindControl("ddlSupplier1");
                var ddl2 = (DropDownList)e.Row.FindControl("ddlSupplier2");
                var ddl3 = (DropDownList)e.Row.FindControl("ddlSupplier3");
                ddl1.Items.Add("");
                ddl2.Items.Add("");
                ddl3.Items.Add("");
                foreach (string s in suppliers)
                {
                    ddl1.Items.Add(s);
                    ddl2.Items.Add(s);
                    ddl3.Items.Add(s);
                }
                ddl1.SelectedValue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SuppCode1"));
                ddl2.SelectedValue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SuppCode2"));
                ddl3.SelectedValue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SuppCode3"));
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void ClearTextBoxes(ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;

                if (ctrl is DropDownList)
                    ((DropDownList)ctrl).SelectedIndex = 0;
                ClearTextBoxes(ctrl.Controls);
            }
        }

        protected void BindGrid()
        {
            grdSupplier.DataSource = editedItems;
            grdSupplier.DataBind();

            int min = (grdSupplier.PageIndex) * grdSupplier.PageSize;
            int max = (min + grdSupplier.PageSize);
            if (editedItems.Count < max)
            {
                max = editedItems.Count;
            }
            lblPageCount.Text = "Showing " + (min + 1) + " to " + max + " of " + editedItems.Count.ToString();
        }

        protected void grdSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            saveList();
            grdSupplier.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void saveList()
        {
            lblPageCount.Text = "";
            foreach (GridViewRow row in grdSupplier.Rows)
            {
                int pagestart = grdSupplier.PageIndex * grdSupplier.PageSize;
                int i = pagestart + row.RowIndex;
                if (editedItems[i].ItemCode == ((Label)row.FindControl("lblItemCode")).Text)
                {
                    editedItems[i].SuppCode1 = ((DropDownList)row.FindControl("ddlSupplier1")).Text;
                    editedItems[i].SuppCode2 = ((DropDownList)row.FindControl("ddlSupplier2")).Text;
                    editedItems[i].SuppCode3 = ((DropDownList)row.FindControl("ddlSupplier3")).Text;
                    editedItems[i].Price1 = Convert.ToDouble(((TextBox)row.FindControl("txtPrice1")).Text);
                    editedItems[i].Price2 = Convert.ToDouble(((TextBox)row.FindControl("txtPrice2")).Text);
                    editedItems[i].Price3 = Convert.ToDouble(((TextBox)row.FindControl("txtPrice3")).Text);
                }
            }
        }

        //protected void grdSupplier_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    string Sortdir = GetSortDirection(e.SortExpression);
        //    string SortExp = e.SortExpression;
        //    var list = items;
        //    if (Sortdir == "ASC")
        //    {
        //        list = Sort<ItemVM>(list, SortExp, SortDirection.Ascending);
        //    }
        //    else
        //    {
        //        list = Sort<ItemVM>(list, SortExp, SortDirection.Descending);
        //    }
        //    this.grdSupplier.DataSource = list;
        //    this.grdSupplier.DataBind();
        //}

        //private string GetSortDirection(string column)
        //{
        //    string sortDirection = "ASC";
        //    string sortExpression = ViewState["SortExpression"] as string;
        //    if (sortExpression != null)
        //    {
        //        if (sortExpression == column)
        //        {
        //            string lastDirection = ViewState["SortDirection"] as string;
        //            if ((lastDirection != null) && (lastDirection == "ASC"))
        //            {
        //                sortDirection = "DESC";
        //            }
        //        }
        //    }
        //    ViewState["SortDirection"] = sortDirection;
        //    ViewState["SortExpression"] = column;
        //    return sortDirection;
        //}

        //public List<Item> Sort<TKey>(List<Item> list, string sortBy, SortDirection direction)
        //{
        //    PropertyInfo property = list.GetType().GetGenericArguments()[0].GetProperty(sortBy);
        //    if (direction == SortDirection.Ascending)
        //    {
        //        return list.OrderBy(e => property.GetValue(e, null)).ToList<Item>();
        //    }
        //    else
        //    {
        //        return list.OrderByDescending(e => property.GetValue(e, null)).ToList<Item>();
        //    }
        //}


        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void txtSearch_Changed(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            isClear = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openClearModal();", true);

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            isClear = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openClearModal();", true);
        }

        protected void btnConfirmClear_Click(object sender, EventArgs e)
        {
            if (isClear)
            {
                ClearTextBoxes(Page.Controls);
                for (int i = 0; i < editedItems.Count; i++)
                {
                    ItemVM tempitem = editedItems[i];
                    editedItems[i] = new ItemVM();
                    editedItems[i].ItemCode = tempitem.ItemCode;
                    editedItems[i].Desc = tempitem.Desc;
                }
                BindGrid();
            }
            else
            {
                string searchquery = txtSearch.Text;
                string querycat = ddlCategory.Text;
                if (querycat == "All")
                {
                    editedItems = items.Where(x => x.Desc.ToLower().Contains(searchquery)).ToList();
                }
                else
                {
                    editedItems = items.Where(x => x.Cat == querycat && x.Desc.ToLower().Contains(searchquery)).ToList();
                }
                BindGrid();
            }

        }

        protected void btnConfirmSearch_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(Page.Controls);
            for (int i = 0; i < editedItems.Count; i++)
            {
                ItemVM tempitem = editedItems[i];
                editedItems[i] = new ItemVM();
                editedItems[i].ItemCode = tempitem.ItemCode;
                editedItems[i].Desc = tempitem.Desc;
            }
            BindGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            saveList();
            lstConfirm.DataSource = editedItems;
            lstConfirm.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            
            bool success = Controllers.ItemCtrl.UpdateItems(editedItems);
            Label1.Text = success.ToString();
            if (success)
            {
                Session["Message"] = "Items Updated Successfully";
                Response.Redirect("StoreDashboard.aspx");   
            }
            else
            {
                Main master = (Main)this.Master;
                master.ShowToastr(this, String.Format("Item Changes not Submitted"), "Something Went Wrong!", "error");
            }
        }
    }
}