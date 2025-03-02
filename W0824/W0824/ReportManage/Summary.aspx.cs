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

namespace W0824.ReportManage
{
    public partial class Summary : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtx2 = new DataTable();
        DataTable dtx4 = new DataTable();
        basec bc = new basec();
   
        W0824.Validate va = new Validate();
      
        protected void Page_Load(object sender, EventArgs e)
        {
             if (va.returnb() == true)
            Response.Redirect("\\Default.aspx");
             bind();
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
            string v7 = Text1.Value;
            string v8 = Text2.Value;
            string v9 = Text3.Value;
            string v10 = Text4.Value;
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
            if (v7 != "" && v8 == "" && v9 == "" && v10 == "" && v1=="" && v2=="")
            {

                showdata(" WHERE  E.CNAME LIKE '%" + Text1.Value + "%' AND  ", "", "");
            }
            else if (v7 == "" && v8 != "" && v9 == "" && v10 == "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE  D.UCID LIKE '%" + Text2.Value +"%' AND  ", "", "");
            }
            else if (v7 == "" && v8 == "" && v9 != "" && v10 == "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE  B.PLATENUM LIKE '%" + Text3.Value + "%' AND  ", "", "");
            }
            else if (v7 == "" && v8 == "" && v9 == "" && v10 != "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE  C.ENAME LIKE '%" + Text4.Value + "%' AND  ", "", "");
            }
            else if (v7 == "" && v8 == "" && v9 == "" && v10 == "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE   A. DATE BETWEEN  '" + v5 + "'AND '" + v6 +"'  AND  ", "", "");
            }
            else if (v7 != "" && v8 != "" && v9 == "" && v10 == "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE  E.CNAME LIKE '%" + Text1.Value + "%' AND D.UCID LIKE '%" + Text2.Value +
                    "%'   AND  ", "", "");
            }
            else if (v7 != "" && v8 == "" && v9 != "" && v10 == "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE  E.CNAME LIKE '%" + Text1.Value + "%' AND  B.PLATENUM LIKE '%" + Text3.Value + "%'  AND  ", "", "");
            }
            else if (v7 != "" && v8 == "" && v9 == "" && v10 != "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE  E.CNAME LIKE '%" + Text1.Value + "%' AND  C.ENAME LIKE '%" + Text4.Value + "%'  AND  ", "", "");
            }
            else if (v7 != "" && v8 == "" && v9 == "" && v10 == "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE  E.CNAME LIKE '%" + Text1.Value + "%' AND A. DATE BETWEEN  '" + v5 + "'AND '" + v6 + "'  AND  ", "", "");
            }
            else if (v7 == "" && v8 != "" && v9 != "" && v10 == "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE  D.UCID LIKE '%" + Text2.Value +
                    "%' AND  B.PLATENUM LIKE '%" + Text3.Value + "%'  AND  ", "", "");
            }
            else if (v7 == "" && v8 != "" && v9 == "" && v10 != "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE  D.UCID LIKE '%" + Text2.Value +
                    "%' AND C.ENAME LIKE '%" + Text4.Value + "%'  AND  ", "", "");
            }
            else if (v7 == "" && v8 != "" && v9 == "" && v10 == "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE  D.UCID LIKE '%" + Text2.Value +
                    "%' AND  A. DATE BETWEEN  '" + v5 + "'AND '" + v6 +"'  AND  ", "", "");
            }
            else if (v7 == "" && v8 == "" && v9 != "" && v10 != "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE  B.PLATENUM LIKE '%" + Text3.Value + "%' AND C.ENAME LIKE '%" + Text4.Value + "%' AND  ", "", "");
            }
            else if (v7 == "" && v8 == "" && v9 != "" && v10 == "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE  B.PLATENUM LIKE '%" + Text3.Value + "%' AND  A. DATE BETWEEN  '" + v5 + "'AND '" + v6 +
                    "' AND  ", "", "");
            }
            else if (v7 == "" && v8 == "" && v9 == "" && v10 != "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE  C.ENAME LIKE '%" + Text4.Value + "%' AND  A. DATE BETWEEN  '" + v5 + "'AND '" + v6 +
                    "' AND  ", "", "");
            }
            else if (v7 != "" && v8 != "" && v9 != "" && v10 == "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE E.CNAME LIKE '%" + Text1.Value + "%' AND D.UCID LIKE '%" + Text2.Value +
                    "%' AND  B.PLATENUM LIKE '%" + Text3.Value + "%' AND  ", "", "");
            }
            else if (v7 != "" && v8 != "" && v9 == "" && v10 != "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE E.CNAME LIKE '%" + Text1.Value + "%' AND D.UCID LIKE '%" + Text2.Value +
                    "%' AND  C.ENAME LIKE '%" + Text4.Value + "%' AND  ", "", "");
            }
            else if (v7 != "" && v8 != "" && v9 == "" && v10 == "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE E.CNAME LIKE '%" + Text1.Value + "%' AND D.UCID LIKE '%" + Text2.Value +
                    "%' AND  A. DATE BETWEEN  '" + v5 + "'AND '" + v6 +"'   AND  ", "", "");
            }
            else if (v7 != "" && v8 == "" && v9 != "" && v10 != "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE E.CNAME LIKE '%" + Text1.Value + "%' AND B.PLATENUM LIKE '%" + Text3.Value +
                    "%' AND C.ENAME LIKE '%" + Text4.Value + "%' AND  ", "", "");
            }
            else if (v7 != "" && v8 == "" && v9 != "" && v10 == "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE E.CNAME LIKE '%" + Text1.Value + "%' AND B.PLATENUM LIKE '%" + Text3.Value +
                    "%' AND A. DATE BETWEEN  '" + v5 + "'AND '" + v6 +
                    "'  AND  ", "", "");
            }
            else if (v7 != "" && v8 == "" && v9 == "" && v10 != "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE E.CNAME LIKE '%" + Text1.Value + "%' AND C.ENAME LIKE '%" + Text4.Value +
                    "%' AND A. DATE BETWEEN  '" + v5 + "' AND  '" + v6 + "'  AND  ", "", "");
            }
            else if (v7 == "" && v8 != "" && v9 != "" && v10 != "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE D.UCID LIKE '%" + Text2.Value +
                    "%'  AND C.ENAME LIKE '%" + Text4.Value +
                    "%' AND  B.PLATENUM LIKE '%" + Text3.Value + "%'   AND  ", "", "");
            }
            else if (v7 == "" && v8 != "" && v9 != "" && v10 == "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE D.UCID LIKE '%" + Text2.Value +
                    "%'  AND  A. DATE BETWEEN  '" + v5 + "'AND '" + v6 +
                    "'  AND  B.PLATENUM LIKE '%" + Text3.Value + "%'   AND  ", "", "");
            }
            else if (v7 == "" && v8 == "" && v9 != "" && v10 != "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE  C.ENAME LIKE '%" + Text4.Value + "%' AND  A. DATE BETWEEN  '" + v5 + "'AND '" + v6 +
                    "'  AND  B.PLATENUM LIKE '%" + Text3.Value + "%'   AND  ", "", "");
            }
            else if (v7 != "" && v8 != "" && v9 != "" && v10 != "" && v1 == "" && v2 == "")
            {

                showdata(" WHERE  E.CNAME LIKE '%" + Text1.Value + "%' AND D.UCID LIKE '%" + Text2.Value +
                    "%' AND  B.PLATENUM LIKE '%" + Text3.Value + "%' AND C.ENAME LIKE '%" + Text4.Value + "%'   AND  ", "", "");
            }
            else if (v7 != "" && v8 != "" && v9 != "" && v10 == "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE   A. DATE BETWEEN  '" + v5 + "'AND '" + v6 +
                    "'  AND E.CNAME LIKE '%" + Text1.Value + "%' AND D.UCID LIKE '%" + Text2.Value +
                    "%' AND  B.PLATENUM LIKE '%" + Text3.Value + "%'  AND  ", "", "");
            }
            else if (v7 == "" && v8 != "" && v9 != "" && v10 != "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE  A. DATE BETWEEN  '" + v5 + "'AND '" + v6 +
                    "' AND D.UCID LIKE '%" + Text2.Value +
                    "%' AND  B.PLATENUM LIKE '%" + Text3.Value + "%' AND C.ENAME LIKE '%" + Text4.Value + "%' AND  ", "", "");
            }
            else if (v7 != "" && v8 != "" && v9 != "" && v10 != "" && v1 != "" && v2 != "")
            {

                showdata(" WHERE  A. DATE BETWEEN  '" + v5 + "'AND '" + v6 +
                    "'  AND E.CNAME LIKE '%" + Text1.Value + "%' AND D.UCID LIKE '%" + Text2.Value +
                    "%' AND  B.PLATENUM LIKE '%" + Text3.Value + "%' AND C.ENAME LIKE '%" + Text4.Value + "%' AND   ", "", "");
            }
          else
          {
              showdata(" WHERE ", "", "");


          }
            nextpage();
        
        }
        #endregion
        #region showdata
        protected void showdata(string sql,string startdate,string enddate)
        {
            PrintSummary print = new PrintSummary();
           
            dt = print.ask(sql,startdate ,enddate );
            if (dt.Rows.Count > 1)
            {

                x1.Value = Convert.ToString(1);
                x.Value = Convert.ToString(1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            
         
            }
            else
            {
                hint.Value = "没有找到记录";
                GridView1.DataSource = null;

            }

        }
        #endregion
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "车牌号码" };
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


        private void clear()
        {

            dt = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
           
            try
            {
                bind(); 
               
            }
            catch (Exception)
            {

            }
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

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
       
          
        }
        protected void btnEXCEL_Click(object sender, ImageClickEventArgs e)
        { //print();
            //excel();
            hint.Value = "购买后即可使用";
            try
            {
               
            }
            catch (Exception)
            {


            }

        }
        protected void excel()
        {


            if (GridView1.Rows.Count > 0)
            {
                basec bc = new basec();
                bc.dgvtoExcel(GridView1, Server .MapPath ("..\\费用汇总表"));
                hint.Value = bc.ErrowInfo;
            }
            else
            {
                hint.Value = "没有数据可导出！";
            }

        }
        protected void excelo()
        {

            GridView gvOrders = new GridView();
            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "GB2312";
            Response.AppendHeader("content-disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode("费用汇总表", System.Text.Encoding.UTF8) + ".xls\"");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");  //设置输出流为简体中文        
            this.EnableViewState = false;
            Response.Write("<meta http-equiv=Content-Type content=\"text/html; charset=GB2312\">");
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);
            gvOrders.AllowPaging = false;
            gvOrders.AllowSorting = false;
            gvOrders.DataSource = dt;
            gvOrders.DataBind();
            gvOrders.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.End();

        }
        protected void print()
        {

            //string v5 = "", v6 = "";
            string v1 = StartDate.Value;
            string v2 = EndDate.Value;
            if (!bc.juagedate(v1, v2))
            {
                hint.Value = bc.ErrowInfo;
                return;
            }
            
            if (v1 == "" && v2 == "")
            {

                hint.Value = "需输入打印期间日期！";
            }
            else
            {

               /* DateTime v3 = Convert.ToDateTime(v1);
                DateTime v4 = Convert.ToDateTime(v2);
                v5 = v3.ToString("yyyy/MM/dd").Replace("-", "/") + " 00:00:00";
                v6 = v4.ToString("yyyy/MM/dd").Replace("-", "/") + " 23:59:59";
               string v7 = v3.ToString("yyyy/MM/dd").Replace("-", "/");
               string v8 = v4.ToString("yyyy/MM/dd").Replace("-", "/");

               String[] Carstr = new string[] { Text1.Value, Text2.Value, Text3.Value, Text4.Value, v5, v6, v7, v8 };
                W0824.ReportManage.CRVSummary.Array= Carstr;
                Response.Redirect("../ReportManage/CRVSummary.aspx");*/

            }


        }


    }
}
