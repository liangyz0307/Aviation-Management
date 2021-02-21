<%@ Page Language="C#"  MasterPageFile="Sys.Master" AutoEventWireup="true" CodeBehind="MHZYBS_Edit.aspx.cs" Inherits="CUST.WKG.MHZYBS_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
        <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"=></script>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="kg_content" runat="server">
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <%--   <nav class="breadcrumb">个人信息管理 <span class="c-gray en">&gt;</span> 个人信息<span class="c-gray en">&gt;</span>员工添加
         </nav>--%>

            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报 送 员 工 编 号：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bsygbh" runat="server" class="input-text" placeholder="报送员工编号"
                            Width="446px" MaxLength="10" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_bsygbh" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送岗位：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bsgw" runat="server" class="input-text" placeholder="报送岗位"
                            Width="446px" MaxLength="6" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_bsgw" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报 送 类 型：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">

                        <asp:TextBox ID="tbx_bslx" runat="server" class="input-text" placeholder="报送类型"
                            Width="446px" MaxLength="6" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_bslx" runat="server"></asp:Label>
                    </td>
                </tr>



                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报 送 IP：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bsip" runat="server" class="input-text" placeholder="报送IP"
                            Width="446px" MaxLength="50" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_bsip" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报 送 时 间：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bssj" runat="server" class="input-text" placeholder="报送时间"
                            Width="446px" MaxLength="50" onclick="lhgcalendar()" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_bssj" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送模式：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bsms" runat="server" class="input-text" placeholder="报送模式"
                            Width="446px" MaxLength="50" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_bsms" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">解决方案：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_jjfa" runat="server" class="input-text" placeholder="解决方案"
                            Width="446px" MaxLength="50" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_jjfa" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备注：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bz" Width="446px" MaxLength="6" runat="server" class="input-text" placeholder="备注" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>

                </tr>
            </table>
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="btn_bj" runat="server"
                                Text="编辑" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_bj_Click"></asp:Button>

                            <asp:Button ID="btn_save" runat="server"
                                Text="保存" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_save_Click" Visible="False"></asp:Button>

                            <asp:Button ID="btn_fh" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_fh_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </article>
</body>
<script src="../css/js/jquery.js" type="text/javascript"></script>
<script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
<script type="text/javascript">

    var i = 0;

    $("#btn_save").click(function () {


        //报送时间
        //$("#tbx_bssj").blur(function () {
        if ($("#tbx_bssj").val() != "") {
            $("#lbl_bssj").text("正确");
            $("#lbl_bssj").css("color", "#00ff00");
        } else {
            $("#lbl_bssj").text("报送时间不能为空");
            $("#lbl_bssj").css("color", "#ff0000");
            i = 1;
        }
        //});




        //报送模式
        //$("#tbx_qmdm").blur(function () {
        if ($("#tbx_bsms").val() != "") {
            $("#lbl_bsms").text("正确");
            $("#lbl_bsms").css("color", "#00ff00");
        } else {
            $("#lbl_bsms").text("报送模式不能为空");
            $("#lbl_bsms").css("color", "#ff0000");
            i = 1;
        }
        //});

        //解决方案
        //$("#tbx_qmdm").blur(function () {
        if ($("#tbx_jjfa").val() != "") {
            $("#lbl_jjfa").text("正确");
            $("#lbl_jjfa").css("color", "#00ff00");
        } else {
            $("#lbl_jjfa").text("解决方案不能为空");
            $("#lbl_jjfa").css("color", "#ff0000");
            i = 1;
        }

        //备注
        //$("#tbx_bz").blur(function () {
        $("#lbl_bz").text("正确");
        $("#lbl_bz").css("color", "#00ff00");
        //});
        if (i == 0) {
            return true;
        }
        else {
            i = 0;
            return false;
        }
        //});

    });
</script>
</asp:Content>
