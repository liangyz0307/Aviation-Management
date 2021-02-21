<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CLGL.aspx.cs" Inherits="CUST.WKG.CLGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css"
        id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script src="../css/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function SelectAll() {
            var table = document.getElementById("<%=this.dlt_cl.ID%>");
            var checkes = table.getElementsByTagName("input");
            for (var i = 0; i < checkes.length; i++) {
                if (document.getElementById("<%=this.cbk_qx.ClientID %>").checked == true) {
                    if (checkes[i].type == "checkbox") {
                        checkes[i].checked = true;
                    }
                }
                else {
                    if (checkes[i].type == "checkbox") {
                        checkes[i].checked = false;
                    }
                }
            }
        }
        //单个按钮驳回
        function rec() {
            var excuse = prompt("请输入驳回原因：");
            if (excuse == null) {
                return false;
            }
            else {
                document.getElementById("<%=HF_yc.ClientID %>").value = excuse;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table style="width: 100%">
                <tr>
                    <td style="width: 15%;" align="right">考试名称：<asp:TextBox ID="tbx_mc" runat="server" Style="width: 120px; height: 24px;"></asp:TextBox>&nbsp;</td>
                    <td style="width: 12%;" align="right">难度：
                         <asp:DropDownList ID="ddlt_stnd" runat="server" class="select-box" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width: 12%;" align="right">科目：
                        <asp:DropDownList ID="ddlt_km" runat="server" class="select-box" Width="100px"></asp:DropDownList>
                    </td>
                    <td style="width: 12%;" align="right">类别：
                        <asp:DropDownList ID="ddlt_lb" runat="server" class="select-box" Width="100px"></asp:DropDownList>
                    </td>
                    <td style="width: 13%;" align="right">岗位：
                        <asp:DropDownList ID="ddlt_gw" runat="server" class="select-box" Style="width: 120px"></asp:DropDownList>
                    </td>
                    <td style="width: 13%;" align="right">状态：
                         <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Width="100px"></asp:DropDownList>
                    </td>
                    <td style="width: 15%;" align="center">
                        <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                            OnClick="btn_select_Click" />
                        &nbsp;
                         <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7" />
                    </td>
                </tr>
            </table>
            <div class="mt-20">
                <asp:DataList ID="dlt_cl" runat="server" DataKeyField="id" OnItemCommand="dlt_cl_ItemCommand" OnItemDataBound="dlt_cl_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">试题列表</th>
                                </tr>
                                <tr class="text-c">
                                    <th width="5%" style="text-align: center; vertical-align: middle;">选择</th>
                                    <th width="5%" style="text-align: center; vertical-align: middle;">序号</th>
                                    <th width="30%" style="text-align: center; vertical-align: middle;">名称</th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">难度</th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">适用科目</th>
                                    <th width="15%" style="text-align: center; vertical-align: middle;">适用岗位</th>
                                    <th width="7%" style="text-align: center; vertical-align: middle;">类别</th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">状态</th>
                                    <th width="10%" id="title_cz" runat="server">操作</th>
                                </tr>
                            </thead>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                            <tbody>
                                <tr class="text-c">
                                    <td width="5%" style="text-align: center; vertical-align: middle;">
                                        <asp:CheckBox ID="cbx_xz" runat="server" /></td>
                                    <td width="5%" style="text-align: center; vertical-align: middle;"><%#(cpage-1)*psize+(Container.ItemIndex + 1)%></td>
                                    <td width="30%" style="text-align: center; vertical-align: middle;">
                                        <asp:HyperLink ID="hlnk_tg" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"../ZXPX/CL_Detail.aspx?id=" + Eval("id")%>' Text='  <%# Eval("mc") %>'></asp:HyperLink></td>
                                    <td width="10%" style="text-align: center; vertical-align: middle;">
                                        <asp:Label ID="lbl_stnd" runat="server" Text='<%#Eval("stnd") %>'></asp:Label></td>
                                    <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                        <asp:Label ID="lbl_sykm" runat="server" Text='<%#Eval("sykm") %>'></asp:Label></td>
                                    <td width="15%" class="class_td" style="text-align: center; vertical-align: middle;">
                                        <asp:Label ID="lbl_sygw" runat="server" Text='<%#Eval("sygw") %>'></asp:Label></td>
                                    <td width="7%" class="class_td" style="text-align: center; vertical-align: middle;">
                                        <asp:Label ID="lbl_kczsd" runat="server" Text='<%#Eval("stlb") %>'></asp:Label></td>
                                    <td width="8%" style="text-align: center; vertical-align: middle;">
                                        <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztdm") %>'></asp:Label></td>
                                    <td class="td-manage" width="10%" id="nr_cz" runat="server">
                                        <asp:LinkButton ID="lbtUpdate" CommandName="Update" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue" Font-Underline="true"
                                            runat="server">编辑</asp:LinkButton>
                                        <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue" Font-Underline="true"
                                            runat="server" OnClientClick="return confirm('您确定要删除该策略信息？')">删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                &thinsp;	
                 <table style="width: 100%">
                     <tr>
                         <td width="8%" style="text-align: center; vertical-align: middle;">
                             <asp:CheckBox ID="cbk_qx" runat="server" onclick="SelectAll()" Text="全选" Width="100%" />
                         </td>
                         <td align="center" style="width: 20%">
                             <asp:Button ID="btn_sc" runat="server" Text="删除" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                 OnClick="btn_sc_Click" Width="66px" />
                         </td>
                         <td align="center" style="width: 20%">
                             <asp:Button ID="btn_tj" runat="server" Text="提交" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                 OnClick="btn_tj_Click" Width="100px" />
                         </td>
                         <td align="center" style="width: 25%">
                             <asp:Button ID="btn_shtg" runat="server" Text="审核通过" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                 OnClick="btn_shtg_Click" Width="100px" />
                         </td>
                         <td align="center" style="width: 25%">
                             <asp:Button ID="btn_bh" runat="server" Text="驳回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                 OnClick="btn_bh_Click" Width="66px" OnClientClick="return rec()" />
                         </td>
                     </tr>
                 </table>
                <br />
                <table style="width: 100%;">
                    <asp:HiddenField ID="HF_yc" runat="server" />
                </table>
                <table>
                    <tr>
                        <td align="center" width="100%">
                            <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>

</body>
</html>
