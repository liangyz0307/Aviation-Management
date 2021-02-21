<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SBGZ_GL.aspx.cs" Inherits="CUST.WKG.SheBei.main.SBGZ_GL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
       <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>

    <script type="text/javascript" src="../lib/respond.min.js"></script>

    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
       <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"  />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
     <script src="../css/js/jquery.js" type="text/javascript"></script>
     <script src="../css/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
</head>
<body>
  <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
        <div>
            <table style="width:100%;text-align:left">

                <tr style="width:100%">
                    <td style="width:7%;letter-spacing:3px">设备编号：</td>
            <td style="width:14%"> <asp:TextBox ID="tbx_sbbh" runat="server" Style="width: 95%;height:26px;"></asp:TextBox></td>
                    
                    <td style="width:7%;letter-spacing:3px">
                         设备类型：</td>
                    <td style="width:14%">
                         <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                         <ContentTemplate>
                        <asp:DropDownList ID="ddlt_sblx" runat="server" class="select-box" Style="width:  95%;height:26px" OnSelectedIndexChanged="ddlt_sblx_SelectedIndexChanged" AutoPostBack="True">
               </asp:DropDownList>
                                </ContentTemplate>
                         </asp:UpdatePanel>

                    </td>
                    <td style="width:7%;">设备种类：</td>
                    <td style="width:14%"> 
                          <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                         <ContentTemplate>
                        <asp:DropDownList ID="ddlt_sbzl" runat="server" class="select-box" Style="width:  95%;height:26px">
               </asp:DropDownList>
                        </ContentTemplate>
                         </asp:UpdatePanel>
                    </td>
                    <td style="width:16%">   &nbsp;<asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"   BackColor="#60B1D7" ForeColor="White"   OnClick="btn_select_Click" />
                                     &nbsp;   <asp:Button ID="btn_dc" runat="server" class="btn  radius" Text="导出" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_dc_Click" />
               </td>
                </tr>
                <tr>
                    <td style="width:7%;">维修人：</td>
                    <td style="width:14%"> <asp:TextBox ID="tbx_wxr" runat="server" Style="width:  98%;height:26px;"></asp:TextBox></td>
                    
                    <td style="width:7%;">维修人部门：</td>
                    <td style="width:14%"> 
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                         <asp:DropDownList ID="ddlt_wxrbm" runat="server" class="select-box" Style="width:  95%;height:26px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_whrbm_SelectedIndexChanged">
               </asp:DropDownList>
                                 </ContentTemplate>
                         </asp:UpdatePanel>
                    </td>
                    <td style="width:7%;">  维修人岗位：</td>
                    <td  style="width:14%">
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
                         <asp:DropDownList ID="ddlt_wxrgw" runat="server" class="select-box" Style="width:  95%;height:26px">
                           </asp:DropDownList>
                           </ContentTemplate>
                         </asp:UpdatePanel>
                    </td>
                    
                    <td  style="width:16%">  &nbsp;<asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加"     BackColor="#60B1D7" ForeColor="White"    OnClick="btn_add_Click" /></td>
                </tr>
            </table>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">设备故障列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">设备编号
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">设备种类
                                    </th>
                                      <th width="8%" style="text-align: center; vertical-align: middle;">设备类型
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">维修人
                                    </th>
                                     <th width="7%" style="text-align: center; vertical-align: middle;">维修人部门
                                    </th>
                                     <th width="7%" style="text-align: center; vertical-align: middle;">维修人岗位
                                    </th>
                                    <th width="7%" style="text-align: center; vertical-align: middle;">累计时长
                                    </th>
                                      <th width="7%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                    <th width="7%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th>
                                <th width="7%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                <th width="7%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                <th width="7%"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                                    <th width="80">操作
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">
                               
                                <td>
                                    <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                                  
                                </td>
                                       <td>
                    <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"  style="TEXT-DECORATION:underline"      NavigateUrl='<%#"SBGZ_Detail.aspx?id=" + Eval("id") %>' Text='<%# Eval("SBBH") %>'></asp:HyperLink> 
           
                    </td>
                             
                                <td>
                                    <asp:Label ID="lbl_xm" runat="server" Text='<%#Eval("SBZLMC") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sfzh" runat="server" Text='<%#Eval("SBLXMC") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_xb" runat="server" Text='<%#Eval("wxr") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("wxrbmmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("wxrgwmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_csrq" runat="server" Text='<%#Eval("LJSC") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                                </td>
                                <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_byyx" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
                            </td>   
                                  <td class="td-manage">
                                 <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr") +"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该惩罚信息？')">删除</asp:LinkButton>
                                    
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <table>
                    <tr>
                        <td align="center" width="100%" background="../images/menuFunction.gif">
                            <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>

       <asp:HiddenField ID="HF_yc" runat="server"/>
    <script type="text/javascript">
    //单个按钮驳回
    function rec() {
                        var excuse;
                        excuse = prompt("请输入驳回原因：");
                        if (excuse == null)
                        { return false; }
                        else {
                            document.getElementById("<%=HF_yc.ClientID %>").value = excuse;
                        }
                          
    }
    </script>  

        <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>

        <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>

    </form>
</body>
</html>
