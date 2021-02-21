<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMJXZF_Detail.aspx.cs" Inherits="CUST.WKG.BMJXZF_Detail" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>该部门的该总方案详情</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="table table-border table-bordered table-hover table-bg table-sort">
                <tr>
                    <td>部门编号：
                            <asp:Label ID="lbl_bmbh" runat="server" Text="部门编号"></asp:Label>
                    </td>
                    <td>部门名称：
                            <asp:Label ID="lbl_bmmc" runat="server" Text="部门名称"></asp:Label>
                    </td>
                    <td>总方案编号：
                            <asp:Label ID="lbl_zfabh" runat="server" Text="总方案编号"></asp:Label>
                    </td>
                    <td>总方案名称：
                            <asp:Label ID="lbl_zfamc" runat="server" Text="总方案名称"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="mt-20">
                <asp:DataList ID="dlt_zfa" runat="server">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">总方案详情
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测方案编号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测方案名称
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测方案权重(%)
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测项编号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测项名称
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测项权重(%)
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">指标描述
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">该评测项得分
                                    </th>
                                </tr>
                            </thead>
                            </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <tbody>
                                <tr class="text-c">
                                    <td width="5%">
                                        <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lbl_pcfabh" runat="server" Text='<%#Eval("PCFABH") %>'></asp:Label>
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lbl_pcfamc" runat="server" Text='<%#Eval("PCFAMC") %>'></asp:Label>
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lbl_pcfaqz" runat="server" Text='<%#Eval("PCFAQZ") %>'></asp:Label>
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("PCXBH") %>'></asp:Label>
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("PCXMC") %>'></asp:Label>
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lbl_pcxqz" runat="server" Text='<%#Eval("PCXQZ") %>'></asp:Label>
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lbl_zbms" runat="server" Text='<%#Eval("ZBMS") %>'></asp:Label>
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lbl_grdf" runat="server" Text='<%#Eval("PCXDF") %>'></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                    <FooterTemplate>
                        
                    </FooterTemplate>
                </asp:DataList>
                <div style="text-align: center">
                    <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" Width="199px" OnClick="btn_fh_Click"></asp:Button>
                </div>
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
    </form>
</body>
</html>
