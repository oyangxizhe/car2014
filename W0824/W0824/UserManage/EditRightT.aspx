<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRightT.aspx.cs" Inherits="W0824.UserManage.EditRightT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭�û�Ȩ��</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="���������ϵͳ" />
<meta name ="keywords" content ="���������ϵͳ,������������,ERP,С΢��ҵ����ϵͳ,ϣ�����" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
    </head>
<body >
   <form id="form1" runat="server">
   <input id="hint" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
>�༭�û�Ȩ��</div>
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
          
         <div class="c13110507" id ="Div21" >
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div15" >
   <span class="c13110511" id ="Span6">
                     (�˳�)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
                <div class="c13101903" id ="Div1">
                    �û���</div>
       <div class="c13111106" id ="Div8">
 <input id="Text1" type="text"  runat ="server" class ="c13110901" /> 
        <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text1','');">ѡ��</a></span>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����ģ�" runat="server" />
       
         </div>
         <div class="c13111301" id ="Div34">
                        <span  style =" margin-left :30px"><asp:Label ID="Label1" runat="server" Text="" ></asp:Label></span>
                          </div>
           </div>
           <div id="i13103001" class ="c13111401">
               <div class="c13111402" id ="Div2">
  <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                <asp:ListItem>��������</asp:ListItem>
                <asp:ListItem>������Ϣά��</asp:ListItem>
               <asp:ListItem>Ա����Ϣά��</asp:ListItem>
               <asp:ListItem>�ͻ���Ϣά��</asp:ListItem>
               <asp:ListItem>���յ�ַά��</asp:ListItem>
                      <asp:ListItem>��������</asp:ListItem>
               <asp:ListItem>�����Ǽ�</asp:ListItem>
               <asp:ListItem>�س��Ǽ�</asp:ListItem>
                <asp:ListItem>�ó�����</asp:ListItem>
                <asp:ListItem>·������</asp:ListItem>
<asp:ListItem>·������</asp:ListItem>
<asp:ListItem>·����ֵ</asp:ListItem>
<asp:ListItem>·�����</asp:ListItem>
 <asp:ListItem>����ͳ��</asp:ListItem>
<asp:ListItem>ά�޷���</asp:ListItem>
<asp:ListItem>���ͷ���</asp:ListItem>
               </asp:CheckBoxList>
       </div>               <div class="c13111402" id ="Div3">
  <asp:CheckBoxList ID="CheckBoxList2" runat="server">
        
<asp:ListItem>��̥����</asp:ListItem>
<asp:ListItem>�������</asp:ListItem>
<asp:ListItem>��ˮ����</asp:ListItem>
<asp:ListItem>��·����</asp:ListItem>
<asp:ListItem>��������</asp:ListItem>
<asp:ListItem>��������</asp:ListItem>
<asp:ListItem>ά�޷���(��)</asp:ListItem>
<asp:ListItem>���ͷ���(��)</asp:ListItem>
<asp:ListItem>��̥����(��)</asp:ListItem>
<asp:ListItem>�������(��)</asp:ListItem>
<asp:ListItem>��ˮ����(��)</asp:ListItem>
<asp:ListItem>��·����(��)</asp:ListItem>
<asp:ListItem>��������(��)</asp:ListItem>
 <asp:ListItem>��������(��)</asp:ListItem>
                <asp:ListItem>����ͳ��</asp:ListItem>
               <asp:ListItem>���û��ܱ�</asp:ListItem>
               </asp:CheckBoxList>
       </div>
                               <div class="c13111402" id ="Div4">
  <asp:CheckBoxList ID="CheckBoxList3" runat="server">
     <asp:ListItem>�û�����</asp:ListItem>
               <asp:ListItem>�û��ʻ�</asp:ListItem>
               <asp:ListItem>��������</asp:ListItem>
               <asp:ListItem>Ȩ�޹���</asp:ListItem>
               </asp:CheckBoxList>
                  <div class="c13111404" id ="Div7">
                    <asp:CheckBox ID="SelectAll" runat="server" oncheckedchanged="SelectAll_CheckedChanged" 
                    AutoPostBack="True" Text="ȫѡ"  CssClass ="c13111403" Width="44px" /></div>
                    <div class="c13111404" id ="Div16">
                    <asp:CheckBox ID="Inverse" runat="server" oncheckedchanged="Inverse_CheckedChanged"
                     AutoPostBack="True" Text="��ѡ" CssClass ="c13111403" Width="44px" /></div>
       </div>

                               <div class="c13111402" id ="Div5">
<asp:CheckBoxList ID="CheckBoxList4" runat="server">


               </asp:CheckBoxList>
       </div>
    <div class="c13111402" id ="Div6">
 <asp:CheckBoxList ID="CheckBoxList5" runat="server">

               </asp:CheckBoxList>
   
       </div>
                                      <div class="c13111402" id ="Div17">
  <asp:CheckBoxList ID="CheckBoxList6" runat="server">
           
               </asp:CheckBoxList>
                 
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
              dlgResult = window.showModalDialog("../USERMANAGE/USERINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
              if (dlgResult != undefined) {

                  document.getElementById("Text1").value = dlgResult[0];
                  document.all("Label1").innerText = dlgResult[1];
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