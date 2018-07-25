using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8_AD_webapp.Models;
using System.Web.UI.HtmlControls;

namespace Group8_AD_webapp
{
    public partial class Main : System.Web.UI.MasterPage
    {
        static string access_token;
        public static List<RequestDetailVM> cartDetailList = new List<RequestDetailVM>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                SetProfile();
                FillCart();
                PopulateMenuItems();
            }
        }

        protected void SetProfile()
        {
            if(Session["empId"] != null)
            {
                int empId = (int)Session["empId"];

                //if (File.Exists(Server.MapPath("~/img/employee/" + empId + ".png")))
                //{
                    imgProfile.Src = "~/img/employee/" + empId + ".png";
                //}
                //else
                //{
                //    imgProfile.Src = "~/img/employee/profile_default.png";
                //}

                lblName.Text = (string)Session["empName"];
                lblRole.Text = (string)Session["role"];
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }

        }

        protected void PopulateMenuItems()
        {
            List<HtmlGenericControl> deptHeadList = new List<HtmlGenericControl>() { menuDeptHeadDash, menuDeptHeadRequest };
            List<HtmlGenericControl> employeeList = new List<HtmlGenericControl>() { menuCatalogueDash, menuEmployeeRequest };
            List<HtmlGenericControl> storeList = new List<HtmlGenericControl>() { menuManagerDash, menuProductVol, menuRestock, menuSuppliers };
            List<HtmlGenericControl> managerList = new List<HtmlGenericControl>() { menuManagerDash, menuProductVol, menuRestock, menuSuppliers, menuAdjustment };
            List<HtmlGenericControl> allMenu = new List<HtmlGenericControl>();
            allMenu.AddRange(deptHeadList);
            allMenu.AddRange(employeeList);
            allMenu.AddRange(storeList);
            allMenu.AddRange(managerList);
            foreach (HtmlGenericControl m in allMenu)
            {
                m.Visible = false;
            }

            switch (Session["role"])
            {
                case "Department Head":
                        foreach (HtmlGenericControl m in deptHeadList)  m.Visible = true; break; 
                case "Delegate":
                    foreach (HtmlGenericControl m in deptHeadList) m.Visible = true; break;
                case "Representative":
                    foreach (HtmlGenericControl m in employeeList) m.Visible = true; break;
                case "Employee":
                    foreach (HtmlGenericControl m in employeeList) m.Visible = true; break;
                case "Store Manager":
                    foreach (HtmlGenericControl m in managerList) m.Visible = true; break;
                case "Store Supervisor":
                    foreach (HtmlGenericControl m in managerList) m.Visible = true; break;
                case "Store Clerk":
                    foreach (HtmlGenericControl m in storeList) m.Visible = true; break;
                default:  break;
            }
        }

        public void ShowToastr(object sender, string message, string title, string type)
        {
            ScriptManager.RegisterStartupScript((Page)sender, sender.GetType(), "toastr_message",
            String.Format("toastr.{0}('{1}', '{2}', {{positionClass: 'toast-bottom-right'}});", type.ToLower(), message, title), true);
        }

        public void FillCart()
        {
            int empId = (int)Session["empId"];
            RequestVM cart = Controllers.RequestCtrl.GetReq(empId, "Unsubmitted").FirstOrDefault();
            
            if (cart != null)
            {
                int reqId = cart.ReqId;
                List<RequestDetailVM> reqDetails = Controllers.RequestDetailCtrl.GetReqDetList(reqId);
                reqDetails = BusinessLogic.AddItemDescToReqDet(reqDetails);
                cartDetailList = reqDetails;
                lstCart.DataSource = cartDetailList;
                lstCart.DataBind();
                UpdateCartCount();

            }
            else {
                cartDetailList = new List<RequestDetailVM>();
                lstCart.DataSource = cartDetailList;
                lstCart.DataBind();
            }
        }

        public void UpdateCartCount()
        {
            int cartCount = 0;
            foreach(RequestDetailVM item in cartDetailList)
            {
                cartCount += item.ReqQty;
            }

            lblCartCount.Text = cartCount.ToString();
        }

        protected void lstCart_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Home.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {

            int empId = (int)Session["empId"];
            RequestVM unsubRequest = Controllers.RequestCtrl.GetReq(empId, "Unsubmitted").FirstOrDefault();
            Main master = this;
            if (unsubRequest != null)
            {
                if (cartDetailList.Count != 0)
                {
                    Response.Redirect("~/Employee/RequestList.aspx");
                }

            }
        }

    }
}