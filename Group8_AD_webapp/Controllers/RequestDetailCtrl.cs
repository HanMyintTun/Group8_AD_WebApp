﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;
using RestSharp;

namespace Group8_AD_webapp.Controllers
{
    public class RequestDetailCtrl
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];

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

        // NOT TESTED
        public static bool AddBookmark(int empId, string itemCode, string access_token)
        {
            //AddReqDet(empId, reqDet, “Bookmarked”)
            RestClient restClient = new RestClient(API_Url);

            string payload = "empId" + empId + "&ItemCode=" + itemCode + "&Status=Bookmarked";
            var request = new RestRequest("/RequestDetail/addReqDet", Method.POST);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("application/x-www-form-urlencoded", payload, ParameterType.RequestBody);
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

        // NOT TESTED
        public static bool AddToCart(int empId, string itemCode, int reqQty, string access_token)
        {
            //AddReqDet(empId, reqDet, “Bookmarked”)
            RestClient restClient = new RestClient(API_Url);

            string payload = "empId" + empId + "&ItemCode=" + itemCode + "&ReqQty=" + reqQty + "&Status=Unsubmitted";
            var request = new RestRequest("/RequestDetail/addReqDet", Method.POST);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("application/x-www-form-urlencoded", payload, ParameterType.RequestBody);
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