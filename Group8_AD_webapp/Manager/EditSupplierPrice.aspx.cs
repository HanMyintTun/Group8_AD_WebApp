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
using Newtonsoft.Json;
using Group8AD_WebAPI.BusinessLogic;

namespace Group8_AD_webapp
{
    public partial class EditSupplierPrice : System.Web.UI.Page
    {
        static List<ItemVM> items = new List<ItemVM>();
        static List<ItemVM> editedItems = new List<ItemVM>();
        static List<ItemVM> submitItems = new List<ItemVM>();
        static List<String> suppliers;
        static bool isClear = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Service.UtilityService.CheckRoles("Store");

            if (!IsPostBack)
            {
                suppliers = Controllers.SupplierCtrl.getSupplierCodes();
                ddlCategory.DataSource = Controllers.ItemCtrl.GetCategory();
                ddlCategory.DataBind();

                items = Controllers.ItemCtrl.GetAllItems();
                editedItems = JsonConvert.DeserializeObject<List<ItemVM>>(JsonConvert.SerializeObject(items));

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
            if (saveList())
            {
                grdSupplier.PageIndex = e.NewPageIndex;
                BindGrid();
            }
        }

        protected bool saveList()
        {
            Main master = (Main)this.Master;
            lblPageCount.Text = "";
            foreach (GridViewRow row in grdSupplier.Rows)
            {
                int pagestart = grdSupplier.PageIndex * grdSupplier.PageSize;
                int i = pagestart + row.RowIndex;

                if(!(((TextBox)row.FindControl("txtPrice1")).Text).Any(x => !char.IsLetter(x)) ||
                    !(((TextBox)row.FindControl("txtPrice2")).Text).Any(x => !char.IsLetter(x)) ||
                    !(((TextBox)row.FindControl("txtPrice3")).Text).Any(x => !char.IsLetter(x)))
                {
                    master.ShowToastr(this, "Please enter a number", 
                        "Price for "+ ((Label)row.FindControl("lblDescription")).Text+" is blank or contains a letter", "error");
                    return false;
                }
                else
                {
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

            return true;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateEditedList();
            if (submitItems.Count != 0)
            {
                isClear = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openClearModal();", true);
            }
            else
            {
                DoSearch();
            }
        }

        protected void txtSearch_Changed(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GenerateEditedList();
            if(submitItems.Count != 0)
            {
                isClear = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openClearModal();", true);
            }
            else
            {
                DoSearch();
            }

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
                DoSearch();
            }

        }

        protected void DoSearch()
        {
            string searchquery = txtSearch.Text;
            string querycat = ddlCategory.Text;
            if (querycat == "All")
            {
                editedItems = JsonConvert.DeserializeObject<List<ItemVM>>(JsonConvert.SerializeObject(items));
                editedItems = editedItems.Where(x => x.Desc.ToLower().Contains(searchquery)).ToList();
            }
            else
            {
                editedItems = JsonConvert.DeserializeObject<List<ItemVM>>(JsonConvert.SerializeObject(items));
                editedItems = editedItems.Where(x => x.Cat == querycat && x.Desc.ToLower().Contains(searchquery)).ToList();
            }
            BindGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (saveList()) { 
            submitItems = editedItems.Where(x => x.SuppCode1 != "" && x.Price1 != 0).ToList();
            submitItems = submitItems.Where(
                x => x.SuppCode1 != items.Where(y => y.ItemCode == x.ItemCode).First().SuppCode1
                || Math.Round(Convert.ToDouble(x.Price1),2) != Math.Round(Convert.ToDouble(items.Where(y => y.ItemCode == x.ItemCode).First().Price1),2)
                || Math.Round(Convert.ToDouble(x.Price2),2) != Math.Round(Convert.ToDouble(items.Where(y => y.ItemCode == x.ItemCode).First().Price2),2)
                || Math.Round(Convert.ToDouble(x.Price3),2) != Math.Round(Convert.ToDouble(items.Where(y => y.ItemCode == x.ItemCode).First().Price3),2)
                || x.SuppCode2 != items.Where(y => y.ItemCode == x.ItemCode).First().SuppCode2
                || x.SuppCode3 != items.Where(y => y.ItemCode == x.ItemCode).First().SuppCode3
            ).ToList();
            lstConfirm.DataSource = submitItems;
            lstConfirm.DataBind();
            if(submitItems.Count == 0)
            {
                lblEmptyChange.Text = "You have not made any changes!";
                btnConfirm.Visible = false;
                submitDetail.Visible = false;
            }
            else
            {
                    lblEmptyChange.Text = "";
                    btnConfirm.Visible = true;
                submitDetail.Visible = true;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }

        protected void GenerateEditedList()
        {
            if (saveList())
            {
                submitItems = editedItems.Where(x => x.SuppCode1 != "" && x.Price1 != 0).ToList();
                submitItems = submitItems.Where(
                    x => x.SuppCode1 != items.Where(y => y.ItemCode == x.ItemCode).First().SuppCode1
                    || Math.Round(Convert.ToDouble(x.Price1), 2) != Math.Round(Convert.ToDouble(items.Where(y => y.ItemCode == x.ItemCode).First().Price1), 2)
                    || Math.Round(Convert.ToDouble(x.Price2), 2) != Math.Round(Convert.ToDouble(items.Where(y => y.ItemCode == x.ItemCode).First().Price2), 2)
                    || Math.Round(Convert.ToDouble(x.Price3), 2) != Math.Round(Convert.ToDouble(items.Where(y => y.ItemCode == x.ItemCode).First().Price3), 2)
                    || x.SuppCode2 != items.Where(y => y.ItemCode == x.ItemCode).First().SuppCode2
                    || x.SuppCode3 != items.Where(y => y.ItemCode == x.ItemCode).First().SuppCode3
                ).ToList();
            }
         }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            
            bool success = ItemBL.UpdateSuppliers(submitItems);
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