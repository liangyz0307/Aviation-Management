<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PCGL_Add.aspx.cs" Inherits="CUST.WKG.PCGL_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>员工个人评测项添加</title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="form1" runat="server">
            <div class="panel-header">
                <strong class="icon-reorder">评测项添加</strong>
            </div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">评测项名称：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_pcxmc" runat="server" class="input-text" placeholder="名称" Style="width: 300px"></asp:TextBox>
                        <asp:Label ID="lbl_pcxmc" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">评测项描述：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_pcxzbms" runat="server" class="input-text" placeholder="名称" Style="width: 300px"></asp:TextBox>
                        <asp:Label ID="lbl_pcxzbms" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="panel-header">
                <table style="width: 100%">
                    <tr>
                        <td align="center" style="width: 25%">
                            <asp:Button ID="btn_save" runat="server" Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                Width="199px" OnClick="btn_save_Click"></asp:Button>
                        </td>
                        <td align="center" style="width: 25%">
                            <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                Width="199px" OnClick="btn_fh_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </article>
</body>
</html>
