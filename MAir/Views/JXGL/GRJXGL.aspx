<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GRJXGL.aspx.cs" Inherits="CUST.WKG.GRJXGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>员工各评测方案最终总分数</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div class="mt-20">
                <table class="table table-border table-bordered table-hover table-bg table-sort">
                    <tr>
                        <td>员工编号：
                            <asp:Label ID="lbl_ygbh" runat="server" Text="员工编号"></asp:Label>
                        </td>
                        <td>姓名：
                            <asp:HyperLink ID="hlnk_xm" runat="server" ForeColor="Blue" Font-Underline="true" Text="姓名"
                                NavigateUrl='<%#"GRJX_YGXX.aspx?bh=" + Eval("YGBH")+"&"+ "pcfabh="+Eval("PCFABH")+"&"+"bmdm="+bm+"&"+"gwdm="+gw%>'>
                            </asp:HyperLink>
                        </td>
                        <td>部门：
                            <asp:Label ID="lbl_bmdm" runat="server" Text="部门"></asp:Label>
                        </td>
                        <td>岗位：
                            <asp:Label ID="lbl_gwdm" runat="server" Text="岗位"></asp:Label>
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
                                    <th width="15%" style="text-align: center; vertical-align: middle;">评测方案编号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">评测方案名称
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">单方案得分
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">权重（%）
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">指标描述
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">该方案最终得分
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">打分日期
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
                                    <%#Container.ItemIndex + 1%>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_pcfabh" runat="server" Text='<%#Eval("PCFABH") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:HyperLink ID="hlnk_pcfamc" runat="server" ForeColor="Blue" Font-Underline="true" Text='<%# Eval("PCFAMC") %>'
                                        NavigateUrl='<%#"GRJX_PCFA_Edit.aspx?ygbh=" + Eval("YGBH")+"&"+ "pcfabh="+Eval("PCFABH")+"&"+"xm="+xm+"&"+"bm="+bm+"&"+"gw="+gw%>'>
                                    </asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_df" runat="server" Text='<%#Eval("PCFADF") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_qz" runat="server" Text='<%#Eval("PCFAQZ") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_zbms" runat="server" Text='<%#Eval("ZBMS") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_gfazzdf" runat="server" Text='<%#Eval("GFAZZDF") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_dfrq" runat="server" Text='<%#Eval("DFRQ") %>'></asp:Label>
                                </td>

                                <td class="td-manage">
                                    <%--                                     <asp:LinkButton ID="lbtAdd" CommandName="Add" CommandArgument='<%#Eval("BH")+"&"+Eval("pcfabh") %>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">添加</asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbnDelete" CommandName="Delete" CommandArgument='<%#Eval("pcfabh") %>' ForeColor="Blue" Font-Underline="true"
                                        runat="server" OnClientClick="return confirm('您确定要删除该评测项信息？')">删除</asp:LinkButton>
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
