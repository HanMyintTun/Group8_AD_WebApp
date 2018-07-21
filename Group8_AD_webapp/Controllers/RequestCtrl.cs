using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;
using Newtonsoft.Json;

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


        public static bool SubmitRequest(int reqId, List<RequestDetailVM> reqDetList)
        {
            string access_token = "";
            RestClient restClient = new RestClient(API_Url);

            var jsonList = JsonConvert.SerializeObject(reqDetList);

            string payload = "reqId="+ reqId + "&reqDetList=" + jsonList;

            // Must add BOTH to querystring AND to Body
            var request = new RestRequest("/Request/submit?"+payload, Method.POST);

            request.AddHeader("authorization", "Bearer " + access_token);
            request.AddParameter("application/x-www-form-urlencoded", payload, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute(request);
            //return payload; //- for testing purposes
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CancelRequest(int reqId)
        {
            string access_token = "";
            RestClient restClient = new RestClient(API_Url);

            string payload = "reqId=" + reqId;

            // Must add to querystring 
            var request = new RestRequest("/Request/remove?" + payload, Method.POST);

            request.AddHeader("authorization", "Bearer " + access_token);
            //request.AddParameter("application/x-www-form-urlencoded", payload, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}