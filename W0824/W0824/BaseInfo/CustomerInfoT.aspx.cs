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

namespace W0824.BaseInfo
{
    public partial class CustomerInfoT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        basec bc = new basec();
        W0824.Validate va = new Validate();
        int i;
        string v1, v2;
        int k;
        string c1, c2, c3, c4, c5, c6, c7, c8, c9;
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        public static string[] cukey = new string[] { "" };

        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                bindo();
            }
            catch (Exception)
            {


            }

        }
        protected void bindo()
        {

            if (!IsPostBack)
            {
                if (str1[0] != "")
                {
                    Text1.Value = str1[0];
                    str1[0] = "";
                }
                else
                {

                    Text1.Value = strE[0];
                    strE[0] = "";

                    at(@"select A.CNAME,B.CONTACT,B.PHONE,B.FAX,B.POSTCODE,B.EMAIL,B.ADDRESS,B.BOXS,B.BASEUNITPRICE from CUSTOMERINFO_MST A 
LEFT JOIN CUSTOMERINFO_DET B ON A.CUKEY=B.CUKEY where A.CUID='" + Text1.Value + "'", 0);

                }

                GridView1.DataSource = dtx();
                GridView1.DataBind();
                bind();
            }

            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");


        }
        protected void at(string sql, int n)
        {

            dt = basec.getdts(sql);
            if (dt.Rows.Count > 0)
            {
                if (n == 0)
                {
                    Text2.Value = dt.Rows[0]["CNAME"].ToString();
                }
                Text3.Value = dt.Rows[0]["PHONE"].ToString();
                Text4.Value = dt.Rows[0]["FAX"].ToString();
                Text5.Value = dt.Rows[0]["POSTCODE"].ToString();
                Text6.Value = dt.Rows[0]["EMAIL"].ToString();
                Text8.Value = dt.Rows[0]["ADDRESS"].ToString();
                Text7.Value = dt.Rows[0]["CONTACT"].ToString();
                Text9.Value = dt.Rows[0]["BOXS"].ToString();
                Text10.Value = dt.Rows[0]["BASEUNITPRICE"].ToString();

            }


        }
        protected void bind()
        {
            hint.Value = "";
            DataTable dt1 = basec.getdts("SELECT * FROM CUSTOMERINFO_DET WHERE CUID='" + Text1.Value + "'");
            GridView2.DataSource = dt1;
            GridView2.DataKeyNames = new string[] { "CUKEY" };
            GridView2.DataBind();
            GridView1.DataSource = dtx();
            GridView1.DataBind();

        }
        #region dtx
        protected DataTable dtx()
        {

            DataTable dt4 = new DataTable();
            dt4.Columns.Add("项次", typeof(string));
            dt4.Columns.Add("联系人", typeof(string));
            dt4.Columns.Add("联系电话", typeof(string));
            dt4.Columns.Add("传真号码", typeof(string));
            dt4.Columns.Add("邮政编码", typeof(string));
            dt4.Columns.Add("EMAIL", typeof(string));
            dt4.Columns.Add("送货地址", typeof(string));
            dt4.Columns.Add("吨数", typeof(string));
            dt4.Columns.Add("基础单价", typeof(string));
            for (i = 1; i <= 4; i++)
            {
                DataRow dr = dt4.NewRow();
                dr["项次"] = i;
                dr["吨数"] = "0";
                dr["基础单价"] = "0";
                dt4.Rows.Add(dr);

            }


            return dt4;
        }
        #endregion

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
            Text10.Value = "";

        }
        #region save
        protected void save()
        {
            hint.Value = "";
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            v1 = cukey[0];
            v2 = bc.getOnlyString("SELECT CNAME FROM CUSTOMERINFO_MST WHERE  CUID='" + Text1.Value + "'");
            if (Text2.Value == "")
            {
                hint.Value = "客户名称不能为空！";
            }
            else if (!bc.exists("SELECT CUID FROM CUSTOMERINFO_MST WHERE CUID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from customerinfo_MST where cname='" + Text2.Value + "'"))
                {

                    hint.Value = "该客户名称已经存在了！";

                }
                else
                {
                    basec.getcoms("insert into customerInfo_MST(CUID,CName,"
              + "CUKEY,Date,MakerID,Year,Month,Day) values('" + Text1.Value
              + "','" + Text2.Value + "','" + v1 + "','" + varDate
              + "','" + varMakerID + "','" + year + "','" + month + "','" + day + "')");


                }
            }
            else if (v2 != Text2.Value)
            {
                if (bc.exists("select * from customerinfo_MST where cname='" + Text2.Value + "'"))
                {
                    hint.Value = "该客户名称已经存在了！";
                }
                else
                {

                    basec.getcoms("UPDATE CUSTOMERINFO_MST SET CNAME='" + Text2.Value + "',CUKEY='" + v1 +
                 "' ,MAKERID='" + varMakerID + "',DATE='" + varDate + "'WHERE CUID='" + Text1.Value + "'");

                }

            }
            else
            {
                basec.getcoms("UPDATE CUSTOMERINFO_MST SET CNAME='" + Text2.Value + "',CUKEY='" + v1 +
               "' ,MAKERID='" + varMakerID + "',DATE='" + varDate + "'WHERE CUID='" + Text1.Value + "'");


            }


        }
        #endregion

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

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                string id = GridView2.DataKeys[e.RowIndex][0].ToString();

                if (bc.exists("SELECT * FROM CUSTOMERINFO_MST WHERE CUKEY='" + id + "'"))
                {
                    hint.Value = "该地址为该客户的默认地址，如果要删除改默认地址请指定其它地址为该客户的送货地址!";
                }

                else if (bc.exists("SELECT * FROM UCAPPLY_DET WHERE CUKEY='" + id + "'"))
                {
                    hint.Value = "该地址在用车单信息中存在不允许删除!";
                }
                else
                {

                    string strSql = "DELETE FROM CUSTOMERINFO_DET WHERE CUKEY='" + id + "'";
                    basec.getcoms(strSql);
                    GridView2.EditIndex = -1;
                    bind();

                }
            }
            catch (Exception)
            {


            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            try
            {
                cukey[0] = "";
                string key = GridView2.DataKeys[GridView2.SelectedIndex].Values[0].ToString();
                at(@"select * from CUSTOMERINFO_DET where CUKEY='" + key + "' ", 1);
                cukey[0] = key;
            }
            catch (Exception)
            {

            }

        }


        #region addDeliveryAddress
        protected void addDeliveryAddress()
        {


            hint.Value = "";
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");


            for (k = 0; k < 4; k++)
            {

                c1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                c2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                c3 = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;
                c4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                c5 = ((TextBox)GridView1.Rows[k].Cells[4].FindControl("TextBox5")).Text;
                c6 = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
                c7 = ((TextBox)GridView1.Rows[k].Cells[6].FindControl("TextBox7")).Text;
                c8 = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                c9 = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                if (c1 != "")
                {

                    if (juage1(k))
                    {

                        string key = bc.numYMD(20, 12, "000000000001", "SELECT * FROM CUSTOMERINFO_DET", "CUKEY", "CU");
                        basec.getcoms(@"INSERT INTO CUSTOMERINFO_DET(CUKEY,CUID,CONTACT,PHONE,FAX,POSTCODE,EMAIL,ADDRESS,DEPART,
                    MAKERID,DATE,YEAR,MONTH,DAY,BOXS,BASEUNITPRICE) VALUES 
                    ('" + key + "','" + Text1.Value + "','" + c1 + "','" + c2 + "','" + c3 + "','" + c4 + "','" + c5 + "','" + c6 +
                        "','" + c7 + "','" + varMakerID + "','" + varDate + "','" + year + "','" + month + "','" + day + "','" + c8 + "','" + c9 + "')");


                    }
                }
            }
            bind();

        }
        #endregion

        #region juage1()
        private bool juage1(int k)
        {
            string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
            string v2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
            string v3 = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;
            string v4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
            string v5 = ((TextBox)GridView1.Rows[k].Cells[4].FindControl("TextBox5")).Text;
            string v6 = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
            string v7 = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
            string v8 = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
            bool ju = true;
            if (bc.checkphone(v2) == false)
            {
                ju = false;
                hint.Value = "电话号码只能输入数字！";

            }
            else if (bc.checkphone(v3) == false)
            {
                ju = false;
                hint.Value = "传真号码只能输入数字！";

            }
            else if (bc.checkphone(v4) == false)
            {
                ju = false;
                hint.Value = "邮编只能输入数字！";

            }
            else if (bc.checkEmail(v5) == false)
            {
                ju = false;
                hint.Value = "邮箱地址只能输入数字字母的组合！";

            }
            else if (v6 == "")
            {

                ju = false;
                hint.Value = "地址不能为空！";

            }
            else if (v7 == "")
            {

                ju = false;
                hint.Value = "吨数不能为空！";

            }
        
            else if (v8 == "")
            {

                ju = false;
                hint.Value = "基础单价不能为空！";

            }
            else if (bc.yesno(v8) == 0)
            {

                ju = false;
                hint.Value = bc.ErrowInfo;

            }
            return ju;

        }
        #endregion
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM CUSTOMERINFO_MST", "CUID", "CU");
            if (var1 == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
                return;
            }
            Text1.Value = var1;
            bind();
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

        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../BaseInfo/CustomerInfo.aspx" + n2);
        }

        protected void btnAddDeliveryAddress_Click(object sender, EventArgs e)
        {
           
            try
            {
                addDeliveryAddress();
            }
            catch (Exception)
            {

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            for (k = 0; k < 4; k++)
            {
                ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[4].FindControl("TextBox5")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text = "";
            }
        }
    }
}
