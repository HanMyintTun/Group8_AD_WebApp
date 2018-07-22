using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;

namespace Group8_AD_webapp
{
    public static class BusinessLogic
    {
        static string access_token;

        public static List<RequestDetailVM> AddItemDescToReqDet(List<RequestDetailVM> list)
        {
            List<ItemVM> items = Controllers.ItemCtrl.GetAllItems();
            foreach(RequestDetailVM req in list)
            {
                req.Desc = (items.Where(x => x.ItemCode == req.ItemCode).FirstOrDefault()).Desc;
            }
            return list;
        }
    }
}