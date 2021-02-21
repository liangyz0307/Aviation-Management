<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAGL_Detail.aspx.cs" Inherits="CUST.WKG.FAGL_Detail" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>评测方案管理</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="text-c">
                <table style="width: 100%">
                    <tr>
                        <td align="center" style="width: 25%">评测方案编号：
                <asp:Label ID="lbl_pcfabh" runat="server" Style="width: 100px; height: 24px;"></asp:Label>
                        </td>
                        <td align="center" style="width: 25%">评测方案名称：
                <asp:Label ID="lbl_pcfamc" runat="server" Style="width: 100px; height: 24px;"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div class="mt-20">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                            <table class="table table-border table-bordered table-hover table-bg table-sort">
                                <thead>
                                    <tr>
                                        <th scope="col" colspan="16">评测方案详细信息
                                        </th>
                                    </tr>
                                    <tr class="text-c">
                                        <%--                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测方案编号
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">评测方案名称
                                    </th>--%>
                                        <th width="10%" style="text-align: center; vertical-align: middle;">评测项编号
                                        </th>
                                        <th width="15%" style="text-align: center; vertical-align: middle;">评测项名称
                                        </th>
                                        <th width="10%" style="text-align: center; vertical-align: middle;">评测项权重(%)
                                        </th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr class="text-c">
                                    <td>
                                        <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("pcxbh") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("pcxmc") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_pcxqz" runat="server" Text='<%#Eval("pcxqz") %>'></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
            <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
            <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
            <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
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
