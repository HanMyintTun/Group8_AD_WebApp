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
        static int rid;
        static string access_token;
        int empId = 2;
        string status = "Submitted";
        
        EmployeeVM emp = new EmployeeVM();
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
            //List<RequestVM> requests = Controllers.RequestCtrl.GetReq(empId, status, access_token);

            //List<EmpReqVM> requestlists = new List<EmpReqVM>();

            //foreach (RequestVM req in requests)
            //{
            //    emp = Controllers.EmployeeCtrl.getEmployeebyId(req.EmpId, access_token);

            //    EmpReqVM empReq = new EmpReqVM();
            //    empReq.ReqId = req.ReqId;
            //    empReq.ReqDateTime = req.ReqDateTime;
            //    empReq.EmpId = req.EmpId;
            //    empReq.EmpName = emp.EmpName;

            //    requestlists.Add(empReq);

            //}
            //requestlists = requestlists.OrderByDescending(x => x.ReqDateTime).ToList();
            List<EmpReqVM> requestlists = BusinessLogic.GetEmpReqList(empId, status, access_token);
            lstOrder.DataSource =  requestlists;

            lstOrder.DataBind();
        }

        //populate req detail in modal
        protected void PopulateDetailList(int rid)
        {
            RequestVM req = Controllers.RequestCtrl.GetRequestByReqId(rid, access_token);
            EmployeeVM emp = Controllers.EmployeeCtrl.getEmployeebyId(req.EmpId, access_token);
            List<RequestDetailVM> showList = BusinessLogic.GetItemDetailList(rid);
            lblReqid.Text = req.ReqId.ToString();
            lblEmpName.Text = emp.EmpName.ToString();
            lblSubmitteddate.Text = req.ReqDateTime.ToString("dd'/'MM'/'yyyy");
            
            lstShow.DataSource = showList;
            lstShow.DataBind();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);//modal popup
        }
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "approvalalert();", true);
           
            AcceptReq();
           // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('toggle');", true);//modal popup
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('Accepted request', 'Success')", true);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "rejectwarning();", true);
           // AcceptReq();
           
        }

        protected void AcceptReq()
        {
            string cmt = txtComments.Text.ToString();
            RequestVM req = Controllers.RequestCtrl.GetRequestByReqId(rid, access_token);
            EmployeeVM emp = Controllers.EmployeeCtrl.getEmployeebyId(req.EmpId, access_token);
            int empId = emp.EmpId;
            Controllers.RequestCtrl.AcceptRequest(rid, empId, cmt, access_token);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('toggle');", true);
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