<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YG_ZFA_Add.aspx.cs" Inherits="MAir.Views.JXGL.YG_ZFA_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td align="center">总方案：
                    <asp:DropDownList ID="ddlt_zfa" runat="server" class="select-box" Style="width: 120px" AutoPostBack="true">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_save" runat="server" class="btn  radius" Text="添加" ForeColor="White" BackColor="#60B1D7"
                            OnClientClick="return checkSTLX()" OnClick="btn_save_Click" />
                </td>
            </tr>
        </table>
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr class="text-c">
                                <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">员工编号
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">员工姓名
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">部门
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">岗位
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">已有总方案
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                <%#(Container.ItemIndex + 1)%>
                            </td>
                            <td>
                                <asp:Label ID="lbl_ygbh" runat="server" Text='<%#Eval("BH") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_ygxm" runat="server" Text='<%#Eval("XM") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_bm" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_gw" runat="server" Text='<%#Eval("gwmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cbl_zfa" runat="server" RepeatDirection="Horizontal">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
            </asp:Repeater>
        </div>
         <table style="width: 100%">
            <tr>
                <td align="center" style="width: 25%">
                    <asp:Button ID="btn_fh" runat="server" class="btn  radius" Width="10%" Text="返回" ForeColor="White" BackColor="#60B1D7" OnClick="btn_fh_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
