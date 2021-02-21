<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BM_PCFA_ADD.aspx.cs" Inherits="CUST.WKG.BM_PCFA_ADD" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>给各部门添加总方案</title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="div">
            <table style="width: 100%">
                <tr>
                    <td align="left" style="width:30%">各部门批量添加总方案</td>
                    <td align="center" style="width:40%">总方案：
                    <asp:DropDownList ID="ddlt_zfa" runat="server" class="select-box" Style="width: 120px" AutoPostBack="true">
                    </asp:DropDownList>
                    </td>
                    <td align="center" style="width:30%">
                        <asp:Button ID="btn_save" runat="server" class="btn  radius" Text="添加" ForeColor="White" BackColor="#60B1D7" OnClick="btn_save_Click" />
                    </td>
                </tr>
            </table>
            <div id="div">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="chkAll" Text="全选" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
            </div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <%--  <tr>
                                <th style="text-align: center; vertical-align: middle;" scope="col" colspan="5">
                               <asp:Button ID="btn_fanxuan" runat="server" Text="反选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_fanxuan_Click"></asp:Button>
                                    <asp:Button ID="btn_quxiao" runat="server" Text="全部取消" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_quxiao_Click"></asp:Button>
                                   </th>
                            </tr>--%>
                            <tr class="text-c">
                                  <th width="5%" style="text-align: center; vertical-align: middle;">选择
                                </th>
                                <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">部门编号
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">部门名称
                                </th>
                                <th width="30%" style="text-align: center; vertical-align: middle;">已有总方案
                                </th>
                               <%-- <th width="40%" style="text-align: center; vertical-align: middle;">
                                    <asp:Button ID="btn_quanxuan" runat="server" Text="全选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_quanxuan_Click"></asp:Button>
                                    <asp:Button ID="btn_fanxuan" runat="server" Text="反选" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_fanxuan_Click"></asp:Button>
                                    <asp:Button ID="btn_quxiao" runat="server" Text="取消" class="btn radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_quxiao_Click"></asp:Button>

                                </th>--%>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                                <td style="text-align: center; vertical-align: middle;">
                                <asp:CheckBox ID="chk" runat="server" />
                            </td>
                            <td>
                                <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                            </td>
                            <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("BMDM") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_bm" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cbl_yyzfa" runat="server" RepeatDirection="Horizontal"></asp:DropDownList>
                            </td>
                         <%--   <td>
                                <asp:CheckBoxList ID="cbl_allzfa" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
                            </td>--%>
                        </tr>
                    </tbody>
                </ItemTemplate>
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
