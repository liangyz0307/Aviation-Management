<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMJX_PCFA_Detail.aspx.cs" Inherits="MAir.Views.JXGL.BMJX_PCFA_Detail" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门评测方案打分</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="mt-20">
            <table class="table table-border table-bordered table-hover table-bg table-sort">
                <tr>
                    <td>部门编号：
                            <asp:Label ID="lbl_bmdm" runat="server" Text="部门编号"></asp:Label>
                    </td>
                    <td>部门名称：
                            <asp:Label ID="lbl_bmmc" runat="server" Text="部门名称"></asp:Label>
                    </td>
                    <td>评测方案编号：
                            <asp:Label ID="lbl_pcfabh" runat="server" Text="评测方案编号"></asp:Label>
                    </td>
                    <td>评测方案名称：
                            <asp:Label ID="lbl_pcfamc" runat="server" Text="评测方案名称"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="mt-20">
            <asp:DataList ID="dlt_pcx_grdf" runat="server" Width="100%" DataKeyField="PCXBH" OnCancelCommand="dlt_pcx_grdf_CancelCommand" OnEditCommand="dlt_pcx_grdf_EditCommand" OnUpdateCommand="dlt_pcx_grdf_UpdateCommand">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">部门绩效单方案打分
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项编号
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项名称
                                </th>
                                <th width="5%" style="text-align: center; vertical-align: middle;">打分
                                </th>
                                <th width="5%" style="text-align: center; vertical-align: middle;">权重(%)
                                </th>
                                <th width="5%" style="text-align: center; vertical-align: middle;">单项得分
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">指标描述
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
                                <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("PCXBH") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("PCXMC") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxdf" runat="server" Text='<%#Eval("PCXDF") %>'></asp:Label>
                            </td>
    
                            <td>
                                <asp:Label ID="lbl_pcxqz" runat="server" Text='<%#Eval("PCXQZ") %>' ForeColor="Red" Font-Underline="true"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lbl_pcxdxdf" runat="server" Text='<%#Eval("PCXDXDF") %>' ForeColor="Red" Font-Underline="true"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxzbms" runat="server" Text='<%#Eval("PCXZBMS") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_dfrq" runat="server" Text='<%#Eval("DFRQ") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" ForeColor="Blue" Font-Underline="true" runat="server">编辑</asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <EditItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("PCXBH") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("PCXMC") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbx_pcxdf" runat="server" Text='<%#Eval("PCXDF") %>' onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}"
                                    onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'0')}else{this.value=this.value.replace(/\D/g,'')}">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxqz" runat="server" Text='<%#Eval("PCXQZ") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxdxdf" runat="server" Text='<%#Eval("PCXDXDF") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbx_pcxzbms" runat="server" Text='<%#Eval("PCXZBMS") %>'>
                                </asp:TextBox>
                            </td>
                            <%--                       <td>
                                <asp:Label ID="tbx_pcxzbms" runat="server" Text='<%#Eval("PCXZBMS") %>'></asp:Label>
                            </td>--%>

                            <td>
                                <asp:Label ID="lbl_dfrq" runat="server" Text='<%#Eval("DFRQ") %>'></asp:Label>
                            </td>

                            <td class="td-manage">
                                <asp:LinkButton ID="lbt_update" CommandName="Update" ForeColor="Blue" Font-Underline="true" runat="server">保存</asp:LinkButton>
                                <asp:LinkButton ID="lbtn_delete" CommandName="Cancel" runat="server" Text="取消" CssClass="command"></asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </EditItemTemplate>
                <FooterTemplate>
                    <table></table>
                </FooterTemplate>
            </asp:DataList>
            <table>
                <tr>
                    <td align="center" width="100%">
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align: center">
              <asp:Button ID="btn_fh" runat="server"
                  Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                  Width="199px" OnClick="btn_fh_Click"></asp:Button>
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
