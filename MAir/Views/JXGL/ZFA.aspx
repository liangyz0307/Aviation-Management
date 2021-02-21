<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZFA.aspx.cs" Inherits="CUST.WKG.ZFA" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>个人总方案管理</title>
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
                    <td align="center">
                        <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="新建总方案" ForeColor="White" BackColor="#60B1D7" OnClick="btn_add_Click" />
                    </td>
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
                                    <th width="10%" style="text-align: center; vertical-align: middle;">总方案编号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">总方案名称
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
                                    <asp:HyperLink ID="hlnk_zfabh" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"ZFA_Detail.aspx?zfabh=" + Eval("ZFABH")+"&zfamc="+Eval("ZFAMC") %>' Text='<%# Eval("ZFABH") %>'></asp:HyperLink> 
                                </td>
                                <td>
                                    <asp:Label ID="lbl_zfamc" runat="server" Text='<%#Eval("ZFAMC") %>'></asp:Label>
                                </td>
                                <td class="td-manage">
                                    <asp:LinkButton ID="lbnDelete" CommandName="Delete" CommandArgument='<%#Eval("ZFABH")+"&"+ Eval("ZFAMC") %>' ForeColor="Blue" Font-Underline="true"
                                        runat="server" OnClientClick="return confirm('您确定要删除该总方案？删除总方案将删除该总方案下的所有相关信息')">删除</asp:LinkButton>
                                </td>
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
        </div>
        <asp:HiddenField ID="HF_yc" runat="server" />

        <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
        <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
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

        <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
        <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
    </form>
</body>
</html>
