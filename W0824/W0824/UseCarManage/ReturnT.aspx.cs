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
    public partial class ReturnT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();

        basec bc = new basec();
        W0824.Validate va = new Validate();

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
F.Return_TIME AS 回车时间,F.Return_VKT AS 回车时里程,F.Return_SECURITYID AS 回车保安工号 ,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.Return_SECURITYID ) AS 回车保安,
G.CAR_NATURE AS 车辆属性,G.CARTYPE AS 车辆类型,"
+ "E.START_OCOUNT as 出车数量 ,E.OCOUNT AS 回车数量,E.SellUnitPrice as 销售单价 ,E.TaxRate as 税率,"
+ "E.SELLUNITPRICE*E.OCOUNT AS 金额,E.TAXRATE/100*E.SELLUNITPRICE*E.OCOUNT AS 税额,"
+ " E.SELLUNITPRICE*(1+(E.TAXRATE)/100)*E.OCOUNT AS 含税金额,E.TYPOGRAPHY_COST AS 排班费用,"
+ "A.REMARK AS 备注 from UCApply_DET A "
+ " LEFT JOIN CUSTOMERINFO_MST B ON A.CUID=B.CUID"
+ " LEFT JOIN CUSTOMERINFO_DET C ON A.CUKEY=C.CUKEY"
+ " LEFT JOIN RECEIVINGANDDELIVERY D ON A.RDID=D.RDID"
+ " LEFT JOIN GODE E ON A.UCKEY=E.GEKEY"
+ " LEFT JOIN UCAPPLY_MST F ON A.UCID=F.UCID"
+ " LEFT JOIN CARINFO G ON F.CAID=G.CAID";
        public static string[] str1 = new string[] { "", "" };
        public static string[] strE = new string[] { "" };
        string[] a = new string[] { "", "加急" };
        string sql;
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


            DataTable dtx4 = basec.getdts(@"SELECT A.UCID,SUM(B.ocount*B.sellunitprice+typography_cost),SUM(B.ocount*B.sellunitprice*
B.taxrate/100),SUM(B.ocount*B.sellunitprice*(1+B.Taxrate/100)) 
FROM UCApply_DET A 
LEFT JOIN GODE B  ON A.UCKEY=B.GEKEY WHERE A.UCID='" + Text1.Value + "' GROUP BY A.UCID ");

            if (dtx4.Rows.Count > 0)
            {
                string v8 = dtx4.Rows[0][1].ToString();
                string v9 = dtx4.Rows[0][2].ToString();
                string v10 = dtx4.Rows[0][3].ToString();
                if (!string.IsNullOrEmpty(dtx4.Rows[0][1].ToString()))
                {
                    Text7.Value = string.Format("{0:F2}", Convert.ToDouble(v8));
                    x.Value = Convert.ToString(1);
                }
                else
                {
                    Text7.Value = "";
                }
            }
            else
            {
                Text7.Value = "";

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
                Text10.Value = dt.Rows[0]["事由说明"].ToString();
                DropDownList1.Text = dt.Rows[0]["车辆类型"].ToString();
                Text11.Value = dt.Rows[0]["使用日期"].ToString();
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
                Text20.Value = dt.Rows[0]["出车时间"].ToString();
                Text21.Value = dt.Rows[0]["出车保安工号"].ToString();
                Text22.Value = dt.Rows[0]["回车时里程"].ToString();
                Label5.Text = dt.Rows[0]["出车保安"].ToString();

                if (dt.Rows[0]["回车时间"].ToString() == "")
                {
                    Text23.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss".Replace("-", "/"));
                }
                else
                {
                    Text23.Value = dt.Rows[0]["回车时间"].ToString();

                }
                if (dt.Rows[0]["回车保安工号"].ToString() == "")
                {
                    Text24.Value = varMakerID;
                    Label6.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
                }
                else
                {

                    Text24.Value = dt.Rows[0]["回车保安工号"].ToString();
                    Label6.Text = dt.Rows[0]["回车保安"].ToString();
                }
            }
            else
            {

                string n1 = Request.Url.AbsoluteUri;
                string n2 = n1.Substring(n1.Length - 10, 10);
                string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
                Text5.Value = varMakerID;
                Text2.Value = DateTime.Now.ToString("yyyy/MM/dd".Replace("-", "/"));
                Text11.Value = DateTime.Now.ToString("yyyy/MM/dd".Replace("-", "/"));
                Label2.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
                Text4.Value = bc.getOnlyString("SELECT DEPART FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
                Text6.Value = "1";
                Text10.Value = "送货";
                Text14.Value = varMakerID;
                Text15.Value = varMakerID;
                Label3.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
                Label4.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");


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
            dt4.Columns.Add("客户", typeof(string));
            dt4.Columns.Add("收货地址", typeof(string));
            dt4.Columns.Add("送货地址", typeof(string));
            dt4.Columns.Add("回车数量", typeof(string));
            dt4.Columns.Add("销售单价", typeof(string));
            dt4.Columns.Add("税率", typeof(string));
            dt4.Columns.Add("备注", typeof(string));
            dt = basec.getdts(M_str_sql + " where A.UCID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dt.Rows[0]["回车数量"].ToString()))
                {
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        
                        DataRow dr = dt4.NewRow();
                        dr["客户"] = dr1["客户名称"].ToString();
                        dr["收货地址"] = dr1["收货地址"].ToString();
                        dr["送货地址"] = dr1["送货地址"].ToString();
                        dr["回车数量"] = dr1["出车数量"].ToString();
                        dr["销售单价"] = dr1["销售单价"].ToString();
                        dr["税率"] = dr1["税率"].ToString();
                        dr["备注"] = dr1["备注"].ToString();
                        dt4.Rows.Add(dr);
                    }
                }
                else
                {
                    for (int i = 1; i <= 1; i++)
                    {
                        DataRow dr = dt4.NewRow();
                        dr["项次"] = Convert.ToString(i);
                        dr["税率"] = 17;
                        dt4.Rows.Add(dr);
                    }

                }


            }


            return dt4;
        }

        protected void ClearText()
        {
            Text2.Value = "";
            Text4.Value = "";
            Text5.Value = "";
            Text6.Value = "";
            Text7.Value = "";
            Text10.Value = "";
            Text11.Value = "";
            Text12.Value = "";
            Text16.Value = "";
            Text18.Value = "";
            DropDownList1.Text = "";
            DropDownList1.Text = "大型货车";


        }
        #region add
        protected void add()
        {
            hint.Value = "";
            string s1 = bc.getOnlyString("SELECT UCAPPLY_STATUS FROM UCAPPLY_MST WHERE UCID='" + Text1.Value + "'");
            if (s1 != "DEPARTURE")
            {

                hint.Value = "此用车单状态不为已出车登记，不能做回车登记！";
            }
            else if (ac1() == 0)
            {

            }
            else if (ac2() == 0)
            {

            }
            else
            {

                add2();
            }
        }
        #endregion
        private void add2()
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
            DateTime d1 = Convert.ToDateTime(Text23.Value);
            string v3 = d1.ToString("yyyy/MM/dd HH:mm:ss").Replace ("-","/");
            if (v2 == "公司车辆")
            {
                basec.getcoms(@"UPDATE UCApply_MST SET Return_VKT='" + Text22.Value + "',Return_TIME='" + v3 +
                "',Return_SECURITYID='" + Text24.Value + "',UCAPPLY_STATUS='RETURN',"
                + "CAR_STATUS='EMPTY' WHERE UCID='" + Text1.Value + "'");
            }
            else
            {
                basec.getcoms(@"UPDATE UCApply_MST SET Return_VKT='0',Return_TIME='" + v3 +
               "',Return_SECURITYID='" + Text24.Value + "',UCAPPLY_STATUS='RETURN' WHERE UCID='" + Text1.Value + "'");
            }
            dt = basec.getdts(M_str_sql + " where A.UCID='" + Text1.Value + "'");
            for (int k = 0; k < dt.Rows.Count; k++)
            {

                string v4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                string v5 = ((TextBox)GridView1.Rows[k].Cells[4].FindControl("TextBox5")).Text;
                string v6 = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
                basec.getcoms("UPDATE GODE SET OCOUNT='" + v4 + "',SELLUNITPRICE='" + v5 + "' ,TYPOGRAPHY_COST='" + v6 + "' WHERE GEKEY='" + dt.Rows[k]["索引"].ToString() + "'");

            }
            bind();
        }
        #region ac1()
        private int ac1()
        {

            int x = 1;
            string v2 = bc.getOnlyString("SELECT CAR_NATURE FROM CARINFO WHERE PLATENUM='" + Text16.Value + "'");
            DateTime temp = DateTime.MinValue;
            if (bc.yesno(Text22.Value) == 0)
            {
                x = 0;
                hint.Value = bc.ErrowInfo;

            }
            else if (v2 == "公司车辆" & Text22.Value == "")
            {
                x = 0;
                hint.Value = "公司车辆需输入回车时里程！";
            }
            else if (v2 == "公司车辆" & (decimal.Parse(Text19.Value) >= decimal.Parse(Text22.Value)))
            {

                x = 0;
                hint.Value = "回车里程数需大于出车里程！";
            }
            else if (Text23.Value == "")
            {

                x = 0;
                hint.Value = "预计回程不能为空！";

            }
            else if (!DateTime.TryParse(Text23.Value, out temp))
            {
                x = 0;
                hint.Value = "日期格式不正确！";
            }
            else if (!bc.checkEMID(Text24.Value))
            {
                x = 0;
                hint.Value = bc.ErrowInfo;
            }

            return x;

        }
        #endregion
        #region ac2()
        private int ac2()
        {

            int x = 1;
            dt = basec.getdts(M_str_sql + " where A.UCID='" + Text1.Value + "'");
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                string v4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                string v5 = ((TextBox)GridView1.Rows[k].Cells[4].FindControl("TextBox5")).Text;
                string v6 = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
                if (v4 == "")
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
                else if (v5 == "")
                {
                    x = 0;
                    hint.Value = "单价不能为空！";
                    break;

                }
                else if (bc.yesno(v5) == 0)
                {
                    x = 0;
                    hint.Value = bc.ErrowInfo;
                    break;
                }
                else if (v6 == "")
                {
                    x = 0;
                    hint.Value = "排班费用不能为空！";
                    break;

                }
                else if (bc.yesno(v6) == 0)
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

            try
            {
                if (s1 == "Y")
                {

                    hint.Value = "此用车单已经审核，不允许修改或删除";
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
            Response.Redirect("../usecarManage/Return.aspx" + n2);
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
                    hint.Value = "此订单没有结案，不允许确认对帐!";
                }

            }
            else
            {
                hint.Value = "没有此订单的销货记录!";
            }

        }

        protected void btnReductionReconcile_Click(object sender, EventArgs e)
        {
            string s1 = bc.getOnlyString("SELECT UCAPPLY_STATUS FROM UCAPPLY_MST WHERE UCID='" + Text1.Value + "'");
            string v2 = bc.getOnlyString("SELECT CAR_NATURE FROM CARINFO WHERE PLATENUM='" + Text16.Value + "'");
            try
            {
                if (s1 != "RETURN")
                {
                    hint.Value = "状态不为已出车登记，不能做撤销";
                }
                else if (!juage())
                {

                }
                else
                {
                    dt = basec.getdts(M_str_sql + " where A.UCID='" + Text1.Value + "'");
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {


                        basec.getcoms("UPDATE GODE SET OCOUNT=NULL,SELLUNITPRICE=NULL,TYPOGRAPHY_COST=NULL WHERE GEKEY='" + dt.Rows[k]["索引"].ToString() + "'");
                        basec.getcoms("UPDATE UCAPPLY_DET SET REMARK=NULL WHERE UCKEY='" + dt.Rows[k]["索引"].ToString() + "'");

                    }
                    if (v2 == "公司车辆")
                    {
                        basec.getcoms(@"UPDATE UCApply_MST SET Return_VKT=NULL,Return_TIME=NULL
                 ,Return_SECURITYID=NULL,UCAPPLY_STATUS='DEPARTURE',CAR_STATUS='BUSY' WHERE UCID='" + Text1.Value + "'");
                    }
                    else
                    {
                        basec.getcoms(@"UPDATE UCApply_MST SET Return_VKT=NULL,Return_TIME=NULL
                 ,Return_SECURITYID=NULL,UCAPPLY_STATUS='DEPARTURE' WHERE UCID='" + Text1.Value + "'");

                    }
                    bind();
                }
            }
            catch (Exception)
            {

            }
        }
        private bool juage()
        {
            bool a = true;
            dt4 = basec.getdts(@"select  top 1 * from ucapply_mst where CAID IN (SELECT CAID FROM CARINFO WHERE PLATENUM='" + Text16.Value +
               "') AND departure_vkt is not null order by return_time desc ");
            dt = basec.getdts(M_str_sql + " where A.UCID='" + Text1.Value + "'");
            string v2 = bc.getOnlyString("SELECT CAR_NATURE FROM CARINFO WHERE PLATENUM='" + Text16.Value + "'");
            if (v2 == "公司车辆")
            {

                if (dt4.Rows.Count > 0)
                {

                    if (dt.Rows[0]["出车时里程"].ToString() != dt4.Rows[0]["DEPARTURE_VKT"].ToString())
                    {
                        a = false;
                        hint.Value = "该用车单的出车里程与该车牌号最近一次出车时的里程数不符，不允许撤销！";

                    }

                }
            }

            return a;

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
            W0824.ReportManage.CRVUCApply.Array = Carstr;
            Response.Redirect("../ReportManage/CRVUCApply.aspx");
        }

    }
}
