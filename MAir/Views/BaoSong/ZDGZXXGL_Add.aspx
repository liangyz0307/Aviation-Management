<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZDGZXXGL_Add.aspx.cs" Inherits="CUST.WKG.ZDGZXXGL_Add" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <%--   UEdit--%>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.config.js" charset="utf-8"></script>
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
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送部门：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">

                        <asp:DropDownList ID="ddlt_bszx" runat="server" Width="446px" placeholder="报送部门"></asp:DropDownList>
                        <asp:Label ID="lbl_bszx" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报 送 类 型：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">

                        <%--<asp:TextBox ID="tbx_bslx" runat="server" class="input-text" placeholder="报送类型"
                            Width="446px" MaxLength="6" Enabled="False"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlt_bslx" runat="server" Width="446px" placeholder="报送部门"></asp:DropDownList>
                        <asp:Label ID="lbl_bslx" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报 送 时 间：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bssj" runat="server" class="input-text" placeholder="报送时间"
                            Width="446px" MaxLength="50" onclick="lhgcalendar()"></asp:TextBox>
                        <asp:Label ID="lbl_bssj" runat="server"></asp:Label>
                    </td>

                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">工作标题：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_gzbt" Width="446px" MaxLength="200" runat="server" class="input-text" placeholder="工作标题"></asp:TextBox>
                        <asp:Label ID="lbl_gzbt" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">重点工作内容：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                       
                           <asp:TextBox ID="tbx_zdgznr" name="txtEditorContents" runat="server" TextMode="MultiLine" Height="300px" Width="450px" ClientIDMode="Static"> </asp:TextBox>
             
                        <asp:Label ID="lbl_zdgznr" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">执行支线：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zxzx" runat="server" Width="446px" placeholder="执行支线"></asp:DropDownList>
                        <asp:Label ID="lbl_zxzx" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">工作负责人：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_gzfzr" Width="446px" MaxLength="25" runat="server" class="input-text" placeholder="工作负责人" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_gzfzr" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">工作轮次：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_gzlc" Width="446px" MaxLength="25" runat="server" class="input-text" placeholder="工作伦次"></asp:TextBox>
                        <asp:Label ID="lbl_gzlc" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备注：<span class="c-red">&nbsp;&nbsp;</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bz" Width="446px" MaxLength="6" runat="server" Height="150px"  TextMode="MultiLine" class="input-text" placeholder="备注"></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    初审人：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_csr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_csr" runat="server" ></asp:Label>
                    </td>
            </tr>
                    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    终审人：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_zsr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_zsr" runat="server" ></asp:Label>
                    </td>
            </tr>

                 <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    数据所属部门：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_sjssbm" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_sjssbm" runat="server" ></asp:Label>
                    </td>
            </tr>


            </table>
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btn_save" runat="server"
                                Text="保存" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_save_Click"></asp:Button></td>
                        <td>&nbsp;</td>
                        <td style="text-align: left">
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
    //实例化编辑器
    var ue = UE.getEditor('tbx_zdgznr');

    var i = 0;
    $("#btn_save").click(function () {

        //报送支线

        if ($("#ddlt_bszx").val().trim() == "-1") {
            $("#lbl_bszx").text("错误：请选择！");
            $("#lbl_bszx").css("color", "#ff0000");
            $("#lbl_bszx").focus();
            i = 1;
        }
        else {
            $("#lbl_bszx").text("正确");
            $("#lbl_bszx").css("color", "#00ff00");
        }
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




        //重点工作内容
        $("#tbx_zdgznr").blur(function () {
        if ($("#tbx_zdgznr").val() != "") {
            $("#lbl_zdgznr").text("正确");
            $("#lbl_zdgznr").css("color", "#00ff00");
        } else {
            $("#lbl_zdgznr").text("重点工作内容不能为空");
            $("#lbl_zdgznr").css("color", "#ff0000");
            i = 1;
        }
        });
        //执行支线

        if ($("#ddlt_zxzx").val().trim() == "-1") {
            $("#lbl_zxzx").text("错误：请选择！");
            $("#lbl_zxzx").css("color", "#ff0000");
            $("#lbl_zxzx").focus();
            i = 1;
        }
        else {
            $("#lbl_zxzx").text("正确");
            $("#lbl_zxzx").css("color", "#00ff00");
        }

        //工作轮次
        if ($("#tbx_gzlc").val() != "") {
            var re = /^\d+(?=\.{0,1}\d+$|$)/
            if (!re.test($("#tbx_gzlc").val())) {
                $("#lbl_gzlc").text("请输入数字！");
                $("#lbl_gzlc").css("color", "#ff0000");
                i = 1;
            }
            else {
                $("#lbl_gzlc").text("正确");
                $("#lbl_gzlc").css("color", "#00ff00");
            }
        }
        else {

            $("#lbl_gzlc").text("工作轮次不能为空");
            $("#lbl_gzlc").css("color", "#ff0000");
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
</html>
