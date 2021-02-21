<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PCGL.aspx.cs" Inherits="CUST.WKG.PCGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="text-c">
                <table>
                    <tr>
                        <td align="center" style="width: 60%">评测项名称：
					 <asp:TextBox ID="tbx_pcxmc" runat="server" Style="width: 100px; height: 24px;" placeholder="全部"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                                OnClick="btn_select_Click" />
                        </td>
                        <td align="center" style="width: 40%">
                            <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">评测项信息
                                    </th>
                                </tr>
                                <tr class="text-c">

                                    <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">评测项编号
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">评测项名称
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">评测项描述
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
                                    <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("pcxbh") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("pcxmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_pcxbz" runat="server" Text='<%#Eval("pcxzbms") %>'></asp:Label>
                                </td>
                                <td class="td-manage">
                                    <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("pcxbh")+"&"+ Eval("zt") %>' ForeColor="Blue" Font-Underline="true"
                                        runat="server" OnClientClick="return confirm('您确定要删除该评测项信息？')">删除</asp:LinkButton>
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
