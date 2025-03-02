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
    public partial class GasT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        W0824.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        protected string M_str_sql = @"
SELECT A.GAID AS GAID,A.CAID AS CAID,B.PLATENUM AS PLATENUM,C.DRIVERID AS DRIVERID,
D.ENAME AS DRIVER,A.Gas_DATE AS Gas_DATE,A.Gas_STATION AS Gas_STATION,A.PAYMENT AS PAYMENT,
B.CARTYPE AS CARTYPE,
C.Gas_COST AS Gas_COST,
C.GAS_UNITPRICE AS GAS_UNITPRICE,
CASE WHEN A.PAYMENT='油库支付' THEN C.GasCARD_MRCOUNT
ELSE C.Gas_COST
END
AS AMOUNT,
C.GasCARD_MRCOUNT AS GasCARD_MRCOUNT,C.UCID AS UCID,
A.HANDLERID AS HANDLERID,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLERID) AS HANDLER,
A.REMARK AS REMARK,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,
A.MAKERID,A.DATE,A.YEAR,A.MONTH FROM Gas A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.GAKEY=C.GEKEY
LEFT JOIN EMPLOYEEINFO D ON D.EMID=C.DRIVERID

";

        string sql = @"INSERT INTO GAS(
GAKEY,
GAID,
UCID,
CAID,
Gas_DATE,
Gas_STATION,
PAYMENT,
SPEC,
HANDLERID,
REMARK,
MAKERID,
DATE,
YEAR,
MONTH,
DAY
) VALUES 

(
@GAKEY,
@GAID,
@UCID,
@CAID,
@Gas_DATE,
@Gas_STATION,
@PAYMENT,
@SPEC,
@HANDLERID,
@REMARK,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@DAY)

";
        string sql1 = @"UPDATE Gas SET 
GAID=@GAID,
UCID=@UCID,
CAID=@CAID,
GAS_DATE=@GAS_DATE,
Gas_STATION=@Gas_STATION,
PAYMENT=@PAYMENT,
SPEC=@SPEC,
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
            Text5.Value = DateTime.Now.ToString("yyy/MM/dd").Replace("-", "/");
            Text10.Value = varMakerID;
            Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");

        }
        protected void Bindo()
        {

            dt = basec.getdts(M_str_sql + " where A.GAID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {
                Text1.Value = dt.Rows[0]["GAID"].ToString();
                Text2.Value = dt.Rows[0]["PLATENUM"].ToString();
                Text3.Value = dt.Rows[0]["DRIVERID"].ToString();
                Text4.Value = dt.Rows[0]["CARTYPE"].ToString();
                Text5.Value = dt.Rows[0]["Gas_DATE"].ToString();
                Text6.Value = dt.Rows[0]["Gas_STATION"].ToString();
                DropDownList1.Text = dt.Rows[0]["PAYMENT"].ToString();
                if (dt.Rows[0]["PAYMENT"].ToString() == "油库支付")
                {
                    Text6.Value = "";
                    Text7.Value = dt.Rows[0]["GasCARD_MRCOUNT"].ToString();
                    Text8.Value = dt.Rows[0]["Gas_UNITPRICE"].ToString();
                    if (dt.Rows[0]["GasCARD_MRCOUNT"].ToString() != "" && dt.Rows[0]["Gas_UNITPRICE"].ToString()!="")
                    {
                        decimal v9 = decimal.Parse(dt.Rows[0]["GasCARD_MRCOUNT"].ToString()) * decimal.Parse(dt.Rows[0]["Gas_UNITPRICE"].ToString());
                        Text9.Value = string.Format("{0:F2}", Convert.ToDouble(v9));
                    }
                    Text11.Value = "";
                }
                else
                {
                    Text8.Value = dt.Rows[0]["GAS_UNITPRICE"].ToString();
                    Text9.Value = dt.Rows[0]["GAS_COST"].ToString();
                    if(!string.IsNullOrEmpty(dt.Rows[0]["GAS_COST"].ToString()))
                    {
                    decimal  v8 =(decimal .Parse (dt.Rows[0]["GAS_COST"].ToString()))/(decimal .Parse (dt.Rows[0]["GAS_UNITPRICE"].ToString()));
                    Text11.Value = string.Format("{0:F2}", Convert.ToDouble(v8));
                    }
                    Text7.Value = "";

                }
                Text10.Value = dt.Rows[0]["HANDLERID"].ToString();
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
            Text5.Value = "";
            Text6.Value = "";
            Text7.Value = "";
            Text8.Value = "";
            Text9.Value = "";
            Text11.Value = "";
            Text12.Value = "";
            TextBox1.Text = "";
            DropDownList1.Text = "油库支付";
            DropDownList2.Text = "93#";
            currentdate();
            Label2.Text = "";
        }
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM Gas", "GAID", "GA");
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
            string GAKEY = bc.numYMD(20, 12, "000000000001", "select * from Gas", "GAKEY", "GA");
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
            string s1 = bc.getOnlyString("SELECT AUDIT_STATUS FROM GODE WHERE GODEID='" +Text1.Value + "'");
            if (s1 == "Y")
            {
                hint.Value = "此单据已经审核，不允许删除或修改！";
                return;
            }
           else  if (!juage1())
            {

            }
            else if (GAKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";

            }
            else if (!bc.exists("SELECT GAID FROM Gas WHERE GAID='" + Text1.Value + "'"))
            {

                SQlcommandE(sql, GAKEY);
                if (DropDownList1.Text == "油库支付")
                {
                    basec.getcoms("INSERT INTO GODE(GEKEY,GODEID,UCID,CAID,GasCARD_MRCOUNT,MAKERID,DATE,DRIVERID,GAS_UNITPRICE) VALUES ('" + GAKEY +
                   "','" + Text1.Value + "','"+Text12.Value +"','" + v3 + "','" + Text7.Value +
                   "','" + varMakerID + "','" + varDate + "','"+v4 +"','"+Text8.Value +"')");
                }
                else
                {
                    basec.getcoms("INSERT INTO GODE(GEKEY,GODEID,UCID,CAID,GAS_UNITPRICE,Gas_COST,MAKERID,DATE,DRIVERID) VALUES ('" + GAKEY +
                    "','" + Text1.Value + "','"+Text12 .Value +"','" + v3 + "','" + Text8.Value + "','" + Text9.Value +
                    "','" + varMakerID + "','" + varDate + "','"+v4+"')");
                }
                Bindo();
            }
            else
            {

                SQlcommandE(sql1 + " WHERE GAID='" + Text1.Value + "'", GAKEY);
                basec.getcoms("UPDATE GODE SET GAS_UNITPRICE=NULL,Gas_COST=NULL,GasCARD_MRCOUNT=NULL WHERE GODEID='" + Text1.Value + "'");
                if (DropDownList1.Text == "油库支付")
                {

                    basec.getcoms(@"UPDATE GODE SET UCID='"+Text12 .Value +"',CAID='" + v3 + "',GasCARD_MRCOUNT='" + Text7.Value + 
                        "',MAKERID='" + varMakerID + "',DATE='" + varDate +
                     "',DRIVERID='" + v4 + "',GAS_UNITPRICE='" + Text8.Value +
                        "' WHERE GODEID='" + Text1.Value + "' ");
                }
                else
                {

                    basec.getcoms(@"UPDATE GODE SET UCID='" + Text12.Value + "',CAID='" + v3 + "',GAS_UNITPRICE='" + Text8.Value +
                        "', Gas_COST='" + Text9.Value +
                        "',MAKERID='" + varMakerID + "',DATE='" + varDate + "',DRIVERID='" + v4 + "' WHERE GODEID='" + Text1.Value + "' ");

                }
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
            string v3;
            if (Text12.Value != "" && bc.checkUCID(Text12.Value))
            {
                v3 = bc.getOnlyString("SELECT CAID FROM GODE WHERE GODEID='" + Text12.Value + "'");
            }
            else
            {
                v3 = bc.getOnlyString("SELECT CAID FROM CARINFO WHERE  PLATENUM='" + Text2.Value + "'");
            }

            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@GAKEY", SqlDbType.VarChar, 20).Value = key;
            sqlcom.Parameters.Add("@GAID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@UCID", SqlDbType.VarChar, 20).Value = Text12.Value;
            sqlcom.Parameters.Add("@CAID", SqlDbType.VarChar, 20).Value = v3;
            sqlcom.Parameters.Add("@Gas_DATE", SqlDbType.VarChar, 50).Value = Text5.Value;
            sqlcom.Parameters.Add("@Gas_STATION", SqlDbType.VarChar, 20).Value = Text6.Value;
            sqlcom.Parameters.Add("@PAYMENT", SqlDbType.VarChar, 20).Value = DropDownList1.Text;
            sqlcom.Parameters.Add("@SPEC", SqlDbType.VarChar, 20).Value = DropDownList2.Text;
            sqlcom.Parameters.Add("@HANDLERID", SqlDbType.VarChar, 20).Value = Text10.Value;
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
            string v1 = bc.getOnlyString(@"SELECT B.PLATENUM FROM TOLLCARDINFO A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID WHERE A.TOLLCARDID='" + Text7.Value + "'");
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
            else if (DropDownList1.Text == "现金支付" & Text6.Value == "")
            {
                ju = false;
                hint.Value = "选择现金支付时加油站不能为空！！";
            }
       
            else if (DropDownList1.Text == "油库支付" & Text7.Value == "")
            {
                ju = false;
                hint.Value = "选择油库支付时油库加油量不能为空！";

            }
   
            else if (bc.yesno(Text7.Value) == 0)
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (Text8.Value == "")
            {
                ju = false;
                hint.Value = "单价不能为空！！";
            }
            else if (bc.yesno(Text8.Value) == 0)
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (DropDownList1.Text == "现金支付" & Text9.Value == "")
            {
                ju = false;
                hint.Value = "选择现金支付时金额不能为空！！";
            }
            else if (bc.yesno(Text9.Value) == 0)
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (!bc.checkEMID(Text10.Value))
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (Text12.Value !="" && !bc.checkUCID (Text12 .Value ))
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
            Response.Redirect("../CostManage/Gas.aspx" + n2);
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
