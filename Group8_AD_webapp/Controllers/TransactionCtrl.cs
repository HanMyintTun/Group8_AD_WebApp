using Group8_AD_webapp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group8_AD_webapp.Controllers
{
    public class TransactionCtrl
    {
        public static List<ItemVM> GetVolume(DateTime fromDate, DateTime toDate)
        {
            string from = fromDate.ToString("yyyy-MM-ddTHH:mm:ss");
            string to = toDate.ToString("yyyy-MM-ddTHH:mm:ss");

            string querystring = "?fromDate=" + from + "&toDate=" + to;
            string jsonResponse = Service.UtilityService.SendPostRequest("/Transaction/getVolume", querystring, "", true);

            if (jsonResponse != "false")
            {
                var response = JsonConvert.DeserializeObject<List<ItemVM>>(jsonResponse);
                return (List<ItemVM>)response;
            }
            else return null;
        }
    }
}