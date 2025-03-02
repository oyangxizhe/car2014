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
using System.IO;
using System.Diagnostics;
namespace W0824.UseCarManage
{
    public partial class DepartureT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();

        basec bc = new basec();
        W0824.Validate va = new Validate();
        int i;
        protected string M_str_sql = @"select A.UCKEY AS 索引,A.UCID as 用车单号,A.CUID AS 客户代码,B.CNAME AS 客户名称,C.ADDRESS AS 收货地址,
A.SN as 项次,D.ADDRESS AS 送货地址,F.USEDATE AS 使用日期,F.APPLICANTID AS 申请人工号,(SELECT DEPART FROM EMPLOYEEINFO WHERE EMID=F.USEPERSONID) AS 部门,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.APPLICANTID ) AS 申请人,F.USEPERSONID AS 使用人工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.APPLICANTID ) AS 使用人,F.USEDAYS AS 使用天数,
F.USECAUSE AS 事由说明,F.PLAN_CARTYPE AS 车辆类型,F.PLAN_RETURNTIME AS 预计返回时间,
F.TOGETHER_PERSONS AS 随行人数,F.DISPATCHERID AS 调度员工号,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.DISPATCHERID ) AS 调度员,
E.DRIVERID AS 驾驶员工号,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=E.DRIVERID ) AS 驾驶员,
F.CAID AS 车辆编号,G.PLATENUM AS 车牌号码,F.USEUNITPRICE AS 用车单价,
F.DEPARTURE_TIME AS 出车时间,F.DEPARTURE_VKT AS 出车时里程,F.DEPARTURE_SECURITYID AS 出车保安工号 ,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.DEPARTURE_SECURITYID ) AS 出车保安,
G.CAR_NATURE AS 车辆属性,G.CARTYPE AS 车辆类型,"
+ "E.START_OCOUNT as 出车数量 ,E.SellUnitPrice as 销售单价 ,E.TaxRate as 税率,"
+ "E.SELLUNITPRICE*E.START_OCOUNT AS 未税金额,E.TAXRATE/100*E.SELLUNITPRICE*E.START_OCOUNT AS 税额,"
+" E.SELLUNITPRICE*(1+(E.TAXRATE)/100)*E.START_OCOUNT AS 含税金额,"
+ "A.REMARK AS 备注 from UCApply_DET A "
+ " LEFT JOIN CUSTOMERINFO_MST B ON A.CUID=B.CUID"
+ " LEFT JOIN CUSTOMERINFO_DET C ON A.CUKEY=C.CUKEY"
+ " LEFT JOIN RECEIVINGANDDELIVERY D ON A.RDID=D.RDID"
+ " LEFT JOIN GODE E ON A.UCKEY=E.GEKEY"
+ " LEFT JOIN UCAPPLY_MST F ON A.UCID=F.UCID"
+" LEFT JOIN CARINFO G ON F.CAID=G.CAID";


        string sql = @"INSERT INTO UCAPPLY_MST(
UCID,
USEDate,
USEPersonID,
USEDEPART,
USEDays,
USECause,
PLAN_CarType,
PLAN_RETURNTIME,
TOGETHER_PERSONS,
UCAPPLY_STATUS,
DISPATCHERID,
DISPATCH_TIME,
CAID,
USEUNITPRICE,
DEPARTURE_TIME,
DEPARTURE_SECURITYID,
DEPARTURE_VKT,
CAR_STATUS,
MakerID,
Date,
Year,
Month
  
) VALUES 
(
@UCID,
@USEDate,
@USEPersonID,
@USEDEPART,
@USEDays,
@USECause,
@PLAN_CarType,
@PLAN_RETURNTIME,
@TOGETHER_PERSONS,
@UCAPPLY_STATUS,
@DISPATCHERID,
@DISPATCH_TIME,
@CAID,
@USEUNITPRICE,
@DEPARTURE_TIME,
@DEPARTURE_SECURITYID,
@DEPARTURE_VKT,
@CAR_STATUS,
@MakerID,
@Date,
@Year,
@Month
)
";
        string sql1 = @"UPDATE UCAPPLY_MST SET 
UCID=@UCID,
USEDate=@USEDate,
USEPersonID=@USEPersonID,
USEDEPART=@USEDEPART,
USEDays=@USEDays,
USECause=@USECause,
PLAN_CarType=@PLAN_CarType,
PLAN_RETURNTIME=@PLAN_RETURNTIME,
TOGETHER_PERSONS=@TOGETHER_PERSONS,
UCAPPLY_STATUS=@UCAPPLY_STATUS,
DISPATCHERID=@DISPATCHERID,
DISPATCH_TIME=@DISPATCH_TIME,
CAID=@CAID,
USEUNITPRICE=@USEUNITPRICE,
DEPARTURE_TIME=@DEPARTURE_TIME,
DEPARTURE_SECURITYID=@DEPARTURE_SECURITYID,
DEPARTURE_VKT=@DEPARTURE_VKT,
CAR_STATUS=@CAR_STATUS,
MakerID=@MakerID,
Date=@Date,
Year=@Year,
Month=@Month

";
        public static string[] str1 = new string[] { "", "" };
        public static string[] strE = new string[] { "" };
        string[] a = new string[] { "", "加急" };
        string UCKEY;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                if (!IsPostBack)
                {
                    //ViewState["pageindex"] = "0";
                    if (str1[0] != "")
                    {
                        Text1.Value = str1[0];
                        x2.Value = str1[1];
                        str1[0] = "";
                        str1[1] = "";

                    }
                    else
                    {
                        Assignment();

                    }
                    bind();
                }
            }
            catch (Exception)
            {


            }
            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
        }
        #region bind
        protected void bind()
        {
            hint.Value = "";
            x.Value = "";
            x1.Value = "";
            GridView1.DataSource = dtx();
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();

            string sql2 = M_str_sql + " WHERE A.UCID='" + Text1.Value + "' ORDER BY A.UCKEY";
            dt1 = basec.getdts(sql2);
            GridView2.DataSource = dt1;
            GridView2.DataKeyNames = new string[] { "索引" };
            GridView2.DataBind();


            DataTable dtx4 = basec.getdts(@"SELECT A.UCID,SUM(B.start_Ocount*B.sellunitprice),SUM(B.start_ocount*B.sellunitprice*
B.taxrate/100),SUM(B.start_ocount*B.sellunitprice*(1+B.Taxrate/100)) 
FROM UCApply_DET A 
LEFT JOIN GODE B  ON A.UCKEY=B.GEKEY WHERE A.UCID='" + Text1.Value + "' GROUP BY A.UCID ");

            if (dtx4.Rows.Count > 0)
            {
                string v8 = dtx4.Rows[0][1].ToString();
                string v9 = dtx4.Rows[0][2].ToString();
                string v10 = dtx4.Rows[0][3].ToString();
                x.Value = Convert.ToString(1);

            }
     
            string M_str_sql1 = @"select 
(CASE WHEN 
A.UCAPPLY_STATUS='OPEN' THEN '开立'
WHEN A.UCAPPLY_STATUS='APPROVE' THEN '已审核'
WHEN A.UCAPPLY_STATUS='DISPATCH' THEN '已调度'
WHEN A.UCAPPLY_STATUS='DEPARTURE' THEN '已出车登记'
ELSE '已回车登记'
END)
AS UCAPPLY_STATU from   UCAPPLY_Mst A
LEFT JOIN CARINFO B ON A.CAID=B.CAID
";
            string s11 = bc.getOnlyString(M_str_sql1 + " WHERE UCID='" + Text1.Value + "'");
            if (!string.IsNullOrEmpty(s11))
            {
                hint.Value = "用车单当前状态： " + s11;
            }
            dt = basec.getdts(M_str_sql + " where A.UCID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {
                string n1 = Request.Url.AbsoluteUri;
                string n2 = n1.Substring(n1.Length - 10, 10);
                string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
                Text2.Value = dt.Rows[0]["使用日期"].ToString();
            
                Text4.Value = dt.Rows[0]["部门"].ToString();
                Text5.Value = dt.Rows[0]["使用人工号"].ToString();
                Label2.Text = dt.Rows[0]["使用人"].ToString();
                Text6.Value = dt.Rows[0]["使用天数"].ToString();
                Text10 .Value  = dt.Rows[0]["事由说明"].ToString();
                DropDownList1.Text = dt.Rows[0]["车辆类型"].ToString();
                Text11.Value = dt.Rows[0]["预计返回时间"].ToString();
                Text12.Value = dt.Rows[0]["随行人数"].ToString();
                Text14.Value = dt.Rows[0]["调度员工号"].ToString();
                Label3.Text = dt.Rows[0]["调度员"].ToString();
                Text15.Value = dt.Rows[0]["驾驶员工号"].ToString();
                Label4.Text = dt.Rows[0]["驾驶员"].ToString();
                Text13.Value = dt.Rows[0]["车辆属性"].ToString();
                Text16.Value = dt.Rows[0]["车牌号码"].ToString();
                Text17.Value = dt.Rows[0]["车辆类型"].ToString();
                Text18.Value = dt.Rows[0]["用车单价"].ToString();
                Text19.Value = dt.Rows[0]["出车时里程"].ToString();

                dt4 = basec.getdts("select  top 1 * from ucapply_mst where CAID='"+ dt.Rows[0]["车辆编号"].ToString()+
                    "' AND return_vkt is not null order by return_time desc ");
                if (dt4.Rows.Count > 0)
                {
                    Text19.Value = dt4.Rows[0]["RETURN_VKT"].ToString();

                }
                if (dt.Rows[0]["出车时间"].ToString() == "")
                {
                    Text20.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
                }
                else
                {
                    Text20.Value = dt.Rows[0]["出车时间"].ToString();
            
                }
                if (dt.Rows[0]["出车保安工号"].ToString() == "")
                {
                    Text21.Value = varMakerID;
                    Label5.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
                }
                else
                {
                 
                    Text21.Value = dt.Rows[0]["出车保安工号"].ToString();
                    Label5.Text = dt.Rows[0]["出车保安"].ToString();
                }
           
            }
            else
            {

                string n1 = Request.Url.AbsoluteUri;
                string n2 = n1.Substring(n1.Length - 10, 10);
                string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
       
                Text5.Value = varMakerID;
                Text2.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
                Text11.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
     
                Label2.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
                Text4.Value = bc.getOnlyString("SELECT DEPART FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
                Text6.Value = "1";
                Text10.Value = "送货";
                Text14.Value = varMakerID;
                Text15.Value = varMakerID;
                Label3.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
                Label4.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
                Text20.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
                Text21.Value = varMakerID;
                Label5.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
               
            }

        }
        #endregion
        #region assignment
        protected void Assignment()
        {
            #region Assignment
            Text1.Value = strE[0];
            strE[0] = "";

            #endregion
        }
        #endregion
        protected DataTable dtx()
        {

            DataTable dt4 = new DataTable();
            dt4.Columns.Add("项次", typeof(string));
 
            // string sql = "";
            for (i = 1; i <= 1; i++)
            {
                DataRow dr = dt4.NewRow();
                dr["项次"] = Convert.ToString(i);
                dt4.Rows.Add(dr);
            }
            return dt4;
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
            string v1 = bc.getOnlyString("SELECT CAID FROM CARINFO WHERE PLATENUM='" + Text16.Value + "'");
            string v2 = bc.getOnlyString("SELECT CAR_NATURE FROM CARINFO WHERE PLATENUM='" + Text16.Value + "'");
            DateTime d1 = Convert.ToDateTime(Text2.Value);
            string v3 = d1.ToString("yyyy/MM/dd HH:mm:ss").Replace ("-","/");
            DateTime d2 = Convert.ToDateTime(Text11.Value);
            string v4 = d2.ToString("yyyy/MM/dd HH:mm:ss").Replace ("-","/");
            DateTime d3 = Convert.ToDateTime(Text20.Value);
            string v5= d3.ToString("yyyy/MM/dd HH:mm:ss").Replace ("-","/");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@UCID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@USEDate", SqlDbType.VarChar, 20).Value = v3;
            sqlcom.Parameters.Add("@USEPersonID", SqlDbType.VarChar, 20).Value = Text5.Value;
            sqlcom.Parameters.Add("@USEDEPART", SqlDbType.VarChar, 20).Value = Text5.Value;
            sqlcom.Parameters.Add("@USEDays", SqlDbType.VarChar, 20).Value = Text6.Value;
            sqlcom.Parameters.Add("@USECause", SqlDbType.VarChar, 20).Value = Text10.Value;
            sqlcom.Parameters.Add("@PLAN_CarType", SqlDbType.VarChar, 20).Value = DropDownList1.Text;
            sqlcom.Parameters.Add("@PLAN_RETURNTIME", SqlDbType.VarChar, 20).Value = v4;
            sqlcom.Parameters.Add("@TOGETHER_PERSONS", SqlDbType.VarChar, 20).Value = Text12.Value;
            sqlcom.Parameters.Add("@UCAPPLY_STATUS", SqlDbType.VarChar, 20).Value = "DEPARTURE";
            sqlcom.Parameters.Add("@DISPATCHERID", SqlDbType.VarChar, 20).Value = Text14.Value;
            sqlcom.Parameters.Add("@DISPATCH_TIME", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@CAID", SqlDbType.VarChar, 20).Value = v1;
           
            if (v2 == "公司车辆")
            {
               
                dt4 = basec.getdts("select  top 1 * from ucapply_mst where CAID='" + v1 +
                  "' AND return_vkt is not null order by return_time desc ");
                if (dt4.Rows.Count > 0)
                {
                    sqlcom.Parameters.Add("@DEPARTURE_VKT", SqlDbType.VarChar, 20).Value = dt4.Rows[0]["RETURN_VKT"].ToString();
                }
                else
                {
                  
                    sqlcom.Parameters.Add("@DEPARTURE_VKT", SqlDbType.VarChar, 20).Value = Text19.Value;
                }
               sqlcom.Parameters.Add("@USEUNITPRICE", SqlDbType.VarChar, 20).Value = Text18.Value;
               sqlcom.Parameters.Add("@CAR_STATUS", SqlDbType.VarChar, 20).Value = "BUSY";
      
            }
            else
            {
                sqlcom.Parameters.Add("@USEUNITPRICE", SqlDbType.VarChar, 20).Value = "0";
                sqlcom.Parameters.Add("@CAR_STATUS", SqlDbType.VarChar, 20).Value = "";
                sqlcom.Parameters.Add("@DEPARTURE_VKT", SqlDbType.VarChar, 20).Value = "0";
            }
            sqlcom.Parameters.Add("@DEPARTURE_TIME", SqlDbType.VarChar, 20).Value = v5;
            sqlcom.Parameters.Add("@DEPARTURE_SECURITYID", SqlDbType.VarChar, 20).Value = Text21.Value;
            sqlcom.Parameters.Add("@MakerID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@Date", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@Year", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@Month", SqlDbType.VarChar, 20).Value = month;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        protected void ClearText()
        {
            Text2.Value = "";
            Text4.Value = "";
            Text5.Value = "";
            Text6.Value = "";
            Text10.Value = "";
            Text11.Value = "";
            Text12.Value = "";
            Text13.Value = "";
            Text16.Value = "";
            Text17.Value = "";
            Text18.Value = "";
            Text19.Value = "";
            DropDownList1.Text = "";
            DropDownList1.Text = "大型货车";

     
        }
        #region add
        protected void add()
        {
            hint.Value = "";
            string s1 = bc.getOnlyString("SELECT UCAPPLY_STATUS FROM UCAPPLY_MST WHERE UCID='" + Text1.Value + "'");
            if (s1=="DEPARTURE"||s1=="RETURN"|| s1=="APPROVE")
            {

                hint.Value = "此用车单状态不为开立，不能做出车操作！";
            }
           else  if (ac1() == 0)
            {

            }
            else if (UCKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
            }
           else  if (ac2() == 0)
            {

            }
            else
            {
               
                add2();
            }
        }
        #endregion
        #region ac1()
        private int ac1()
        {

            int x = 1;
            string v2 = bc.getOnlyString("SELECT CAR_NATURE FROM CARINFO WHERE PLATENUM='" + Text16.Value + "'");
            string v1 = bc.getOnlyString(@"SELECT TOP 1 A.CAR_STATUS FROM UCAPPLY_MST A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID WHERE B.PLATENUM='" + Text16.Value + "'order by DISPATCH_time desc ");
           
               DateTime temp = DateTime.MinValue;
 
            if (Text2.Value =="")
            {
                x = 0;
                hint.Value = "使用日期不能为空！";

            }
            else if (!DateTime.TryParse(Text2.Value , out temp))
            {
                x = 0;
                hint.Value = "日期格式不正确！";
            }
            else if (!bc.checkEMID(Text5.Value))
             {
                 x = 0;
                hint.Value = bc.ErrowInfo;

            }
            else if (bc.yesno(Text6.Value) == 0)
             {
                 x = 0;
                hint.Value = bc.ErrowInfo;

            }
            else if (Text11.Value == "")
            {
                x = 0;
                hint.Value = "预计回程不能为空！";

            }
            else if (!DateTime.TryParse(Text11.Value, out temp))
            {
                x = 0;
                hint.Value = "日期格式不正确！";
            }
             else if (!bc.checkEMID(Text14.Value))
             {
                 x = 0;
                 hint.Value = bc.ErrowInfo;
             }
             else if (!bc.checkEMID(Text15.Value))
             {
                 x = 0;
                 hint.Value = bc.ErrowInfo;
             }
             else if (!bc.checkPLATENUM (Text16.Value ))
             {
                 x = 0;
                 hint.Value = bc.ErrowInfo;

             }
             else if (v2 == "公司车辆" & Text18.Value == "")
             {
                 x = 0;
                 hint.Value = "公司车辆需输入用车单价！";
             }
             else if (v1 == "BUSY")
             {
                 x = 0;
                 hint.Value = "该车辆在使用中或未做回车登记不能派车！";

             }
            else if (bc.yesno(Text19.Value )==0)
            {
                x = 0;
                hint.Value = bc.ErrowInfo;

            }
            else if (!juage ())
            {
                x = 0;
                hint.Value ="公司车辆需输入出车里程！";

            }
            else if (Text20.Value == "")
            {
               
                x = 0;
                hint.Value = "出车时间时间不能为空！";

            }
            else if (!DateTime.TryParse(Text20.Value, out temp))
            {
                x = 0;
                hint.Value = "日期格式不正确！";
            }
            else if (!bc.checkEMID(Text21.Value))
            {
                x = 0;
                hint.Value = bc.ErrowInfo;
            }
          
            return x;

        }
        #endregion
        private bool juage(string s1, string s2, string filed)
        {
            bool a = true;
            string w1 = bc.getOnlyString("select " + filed + " from WAREinfo where WAREid='" + s1 + "'");
            if (!string.IsNullOrEmpty(w1))
            {
                if (w1 != s2)
                {
                    a = false;
                }
            }
            return a;

        }
        private bool juage()
        {
            string v2 = bc.getOnlyString("SELECT CAR_NATURE FROM CARINFO WHERE PLATENUM='" + Text16.Value + "'");
            string v11 = bc.getOnlyString("SELECT CAID FROM CARINFO WHERE PLATENUM='" + Text16.Value + "'");
            dt4 = basec.getdts("select  top 1 * from ucapply_mst where CAID='" + v11 +
               "' AND return_vkt is not null order by return_time desc ");

            bool a = true;
            if (v2 == "公司车辆" && string.IsNullOrEmpty (Text19.Value ) && dt4.Rows.Count > 0)
            {


            }
            else if (v2 == "公司车辆" && Text19.Value != "")
            {


            }
            else if (v2 == "外租车" && Text19.Value == "" || Text19.Value  !="")
            {


            }
            else
            {
                a = false;
            }
            return a;

        }
        private void add2()
        {

            int k;
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            string usedepart = bc.getOnlyString("SELECT DEPART FROM EMPLOYEEINFO WHERE EMID='" + Text5.Value + "'");
            string v22 = bc.getOnlyString("SELECT CAR_NATURE FROM CARINFO WHERE PLATENUM='" + Text16.Value + "'");
            string v11 = bc.getOnlyString("SELECT CAID FROM CARINFO WHERE PLATENUM='" + Text16.Value + "'");

     
            if (!bc.exists("SELECT UCID FROM UCApply_DET WHERE UCID='" + Text1.Value + "'"))
            {
                for (k = 0; k < 1; k++)
                {
                    string s1;
                    int s2;
                    string SN;
                    string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string v2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                    string v3 = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;
                    string v4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                    string v5 = ((TextBox)GridView1.Rows[k].Cells[4].FindControl("TextBox5")).Text;
                    string cukey = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("CUKEY")).Text;
                    string rdid = ((TextBox)GridView1.Rows[k].Cells[6].FindControl("RDID")).Text;
                    string cuid = bc.getOnlyString("SELECT CUID FROM CUSTOMERINFO_DET WHERE CUKEY='" + cukey + "'");
                    if (v1 != "")
                    {

                        UCKEY = bc.numYMD(20, 12, "000000000001", "select * from UCApply_DET", "UCKEY", "UC");
                        DataTable dty = bc.getdt("SELECT * FROM UCApply_DET WHERE UCID='" + Text1.Value + "'");
                        if (dty.Rows.Count > 0)
                        {
                            s1 = dty.Rows[dty.Rows.Count - 1]["SN"].ToString();
                            s2 = Convert.ToInt32(s1) + 1;
                        }
                        else
                        {
                            s2 = 1;
                        }
                        SN = Convert.ToString(s2);

                        basec.getcoms(@"INSERT INTO UCApply_DET(UCKEY,UCID,SN,CUID,CUKEY,RDID,REMARK,YEAR,MONTH,DAY)  VALUES ('" + UCKEY +
                "','" + Text1.Value + "','" + SN + "','" + cuid + "','" + cukey + "','" + rdid + "','" + v5 +
                "','" + year + "','" + month + "','" + day + "')");

                        basec.getcoms(@"INSERT INTO GODE(GEKEY,GODEID,UCID,CAID,START_OCOUNT,MAKERID,DATE,DRIVERID)  VALUES ('" + UCKEY +
                            "','" + Text1.Value + "','" + Text1.Value + "','" + v11 + "','" + v4 + "','" + varMakerID + 
                            "','" + varDate + "','"+Text15.Value +"')");
                    }
                }
               
            }
            if (!bc.exists("SELECT UCID FROM UCApply_DET WHERE UCID='" + Text1.Value + "'"))
            {

                return;
            }
            else if (!bc.exists("SELECT UCID FROM UCApply_MST WHERE UCID='" + Text1.Value + "'"))
            {

                SQlcommandE(sql);

            }
            else
            {
                SQlcommandE(sql1 + " WHERE UCID='" + Text1.Value + "'");
                basec.getcoms(@"UPDATE GODE SET UCID='" + Text1.Value + "',CAID='" + v11 + "',DRIVERID='"+Text15.Value +
                    "' WHERE GODEID='" + Text1.Value + "'");

            }
            bind();
        }

        #region ac1()
        private int ac2()
        {

            int x = 1;
            for (int k = 0; k < 1; k++)
            {

                string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string v2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                string v3 = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;
                string v4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                string v5 = ((TextBox)GridView1.Rows[k].Cells[4].FindControl("TextBox5")).Text;
                string cukey = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("CUKEY")).Text;
                string rdid = ((TextBox)GridView1.Rows[k].Cells[6].FindControl("RDID")).Text;
                DateTime temp = DateTime.MinValue;
                if (v1 == "")
                {

                }
                else if (!bc.exists("select * from customerinfo_DET where CUKEY='" + cukey + "'"))
                {
                    x = 0;
                    hint.Value = "该客户不存在于系统中！";
                    break;

                }
                else if (!bc.exists("select * from receivinganddelivery where rdid='" + rdid + "'"))
                {
                    x = 0;
                    hint.Value = "送货地址为空或不存在于系统中！";
                    break;

                }
                else if (v4 == "")
                {
                    x = 0;
                    hint.Value = "数量不能为空！";
                    break;

                }
                else if (bc.yesno(v4) == 0)
                {
                    x = 0;
                    hint.Value = bc.ErrowInfo;
                    break;

                }
            }
            return x;

        }
        #endregion
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色 
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#C9D3E2',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
                e.Row.Attributes["style"] = "Cursor:pointer";
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色 
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#C9D3E2',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
                e.Row.Attributes["style"] = "Cursor:pointer";
            }
        }
        #region gridview2 delete
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string[] str = new string[] { "" };
            string sql1;
            hint.Value = "";
            string id = GridView2.DataKeys[e.RowIndex][0].ToString();
            str[0] = id;
            sql1 = "DELETE FROM UCApply_DET WHERE UCKEY='" + id + "'";
            string v1 = bc.getOnlyString("SELECT UCID FROM UCAPPLY_DET WHERE UCKEY='" + id + "'");
            string s1 = bc.getOnlyString("SELECT UCAPPLY_STATUS FROM UCAPPLY_MST WHERE UCID='" + v1 + "'");
            if (s1 == "RETURN" || s1 == "APPROVE")
            {
               
                hint.Value = "此用车单状态不为开立或已出车登记，不允许删除";
            }
            else if (bc.juageOne("SELECT * FROM UCApply_DET WHERE UCID='" + Text1.Value + "'"))
            {

                basec.getcoms(sql1);
                sql = "DELETE UCApply_MST WHERE UCID='" + Text1.Value + "'";
                basec.getcoms(sql);
                basec.getcoms("DELETE GODE WHERE GEKEY='" + id + "'");
                GridView2.EditIndex = -1;
                bind();

            }
            else
            {

                basec.getcoms(sql1);
                basec.getcoms("DELETE GODE WHERE GEKEY='" + id + "'");
                GridView2.EditIndex = -1;
                bind();


            }
            try
            {
                
            }
            catch (Exception)
            {


            }
        }
        #endregion

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色 
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#C9D3E2',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
                e.Row.Attributes["style"] = "Cursor:pointer";
            }
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            ClearText();
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM UCApply_MST", "UCID", "UC");
            bind();
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
           
            try
            {
                add();

            }
            catch (Exception)
            {

            }
        }

        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../usecarManage/departure.aspx" + n2);
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
            sql = @"SELECT A.UCID AS UCID,A.SN AS SN,B.WAREID AS WAREID,C.OCOUNT AS OCOUNT,SUM(B.MRCOUNT) AS MRCOUNT FROM SELLTABLE_DET A 
LEFT JOIN MATERE B ON A.SEKEY=B.MRKEY 
LEFT JOIN UCApply_DET C ON C.UCID=A.UCID AND C.SN=A.SN WHERE  A.UCID='" + Text1.Value + "' GROUP BY A.UCID,A.SN,B.WAREID,C.OCOUNT";
            DataTable dt2 = basec.getdts(sql);
            if (dt2.Rows.Count > 0)
            {
                if (bc.JuageOrderOrPurchaseStatus(Text2.Value, 0))
                {
                    basec.getcoms("UPDATE UCApply_MST SET UCApplySTATUS_MST='RECONCILE' WHERE UCID='" + Text1.Value + "'");
                    bind();
                }
                else
                {
                
                }

            }
            else
            {
               
            }

        }

        protected void btnReductionReconcile_Click(object sender, EventArgs e)
        {
            string s1 = bc.getOnlyString("SELECT UCAPPLY_STATUS FROM UCAPPLY_MST WHERE UCID='" + Text1.Value + "'");
            string v2 = bc.getOnlyString("SELECT CAR_NATURE FROM CARINFO WHERE PLATENUM='" + Text16.Value + "'");
            try
            {
                if (s1 != "DEPARTURE")
                {
                    hint.Value = "状态不为已出车登记，不能做撤销";
                }
                else
                {
                    if (v2 == "公司车辆")
                    {
                        basec.getcoms(@"UPDATE UCApply_MST SET DISPATCHERID=NULL,CAID=NULL,DISPATCH_TIME=NULL ,
                USEUNITPRICE=NULL,CAR_STATUS='EMPTY',UCAPPLY_STATUS='OPEN' WHERE UCID='" + Text1.Value + "'");

                        basec.getcoms(@"UPDATE UCApply_MST SET DEPARTURE_VKT=NULL,DEPARTURE_TIME=NULL
                 ,DEPARTURE_SECURITYID=NULL WHERE UCID='" + Text1.Value + "'");
                    }
                    else
                    {
                        basec.getcoms(@"UPDATE UCApply_MST SET DEPARTURE_VKT=NULL,DEPARTURE_TIME=NULL
                 ,DEPARTURE_SECURITYID=NULL,UCAPPLY_STATUS='OPEN' WHERE UCID='" + Text1.Value + "'");

                        basec.getcoms(@"UPDATE UCApply_MST SET DISPATCHERID=NULL,DRIVERID=NULL,CAID=NULL,DISPATCH_TIME=NULL ,
                    USEUNITPRICE=NULL WHERE UCID='" + Text1.Value + "'");

                    }
                    basec.getcoms("UPDATE GODE SET CAID=NULL,DRIVERID=NULL WHERE GODEID='" + Text1.Value + "'");
                    bind();
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

                String[] Carstr = new string[] { Text1.Value};
                W0824.ReportManage.CRVUCApply.Array= Carstr;
                Response.Redirect("../ReportManage/CRVUCApply.aspx");
        }

    }
}
