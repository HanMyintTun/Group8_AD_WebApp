using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp.Manager
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtToGrid = new DataTable();
               
                dtToGrid.Columns.Add("date", typeof(string));
               

                Session["dtToGrid"] = dtToGrid;

            }
        }
        
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            DataTable dtToGrid = (DataTable)Session["dtToGrid"];

            DataRow drToGrid = dtToGrid.NewRow();

            drToGrid["date"] = txtDate.Text.Trim();
           

            dtToGrid.Rows.Add(drToGrid);

            ItemsGrid.DataSource = dtToGrid;
            ItemsGrid.DataBind();
          


        }
        protected void ItemGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt1 = (DataTable)Session["Remove"];
            // DataTable dt = new DataTable();
            if (dt1.Rows.Count > 0)
            {
                dt1.Rows[e.RowIndex].Delete();
                ItemsGrid.DataSource = dt1;
                ItemsGrid.DataBind();
            }
        }

    }
}