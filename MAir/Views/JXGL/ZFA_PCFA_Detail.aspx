<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZFA_PCFA_Detail.aspx.cs" Inherits="MAir.Views.JXGL.ZFA_PCFA_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>评测方案下的评测项详情</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="text-c">
            <table class="table table-border table-bordered table-hover table-bg table-sort">
                <tr class="text-c">
                    <th scope="col" colspan="16">评测方案编号：
                                        <asp:Label ID="lbl_pcfabh" runat="server" Style="width: 100px; height: 24px;" Text="评测方案编号"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         评测方案名称：
                                         <asp:Label ID="lbl_pcfamc" runat="server" Style="width: 100px; height: 24px;" Text="评测方案名称"></asp:Label>
                    </th>
                </tr>
            </table>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr class="text-c">
                                       <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测项编号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测项名称
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测项权重(%)
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
                                    <%#Container.ItemIndex + 1%>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("pcxbh") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("pcxmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_pcxqz" runat="server" Text='<%#Eval("pcxqz") %>'></asp:Label>
                                </td>
                                    <td class="td-manage">
                                    <asp:LinkButton ID="lbnDelete" CommandName="Delete" ForeColor="Blue" Font-Underline="true" CommandArgument='<%#Eval("PCFABH")+"&"+Eval("PCFAMC") %>'
                                        runat="server" OnClientClick="return confirm('您确定要删除该评测项信息？注意！删除该条评测项将同时删除该评测方案里的其他评测项！')">删除</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <table>
            <tr>
                <td align="center">
                    <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" Width="199px" OnClick="btn_fh_Click"></asp:Button>
                    <input id="ChangeFlag" runat="server" type="hidden" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
