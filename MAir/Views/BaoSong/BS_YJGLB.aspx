<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_YJGLB.aspx.cs" Inherits="CUST.WKG.BS_YJGLB" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>延吉管理部页面</title>
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

                    <td style="width: 6%;" align="left">值班领导：
                        <asp:DropDownList ID="ddlt_zbld" runat="server" class="select-box" Style="width: 80px; height: 28px;">
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

                                    <th width="4%"  style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="6%"  style="text-align: center; vertical-align: middle;">日期
                                    </th>
                                    <th width="6%"  style="text-align: center; vertical-align: middle;">值班领导 
                                    </th>
                                    <th width="8%"  style="text-align: center; vertical-align: middle;">行政班 
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">管制带班主任
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">塔台值班
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">站调值班
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">情报
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">通导带班
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">通信
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">导航
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">报台
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">气象机务
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">气象观测
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">气象预报
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">操作
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
                                    <asp:Label ID="lbl_xq" runat="server" Text='<%#Eval("rqmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:HyperLink runat="server" ForeColor="blue" Style="text-decoration: underline" NavigateUrl='<%#"BS_YJGLB_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("zbld") %>'></asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_xzb" runat="server" Text='<%#Eval("xzb") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_gzdbzr" runat="server" Text='<%#Eval("gzdbzr") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_ttzb" runat="server" Text='<%#Eval("ttzb") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_zdzb" runat="server" Text='<%#Eval("zdzb") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_qb" runat="server" Text='<%#Eval("qb") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_tddb" runat="server" Text='<%#Eval("tddb") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_tx" runat="server" Text='<%#Eval("tx") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_dh" runat="server" Text='<%#Eval("dh") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bt" runat="server" Text='<%#Eval("bt") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_qxjw" runat="server" Text='<%#Eval("qxjw") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_qxgc" runat="server" Text='<%#Eval("qxgc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_qxyb" runat="server" Text='<%#Eval("qxyb") %>'></asp:Label>
                                </td>
                                <td class="td-manage">
                                    <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")%>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">编辑</asp:LinkButton>
                                    &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")%>' ForeColor="Blue" Font-Underline="true"
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
