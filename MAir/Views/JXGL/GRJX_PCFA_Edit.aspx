<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GRJX_PCFA_Edit.aspx.cs" Inherits="MAir.Views.JXGL.GRJX_PCFA_Edit" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>个人绩效单方案打分</title>
        <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mt-20">
            <table class="table table-border table-bordered table-hover table-bg table-sort">
                <tr>
                    <td>员工编号：
                            <asp:Label ID="lbl_ygbh" runat="server" Text="员工编号"></asp:Label>
                    </td>
                    <td>姓名：
                            <asp:HyperLink ID="hlnk_xm" runat="server" ForeColor="Blue" Font-Underline="true" Text="姓名"
                                NavigateUrl='<%#"GRJX_YGXX.aspx?bh=" + Eval("BH")+"&"+ "pcfabh="+Eval("PCFABH")+"&"+"bmdm="+Eval("bmdm")+"&"+"gwdm="+Eval("gwdm")%>'>
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
            <asp:DataList ID="dlt_pcx_grdf" runat="server" Width="100%" DataKeyField="ygbh" OnCancelCommand="dlt_pcx_grdf_CancelCommand" OnEditCommand="dlt_pcx_grdf_EditCommand" OnUpdateCommand="dlt_pcx_grdf_UpdateCommand">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">个人绩效单方案打分
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">总方案编号
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">总方案名称
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测方案编号
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测方案名称
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项编号
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项名称
                                </th>
                                <th width="5%" style="text-align: center; vertical-align: middle;">权重(%)
                                </th>
                                <th width="5%" style="text-align: center; vertical-align: middle;">个人得分
                                </th>
                                <th width="5%" style="text-align: center; vertical-align: middle;">单项得分(权重*个人得分)
                                </th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">绩效指标描述
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
                                <asp:Label ID="lbl_zfabh" runat="server" Text='<%#Eval("ZFABH") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_zfamc" runat="server" Text='<%#Eval("ZFAMC") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcfabh" runat="server" Text='<%#Eval("PCFABH") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcfamc" runat="server" Text='<%#Eval("PCFAMC") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("PCXBH") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("PCXMC") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_qz" runat="server" Text='<%#Eval("PCXQZ") %>' ForeColor="Red" Font-Underline="true"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_grdf" runat="server" Text='<%#Eval("GRDF") %>' ForeColor="Red" Font-Underline="true"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_dxdf" runat="server" Text='<%#Eval("DXDF") %>' ForeColor="Red" Font-Underline="true"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_jxzbms" runat="server" Text='<%#Eval("JXZBMS") %>'></asp:Label>
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
                                <asp:Label ID="lbl_zfabh" runat="server" Text='<%#Eval("ZFABH") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_zfamc" runat="server" Text='<%#Eval("ZFAMC") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcfabh" runat="server" Text='<%#Eval("PCFABH") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcfamc" runat="server" Text='<%#Eval("PCFAMC") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("PCXBH") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("PCXMC") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_qz" runat="server" Text='<%#Eval("PCXQZ") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbx_grdf" runat="server" Text='<%#Eval("GRDF") %>' onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}"
                                    onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'0')}else{this.value=this.value.replace(/\D/g,'')}">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lbl_dxdf" runat="server" Text='<%#Eval("DXDF") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbx_jxzbms" runat="server" Text='<%#Eval("JXZBMS") %>'></asp:TextBox>
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
            &nbsp;  
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
