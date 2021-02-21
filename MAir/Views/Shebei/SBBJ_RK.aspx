<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SBBJ_RK.aspx.cs" Inherits="CUST.WKG.SBBJ_RK" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>导航设备设备管理</title>
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
   <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div >
         <div >
                <table style="width:100%;text-align:left">
                 <tr style="width:100%">
                     <td style="width:7%;letter-spacing:3px">备件名称：</td>
                     <td style="width:13%"><asp:DropDownList ID="ddlt_bjmc" runat="server" class="select-box" Style="width: 95%;height:26px"> </asp:DropDownList></td>
                     <td style="width:7%;letter-spacing:3px">备件分类：</td>
                     <td style="width:13%"><asp:DropDownList ID="ddlt_bjfl" runat="server" class="select-box" Style="width: 95%;height:26px"></asp:DropDownList></td>
                         <td style="width:7%;letter-spacing:3px">开始时间：</td>
                     <td style="width:13%"><asp:TextBox ID="tbx_kssj" runat="server"  class="Wdate"  Width="95%"   Height="26px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox></td>
                         <td style="width:7%;letter-spacing:3px">结束时间：</td>
                     <td style="width:13%"><asp:TextBox ID="tbx_jssj" runat="server"  class="Wdate"  Width="95%"   Height="26px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox></td>
                       <td style="width:20%;text-align:left">
                       &nbsp;<asp:Button ID="Button1" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7"  ForeColor="White"  OnClick="btn_select_Click" />
                 <asp:Button ID="btn_dc" runat="server" class="btn  radius" Text="导出" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_dc_Click" />
                     </td>
                      </tr>
                         <tr style="width:100%">
                       <td style="width:7%">经办人部门：</td>
                     <td style="width:13%">
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate> 
                         <asp:DropDownList ID="ddlt_jbrbm" runat="server" class="select-box" Style="width: 95%;height:26px" OnSelectedIndexChanged="ddlt_jbrbm_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                           </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:7%">经办人岗位：</td>
                     <td style="width:13%">
                           <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate> 
                         <asp:DropDownList ID="ddlt_jbrgw" runat="server" class="select-box" Style="width: 95%;height:26px">
                      </asp:DropDownList>
                         </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:7%">负责人部门：</td>
                     <td style="width:13%">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                  <ContentTemplate> 
                         <asp:DropDownList ID="ddlt_fzrbm" runat="server" class="select-box" Style="width: 95%;height:26px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_fzrbm_SelectedIndexChanged"> </asp:DropDownList>
                         </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:7%">负责人岗位：</td>
                     <td style="width:13%">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                  <ContentTemplate> 
                         <asp:DropDownList ID="ddlt_fzrgw" runat="server" class="select-box" Style="width: 95%;height:26px"></asp:DropDownList>
                            </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:20%;text-align:left"></td>
                  </tr>
                      <tr style="width:100%">
                       <td style="width:7%;letter-spacing:3px">备件适用：</td>
                     <td style="width:13%"><asp:DropDownList ID="ddlt_bjsy" runat="server" class="select-box" Style="width: 95%;height:26px"></asp:DropDownList></td>
                     <td style="width:7%">入库经办人：</td>
                     <td style="width:13%"><asp:TextBox ID="tbx_jbr" runat="server" Style="width:95%;height:26px;" MaxLength="10"></asp:TextBox></td>
                     <td style="width:7%">库房负责人：</td>
                     <td style="width:13%"><asp:TextBox ID="tbx_fzr" runat="server" Style="width:95%;height:26px;" MaxLength="10"></asp:TextBox></td>
                    <td  style="width:7%">状态：</td>
                             <td  style="width:13%"> 
             <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px; height: 28px;" >
            </asp:DropDownList></td>
                           <td style="width:20%">&nbsp; <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加"  BackColor="#60B1D7" ForeColor="White"  OnClick="btn_add_Click" /></td> 
                      </tr>
             </table>
            </div>
        <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">备件入库列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="20" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件名称
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件分类
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件适用
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">入库经办人
                                    </th>
                                     <th width="60" style="text-align: center; vertical-align: middle;">库房负责人
                                    </th>
                                     <th width="60" style="text-align: center; vertical-align: middle;">数据所在部门
                                    </th>
                                      <th width="50" style="text-align: center; vertical-align: middle;">录入人
                                    </th>
                                     <th width="60" style="text-align: center; vertical-align: middle;">初审人
                                    </th>
                                     <th width="60" style="text-align: center; vertical-align: middle;">终审人
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">现有库存数量
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">首次入库时间
                                    </th>
                                    <th width="30" style="text-align: center; vertical-align: middle;">状态
                                    </th>
                                   <th width="90">操作
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
                    <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"   style="TEXT-DECORATION:underline"    NavigateUrl='<%#"BJRK_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("bjmc") %>'></asp:HyperLink> 
                               </td>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sfzh" runat="server" Text='<%#Eval("bjfl_mc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_xb" runat="server" Text='<%#Eval("bjsy_mc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("jbrxm") %>'></asp:Label>
                                </td>
                                   <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("fzrxm") %>'></asp:Label>
                                </td>
                               <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_csrq" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_jg" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("rksl") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("rksjz") %>'></asp:Label>
                                </td>
                                 <td title='<%# Eval("bhyy") %>'>
                                    <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                                </td>
                                <td>
                                      <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr") +"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_ck" CommandName="CK" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")+"&"+ Eval("bjbh") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >出库</asp:LinkButton>
                                  <asp:LinkButton ID="lbt_rk" CommandName="RK" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")+"&"+ Eval("bjbh") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >入库</asp:LinkButton>
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
                    <td  style="text-align:center;width:100%">
                        <cc1:Pager ID="pg_fy" runat="server" Width="95%" OnPageChanged="pg_fy_PageChanged" />
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
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>
    </form>
</body>
</html>
