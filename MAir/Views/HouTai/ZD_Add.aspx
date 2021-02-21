<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZD_Add.aspx.cs" Inherits="CUST.WKG.ZD_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>

    <script type="text/javascript" src="../lib/respond.min.js"></script>

    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
   <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
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
            <strong class="icon-reorder">字典添加</strong>
        </div>
    <table >
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    字 典 码：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">   <asp:DropDownList ID="ddlt_zdm" runat="server"></asp:DropDownList>
                    <asp:Label ID="lbl_zdm" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    编 码：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">   <asp:TextBox ID="tbx_bm" runat="server" class="input-text" placeholder="编码" 
                 Width="400px" MaxLength="9"></asp:TextBox><asp:Label ID="lbl_bm" runat="server" ></asp:Label></td>
            </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    名 称：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_mc" runat="server" class="input-text" placeholder="名称" 
                 Width="400px" MaxLength="100"></asp:TextBox><asp:Label ID="lbl_mc" runat="server" ></asp:Label></td>
                
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
	</div>
	</form>
</article>

     <script  src="../css/js/jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            //编码
        $("#tbx_bm").blur(function() {
        if ($("#tbx_bm").val() != "") {
            if (!$("#tbx_bm").val().match(/^\d+$/)) {
                $("#lbl_bm").text("错误：代码必须为数字！");
                $("#lbl_bm").css("color", "#ff0000");
            } else {
                $("#lbl_bm").text("正确");
                $("#lbl_bm").css("color", "#00ff00");
            }
        } else {
            $("#lbl_bm").text("错误");
            $("#lbl_bm").css("color", "#ff0000");
        }
        });
            //名称
            $("#tbx_mc").blur(function() {
                if ($("#tbx_mc").val() != "") {
                    $("#lbl_mc").text("正确");
                    $("#lbl_mc").css("color", "#00ff00");
                } else {
                $("#lbl_mc").text("错误");
                $("#lbl_mc").css("color", "#ff0000");
                }
            });
            //字典码
            $("#ddlt_zdm").change(function() {

            if ($("#ddlt_zdm option:selected").val() != "-1") {
                $("#lbl_zdm").text("正确");
                $("#lbl_zdm").css("color", "#00ff00");
                } else {
                $("#lbl_zdm").text("请选择");
                $("#lbl_zdm").css("color", "#ff0000");
                }
            });
            $("#btn_save").click(function () {

                if ($("#ddlt_zdm option:selected").val() == "-1") {
                    $("#lbl_zdm").text("请选择");
                    $("#lbl_zdm").css("color", "#ff0000");
                    return false;
                }

                if ($("#tbx_bm").val().trim() == "") {
                    $("#lbl_bm").text("错误：编码不能为空！");
                    $("#lbl_bm").css("color", "#ff0000");
                    return false;
                }
                if ($("#tbx_mc").val().trim() == "") {
                    $("#lbl_mc").text("错误：名称不能为空！");
                    $("#lbl_mc").css("color", "#ff0000");
                    return false;
                }
               
            });
            
        });
    </script>
</body>
</html>
