using Group8_AD_webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group8AD_WebAPI.BusinessLogic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string pdfpath = Server.MapPath("~/PDF/");
            string filename = "DisbursementListByDepartment_" + DateTime.Now.ToString("yyyMMddHHmmss") + ".pdf";
            String templatepath = Server.MapPath("~/Report_Templates/");
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);          

            string HTML = PdfBL.DisbursementListByDept(templatepath);

            Panel p = new Panel();
            p.Controls.Add(new LiteralControl(HTML));
            p.RenderControl(hw);

            //PdfPTable pdfPTable = new PdfPTable(5);
            //pdfPTable.WidthPercentage = 100;
            //pdfPTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            //pdfPTable.DefaultCell.BorderWidth = 1;

            //int[] widths = new int[] { 15, 20, 35, 15, 15 };
            //pdfPTable.SetWidths(widths);

            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
           // Document pdfDoc = new Document(PageSize.A4);

            pdfDoc.SetMargins(50, 50, 50, 50);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, new FileStream(pdfpath+filename, FileMode.Create));
            pdfDoc.Open();

            htmlparser.Parse(sr);
            pdfDoc.Close();
        }
    }
}