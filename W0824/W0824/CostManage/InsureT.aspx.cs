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
using XizheC;




namespace W0824.CostManage
{
    public partial class InsureT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        W0824.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        protected string M_str_sql = @"
SELECT A.INID AS INID,A.CAID AS CAID,B.PLATENUM AS PLATENUM,C.DRIVERID AS DRIVERID,
D.ENAME AS DRIVER,B.CARTYPE AS CARTYPE,C.INSURE_COST AS INSURE_COST,A.INSUDF AS INSUDF,
A.HANDLERID AS HANDLERID,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLERID) AS HANDLER,
A.REMARK AS REMARK,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,C.UCID AS UCID,
A.MAKERID,A.DATE,A.YEAR,A.MONTH FROM INSURE A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.INKEY=C.GEKEY
LEFT JOIN EMPLOYEEINFO D ON D.EMID=C.DRIVERID
";

        string sql = @"INSERT INTO Insure(
INKEY,
INID,
UCID,
CAID,
INSUDF,
HANDLERID,
REMARK,
MAKERID,
DATE,
YEAR,
MONTH,
DAY
) VALUES 

(
@INKEY,
@INID,
@UCID,
@CAID,
@INSUDF,
@HANDLERID,
@REMARK,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@DAY)

";
        string sql1 = @"UPDATE Insure SET 
UCID=@UCID,
INID=@INID,
CAID=@CAID,
INSUDF=@INSUDF,
HANDLERID=@HANDLERID,
REMARK=@REMARK,
MAKERID=@MAKERID,
DATE=@DATE
";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Bind();
            }

            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
        }
        protected void Bind()
        {

            hint.Value = "";
            if (str1[0] != "")
            {
                Text1.Value = str1[0];
                str1[0] = "";
            }
            else
            {

                Text1.Value = strE[0];
                strE[0] = "";

            }
            Bindo();

        }
        protected void currentdate()
        {

            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            Text7.Value = DateTime.Now.ToString("yyy/MM/dd").Replace("-", "/");
          
            Text9.Value = varMakerID;
            Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
        
        }
        protected void Bindo()
        {

            dt = basec.getdts(M_str_sql +" where INID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {
                Text1.Value = dt.Rows[0]["INID"].ToString();
                Text2.Value = dt.Rows[0]["PLATENUM"].ToString();
                Text3.Value = dt.Rows[0]["DRIVERID"].ToString();
                Text4.Value = dt.Rows[0]["CARTYPE"].ToString();
                Text6.Value = dt.Rows[0]["INSURE_COST"].ToString();
                Text7.Value = dt.Rows[0]["INSUDF"].ToString();
                Text9.Value = dt.Rows[0]["HANDLERID"].ToString();
                Label1.Text = dt.Rows[0]["HANDLER"].ToString();
                TextBox1.Text = dt.Rows[0]["REMARK"].ToString();
                Text12.Value = dt.Rows[0]["UCID"].ToString();
                Label2.Text = dt.Rows[0]["DRIVER"].ToString();
            }
            else
            {
                currentdate();
            }
            string s1 = bc.getOnlyString("SELECT AUDIT_STATUS FROM GODE WHERE GODEID='" + Text1.Value + "'");
            if (s1 == "Y")
            {

              

            }
            else
            {

             

            }

        }
        protected void ClearText()
        {
            Text2.Value = "";
            Text3.Value = "";
            Text4.Value = "";
            Text6.Value = "";
            Text7.Value = "";
            Text9.Value = "";
            TextBox1.Text = "";
            Text12.Value = "";
            currentdate();
            Label2.Text = "";
        }


        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM Insure", "INID", "IN");
            if (var1 == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
                return;
            }
            Text1.Value = var1;
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
           
            try
            {
                save();
            }
            catch (Exception)
            {

            }

        }
        protected void save()
        {

            hint.Value = "";
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            string INKEY = bc.numYMD(20, 12, "000000000001", "select * from INSURE", "INKEY", "IN");
            string v3, v4;
            if (Text12.Value != "" && bc.checkUCID(Text12.Value))
            {
                v3 = bc.getOnlyString("SELECT CAID FROM GODE WHERE GODEID='" + Text12.Value + "'");
                v4 = bc.getOnlyString("SELECT DRIVERID FROM GODE WHERE GODEID='" + Text12.Value + "'");
            }
            else
            {
                v3 = bc.getOnlyString("SELECT CAID FROM CARINFO WHERE  PLATENUM='" + Text2.Value + "'");
                v4 = Text3.Value;
            }
            string s1 = bc.getOnlyString("SELECT AUDIT_STATUS FROM GODE WHERE GODEID='" + Text1.Value + "'");
            if (s1 == "Y")
            {
                hint.Value = "此单据已经审核，不允许删除或修改！";
                return;
            }
            else if (!juage1())
            {

            }
            else if (INKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";

            }
            else if (!bc.exists("SELECT INID FROM Insure WHERE INID='" + Text1.Value + "'"))
            {
             
                    SQlcommandE(sql);
                    basec.getcoms("INSERT INTO GODE(GEKEY,GODEID,UCID,CAID,INSURE_COST,MAKERID,DATE,DRIVERID) VALUES ('" + INKEY +
                    "','" + Text1.Value + "','"+Text12.Value +"','"+v3 +"','" + Text6.Value + 
                    "','" + varMakerID + "','" + varDate + "','"+v4+"')");
                    Bindo();
            }
            else
            {

                SQlcommandE(sql1 + " WHERE INID='" + Text1.Value + "'");
                basec.getcoms(@"UPDATE GODE SET UCID='" + Text12.Value + "',CAID='" + v3 + 
                    "',INSURE_COST='" + Text6.Value + "',MAKERID='" + varMakerID + "',DATE='" + varDate +
                 "',DRIVERID='"+v4 +"' WHERE GODEID='" + Text1.Value + "' ");
                Bindo();
            }
        }
        #region SQlcommandE
        protected void SQlcommandE(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            string v3;
            if (Text12.Value != "" && bc.checkUCID(Text12.Value))
            {
                v3 = bc.getOnlyString("SELECT CAID FROM GODE WHERE GODEID='" + Text12.Value + "'");
            }
            else
            {
                v3 = bc.getOnlyString("SELECT CAID FROM CARINFO WHERE  PLATENUM='" + Text2.Value + "'");
            }
            string INKEY = bc.numYMD(20, 12, "000000000001", "select * from INSURE", "INKEY", "IN");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@INKEY", SqlDbType.VarChar, 20).Value = INKEY;
            sqlcom.Parameters.Add("@INID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@UCID", SqlDbType.VarChar, 20).Value = Text12.Value;
            sqlcom.Parameters.Add("@CAID", SqlDbType.VarChar, 20).Value = v3;
            sqlcom.Parameters.Add("@INSUDF", SqlDbType.VarChar, 20).Value = Text7.Value;
            sqlcom.Parameters.Add("@HANDLERID", SqlDbType.VarChar, 20).Value = Text9.Value;
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 1000).Value = TextBox1.Text;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        #region juage1()
        private bool juage1()
        {
            bool ju = true;
            if (!bc.checkPLATENUM(Text2.Value))
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (!bc.checkEMID(Text3.Value))
            {
                ju = false;
                hint.Value = bc.ErrowInfo;
            }
            else if (bc.yesno(Text6.Value) == 0)
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (!bc.checkEMID(Text9.Value))
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (Text12.Value != "" && !bc.checkUCID(Text12.Value))
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            return ju;
        }
        #endregion
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../CostManage/Insure.aspx" + n2);
        }

        protected void btnReconcile_Click(object sender, EventArgs e)
        {

            try
            {
                reconcile();
            }
            catch (Exception)
            {

            }
        }
        protected void reconcile()
        {
           
        }

        protected void btnReductionReconcile_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                print();
                //excel();
            }
            catch (Exception)
            {


            }

        }
        protected void print()
        {

            String[] Carstr = new string[] { Text1.Value };
            W0824.ReportManage.CRVCostBill.Array = Carstr;
            Response.Redirect("../ReportManage/CRVCostBill.aspx");
        }
    }
}
