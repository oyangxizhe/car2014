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
    public partial class TollTA : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        W0824.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        protected string M_str_sql = @"
SELECT A.TOID AS TOID,A.CAID AS CAID,B.PLATENUM AS PLATENUM,C.DRIVERID AS DRIVERID,
D.ENAME AS DRIVER,A.Toll_DATE AS Toll_DATE,A.TOLL_PLACE AS TOLL_PLACE,A.PAYMENT AS PAYMENT,
B.CARTYPE AS CARTYPE,
C.TOLL AS TOLL,
CASE WHEN A.PAYMENT='路卡支付' THEN C.TOLLCARD_MRCOUNT
ELSE C.Toll
END
AS AMOUNT,
E.TOLLCARDID AS TOLLCARDID,
C.TOLLCARD_MRCOUNT AS TOLLCARD_MRCOUNT,
A.HANDLERID AS HANDLERID,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLERID) AS HANDLER,
A.REMARK AS REMARK,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,C.UCID AS UCID,
A.MAKERID,A.DATE,A.YEAR,A.MONTH FROM Toll A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.TOKEY=C.GEKEY
LEFT JOIN EMPLOYEEINFO D ON D.EMID=C.DRIVERID
LEFT JOIN TOLLCARDINFO E ON C.TCID=E.TCID

";

        string sql = @"INSERT INTO Toll(
TOKEY,
TOID,
UCID,
CAID,
Toll_DATE,
TOLL_PLACE,
PAYMENT,
HANDLERID,
REMARK,
MAKERID,
DATE,
YEAR,
MONTH,
DAY
) VALUES 

(
@TOKEY,
@TOID,
@UCID,
@CAID,
@Toll_DATE,
@TOLL_PLACE,
@PAYMENT,
@HANDLERID,
@REMARK,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@DAY)

";
        string sql1 = @"UPDATE Toll SET 
TOID=@TOID,
UCID=@UCID,
CAID=@CAID,
TOLL_PLACE=@TOLL_PLACE,
Toll_DATE=@Toll_DATE,
PAYMENT=@PAYMENT,
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

            dt = basec.getdts(M_str_sql + " where A.TOID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {
                Text1.Value = dt.Rows[0]["TOID"].ToString();
                Text2.Value = dt.Rows[0]["PLATENUM"].ToString();
                Text3.Value = dt.Rows[0]["DRIVERID"].ToString();
                Text4.Value = dt.Rows[0]["CARTYPE"].ToString();
                Text5.Value = dt.Rows[0]["TOLL_DATE"].ToString();
                Text6.Value = dt.Rows[0]["Toll_PLACE"].ToString();
                DropDownList1.Text = dt.Rows[0]["PAYMENT"].ToString();
                if (dt.Rows[0]["PAYMENT"].ToString() == "路卡支付")
                {
                    Text7.Value = bc.getOnlyString(@"SELECT A.TOLLCARDID FROM TOLLCARDINFO A LEFT JOIN CARINFO B ON A.CAID=B.CAID WHERE B.PLATENUM=
'" + dt.Rows[0]["PLATENUM"].ToString() + "'");
                    Text8.Value = bc.gettollAmount(Text7.Value);
                    Text9.Value = dt.Rows[0]["TOLLCARD_MRCOUNT"].ToString();
                }
                else
                {
                    Text9.Value = dt.Rows[0]["TOLL"].ToString();
                    Text7.Value = "";
                    Text8.Value = "";

                }
              
                //Text8.Value = dt.Rows[0]["HANDLERID"].ToString();
           
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

                btnReconcile.Text = "已审核";
                btnReconcile.Enabled = false;
                btnReductionReconcil.Enabled = true;

            }
            else
            {

                btnReconcile.Text = "审核";
                btnReconcile.Enabled = true;
                btnReductionReconcil.Enabled = false;

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
            Text12.Value = "";
            TextBox1.Text = "";
            DropDownList1.Text = "";
            DropDownList1.Text = "路卡支付";
            currentdate();
            Label2.Text = "";
        }


        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM Toll", "TOID", "TO");
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
            string TOKEY = bc.numYMD(20, 12, "000000000001", "select * from Toll", "TOKEY", "TO");
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
            else if (TOKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";

            }
            else if (!bc.exists("SELECT TOID FROM Toll WHERE TOID='" + Text1.Value + "'"))
            {

                SQlcommandE(sql, TOKEY);
                if (DropDownList1.Text == "路卡支付")
                {
                    basec.getcoms("INSERT INTO GODE(GEKEY,GODEID,UCID,CAID,TOLLCARD_MRCOUNT,MAKERID,DATE,DRIVERID) VALUES ('" + TOKEY +
                   "','" + Text1.Value + "','" + Text12.Value + "','" + v3 + "','" + Text9.Value + "','" + varMakerID + "','" + varDate + "','" + v4 + "')");
                }
                else
                {
                    basec.getcoms("INSERT INTO GODE(GEKEY,GODEID,UCID,CAID,Toll,MAKERID,DATE,DRIVERID) VALUES ('" + TOKEY +
                    "','" + Text1.Value + "','" + Text12.Value + "','" + v3 + "','" + Text9.Value + "','" + varMakerID + "','" + varDate + "','" + v4 + "')");
                }
                Bindo();
            }
            else
            {

                SQlcommandE(sql1 + " WHERE TOID='" + Text1.Value + "'", TOKEY);
                basec.getcoms("UPDATE GODE SET TOLL=NULL,TOLLCARD_MRCOUNT=NULL WHERE GODEID='" + Text1.Value + "'");
                if (DropDownList1.Text == "路卡支付")
                {

                    basec.getcoms(@"UPDATE GODE SET UCID='" + Text12.Value + "',CAID='" + v3 + "',TOLLCARD_MRCOUNT='" + Text9.Value +
                        "',MAKERID='" + varMakerID + "',DATE='" + varDate +
                     "',DRIVERID='" + v4 + "' WHERE GODEID='" + Text1.Value + "' ");
                }
                else
                {

                    basec.getcoms(@"UPDATE GODE SET UCID='" + Text12.Value + "',CAID='" + v3 + "',Toll='" + Text9.Value +
                        "',MAKERID='" + varMakerID + "',DATE='" + varDate +
                     "',DRIVERID='" + v4 + "' WHERE GODEID='" + Text1.Value + "' ");

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
            sqlcom.Parameters.Add("@TOKEY", SqlDbType.VarChar, 20).Value = key;
            sqlcom.Parameters.Add("@TOID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@UCID", SqlDbType.VarChar, 20).Value = Text12.Value;
            sqlcom.Parameters.Add("@CAID", SqlDbType.VarChar, 20).Value = v3;
            sqlcom.Parameters.Add("@Toll_DATE", SqlDbType.VarChar, 50).Value = Text5.Value;
            sqlcom.Parameters.Add("@TOLL_PLACE", SqlDbType.VarChar, 20).Value = Text6.Value;
            sqlcom.Parameters.Add("@PAYMENT", SqlDbType.VarChar, 20).Value = DropDownList1.Text;
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
LEFT JOIN CARINFO B ON A.CAID=B.CAID WHERE A.TOLLCARDID='"+Text7.Value +"'");
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
            else if (Text6.Value == "")
            {
                ju = false;
                hint.Value = "交费地点不能为空！";
            }
            else if (bc.yesno(Text9.Value) == 0)
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (DropDownList1 .Text =="路卡支付" & Text7.Value =="")
            {
                ju = false;
                hint.Value = "选择路卡支付时卡号不能为空！";

            }
            else if (DropDownList1.Text == "路卡支付" & !bc.checkTOLLCARDID(Text7.Value))
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (DropDownList1.Text == "路卡支付" & bc.checkTOLLCARDID(Text7.Value) & Text9 .Value !="" )
            {
                if (v1 != Text2.Value)
                {
                    ju = false;
                    hint.Value = "路卡绑定的车牌号码与本次所选择的车牌号码不一致！";
                }
                else if (decimal.Parse(bc.gettollAmount(Text7.Value)) < decimal.Parse(Text9.Value))
                {
                    ju = false;
                    hint.Value = "消费金额需小于或等于路卡余额！";
                }
                

            }
            else if (!bc.checkEMID(Text10.Value))
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
            Response.Redirect("../CostManage/TollA.aspx" + n2);
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
