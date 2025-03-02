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




namespace W0824.TollCardManage
{
    public partial class TollCardAddFundsT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        W0824.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        protected string M_str_sql = @"SELECT A.TFID AS TFID,A.TCID AS TCID,C.TollCARDID AS TollCARDID,B.PLATENUM AS PLATENUM,
A.ADDFUNDSDATE AS ADDFUNDSDATE,A.HANDLERID AS HANDLERID,A.REMARK AS REMARK,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,
A.MAKERID,A.DATE,A.YEAR,A.MONTH,D.TOLLCARD_GECOUNT FROM TollCARDADDFUNDS A 
LEFT JOIN TollCARDINFO C ON A.TCID=C.TCID
LEFT JOIN CARINFO B ON C.CAID=B.CAID
LEFT JOIN GODE D ON A.TFKEY=D.GEKEY";
        string TFKEY;
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

            dt = basec.getdts(M_str_sql + " where A.TFID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text1.Value = dt.Rows[0]["TFID"].ToString();
                Text2.Value = dt.Rows[0]["TollCARDID"].ToString();
                Text3.Value = dt.Rows[0]["PLATENUM"].ToString();
                Text4.Value = dt.Rows[0]["TOLLCARD_GECOUNT"].ToString();
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
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM TollCardAddFunds", "TFID", "TF");
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
            string v2 = bc.getOnlyString("SELECT TCID FROM TollCARDINFO WHERE  TollCARDID='" + Text2.Value + "'");
            string v3 = bc.getOnlyString("SELECT CAID FROM TollCARDINFO WHERE  TollCARDID='" + Text2.Value + "'");
            TFKEY = bc.numYMD(20, 12, "000000000001", "select * from TollCARDADDFUNDS", "TFKEY", "TF");

            if (!juage1())
            {

            }
            else if (TFKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";

            }
            else if (!bc.exists("SELECT * FROM TollCARDADDFUNDS WHERE TFID='" + Text1.Value + "'"))
            {

                basec.getcoms(@"INSERT INTO TollCARDADDFUNDS(TFKEY,TFID,TCID,ADDFUNDSDATE,
HANDLERID,REMARK,MAKERID,DATE,YEAR,MONTH,DAY) VALUES ('" + TFKEY + "','" + Text1.Value + "','" + v2 +
                             "','" + Text5.Value + "','" + Text6.Value +
                   "','" + TextBox1.Text + "','" + varMakerID + "','" + varDate + "','" + year + "','" + month + "','" + day + "')");

                basec.getcoms("INSERT INTO GODE(GEKEY,GODEID,TCID,CAID,TOLLCARD_GECOUNT,MAKERID,DATE) VALUES ('" + TFKEY +
              "','" + Text1.Value + "','" + v2 + "','"+v3+"','" + Text4.Value + "','" + varMakerID + "','" + varDate + "')");

                Bindo();
            }
            else
            {

                basec.getcoms(@"UPDATE TollCARDADDFUNDS SET 
TCID='" + v2 + "',ADDFUNDSDATE='" + Text5.Value + "',HANDLERID='" + Text6.Value +
        "',REMARK='" + TextBox1.Text + "',MAKERID='" + varMakerID +
        "',DATE='" + varDate + "' WHERE TFID='" + Text1.Value + "'");

                basec.getcoms(@"UPDATE GODE SET TOLLCARD_GECOUNT='" + Text4.Value + "',TCID='" + v2 + "',CAID='"+v3+"',MAKERID='" + varMakerID +
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
            else if (!bc.checkTOLLCARDID(Text2.Value))
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
            Response.Redirect("../TollCardManage/TollCardAddFunds.aspx" + n2);
        }


    }
}


