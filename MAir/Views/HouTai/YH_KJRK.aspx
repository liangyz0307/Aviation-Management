<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YH_KJRK.aspx.cs" Inherits="CUST.WKG.YG_KJRK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
    <style type="text/css">
        .auto-style1 {
            height: 300px;
            width: 400px;
        }
    </style>
</head>
<body>
       <form id="form1" runat="server">  
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>              
             <div style="  width:70%; height:80%;margin:0 auto" class="panel admin-panel">                
               <table style="width:800px;margin:0 auto">
                 <tr>
                    <td class="auto-style1">
                         <table style="height:300px;width:350px">
                               <tr>
                                   <td style="text-align:center;height:30px;width:350px">
                                       <h2>未分配快捷入口</h2>
                                   </td>
                               </tr>
                               <tr >
                                  <td style="height:50px;width:350px">
                                      <asp:UpdatePanel ID="UpdatePanel3" runat="server"> <ContentTemplate>
                                            <div style="overflow:scroll;border:1px solid #000;width:350px;display:block; height:250px" >                   
                                              <asp:CheckBoxList ID="cbxl_wfpym" runat="server" Height="17px" Width="220px" 
                                                  RepeatColumns="1" RepeatDirection="Horizontal" >
                                              </asp:CheckBoxList>                         
                                            </div>
                                          </ContentTemplate>  </asp:UpdatePanel> 
                                  </td>
                               </tr>
                               <tr>
                                  <td style="height:20px">
                                      <asp:UpdatePanel ID="UpdatePanel6" runat="server"> <ContentTemplate>
                                          <asp:CheckBox ID="cbx_wfp" runat="server" AutoPostBack="True" OnCheckedChanged="cbx_wfp_CheckedChanged" 
                                               />全选
                                        </ContentTemplate></asp:UpdatePanel> 
                                  </td>
                              </tr>
                         </table>
                     </td>
                    <td style="width:100px">
                         <table>
                              <tr>
                                 <td style="height:100px;width:30px">
                                 </td>
                              </tr>
                              <tr >
                                  <td style="height:50px;width:30px;text-align:center">
                                      <asp:Button ID="btn_add_qx" runat="server" Text=" ====》" Width="100px" 
                                          class="button button-block bg-main" OnClick="btn_add_qx_Click"  />
                                  </td>
                              </tr>   
                              <tr >
                                  <td style="height:50px;width:30px;text-align:center">
                                      <asp:Button ID="btn_del_qx" runat="server" Text="《====" Width="100px" 
                                                   class="button button-block bg-main" OnClick="btn_del_qx_Click"  />
                                  </td>
                              </tr>
                        </table>
                     </td>    
                    <td style="height:300px;width:350px">
                         <table style="height:300px;width:350px">
                               <tr>
                                   <td style="text-align:center;height:30px;width:350px">
                                       <h2>已分配快捷入口</h2>
                                   </td>
                               </tr>
                               <tr >
                                  <td style="height:50px;width:300px">
                                      <asp:UpdatePanel ID="UpdatePanel1" runat="server"> <ContentTemplate>
                                            <div style="overflow:scroll;border:1px solid #000;width:350px;display:block; height:250px;">                   
                                              <asp:CheckBoxList ID="cbxl_yfpym" runat="server" Height="17px" Width="220px" 
                                                  RepeatColumns="1" RepeatDirection="Horizontal" >
                                              </asp:CheckBoxList>                         
                                            </div>
                                          </ContentTemplate>  </asp:UpdatePanel> 
                                  </td>
                               </tr>
                               <tr>
                                 <td style="height:20px">
                                       <asp:UpdatePanel ID="UpdatePanel2" runat="server"> <ContentTemplate>
                                           <asp:CheckBox ID="cbx_yfp" runat="server" AutoPostBack="True" OnCheckedChanged="cbx_yfp_CheckedChanged" 
                                               />全选
                                         </ContentTemplate></asp:UpdatePanel> 
                                   </td>
                               </tr>
                       </table>
                   </td>
                 </tr>
              </table>   
                 <br />
                   <table>
            <tr>
                
                  <td style="text-align:center">
                      <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius"  BackColor="#60B1D7" ForeColor="White" 
                Width="199px" OnClick="btn_fh_Click"  ></asp:Button>
                  </td>
            </tr>
        </table>                                         
           </div>  
    </form>
</body>
</html>
