<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GasCardSearch.aspx.cs" Inherits="W0824.GasCardManage.GasCardSearch" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�Ϳ�����ѯ</title>
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
          &gt;�Ϳ�����ѯ</div>
     <div class="c13101907" id ="Div10">
 </div>
     </div>
        </div>
<div class ="c13110501">
       <div class="c13110504" id ="Div19">
<span id="i13052904"  class ="c13110505"  >
           ��������</span> </div>
          <div class="c13110506" id ="Div20">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div5">
                            �Ϳ��ţ�</div>
     <div class="c13110103" id ="Div6">
            <input id="Text1" type="text"  runat ="server" class="c13102103" /></div>
                            <div class="c13110104" id ="Div1">
                                ���ƺ��룺</div>
     <div class="c13110103" id ="Div14">
 <input id="Text2" type="text"  runat ="server" class="c13102103" /></div>
           </div>
           <div class ="c13110105">
                        <div class="c13110104" id ="Div2">
                            �����ڼ䣺</div>
     <div class="c13110103" id ="Div8">
     <span style =" margin-right :8px;">
     <input id="StartDate" type="text" runat="server"   onclick ="f13100202('StartDate')" class ="c13102103" />
   </span> </div>
          <div class="c13110104" id ="Div12">
                 <span style=" margin-right :58px">��</span></div>
     <div class="c13110103" id ="Div13">
  <input id="EndDate" type="text" runat="server"  onclick ="f13100202('EndDate')" class ="c13102103" /></div>
     
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
            (����)
              </span>
       </div>
       <div class="c13110507" id ="Div16">
   </div>
          <div class="c13110510" id ="Div37">
                </div>
    </div>
  
                      <div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div>
             <div id="i13103001" class ="c13111201">
          
                    <asp:GridView ID="GridView1" runat="server"  CssClass ="c13111107 " 
                       onrowdatabound="GridView1_RowDataBound"  >
                         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    </asp:GridView>
                </div>
                      <div id="i13111201" class ="c13101902" style="display:none ">
                                 <div class="c13102907" id ="Div15">
                                 </div>
      <div class="c13101903" id ="Div31">
          �ϼ�δ˰���iv class="c13101904" id ="Div32">
        <input id="Text7" type="text"  runat="server"    class="c13102908"/></div>
          <div class="c13101903" id ="Div33">
              �ϼ�˰��</div>
     <div class="c13101904" id ="Div34">
   <input id="Text8" type="text"  runat ="server" class="c13102908" /> 
         </div>
                  <div class="c13101903" id ="Div35">
                      �ϼƺ�˰���</div>
     <div class="c13101904" id ="Div36">
   <input id="Text9" type="text"  runat ="server" class ="c13102908"  /> 
         </div>
           </div>
          <div class ="c13102303" style ="display :none">
          <span class="c13102304"><asp:Label ID="lblRecordCount" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:Label ID="lblPageCount" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:Label ID="lblCurrentIndex" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:LinkButton ID="btnFirst" runat="server" CommandArgument="First" onclick="PageButton_Click">��ҳ</asp:LinkButton></span>
          <span class="c13102304"><asp:LinkButton ID="btnPrev" runat="server" CommandArgument="Prev" onclick="PageButton_Click">��һҳ</asp:LinkButton></span>  
          <span class="c13102304"><asp:LinkButton ID="btnNext" runat="server" CommandArgument="Next" onclick="PageButton_Click">��һҳ</asp:LinkButton></span>
          <span class="c13102304"><asp:LinkButton ID="btnLast" runat="server" CommandArgument="Last" onclick="PageButton_Click">βҳ</asp:LinkButton></span>
          <span class="c13102304"> ת��</span>
          <span class="c13102304"><asp:TextBox ID="txtNum" runat="server"  Width="73px"></asp:TextBox></span>
          <span class="c13102304"> ҳ</span>
          <span class="c13102304"> <asp:Button ID="btngo" runat="server"  Text="GO��"   style="width:45px" onclick="btngo_Click" /></span>
               
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
