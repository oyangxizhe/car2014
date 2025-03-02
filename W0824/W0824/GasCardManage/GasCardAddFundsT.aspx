<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GasCardAddFundsT.aspx.cs" Inherits="W0824.GasCardManage.GasCardAddFundsT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑加油卡信息</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="" />
<meta name ="keywords" content ="" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
    </head>
<body >
   <form id="form1" runat="server">
   <input id="hint" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;编辑加油卡冲值信息</div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
    <div class ="c13110501">
      <div class="c13110502" id ="Div14">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png"    onclick="btnAdd_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div12">
   <span class="c13110511" id ="Span4">
                  (新增)
          </span>
       </div>
             <div class="c13110502" id ="Div11">
   <span class="c13110508" id ="Span3">
       <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Image/btnSave.png" 
                     onclick="btnSave_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div13">
   <span class="c13110511" id ="Span5">
                  (保存)
          </span>
       </div>
          
         <div class="c13110507" id ="Div21">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div15">
   <span class="c13110511" id ="Span6">
                     (退出)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div2">
          单号 </div>
     <div class="c13122502" id ="Div4">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c13102103" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填" runat="server" /></div>
         <div class="c13101903" id ="Div5">
             卡号</div>
     <div class="c13122502" id ="Div6">
   <input id="Text2" type="text"  runat ="server" class ="c13110901" /> 
       
           <a  href="javascript:f13100202('Text2','');">
         选择</a> 
 </div>
                <div class="c13101903" id ="Div1">
                    车牌号码</div>
     <div class="c13122502" id ="Div3">            
   <input id="Text3" type="text"  runat="server"    class ="c13110901" />
  
    </div>
          <div class="c13101903" id ="Div7">
          冲值金额 </div>
     <div class="c13122502" id ="Div8">
     <span style =" margin-right :8px;">
<input id="Text4" type="text"  runat="server"    class ="c13110901" />
   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text4" Text="必填" runat="server" />                 
                    </span> </div>
           </div>
             <div class ="c13101902">

                          <div class="c13101903" id ="Div16">
                              冲值日期 </div>
     <div class="c13122502" id ="Div17">
     <span style =" margin-right :8px;">
   <input id="Text5" type="text"  runat="server" onclick ="f13100202('Text5')" readonly="readonly" class ="c13110901" />
       
                    </span> </div>
                             <div class="c13101903" id ="Div18">
                                 经手人</div>
     <div class="c13111503" id ="Div19">
     <input id="Text6" type="text"  runat="server"    class ="c14112502" />
        <span style =" margin-left :2px; margin-right :10px;"><a  href="javascript:f13100202('Text6','');">
         选择</a></span>
                   <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
      </div>
      </div> 
           <div class ="c13122402">
          <div class="c13101903" id ="Div108">
                 备注</div>
     <div class="c13122401" id ="Div109">
         <asp:TextBox ID="TextBox1" runat="server"   TextMode="MultiLine" CssClass ="c13122403"></asp:TextBox>
         </div>
           </div>
      <script type ="text/javascript" >
          window.onload = function onload1() {
              var Invocation = document.getElementById("hint").value;
              if (Invocation != "") {
                  document.getElementById("i13102301").style.display = "block";
                  document.all("prompt").innerText = Invocation;
              }
              else {

                  document.getElementById("i13102301").style.display = "none";
              }
          }
          function f13100202(obj, obj1) {
              var dlgResult;
              if (obj == "Text2") {
                  dlgResult = window.showModalDialog("../gascardmanage/gascardinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text2").value = dlgResult[1];
                      document.getElementById("Text3").value = dlgResult[2];
                  }
              }
             else  if (obj == "Text3") {
                  dlgResult = window.showModalDialog("../BaseInfo/carinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text3").value = dlgResult[1];
                  }

              }
              else if (obj == "Text5") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text5").value = dlgResult;
                  }
              }

              else {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text6").value = dlgResult[0];
                      document.all("Label1").innerText = dlgResult[1];
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
