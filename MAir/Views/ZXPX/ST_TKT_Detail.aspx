<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ST_TKT_Detail.aspx.cs" Inherits="CUST.WKG.ST_TKT_Detail" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>
    <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <table style="width: 100%; margin: auto; vertical-align: middle; border: 1px solid #C0D9D9; background-color: #F6FAFD">
                <tbody>
                       <tr>
                        <th scope="col" colspan="16"><strong style="font-size: 150%">填空题详细</strong></th>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">试题题干：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_tg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">正确答案：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_da" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">试题难度：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_nd" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">适用科目：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_km" runat="server"></asp:Label>
                        </td>
                    </tr>
                        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">类别：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_stlb" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">适用岗位：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_gw" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">考察知识点：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_kczsd" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">录入人：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_lrr" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">录入时间：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_lrsj" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">审核人：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_shr" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">当前状态：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_zt" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">驳回原因：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc" aria-multiline="False">
                            <asp:Label ID="lbl_yysm" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div style="width: 80%; margin: auto; text-align: center;">
                &nbsp; 
            <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" Width="199px" OnClick="btn_fh_Click"></asp:Button>
            </div>
        </form>
    </article>
</body>
</html>
