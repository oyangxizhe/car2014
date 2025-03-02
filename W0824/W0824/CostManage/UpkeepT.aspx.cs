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
    public partial class UpkeepT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        W0824.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        protected string M_str_sql = @"SELECT A.UPID AS UPID,A.CAID AS CAID,B.PLATENUM AS PLATENUM,C.DRIVERID AS DRIVERID,
D.ENAME AS DRIVER,A.Upkeep_DATE AS Upkeep_DATE,
B.CARTYPE AS CARTYPE,C.Upkeep_COST AS Upkeep_COST,A.VKT AS VKT,
A.HANDLERID AS HANDLERID,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLERID) AS HANDLER,
A.REMARK AS REMARK,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,
A.MAKERID,A.DATE,A.YEAR,A.MONTH FROM Upkeep A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.UPKEY=C.GEKEY
LEFT JOIN EMPLOYEEINFO D ON D.EMID=C.DRIVERID";

        string sql = @"INSERT INTO Upkeep(
UPKEY,
UPID,
CAID,
VKT,
Upkeep_DATE,
HANDLERID,
REMARK,
MAKERID,
DATE,
YEAR,
MONTH,
DAY
) VALUES 

(
@UPKEY,
@UPID,
@CAID,
@VKT,
@Upkeep_DATE,
@HANDLERID,
@REMARK,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@DAY)

";
        string sql1 = @"UPDATE Upkeep SET 
UPID=@UPID,
CAID=@CAID,
VKT=@VKT,
Upkeep_DATE=@Upkeep_DATE,
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

            dt = basec.getdts(M_str_sql + " where UPID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {
                Text1.Value = dt.Rows[0]["UPID"].ToString();
                Text2.Value = dt.Rows[0]["PLATENUM"].ToString();
                Text3.Value = dt.Rows[0]["DRIVERID"].ToString();
                Text4.Value = dt.Rows[0]["CARTYPE"].ToString();
                Text5.Value = dt.Rows[0]["VKT"].ToString();
                Text6.Value = dt.Rows[0]["Upkeep_COST"].ToString();
                Text7.Value = dt.Rows[0]["Upkeep_DATE"].ToString();
                Text9.Value = dt.Rows[0]["HANDLERID"].ToString();
                Label1.Text = dt.Rows[0]["HANDLER"].ToString();
                TextBox1.Text = dt.Rows[0]["REMARK"].ToString();
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
            Text5.Value = "";
            Text6.Value = "";
            Text7.Value = "";
            Text9.Value = "";
            TextBox1.Text = "";
            currentdate();
            Label2.Text = "";
        }


        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM Upkeep", "UPID", "UP");
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
            string UPKEY = bc.numYMD(20, 12, "000000000001", "select * from Upkeep", "UPKEY", "UP");
            string v3 = bc.getOnlyString("SELECT CAID FROM CARINFO WHERE  PLATENUM='" + Text2.Value + "'");
            string s1 = bc.getOnlyString("SELECT AUDIT_STATUS FROM GODE WHERE GODEID='" + Text1.Value + "'");
            if (s1 == "Y")
            {
                hint.Value = "此单据已经审核，不允许删除或修改！";
                return;
            }
            else if (!juage1())
            {

            }
            else if (UPKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";

            }
            else if (!bc.exists("SELECT UPID FROM Upkeep WHERE UPID='" + Text1.Value + "'"))
            {

                SQlcommandE(sql, UPKEY);
                basec.getcoms("INSERT INTO GODE(GEKEY,GODEID,CAID,Upkeep_COST,MAKERID,DATE,DRIVERID) VALUES ('" + UPKEY +
                "','" + Text1.Value + "','"+v3+"','" + Text6.Value + "','" + varMakerID + "','" + varDate + "','"+Text3.Value +"')");
                Bindo();
            }
            else
            {

                SQlcommandE(sql1 + " WHERE UPID='" + Text1.Value + "'", UPKEY);
                basec.getcoms(@"UPDATE GODE SET CAID='"+v3+"',Upkeep_COST='" + Text6.Value + "',MAKERID='" + varMakerID + "',DATE='" + varDate +
                 "',DRIVERID='"+Text3.Value +"' WHERE GODEID='" + Text1.Value + "' ");
                Bindo();
            }
        }
        #region SQlcommandE
        protected void SQlcommandE(string sql, string key)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            string v3 = bc.getOnlyString("SELECT CAID FROM CARINFO WHERE  PLATENUM='" + Text2.Value + "'");

            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@UPKEY", SqlDbType.VarChar, 20).Value = key;
            sqlcom.Parameters.Add("@UPID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@CAID", SqlDbType.VarChar, 20).Value = v3;
            sqlcom.Parameters.Add("@VKT", SqlDbType.VarChar, 50).Value = Text5.Value;
            sqlcom.Parameters.Add("@Upkeep_DATE", SqlDbType.VarChar, 20).Value = Text7.Value;
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
            else if (bc.yesno(Text5.Value) == 0)
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
            return ju;
        }
        #endregion
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../CostManage/Upkeep.aspx" + n2);
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
            hint.Value = "";
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            basec.getcoms("UPDATE GODE SET AUDIT_STATUS='Y',AUDIT_MAKERID='" + varMakerID +
                "',AUDIT_DATE='" + varDate + "' WHERE GODEID='" + Text1.Value + "'");
            Bindo();
        }

        protected void btnReductionReconcile_Click(object sender, EventArgs e)
        {
            string s1 = bc.getOnlyString("SELECT AUDIT_STATUS FROM GODE WHERE GODEID='" + Text1.Value + "'");
            try
            {
                if (s1 != "Y")
                {
                    hint.Value = "状态不为已审核，不能做撤审";
                }
                else
                {
                    basec.getcoms("UPDATE GODE SET AUDIT_STATUS=NULL,AUDIT_MAKERID=NULL ,AUDIT_DATE=NULL WHERE GODEID='" + Text1.Value + "'");
                    Bindo();
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
