<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveT.aspx.cs" Inherits="W0824.UseCarManage.ApproveT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑用车审核信息</title>
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
          &gt;编辑用车审核信息 
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
                  (保存)
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
                     (退出)
               </span>
       </div>
        <div class="c13110507" id ="Div32">
                <span class="c13110503" id ="Span7">
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">审核</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div33">
   <span class="c13110511" id ="Span8">
                 
          </span>
       </div>
                       <div class="c13110507" id ="Div34">
                <span class="c13110503" id ="Span9">
    <asp:LinkButton ID="btnReductionReconcil" runat="server" onclick="btnReductionReconcile_Click" CssClass ="">撤审</asp:LinkButton>
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
                     (打印)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
 <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          用车单号</div>
     <div class="c13122502"  id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c13102103" 
            /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="必填" runat="server" /></div>
         <div class="c13101903" id ="Div26">
             使用日期</div>
     <div class="c13122502"  id ="Div27">
   <input id="Text2" type="text"  runat ="server"   onclick ="f13100202('Text2','')"  class ="c14112602" />
 </div>
                <div class="c13101903" id ="Div1">
                        部门</div>
     <div class="c13122502"  id ="Div2">
         <input id="Text4" type="text" runat="server" class ="c14112603"   readonly ="readonly"/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Text4" Text="必填" runat="server" />
         </div>
              <div class="c13101903" id ="Div30">
                  使用人工号</div>
     <div class="c14120501"  id ="Div31">
<input id="Text5" type="text" runat="server"  onclick ="f13100202('Text5','')" class ="c14120602"  />
      <span style =" margin-left :2px;"><asp:Label ID="Label2" runat="server" Text="" ></asp:Label></span>  
</div>
           </div>
  <div class ="c13101902">
    

     <div class="c13101903" id ="Div3">
           使用天数</div>
     <div class="c13122502" id ="Div4">
<input id="Text6" type="text" runat="server" class ="c14112603" />(DAY)
    <span style =" margin-left :5px;">
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text6" Text="必填" runat="server" /></span> 
</div>
 <div class="c13101903" id ="Div39">
          事由说明 </div>
     <div class="c14112503" id ="Div40">
           <input id="Text10" type="text"  runat="server"  class="c14112004"/>
                <span style =" margin-left :5px;">
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="Text10" Text="必填" runat="server" /></span> 
           </div>
           </div>
           
           <div class ="c13101902">
                   <div class="c13101903" id ="Div5">
                        预约车辆类型</div>
     <div class="c13122502"  id ="Div6">
         <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="c13102104" >
                                <asp:ListItem>大型货车</asp:ListItem>
                                <asp:ListItem>轿车</asp:ListItem>
                                <asp:ListItem>微型货车</asp:ListItem>
                                <asp:ListItem>小型货车</asp:ListItem>
                                <asp:ListItem>中型货车</asp:ListItem>
                                <asp:ListItem>客车</asp:ListItem>
                    </asp:DropDownList>
    <span style =" margin-left :2px;">
          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="DropDownList1" Text="必填" runat="server" /></span> 
         </div>
              <div class="c13101903" id ="Div15">
                  预计回程时间</div>
     <div class="c13122502"  id ="Div21">
   <input id="Text11" type="text"  runat ="server"  onclick ="f13100202('Text11','')"  class ="c14112602"/>
                       </div>
     <div class="c13101903" id ="Div37">
           随行人数</div>
     <div class="c13122502" id ="Div38">
<input id="Text12" type="text" runat="server"  class ="c14112603"  />
</div>
               <div class="c13101903" id ="Div43">
                    调度员工号</div>
     <div class="c14120501"  id ="Div44">
<input id="Text14" type="text" runat="server"  onclick ="f13100202('Text14','')" class ="c14120602" />
     <span style =" margin-left :2px;"><asp:Label ID="Label3" runat="server" Text="" ></asp:Label></span> 
</div>
           </div>
           <div class ="c13101902">
 
                       <div class="c13101903" id ="Div41">
                           驾驶员工号</div>
     <div class="c13122502"  id ="Div42">
     <input id="Text15" type="text" runat="server" onclick ="f13100202('Text15','')" class ="c14112603" />
     <span style =" margin-left :2px;"><asp:Label ID="Label4" runat="server" Text="" ></asp:Label></span> 

</div>

   <div class="c13101903" id ="Div45">
              车牌号码</div>
     <div  class="c13122502" id ="Div46">
     <input id="Text16" type="text" runat="server"  onclick ="f13100202('Text16','')" class ="c14112602" />

</div>
   <div class="c13101903" id ="Div51">
          车辆属性</div>
     <div class="c13122502"  id ="Div52">
  <input id="Text13" type="text" runat="server"  class ="c14112603"  readonly ="readonly"  />
</div>
  <div class="c13101903" id ="Div47">
           车辆类型</div>
     <div class="c14120501"  id ="Div48">
<input id="Text17" type="text" runat="server" class ="c14120602"  readonly ="readonly"  />
</div>
           </div>
           <div class ="c13101902">
                    


     <div class="c13101903" id ="Div49">
           用车单价</div>
     <div class="c13122502"  id ="Div50">
<input id="Text18" type="text" runat="server"  class ="c14112603"   />
</div>
                      <div class="c13101903" id ="Div53">
                           出车时里程数</div>
     <div class="c13122502"  id ="Div54">
<input id="Text19" type="text" runat="server" class ="c14112602"   />

</div>
 
     <div class="c13101903" id ="Div55">
          出车时间</div>
     <div class="c13122502"  id ="Div56">
<input id="Text20" type="text" runat="server" onclick ="f13100202('Text20','')"  class ="c14112602"  />  
</div>
   <div class="c13101903" id ="Div57">
           保安工号</div>
     <div class="c14120501"  id ="Div58">
<input id="Text21" type="text" runat="server"  onclick ="f13100202('Text21','')" class ="c14120602" />
      <span style =" margin-left :2px;"><asp:Label ID="Label5" runat="server" Text="" ></asp:Label></span>   
</div>
           </div>
           
           
           
           
           
           <div class ="c13101902">
                    


     <div class="c13101903" id ="Div10">
            回车时里程数</div>
     <div class="c13122502"  id ="Div1">
<input id="Text22" type="text" runat="server"  class ="c13110901"   />
</div>
                      <div class="c13101903" id ="Div2">
                           回车时间</div>
     <div class="c13122502"  id ="Div13">
<input id="Text23" type="text" runat="server"  onclick ="f13100202('Text23','')" class ="c14112508" />

</div>
 
     <div class="c13101903" id ="Div14">
           回车保安</div>
     <div class="c13122502"  id ="Div16">
<input id="Text24" type="text" runat="server" onclick ="f13100202('Text24','')"  class ="c13110901"   />  
    <span style =" margin-left :2px;"><asp:Label ID="Label6" runat="server" Text="" ></asp:Label></span>  
</div>

           </div>
           
<div class ="c13111601">
       <div class="c13101903" id ="Div35">
           添加客户信息</div>
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
          
           <asp:TemplateField HeaderText="客户" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("客户") %>'   CssClass ="c14112506"   ></asp:TextBox>   
                                
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="收货地址"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("收货地址") %>' CssClass ="c14112506"  ></asp:TextBox> 
                        
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%"  />
            </asp:TemplateField> 
                              <asp:TemplateField HeaderText="发货地址"  >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server"  Text='<%#Eval ("送货地址") %>'  CssClass ="c14112506" ></asp:TextBox>  
                                
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%"  />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="回车数量(吨)">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval ("回车数量") %>' CssClass ="c13112302" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="货运单价">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"   CssClass ="c13112302" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="排班费">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server"    CssClass ="c13112302"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server"   Text='<%#Eval ("备注") %>' CssClass ="c13120501"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="客户地址索引"   >
                <ItemTemplate >
                                <asp:TextBox ID="CUKEY" runat="server"  CssClass ="c13120501"  ></asp:TextBox>    
                                
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="收送地址ID"   >
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
          
                                     <asp:BoundField DataField="索引" HeaderText="索引"  Visible ="false"  >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="项次" HeaderText="项次" >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
          <asp:BoundField DataField="客户代码" HeaderText="客户代码" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                     
            <asp:BoundField DataField="客户名称" HeaderText="客户名称" >
                              <ItemStyle Width="200px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                          </asp:BoundField> 
       <asp:BoundField DataField="收货地址" HeaderText="收货地址" >
                              <ItemStyle Width="200px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="送货地址" HeaderText="发货地址" >
                              <ItemStyle Width="200px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="回车数量" HeaderText="回车数量(吨)" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"  HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          
            <asp:BoundField DataField="销售单价" HeaderText="货运单价" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
           <asp:BoundField DataField="金额" HeaderText="金额"    DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:BoundField DataField="排班费用" HeaderText="排班费用"    DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:BoundField DataField="备注" HeaderText="备注"   >
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
              合计金额</div>
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
                              var v1 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
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
                              var v11 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; //获取girdview里第1列TextBox的值
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