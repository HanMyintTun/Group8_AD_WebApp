using Group8_AD_webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp.Manager
{
    public partial class AdjRequestList : System.Web.UI.Page
    {
        List<AdjustmentVM> requests = new List<AdjustmentVM>();
        static List<RequestDetailVM> showList = new List<RequestDetailVM>();
        static List<RequestDetailVM> bookmarkList = new List<RequestDetailVM>();
        static List<RequestDetailVM> submitList = new List<RequestDetailVM>();

        static string access_token;
        static string voucherno;
       
        static string status = "";
        static public bool IsEditable = false;
        static public bool IsNotSubmitted = false;
        static public bool IsApproved = false;
        static public bool IsEmpty = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["empId"] = 42;
            int empId = (int)Session["empId"];
            access_token = Session["Token"].ToString();
            if (Request.QueryString["voucherno"] != null)
            {
                voucherno = Request.QueryString["voucherno"];
              //  AdjustmentVM adj = Controllers.AdjustmentCtrl.GetAdjByVoucher(voucherno);
                
                   // voucherno = adj.VoucherNo;
                 //   status = adj.Status;
                    //PopulateList(voucherno);
                    //BindGrids();
                    //IsEmpty = false;
               
                    //BindGrids();
                    // Custom Error Message
                
            }
           


           
        }

       
       
        protected void PopulateList(int v)
        {
            //List<RequestDetailVM> reqDetails = Controllers.RequestDetailCtrl.GetReqDetList(reqid);
            //reqDetails = BusinessLogic.AddItemDescToReqDet(reqDetails);
            //showList = reqDetails;
        }

        protected void PopulateBookmarks(int reqid)
        {
            List<RequestDetailVM> reqDetails = Controllers.RequestDetailCtrl.GetReqDetList(reqid);
            reqDetails = BusinessLogic.AddItemDescToReqDet(reqDetails);
            bookmarkList = reqDetails;
            bookmarkList = bookmarkList.OrderByDescending(x => x.ReqLineNo).ToList();
        }

        protected void BindGrids()
        {
            lstShow.DataSource = showList;
            lstShow.DataBind();

            lstBookmark.DataSource = bookmarkList;
            lstBookmark.DataBind();
        }

        protected void lstCatalogue_PagePropertiesChanged(object sender, EventArgs e)
        {
            //BindGrids();
        }

       



      
     

       
      

    }
}
