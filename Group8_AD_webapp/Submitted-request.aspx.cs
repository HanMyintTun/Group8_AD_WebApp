using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group8_AD_webapp
{
    public partial class Submitted_request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable oDataTable = new DataTable();
                DataColumn col1 = new DataColumn("OrderID");
                DataColumn col2 = new DataColumn("Name");
                DataColumn col3 = new DataColumn("SubmittedDate");
                DataColumn col4 = new DataColumn();
                col1.DataType = System.Type.GetType("System.Int16");
                col2.DataType = System.Type.GetType("System.String");
                col3.DataType = System.Type.GetType("System.String");

                oDataTable.Columns.Add(col1);
                oDataTable.Columns.Add(col2);
                oDataTable.Columns.Add(col3);
                oDataTable.Columns.Add(col4);


                DataRow oRow = oDataTable.NewRow();

                oRow[col1] = 1;
                oRow[col2] = "Gary";
                oRow[col3] = "13/11/2018";
                oRow[col4] = null;

                DataRow oRow1 = oDataTable.NewRow();

                oRow1[col1] = 1;
                oRow1[col2] = "Gary";
                oRow1[col3] = "13/11/2018";
                oRow1[col4] = null;
                oDataTable.Rows.Add(oRow);
                oDataTable.Rows.Add(oRow1);

                list.DataSource = oDataTable;
                list.DataBind();
              

            }
            

        }
    }
}