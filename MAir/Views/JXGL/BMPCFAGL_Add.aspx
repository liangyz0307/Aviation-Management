﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMPCFAGL_Add.aspx.cs" Inherits="MAir.Views.JXGL.BMPCFAGL_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门评测方案添加</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel-header">
            <strong class="icon-reorder">评测方案添加</strong>
        </div>
        <div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:DataList ID="dlt_pcfa_add" runat="server" DataKeyField="ID">
                        <HeaderTemplate>
                            <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%">
                                <thead>
                                    <tr class="text-c">
                                        <th width="5%" style="text-align: center; vertical-align: middle;">选择</th>
                                        <th width="5%" style="text-align: center; vertical-align: middle;">序号</th>
                                        <th width="10%" style="text-align: center; vertical-align: middle;">评测项编号</th>
                                        <th width="10%" style="text-align: center; vertical-align: middle;">评测项名称</th>
                                        <th width="15%" style="text-align: center; vertical-align: middle;">权重%(填写0~100之间的整数，且权重之和要求为100)</th>
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
                                            <asp:Label ID="lbl_pcxbh" runat="server" Text='<%#Eval("PCXBH") %>'></asp:Label>
                                        </td>
                                        <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                            <asp:Label ID="lbl_pcxmc" runat="server" Text='<%#Eval("PCXMC") %>'></asp:Label>
                                        </td>
                                        <td width="15%" class="class_td" style="text-align: center; vertical-align: middle;">
                                            <asp:TextBox ID="tbx_pcxqz" runat="server" Text="" CommandName="tbx" onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}"
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
        <div class="panel-header" style="text-align:center">
            <asp:Label ID="lbl_pcfamc" runat="server" Text="新建评测方案名称："></asp:Label>
            <asp:TextBox ID="tbx_pcfamc" runat="server" class="input-text" placeholder="名称" Style="width: 300px"></asp:TextBox>
            <br/>
  <%--      </div>
        <div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">--%>
            <asp:Button ID="btn_save" runat="server" Text="添加" class="btn  radius" ForeColor="White" BackColor="#60B1D7" Width="199px" OnClick="btn_save_Click"></asp:Button>
            &nbsp; 
            <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" Width="199px" OnClick="btn_fh_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
