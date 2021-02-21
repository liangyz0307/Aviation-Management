<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KS_Result.aspx.cs" Inherits="CUST.WKG.KS_Result" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
    <script type="text/javascript">
        function maxWin() {
            window.top.moveTo(0, 0);
            window.top.resizeTo(screen.availWidth, screen.availHeight);
        }
    </script>
</head>
<body onresize='maxWin()'>
    <article class="page-container">
        <br />
        <br />
        <form id="Form1" runat="server" class="form form-horizontal">

            <div style="text-align: center">
                <strong class="icon-reorder">
                    <asp:Label ID="lbl_mc" Font-Size="30px" runat="server"></asp:Label></strong>
            </div>
            <table style="width: 40%; margin: auto; vertical-align: middle; border: 1px solid #C0D9D9; background-color: #F6FAFD;" class="td_sjsc">
                <tbody>
                    <tr style="vertical-align: top; font-size: large; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">总成绩：</td>
                        <td colspan="3" style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_zf" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">单选题：</td>
                        <td style="width: 17%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_xz_zq_sl" runat="server"></asp:Label>
                            &nbsp;/
                            <asp:Label ID="lbl_xz_sl" runat="server"></asp:Label>
                        </td>
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">单题分值：</td>
                        <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_xz_fz" runat="server"></asp:Label>
                        </td>
                    </tr>

                     <tr style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">多选题：</td>
                        <td style="width: 17%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_dx_zq_sl" runat="server"></asp:Label>
                            &nbsp;/
                            <asp:Label ID="lbl_dx_sl" runat="server"></asp:Label>
                        </td>
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">单题分值：</td>
                        <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_dx_fz" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">判断题：</td>
                        <td style="width: 17%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_pd_zq_sl" runat="server"></asp:Label>
                            &nbsp;/
                            <asp:Label ID="lbl_pd_sl" runat="server"></asp:Label>
                        </td>
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">单题分值：</td>
                        <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_pd_fz" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Tr1" style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc" runat="server">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">填空题：</td>
                        <td style="width: 17%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_tk_zq_sl" runat="server"></asp:Label>
                            &nbsp;/
                            <asp:Label ID="lbl_tk_sl" runat="server"></asp:Label>
                        </td>
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">单题分值：</td>
                        <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_tk_fz" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Tr3" style="vertical-align: top; width: 40%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc" runat="server">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">时长(分钟)：</td>
                        <td style="width: 17%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_sc" runat="server"></asp:Label>
                        </td>
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">试题难度：</td>
                        <td style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_nd" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="row cl" style="width: 50%; margin-left: 30%">
                <div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3" style="margin-left: auto">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp; 
                        <asp:Button ID="btn_fh" runat="server" Text="确定" class="btn  radius"
                            ForeColor="White" BackColor="#60B1D7" Width="199px" OnClick="btn_fh_Click"></asp:Button>
                </div>
            </div>
        </form>
    </article>
</body>
</html>
