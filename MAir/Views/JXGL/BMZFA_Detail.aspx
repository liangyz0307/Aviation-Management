<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMZFA_Detail.aspx.cs" Inherits="MAir.Views.JXGL.BMZFA_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>部门总方案下所有评测方案</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="mt-20">
                <table class="table table-border table-bordered table-hover table-bg table-sort">
                    <tr class="text-c">
                        <th scope="col" colspan="16">总方案编号：
                                        <asp:Label ID="lbl_zfabh" runat="server" Style="width: 100px; height: 24px;" Text="总方案编号"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         总方案名称：
                                         <asp:Label ID="lbl_zfamc" runat="server" Style="width: 100px; height: 24px;" Text="总方案名称"></asp:Label>
                        </th>
                    </tr>
                </table>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr class="text-c">
                                    <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测方案编号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测方案名称
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测方案权重（%）
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
                                    <asp:Label ID="lbl_pcfabh" runat="server" Text='<%#Eval("PCFABH") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_pcfamc" runat="server" Text='<%#Eval("PCFAMC") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_pcfaqz" runat="server" Text='<%#Eval("PCFAQZ") %>'></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="row cl">
                <table>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" Width="199px" OnClick="btn_fh_Click"></asp:Button>
                            <input id="ChangeFlag" runat="server" type="hidden" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
