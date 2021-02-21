<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMJXGL.aspx.cs" Inherits="MAir.Views.JXGL.BMJXGL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>该部门名下所有评测方案及得分</title>
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
                    <td>部门编号：
                            <asp:Label ID="lbl_bmdm" runat="server" Text="部门编号"></asp:Label>
                    </td>
                    <td>部门名称：
                            <asp:Label ID="lbl_bmmc" runat="server" Text="部门名称"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="mt-20">
            <strong class="icon-reorder">选择总方案：
                  <asp:DropDownList ID="ddlt_zfa" runat="server" class="select-box" Style="width: 120px" AutoPostBack="true" OnSelectedIndexChanged="ddlt_zfa_SelectedIndexChanged">
                  </asp:DropDownList>
            </strong>
        </div>
        <div id="div">
            <asp:DataList ID="dlt_pcfa" runat="server" DataKeyField="pcfabh">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <thead>
                            <tr class="text-c">
                                <th width="5%" style="text-align: center; vertical-align: middle;">序号</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测方案编号(已打分)</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测方案名称(已打分)</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测方案权重(%)</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">该方案得分</th>
                                
                               <%-- <th width="10%" style="text-align: center; vertical-align: middle;">打分日期</th>--%>
                            </tr>
                        </thead>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <tbody>
                            <tr class="text-c">
                                <td width="5%" style="text-align: center; vertical-align: middle;"><%#(Container.ItemIndex + 1)%>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcfabh" runat="server" Text='<%#Eval("PCFABH") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcfamc" runat="server" Text='<%#Eval("PCFAMC") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcfaqz" runat="server" Text='<%#Eval("PCFAQZ") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_dfadf" runat="server" Text='<%#Eval("pcfazf") %>'></asp:Label>
                                </td>
      
                                <%--<td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_dfrq" runat="server" Text='<%#Eval("DFRQ") %>'></asp:Label>
                                </td>--%>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <div class="mt-20">
                <strong class="icon-reorder">选择评测方案进行打分：
                  <asp:DropDownList ID="ddlt_pcfa" runat="server" class="select-box" Style="width: 120px" AutoPostBack="true" OnSelectedIndexChanged="ddlt_pcfa_SelectedIndexChanged">
                  </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
               <asp:Label ID="Label1" runat="server" Text="该评测方案权重："></asp:Label>
                    <asp:Label ID="lbl_pcfaqz" runat="server" Text='<%#Eval("PCFAQZ") %>'></asp:Label>
                    %
                </strong>
            </div>
            <asp:DataList ID="dlt_pcx" runat="server" DataKeyField="bmdm" OnCancelCommand="dlt_pcx_CancelCommand" OnEditCommand="dlt_pcx_EditCommand" OnUpdateCommand="dlt_pcx_UpdateCommand">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <thead>
                            <tr class="text-c">
                                <th width="5%" style="text-align: center; vertical-align: middle;">序号</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项编号</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项名称</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项权重(%)</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项打分</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">绩效指标描述</th>
                                <%-- <th width="10%" style="text-align: center; vertical-align: middle;">打分日期</th>--%>
                                <th width="10%">操作
                                </th>
                            </tr>
                        </thead>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <tbody>
                            <tr class="text-c">
                                <td width="5%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <%#Container.ItemIndex + 1%>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("PCXBH") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("PCXMC") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxqz" runat="server" Text='<%#Eval("PCXQZ") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxdf" runat="server" Text='<%#Eval("PCXDF") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_jxzbms" runat="server" Text='<%#Eval("ZBMS") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:LinkButton ID="lbtEdit" CommandName="Edit" ForeColor="Blue" Font-Underline="true" runat="server">编辑</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
                <EditItemTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <tbody>
                            <tr class="text-c">
                                <td width="5%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <%#Container.ItemIndex + 1%>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("PCXBH") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("PCXMC") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pcxqz" runat="server" Text='<%#Eval("PCXQZ") %>'></asp:Label>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:TextBox ID="tbx_pcxdf" runat="server" Text='<%#Eval("PCXDF") %>' CommandName="tbx" onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}"
                                        onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'0')}else{this.value=this.value.replace(/\D/g,'')}">
                                    </asp:TextBox>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:TextBox ID="tbx_jxzbms" runat="server" Text='<%#Eval("ZBMS") %>'></asp:TextBox>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:LinkButton ID="lbt_update" CommandName="Update" ForeColor="Blue" Font-Underline="true" runat="server">保存</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_delete" CommandName="Cancel" runat="server" Text="取消" CssClass="command"></asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EditItemTemplate>
                <FooterTemplate>
                    <table></table>
                </FooterTemplate>
            </asp:DataList>
        </div>
        <table style="width: 100%">
            <tr>
                <td align="center" style="width: 25%">
                    <asp:Button ID="btn_add" runat="server" class="btn  radius" Width="10%" Text="添加总方案" ForeColor="White" BackColor="#60B1D7" OnClick="btn_add_Click" />
                    <asp:Button ID="btn_fh" runat="server" class="btn  radius" Width="10%" Text="返回" ForeColor="White" BackColor="#60B1D7" OnClick="btn_fh_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
