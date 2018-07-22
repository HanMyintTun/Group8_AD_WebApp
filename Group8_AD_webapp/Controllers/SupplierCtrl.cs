using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Group8_AD_webapp.Controllers
{
    public class SupplierCtrl
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];

        public static List<string> getSupplierCodes()
        {
            string jsonResponse = Service.UtilityService.SendGetRequest("/Supplier", "", true);

            if (jsonResponse != "false")
            {
                var response = JsonConvert.DeserializeObject<List<SupplierVM>>(jsonResponse);
                if (response != null)
                {
                    List<string> suppCodeList = new List<string>();
                    foreach (SupplierVM s in response)
                    {
                        suppCodeList.Add(s.SuppCode);
                    }
                    return suppCodeList;
                }
                return null;
            }
            else return null;
        }
    }
}