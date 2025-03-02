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
    public partial class CRVSummary : System.Web.UI.Page
    {
        basec bc = new basec();
        PrintSummary print = new PrintSummary();
        public static string[] Array = new string[] { "","","","","", "","","" };
        W0824.Validate va = new Validate();
        string sqlth;
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
            select();
            DataTable dt = print.ask(sqlth ,Array [6],Array [7]);
            W0824.ReportManage.CRSummary oRpt = new CRSummary();
            string ul = Server.MapPath("../ReportManage/CRSummary.rpt");
            oRpt.Load(ul);
            oRpt.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = oRpt;
   
        }

        protected void select()
        {


            string v1 = Array[4];
            string v2 = Array[5];
            string v7 = Array[0];
            string v8 = Array[1];
            string v9 = Array[2];
            string v10 = Array[3];


            if (v7 != "" && v8 == "" && v9 == "" && v10 == "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE  E.CNAME LIKE '%" + v7 + "%' AND ";
            }
            else if (v7 == "" && v8 != "" && v9 == "" && v10 == "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE  D.UCID LIKE '%" + v8 + "%' AND ";
            }
            else if (v7 == "" && v8 == "" && v9 != "" && v10 == "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE  B.PLATENUM LIKE '%" + v9 + "%' AND ";
            }
            else if (v7 == "" && v8 == "" && v9 == "" && v10 != "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE  C.ENAME LIKE '%" + v10 + "%' AND ";
            }
            else if (v7 == "" && v8 == "" && v9 == "" && v10 == "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE   A. DATE BETWEEN  '" + v1 + "'AND '" + v2 + "'  AND ";
            }
            else if (v7 != "" && v8 != "" && v9 == "" && v10 == "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE  E.CNAME LIKE '%" + v7 + "%' AND D.UCID LIKE '%" + v8 +
                     "%'   AND ";
            }
            else if (v7 != "" && v8 == "" && v9 != "" && v10 == "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE  E.CNAME LIKE '%" + v7 + "%' AND  B.PLATENUM LIKE '%" + v9 + "%'  AND ";
            }
            else if (v7 != "" && v8 == "" && v9 == "" && v10 != "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE  E.CNAME LIKE '%" + v7 + "%' AND  C.ENAME LIKE '%" + v10 + "%'  AND ";
            }
            else if (v7 != "" && v8 == "" && v9 == "" && v10 == "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE  E.CNAME LIKE '%" + v7 + "%' AND A. DATE BETWEEN  '" + v1 + "'AND '" + v2 + "'  AND ";
            }
            else if (v7 == "" && v8 != "" && v9 != "" && v10 == "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE  D.UCID LIKE '%" + v8 +
                     "%' AND  B.PLATENUM LIKE '%" + v9 + "%'  AND ";
            }
            else if (v7 == "" && v8 != "" && v9 == "" && v10 != "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE  D.UCID LIKE '%" + v8 +
                     "%' AND C.ENAME LIKE '%" + v10 + "%'  AND ";
            }
            else if (v7 == "" && v8 != "" && v9 == "" && v10 == "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE  D.UCID LIKE '%" + v8 +
                     "%' AND  A. DATE BETWEEN  '" + v1 + "'AND '" + v2 + "'  AND ";
            }
            else if (v7 == "" && v8 == "" && v9 != "" && v10 != "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE  B.PLATENUM LIKE '%" + v9 + "%' AND C.ENAME LIKE '%" + v10 + "%' AND ";
            }
            else if (v7 == "" && v8 == "" && v9 != "" && v10 == "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE  B.PLATENUM LIKE '%" + v9 + "%' AND  A. DATE BETWEEN  '" + v1 + "'AND '" + v2 +
                     "' AND ";
            }
            else if (v7 == "" && v8 == "" && v9 == "" && v10 != "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE  C.ENAME LIKE '%" + v10 + "%' AND  A. DATE BETWEEN  '" + v1 + "'AND '" + v2 +
                     "' AND ";
            }
            else if (v7 != "" && v8 != "" && v9 != "" && v10 == "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE E.CNAME LIKE '%" + v7 + "%' AND D.UCID LIKE '%" + v8 +
                     "%' AND  B.PLATENUM LIKE '%" + v9 + "%' AND ";
            }
            else if (v7 != "" && v8 != "" && v9 == "" && v10 != "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE E.CNAME LIKE '%" + v7 + "%' AND D.UCID LIKE '%" + v8 +
                     "%' AND  C.ENAME LIKE '%" + v10 + "%' AND ";
            }
            else if (v7 != "" && v8 != "" && v9 == "" && v10 == "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE E.CNAME LIKE '%" + v7 + "%' AND D.UCID LIKE '%" + v8 +
                     "%' AND  A. DATE BETWEEN  '" + v1 + "'AND '" + v2 + "'   AND ";
            }
            else if (v7 != "" && v8 == "" && v9 != "" && v10 != "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE E.CNAME LIKE '%" + v7 + "%' AND B.PLATENUM LIKE '%" + v9 +
                     "%' AND C.ENAME LIKE '%" + v10 + "%' AND ";
            }
            else if (v7 != "" && v8 == "" && v9 != "" && v10 == "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE E.CNAME LIKE '%" + v7 + "%' AND B.PLATENUM LIKE '%" + v9 +
                     "%' AND A. DATE BETWEEN  '" + v1 + "'AND '" + v2 +
                     "'  AND ";
            }
            else if (v7 != "" && v8 == "" && v9 == "" && v10 != "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE E.CNAME LIKE '%" + v7 + "%' AND C.ENAME LIKE '%" + v10 +
                     "%' AND A. DATE BETWEEN  '" + v1 + "' AND  '" + v2 + "'  AND ";
            }
            else if (v7 == "" && v8 != "" && v9 != "" && v10 != "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE D.UCID LIKE '%" + v8 +
                     "%'  AND C.ENAME LIKE '%" + v10 +
                     "%' AND  B.PLATENUM LIKE '%" + v9 + "%'   AND ";
            }
            else if (v7 == "" && v8 != "" && v9 != "" && v10 == "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE D.UCID LIKE '%" + v8 +
                     "%'  AND  A. DATE BETWEEN  '" + v1 + "'AND '" + v2 +
                     "'  AND  B.PLATENUM LIKE '%" + v9 + "%'   AND ";
            }
            else if (v7 == "" && v8 == "" && v9 != "" && v10 != "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE  C.ENAME LIKE '%" + v10 + "%' AND  A. DATE BETWEEN  '" + v1 + "'AND '" + v2 +
                     "'  AND  B.PLATENUM LIKE '%" + v9 + "%'   AND ";
            }
            else if (v7 != "" && v8 != "" && v9 != "" && v10 != "" && v1 == "" && v2 == "")
            {

                sqlth = @" WHERE  E.CNAME LIKE '%" + v7 + "%' AND D.UCID LIKE '%" + v8 +
                     "%' AND  B.PLATENUM LIKE '%" + v9 + "%' AND C.ENAME LIKE '%" + v10 + "%'   AND ";
            }
            else if (v7 != "" && v8 != "" && v9 != "" && v10 == "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE   A. DATE BETWEEN  '" + v1 + "'AND '" + v2 +
                     "'  AND E.CNAME LIKE '%" + v7 + "%' AND D.UCID LIKE '%" + v8 +
                     "%' AND  B.PLATENUM LIKE '%" + v9 + "%'  AND ";
            }
            else if (v7 == "" && v8 != "" && v9 != "" && v10 != "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE  A. DATE BETWEEN  '" + v1 + "'AND '" + v2 +
                     "' AND D.UCID LIKE '%" + v8 +
                     "%' AND  B.PLATENUM LIKE '%" + v9 + "%' AND C.ENAME LIKE '%" + v10 + "%' AND ";
            }
            else if (v7 != "" && v8 != "" && v9 != "" && v10 != "" && v1 != "" && v2 != "")
            {

                sqlth = @" WHERE  A. DATE BETWEEN  '" + v1 + "'AND '" + v2 +
                     "'  AND E.CNAME LIKE '%" + v7 + "%' AND D.UCID LIKE '%" + v8 +
                     "%' AND  B.PLATENUM LIKE '%" + v9 + "%' AND C.ENAME LIKE '%" + v10 + "%' AND  ";
            }
            else
            {
                sqlth = @" WHERE";


            }


        }

    }
}
