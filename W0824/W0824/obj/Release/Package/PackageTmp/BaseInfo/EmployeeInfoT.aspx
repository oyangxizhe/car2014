<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeInfoT.aspx.cs" Inherits="W0824.BaseInfo.EmployeeInfoT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭Ա����Ϣ</title>
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
>�༭Ա����Ϣ</div>
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
                  (����)
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
(����)
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
                     (�˳�)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div2">
   Ա����� </div>
     <div class="c13122502" id ="Div4">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c13102103" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></div>
         <div class="c13101903" id ="Div5">
             ����</div>
     <div class="c13122502" id ="Div6">
   <input id="Text2" type="text"  runat ="server" class ="c13110901" /> 
           <span style =" margin-left :8px;">
           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text2" Text="����" runat="server" />
           </span> </div>
                <div class="c13101903" id ="Div1">
                    �ձ�</div>
     <div class="c13122502" id ="Div3">
                   <asp:DropDownList ID="DropDownList1" runat="server"  CssClass ="c13102104">
                     <asp:ListItem></asp:ListItem>
                          <asp:ListItem>��</asp:ListItem>
                         <asp:ListItem>Ů</asp:ListItem>
                     
                                   
                    </asp:DropDownList>
    </div>
         <div class="c13101903" id ="Div7">
          ���� </div>
     <div class="c14120501" id ="Div8">
     <span style =" margin-right :8px;">
<input id="Text3" type="text"  runat="server"    class="c13102103" />
                    
                    </span> </div>
           </div>
             <div class ="c13101902">
 
                          <div class="c13101903" id ="Div16">
                              ���� </div>
     <div class="c13122502" id ="Div17">
     <span style =" margin-right :8px;">
   <input id="Text4" type="text"  runat="server"    class="c13102103" />
       
                    </span> </div>
                             <div class="c13101903" id ="Div18">
                                 ����</div>
     <div class="c13122502" id ="Div19">
    <asp:DropDownList ID="DropDownList2" runat="server"  CssClass ="c13102104">
                     <asp:ListItem></asp:ListItem>
                          <asp:ListItem>������</asp:ListItem>
                         <asp:ListItem>ҵ��</asp:ListItem>
                         <asp:ListItem>���񲿲����</asp:ListItem>
                         <asp:ListItem>������Ϣ��</asp:ListItem>
                         <asp:ListItem>���������ܿ�</asp:ListItem>
                         <asp:ListItem>�������ɹ���</asp:ListItem>
                         <asp:ListItem>�������ʲĿ�</asp:ListItem>
                         <asp:ListItem>���̲�</asp:ListItem>
                         <asp:ListItem>Ʒ����</asp:ListItem>
                         <asp:ListItem>�������豸��</asp:ListItem>
                         <asp:ListItem>������������</asp:ListItem>
                         <asp:ListItem>�������¿�</asp:ListItem>
                         <asp:ListItem>���������</asp:ListItem>
                         <asp:ListItem>��ϵ��</asp:ListItem>
                         <asp:ListItem>������</asp:ListItem>
                          <asp:ListItem>��ԦԱ</asp:ListItem>
                          <asp:ListItem>������</asp:ListItem>
                                   
                    </asp:DropDownList>
      </div>
       <div class="c13101903" id ="Div20">
          ְ�� </div>
     <div class="c13122502" id ="Div22">
    <asp:DropDownList ID="DropDownList3" runat="server"  CssClass ="c13102104">
                           <asp:ListItem ></asp:ListItem>
                    <asp:ListItem>ְԱ</asp:ListItem>
                                    <asp:ListItem>����(�Ƴ�)</asp:ListItem>
                                    <asp:ListItem>�γ�(����)</asp:ListItem>
                                    <asp:ListItem>����</asp:ListItem>
                                    <asp:ListItem>���ܾ���</asp:ListItem>
                                    <asp:ListItem>�ܾ���</asp:ListItem>
                                     <asp:ListItem>����</asp:ListItem>
                                    <asp:ListItem>���³�</asp:ListItem>
                                   
                    </asp:DropDownList>
         </div>
         <div class="c13101903" id ="Div23">
             ���֤��</div>
     <div class="c14120501" id ="Div24">
   <input id="Text5" type="text"  runat ="server" class="c13102103" /> 
     <span style =" margin-left :8px;">
       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text5" Text="����" runat="server" /></span> 
        </div>
      </div> 

           <div class ="c13101902">
     
                <div class="c13101903" id ="Div25">
                    ��������</div>
     <div class="c13122502" id ="Div26">
               <input id="Text6" type="text"  runat="server" onclick ="f13100202('Text6')"  readonly ="readonly"  class="c13102103" />    
    </div>
      <div class="c13101903" id ="Div27">
          ��ͥסַ </div>
     <div class="c14032101" id ="Div28">
           <input id="Text7" type="text"  runat="server"  readonly ="readonly" class="c14112004"/></div>
           </div>
           <div class ="c13101902">
    
         <div class="c13101903" id ="Div29">
             ���˵绰</div>
     <div class="c13122502" id ="Div30">
   <input id="Text8" type="text"  runat ="server" class="c13102103" /> 
      <span style =" margin-left :8px;">
       </span> 
        </div>
 
           </div>
           
           <div class ="c13122402">

          <div class="c13101903" id ="Div108">
                 ��ע</div>
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
              if (obj == "Text6") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {


                      document.getElementById("Text6").value = dlgResult;
                  }

              }
              else if (obj == "Text7") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {


                      document.getElementById("Text7").value = dlgResult;
                  }

              }

              else {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text9").value = dlgResult[0];
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
