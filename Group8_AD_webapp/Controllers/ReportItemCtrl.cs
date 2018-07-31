using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;
using Newtonsoft.Json;
using RestSharp;
using Group8AD_WebAPI.BusinessLogic;

namespace Group8_AD_webapp.Controllers
{
    public class ReportItemCtrl
    {

        public static List<ReportItemVM> ShowCostReport(string dept1, string dept2, string supp1, string supp2,
            string cat, List<DateTime> dates, bool byMonth)
        {
            return ReportItemBL.ShowCostReport(dept1, dept2, supp1, supp2, cat, dates, byMonth);
        }
    }
}