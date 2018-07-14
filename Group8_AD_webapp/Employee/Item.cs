using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group8_AD_webapp
{
    public class Item
    {
        string itemCode;
        string category;
        string description;
        int balance;
        double price;
        string uom;

        public string ItemCode { get => itemCode; set => itemCode = value; }
        public string Category { get => category; set => category = value; }
        public string Description { get => description; set => description = value; }
        public int Balance { get => balance; set => balance = value; }
        public double Price { get => price; set => price = value; }
        public string Uom { get => uom; set => uom = value; }
        
        public Item(string itemCode, string category, string description, int balance, double price, string uom)
        {
            ItemCode = itemCode;
            Category = category;
            Description = description;
            Balance = balance;
            Price = price;
            Uom = uom;
        }
    }
}