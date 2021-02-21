<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YH_Edit.aspx.cs" Inherits="CUST.WKG.YH_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

 <head id="Head1" runat="server">
    <title></title>
   
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
       
         <div class="panel-head">
            <strong class="icon-reorder">用户编辑</strong>
        </div>
       <table >
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    用 户 编 号：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">   <asp:Label ID="lbl_bh" runat="server" ></asp:Label></td>
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    密 码：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_mm" runat="server" class="input-text" placeholder="密码" 
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
                 Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd HH:mm:ss'})" ></asp:TextBox>
                    <asp:Label ID="lbl_kssj" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    结 束 时 间：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_jssj" runat="server" class="input-text" placeholder="结束时间" 
                 Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd HH:mm:ss'})" ></asp:TextBox>
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
        
         <tr style="vertical-align: top;  width:100%;border:1px solid #C0D9D9;" class="td_sjsc">
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
          <%--   <asp:Button ID="btn_bj" runat="server" 
                Text="编辑" class="btn  radius" ForeColor="White" BackColor="#60B1D7"     Width="120px" OnCommand="btn_bj_Command"  ></asp:Button> --%> 
		    <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="120px"  onclick="btn_save_Click" ></asp:Button>  
              &nbsp;  
              <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="120px"  onclick="btn_fh_Click"></asp:Button>  
		</div>
	</div>
	</form>
</article>
    <!--_footer 作为公共模版分离出去-->

      <script type="text/javascript" src="../../Content/css/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../../Content/css/h-ui.admin/js/H-ui.admin.js"></script>

    <!--/_footer /作为公共模版分离出去-->
    <!--请在下方写此页面业务相关的脚本-->
      <script  src="../../Content/js/jquery.js" type="text/javascript"></script>
        <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
      <script type="text/javascript">
        $(document).ready(function () {
          //标题
            $("#tbx_bt").blur(function() {
                if ($("#lbl_bt").val() != "") {
                    $("#lbl_bt").text("正确");
                    $("#lbl_bt").css("color", "#00ff00");
                } else {
                $("#lbl_bt").text("错误");
                $("#lbl_bt").css("color", "#ff0000");
                }
            });
          //密码
           $("#tbx_mm").blur(function() {
                if ($("#lbl_mm").val() != "") {
                    $("#lbl_mm").text("正确");
                    $("#lbl_mm").css("color", "#00ff00");
                } else {
                $("#lbl_mm").text("错误");
                $("#lbl_mm").css("color", "#ff0000");
                }
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
        //内容
            $("#tbx_nr").blur(function () {
                $("#lbl_nr").text("正确");
                $("#lbl_nr").css("color", "#00ff00");
            });
            //接收部门
            $("#lbx_jsr1").blur(function() {
                if ($("#lbl_jsbm").val() != "") {
                    $("#lbl_jsbm").text("正确");
                    $("#lbl_jsbm").css("color", "#00ff00");
                } else {
                $("#lbl_jsbm").text("错误");
                $("#lbl_jsbm").css("color", "#ff0000");
                }
            });
            //公告类型
            $("#ddlt_gglx").change(function () {
                if ($("#ddlt_gglx option:selected").val() != "-1") {
                    $("#lbl_gglx").text("正确");
                    $("#lbl_gglx").css("color", "#00ff00");
                } else {
                    $("#lbl_gglx").text("请选择");
                    $("#lbl_gglx").css("color", "#ff0000");
                }
            });
        });
    </script>

</body>


</html>
