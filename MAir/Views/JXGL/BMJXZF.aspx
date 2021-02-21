<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMJXZF.aspx.cs" Inherits="CUST.WKG.BMJXZF" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门绩效总分</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td style="width: 50%" align="center">总方案：
                        <asp:DropDownList ID="ddlt_zfa" runat="server" class="select-box" Style="width: 120px">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;    
                        <asp:Button ID="btn_cx" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7" OnClick="btn_cx_Click" />
                    </td>
                </tr>
            </table>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">部门列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">部门编号
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">部门名称
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">该总方案下分数
                                    </th>
                                    <th width="5%" style="text-align: center; vertical-align: middle;">评价
                                    </th>
                                    <th width="5%" style="text-align: center; vertical-align: middle;">公示状态
                                    </th>
                                    <th width="10%">操作
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
                                    <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("bmdm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bmmc" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:HyperLink ID="hlnk_grjxzf" runat="server" ForeColor="Blue" Font-Underline="true" Text='<%#Eval("ZF")%>'
                                        NavigateUrl='<%#"BMJXZF_Detail.aspx?bmdm=" + Eval("bmdm")+"&"+"zfabh="+Eval("zfabh")%>'>
                                    </asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_ylpj" runat="server" Text='<%#Eval("ylpj") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_gszt" runat="server" Text='<%#Eval("zszt") %>'></asp:Label>
                                </td>
                                <td class="td-manage">
                                    <asp:LinkButton ID="lbtAdd" CommandName="Add" CommandArgument='<%#Eval("bmdm")+"&"+Eval("bmmc")+"&"+Eval("ZF")%>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">打分管理</asp:LinkButton>
                                    <%-- <asp:LinkButton ID="lbnDelete" CommandName="Delete" CommandArgument='<%#Eval("bmdm")%>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该评测项信息？')">删除</asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbt_GS" CommandName="ZS" CommandArgument='<%#Eval("bmdm")+"&"+Eval("bmmc")+"&"+Eval("ZF")%>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">公示</asp:LinkButton>
                                    <asp:LinkButton ID="lbt_QXGS" CommandName="QX" CommandArgument='<%#Eval("bmdm")+"&"+Eval("bmmc")+"&"+Eval("ZF")%>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">取消公示</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        <table></table>
                    </FooterTemplate>
                </asp:Repeater>
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
