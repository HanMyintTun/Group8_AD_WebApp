using Group8_AD_webapp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8AD_WebAPI.BusinessLogic;
namespace Group8_AD_webapp.Controllers
{
    public class DepartmentCtrl
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];
        public static DepartmentVM GetDept(int empId)
        {
            return DepartmentBL.GetDept(empId);
        }

        public static List<DepartmentVM> GetAllDept()
        {
                List<DepartmentVM> departments = DepartmentBL.GetAllDept();
                return departments.Where(x => x.DeptName != "Store Department").ToList();
        }


        public static bool RemoveDelegate(string deptCode)
        {

            return DepartmentBL.removeDelegate(deptCode);
          
            //RestClient restClient = new RestClient(API_Url);
            //// Must add to querystring 
            //var request = new RestRequest("/Department/removeDelegate/" + deptCode, Method.POST);

            //request.AddHeader("authorization", "Bearer " + access_token);
            ////request.AddParameter("application/x-www-form-urlencoded", payload, ParameterType.RequestBody);
            //request.RequestFormat = DataFormat.Json;

            //var response = restClient.Execute(request);
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        public static bool SetRep(string deptCode, int empId)
        {
            return DepartmentBL.setRep(deptCode, empId);
            //RestClient restClient = new RestClient(API_Url);
            //// Must add to querystring 
            //var request = new RestRequest("/Department/setRep?deptCode=" + deptCode +"&empID="+ empId, Method.POST);

            //request.AddHeader("authorization", "Bearer " + access_token);
            ////request.AddParameter("application/x-www-form-urlencoded", payload, ParameterType.RequestBody);
            //request.RequestFormat = DataFormat.Json;

            //var response = restClient.Execute(request);
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public static bool SetDelegate(string deptCode, DateTime fromDate, DateTime toDate, int empId, string access_token)
        {

            return DepartmentBL.setDelegate(deptCode, fromDate, toDate, empId);
            //RestClient restClient = new RestClient(API_Url);
            
            //var request = new RestRequest("/Department/setDelegate?deptCode=" +deptCode+ "&fromDate="+fromDate+ "&toDate=" +toDate+ "&empId=" +empId, Method.POST);

            //request.AddHeader("authorization", "Bearer " + access_token);
            ////request.AddUrlSegment("deptCode", deptCode);
            ////request.AddUrlSegment("fromDate", fromDate);
            ////request.AddUrlSegment("toDate", toDate);
            ////request.AddUrlSegment("empId", empId);
            //request.RequestFormat = DataFormat.Json;

            //var response = restClient.Execute(request);
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

    }
}