using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Group8_AD_webapp.Controllers
{
    public class RequestDetailCtrl
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];

        //superseded by below
        public static List<RequestDetailVM> GetReqDetList(int reqId, string access_token)
        {
            RestClient restClient = new RestClient(API_Url);

            var request = new RestRequest("/RequestDetail/GetReqDetList/" + reqId, Method.GET);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;


            var response = restClient.Execute<List<RequestDetailVM>>(request);
            if (response.Content == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            else if (response.Content != null)
            {
                return response.Data.ToList<RequestDetailVM>();
            }
            else
            {
                return null;
            }
        }

        public static List<RequestDetailVM> GetReqDetList(int reqId)
        {
            string querystring = "/" + reqId;
                string jsonResponse = Service.UtilityService.SendGetRequest("/RequestDetail/GetReqDetList", querystring, true);

            if (jsonResponse != "false")
            {
                var response = JsonConvert.DeserializeObject<List<RequestDetailVM>>(jsonResponse);
                return response;
            }
            else return null;
        }

        public static bool AddBookmark(int empId, string itemCode)
        {
            string querystring = "?empId=" + empId + "&ItemCode=" + itemCode + "&ReqQty=1&Status=Bookmarked";
            string jsonResponse = Service.UtilityService.SendPostRequest("/RequestDetail/addReqDet", querystring, "", false);
            return Convert.ToBoolean(jsonResponse);
        }

        public static bool AddToCart(int empId, string itemCode, int reqQty)
        {
            string querystring = "?empId=" + empId + "&ItemCode=" + itemCode + "&ReqQty="+reqQty+"&Status=Unsubmitted";
            string jsonResponse = Service.UtilityService.SendPostRequest("/RequestDetail/addReqDet", querystring, "", false);
            return Convert.ToBoolean(jsonResponse);
        }

        public static bool RemoveReqDet(int reqId, string itemCode, string access_token)
        {
            string querystring = "?ReqId=" + reqId + "&ItemCode=" + itemCode;
            string jsonResponse = Service.UtilityService.SendPostRequest("/RequestDetail/removeReqDet", querystring, "",false);
            return Convert.ToBoolean(jsonResponse);
        }

    }
}