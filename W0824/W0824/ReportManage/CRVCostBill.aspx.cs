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
    public partial class CRVCostBill : System.Web.UI.Page
    {
        basec bc = new basec();
        PrintCostBill print = new PrintCostBill();
        
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
            DataTable dt = print.ask(Array[0]);
            if (Array[0].Length > 2)
            {
            
                if (Array[0].Substring(0, 2) == "AU")
                {
                    W0824.ReportManage.CRAudit oRpt = new CRAudit();
                    string ul = Server.MapPath("../ReportManage/CRAudit.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dt);
                    CrystalReportViewer1.ReportSource = oRpt;
                }
                else if (Array[0].Substring(0, 2) == "GA")
                {
                    W0824.ReportManage.CRGas  oRpt =new CRGas();
                    string ul = Server.MapPath("../ReportManage/CRGas.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dt);
                    CrystalReportViewer1.ReportSource = oRpt;
                }
                else if (Array[0].Substring(0, 2) == "IN")
                {
                    W0824.ReportManage.CRInsure oRpt = new CRInsure();
                    string ul = Server.MapPath("../ReportManage/CRInsure.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dt);
                    CrystalReportViewer1.ReportSource = oRpt;
                }
                else if (Array[0].Substring(0, 2) == "OT")
                {
                    W0824.ReportManage.CROther oRpt = new CROther();
                    string ul = Server.MapPath("../ReportManage/CRInsure.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dt);
                    CrystalReportViewer1.ReportSource = oRpt;
                }
                else if (Array[0].Substring(0, 2) == "RE")
                {
                    W0824.ReportManage.CRRepair oRpt = new CRRepair();
                    string ul = Server.MapPath("../ReportManage/CRRepair.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dt);
                    CrystalReportViewer1.ReportSource = oRpt;
                }
                else if (Array[0].Substring(0, 2) == "TO")
                {
                    W0824.ReportManage.CRToll oRpt = new CRToll();
                    string ul = Server.MapPath("../ReportManage/CRToll.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dt);
                    CrystalReportViewer1.ReportSource = oRpt;
                }
            }
          
         
   

        }
    }
}
