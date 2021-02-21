<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZXXX_SP_Add.aspx.cs" Inherits="CUST.WKG.ZXXX_SP_Add" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>在线学习—视频上传</title>
    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
         <%--   UEdit--%>
    <script type="text/javascript" src="../../UEdit/utf8-net/ZXXX_SP.config.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.all.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/lang/zh-cn/zh-cn.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>

    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">上传人：</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_scr" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">视频名：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_wjm" Width="446px" MaxLength="25" runat="server" class="input-text" placeholder="请与视频名保持一致"></asp:TextBox>
                        <asp:Label ID="lbl_wjm" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">视频上传及简介：</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                           <asp:TextBox ID="tbx_spsc" name="txtEditorContents" runat="server" TextMode="MultiLine" Height="300px" Width="450px" ClientIDMode="Static"></asp:TextBox>
                        <asp:Label ID="lbl_zdgznr" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btn_save" runat="server"
                                Text="保存" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_save_Click" ></asp:Button></td>
                        <td>&nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="btn_fh" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" style="margin-left: 459px" OnClick="btn_fh_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </article>
</body>
<script src="../css/js/jquery.js" type="text/javascript"></script>
<script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
<script type="text/javascript">  //实例化编辑器

    var ue = UE.getEditor('tbx_spsc');
  
    var i = 0;

    var ue = UE.getEditor('tbx_spsc', {

        autoFloatEnabled: false//是否保持toolbar位置不懂
    });
    $("#btn_save").click(function () { //文件名
        if ($("#tbx_wjm").val() != "") {
            $("#lbl_wjm").text("正确");
            $("#lbl_wjm").css("color", "#00ff00");
        } else {
            $("#lbl_wjm").text("文件名不能为空");
            $("#lbl_wjm").css("color", "#ff0000");
            i = 1;
        }
        if (i == 0) {
            return true;
        }
        else {
            i = 0;
            return false;
        }
        });
  </script>
</html>

