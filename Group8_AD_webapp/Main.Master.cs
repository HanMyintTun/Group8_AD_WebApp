using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8_AD_webapp.Models;

namespace Group8_AD_webapp
{
    public partial class Main : System.Web.UI.MasterPage
    {
        static string access_token;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCart();
            }
        }

        public void ShowToastr(object sender, string message, string title, string type)
        {
            ScriptManager.RegisterStartupScript((Page)sender, sender.GetType(), "toastr_message",
            String.Format("toastr.{0}('{1}', '{2}', {{positionClass: 'toast-bottom-right'}});", type.ToLower(), message, title), true);
        }

        public void FillCart()
        {
            int empId = 31;
            RequestVM cart = Controllers.RequestCtrl.GetReq(empId, "Unsubmitted", access_token).FirstOrDefault();
            List<RequestDetailVM> cartDetailList = new List<RequestDetailVM>();

            if (cart != null)
            {
                int reqId = cart.ReqId;
                List<RequestDetailVM> reqDetails = Controllers.RequestDetailCtrl.GetReqDetList(reqId, access_token);
                reqDetails = BusinessLogic.AddItemDescToReqDet(reqDetails);
                cartDetailList = reqDetails;
                lstCart.DataSource = cartDetailList;
                lstCart.DataBind();

                lblCartCount.Text = cartDetailList.Count().ToString();
            }
            else {
                lstCart.DataSource = cartDetailList;
                lstCart.DataBind();
            }
        }

        protected void lstCart_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}