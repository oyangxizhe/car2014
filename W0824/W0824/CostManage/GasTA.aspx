<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GasTA.aspx.cs" Inherits="W0824.CostManage.GasTA" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑加油费用信息(核)</title>
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
>编辑加油费用信息(核)</div>
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
       <div class="c13110507" id ="Div36">
                <span class="c13110503" id ="Span7">
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">审核</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div37">
   <span class="c13110511" id ="Span8">
                 
          </span>
       </div>
                       <div class="c13110507" id ="Div38">
                <span class="c13110503" id ="Span9">
    <asp:LinkButton ID="btnReductionReconcil" runat="server" onclick="btnReductionReconcile_Click" CssClass ="">撤审</asp:LinkButton>
    </span> 
   </div>
   
                               <div class="c13110507" id ="Div41">
                  <span class="c13110503" id ="Span10">
     <asp:ImageButton ID="btnPrint" 
                 runat="server" ImageUrl="~/Image/btnprint.png" 
                      onclick="btnPrint_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div42">
   <span class="c13110511" id ="Span11">
                     (打印)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
<div class ="c13101902">
      <div class="c13101903" id ="Div39">
          用车单号 </div>
     <div class="c13122502" id ="Div40">
<input id="Text12" type="text"  runat="server"  onclick ="f13100202('Text12','')" class="c14011901" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text1" Text="必填！" runat="server" /></div>
  <div class="c13101903" id ="Div2">
   加油单号 </div>
     <div class="c13122502" id ="Div4">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c13102103" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填！" runat="server" /></div>
         <div class="c13101903" id ="Div5">
             车牌号码</div>
     <div class="c13122502" id ="Div6">
   <input id="Text2" type="text"  runat ="server" onclick ="f13100202('Text2','')"  class="c14011101" /> 
</div>
                <div class="c13101903" id ="Div1">
                                        驾驶员</div>
      <div class="c14120501" id ="Div3">
     <input id="Text3" type="text"  runat="server" onclick ="f13100202('Text3','')"   class="c14011101" />
   <asp:Label ID="Label2" runat="server"   Text="" ></asp:Label>
       </div>
           </div>
 
             <div class ="c13101902">
      <div class="c13101903" id ="Div7">
          车辆类型 </div>
      <div class="c13122502" id ="Div8">
<input id="Text4" type="text"  runat="server"    class="c13102103" /> 
         </div>         <div class="c13101903" id ="Div23">
               加油日期</div>
<div class="c13122502" id ="Div24">
   <input id="Text5" type="text"  runat ="server" class ="c13110901" onclick ="f13100202('Text5','')" readonly ="readonly"  /> 
           <span style =" margin-left :5px;">
           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Text5" Text="必填！" runat="server" />
           </span> </div>
                              
                          <div class="c13101903" id ="Div16">
                              加油站 </div>
     <div class="c13122502" id ="Div17">
     <input id="Text6" type="text"  runat="server"   class="c14012501"/> </div>
                           <div class="c13101903" id ="Div18">
                    支付方式</div>
     <div class="c14120501" id ="Div19">
                   <asp:DropDownList ID="DropDownList1" runat="server"  CssClass ="c13102104">
                     <asp:ListItem>油库支付</asp:ListItem>
                    <asp:ListItem>现金支付</asp:ListItem>  
                    </asp:DropDownList>
    </div>
      </div> 

           <div class ="c13101902">

      <div class="c13101903" id ="Div20">
          规格 </div>
     <div class="c13122502" id ="Div22">
<asp:DropDownList ID="DropDownList2" runat="server"  CssClass ="c13102104">
                                    <asp:ListItem>93#</asp:ListItem>
                                    <asp:ListItem>90#</asp:ListItem>
                                    <asp:ListItem>97#</asp:ListItem>
                                     <asp:ListItem>0#</asp:ListItem>
                    </asp:DropDownList>
         </div>
      <div class="c13101903" id ="Div28">
          油库加油量 </div>
     <div class="c13122502" id ="Div29">
<input id="Text7" type="text"  runat="server" class="c14011901" />(L)
         </div>
                <div class="c13101903" id ="Div34">
           单价 </div>
     <div class="c13122502" id ="Div35">
<input id="Text8" type="text"  runat="server" class="c13102103" /> 
          <span style =" margin-left :5px;">
             
                    </span>
         </div>
       <div class="c13101903" id ="Div25">
           金额 </div>
     <div class="c14120501" id ="Div26">
<input id="Text9" type="text"  runat="server" class="c13102103" /> 
          <span style =" margin-left :5px;">
                    </span>
         </div>
           </div>
           <div class ="c13101902">
 

      <div class="c13101903" id ="Div30">
                          经手人工号</div>
<div class="c13122502" id ="Div31">
     <input id="Text10" type="text"  runat="server" onclick ="f13100202('Text9','')"      class="c13110901" />
                     <span style =" margin-left :2px;"> <asp:Label ID="Label1" runat="server" Text="" ></asp:Label></span> 
      </div>

           </div>
           <div class ="c13122402">

          <div class="c13101903" id ="Div108">
                 备注</div>
     <div class="c13122401" id ="Div109">

         <asp:TextBox ID="TextBox1" runat="server"   TextMode="MultiLine" CssClass ="c13122403"></asp:TextBox>
         </div>
                
           </div>
           <div class ="c13101902">
                                 <div class="c13102907" id ="Div27">
                                 </div>
      <div class="c14112014" id ="Div32">
          </div>
     <div class="c13101904" id ="Div59">
        </div>
          <div class="c14112014" id ="Div60">
              数量</div>
     <div class="c13101904" id ="Div61">
   <input id="Text11" type="text"  runat ="server" class="c13102908" /> 
         </div>
                  <div class="c14112014" id ="Div62">
                      </div>
     <div class="c13101904" id ="Div63">

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
                dlgResult = window.showModalDialog("../BaseInfo/carinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                if (dlgResult != undefined) {
                    document.getElementById("Text2").value = dlgResult[1];
                    document.getElementById("Text3").value = dlgResult[5];
                    document.getElementById("Text4").value = dlgResult[3];
                    document.all("Label2").innerText = dlgResult[6];
                }

            }
            else if (obj == "Text3") {
                dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                if (dlgResult != undefined) {
                    document.getElementById("Text3").value = dlgResult[0];
                    document.all("Label2").innerText = dlgResult[1];
                }


            }
            else if (obj == "Text5") {
                dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                if (dlgResult != undefined) {


                    document.getElementById("Text5").value = dlgResult;
                }

            }
             
           else  if (obj == "Text7") {
           dlgResult = window.showModalDialog("../Gascardmanage/Gascardsearch.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {


                      document.getElementById("Text7").value = dlgResult[1];
                      document.getElementById("Text8").value = dlgResult[4];
                  }

              }
              else if (obj == "Text12") {
                  dlgResult = window.showModalDialog("../usecarmanage/departure.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text12").value = dlgResult[0];
                      document.getElementById("Text2").value = dlgResult[1];
                      document.getElementById("Text3").value = dlgResult[2];
                      document.getElementById("Text4").value = dlgResult[3];
                      document.all("Label2").innerText = dlgResult[4];
                  }

              }
  
              else {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text10").value = dlgResult[0];
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