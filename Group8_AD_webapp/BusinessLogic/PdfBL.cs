using Group8_AD_webapp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Group8AD_WebAPI.BusinessLogic
{
    public static class PdfBL
    {
        public static string DisbursementListByDept(string templatePath)
        {
            string DeptCode = "ENGL";
            SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext();

            List<PdfVM> disbListbyDept = new List<PdfVM>();

            List<Employee> eList = entities.Employees.Where(e => e.DeptCode.Equals(DeptCode)).ToList();

            List<Request> rList = new List<Request>();
            List<RequestDetail> rdList = new List<RequestDetail>();
            foreach (Employee e in eList)
            {
                List<Request> reqList = entities.Requests.Where(r => r.EmpId == e.EmpId).ToList();
                rList.AddRange(reqList);
            }

            foreach (Request r in rList.Take(5))
            {
                List<RequestDetail> reqdList = entities.RequestDetails.Where(rd => rd.ReqId == r.ReqId).ToList();
                rdList.AddRange(reqdList);
            }

            List<Item> iList = entities.Items.ToList();

            foreach (Item i in iList)
            {
                foreach (RequestDetail rd in rdList)
                {
                    PdfVM disb = new PdfVM();
                    disb.ItemCode = i.ItemCode;
                    disb.Cat = i.Cat;
                    disb.Desc = i.Desc;
                    disb.Request_Qty = rd.ReqQty;
                    disb.DeptCode = DeptCode;
                    disb.Fulfilled_Qty = rd.FulfilledQty;
                    disbListbyDept.Add(disb);
                }
            }

            return _generateDisbursementListbyDept(disbListbyDept, templatePath);
        }

        private static string _generateDisbursementListbyDept(List<PdfVM> disbList, string filePath)
        {

            string HTML = string.Empty;
            HTML = File.ReadAllText(filePath + "DisbursementListByDept_Header.txt", System.Text.Encoding.UTF8);
            HTML = HTML.Replace("[disb-date]", DateTime.Now.Date.ToString());
            HTML = HTML.Replace("[coll-point]", disbList.Select(d => d.DeptCode).First().ToString());
            HTML = HTML.Replace("[DeptCode]", disbList.Select(d=>d.DeptCode).First().ToString());
            foreach (PdfVM dis in disbList.Take(50))
            {
               // HTML = File.ReadAllText(filePath + "DisbursementListByDept_Header.txt");
             

                HTML = string.Concat(HTML, File.ReadAllText(filePath + "DisbursementListByDept_Body.txt", System.Text.Encoding.UTF8));

                HTML = HTML.Replace("[itemcode]", dis.ItemCode);
                HTML = HTML.Replace("[item_category]", dis.Cat);
                HTML = HTML.Replace("[item_desc]", dis.Desc);
                HTML = HTML.Replace("[request_qty]", dis.Request_Qty.ToString());
                HTML = HTML.Replace("[fulfilled_qty]", dis.Fulfilled_Qty.ToString());
            
            }
            HTML = string.Concat(HTML, File.ReadAllText(filePath + "DisbursementListByDept_Footer.txt", System.Text.Encoding.UTF8));


            return HTML;
        }
    }
}