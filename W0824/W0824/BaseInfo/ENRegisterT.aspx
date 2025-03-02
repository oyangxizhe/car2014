<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ENRegisterT.aspx.cs" Inherits="W0824.BaseInfo.ENRegisterT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>新建公里数信息</title>
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
  
   
    <script language ="javascript" type ="text/javascript" src ="../../Js/dateTimePicker.js"></script>
    <style type="text/css">
        .style4
        {
            width: 89px;
        }
        .style5
        {
            width: 87px;
        }
        .style9
        {
        }
        .style10
        {
            width: 252px;
            height : 22px;
        }
        .style12
        {
            width: 85px;
        }
        .n
        {
            height: 100px;
        }
        #txtJTGTime
        {
            height: 79px;
            width: 202px;
        }
    </style>
    </head>
<body>
   <form id="form1" runat="server">
    <div> 
             &nbsp;&nbsp;<asp:Button ID="btnAdd" runat="server" Text="新建" onclick="btnAdd_Click" 
                    style="width: 45px" />
             <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" 

style="width:45px; " />
            <asp:LinkButton ID="btnExit" runat="server" onclick="btnExit_Click">返回</asp:LinkButton>
</div> <br />
    <div>
    
        <table class="n" border="1">
            <tr>
                <td colspan="2" class="Caption" style="border:0px;" >
                    新建公里数信息</td>
            </tr>
            <tr>
                <td class="style4">
                    编号</td>
                <td class="style9">
                    <asp:TextBox ID="txtID" runat="server" ReadOnly="True" Width="128px" ></asp:TextBox>
                </td>
                <td class="style12">
                    车牌号码</td>
                <td>
                    <asp:DropDownList ID="ddlPlateNum" runat="server" Height="22px" Width="154px" 
                        DataSourceID="SqlDataSource1" DataTextField="PlateNum">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:db_CARConnectionString %>" 
                        SelectCommand="SELECT * FROM [tb_CarInfo]"></asp:SqlDataSource>
                  </td>
                   <td class="style4">
                       登记日期</td>
               <td > <div style="position: relative; top: 0px; left: 0px;">
          <input id="txtENRegisterDate" type="text" runat="server" onclick ="setday(this)"/></div>
                  </td>
            </tr>
            <tr>   
               <td class="style5">
                    上月公里数</td>
                <td class="style10">
                    <asp:TextBox ID="txtCostName" runat="server" Width="128px" ></asp:TextBox>
                </td>
                <td class="style5">
                    本月公里数</td>
                <td class="style10">
                    <asp:TextBox ID="txtAmount" runat="server" ></asp:TextBox>
                </td>
                  <td class="style5">
                    本月实际公里数</td>
                <td class="style10">
                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="style12">
                    经手人</td>
                <td>
                    <asp:DropDownList ID="ddlHandler" runat="server" Height="22px" Width="154px" 
                        DataSourceID="SqlDataSource2" DataTextField="EmployeeName">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:db_CARConnectionString %>" 
                        SelectCommand="SELECT * FROM [tb_EmployeeInfo]"></asp:SqlDataSource>
                  </td>
                  </tr>
                  <tr>
                 <td class="style4">
                    备注</td>
                <td class="style9" colspan="5">
                    <asp:TextBox ID="txtRemark" runat="server" Height="68px" Width="681px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
             
            </tr>
        </table>
    </div>   
    </form>
</body>
</html>


