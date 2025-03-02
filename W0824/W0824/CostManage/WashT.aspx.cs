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
    public partial class WashT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        W0824.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        string WAKEY;
        protected string M_str_sql = @"SELECT A.WAID AS WAID,A.CAID AS CAID,B.PLATENUM AS PLATENUM,C.DRIVERID AS DRIVERID,
D.ENAME AS DRIVER,C.Wash_UNITPRICE AS Wash_UNITPRICE,C.Wash_COUNT AS Wash_COUNT,
A.Wash_DATE AS Wash_DATE,A.HANDLERID AS HANDLERID,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLERID) AS HANDLER,
C.Wash_COUNT*C.Wash_UNITPRICE AS Wash_COST,A.REMARK AS REMARK,C.UCID AS UCID,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,
A.MAKERID,A.DATE,A.YEAR,A.MONTH FROM Wash A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.WAKEY=C.GEKEY
LEFT JOIN EMPLOYEEINFO D ON D.EMID=C.DRIVERID";
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
        protected void Bindo()
        {

            dt = basec.getdts(M_str_sql + " where A.WAID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text1.Value = dt.Rows[0]["WAID"].ToString();
                Text2.Value = dt.Rows[0]["Wash_DATE"].ToString();
                Text3.Value = dt.Rows[0]["PLATENUM"].ToString();
                Text4.Value = dt.Rows[0]["DRIVERID"].ToString();
                Text5.Value = dt.Rows[0]["Wash_COUNT"].ToString();
                Text6.Value = dt.Rows[0]["Wash_UNITPRICE"].ToString();
                Text7.Value = dt.Rows[0]["HANDLERID"].ToString();
                Label1.Text = dt.Rows[0]["HANDLER"].ToString();
                TextBox1.Text = dt.Rows[0]["REMARK"].ToString();
                string v10 = dt.Rows[0]["Wash_COST"].ToString();
                Text9.Value = string.Format("{0:F2}", Convert.ToDouble(v10));
                Text12.Value = dt.Rows[0]["UCID"].ToString();
                Label2.Text = dt.Rows[0]["DRIVER"].ToString();
            }
            else
            {

                currentdate();
                Text9.Value = "";

            }

        }
        protected void currentdate()
        {

            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            Text2.Value = DateTime.Now.ToString("yyy/MM/dd").Replace("-", "/");
            Text7.Value = varMakerID;
            Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");

        }
        protected void ClearText()
        {
            Text1.Value = "";
            Text2.Value = "";
            Text3.Value = "";
            Text4.Value = "";
            Text5.Value = "";
            Text6.Value = "";
            Text7.Value = "";
            Text9.Value = "";
            TextBox1.Text = "";
            Label1.Text = "";
            Text12.Value = "";
            Label2.Text = "";

        }


        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM Wash", "WAID", "WA");
            if (var1 == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
                return;
            }
            Text1.Value = var1;
            currentdate();
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
            string v3, v4;
            if (Text12.Value != "" && bc.checkUCID(Text12.Value))
            {
                v3 = bc.getOnlyString("SELECT CAID FROM GODE WHERE GODEID='" + Text12.Value + "'");
                v4 = bc.getOnlyString("SELECT DRIVERID FROM GODE WHERE GODEID='" + Text12.Value + "'");
            }
            else
            {
                v3 = bc.getOnlyString("SELECT CAID FROM CARINFO WHERE  PLATENUM='" + Text3.Value + "'");
                v4 = Text4.Value;
            }
            WAKEY = bc.numYMD(20, 12, "000000000001", "select * from Wash", "WAKEY", "WA");

            string s1 = bc.getOnlyString("SELECT AUDIT_STATUS FROM GODE WHERE GODEID='" + Text1.Value + "'");
            if (s1 == "Y")
            {
                hint.Value = "此单据已经审核，不允许删除或修改！";
                return;
            }
            else if (!juage1())
            {

            }
            else if (WAKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";

            }
            else if (!bc.exists("SELECT * FROM Wash WHERE WAID='" + Text1.Value + "'"))
            {



                basec.getcoms(@"INSERT INTO Wash(WAKEY,WAID,UCID,Wash_DATE,CAID,HANDLERID,REMARK,MAKERID,DATE,YEAR,MONTH,DAY) VALUES ('" + WAKEY +
                    "','" + Text1.Value + "','"+Text12.Value +"','" + Text2.Value + "','" + v3 +
"','" + Text7.Value + "','" + TextBox1.Text + "','" + varMakerID +"','" + varDate + "','" + year + "','" + month + "','" + day + "')");


                basec.getcoms("INSERT INTO GODE(GEKEY,GODEID,UCID,CAID,Wash_COUNT,Wash_UNITPRICE,MAKERID,DATE,DRIVERID) VALUES ('" + WAKEY +
              "','" + Text1.Value + "','"+Text12 .Value +"','"+v3+"','" + Text5.Value +
              "','" + Text6.Value + "','" + varMakerID + "','" + varDate + "','"+v4+"')");

                Bindo();

            }

            else
            {

                basec.getcoms(@"UPDATE Wash SET UCID='"+Text12 .Value +"',Wash_DATE='" + Text2.Value + "',CAID='" + v3 + "',HANDLERID='" + Text7.Value +
        "',REMARK='" + TextBox1.Text + "',MAKERID='" + varMakerID +
        "',DATE='" + varDate + "' WHERE WAID='" + Text1.Value + "'");

                basec.getcoms(@"UPDATE GODE SET  UCID='" + Text12.Value + "',CAID='" + v3 + "',Wash_UNITPRICE='" + Text5.Value +
                    "',Wash_COUNT='" + Text6.Value + "',MAKERID='" + varMakerID + "',DATE='" + varDate +
                  "',DRIVERID='"+v4+"' WHERE GODEID='" + Text1.Value + "' ");
                Bindo();

            }
        }
        #region juage1()
        private bool juage1()
        {


            bool ju = true;
            if (!bc.checkPLATENUM(Text3.Value))
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (!bc.checkEMID(Text4.Value))
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
            else if (!bc.checkEMID(Text7.Value))
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
            Response.Redirect("../CostManage/Wash.aspx" + n2);
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


