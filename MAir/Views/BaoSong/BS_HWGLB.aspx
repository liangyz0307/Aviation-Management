<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_HWGLB.aspx.cs" Inherits="CUST.WKG.BS_HWGLB" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>

<!DOCTYPE html>
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>航务管理管理部页面</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table>
                <tr>
                    <td style="width: 6%;" align="left" class="auto-style4">日期：
                        <asp:TextBox ID="tbx_kssj" runat="server" class="input-text" placeholder="开始日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="89px"></asp:TextBox>-<asp:TextBox ID="tbx_jssj" runat="server" class="input-text" placeholder="截止日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" TextMode="SingleLine" Width="91px"></asp:TextBox>
                    </td>

                    <td style="width: 6%;" align="left">星期：
                        <asp:DropDownList ID="ddlt_xq" runat="server" class="select-box" Style="width: 100px; height: 28px;">
                        </asp:DropDownList></td>

                    <td style="width: 6%;" align="left">值班领导：
                        <asp:DropDownList ID="ddlt_zbld" runat="server" class="select-box" Style="width: 100px; height: 28px;">
                        </asp:DropDownList></td>

                    <td style="width: 6%" align="center">
                        <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                            OnClick="btn_select_Click" />
                        &nbsp;
                        <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7" />
                    </td>
                </tr>

            </table>

            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">值班信息
                                    </th>
                                </tr>
                                <tr class="text-c">

                                    <th width="8%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">星期 
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">日期
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">值班领导 
                                    </th>
                                    <th width="12%" style="text-align: center; vertical-align: middle;">移动电话
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">固定电话
                                    </th>
                                    <th width="18%" style="text-align: center; vertical-align: middle;">导航保健室
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">备注
                                    </th>
                                    <th width="18%" style="text-align: center; vertical-align: middle;">操作
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
                                    <asp:Label ID="lbl_xqmc" runat="server" Text='<%#Eval("xqmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_rqmc" runat="server" Text='<%#Eval("rqmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_zbld" runat="server" Text='<%#Eval("zbld") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_yddh" runat="server" Text='<%#Eval("yddh") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_gddh" runat="server" Text='<%#Eval("gddh") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_dhbzs" runat="server" Text='<%#Eval("dhbzs") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bz" runat="server" Text='<%#Eval("bz") %>'></asp:Label>
                                </td>
                                <td class="td-manage">
                                    <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id") %>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">编辑</asp:LinkButton>
                                    &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该值班表信息？')">删除</asp:LinkButton>
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
                        <td align="center" width="100%" background="../images/menuFunction.gif">
                            <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:HiddenField ID="HF_yc" runat="server" />
        <script type="text/javascript" src="../css/js/jquery.js"></script>

        <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>

        <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>

        <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>

    </form>
</body>
</html>
