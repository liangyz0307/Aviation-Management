<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CJ_Detial.aspx.cs" Inherits="CUST.WKG.ZXPX.main.CJ_Detial" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css"
        id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <style type="text/css">
        td.td_zxks {
            background: #F6FAFD;
            border: 1px dotted;
        }

        table.tab_zxks {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <br />
        <div style="text-align: center">
            <strong class="icon-reorder">
                <asp:Label ID="lbl_mc" Font-Size="30px" runat="server"></asp:Label></strong>
        </div>

        <form id="Form1" runat="server" class="form form-horizontal">
            <div id="div_CX" style="text-align: center" runat="server">
                <strong class="icon-reorder" style="font-size: 150%">考生号:</strong>
                <asp:TextBox ID="tbx_ksh" runat="server" Width="17%" Height="24px" MaxLength="10"></asp:TextBox>
                <asp:Button ID="btn_cjcx" runat="server" class="btn  radius" Text="查询成绩" Font-Size="110%"
                    ForeColor="White" BackColor="#60B1D7" Width="14%" OnClick="btn_cjcx_Click" />
            </div>
            <asp:DataList ID="dlt_djk" runat="server" DataKeyField="id">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%; border: 1px solid #C0D9D9; background-color: #F6FAFD">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16"><strong style="font-size: 150%">成绩列表</strong></th>
                            </tr>
                            <tr class="text-c">
                                <th width="10%" style="text-align: center; vertical-align: middle;">考生号</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">总分</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">单选题</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">多选题</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">判断题</th>
                                <th width="10%" style="text-align: center; vertical-align: middle;">填空题</th>
                                <th width="20%" style="text-align: center; vertical-align: middle;">交卷时间</th>
                            </tr>
                        </thead>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width: 100%; border: 1px solid #C0D9D9; background-color: #F6FAFD">
                        <tbody>
                            <tr class="text-c">
                                <td width="10%" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_ksh" runat="server" Text='<%#Eval("ksh") %>'></asp:Label></td>
                                <td width="10%" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_zf" runat="server" Text='<%#Eval("zf") %>'></asp:Label></td>
                                <td width="10%" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_xzt" runat="server" Text='<%#Eval("xzt") %>'></asp:Label></td>
                                <td width="10%" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_dxt" runat="server" Text='<%#Eval("dxt") %>'></asp:Label></td>
                                <td width="10%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_pdt" runat="server" Text='<%#Eval("pdt") %>'></asp:Label></td>
                                <td width="10%" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_tkt" runat="server" Text='<%#Eval("tkt") %>'></asp:Label></td>
                                <td width="20%" class="class_td" style="text-align: center; vertical-align: middle;">
                                    <asp:Label ID="lbl_kssj_jssj" runat="server" Text='<%#Eval("jssj") %>'></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <div style="text-align: center">
                <asp:Button ID="btn_fh" runat="server" class="btn  radius" Text="返回" ForeColor="White" BackColor="#60B1D7" Width="14%" OnClick="btn_fh_Click" />
            </div>
            <br />
            <br />
            <br />
            <table style="width: 50%; margin: auto;">
                <asp:HiddenField ID="HF_cl_id" runat="server" />
            </table>
        </form>
    </article>
</body>
</html>
