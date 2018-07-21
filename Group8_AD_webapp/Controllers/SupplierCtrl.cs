using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;
using RestSharp;

namespace Group8_AD_webapp.Controllers
{
    public class SupplierCtrl
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];

        public static List<string> getSupplierCodes(string access_token)
        {

            RestClient restClient = new RestClient(API_Url);

            var request = new RestRequest("/Supplier", Method.GET);
            request.AddHeader("authorization", "Bearer " + access_token);
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute<List<SupplierVM>>(request);

            if (response.Content == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            else if (response.Content != null)
            {
                List<SupplierVM> suppList = response.Data.ToList<SupplierVM>();
                List<string> suppCodeList = new List<string>();
                foreach (SupplierVM s in suppList)
                {
                    suppCodeList.Add(s.SuppCode);
                }
                return suppCodeList;
            }
            else
            {
                return null;
            }

        }
    }
}