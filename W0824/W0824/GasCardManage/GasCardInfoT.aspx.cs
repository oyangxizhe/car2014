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
    public partial class GasCardInfoT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        W0824.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        string GAKEY;
        protected string M_str_sql = @"SELECT A.GAID AS GAID,A.GASCARDID AS GASCARDID,A.CAID AS CAID,B.PLATENUM AS PLATENUM,
A.OPEN_TIME AS OPEN_TIME,A.HANDLERID AS HANDLERID,A.GAS_STATION AS GAS_STATION,A.REMARK AS REMARK,
C.GECOUNT,(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,
A.MAKERID,A.DATE,A.YEAR,A.MONTH FROM GASCARDINFO A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.GAKEY=C.GEKEY";
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

            dt = basec.getdts(M_str_sql + " where A.GAID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text1.Value = dt.Rows[0]["GAID"].ToString();
                Text2.Value = dt.Rows[0]["GASCARDID"].ToString();
                Text3.Value = bc.getOnlyString("SELECT PLATENUM FROM CARINFO WHERE CAID='" + dt.Rows[0]["CAID"].ToString() + "'");
                Text4.Value = dt.Rows[0]["GECOUNT"].ToString();
                Text5.Value = dt.Rows[0]["OPEN_TIME"].ToString();
                Text6.Value = dt.Rows[0]["HANDLERID"].ToString();
                Text7.Value = dt.Rows[0]["GAS_STATION"].ToString();
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
            Text4.Value = "0.00";
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
            TextBox1.Text = "";
            Label1.Text = "";
        }


        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM GasCardInfo", "GAID", "GA");
            if (var1 == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
                return;
            }
            Text1.Value = var1;
            Text4.Value = "0.00";
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
            string v2 = bc.getOnlyString("SELECT GASCARDID FROM GasCardINFO WHERE  GAID='" + Text1.Value + "'");
            string v3 = bc.getOnlyString("SELECT CAID FROM CARINFO WHERE  PLATENUM='" + Text3.Value + "'");
            GAKEY = bc.numYMD(20, 12, "000000000001", "select * from GASCARDINFO", "GAKEY", "GA");

            if (!juage1())
            {

            }
            else if (GAKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";

            }
            else if (!bc.exists("SELECT * FROM GasCardINFO WHERE GAID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from GasCardINFO where GASCARDID='" + Text2.Value + "'"))
                {

                    hint.Value = "该油卡号已经存在了！";

                }
                else
                {

                    
                    basec.getcoms(@"INSERT INTO GASCARDINFO(GAKEY,GAID,GASCARDID,CAID,OPEN_TIME,
HANDLERID,GAS_STATION,REMARK,MAKERID,DATE,YEAR,MONTH,DAY) VALUES ('"+GAKEY +"','" + Text1.Value + "','" + Text2.Value + "','" + v3 +
                                                                     "','" + Text5.Value + "','" + Text6.Value + "','" + Text7.Value +
 "','" + TextBox1.Text + "','" + varMakerID + "','" + varDate + "','" + year + "','" + month + "','" + day + "')");

                    basec.getcoms("INSERT INTO GODE(GEKEY,GODEID,GAID,CAID,GECOUNT,MAKERID,DATE) VALUES ('" + GAKEY +
                  "','" + Text1.Value + "','" + Text1.Value + "','" + v3 + "','" + Text4.Value + "','" + varMakerID + "','" + varDate + "')");


                    Bindo();
                }
            }
            else if (v2 != Text2.Value)
            {
                if (bc.exists("select * from GasCardINFO where GASCARDID='" + Text2.Value + "'"))
                {

                    hint.Value = "该油卡号已经存在了！";

                }
                else
                {
                    basec.getcoms(@"UPDATE GASCARDINFO SET 
GASCARDID='" + Text2.Value + "',CAID='" + v3 + "',OPEN_TIME='" + Text5.Value + "',HANDLERID='" + Text6.Value +
            "',GAS_STATION='" + Text7.Value + "',REMARK='" + TextBox1.Text + "',MAKERID='" + varMakerID +
            "',DATE='" + varDate + "' WHERE GAID='" + Text1.Value + "'");

                    basec.getcoms(@"UPDATE GODE SET GECOUNT='" + Text4.Value + "',CAID='" + v3 + "',MAKERID='" + varMakerID + "',DATE='" + varDate +
                        "' WHERE GODEID='" + Text1.Value + "' ");

    
                    Bindo();

                }

            }
            else
            {

                basec.getcoms(@"UPDATE GASCARDINFO SET 
GASCARDID='" + Text2.Value + "',CAID='" + v3 + "',OPEN_TIME='" + Text5.Value + "',HANDLERID='" + Text6.Value +
        "',GAS_STATION='" + Text7.Value + "',REMARK='" + TextBox1.Text + "',MAKERID='" + varMakerID +
        "',DATE='" + varDate + "' WHERE GAID='" + Text1.Value + "'");

                basec.getcoms(@"UPDATE GODE SET GECOUNT='" + Text4.Value + "',CAID='" + v3 + "',MAKERID='" + varMakerID + "',DATE='" + varDate +
                  "' WHERE GODEID='" + Text1.Value + "' ");

       
                Bindo();

            }



        }
        #region juage1()
        private bool juage1()
        {


            bool ju = true;
            if (!bc.checkPLATENUM(Text3.Value ))
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else  if (bc.yesno(Text4.Value) == 0)
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
            Response.Redirect("../GasCardManage/GasCardInfo.aspx" + n2);
        }
    }
}


