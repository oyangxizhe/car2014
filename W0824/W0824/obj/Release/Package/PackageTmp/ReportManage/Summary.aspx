<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="W0824.ReportManage.Summary" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>费用汇总查询</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="" />
<meta name ="keywords" content ="" />
   <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
      <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
 <base target ="_self" /> 
    </head>
<body>  
    <form id="form1" runat="server">
        <input id="hint" type="hidden"  runat="server" />
        <input id="x" type="hidden"  runat="server" />
          <input id="x1" type="hidden"  runat="server" />
       <div >
                  <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;费用汇总查询</div>
     <div class="c13101907" id ="Div10">
 </div>
     </div>
        </div>
<div class ="c13110501">
 <div class="c13110502" id ="Div4">
   <span class="c13110508" id ="Span1">
       
          </span>
       </div>
       <div class="c13110510" id ="Div7">
   <span class="c13110511" id ="Span3">
           </span>
       </div>
       <div class="c13110504" id ="Div19">
<span id="i13052904"  class ="c13110505"  >
           搜索条件</span> </div>
          <div class="c13110506" id ="Div20">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div5">
                                                        客户名称：</div>
     <div class="c14111903" id ="Div6">
            <input id="Text1" type="text"  runat ="server" class="c14111902" /></div>
                            <div class="c13110104" id ="Div1">
                                用车单号
                            </div>
     <div class="c14111903" id ="Div14">
     <input id="Text2" type="text"  runat ="server" class="c14111902" />
                        </div>
           </div>
           <div class ="c13110105">
                        <div class="c13110104" id ="Div2">
                            日期期间：</div>
     <div class="c14111903" id ="Div8">
     <span style =" margin-right :8px;">
     <input id="StartDate" type="text" runat="server" onclick ="f13100202('StartDate')" class ="c14111902" />
   </span> </div>
          <div class="c13110104" id ="Div12">
         <span class="c14111901">～</span>
                 </div>
     <div class="c14111903" id ="Div13">
  <input id="EndDate" type="text" runat="server" onclick ="f13100202('EndDate')" class ="c14111902" /></div>
     
           </div>
</div>
         <div class="c13110507" id ="Div21">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnSearch" 
                 runat="server" ImageUrl="~/Image/btnSearch.png" Width="60px" 
                      onclick="btnSearch_Click" />
          </span>
   </div>
          <div class="c13110510" id ="Div3">
   <span class="c13110505" id ="Span4">
              (搜索)
              </span>
       </div>
                 <div class="c13110502" id ="Div53">
   <span class="c13110508" id ="Span11">
       <asp:ImageButton ID="btnEXCEL" runat="server" ImageUrl="~/Image/Excel_big.png" 
              onclick="btnEXCEL_Click"/>
          </span>
       </div>
       <div class="c13110510" id ="Div54">
   <span class="c13110511" id ="Span12">
             <asp:Label ID="Label3" runat="server" Text="(导出)"></asp:Label>         </span>
       </div> 
    </div>      
    
    <div class ="c13112601">
       <div class="c14031301" id ="Div25">
           &nbsp;</div>

          <div class="c13112603" id ="Div26">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div27">
                            车牌号码：</div>
     <div class="c14111903" id ="Div28">
            <input id="Text3" type="text"  runat ="server" class="c14111902" /></div>
                            <div class="c13110104" id ="Div29">
                                驾驶员：</div>
     <div class="c14111903" id ="Div30">
     <input id="Text4" type="text"  runat ="server" class="c14111902" />
                            </div>
           </div>
           
</div>
    </div>
                      <div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div>

             <div id="i13103001" class ="c13111201">
          
                    <asp:GridView ID="GridView1" runat="server" 
                    AllowPaging="false" 
                    AllowSorting="false"   
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                         CssClass ="c14112606"
                   
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns >
                       <asp:BoundField DataField="车牌号码" HeaderText="车牌号码" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                      <asp:BoundField DataField="用车单号" HeaderText="用车单号" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                      <asp:BoundField DataField="驾驶员" HeaderText="驾驶员" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="客户名称" HeaderText="客户名称" >
                              <ItemStyle Width="300px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="300px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="收货地址" HeaderText="收货地址" >
                              <ItemStyle Width="100px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="送货地址" HeaderText="发货地址" >
                              <ItemStyle Width="100px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="运费收入" HeaderText="运费收入"  DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                   <asp:BoundField DataField="排班收入" HeaderText="排班收入"  DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                             <asp:BoundField DataField="维修费用" HeaderText="维修费用" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                             <asp:BoundField DataField="加油费用" HeaderText="加油费用" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                         <asp:BoundField DataField="油库耗油" HeaderText="油库耗油" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="油库费用" HeaderText="油库费用" DataFormatString="{0:0.00}">
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                     <asp:BoundField DataField="轮胎费用" HeaderText="轮胎费用" DataFormatString="{0:0.00}" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a " HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                <asp:BoundField DataField="保险费用" HeaderText="罚款费用" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                <asp:BoundField DataField="年审费用" HeaderText="加水费用" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                <asp:BoundField DataField="过路费用" HeaderText="过路费用" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                    <asp:BoundField DataField="路卡费用" HeaderText="路卡费用" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                  <asp:BoundField DataField="保养费用" HeaderText="保养费用" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                <asp:BoundField DataField="其它费用" HeaderText="其它费用" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                 <asp:BoundField DataField="费用合计" HeaderText="费用合计"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                <asp:BoundField DataField="实现利润" HeaderText="实现利润"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                 <asp:BoundField DataField="公里数" HeaderText="公里数"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                <asp:BoundField DataField="出车吨数" HeaderText="出车吨数"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="回车吨数" HeaderText="回车吨数"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div>

          <div class ="c13102303" style ="display :none">
          <span class="c13102304"><asp:Label ID="lblRecordCount" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:Label ID="lblPageCount" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:Label ID="lblCurrentIndex" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:LinkButton ID="btnFirst" runat="server" CommandArgument="First" onclick="PageButton_Click">首页</asp:LinkButton></span>
          <span class="c13102304"><asp:LinkButton ID="btnPrev" runat="server" CommandArgument="Prev" onclick="PageButton_Click">上一页</asp:LinkButton></span>  
          <span class="c13102304"><asp:LinkButton ID="btnNext" runat="server" CommandArgument="Next" onclick="PageButton_Click">下一页</asp:LinkButton></span>
          <span class="c13102304"><asp:LinkButton ID="btnLast" runat="server" CommandArgument="Last" onclick="PageButton_Click">尾页</asp:LinkButton></span>
          <span class="c13102304"> 转到</span>
          <span class="c13102304"><asp:TextBox ID="txtNum" runat="server"  Width="73px"></asp:TextBox></span>
          <span class="c13102304"> 页</span>
          <span class="c13102304"> <asp:Button ID="btngo" runat="server"  Text="GO！"   style="width:45px" onclick="btngo_Click" /></span>
               
</div>
<script type="text/javascript" language="javascript">
    function f13100302(result) {
        if (window.opener != undefined) {
            //for chrome
            window.opener.returnValue = result;
        }
        else {
            window.returnValue = result;
        }
        window.close();
    }
    window.onload = function onload1() {
        var Invocation = document.getElementById("hint").value;
        var Invocation1 = document.getElementById("x").value;
        var Invocation2 = document.getElementById("x1").value;
        if (Invocation != "") {
            document.getElementById("i13102301").style.display = "block";
            document.all("prompt").innerText = Invocation;
        }
        else {
            document.getElementById("i13102301").style.display = "none";
        }
        if (Invocation1 != "") {
            document.getElementById("i13103001").style.display = "block";
         

        }
        else {
            document.getElementById("i13103001").style.display = "none";
         

        }
        if (Invocation2 != "") {
            //document.getElementById("i13111201").style.display = "block";

        }
        else {
            //document.getElementById("i13111201").style.display = "none";
        }

    }
    function f13100202(obj) {
        var dlgResult;

        if (obj == "StartDate") {
            dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
            if (dlgResult != undefined) {


                document.getElementById("startdate").value = dlgResult;
            }

        }
        else if (obj == "EndDate") {
            dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
            if (dlgResult != undefined) {


                document.getElementById("enddate").value = dlgResult;
            }
        }
        else if (obj == "Text1") {

            dlgResult = window.showModalDialog("../PurchaseManage/Supplierinfo.aspx", window, "dialogWidth:960px; dialogHeight:480px; status:0");
            if (dlgResult != undefined) {

                //document.getElementById("Text2").value = dlgResult[0];
                document.getElementById("Text1").value = dlgResult[1];
                //document.getElementById("Text6").value = dlgResult[2];
            }
        }
    }
    function enter2tab(e) {
        if (window.event.keyCode == 13) window.event.keyCode = 9
    }
    document.onkeydown = enter2tab;
</script>
    </form>
</body>
</html>
