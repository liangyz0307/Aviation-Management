<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KS_Detail.aspx.cs" Inherits="CUST.WKG.KS_Detail" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            <div style="text-align: center">
                <strong style="font-size: 150%">
                    <asp:Label ID="lbl_mc" runat="server"></asp:Label></strong>
            </div>
            <table style="width: 100%; margin: auto; vertical-align: middle; border: 1px solid #C0D9D9; background-color: #F6FAFD">
                <tbody>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 3%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">试卷总分：</td>
                        <td colspan="4" style="text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_zf" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 3%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">单选题数量：</td>
                        <td colspan="2" style="width: 1%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_xz_sl" runat="server"></asp:Label>
                        </td>
                        <td style="width: 1%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">单题分值：</td>
                        <td colspan="2" style="width: 7%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_xz_fz" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 3%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">多选题数量：</td>
                        <td colspan="2" style="width: 1%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_dx_sl" runat="server"></asp:Label>
                        </td>
                        <td style="width: 1%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">单题分值：</td>
                        <td colspan="2" style="width: 7%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_dx_fz" runat="server"></asp:Label>
                        </td>
                    </tr>


                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 3%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">判断题数量：</td>
                        <td colspan="2" style="width: 1%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_pd_sl" runat="server"></asp:Label>
                        </td>
                        <td style="width: 1%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">单题分值：</td>
                        <td colspan="2" style="width: 7%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_pd_fz" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Tr1" style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc" runat="server">
                        <td style="width: 3%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">填空题数量：</td>
                        <td colspan="2" style="width: 1%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_tk_sl" runat="server"></asp:Label>
                        </td>
                        <td style="width: 1%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">单题分值：</td>
                        <td colspan="2" style="width: 7%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_tk_fz" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Tr3" style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc" runat="server">
                        <td style="width: 3%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">时长(分钟)：</td>
                        <td colspan="2" style="width: 1%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_sc" runat="server"></asp:Label>
                        </td>
                        <td style="width: 1%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">试题难度：</td>
                        <td colspan="2" style="width: 7%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_nd" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 3%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">适用科目：</td>
                        <td colspan="2" style="width: 1%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_km" runat="server"></asp:Label>
                        </td>
                        <td style="width: 1%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">适用岗位：</td>
                        <td colspan="2" style="width: 7%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_gw" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 3%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">试题类别：</td>
                        <td colspan="4" style="width: 1%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_lb" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 3%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">出题人：</td>
                        <td colspan="2" style="width: 1%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_ctr" runat="server"></asp:Label>
                        </td>
                        <td style="width: 1%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">出题时间：</td>
                        <td colspan="2" style="width: 7%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:Label ID="lbl_ctsj" runat="server"></asp:Label>
                        </td>
                    </tr>


                </tbody>
            </table>
            <div style="width: 80%; margin: auto; text-align: center;">
                <asp:Button ID="btn_fh" runat="server"
                    Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                    Width="199px" OnClick="btn_fh_Click"></asp:Button>
            </div>
        </form>
    </article>
</body>
<script src="../css/js/jquery.js" type="text/javascript"></script>
<script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        //1.组卷名称
        $("#tbx_mc").blur(function () {
            if ($("#tbx_mc").val() != "") {
                $("#lbl_mc").text("正确");
                $("#lbl_mc").css("color", "#00ff00");
            } else {
                $("#lbl_mc").text("错误：组卷名称不能为空");
                $("#lbl_mc").css("color", "#ff0000");
            }
        });
        //2.总分
        $("#tbx_zf").blur(function () {
            if ($("#tbx_zf").val() != "") {
                var reg = /^\d{1,3}$/;
                if (reg.test($("#tbx_zf").val()) == false) {
                    $("#lbl_zf").text("错误：总分必须为1-3位数字");
                    $("#lbl_zf").css("color", "#ff0000");
                } else {
                    $("#lbl_zf").text("正确");
                    $("#lbl_zf").css("color", "#00ff00");
                }
            } else {
                $("#lbl_zf").text("错误：总分不能为空！");
                $("#lbl_zf").css("color", "#ff0000");
            }
        });
        //3.选择题数量
        $("#tbx_xz_sl").blur(function () {
            if ($("#tbx_xz_sl").val() != "") {
                var reg = /^\d{1,3}$/;
                if (reg.test($("#tbx_xz_sl").val()) == false) {
                    $("#lbl_xz_sl").text("错误：选择题数量必须为1-3位数字");
                    $("#lbl_xz_sl").css("color", "#ff0000");
                } else {
                    $("#lbl_xz_sl").text("正确");
                    $("#lbl_xz_sl").css("color", "#00ff00");
                }
            } else {
                $("#lbl_xz_sl").text("错误：选择题数量不能为空！");
                $("#lbl_xz_sl").css("color", "#ff0000");
            }
        });
        //4.单个选择题分值
        $("#tbx_xz_fz").blur(function () {
            if ($("#tbx_xz_fz").val() != "") {
                var reg = /^\d{1,3}$/;
                if (reg.test($("#tbx_xz_fz").val()) == false) {
                    $("#lbl_xz_fz").text("错误：单个选择题分值必须为1-3位数字");
                    $("#lbl_xz_fz").css("color", "#ff0000");
                } else {
                    $("#lbl_xz_fz").text("正确");
                    $("#lbl_xz_fz").css("color", "#00ff00");
                }
            } else {
                $("#lbl_xz_fz").text("错误：单个选择题分值不能为空！");
                $("#lbl_xz_fz").css("color", "#ff0000");
            }
        });
        //5.判断题数量
        $("#tbx_pd_sl").blur(function () {
            if ($("#tbx_pd_sl").val() != "") {
                var reg = /^\d{1,3}$/;
                if (reg.test($("#tbx_pd_sl").val()) == false) {
                    $("#lbl_pd_sl").text("错误：判断题数量必须为1-3位数字");
                    $("#lbl_pd_sl").css("color", "#ff0000");
                } else {
                    $("#lbl_pd_sl").text("正确");
                    $("#lbl_pd_sl").css("color", "#00ff00");
                }
            } else {
                $("#lbl_pd_sl").text("错误：判断题数量不能为空！");
                $("#lbl_pd_sl").css("color", "#ff0000");
            }
        });
        //6.单个判断题分值
        $("#tbx_pd_fz").blur(function () {
            if ($("#tbx_pd_fz").val() != "") {
                var reg = /^\d{1,3}$/;
                if (reg.test($("#tbx_pd_fz").val()) == false) {
                    $("#lbl_pd_fz").text("错误：单个判断题分值必须为1-3位数字");
                    $("#lbl_pd_fz").css("color", "#ff0000");
                } else {
                    $("#lbl_pd_fz").text("正确");
                    $("#lbl_pd_fz").css("color", "#00ff00");
                }
            } else {
                $("#lbl_pd_fz").text("错误：单个判断题分值不能为空！");
                $("#lbl_pd_fz").css("color", "#ff0000");
            }
        });
        //7.填空题数量
        $("#tbx_tk_sl").blur(function () {
            if ($("#tbx_tk_sl").val() != "") {
                var reg = /^\d{1,3}$/;
                if (reg.test($("#tbx_tk_sl").val()) == false) {
                    $("#lbl_tk_sl").text("错误：填空题数量必须为1-3位数字");
                    $("#lbl_tk_sl").css("color", "#ff0000");
                } else {
                    $("#lbl_tk_sl").text("正确");
                    $("#lbl_tk_sl").css("color", "#00ff00");
                }
            } else {
                $("#lbl_tk_sl").text("错误：填空题数量不能为空！");
                $("#lbl_tk_sl").css("color", "#ff0000");
            }
        });
        //8.单个填空题分值
        $("#tbx_tk_fz").blur(function () {
            if ($("#tbx_tk_fz").val() != "") {
                var reg = /^\d{1,3}$/;
                if (reg.test($("#tbx_tk_fz").val()) == false) {
                    $("#lbl_tk_fz").text("错误：单个填空题分值必须为1-3位数字");
                    $("#lbl_tk_fz").css("color", "#ff0000");
                } else {
                    $("#lbl_tk_fz").text("正确");
                    $("#lbl_tk_fz").css("color", "#00ff00");
                }
            } else {
                $("#lbl_tk_fz").text("错误：单个填空题分值不能为空！");
                $("#lbl_tk_fz").css("color", "#ff0000");
            }
        });
        //9.时长
        $("#tbx_sc").blur(function () {
            if ($("#tbx_sc").val() != "") {
                var reg = /^\d{1,3}$/;
                if (reg.test($("#tbx_sc").val()) == false) {
                    $("#lbl_sc").text("错误：时长必须为1-3位数字");
                    $("#lbl_sc").css("color", "#ff0000");
                } else {
                    $("#lbl_sc").text("正确");
                    $("#lbl_sc").css("color", "#00ff00");
                }
            } else {
                $("#lbl_sc").text("错误：时长不能为空！");
                $("#lbl_sc").css("color", "#ff0000");
            }
        });
        //10.试题难度
        $("#ddlt_stnd").change(function () {
            if ($("#ddlt_stnd option:selected").val() != "-1") {
                $("#lbl_nd").text("正确");
                $("#lbl_nd").css("color", "#00ff00");
            } else {
                $("#lbl_nd").text("请选择");
                $("#lbl_nd").css("color", "#ff0000");
            }
        });
        //11.适用科目
        $("#ddlt_km").change(function () {
            if ($("#ddlt_km option:selected").val() != "-1") {
                $("#lbl_km").text("正确");
                $("#lbl_km").css("color", "#00ff00");
            } else {
                $("#lbl_km").text("请选择");
                $("#lbl_km").css("color", "#ff0000");
            }
        });
        //12.适用岗位
        $("#ddlt_gw").change(function () {
            if ($("#ddlt_gw option:selected").val() != "-1") {
                $("#lbl_gw").text("正确");
                $("#lbl_gw").css("color", "#00ff00");
            } else {
                $("#lbl_gw").text("请选择");
                $("#lbl_gw").css("color", "#ff0000");
            }
        });
    });
</script>
</html>
