using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Group8_AD_webapp.Controllers
{
    public class ItemCtrl
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];

        public static List<ItemVM> GetAllItems()
        {
            string jsonResponse = Service.UtilityService.SendGetRequest("/Item", "", true);
            if (jsonResponse != "false")
            {
                var response = JsonConvert.DeserializeObject<List<ItemVM>>(jsonResponse);
                return response;
            }
            else return null;
        }

        public static List<string> GetCategory()
        {
            string jsonResponse = Service.UtilityService.SendGetRequest("/Item/GetCategory", "", true);
            if (jsonResponse != "false")
            {
                var response = JsonConvert.DeserializeObject<List<string>>(jsonResponse);
                return response;
            }
            else return null;
        }

        public static List<ItemVM> GetFrequentList(int empId)
        {
            string querystring = "/" + empId;
            string jsonResponse = Service.UtilityService.SendGetRequest("/Item/GetFrequentList", querystring, true);
            if (jsonResponse != "false")
            {
                var response = JsonConvert.DeserializeObject<List<ItemVM>>(jsonResponse);
                return response;
            }
            else return null;
        }

        // CHANGE WHEN WEBAPI up
        public static bool UpdateItems(List<ItemVM> list)
        {
            var jsonList = JsonConvert.SerializeObject(list);
            string jsonResponse = Service.UtilityService.SendPostRequest("/Item/UpdateItem", "", jsonList, false);
            return Convert.ToBoolean(jsonResponse);
        }
    }
}