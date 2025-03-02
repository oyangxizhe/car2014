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




namespace W0824.GasCardManage
{
    public partial class GasCardAddFundsT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        W0824.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        protected string M_str_sql = @"SELECT A.GFID AS GFID,A.GAID AS GAID,C.GASCARDID AS GASCARDID,B.PLATENUM AS PLATENUM,
A.ADDFUNDSDATE AS ADDFUNDSDATE,A.HANDLERID AS HANDLERID,A.REMARK AS REMARK,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,
A.MAKERID,A.DATE,A.YEAR,A.MONTH,D.GECOUNT FROM GASCARDADDFUNDS A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GASCARDINFO C ON A.GAID=C.GAID
LEFT JOIN GODE D ON A.GFKEY=D.GEKEY";
        string GFKEY;
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

            dt = basec.getdts(M_str_sql + " where A.GFID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text1.Value = dt.Rows[0]["GFID"].ToString();
                Text2.Value = dt.Rows[0]["GASCARDID"].ToString();
                Text3.Value = dt.Rows[0]["PLATENUM"].ToString();
                Text4.Value = dt.Rows[0]["GECOUNT"].ToString();
                Text5.Value = dt.Rows[0]["ADDFUNDSDATE"].ToString();
                Text6.Value = dt.Rows[0]["HANDLERID"].ToString();
                Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + dt.Rows[0]["HANDLERID"].ToString() + "'");
                TextBox1.Text = dt.Rows[0]["REMARK"].ToString();
            }
            else
            {

                currentdate();
            }
        }
        protected void currentdate()
        {

            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            Text5.Value = DateTime.Now.ToString("yyy/MM/dd").Replace("-", "/");
            Text6.Value = varMakerID;
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
            TextBox1.Text = "";
        }


        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM GasCardAddFunds", "GFID", "GF");
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
            string v2 = bc.getOnlyString("SELECT GAID FROM GASCARDINFO WHERE  GASCARDID='" + Text2.Value + "'");
            string v3 = bc.getOnlyString("SELECT CAID FROM CARINFO WHERE  PLATENUM='" + Text3.Value + "'");
            GFKEY = bc.numYMD(20, 12, "000000000001", "select * from GASCARDADDFUNDS", "GFKEY", "GF");

            if (!juage1())
            {

            }
            else if (GFKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";

            }
            else if (!bc.exists("SELECT * FROM GASCARDADDFUNDS WHERE GFID='" + Text1.Value + "'"))
            {
              
                    basec.getcoms(@"INSERT INTO GASCARDADDFUNDS(GFKEY,GFID,GAID,CAID,ADDFUNDSDATE,
HANDLERID,REMARK,MAKERID,DATE,YEAR,MONTH,DAY) VALUES ('" + GFKEY + "','" + Text1.Value + "','" + v2 + "','" + v3 +
                                 "','" + Text5.Value + "','" + Text6.Value +
                       "','" + TextBox1.Text + "','" + varMakerID + "','" + varDate + "','" + year + "','" + month + "','" + day + "')");

                    basec.getcoms("INSERT INTO GODE(GEKEY,GODEID,GAID,CAID,GECOUNT,MAKERID,DATE) VALUES ('" + GFKEY +
                  "','" + Text1.Value + "','" + v2+ "','" + v3 + "','" + Text4.Value + "','" + varMakerID + "','" + varDate + "')");

                    Bindo();
            }
            else
            {

                basec.getcoms(@"UPDATE GASCARDADDFUNDS SET 
GAID='" + v2 + "',CAID='" + v3 + "',ADDFUNDSDATE='" + Text5.Value + "',HANDLERID='" + Text6.Value +
        "',REMARK='" + TextBox1.Text + "',MAKERID='" + varMakerID +
        "',DATE='" + varDate + "' WHERE GFID='" + Text1.Value + "'");

                basec.getcoms(@"UPDATE GODE SET GECOUNT='" + Text4.Value + "',GAID='"+v2+"',CAID='" + v3 + "',MAKERID='" + varMakerID +
                    "',DATE='" + varDate +
                  "' WHERE GODEID='" + Text1.Value + "' ");
                Bindo();

            }
        }
        #region juage1()
        private bool juage1()
        {


            bool ju = true;
            if (Text2.Value == "")
            {
                ju = false;
                hint.Value = "卡号不能为空！";

            }
            else  if (!bc.checkGASCARDID(Text2.Value))
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
             
            else if (!bc.checkPLATENUM(Text3.Value))
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (bc.yesno(Text4.Value) == 0)
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }

            else if (!bc.checkEMID(Text6.Value))
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
            Response.Redirect("../GasCardManage/GasCardAddFunds.aspx" + n2);
        }


    }
}


