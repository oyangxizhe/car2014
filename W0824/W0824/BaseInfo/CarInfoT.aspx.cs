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




namespace W0824.BaseInfo
{
    public partial class CarInfoT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        W0824.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };

        string sql = @"INSERT INTO CARINFO(
CAID,
PLATENUM,
CARBRAND,
CARTYPE,
CAR_NATURE,
TONNAGE,
USEUNITPRICE,
PURPOSE,
DRIVERID,
REMARK,
MAKERID,
DATE,
YEAR,
MONTH
) VALUES 

(@CAID,
@PLATENUM,
@CARBRAND,
@CARTYPE,
@CAR_NATURE,
@TONNAGE,
@USEUNITPRICE,
@PURPOSE,
@DRIVERID,
@REMARK,
@MAKERID,
@DATE,
@YEAR,
@MONTH)

";
        string sql1 = @"UPDATE CARINFO SET 
CAID=@CAID,
PLATENUM=@PLATENUM,
CARBRAND=@CARBRAND,
CARTYPE=@CARTYPE,
CAR_NATURE=@CAR_NATURE,
TONNAGE=@TONNAGE,
USEUNITPRICE=@USEUNITPRICE,
PURPOSE=@PURPOSE,
DRIVERID=@DRIVERID,
REMARK=@REMARK,
MAKERID=@MAKERID,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH";
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
            Text9.Value = varMakerID;
            Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
            Text8.Value = "0";
        }
        protected void Bindo()
        {

            dt = basec.getdts("select * from CarInfo where CAID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {
                Text1.Value = dt.Rows[0]["CAID"].ToString();
                Text2.Value = dt.Rows[0]["PLATENUM"].ToString();
                DropDownList1.Text = dt.Rows[0]["CARBRAND"].ToString();
                DropDownList2.Text = dt.Rows[0]["CARTYPE"].ToString();
                DropDownList3.Text = dt.Rows[0]["CAR_NATURE"].ToString();
                Text3.Value = dt.Rows[0]["TONNAGE"].ToString();
                Text8.Value = dt.Rows[0]["USEUNITPRICE"].ToString();
                DropDownList4.Text = dt.Rows[0]["PURPOSE"].ToString();
                Text9.Value = dt.Rows[0]["DRIVERID"].ToString();
                Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + dt.Rows[0]["DRIVERID"].ToString() + "'");
                TextBox1.Text = dt.Rows[0]["REMARK"].ToString();
            }
            else
            {
                currentdate();
            }


        }
        protected void ClearText()
        {
            Text2.Value = "";
            DropDownList1.Text = "";
            DropDownList2.Text = "";
            DropDownList3.Text = "";
            Text3.Value = "";
            Text8.Value = "";
            DropDownList4.Text = "";
            Text9.Value = "";
            TextBox1.Text = "";
            currentdate();
            Text8.Value = "0";
        }


        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM CARINFO", "CAID", "CA");
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
            string v2 = bc.getOnlyString("SELECT PLATENUM FROM CARINFO WHERE  CAID='" + Text1.Value + "'");
            if (!juage1())
            {

            }
            else if (!bc.exists("SELECT CAID FROM CARINFO WHERE CAID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from CARINFO where PLATENUM='" + Text2.Value + "'"))
                {

                    hint.Value = "该车牌号码已经存在了！";

                }
                else
                {

                    SQlcommandE(sql);
                    Bindo();
                }
            }
            else if (v2 != Text2.Value)
            {
                if (bc.exists("select * from carinfo where platenum='" + Text2.Value + "'"))
                {
                    hint.Value = "该车牌号码已经存在了！";
                }
                else
                {
                    SQlcommandE(sql1 + " WHERE CAID='" + Text1.Value + "'");
                    Bindo();

                }

            }
            else
            {

                SQlcommandE(sql1 + " WHERE CAID='" + Text1.Value + "'");
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
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@CAID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@PLATENUM", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@CARBRAND", SqlDbType.VarChar, 20).Value = DropDownList1.Text;
            sqlcom.Parameters.Add("@CARTYPE", SqlDbType.VarChar, 20).Value = DropDownList2.Text;
            sqlcom.Parameters.Add("@CAR_NATURE", SqlDbType.VarChar, 20).Value = DropDownList3.Text;
            sqlcom.Parameters.Add("@TONNAGE", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@USEUNITPRICE", SqlDbType.VarChar, 20).Value = Text8.Value;
            sqlcom.Parameters.Add("@PURPOSE", SqlDbType.VarChar, 20).Value = DropDownList4.Text;
            sqlcom.Parameters.Add("@DRIVERID", SqlDbType.VarChar, 20).Value = Text9.Value;
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 1000).Value = TextBox1.Text;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        #region juage1()
        private bool juage1()
        {


            bool ju = true;
            if (bc.yesno(Text3.Value) == 0)
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (DropDownList3.Text == "公司车辆" & Text8.Value =="")
            {
                ju = false;
                hint.Value = "公司车辆需输入用车单价";

            }
            else if (bc.yesno(Text8.Value) == 0)
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
            Response.Redirect("../BaseInfo/CarInfo.aspx" + n2);
        }
    }
}
