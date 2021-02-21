<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AQJG_JCRW.aspx.cs" Inherits="CUST.WKG.AQJG_JCRW" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" formid="form1">
        <div>
            <table>
                <tr>
                    <td align="right" class="1%">检查单：
                    <asp:DropDownList ID="ddlt_jcd" runat="server" class="select-box" AutoPostBack="true" Height="25px" Width="100px">
                    </asp:DropDownList></td>
                    <td align="right" class="1%">检查内容：
                    <asp:TextBox ID="tbx_jcnr" runat="server" Height="20px" Width="90px"></asp:TextBox></td>
                    <td align="center" class="1%">检查时间：
                    <asp:TextBox ID="tbx_jcsjks" runat="server" class="input-text" placeholder="开始日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="90px"></asp:TextBox>-<asp:TextBox ID="tbx_jcsjjs" runat="server" class="input-text" placeholder="截止日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="90px"></asp:TextBox></td>
                    <td align="right" class="1%">检查任务状态：
                    <asp:DropDownList ID="ddlt_jcrwzt" runat="server" class="select-box" AutoPostBack="true" Height="25px" Width="100px">
                    </asp:DropDownList></td>
                    <td align="center" class="1%">
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
                                    <th scope="col" colspan="16">检查任务
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="10%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">检查人
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">被检查人
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">检查时间
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">检查单
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">检查内容
                                    </th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">检查任务状态
                                    </th>
                                    <th width="20%">操作
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
                                    <asp:HyperLink ID="hlnk_jcr" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"AQJG_JCRW_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("jcrxm") %>'></asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_bjcr" runat="server" Text='<%#Eval("bjcrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_jcsj" runat="server" Text='<%#Eval("jcsjmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_jcd" runat="server" Text='<%#Eval("jcxmmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("jcxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_jcrwzt" runat="server" Text='<%#Eval("jcrwztmc") %>'></asp:Label>
                                </td>
                                <td class="td-manage">
                                    <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id") %>' ForeColor="Blue" Style="text-decoration: underline"
                                        runat="server" OnClientClick="return confirm('您确定要修改该信息？')">编辑</asp:LinkButton>

                                    <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' ForeColor="Blue" Style="text-decoration: underline"
                                        runat="server" OnClientClick="return confirm('您确定要删除该信息？')">删除</asp:LinkButton>

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
        <script type="text/javascript" src="../css/js/jquery.js"></script>
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
