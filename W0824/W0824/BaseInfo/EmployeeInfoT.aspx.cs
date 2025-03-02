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
    public partial class EmployeeInfoT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        W0824.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        string sql = @"INSERT INTO EMPLOYEEINFO(
EMID,
ENAME,
SEX,
NATIVEPLACE,
NATIONALITY,
DEPART,
POSITION,
IDNUMBER,
BORNTIME,
ADDRESS,
PHONE,
REMARK,
MAKERID,
DATE,
YEAR,
MONTH
) VALUES 

(
@EMID,
@ENAME,
@SEX,
@NATIVEPLACE,
@NATIONALITY,
@DEPART,
@POSITION,
@IDNUMBER,
@BORNTIME,
@ADDRESS,
@PHONE,
@REMARK,
@MAKERID,
@DATE,
@YEAR,
@MONTH

)

";
        string sql1 = @"UPDATE EMPLOYEEINFO SET 
EMID=@EMID,
ENAME=@ENAME,
SEX=@SEX,
NATIVEPLACE=@NATIVEPLACE,
NATIONALITY=@NATIONALITY,
DEPART=@DEPART,
POSITION=@POSITION,
IDNUMBER=@IDNUMBER,
BORNTIME=@BORNTIME,
ADDRESS=@ADDRESS,
PHONE=@PHONE,
REMARK=@REMARK,
MAKERID=@MAKERID,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH
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
                dt = basec.getdts("select * from EmployeeInfo where EMID='" + Text1.Value + "'");
                if (dt.Rows.Count > 0)
                {


                    Text1.Value = dt.Rows[0]["EMID"].ToString();
                    Text2.Value = dt.Rows[0]["ENAME"].ToString();
                    DropDownList1.Text = dt.Rows[0]["SEX"].ToString();
                    Text3.Value = dt.Rows[0]["NATIVEPLACE"].ToString();
                    Text4.Value = dt.Rows[0]["NATIONALITY"].ToString();
                    DropDownList2.Text = dt.Rows[0]["DEPART"].ToString();
                    DropDownList3.Text = dt.Rows[0]["POSITION"].ToString();
                    Text5.Value = dt.Rows[0]["IDNUMBER"].ToString();
                    Text6.Value = dt.Rows[0]["BORNTIME"].ToString();
                    Text7.Value = dt.Rows[0]["ADDRESS"].ToString();
                    Text8.Value = dt.Rows[0]["PHONE"].ToString();
                    TextBox1.Text = dt.Rows[0]["REMARK"].ToString();


                }
            

            }

        }
        protected void ClearText()
        {
            Text1.Value = "";
            Text2.Value = "";
            DropDownList1.Text = "";
            Text3.Value = "";
            Text4.Value = "";
            DropDownList2.Text = "";
            DropDownList3.Text = "";
            Text5.Value = "";
            Text6.Value = "";
            Text7.Value = "";
            Text8.Value = "";
            TextBox1.Text = "";
        }


        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            Text1.Value = bc.numYM(7, 3, "001", "SELECT * FROM EMPLOYEEINFO", "EMID", "");

        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

           
            try
            {
                save();
              
            }
            catch (Exception)
            {
                hint.Value = "名字长度限定五个汉字";
            }

        }
        protected void save()
        {
            hint.Value = "";
            string v2 = bc.getOnlyString("SELECT IDNUMBER FROM EMPLOYEEINFO WHERE  EMID='" + Text1.Value + "'");
            if (!juage1())
            {

            }
            else if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from EMPLOYEEINFO where IDNUMBER='" + Text5.Value + "'"))
                {

                    hint.Value = "该身份证号已经存在了！";

                }
                else
                {

                    SQlcommandE(sql);
                }
            }
            else if (v2 != Text5.Value)
            {
                if (bc.exists("select * from EMPLOYEEINFO where IDNUMBER='" + Text5.Value + "'"))
                {
                    hint.Value = "该身份证号已经存在了！";
                }
                else
                {
                    SQlcommandE(sql1 + " WHERE EMID='" + Text1.Value + "'");

                }

            }
            else
            {

                SQlcommandE(sql1 + " WHERE EMID='" + Text1.Value + "'");

            }


        }
        #region juage1()
        private bool juage1()
        {


            bool ju = true;
            if (bc.yesno(Text5.Value) == 0)
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            else if (bc.yesno(Text8.Value) == 0)
            {
                ju = false;
                hint.Value = bc.ErrowInfo;

            }

            return ju;
        }
        #endregion
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
            sqlcom.Parameters.Add("@EMID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@ENAME", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@SEX", SqlDbType.VarChar , 20).Value = DropDownList1.Text;
            sqlcom.Parameters.Add("@NATIVEPLACE", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@NATIONALITY", SqlDbType.VarChar, 20).Value = Text4.Value;
            sqlcom.Parameters.Add("@DEPART", SqlDbType.VarChar, 20).Value = DropDownList2.Text;
            sqlcom.Parameters.Add("@POSITION", SqlDbType.VarChar, 20).Value = DropDownList3.Text;
            sqlcom.Parameters.Add("@IDNUMBER", SqlDbType.VarChar, 20).Value = Text5.Value;

            sqlcom.Parameters.Add("@BORNTIME", SqlDbType.VarChar, 20).Value = Text6.Value;
            sqlcom.Parameters.Add("@ADDRESS", SqlDbType.VarChar, 100).Value = Text7.Value;
            sqlcom.Parameters.Add("@PHONE", SqlDbType.VarChar, 20).Value =Text8.Value;
     
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
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../BaseInfo/EmployeeInfo.aspx" + n2);
        }
    }
}


