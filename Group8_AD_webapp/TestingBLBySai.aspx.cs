﻿using Group8_AD_webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8AD_WebAPI.BusinessLogic;
namespace Group8_AD_webapp
{
    public partial class TestingBL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ItemVM> iList = ItemBL.GetDeptDisbList(23);
                GridView1.DataSource = iList;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            //List<ItemVM> iList = ItemBL.GetDeptDisbList(23);
            //GridView1.DataSource = iList;
            //GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // GridViewRow row = GridView1.SelectedRow[0];
        }
    }
}