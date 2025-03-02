<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CCarInfoT.ascx.cs" Inherits="W0824.Ascx.CCarInfoT" %>
   <script language ="javascript" type ="text/javascript" src ="../Js/dateTimePicker.js"></script>
<div> 
             &nbsp;&nbsp;<asp:Button ID="btnAdd" runat="server" Text="新建" onclick="btnAdd_Click" 
                    style="width: 45px" />
            <asp:Button ID="btnSave0" runat="server" Text="修改" onclick="btnEdit_Click" 
                 style="width:45px;" />
             <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" style="width:45px;" />
            <asp:LinkButton ID="btnExit" runat="server" onclick="btnExit_Click">返回</asp:LinkButton>
                    </div> 
           
   
                <div>
            <div >
          
                &nbsp;&nbsp;
                <br />
                &nbsp;&nbsp; 
                <div style="margin-left:12px;">
                    <table border="1" style=" margin-left:auto; margin-right:auto; width:95%;" >
                        <tr>
                            <td colspan=2 class=Caption style="border:0px;">
                                车辆详细信息</td>
                        </tr>
                        <tr>
                            <td td width=80 >
                                                                车辆编号</td>
                            <td>
                                <asp:TextBox ID=txtCarID runat=server/>
                            </td>
                            <td td width=80>
                                                                车辆识别码    <td width=170>
                                <asp:TextBox ID=txtCIdentiCode runat=server />
                            </td>
                            <td td width=80>
                                发动机号</td>
                            <td>
                                <asp:TextBox ID=txtEngineNum runat=server />
                            </td>
                        </tr>
                        <tr>
                            <td >
                                                                车牌号码</td>
                            <td>
                                <asp:TextBox ID=txtPlateNum runat=server />
                            </td>
                            <td>
                                                                汽车品牌    <td>
                                <asp:DropDownList ID=ddlCarBrand runat=server Width=120 />
                            </td>
                            <td>
                                汽车型号</td>
                            <td>
                                <asp:TextBox ID=txtCarModel runat=server />
                            </td>
                        </tr>
                        <tr>
                            <td >
                                                                &nbsp;汽车类型</td>
                            <td>
                                <asp:DropDownList ID=ddlCarType runat=server Width=120 />
                            </td>
                            <td >
                                                                颜色    <td>
                                <asp:DropDownList ID=ddlColor runat=server Width=120 />
                            </td>
                            <td>
                                吨位/人数 </td>
                            <td >
                                <asp:DropDownList ID=ddlTonnage runat=server Width=120 />
                            </td>
                        </tr>
                        <tr>
                            <td >
                                                                购买日期</td>
                            <td>
                                <input id="txtPurDate" type="text" runat ="server" onclick ="setday(this)" /></td>
                            <td>
                                                                采购价格    <td>
                                <asp:TextBox ID=txtPurPrice runat=server />
                            </td>
                            <td>
                                车属单位</td>
                            <td>
                                <asp:TextBox ID=txtCarHodler runat=server />
                            </td>
                        </tr>
                        <tr>
                            <td  >
                                                                购置税费</td>
                            <td>
                                <asp:TextBox ID=txtPurTax runat=server />
                            </td>
                            <td>
                                                                购置税证号    <td>
                                <asp:TextBox ID=txtPTCertiNo runat=server />
                            </td>
                            <td>
                                保险公司</td>
                            <td>
                                <asp:TextBox ID=txtInsuCom runat=server Width="225px" />
                            </td>
                        </tr>
                        <tr>
                            <td >
                                                                保险金额</td>
                            <td>
                                <asp:TextBox ID=txtInsuAmount runat=server />
                            </td>
                            <td>
                                                                保险期从&nbsp;    <td>
                                <input id="txtPurDF" type="text" runat ="server" onclick ="setday(this)" /></td>
                            <td>
                                保险期至</td>
                            <td>
                                <input id="txtPurDT" type="text" runat ="server" onclick ="setday(this)" /></td>
                        </tr>
                        <tr>
                            <td  >
                                                                用车单价</td>
                            <td>
                                <asp:TextBox ID=txtUseUnitPrice runat=server />
                            </td>
                            <td >
                                用途    <td>
                                <asp:DropDownList ID=txtApplication runat=server Width=120 />
                            </td>
                        </tr>
                        <tr>
                            <td  >
                                备注</td>
                            <td colspan=3>
                                <asp:TextBox ID=txtRemark runat=server Rows=3 TextMode=multiLine 
                                    Width="446px" />
                            </td>
                        </tr>
                    </table>
                </div>
                    </div></div>