<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRVSummary.aspx.cs" Inherits="W0824.ReportManage.CRVSummary" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style ="display :none ">
    <object id="CrystalPrintControl" classid="CLSID:BAEE131D-290A-4541-A50A-8936F159563A"

codebase="http://127.0.0.1/PrintControl.cab" #Version="10,5,1,2285"></object>
    </div>
 <div style ="height:300px">    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="true" /></div>

 
    </form>
</body>
</html>
