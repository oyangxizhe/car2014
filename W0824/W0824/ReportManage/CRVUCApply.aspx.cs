using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using XizheC;
namespace W0824.ReportManage
{
    public partial class CRVUCApply : System.Web.UI.Page
    {
        basec bc = new basec();
        PrintUCApply print = new PrintUCApply();
        
        public static string[] Array = new string[] { "","","","","", "","","" };
        W0824.Validate va = new Validate();
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
            if (va.returnb() == true)
            Response.Redirect("../Default.aspx");  
        }
        protected void Bind()
        {
            CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.Pdf;
            SqlConnection sqlcon = bc.getcon();
            sqlcon.Open();
            string sqlth = @" where  F.UCID LIKE '%" + Array[0] + "%' ";
            DataTable dt = print.ask(sqlth);
            W0824.ReportManage.CRUCApply  oRpt =new CRUCApply();
            string ul = Server.MapPath("../ReportManage/CRVUCApply.rpt");
            oRpt.Load(ul);
            oRpt.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = oRpt;
   

        }
    }
}
