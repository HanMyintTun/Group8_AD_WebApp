using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;
using RestSharp;

namespace Group8_AD_webapp.Controllers
{
    public class ItemCtrl
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];

        public static List<ItemVM> GetAllItems(string access_token)
        {
            RestClient restClient = new RestClient(API_Url);

            var request = new RestRequest("/Item", Method.GET);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;


            var response = restClient.Execute<List<ItemVM>>(request);
            if (response.Content == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            else if (response.Content != null)
            {
                return response.Data.ToList<ItemVM>();
            }
            else
            {
                return null;
            }

        }

        public static List<string> GetCategory(string access_token)
        {
            RestClient restClient = new RestClient(API_Url);

            var request = new RestRequest("/Item/GetCategory", Method.GET);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;
            
            var response = restClient.Execute<List<string>>(request);
            if (response.Content == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            else if (response.Content != null)
            {
                return response.Data.ToList<string>();
            }
            else
            {
                return null;
            }
        }

        public static List<ItemVM> GetFrequentList(int empId, string access_token)
        {
            RestClient restClient = new RestClient(API_Url);

            var request = new RestRequest("/Item/GetFrequentList/"+empId, Method.GET);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;
            
            var response = restClient.Execute<List<ItemVM>>(request);
            if (response.Content == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            else if (response.Content != null)
            {
                return response.Data.ToList<ItemVM>();
            }
            else
            {
                return null;
            }
        }

        // CHANGE WHEN WEBAPI up
        public static bool UpdateItems(List<ItemVM> list, string access_token)
        {
            RestClient restClient = new RestClient(API_Url);
            var jsonList = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            string payload = "list="+jsonList;
            var request = new RestRequest("/Item/UpdateItem", Method.POST);

            request.AddHeader("authorization", "Bearer " + access_token);
            request.AddParameter("application/x-www-form-urlencoded", payload, ParameterType.RequestBody);
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