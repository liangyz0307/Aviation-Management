<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ST_PDT_Update.aspx.cs" Inherits="CUST.WKG.ST_PDT_Update" %>

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
    <%--   UEdit--%>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.config.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.all.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/lang/zh-cn/zh-cn.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>
    <script type="text/javascript">
        //实例化编辑器
        //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
        var ue = UE.getEditor('tbx_tg');
    </script>
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="panel-head">
            </div>
            <table style="width: 100%; margin: auto; vertical-align: middle; border: 1px solid #C0D9D9; background-color: #F6FAFD">
                <tbody>

                    <tr>
                        <th scope="col" colspan="16"><strong style="font-size: 150%">判断题编辑</strong></th>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">试题题干：<span class="c-red">*</span></td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:TextBox ID="tbx_tg" runat="server" MaxLength="1000" Width="100%" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            <asp:Label ID="lbl_tg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">正确答案：<span class="c-red">*</span></td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:DropDownList ID="ddlt_da" runat="server" class="select-box" Style="width: 150px">
                            </asp:DropDownList>
                            <asp:Label ID="lbl_da" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">试题难度：<span class="c-red">*</span></td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:DropDownList ID="ddlt_stnd" runat="server" class="select-box" Style="width: 150px">
                            </asp:DropDownList>
                            <asp:Label ID="lbl_nd" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">适用科目：<span class="c-red">*</span></td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:DropDownList ID="ddlt_km" runat="server" class="select-box" Style="width: 150px">
                            </asp:DropDownList>
                            <asp:Label ID="lbl_km" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">类别：<span class="c-red">*</span></td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:DropDownList ID="ddlt_stlb" runat="server" class="select-box" Style="width: 150px">
                            </asp:DropDownList>
                            <asp:Label ID="lbl_stlb" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">适用岗位：<span class="c-red">*</span></td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:CheckBoxList ID="cbxl_gw" runat="server" RepeatColumns="4">
                                    </asp:CheckBoxList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:CheckBox ID="cbx_qx" runat="server" AutoPostBack="True" OnCheckedChanged="cbx_qx_CheckedChanged" Text="全选" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Label ID="lbl_gw" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">考察知识点：<span class="c-red">*</span></td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                            <asp:TextBox ID="tbx_kczsd" runat="server" class="input-text" Width="446px" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
                            <asp:Label ID="lbl_kczsd" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div style="width: 80%; margin: auto; text-align: center;">
                <asp:Button ID="btn_save" runat="server"
                    Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                    Width="199px" OnClick="btn_save_Click"></asp:Button>
                &nbsp; 
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
        //试题题干
        $("#tbx_tg").blur(function () {
            if ($("#tbx_tg").val() != "") {
                $("#lbl_tg").text("正确");
                $("#lbl_tg").css("color", "#00ff00");
            } else {
                $("#lbl_tg").text("错误：不能为空");
                $("#lbl_tg").css("color", "#ff0000");
            }
        });
        $("#tbx_da").blur(function () {
            if ($("#tbx_da").val() != "") {
                $("#lbl_da").text("正确");
                $("#lbl_da").css("color", "#00ff00");
            } else {
                $("#lbl_da").text("错误：不能为空");
                $("#lbl_da").css("color", "#ff0000");
            }
        });
        //试题难度
        $("#ddlt_stnd").change(function () {
            if ($("#ddlt_stnd option:selected").val() != "-1") {
                $("#lbl_nd").text("正确");
                $("#lbl_nd").css("color", "#00ff00");
            } else {
                $("#lbl_nd").text("请选择");
                $("#lbl_nd").css("color", "#ff0000");
            }
        });
        //适用科目
        $("#ddlt_km").change(function () {
            if ($("#ddlt_km option:selected").val() != "-1") {
                $("#lbl_km").text("正确");
                $("#lbl_km").css("color", "#00ff00");
            } else {
                $("#lbl_km").text("请选择");
                $("#lbl_km").css("color", "#ff0000");
            }
        });
        //适用岗位
        $("#ddlt_gw").change(function () {
            if ($("#ddlt_gw option:selected").val() != "-1") {
                $("#lbl_gw").text("正确");
                $("#lbl_gw").css("color", "#00ff00");
            } else {
                $("#lbl_gw").text("请选择");
                $("#lbl_gw").css("color", "#ff0000");
            }
        });
        //考察知识点
        $("#tbx_kczsd").blur(function () {
            if ($("#tbx_kczsd").val() != "") {
                $("#lbl_kczsd").text("正确");
                $("#lbl_kczsd").css("color", "#00ff00");
            } else {
                $("#lbl_kczsd").text("错误：不能为空");
                $("#lbl_kczsd").css("color", "#ff0000");
            }
        });
    });
</script>
</html>
