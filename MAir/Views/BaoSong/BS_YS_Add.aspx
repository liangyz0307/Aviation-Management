<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_YS_Add.aspx.cs" Inherits="CUST.WKG.BS_YS_Add" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
      <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <%--   <nav class="breadcrumb">个人信息管理 <span class="c-gray en">&gt;</span> 个人信息<span class="c-gray en">&gt;</span>员工添加
         </nav>--%>
            <div class="panel-head">
                <strong class="icon-reorder">预算添加</strong>
            </div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">员 工 编 号：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bh" runat="server" class="input-text"
                            Width="446px" MaxLength="10" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_bh" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报 送 岗 位：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bsgw" runat="server" class="input-text"
                            Width="446px" MaxLength="10" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_bsgw" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报 送 类 型：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_bslx" runat="server" Width="446px" Enabled="false"></asp:DropDownList>
                        <asp:Label ID="lbl_bslx" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报 送 时 间：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bssj" runat="server" class="Wdate" Height="20px" Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:Label ID="lbl_bssj" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">申 请 部 门：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_sqbm" runat="server" class="input-text"
                            Width="446px" MaxLength="3" Enabled="false"></asp:TextBox>
                        <asp:Label ID="lbl_sqbm" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">预 算 总 额：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_ysze" runat="server" class="input-text"
                            Width="446px" MaxLength="10"></asp:TextBox>
                        <asp:Label ID="lbl_ysze" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">预 算 用 途：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_ysyt" runat="server" class="input-text"
                            Width="446px" MaxLength="200"></asp:TextBox>
                        <asp:Label ID="lbl_ysyt" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">预 算 来 源：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_ysly" runat="server" class="input-text"
                            Width="446px" MaxLength="200"></asp:TextBox>
                        <asp:Label ID="lbl_ysly" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">应 用 年 限：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_yynx" runat="server" class="input-text"
                            Width="446px" MaxLength="5" Enabled="true"></asp:TextBox>
                        <asp:Label ID="lbl_yynx" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备 注：&nbsp;&nbsp;</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bz" runat="server" class="input-text"
                            Width="446px" MaxLength="200"></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>

                </tr>
            </table>


            <div class="row cl">
                <div class="row cl" style="text-align: center; width: 100%; margin: 0 auto;">
                    <table>
                        <tr>
                            <td style="text-align: right">
                                <asp:Button ID="btn_save" runat="server"
                                    Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                    Width="199px" OnClick="btn_save_Click"></asp:Button></td>
                            <td>&nbsp;</td>
                            <td style="text-align: left">
                                <asp:Button ID="btn_fh" runat="server"
                                    Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                    Width="199px" OnClick="btn_fh_Click" Style="margin-bottom: 0px"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </form>
    </article>
</body>

<script type="text/javascript">
    //$(function () {
    //    $("input[type='text'], select").each(function () {
    //        var id = $("#lbl_" + $(this).attr("id").substring(4))
    //        $(this).change(function () {
    //            if ($(this).val() != "") {
    //                if (id = $("#lbl_yynx")) { setok(id); }
    //                else {
    //                    id.text("正确");
    //                    id.css("color", "#00ff00");
    //                }
    //                if (id = $("#lbl_ysze")) { setok(id); }
    //                else {
    //                    id.text("正确");
    //                    id.css("color", "#00ff00");
    //                }
    //            }
    //            else {
    //                id.text("错误");
    //                id.css("color", "#ff0000");
    //            }
    //        });
    //    });
    //    function setok(id) {
    //        var re = /^\d+(?=\.{0,1}\d+$|$)/
    //        if (!re.test($("#tbx_zbybh").val())) {
    //            id.text("请输入数字！");
    //            id.css("color", "#ff0000");
    //            return false;
    //        }
    //        else if (!re.test($("#tbx_ysze").val())) {
    //            id.text("请输入数字！");
    //            id.css("color", "#ff0000");
    //            return false;
    //        }
    //        else {
    //            id.text("正确");
    //            id.css("color", "#00ff00");
    //        }
    //    }
    //});
    //$(document).ready(function () {
    var i = 0;

    //预算总额
    $("#btn_save").click(function () {

        //员工编号

        $("#lbl_bh").text("正确");
        $("#lbl_bh").css("color", "#00ff00");

        //报送岗位

        $("#lbl_bsgw").text("正确");
        $("#lbl_bsgw").css("color", "#00ff00");

        //报送IP

        $("#lbl_bsip").text("正确");
        $("#lbl_bsip").css("color", "#00ff00");
        //报送时间

        if ($("#tbx_bssj").val() != "") {
            $("#lbl_bssj").text("正确");
            $("#lbl_bssj").css("color", "#00ff00");
        } else {
            $("#lbl_bssj").text("错误");
            $("#lbl_bssj").css("color", "#ff0000");
            i = 1;
        }

        //申请部门

        $("#lbl_sqbm").text("正确");
        $("#lbl_sqbm").css("color", "#00ff00");


        //报送岗位

        $("#lbl_bsgw").text("正确");
        $("#lbl_bsgw").css("color", "#00ff00");
        //报送类型

        if ($("#ddlt_bslx").val().trim() == "-1") {
            $("#lbl_bslx").text("错误：请选择！");
            $("#lbl_bslx").css("color", "#ff0000");
            $("#lbl_bslx").focus();
            return false;
        }
        else {
            $("#lbl_bslx").text("正确");
            $("#lbl_bslx").css("color", "#00ff00");
        }
        //预算总额
        if ($("#tbx_ysze").val() != "") {
            var ysze = /^\d+(?=\.{0,1}\d+$|$)/
            if (!ysze.test($("#tbx_ysze").val())) {
                $("#lbl_ysze").text("请输入数字！");
                $("#lbl_ysze").css("color", "#ff0000");
                i = 1;
            }
            else {
                $("#lbl_ysze").text("正确");
                $("#lbl_ysze").css("color", "#00ff00");
            }
        } else {
            $("#lbl_ysze").text("错误");
            $("#lbl_ysze").css("color", "#ff0000");
            i = 1;
        }
        //预算用途

        if ($("#tbx_ysyt").val() != "") {
            $("#lbl_ysyt").text("正确");
            $("#lbl_ysyt").css("color", "#00ff00");
        } else {
            $("#lbl_ysyt").text("错误");
            $("#lbl_ysyt").css("color", "#ff0000");
            i = 1;
        }

        //预算来源

        if ($("#tbx_ysly").val() != "") {
            $("#lbl_ysly").text("正确");
            $("#lbl_ysly").css("color", "#00ff00");
        } else {
            $("#lbl_ysly").text("错误");
            $("#lbl_ysly").css("color", "#ff0000");
            i = 1;
        }

        //应用年限


        if ($("#tbx_yynx").val() != "") {
            var re = /^\d+(?=\.{0,1}\d+$|$)/
            if (!re.test($("#tbx_yynx").val())) {
                $("#lbl_yynx").text("请输入数字！");
                $("#lbl_yynx").css("color", "#ff0000");
                i = 1;
            }
            else {
                $("#lbl_yynx").text("正确");
                $("#lbl_yynx").css("color", "#00ff00");
            }
        }
        else {

            $("#lbl_yynx").text("错误");
            $("#lbl_yynx").css("color", "#ff0000");
            i = 1;
        }
        //备注
        $("#lbl_bz").text("正确");
        $("#lbl_bz").css("color", "#00ff00");


        if (i == 0) {
            return true;
        }
        else {
            i = 0;
            return false;
        }
    });

    //});
</script>
</html>
