using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group8_AD_webapp.Models
{
    public class ItemVM
    {
        private string _itemCode;
        private string _cat;
        private string _desc;
        private string _location;
        private string _uOM;
        private bool _isActive;
        private int _balance;
        private int _reorderLevel;
        private int _reorderQty;
        private int _tempQtyDisb;
        private int _tempQtyCheck;
        private string _suppCode1;
        private double _price1;
        private string _suppCode2;
        private double _price2;
        private string _suppCode3;
        private double _price3;

        public string ItemCode { get => _itemCode; set => _itemCode = value; }
        public string Cat { get => _cat; set => _cat = value; }
        public string Desc { get => _desc; set => _desc = value; }
        public string Location { get => _location; set => _location = value; }
        public string UOM { get => _uOM; set => _uOM = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public int Balance { get => _balance; set => _balance = value; }
        public int ReorderLevel { get => _reorderLevel; set => _reorderLevel = value; }
        public int ReorderQty { get => _reorderQty; set => _reorderQty = value; }
        public int TempQtyDisb { get => _tempQtyDisb; set => _tempQtyDisb = value; }
        public int TempQtyCheck { get => _tempQtyCheck; set => _tempQtyCheck = value; }
        public string SuppCode1 { get => _suppCode1; set => _suppCode1 = value; }
        public double Price1 { get => _price1; set => _price1 = value; }
        public string SuppCode2 { get => _suppCode2; set => _suppCode2 = value; }
        public double Price2 { get => _price2; set => _price2 = value; }
        public string SuppCode3 { get => _suppCode3; set => _suppCode3 = value; }
        public double Price3 { get => _price3; set => _price3 = value; }

        public ItemVM()
        {

        }
    }
}