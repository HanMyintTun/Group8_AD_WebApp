using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;
using Group8AD_WebAPI.BusinessLogic;

namespace Group8_AD_webapp.Service
{
    public class UtilityService
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];

        public static string SendGetRequest(string route, string querystring, bool needContent)
        {
            string access_token = (string)System.Web.HttpContext.Current.Session["access_token"];
            RestClient restClient = new RestClient(API_Url);

            var request = new RestRequest(route + querystring, Method.GET);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (needContent)
                {
                    return response.Content;
                }
                else
                {
                    return "true";
                }
            }
            else
            {
                return "false";
            }
        }

        public static string SendPostRequest(string route, string querystring, string jsonObject, bool needContent)
        {
            string access_token = (string)System.Web.HttpContext.Current.Session["access_token"];
            RestClient restClient = new RestClient(API_Url);

            var request = new RestRequest(route + querystring, Method.POST);
            request.AddHeader("authorization", "Bearer " + access_token);
            if (jsonObject != "") { request.AddParameter("text/json", jsonObject, ParameterType.RequestBody); }
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (needContent)
                {
                    return response.Content;
                }
                else
                {
                    return "true";
                }
            }
            else
            {
                return "false";
            }
        }

        public static bool Authenticate(int empId, string password)
        {
            // CALL Authentication here


            EmployeeVM emp = EmployeeBL.GetEmp(empId);
            if(emp == null)
            {
                return false;
            }
            else
            {
                HttpContext.Current.Session["empId"] = empId;
                HttpContext.Current.Session["empName"] = emp.EmpName;
                if (emp.Role == "Employee")
                {
                    DepartmentVM dep = DepartmentBL.GetDept(empId);
                    if (dep.DelegateApproverId == empId)
                    {
                        HttpContext.Current.Session["role"] = "Delegate";
                    }
                    else if (dep.DeptRepId == empId)
                    {
                        HttpContext.Current.Session["role"] = "Representative";
                    }
                    else
                    {
                        HttpContext.Current.Session["role"] = "Employee";
                    }
                }
                else
                {
                    HttpContext.Current.Session["role"] = emp.Role;
                }

                return true;
            }
            
        }
    }
}