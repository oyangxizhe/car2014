<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveT.aspx.cs" Inherits="W0824.UseCarManage.ApproveT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭�ó������Ϣ</title>
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
      <input id="x" type="hidden"  runat="server" />
       <input id="x1" type="hidden"  runat="server" />
        <input id="x2" type="hidden"  runat="server" />
         
                <div class ="c13101905"> 
      <div class="c13101906" id ="Div9">
          &gt;�༭�ó������Ϣ 
    </div>
    </div> 
<div class ="c13110501">
      <div class="c13110502" id ="Div17">
       </div>
              <div class="c13110510" id ="Div18">
   <span class="c13110511" id ="Span4">
              
          </span>
       </div>
             <div class="c13110502" id ="Div19">
   <span class="c13110508" id ="Span3">
       <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Image/btnSave.png" 
                     onclick="btnSave_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div20">
   <span class="c13110511" id ="Span5">
                  (����)
          </span>
       </div>
          
         <div class="c13110507" id ="Div22">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div23">
   <span class="c13110511" id ="Span6">
                     (�˳�)
               </span>
       </div>
        <div class="c13110507" id ="Div32">
                <span class="c13110503" id ="Span7">
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">���</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div33">
   <span class="c13110511" id ="Span8">
                 
          </span>
       </div>
                       <div class="c13110507" id ="Div34">
                <span class="c13110503" id ="Span9">
    <asp:LinkButton ID="btnReductionReconcil" runat="server" onclick="btnReductionReconcile_Click" CssClass ="">����</asp:LinkButton>
    </span> 
   </div>
   <div class="c13110507" id ="Div11">
                  <span class="c13110503" id ="Span10">
     <asp:ImageButton ID="btnPrint" 
                 runat="server" ImageUrl="~/Image/btnprint.png" 
                      onclick="btnPrint_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div12">
   <span class="c13110511" id ="Span11">
                     (��ӡ)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
 <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          �ó�����</div>
     <div class="c13122502"  id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c13102103" 
            /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></div>
         <div class="c13101903" id ="Div26">
             ʹ������</div>
     <div class="c13122502"  id ="Div27">
   <input id="Text2" type="text"  runat ="server"   onclick ="f13100202('Text2','')"  class ="c14112602" />
 </div>
                <div class="c13101903" id ="Div1">
                        ����</div>
     <div class="c13122502"  id ="Div2">
         <input id="Text4" type="text" runat="server" class ="c14112603"   readonly ="readonly"/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Text4" Text="����" runat="server" />
         </div>
              <div class="c13101903" id ="Div30">
                  ʹ���˹���</div>
     <div class="c14120501"  id ="Div31">
<input id="Text5" type="text" runat="server"  onclick ="f13100202('Text5','')" class ="c14120602"  />
      <span style =" margin-left :2px;"><asp:Label ID="Label2" runat="server" Text="" ></asp:Label></span>  
</div>
           </div>
  <div class ="c13101902">
    

     <div class="c13101903" id ="Div3">
           ʹ������</div>
     <div class="c13122502" id ="Div4">
<input id="Text6" type="text" runat="server" class ="c14112603" />(DAY)
    <span style =" margin-left :5px;">
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text6" Text="����" runat="server" /></span> 
</div>
 <div class="c13101903" id ="Div39">
          ����˵�� </div>
     <div class="c14112503" id ="Div40">
           <input id="Text10" type="text"  runat="server"  class="c14112004"/>
                <span style =" margin-left :5px;">
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="Text10" Text="����" runat="server" /></span> 
           </div>
           </div>
           
           <div class ="c13101902">
                   <div class="c13101903" id ="Div5">
                        ԤԼ��������</div>
     <div class="c13122502"  id ="Div6">
         <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="c13102104" >
                                <asp:ListItem>���ͻ���</asp:ListItem>
                                <asp:ListItem>�γ�</asp:ListItem>
                                <asp:ListItem>΢�ͻ���</asp:ListItem>
                                <asp:ListItem>С�ͻ���</asp:ListItem>
                                <asp:ListItem>���ͻ���</asp:ListItem>
                                <asp:ListItem>�ͳ�</asp:ListItem>
                    </asp:DropDownList>
    <span style =" margin-left :2px;">
          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="DropDownList1" Text="����" runat="server" /></span> 
         </div>
              <div class="c13101903" id ="Div15">
                  Ԥ�ƻس�ʱ��</div>
     <div class="c13122502"  id ="Div21">
   <input id="Text11" type="text"  runat ="server"  onclick ="f13100202('Text11','')"  class ="c14112602"/>
                       </div>
     <div class="c13101903" id ="Div37">
           ��������</div>
     <div class="c13122502" id ="Div38">
<input id="Text12" type="text" runat="server"  class ="c14112603"  />
</div>
               <div class="c13101903" id ="Div43">
                    ����Ա����</div>
     <div class="c14120501"  id ="Div44">
<input id="Text14" type="text" runat="server"  onclick ="f13100202('Text14','')" class ="c14120602" />
     <span style =" margin-left :2px;"><asp:Label ID="Label3" runat="server" Text="" ></asp:Label></span> 
</div>
           </div>
           <div class ="c13101902">
 
                       <div class="c13101903" id ="Div41">
                           ��ʻԱ����</div>
     <div class="c13122502"  id ="Div42">
     <input id="Text15" type="text" runat="server" onclick ="f13100202('Text15','')" class ="c14112603" />
     <span style =" margin-left :2px;"><asp:Label ID="Label4" runat="server" Text="" ></asp:Label></span> 

</div>

   <div class="c13101903" id ="Div45">
              ���ƺ���</div>
     <div  class="c13122502" id ="Div46">
     <input id="Text16" type="text" runat="server"  onclick ="f13100202('Text16','')" class ="c14112602" />

</div>
   <div class="c13101903" id ="Div51">
          ��������</div>
     <div class="c13122502"  id ="Div52">
  <input id="Text13" type="text" runat="server"  class ="c14112603"  readonly ="readonly"  />
</div>
  <div class="c13101903" id ="Div47">
           ��������</div>
     <div class="c14120501"  id ="Div48">
<input id="Text17" type="text" runat="server" class ="c14120602"  readonly ="readonly"  />
</div>
           </div>
           <div class ="c13101902">
                    


     <div class="c13101903" id ="Div49">
           �ó�����</div>
     <div class="c13122502"  id ="Div50">
<input id="Text18" type="text" runat="server"  class ="c14112603"   />
</div>
                      <div class="c13101903" id ="Div53">
                           ����ʱ�����</div>
     <div class="c13122502"  id ="Div54">
<input id="Text19" type="text" runat="server" class ="c14112602"   />

</div>
 
     <div class="c13101903" id ="Div55">
          ����ʱ��</div>
     <div class="c13122502"  id ="Div56">
<input id="Text20" type="text" runat="server" onclick ="f13100202('Text20','')"  class ="c14112602"  />  
</div>
   <div class="c13101903" id ="Div57">
           ��������</div>
     <div class="c14120501"  id ="Div58">
<input id="Text21" type="text" runat="server"  onclick ="f13100202('Text21','')" class ="c14120602" />
      <span style =" margin-left :2px;"><asp:Label ID="Label5" runat="server" Text="" ></asp:Label></span>   
</div>
           </div>
           
           
           
           
           
           <div class ="c13101902">
                    


     <div class="c13101903" id ="Div10">
            �س�ʱ�����</div>
     <div class="c13122502"  id ="Div1">
<input id="Text22" type="text" runat="server"  class ="c13110901"   />
</div>
                      <div class="c13101903" id ="Div2">
                           �س�ʱ��</div>
     <div class="c13122502"  id ="Div13">
<input id="Text23" type="text" runat="server"  onclick ="f13100202('Text23','')" class ="c14112508" />

</div>
 
     <div class="c13101903" id ="Div14">
           �س�����</div>
     <div class="c13122502"  id ="Div16">
<input id="Text24" type="text" runat="server" onclick ="f13100202('Text24','')"  class ="c13110901"   />  
    <span style =" margin-left :2px;"><asp:Label ID="Label6" runat="server" Text="" ></asp:Label></span>  
</div>

           </div>
           
<div class ="c13111601">
       <div class="c13101903" id ="Div35">
           ��ӿͻ���Ϣ</div>
     <div class="c13122502"  id ="Div36">
      <span style="color :#990033"></span>
</div>
 
         
        
</div>
 
         
    
<div>
</div>
<div class ="c13111602">
             
          <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" PageSize="15" 
                        CssClass ="c14112601"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
          
           <asp:TemplateField HeaderText="�ͻ�" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("�ͻ�") %>'   CssClass ="c14112506"   ></asp:TextBox>   
                                
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="�ջ���ַ"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("�ջ���ַ") %>' CssClass ="c14112506"  ></asp:TextBox> 
                        
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%"  />
            </asp:TemplateField> 
                              <asp:TemplateField HeaderText="������ַ"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server"  Text='<%#Eval ("�ͻ���ַ") %>'  CssClass ="c14112506" ></asp:TextBox>  
                                
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%"  />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="�س�����(��)">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval ("�س�����") %>' CssClass ="c13112302" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="���˵���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"   CssClass ="c13112302" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="�Ű��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server"    CssClass ="c13112302"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="��ע">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server"   Text='<%#Eval ("��ע") %>' CssClass ="c13120501"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="�ͻ���ַ����"   >
                <ItemTemplate >
                                <asp:TextBox ID="CUKEY" runat="server"  CssClass ="c13120501"  ></asp:TextBox>    
                                
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="���͵�ַID"   >
                <ItemTemplate >
                                <asp:TextBox ID="RDID" runat="server"  CssClass ="c13120501"   ></asp:TextBox>    
                                
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="true" />   
                </asp:GridView>
                </div>
 <div id="i13103001" class ="c13102201">
        <asp:GridView ID="GridView2" runat="server" 
                    onrowdeleting="GridView2_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView2_RowDataBound" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c13112304"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
          
                                     <asp:BoundField DataField="����" HeaderText="����"  Visible ="false"  >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="���" HeaderText="���" >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
          <asp:BoundField DataField="�ͻ�����" HeaderText="�ͻ�����" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                     
            <asp:BoundField DataField="�ͻ�����" HeaderText="�ͻ�����" >
                              <ItemStyle Width="200px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                          </asp:BoundField> 
       <asp:BoundField DataField="�ջ���ַ" HeaderText="�ջ���ַ" >
                              <ItemStyle Width="200px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="�ͻ���ַ" HeaderText="������ַ" >
                              <ItemStyle Width="200px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="�س�����" HeaderText="�س�����(��)" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"  HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          
            <asp:BoundField DataField="���۵���" HeaderText="���˵���" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
           <asp:BoundField DataField="���" HeaderText="���"    DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:BoundField DataField="�Ű����" HeaderText="�Ű����"    DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:BoundField DataField="��ע" HeaderText="��ע"   >
                              <ItemStyle Width="200px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                          </asp:BoundField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                   
                </div>
<div class ="c13101902">
                                 <div class="c13102907" id ="Div28">
                                 </div>
      <div class="c14112014" id ="Div29">
          </div>
     <div class="c13101904" id ="Div59">
        </div>
          <div class="c14112014" id ="Div60">
              �ϼƽ��</div>
     <div class="c13101904" id ="Div61">
   <input id="Text7" type="text"  runat ="server" class="c13102908" /> 
         </div>
                  <div class="c14112014" id ="Div62">
                      </div>
     <div class="c13101904" id ="Div63">

         </div>
           </div> 
      <script type ="text/javascript" >
          var table, tr;
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
                

              }
              else {
           
              }
          }

          function f13100202(obj, obj1) {
              var dlgResult;
                 if (obj == "Text2") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {


                      document.getElementById("Text2").value = dlgResult;
                  }

              }
              else if (obj == "Text3") {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text3").value = dlgResult[0];
                      document.all("Label1").innerText = dlgResult[1];
                      document.getElementById("Text4").value = dlgResult[2];
                  }

              }
              else if (obj == "Text5") {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text5").value = dlgResult[0];
                      document.all("Label2").innerText = dlgResult[1];
             
                  }

              }
             else   if (obj == "TextBox1") {
                  dlgResult = window.showModalDialog("../BaseInfo/customerinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                       table = document.getElementById('<%=GridView1.ClientID%>');
                       tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v1 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                              var v2 = tr[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0];
                              var v4 = tr[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0];
                              var cukey = tr[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0];
                              v1.value = dlgResult[1];
                              v2.value = dlgResult[2];
                              v4.value = dlgResult[5];
                             cukey.value =dlgResult[6];
                              break;
                          }
                      }

                  }

              }

              else if (obj == "TextBox3") {
             
                  dlgResult = window.showModalDialog("../baseinfo/receivinganddelivery.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                    
                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v11 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                              var v22 = tr[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0];
                              var rdid = tr[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0];
                              rdid .value = dlgResult[0];
                              v22.value = dlgResult[4];
                             
                              break;
                          }
                       
                      }
                   

                  }

              }
          
              else if (obj == "Text11") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {


                      document.getElementById("Text11").value = dlgResult;
                  }
              }
              else if (obj == "Text14") {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text14").value = dlgResult[0];
                      document.all("Label3").innerText = dlgResult[1];

                  }

              }
              else if (obj == "Text15") {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text15").value = dlgResult[0];
                      document.all("Label4").innerText = dlgResult[1];

                  }

              }
              else if (obj == "Text16") {
                  dlgResult = window.showModalDialog("../baseinfo/carinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text16").value = dlgResult[1];
                      document.getElementById("Text13").value = dlgResult[2];
                      document.getElementById("Text17").value = dlgResult[3];
                      document.getElementById("Text18").value = dlgResult[4];
                  }

              }
              else if (obj == "Text20") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text20").value = dlgResult;
                  }
              }
              else if (obj == "Text21") {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text21").value = dlgResult[0];
                      document.all("Label5").innerText = dlgResult[1];

                  }

              }
              else if (obj == "Text23") {
                  dlgResult = window.showModalDialog("../WDatet.aspx?time=0", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {
                      document.getElementById("Text23").value = dlgResult;
                  }
              }
              else if (obj == "Text24") {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text24").value = dlgResult[0];
                      document.all("Label6").innerText = dlgResult[1];

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