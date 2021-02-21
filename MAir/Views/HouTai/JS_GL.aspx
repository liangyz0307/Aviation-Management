<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_GL.aspx.cs" Inherits="CUST.WKG.JS_GL" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="text-c">
                角色名称：
             <asp:TextBox ID="tbx_jsmc" runat="server" Style="width: 100px; height: 25px;"></asp:TextBox>
                备注：
           <asp:TextBox ID="tbx_ms" runat="server" Style="width: 100px; height: 25px;"></asp:TextBox>

                <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" BackColor="#60B1D7" ForeColor="White"
                    OnClick="btn_select_Click" />
                &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" OnClick="btn_add_Click" BackColor="#60B1D7" ForeColor="White" />
            </div>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">角色列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="30" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">角色代码
                                    </th>
                                    <th width="70" style="text-align: center; vertical-align: middle;">角色名称
                                    </th>
                                    <th width="60">操作
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
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("jsdm") %>'></asp:Label>
                                </td>
                              <td>
                                  <asp:Label ID="Label6" runat="server" Text='<%#Eval("jsmc") %>'></asp:Label>
                              </td>
                                </td>
                            <td class="td-manage">
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("jsdm") %>' ForeColor="#60B1D7" Style="text-decoration: underline"
                                    runat="server">编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("jsdm") %>' ForeColor="#60B1D7" Style="text-decoration: underline"
                                    runat="server" OnClientClick="return confirm('您确定要删除该角色信息，同时删除对应用户下该角色信息？')">删除</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtPeizhi" CommandName="Fenpei" CommandArgument='<%#Eval("jsdm") %>' ForeColor="#60B1D7" Style="text-decoration: underline"
                                    runat="server">权限配置</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtBmsq" CommandName="Shouquan" CommandArgument='<%#Eval("jsdm") %>' ForeColor="#60B1D7" Style="text-decoration: underline"
                                    runat="server">部门授权</asp:LinkButton>
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
            <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
        <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
    </form>
</body>
</html>
