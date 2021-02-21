<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GRJX_PCFA_DF.aspx.cs" Inherits="MAir.Views.JXGL.GRJX_PCFA_DF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>该页面暂时不做使用，同YG_GRJX_DF的第二个Datalist</title>
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
        <div>
            <strong class="icon-reorder">
                <asp:Label ID="Label3" runat="server" Text="总方案名称："></asp:Label>
                <asp:Label ID="lbl_zfamc" runat="server" Text='<%#Eval("ZFAMC") %>'></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="评测方案名称："></asp:Label>
                <asp:Label ID="lbl_pcfamc" runat="server" Text='<%#Eval("PCFAMC") %>'></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="评测方案权重（%）："></asp:Label>
                <asp:Label ID="lbl_pcfaqz" runat="server" Text='<%#Eval("PCFAQZ") %>'></asp:Label>
                %
            </strong>
            <br />
            <asp:DataList ID="dlt_pcx" runat="server" DataKeyField="ID">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <thead>
                            <tr class="text-c">
                                <th width="10%" style="text-align: center; vertical-align: middle;">序号</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项编号</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项名称</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项权重(%)</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项打分</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">评测项指标描述</th>
                                <%--                                <th width="10%" style="text-align: center; vertical-align: middle;">打分日期</th>--%>
                            </tr>
                        </thead>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                        <tbody>
                            <tr class="text-c">
                                <td width="10%" style="text-align: center; vertical-align: middle;"><%#(Container.ItemIndex + 1)%>
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
                                    <asp:TextBox ID="tbx_pcxdf" runat="server" Text="" CommandName="tbx" onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}"
                                        onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'0')}else{this.value=this.value.replace(/\D/g,'')}" placeholder="打分">
                                    </asp:TextBox>
                                </td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:TextBox ID="tbx_pcxzbms" runat="server" Text="" placeholder="指标描述">
                                    </asp:TextBox>
                                </td>
                                <%--                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:TextBox ID="tbx_dfrq" runat="server" class="input-text" Style="width: 200px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                                </td>--%>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <table style="width: 100%">
            <tr>
                <td align="center" style="width: 25%">
                    <asp:Button ID="btn_save" runat="server" class="btn  radius" Text="保存" ForeColor="White" BackColor="#60B1D7" OnClick="btn_save_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
