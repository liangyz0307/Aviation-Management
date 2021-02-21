<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GRJXZF.aspx.cs" Inherits="CUST.WKG.GRJXZF" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>个人绩效总分</title>
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
                    <td style="width: 50%" align="right">总方案：
                        <asp:DropDownList ID="ddlt_zfa" runat="server" class="select-box" Style="width: 120px" >
                        </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                部门代码：
                    <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 120px">
                    </asp:DropDownList>
                    </td>
                    <td align="center" style="width: 50%">
                        <asp:Button ID="btn_cx" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7" OnClick="btn_cx_Click" />
                    </td>
                </tr>
            </table>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">员工列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">员工编号
                                    </th>
                                    <th width="5%" style="text-align: center; vertical-align: middle;">姓名
                                    </th>
                                    <th width="7%" style="text-align: center; vertical-align: middle;">部门
                                    </th>
                                    <th width="7%" style="text-align: center; vertical-align: middle;">岗位
                                    </th>
                                    <th width="5%" style="text-align: center; vertical-align: middle;">该总方案下分数
                                    </th>
                                    <th width="5%" style="text-align: center; vertical-align: middle;">评价
                                    </th>
                                    <th width="5%" style="text-align: center; vertical-align: middle;">公示状态
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
                                    <asp:Label ID="lbl_ygbh" runat="server" Text='<%#Eval("bh") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:HyperLink ID="hlnk_xm" runat="server" ForeColor="Blue" Font-Underline="true" Text='<%# Eval("XM") %>'
                                        NavigateUrl='<%#"GRJX_YGXX.aspx?bh=" + Eval("bh")+"&"+"bmdm="+Eval("bmdm")+"&"+"gwdm="+Eval("gwdm")%>'>
                                    </asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("gwmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:HyperLink ID="hlnk_grjxzf" runat="server" ForeColor="Blue" Font-Underline="true" Text='<%#Eval("ZF")%>'
                                        NavigateUrl='<%#"GRJXZF_Detail.aspx?ygbh=" + Eval("bh")+"&"+"xm="+Eval("XM")+"&"+"bm="+Eval("bmmc")+"&"+"gw="+Eval("gwmc")+"&"+"zfabh="+Eval("zfabh")%>'>
                                    </asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_ylpj" runat="server" Text='<%#Eval("ylpj") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_gszt" runat="server" Text='<%#Eval("zszt") %>'></asp:Label>
                                </td>
                                <td class="td-manage">
                                    <asp:LinkButton ID="lbtAdd" CommandName="Add" CommandArgument='<%#Eval("bh")+"&"+Eval("XM")+"&"+Eval("bmmc")+"&"+Eval("gwmc")+"&"+Eval("zfabh")+"&"+Eval("ZF")%>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">打分管理</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbt_GS" CommandName="ZS" CommandArgument='<%#Eval("bh")+"&"+Eval("XM")+"&"+Eval("bmmc")+"&"+Eval("gwmc")+"&"+Eval("zfabh")+"&"+Eval("ZF")%>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">公示</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbt_QXGS" CommandName="QX" CommandArgument='<%#Eval("bh")+"&"+Eval("XM")+"&"+Eval("bmmc")+"&"+Eval("gwmc")+"&"+Eval("zfabh")+"&"+Eval("ZF")%>' ForeColor="Blue" Font-Underline="true"
                                        runat="server">取消公示</asp:LinkButton>
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
    </form>
</body>
</html>
