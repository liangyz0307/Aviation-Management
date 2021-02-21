<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMPCXGL.aspx.cs" Inherits="MAir.Views.JXGL.BMPCXGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门评测项管理</title>
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
                        <td align="center" style="width: 50%">评测项名称：
                            <asp:TextBox ID="tbx_pcxmc" runat="server" Style="width: 100px; height: 24px;"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7" OnClick="btn_select_Click" />
                        </td>
                        <td align="center" style="width: 50%">
                            <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" ForeColor="White" BackColor="#60B1D7" OnClick="btn_add_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                              
                                <tr class="text-c">
                                    <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">评测项编号
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">评测项名称
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">评测项描述
                                    </th>
                                    <%--  <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    评测项加减分
                                </th>--%>
                                    <%--                                    <th width="10%" style="text-align: center; vertical-align: middle;">状态
                                    </th>--%>
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
                                    <asp:Label ID="lbl_pcxbz" runat="server" Text='<%#Eval("zbms") %>'></asp:Label>
                                </td>
                                <%--                             <td>
                                <asp:Label ID="lbl_pcxjjf" runat="server" Text='<%#Eval("pcxjjfmc") %>'></asp:Label>
                            </td>
                                <td>
                                    <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                                </td>--%>
                                <td class="td-manage">
                                    <%--                                    <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("pcxbh")+"&"+ Eval("zt") %>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">提交</asp:LinkButton>
                                    <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("pcxbh")+"&"+ Eval("zt") %>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">审核</asp:LinkButton>
                                    <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("pcxbh")+"&"+ Eval("zt") %>' ForeColor="Blue" Font-Underline="true"
                                        runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                    <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("pcxbh")+"&"+ Eval("zt") %>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">编辑</asp:LinkButton>--%>

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
