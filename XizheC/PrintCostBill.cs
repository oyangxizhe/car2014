using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;

namespace XizheC
{
    public class PrintCostBill
    {
        basec bc = new basec();
        string sqlo = @"
SELECT A.AUID AS 单号,A.UCID AS 用车单号,A.CAID AS CAID,B.PLATENUM AS 车牌号码,C.DRIVERID AS 驾驶员,
D.ENAME AS DRIVER,A.AUDIT_DATE AS 日期,A.USE_DEPART AS USE_DEPART,A.CHARGE_DEPARTMENT AS 收费单位,
B.CARTYPE AS CARTYPE,C.AUDIT_COST AS 金额,
A.HANDLERID AS HANDLERID,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLERID) AS 经手人,
A.REMARK AS 备注,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,
A.MAKERID,A.DATE,A.YEAR,A.MONTH,C.UCID AS UCID,
CASE WHEN C.AUDIT_STATUS='Y' THEN '已审核'
ELSE '未审核'
END 
AS AUDIT_STATUS,(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=C.AUDIT_MAKERID ) AS 审核
FROM Audit A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.AUKEY=C.GEKEY
LEFT JOIN EMPLOYEEINFO D ON D.EMID=C.DRIVERID
";
        string sqlt = @"
SELECT A.GAID AS 单号,A.UCID AS 用车单号,A.CAID AS CAID,B.PLATENUM AS 车牌号码,C.DRIVERID AS DRIVERID,
D.ENAME AS 驾驶员,A.Gas_DATE AS 日期,A.Gas_STATION AS 加油站,A.PAYMENT AS 支付方式,
B.CARTYPE AS CARTYPE,
C.GAS_UNITPRICE AS 单价,
C.GASCARD_MRCOUNT AS 油库加油量,
CASE WHEN A.PAYMENT='油库支付' THEN C.GAS_UNITPRICE *C.GASCARD_MRCOUNT 
ELSE C.GAS_COST 
END
AS 金额,
CASE WHEN A.PAYMENT='现金支付'  THEN  C.Gas_COST/C.GAS_UNITPRICE
ELSE null
END
AS 数量,
C.UCID AS UCID,A.SPEC AS 规格,
A.HANDLERID AS HANDLERID,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLERID) AS HANDLER,
A.REMARK AS 备注,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=C.AUDIT_MAKERID ) AS 审核,
A.MAKERID,A.DATE,A.YEAR,A.MONTH FROM Gas A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.GAKEY=C.GEKEY
LEFT JOIN EMPLOYEEINFO D ON D.EMID=C.DRIVERID 
";
        string sqlth = @"
SELECT A.INID AS 单号,A.CAID AS CAID,B.PLATENUM AS 车牌号码,C.DRIVERID AS DRIVERID,
D.ENAME AS 驾驶员,B.CARTYPE AS CARTYPE,C.INSURE_COST AS 金额,A.INSUDF AS 日期,
A.HANDLERID AS HANDLERID,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLERID) AS 经手人,
A.REMARK AS 备注,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,C.UCID AS 用车单号,(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=C.AUDIT_MAKERID ) AS 审核,
A.MAKERID,A.DATE,A.YEAR,A.MONTH FROM INSURE A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.INKEY=C.GEKEY
LEFT JOIN EMPLOYEEINFO D ON D.EMID=C.DRIVERID
";
        string sqlf = @"
SELECT A.OTID AS 单号,A.CAID AS CAID,B.PLATENUM AS 车牌号码,C.DRIVERID AS DRIVERID,
D.ENAME AS 驾驶员,A.Other_DATE AS 日期,
B.CARTYPE AS CARTYPE,C.Other_COST AS 金额,A.COST_NAME AS 费用名称,C.UCID AS 用车单号,
A.HANDLERID AS HANDLERID,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLERID) AS 经手人,
A.REMARK AS 备注,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=C.AUDIT_MAKERID ) AS 审核,
A.MAKERID,A.DATE,A.YEAR,A.MONTH FROM Other A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.OTKEY=C.GEKEY
LEFT JOIN EMPLOYEEINFO D ON D.EMID=C.DRIVERID
      
";
        string sqlfi = @"
SELECT A.REID AS 单号,A.CAID AS CAID,B.PLATENUM AS 车牌号码,C.DRIVERID AS DRIVERID,
D.ENAME AS 驾驶员,
A.REPAIR_DATE AS 日期,A.HANDLERID AS HANDLERID,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLERID) AS 经手人,
C.REPAIR_COST AS 金额,A.REPAIR_CONTENT AS 维修内容,A.REMARK AS 备注,C.UCID AS 用车单号,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=C.AUDIT_MAKERID ) AS 审核,
A.MAKERID,A.DATE,A.YEAR,A.MONTH FROM Repair A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.REKEY=C.GEKEY
LEFT JOIN EMPLOYEEINFO D ON D.EMID=C.DRIVERID
      
";
        string sqls = @"
 SELECT A.TOID AS 单号,A.CAID AS CAID,B.PLATENUM AS 车牌号码,C.DRIVERID AS DRIVERID,
D.ENAME AS 驾驶员,A.Toll_DATE AS 日期,A.TOLL_PLACE AS 交费地点,A.PAYMENT AS 支付方式,
B.CARTYPE AS CARTYPE,
C.TOLL AS TOLL,
CASE WHEN A.PAYMENT='路卡支付' THEN C.TOLLCARD_MRCOUNT
ELSE C.Toll
END
AS 金额,
E.TOLLCARDID AS 路卡号,
C.TOLLCARD_MRCOUNT AS TOLLCARD_MRCOUNT,
A.HANDLERID AS HANDLERID,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLERID) AS 经手人,
A.REMARK AS 备注,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS MAKER,C.UCID AS 用车单号,(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=C.AUDIT_MAKERID ) AS 审核,
A.MAKERID,A.DATE,A.YEAR,A.MONTH FROM Toll A 
LEFT JOIN CARINFO B ON A.CAID=B.CAID
LEFT JOIN GODE C ON A.TOKEY=C.GEKEY
LEFT JOIN EMPLOYEEINFO D ON D.EMID=C.DRIVERID
LEFT JOIN TOLLCARDINFO E ON C.CAID=E.CAID 
";
        

        public PrintCostBill()
        {

        }
        #region audit
        public  DataTable ask(string billid)
        {
            string sql1 = "";
            DataTable dtt = new DataTable();
            if (billid.Length > 2)
            {

                if (billid.Substring(0, 2) == "AU")
                {
                    sql1 = sqlo + " where  A.AUID LIKE '%" + billid + "%'";
                }
                else if (billid.Substring(0, 2) == "GA")
                {
                    sql1 = sqlt + " where  A.GAID LIKE '%" + billid + "%'";
                }
                else if (billid.Substring(0, 2) == "IN")
                {
                    sql1 = sqlth + " where  A.INID LIKE '%" + billid + "%'";
                }
                else if (billid.Substring(0, 2) == "OT")
                {
                    sql1 = sqlf + " where  A.OTID LIKE '%" + billid + "%'";
                }
                else if (billid.Substring(0, 2) == "RE")
                {
                    sql1 = sqlfi + " where  A.REID LIKE '%" + billid + "%'";
                }
                else if (billid.Substring(0, 2) == "TO")
                {
                    sql1 = sqls + " where  A.TOID LIKE '%" + billid + "%'";
                }
                dtt = bc.getdt(sql1);
             
            }
            return dtt;
        }
        #endregion
     
    }
}


