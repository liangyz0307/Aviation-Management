<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMZFA_Add.aspx.cs" Inherits="MAir.Views.JXGL.BMZFA_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <title>部门绩效总方案添加</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel-header">
            <strong class="icon-reorder">部门总方案添加</strong>
        </div>
        <div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:DataList ID="dlt_pcfa_add" runat="server">
                        <%--DataKeyField="ZFABH"--%>
                        <HeaderTemplate>
                            <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                                <thead>
                                    <tr class="text-c">
                                        <th width="5%" style="text-align: center; vertical-align: middle;">选择</th>
                                        <th width="5%" style="text-align: center; vertical-align: middle;">序号</th>
                                        <th width="10%" style="text-align: center; vertical-align: middle;">评测方案编号</th>
                                        <th width="10%" style="text-align: center; vertical-align: middle;">评测方案名称</th>
                                        <th width="10%" style="text-align: center; vertical-align: middle;">权重%(填写0~100之间的整数，且权重之和要求为100)</th>
                                    </tr>
                                </thead>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                                <tbody>
                                    <tr class="text-c">
                                        <td width="5%" style="text-align: center; vertical-align: middle;">
                                            <asp:CheckBox ID="cbx_pcfa" runat="server" />
                                        </td>
                                        <td width="5%" style="text-align: center; vertical-align: middle;"><%#(Container.ItemIndex + 1)%>
                                        </td>
                                        <td width="10%" style="text-align: center; vertical-align: middle;">
                                            <asp:Label ID="lbl_pcfabh" runat="server" Text='<%#Eval("PCFABH") %>'></asp:Label>
                                        </td>
                                        <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                            <asp:Label ID="lbl_pcfamc" runat="server" Text='<%#Eval("PCFAMC") %>'></asp:Label>
                                        </td>
                                        <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                            <asp:TextBox ID="tbx_pcfaqz" runat="server" Text="" CommandName="tbx" onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}"
                                                onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'0')}else{this.value=this.value.replace(/\D/g,'')}">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </tr>
            </table>
        </div>
        <div class="panel-header">
            <table>
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_pcfamc" runat="server" Text="新建总方案名称："></asp:Label>
                        <asp:TextBox ID="tbx_zfamc" runat="server" class="input-text" placeholder="总方案名称" Style="width: 300px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="panel-header">
            <table>
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_save" runat="server" Text="添加" class="btn  radius" ForeColor="White" BackColor="#60B1D7" Width="199px" OnClick="btn_save_Click"></asp:Button>
                    </td>
                    <td align="center">
                        <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" Width="199px" OnClick="btn_fh_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
