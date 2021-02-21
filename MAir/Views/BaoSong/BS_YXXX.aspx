<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_YXXX.aspx.cs" Inherits="CUST.WKG.BS_YXXX" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>运行信息报送</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css"
        id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <script src="../css/js/jquery.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="text-c">
        <table>
            <tr>
                <td style="width:30%; " align="right">日期：
                    <asp:TextBox ID="tbx_bsrq_qs" runat="server" class="input-text" placeholder="起始报送日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="89px">
                    </asp:TextBox>
                    --
                    <asp:TextBox ID="tbx_bsrq_jz" runat="server" class="input-text" placeholder="截止报送日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="89px">
                    </asp:TextBox>
                </td>

                <td style="width:17%; " align="right">文件名称：
                    <asp:TextBox ID="tbx_bswj" runat="server" Height="20px">
                    </asp:TextBox>
                </td>

                <td style="width:12%; " align="right">状态：
                    <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 100px">
                    </asp:DropDownList>
                </td>

                <td style="width:12%; " align="right">部门：             
                    <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Width="149px">
                    </asp:DropDownList>
                </td>
                <td  align="center">
                    <asp:Button ID="btn_cx" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7" OnClick="btn_select_Click" />
                    <asp:Button ID="btn_tj" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7"/>      
               </td>
            </tr>
        </table>
         </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="18">
                                    运行信息报送
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="30"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="120" style="text-align:center;vertical-align:middle;">
                                    运行信息报送编号
                                </th>
                                <th width="150" style="text-align:center;vertical-align:middle;">
                                    运行信息文件名称
                                </th>
                                <th width="100"  style="text-align:center;vertical-align:middle;">
                                    运行信息报送日期
                                </th>
                                <th width="100"  style="text-align:center;vertical-align:middle;">
                                    部门
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                                <th width="40">
                                    操作
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
                                 <asp:LinkButton runat="server" Text='<%# Eval("bsbh") %>'   CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bsbm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") +"&"+ Eval("bsbh")+"&"+ Eval("bswj")%>' OnCommand="link_visitDetail"  BackColor="YellowGreen"> </asp:LinkButton>
                            </td>
                             <td>
                                <asp:Label runat="server" Text='<%#Eval("bswj") %>'></asp:Label>
                            </td>

                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("bsrq") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("bsbm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_ztmc" runat="server" Text='<%#Eval("zt") %>'></asp:Label>
                            </td>
                                <td class="td-manage">
<%--                               <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bsbm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  style="text-decoration:underline"
                                    runat="server" >提交</asp:LinkButton>
                               <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") +"&"+ Eval("bsbm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue" style="text-decoration:underline"
                                    runat="server" >审核</asp:LinkButton>
                               <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bsbm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue" style="text-decoration:underline"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>--%>
<%--                               <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bsbm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") +"&"+ Eval("bsbh")+"&"+ Eval("bswj")%>' ForeColor="Blue" style="text-decoration:underline"
                                    runat="server" OnClientClick="return confirm('您确定要修改该信息？')">修改</asp:LinkButton>--%>

                                    <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bsbm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") +"&"+ Eval("bsbh")+"&"+ Eval("bswj")%>' ForeColor="Blue" Style="text-decoration: underline"
                                        runat="server" OnClientClick="return confirm('您确定要删除该条信息？')">删除</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" CommandName="Download" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bsbm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")+"&"+ Eval("bsbh")+"&"+ Eval("bswj") %>' ForeColor="Blue" Style="text-decoration: underline"
                                        runat="server" OnClientClick="return confirm('您确定要下载改文件吗？')">下载</asp:LinkButton>
                                </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
             &thinsp;	
                <br />
            <table style="width: 100%;">
                    <asp:HiddenField ID="HF_yc" runat="server" />
                </table>
              <table>
                    <tr>
                        <td align="center" width="100%">
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                        </td>
                    </tr>
                </table>
        </div>
    </form>
</body>
</html>
