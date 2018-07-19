using Group8_AD_webapp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group8_AD_webapp.Controllers
{
    public class EmployeeCtrl
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];
        public static List<EmployeeVM> getEmployeeList(string access_token)
        {

            RestClient restClient = new RestClient(API_Url);

            var request = new RestRequest("/Employee", Method.GET);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute<List<EmployeeVM>>(request);

            if (response.Content == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            else if (response.Content != null)
            {
                return response.Data.ToList<EmployeeVM>();
            }
            else
            {
                return null;
            }

        }

        public static EmployeeVM getEmployeebyId(int id, string access_token)
        {

            RestClient restClient = new RestClient(API_Url);

            var request = new RestRequest("/Employee/" + id, Method.GET);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute<EmployeeVM>(request);

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