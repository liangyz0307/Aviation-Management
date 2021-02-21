<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_Edit.aspx.cs" Inherits="MAir.HouTai.JS_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script type="text/javascript" src="../../../Content/js/jquery.js"></script>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">

            <table style="border-top: 2px solid #C0D9D9; border: 2px solid #C0D9D9;">
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">角色名称 ：<asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:TextBox ID="tbx_jsmc" runat="server" Height="26px" Width="50%" placeholder="角色名称"></asp:TextBox>
                        <asp:Label ID="lbl_jsmc" runat="server"></asp:Label>
                    </td>
                </tr>
              
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">备注 ： 
                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:TextBox ID="tbx_bz" runat="server" Height="60px" Width="50%" Style="resize: none" TextMode="MultiLine" placeholder="备注"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btn_bc" runat="server"
                                Text="保存" class="btn radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_bc_Click"></asp:Button></td>
                        <td>&nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="btn_fh" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_fh_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
            <script type="text/javascript">
                $(document).ready(function () {
                    $("#tbx_jsmc").blur(function () {
                        if ($("#tbx_jsmc").val().trim() != "") {
                            $("#lbl_jsmc").text("正确");
                            $("#lbl_jsmc").css("color", "#00ff00");
                        } else {
                            $("#lbl_jsmc").text("错误：角色名称不能为空");
                            $("#lbl_jsmc").css("color", "#ff0000");
                        }
                    });
                    //按钮判断
                    $("#btn_bc").click(function () {
                        var flag = 0;
                        if ($("#tbx_jsmc").val().trim() == "") {
                            $("#lbl_jsmc").text("错误：角色名称不能为空");
                            $("#lbl_jsmc").css("color", "#ff0000");
                            $("#tbx_jsmc").focus();
                            flag = 1;
                        }
                        else {
                            $("#lbl_jsmc").text("正确");
                            $("#lbl_jsmc").css("color", "#00ff00");
                        }
                        if (flag == 1) {
                            return false;
                        }

                    });
                });
            </script>
        </form>
    </article>
</body>
</html>
