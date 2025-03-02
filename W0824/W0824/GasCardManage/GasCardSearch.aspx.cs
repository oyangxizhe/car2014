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
using System.Net;
using System.Text;
using XizheC;
using System.IO;
using System.Diagnostics;

namespace W0824.GasCardManage
{
    public partial class GasCardSearch : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtx2 = new DataTable();
        DataTable dtx4 = new DataTable();
        basec bc = new basec();
        int i, j;



        string sqlo = @"select A.ORID AS 订单号,
A.SN as 项次,E.WareID as 品号,B.EUJ_WAREID AS EUJ料号,
B.WNAME AS 品名,B.CWAREID AS 客户料号,
RTRIM(CONVERT(DECIMAL(18,2),C.SELLUNITPRICE)) AS 销售单价,RTRIM(CONVERT(DECIMAL(18,2),C.TAXRATE )) AS 税率,
RTRIM(CONVERT(DECIMAL(18,2),C.OCount)) as 订单数量 ,
RTRIM(CONVERT(DECIMAL(18,2),SUM(E.MRCount))) as 累计销货数量 ,
RTRIM(CONVERT(DECIMAL(18,2),SUM(E.MRCOUNT*C.SELLUNITPRICE))) AS 未税金额,
RTRIM(CONVERT(DECIMAL(18,2),SUM(E.MRCOUNT*C.SELLUNITPRICE*C.TAXRATE/100) )) AS 税额,
RTRIM(CONVERT(DECIMAL(18,2),SUM(E.MRCOUNT*C.SELLUNITPRICE*(1+C.TAXRATE/100)) )) AS 含税金额,
C.CUID as 客户代码,D.CName as 客户 ,F.ORDERDATE AS 订货日期,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.SALEID )  AS 业务员
from SELLTABLE_DET A 
LEFT JOIN ORDER_DET C ON A.ORID=C.ORID AND A.SN=C.SN
LEFT JOIN CUSTOMERINFO_MST D ON C.CUID=D.CUID
LEFT JOIN MATERE E ON A.SEKEY=E.MRKEY
LEFT JOIN WAREINFO B ON E.WAREID=B.WAREID
LEFT JOIN ORDER_MST F ON C.ORID=F.ORID";
        string sqlt = @" GROUP BY A.ORID,A.SN,E.WAREID,B.EUJ_WAREID,B.WNAME,B.CWAREID,
C.SELLUNITPRICE,C.TAXRATE,C.OCOUNT,C.CUID,D.CNAME,F.ORDERDATE,F.SALEID ORDER BY A.ORID,A.SN";

        protected string M_str_sql = @"
select A.SEKEY AS 索引,A.ORID AS 订单号,A.SEID AS 销货单号,A.SN as 项次,E.WareID as 品号,
B.EUJ_WAREID AS EUJ料号,B.WNAME AS 品名,B.CWAREID AS 客户料号,C.OCOUNT AS 订单数量,
RTRIM(CONVERT(DECIMAL(18,2),C.SELLUNITPRICE)) AS 销售单价,RTRIM(CONVERT(DECIMAL(18,2),C.TAXRATE )) AS 税率,
RTRIM(CONVERT(DECIMAL(18,2),E.MRCount)) as 销货数量 ,RTRIM(CONVERT(DECIMAL(18,2),E.MRCOUNT*C.SELLUNITPRICE)) AS 未税金额,
RTRIM(CONVERT(DECIMAL(18,2),E.MRCOUNT*C.SELLUNITPRICE*C.TAXRATE/100)) AS 税额,
RTRIM(CONVERT(DECIMAL(18,2),E.MRCOUNT*C.SELLUNITPRICE*(1+C.TAXRATE/100))) AS 含税金额,C.CUID as 客户代码,
D.CName as 客户名称 ,F.ORDERDATE AS 订货日期,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.SALEID )  AS 业务员,
F.DATE AS 订单制单日期,G.SELLDATE AS 销货日期,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=G.SELLERID )  AS 销货员
,E.DATE AS 销货制单日期,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=E.MAKERID )  AS 销货制单人
from SELLTABLE_DET A              
LEFT JOIN ORDER_DET C ON A.ORID=C.ORID AND A.SN=C.SN
LEFT JOIN CUSTOMERINFO_MST D ON C.CUID=D.CUID
LEFT JOIN MATERE E ON A.SEKEY=E.MRKEY
LEFT JOIN WAREINFO B ON E.WAREID=B.WAREID
LEFT JOIN ORDER_MST F ON C.ORID=F.ORID 
LEFT JOIN SELLTABLE_MST G ON A.SEID=G.SEID";
        protected string M_str_sql1;
        W0824.Validate va = new Validate();

        protected void Page_Load(object sender, EventArgs e)
        {
             if (va.returnb() == true)
            Response.Redirect("\\Default.aspx");

        }
        #region bind()
        private void bind()
        {
            

            try
            {
                hint.Value = "";
                x.Value = "";
                x1.Value = "";
                GridView1.PageSize = 15;
                select();
            }
            catch (Exception)
            {

            }
        }
        #endregion
        #region select()
        protected void select()
        {

            string v5 = "", v6 = "";
            string v1 = StartDate.Value;
            string v2 = EndDate.Value;
            if (!bc.juagedate(v1, v2))
            {
                hint.Value = bc.ErrowInfo;
                return;
            }
            if (v1 != "" && v2 != "")
            {
                DateTime v3 = Convert.ToDateTime(v1);
                DateTime v4 = Convert.ToDateTime(v2);
                v5 = v3.ToString("yyyy/MM/dd").Replace("-", "/") + " 00:00:00";
                v6 = v4.ToString("yyyy/MM/dd").Replace("-", "/") + " 23:59:59";

            }

            if (Text1.Value != "" && StartDate.Value == "" && EndDate.Value == "")
            {


                M_str_sql1 = M_str_sql + " where A.ENAME like '%" + Text1.Value + "%'";
                dt = basec.getdts(M_str_sql1);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
                else
                {
                    hint.Value = "没有找到记录";

                }

            }
            else if (Text1.Value == "" && StartDate.Value != "" && EndDate.Value != "")
            {
                M_str_sql1 = M_str_sql + " where A. DATE BETWEEN  '" + v5 + "'AND '" + v6 + "'";
                dt = basec.getdts(M_str_sql1);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    hint.Value = "没有找到记录";
                }

            }
            else if (Text1.Value != "" && StartDate.Value != "" && EndDate.Value != "")
            {
                M_str_sql1 = M_str_sql + " where A.DATE BETWEEN  '" + v5 + "'AND '" + v6 + "' AND A.ENAME LIKE '%" + Text1.Value + "%'";
                dt = basec.getdts(M_str_sql1);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind(); ;
                }
                else
                {
                    hint.Value = "没有找到记录";

                }
            }
            else
            {
                dt = basec.getdts(M_str_sql);
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            nextpage();
        }
        #endregion
        #region showdata
        protected void showdata(string sql)
        {
            dt = ask(sql);
            if (dt.Rows.Count > 0)
            {

                x1.Value = Convert.ToString(1);
                x.Value = Convert.ToString(1);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
        #endregion
        #region showdatao
        protected void showdatao(string sql)
        {

            dt = bc.getdt(M_str_sql+sql );
            if (dt.Rows.Count > 0)
            {

                x1.Value = Convert.ToString(1);
                x.Value = Convert.ToString(1);

                GridView1.DataSource = dt;
                GridView1.DataBind();

            }

        }
        #endregion
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "订单号" };
            GridView1.DataBind();
            lblRecordCount.Text = "记录总数" + dt.Rows.Count + "条";
            lblPageCount.Text = "总页数" + (GridView1.PageCount).ToString() + "页";
            lblCurrentIndex.Text = "当前页第" + ((GridView1.PageIndex) + 1).ToString() + "页";
            if (dt.Rows.Count > 0)
            {
                if (GridView1.PageIndex == 0)
                {
                    btnFirst.Enabled = false;
                    btnPrev.Enabled = false;
                }
                else
                {
                    btnFirst.Enabled = true;
                    btnPrev.Enabled = true;
                }
                if (GridView1.PageIndex == GridView1.PageCount - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }

                // 计算生成分页页码,分别为："首 页" "上一页" "下一页" "尾 页"
                btnFirst.CommandName = "1";
                btnPrev.CommandName = (GridView1.PageIndex == 0 ? "1" : GridView1.PageIndex.ToString());

                btnNext.CommandName = (GridView1.PageCount == 1 ? GridView1.PageCount.ToString() : (GridView1.PageIndex + 2).ToString());
                btnLast.CommandName = GridView1.PageCount.ToString();
            }
            else
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }

        }
        #endregion
        #region ask
        private DataTable ask(string sql)
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("订单号", typeof(string));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("品号", typeof(string));
            dtt.Columns.Add("EUJ料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("销售单价", typeof(decimal));
            dtt.Columns.Add("税率", typeof(decimal));
            dtt.Columns.Add("订单数量", typeof(decimal));
            dtt.Columns.Add("累计销货数量", typeof(decimal));
            dtt.Columns.Add("未销货数量", typeof(decimal), "订单数量-累计销货数量");
            dtt.Columns.Add("未税金额", typeof(decimal), "销售单价*累计销货数量");
            dtt.Columns.Add("税额", typeof(decimal), "销售单价*累计销货数量*税率/100");
            dtt.Columns.Add("含税金额", typeof(decimal), "销售单价*累计销货数量*(1+税率/100)");
            dtt.Columns.Add("需求日期", typeof(string));
            dtt.Columns.Add("客户代码", typeof(string));
            dtt.Columns.Add("客户", typeof(string));
            dtt.Columns.Add("电话", typeof(string));
            dtt.Columns.Add("地址", typeof(string));
            dtt.Columns.Add("制单人", typeof(string));
            dtt.Columns.Add("制单日期", typeof(string));

            DataTable dtx1 = bc.getdt(@"SELECT A.ORID AS ORID,A.SN AS SN,A.WAREID AS WAREID,A.SELLUNITPRICE AS SELLUNITPRICE,
A.TAXRATE AS TAXRATE,A.NEEDDATE AS NEEDDATE,A.OCOUNT AS OCOUNT,D.CUID AS CUID,D.CNAME AS CNAME,E.PHONE AS PHONE,E.ADDRESS AS ADDRESS,
F.DATE AS DATE,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.MAKERID) AS MAKER FROM ORDER_DET A 
 LEFT JOIN ORDER_MST F ON A.ORID=F.ORID 
LEFT JOIN CUSTOMERINFO_MST D ON A.CUID=D.CUID
LEFT JOIN CUSTOMERINFO_DET E ON D.CUKEY=E.CUKEY
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID" + sql);
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i < dtx1.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["订单号"] = dtx1.Rows[i]["ORID"].ToString();
                    dr["项次"] = dtx1.Rows[i]["SN"].ToString();
                    dr["品号"] = dtx1.Rows[i]["WAREID"].ToString();
                    dtx2 = bc.getdt("select * from wareinfo where wareid='" + dtx1.Rows[i]["WAREID"].ToString() + "'");
                    dr["EUJ料号"] = dtx2.Rows[0]["EUJ_WAREID"].ToString();
                    dr["品名"] = dtx2.Rows[0]["WNAME"].ToString();
                    dr["客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                    dr["订单数量"] = dtx1.Rows[i]["OCOUNT"].ToString();
                    dr["销售单价"] = dtx1.Rows[i]["SELLUNITPRICE"].ToString();
                    dr["税率"] = dtx1.Rows[i]["TAXRATE"].ToString();
                    dr["累计销货数量"] = 0;
                    dr["需求日期"] = dtx1.Rows[i]["NEEDDATE"].ToString();
                    dr["客户代码"] = dtx1.Rows[i]["CUID"].ToString();
                    dr["客户"] = dtx1.Rows[i]["CNAME"].ToString();
                    dr["电话"] = dtx1.Rows[i]["PHONE"].ToString();
                    dr["地址"] = dtx1.Rows[i]["ADDRESS"].ToString();
                    dr["制单人"] = dtx1.Rows[i]["MAKER"].ToString();
                    dr["制单日期"] = dtx1.Rows[i]["DATE"].ToString();
                    dtt.Rows.Add(dr);

                }

            }

            DataTable dtx41 = bc.getdt(sqlo + sql + sqlt);
            if (dtx41.Rows.Count > 0)
            {
                for (i = 0; i < dtx41.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["订单号"].ToString() == dtx41.Rows[i]["订单号"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx41.Rows[i]["项次"].ToString())
                        {
                            dtt.Rows[j]["累计销货数量"] = dtx41.Rows[i]["累计销货数量"].ToString();
                            break;
                        }

                    }
                }

            }

            return dtt;
        }
        #endregion

        private void clear()
        {

            dt = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Text7.Value = "";
            Text8.Value = "";
            Text9.Value = "";

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            bind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void PageButton_Click(object sender, EventArgs e)
        {
            GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
            bind();
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            #region btngo
            try
            {
                if (txtNum.Text == "")
                {
                    //opAndvalidate.Show("页数不能为空");
                }
                else
                {
                    int vargo = Convert.ToInt32(txtNum.Text);
                    if (vargo <= GridView1.PageCount)
                    {
                        GridView1.PageIndex = Convert.ToInt32(txtNum.Text) - 1;
                        bind();
                    }
                    else
                    {
                        hint.Value = "没有找到记录";
                    }
                }
            }
            catch (Exception)
            {
                //opAndvalidate.Show("输入格式不正确，请检查！");
            }

            #endregion
        }
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            bind();
        }

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




    }
}
