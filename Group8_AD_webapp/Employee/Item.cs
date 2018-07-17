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
        bool isActive;
        int reorderLevel;
        int reorderQuantity;
        string reccReorderLvl;
        double reccReorderQty;
        string suppCode1;
        double price1;
        string suppCode2;
        double price2;
        string suppCode3;
        double price3;

        public string ItemCode { get => itemCode; set => itemCode = value; }
        public string Category { get => category; set => category = value; }
        public string Description { get => description; set => description = value; }
        public int Balance { get => balance; set => balance = value; }
        public double Price { get => price; set => price = value; }
        public string Uom { get => uom; set => uom = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public int ReorderLevel { get => reorderLevel; set => reorderLevel = value; }
        public int ReorderQuantity { get => reorderQuantity; set => reorderQuantity = value; }
        public string ReccReorderLvl { get => reccReorderLvl; set => reccReorderLvl = value; }
        public double ReccReorderQty { get => reccReorderQty; set => reccReorderQty = value; }
        public string SuppCode1 { get => suppCode1; set => suppCode1 = value; }
        public double Price1 { get => price1; set => price1 = value; }
        public string SuppCode2 { get => suppCode2; set => suppCode2 = value; }
        public double Price2 { get => price2; set => price2 = value; }
        public string SuppCode3 { get => suppCode3; set => suppCode3 = value; }
        public double Price3 { get => price3; set => price3 = value; }

        public Item(string itemCode, string category, string description, int balance, double price, string uom)
        {
            ItemCode = itemCode;
            Category = category;
            Description = description;
            Balance = balance;
            Price = price;
            Uom = uom;
        }

        public Item(string itemCode, string category, string description, string supplier1, double price1, string supplier2, double price2,
            string supplier3, double price3)
        {
            ItemCode = itemCode;
            Category = category;
            Description = description;
            SuppCode1 = supplier1;
            Price1 = price1;
            SuppCode2 = supplier2;
            Price2 = price2;
            SuppCode3 = supplier3;
            Price3 = price3;
        }

        public Item(string itemCode, string category, string description)
        {
            ItemCode = itemCode;
            Category = category;
            Description = description;
        }

        public Item()
        {

        }
    }
}