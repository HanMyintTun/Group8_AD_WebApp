using Group8_AD_webapp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp
{
    public partial class Submitted_Requests : System.Web.UI.Page
    {
        int rid;
        static string access_token;
        int empId = 2;
        string status = "Submitted";
        List<RequestDetailVM> showList = new List<RequestDetailVM>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                access_token = Session["Token"].ToString();
                BindGrid();
            }

        }

        //bind grid for submitted requests 
        protected void BindGrid()
        {
            List<RequestVM> requests = Controllers.RequestCtrl.GetReq(empId, status, access_token);

            List<EmpReqVM> requestlists = new List<EmpReqVM>();

            foreach (RequestVM req in requests)
            {
                EmployeeVM emp = Controllers.EmployeeCtrl.getEmployeebyId(req.EmpId, access_token);

                EmpReqVM empReq = new EmpReqVM();
                empReq.ReqId = req.ReqId;
                empReq.ReqDateTime = req.ReqDateTime;
                empReq.EmpId = req.EmpId;
                empReq.EmpName = emp.EmpName;

                requestlists.Add(empReq);

            }
            requestlists = requestlists.OrderByDescending(x => x.ReqDateTime).ToList();
            lstOrder.DataSource = requestlists;

            lstOrder.DataBind();


        }

        //populate req detail in modal
        protected void PopulateDetailList(int rid)
        {
            RequestVM req = Controllers.RequestCtrl.GetRequestByReqId(rid, access_token);
            EmployeeVM emp = Controllers.EmployeeCtrl.getEmployeebyId(req.EmpId, access_token);
            lblReqid.Text = req.ReqId.ToString();
            lblEmpName.Text = emp.EmpName.ToString();
            lblSubmitteddate.Text = req.ReqDateTime.ToString("dd'/'MM'/'yyyy");
            List<RequestDetailVM> reqDetails = Controllers.RequestDetailCtrl.GetReqDetList(rid, access_token);
            reqDetails = BusinessLogic.AddItemDescToReqDet(reqDetails);
            showList = reqDetails;
            lstShow.DataSource = showList;
            lstShow.DataBind();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);//modal popup
        }
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('Accepted request', 'Success')", true);
        }
      
        //detail buttom action 
        protected void lstOrder_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (e.CommandName == "ReqDetail")
            {
                if (e.CommandArgument.ToString() != "")
                {

                    rid = Convert.ToInt32(e.CommandArgument);

                    PopulateDetailList(rid);
                }

            }


        }
    }
}