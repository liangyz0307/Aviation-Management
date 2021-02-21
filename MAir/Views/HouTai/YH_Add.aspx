<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YH_Add.aspx.cs" Inherits="CUST.WKG.YH_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>

    <script type="text/javascript" src="../lib/respond.min.js"></script>

    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
 <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css"
        id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
              
            }    
    </style>
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
</head>
<body>
      <article class="page-container">
<form id="Form1" runat="server" class="form form-horizontal">
      <%--   <nav class="breadcrumb">个人信息管理 <span class="c-gray en">&gt;</span> 个人信息<span class="c-gray en">&gt;</span>员工添加
         </nav>--%>
    <div class="panel-head">
            <strong class="icon-reorder">用户添加</strong>
        </div>
    <table >
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    用 户 编 号：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                     <asp:TextBox ID="tbx_bh" runat="server" class="input-text" placeholder="用户编号" 
                 Width="446px" MaxLength="10"></asp:TextBox>
                    <asp:Label ID="lbl_bh" runat="server" ></asp:Label>
                </td>
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    密 码：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">   <asp:TextBox ID="tbx_mm" runat="server" class="input-text" placeholder="密码" 
                 Width="446px" TextMode="Password" MaxLength="32"></asp:TextBox>
                    <asp:Label ID="lbl_mm" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    类 别：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">   <asp:DropDownList ID="ddlt_lb" runat="server"></asp:DropDownList>
                    <asp:Label ID="lbl_lb" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    名 称：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">   <asp:TextBox ID="tbx_mc" runat="server" class="input-text" placeholder="名称" 
                 Width="446px" MaxLength="100"></asp:TextBox>
                    <asp:Label ID="lbl_mc" runat="server" ></asp:Label>
                </td>
            </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    开 始 时 间：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_kssj" runat="server" class="input-text" placeholder="开始时间" 
                 Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd HH:mm:ss'})" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="lbl_kssj" runat="server" ></asp:Label>
                </td>
            
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    结 束 时 间：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_jssj" runat="server" class="input-text" placeholder="结束时间" 
                 Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd HH:mm:ss'})" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="lbl_jssj" runat="server" ></asp:Label>
                </td>
                
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    是 否 是 权 限 用 户：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                  <asp:DropDownList ID="ddlt_sfsqxyh" runat="server"></asp:DropDownList>
                    <asp:Label ID="lbl_sfsqxyh" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    是 否 启 用：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:DropDownList ID="ddlt_sfqy" runat="server"></asp:DropDownList>
                    <asp:Label ID="lbl_sfqy" runat="server" ></asp:Label>
                </td>
                
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    序 列 号：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_xlh" runat="server" class="input-text" placeholder="序列号" 
                 Width="446px" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="lbl_xlh" runat="server" ></asp:Label>
                </td>
                
            </tr>
        
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    所 属：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:DropDownList ID="ddlt_ss" runat="server"></asp:DropDownList>
                    <asp:Label ID="lbl_ss" runat="server" ></asp:Label>
                </td>
                
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    是 否 是 管 理 用 户：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:DropDownList ID="ddlt_sfsglyh" runat="server"></asp:DropDownList>
                    <asp:Label ID="lbl_sfsglyh" runat="server" ></asp:Label>
                </td>
                
            </tr>
        </table>
	 

	<div class="row cl">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
		    <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_save_Click"  ></asp:Button> 
            &nbsp; 
            <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_fh_Click"   ></asp:Button> 
		</div>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	</div>
	</form>
</article>

     <script  src="../../Content/js/jquery.js" type="text/javascript"></script>
        <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //用户编号
        $("#tbx_bh").blur(function() {
        if ($("#tbx_bh").val() != "") {
                $("#lbl_bh").text("正确");
                $("#lbl_bh").css("color", "#00ff00");
        } else {
            $("#lbl_bh").text("错误");
            $("#lbl_bh").css("color", "#ff0000");
        }
        });
            //密码
            $("#tbx_mm").blur(function() {
                if ($("#tbx_mm").val() != "") {
                    $("#lbl_mm").text("正确");
                    $("#lbl_mm").css("color", "#00ff00");
                } else {
                $("#lbl_mm").text("错误");
                $("#lbl_mm").css("color", "#ff0000");
                }
            });
            //类别
            $("#ddlt_lb").change(function() {
            if ($("#ddlt_lb option:selected").val() != "-1") {
                $("#lbl_lb").text("正确");
                $("#lbl_lb").css("color", "#00ff00");
                } else {
                $("#lbl_lb").text("请选择");
                $("#lbl_lb").css("color", "#ff0000");
                }
            });
            //名称
            $("#tbx_mc").blur(function() {
            $("#lbl_mc").text("正确");
            $("#lbl_mc").css("color", "#00ff00");
            });
            //开始时间
            $("#tbx_kssj").blur(function () {
                $("#lbl_kssj").text("正确");
                $("#lbl_kssj").css("color", "#00ff00");
            });
            //结束时间
            $("#tbx_jssj").blur(function () {
                $("#lbl_jssj").text("正确");
                $("#lbl_jssj").css("color", "#00ff00");
            });
            //是否是权限用户
            $("#ddlt_sfsqxyh").change(function () {

                if ($("#ddlt_sfsqxyh option:selected").val() != "-1") {
                    $("#lbl_sfsqxyh").text("正确");
                    $("#lbl_sfsqxyh").css("color", "#00ff00");
                } else {
                    $("#lbl_sfsqxyh").text("请选择");
                    $("#lbl_sfsqxyh").css("color", "#ff0000");
                }

            });
            //是否启用
            $("#ddlt_sfqy").change(function () {

                if ($("#ddlt_sfqy option:selected").val() != "-1") {
                    $("#lbl_sfqy").text("正确");
                    $("#lbl_sfqy").css("color", "#00ff00");
                } else {
                    $("#lbl_sfqy").text("请选择");
                    $("#lbl_sfqy").css("color", "#ff0000");
                }

            });
            //序列号
            $("#tbx_xlh").blur(function () {
                $("#lbl_xlh").text("正确");
                $("#lbl_xlh").css("color", "#00ff00");
            });
            
           
            //所属
            $("#ddlt_ss").change(function () {

                if ($("#ddlt_ss option:selected").val() != "-1") {
                    $("#lbl_ss").text("正确");
                    $("#lbl_ss").css("color", "#00ff00");
                } else {
                    $("#lbl_ss").text("请选择");
                    $("#lbl_ss").css("color", "#ff0000");
                }
               
            });
            //是否是管理员用户
            $("#ddlt_sfsglyh").change(function () {

                if ($("#ddlt_sfsglyh option:selected").val() != "-1") {
                    $("#lbl_sfsglyh").text("正确");
                    $("#lbl_sfsglyh").css("color", "#00ff00");
                } else {
                    $("#lbl_sfsglyh").text("请选择");
                    $("#lbl_sfsglyh").css("color", "#ff0000");
                }

            });
        });
    </script>
</body>
</html>
