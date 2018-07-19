using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;

namespace Group8_AD_webapp.Controllers
{
    public static class RequestCtrl
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];

        public static List<RequestVM> GetReq(int empId, string status, string access_token)
        {
            RestClient restClient = new RestClient(API_Url);
            
            var request = new RestRequest("/Request/get/?empId=" + empId + "&status=" + status, Method.POST);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;
            

            var response = restClient.Execute<List<RequestVM>>(request);
            if (response.Content == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            else if (response.Content != null)
            {
                return response.Data.ToList<RequestVM>();
            }
            else
            {
                return null;
            }

        }

        public static List<RequestVM> GetRequestByDateRange(int empId, string status, DateTime fromDate, DateTime toDate, string access_token)
        {
            RestClient restClient = new RestClient(API_Url);
            string from = fromDate.ToString("yyyy-MM-ddTHH:mm:ss");
            string to = toDate.ToString("yyyy-MM-ddTHH:mm:ss");

            string payload = "?empId=" + empId + "&status=" + status + "&fromDate=" + from
                + "&toDate=" + to;
            var request = new RestRequest("/Request/get"+payload, Method.POST);

            var response = restClient.Execute<List<RequestVM>>(request);
            if (response.Content == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            else if (response.Content != null)
            {
                return response.Data.ToList<RequestVM>();
            }
            else
            {
                return null;
            }

        }

        public static RequestVM GetRequestByReqId(int reqId, string access_token)
        {
            RestClient restClient = new RestClient(API_Url);

            var request = new RestRequest("/Request/get?reqId=" + reqId, Method.POST);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute<RequestVM>(request);
            if (response.Content == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            else if (response.Content != null)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }
    }
}