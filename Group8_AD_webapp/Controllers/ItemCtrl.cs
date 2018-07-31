﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group8_AD_webapp.Models;
using Newtonsoft.Json;
using RestSharp;
using Group8AD_WebAPI.BusinessLogic;

namespace Group8_AD_webapp.Controllers
{
    public class ItemCtrl
    {
        private static readonly string API_Url = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];

        public static List<ItemVM> GetAllItems()
        {
            return ItemBL.GetAllItems();
        }

        public static List<string> GetCategory()
        {
            return ItemBL.GetCatList();
        }

        public static List<ItemVM> GetFrequentList(int empId)
        {
            return ItemBL.GetFrequentList(empId);
        }

        public static bool UpdateSuppliers(List<ItemVM> list)
        {
            return ItemBL.UpdateSuppliers(list);
        }

        // Update When BUsiness Logic Changes
        public static bool UpdateItems(List<ItemVM> list)
        {
            ItemBL.UpdateItemLists(list);
            return true;        //  TO REPLACE
        }

        public static ItemVM GetItem(string itemCode)
        {
            return ItemBL.GetItem(itemCode);
        }
    }
}