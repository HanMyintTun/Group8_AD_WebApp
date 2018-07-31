using Group8_AD_webapp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8AD_WebAPI.BusinessLogic;
namespace Group8_AD_webapp.Controllers
{
    public class TransactionController
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];
        public static List<ReportItemVM> GetCBByMth(string deptCode, DateTime fromDate, DateTime toDate)
        {
            return ReportItemBL.GetCBByMth(deptCode, fromDate, toDate);
            //RestClient restClient = new RestClient(API_Url);
            ////Transaction/CBMonth?deptCode=COMM&fromDate=2017-07-18&toDate=2018-03-18
            //var request = new RestRequest("/Transaction/CBMonth?deptCode=" + deptCode+ "&fromDate=" +fromDate+ "&toDate=" +toDate, Method.POST);
            //request.AddHeader("authorization", "Bearer " + access_token);
            //request.RequestFormat = DataFormat.Json;

            //var response = restClient.Execute<List<ReportItemVM>>(request);

            //if (response.Content == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            //{
            //    return null;
            //}
            //else if (response.Content != null)
            //{
            //    return response.Data.ToList<ReportItemVM>();
            //}
            //else
            //{
            //    return null;
            //}

        }
    }
}