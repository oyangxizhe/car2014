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

namespace W0824.Ascx
{
    public partial class CCarInfoT : System.Web.UI.UserControl
    {
        DataTable dt = new DataTable();
        W0824.BaseClass.BaseOperate boperate = new W0824.BaseClass.BaseOperate();
        W0824.BaseClass.OperateAndValidate opAndvalidate = new W0824.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select * from tb_CarInfo";
        protected string M_str_table = "tb_CarInfo";
        protected int M_int_judge, i;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPurDate.Value = DateTime.Now.ToShortDateString();
            txtPurDF.Value = DateTime.Now.ToShortDateString();
            txtPurDT.Value = DateTime.Now.ToShortDateString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select Year,Month,CarID from tb_CarInfo", "select * from tb_CarInfo where Year='" + year +
                "' and Month='" + month + "'", "tb_CarInfo", "CarID", "CA", "0001", txtCarID);
            btnSave.Enabled = true;
            M_int_judge = 0;
            ClearText();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            M_int_judge = 1;
           
        }
        protected void ClearText()
        {
            txtCIdentiCode.Text = "";
            txtEngineNum.Text = "";
            txtPlateNum.Text = "";
            ddlCarBrand.Text = "";
            txtCarModel.Text = "";
            ddlCarType.Text = "";
            ddlColor.Text = "";
            ddlTonnage.Text = "";
            txtPurPrice.Text = "";
            txtApplication.Text = "";
            txtPurTax.Text = "";
            txtPTCertiNo.Text = "";
            txtInsuAmount.Text = "";
            txtCarHodler.Text = "";
            txtInsuCom.Text = "";
            txtRemark.Text = "";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            DateTime varDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());

            string varCarID = txtCarID.Text.Trim();
            string varCIdentiCode = txtCIdentiCode.Text.Trim();
            string varEngineNum = txtEngineNum.Text.Trim();
            string varPlateNum = txtPlateNum.Text.Trim();
            string varCarBrand = ddlCarBrand.Text.Trim();
            string varCarModel = txtCarModel.Text.Trim();
            string varCarType = ddlCarType.Text.Trim();
            string varColor = ddlColor.Text.Trim();
            string varTonnage = ddlTonnage.Text.Trim();
            string varPurDate = Request["txtPurDate"];
            string varPurPrice = txtPurPrice.Text.Trim();
            string varApplication = txtApplication.Text.Trim();
            string varPurTax = txtPurTax.Text.Trim();
            string varPTCertiNo = txtPTCertiNo.Text.Trim();
            decimal varUseUnitPrice = decimal.Parse(txtUseUnitPrice.Text.Trim());
            string varInsuAmount = txtInsuAmount.Text.Trim();
            string varInsuDF = Request["txtInsuDF"];
            string varInsuDT = Request["txtInsuDT"];
            string varCarHodler = txtCarHodler.Text.Trim();
            string varInsuCom = txtInsuCom.Text.Trim();
            string varRemark = txtRemark.Text.Trim();

            string varTime = DateTime.Now.ToLongTimeString();

            SqlDataReader sqlread = boperate.getread("select PlateNum from tb_CarInfo where PlateNum='" + txtPlateNum.Text.Trim() + "'");
            if (M_int_judge == 0)
            {
                if (txtPlateNum.Text == "")
                {

                    opAndvalidate.Show("车牌号码不能为空！");
                }
                else if (sqlread.HasRows)
                {
                    opAndvalidate.Show("该车牌号码已经存在！！");

                    txtPlateNum.Text = "";

                }

                else
                {


                    boperate.getcom("insert into tb_CarInfo(CarID,CIdentiCode,EngineNum,PlateNum,CarBrand,CarModel,CarType,Color,Tonnage,"
                        + "PurDate,PurPrice,Application,PurTax,PTCertiNo,UseUnitPrice,InsuAmount,InsuDF,InsuDT,CarHodler,InsuCom,Remark,"
                    + "Date,Time,Year,Month) values('" + varCarID + "','" + varCIdentiCode + "','" + varEngineNum + "','" + varPlateNum +
                    "','" + varCarBrand + "','" + varCarModel + "','" + varCarType + "','" + varColor + "','" + varTonnage +
                    "','" + varPurDate + "','" + varPurPrice + "','" + varApplication + "','" + varPurTax + "','" + varPTCertiNo + "','" + varUseUnitPrice +
                    "','" + varInsuAmount + "','" + varInsuDF + "','" + varInsuDT + "','" + varCarHodler + "','" + varInsuCom + "','" + varRemark +
                    "','" + varDate + "','" + varTime + "','" + year + "','" + month + "')");

                }
            }
            sqlread.Close();
            if (M_int_judge == 1)
            {
                if (txtPlateNum.Text == "")
                {

                    opAndvalidate.Show("车牌号码不能为空！");
                }

                else
                {


                    boperate.getcom("update tb_CarInfo set CIdentiCode='" + varCIdentiCode + "',EngineNum='" + varEngineNum +
                        "',PlateNum='" + varPlateNum + "',CarBrand='" + varCarBrand + "',CarModel='" + varCarModel + "',CarType='" + varCarType +
                        "',Color='" + varColor + "',Tonnage='" + varTonnage + "',PurDate='" + varPurDate + "',PurPrice='" + varPurPrice +
                        "',Application='" + varApplication + "',PurTax='" + varPurTax + "',PTCertiNo='" + varPTCertiNo + "',UseUnitPrice='" + varUseUnitPrice +
                        "',InsuAmount='" + varInsuAmount + "',InsuDF='" + varInsuDF + "',InsuDT='" + varInsuDT + "',CarHodler='" + varCarHodler +
                        "',InsuCom='" + varInsuCom + "',Remark='" + varRemark + "' where CarID='" + varCarID + "'");

                }

            }

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("\\BaseInfo\\CarInfo.aspx");
        }
    }
}