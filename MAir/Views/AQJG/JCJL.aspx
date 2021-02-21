<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JCJL.aspx.cs" Inherits="CUST.WKG.JCJL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

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
        .auto-style1 {
            width: 132%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="text-c" style="text-align: center; width: 100%; margin: 0 auto;">
                检查时间：
                <asp:TextBox ID="tbx_jcsjs" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="开始时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>-<asp:TextBox ID="tbx_jcsje" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="截止时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox></td>
                被检单位：              
                <asp:DropDownList ID="ddlt_bjdw" runat="server">
                </asp:DropDownList>
                填报单位：
                <asp:DropDownList ID="ddlt_jcd" runat="server" OnSelectedIndexChanged="ddlt_jcd_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                检查内容：
                    <asp:DropDownList ID="ddlt_jcxm" runat="server">
                    </asp:DropDownList>
                检查结果：
                <asp:DropDownList ID="ddlt_jcjg" runat="server" class="select-box" Style="width: 80px" AutoPostBack="true">
                </asp:DropDownList>
                <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click" />
                &nbsp;
             <asp:Button ID="btn_adda" runat="server" class="btn  radius" Text="添加" BackColor="#60B1D7" ForeColor="White" OnClick="btn_adda_Click" />
            </div>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="21">检查记录
                                    </th>
                                </tr>
                                <tr>
                                    <th width="30" style="text-align: left;">序号
                                    </th>
                                    <th width="80" style="text-align: left;">检查内容
                                    </th>
                                    <th width="80" style="text-align: left;">检查时间
                                    </th>
                                    <th width="80" style="text-align: left;">被检单位
                                    </th>
                                    <th width="80" style="text-align: left;">填报单位
                                    </th>
                                    <th width="80" style="text-align: left;">责任人
                                    </th>
                                    <th width="80" style="text-align: left;">检查结果
                                    </th>
                                    <th width="80" style="text-align: left;">整改意见
                                    </th>
                                    <th width="80" style="text-align: left;">落实情况反馈
                                    </th>
                                    <th width="80" style="text-align: left;">检查人  
                                    </th>
                                    <th width="80" style="text-align: left;">
                                    操作                
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td>
                                    <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"JCJL_Detail.aspx?rwid=" + Eval("rwid")%>' Text='<%# Eval("jcxm") %>'></asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("jcsjmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("bjdwmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("jcdmc") %>'></asp:Label>
                                </td>
                                <td>
                                    
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("tzzrry") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("jcjgmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("zgyj") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("lsqkfk") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("jcr") %>'></asp:Label>
                                </td>
                                <td class="td-manage">
                                    <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("RWID") %>' ForeColor="Blue" Style="text-decoration: underline"
                                        runat="server">编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("RWID") %>' ForeColor="Blue" Style="text-decoration: underline"
                                        runat="server">删除</asp:LinkButton>
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
                        <td align="center" class="auto-style1">
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
