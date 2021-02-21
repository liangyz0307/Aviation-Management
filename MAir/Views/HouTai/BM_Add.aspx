<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BM_Add.aspx.cs" Inherits="CUST.WKG.BM_Add" %>

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
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
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
            <strong class="icon-reorder">部门添加</strong>
        </div>
    <table >
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    部 门 代 码：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                     <asp:TextBox ID="tbx_bmdm" runat="server" class="input-text" placeholder="部门代码" 
                 Width="400px" MaxLength="3"></asp:TextBox>
                   
                    <asp:Label ID="lbl_bmdm" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    部 门 名 称：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_bmmc" runat="server" class="input-text" placeholder="部门名称" 
                 Width="400px" MaxLength="50"></asp:TextBox><asp:Label ID="lbl_bmmc" runat="server" ></asp:Label></td>
            </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    上 级 部 门：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:DropDownList ID="ddlt_sjbm" runat="server"></asp:DropDownList>
                     <asp:Label ID="lbl_sjbm" runat="server" ></asp:Label></td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    部 门 类 别：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:DropDownList ID="ddlt_bmlb" runat="server"></asp:DropDownList>
                     <asp:Label ID="lbl_bmlb" runat="server" ></asp:Label></td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    负 责 人 编 号：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                     <asp:TextBox ID="tbx_fzr" runat="server" class="input-text" placeholder="负责人" 
                 Width="400px" MaxLength="10"></asp:TextBox><asp:Label ID="lbl_fzr" runat="server" ></asp:Label></td>
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    联 系 电 话：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                     <asp:TextBox ID="tbx_lxdh" runat="server" class="input-text" placeholder="联系电话" 
                 Width="400px" MaxLength="12"></asp:TextBox><asp:Label ID="lbl_lxdh" runat="server" ></asp:Label></td>
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    状 态：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:DropDownList ID="ddlt_zt" runat="server"></asp:DropDownList>
                     <asp:Label ID="lbl_zt" runat="server" ></asp:Label></td>
                
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
            //部门代码
        $("#tbx_bmdm").blur(function() {
            if ($("#tbx_bmdm").val() != "") {
               
                if (!$("#tbx_bmdm").val().match(/^[0-9]*$/)) {
                $("#lbl_bmdm").text("错误：代码必须为数字！");
                $("#lbl_bmdm").css("color", "#ff0000");
            } else {
                $("#lbl_bmdm").text("正确");
                $("#lbl_bmdm").css("color", "#00ff00");
            }
        } else {
            $("#lbl_bmdm").text("错误");
            $("#lbl_bmdm").css("color", "#ff0000");
        }
        });
            //名称
            $("#tbx_bmmc").blur(function() {
                if ($("#tbx_bmmc").val() != "") {
                    $("#lbl_bmmc").text("正确");
                    $("#lbl_bmmc").css("color", "#00ff00");
                } else
                {
                    $("#lbl_bmmc").text("错误");
                    $("#lbl_bmmc").css("color", "#ff0000");
                }
                  
               
            });
            //负责人
            $("#tbx_fzr").blur(function () {
                if ($("#tbx_fzr").val() != "") {
                    if (!$("#tbx_fzr").val().match(/^\d+$/)) {
                        $("#lbl_fzr").text("错误：负责人编号必须为数字！");
                        $("#lbl_fzr").css("color", "#ff0000");
                    } else {
                        $("#lbl_bmdm").text("正确");
                        $("#lbl_bmdm").css("color", "#00ff00");
                    }
                } else {
                    $("#lbl_fzr").text("错误");
                    $("#lbl_fzr").css("color", "#ff0000");
                }
              
            });
            //联系电话
            $("#tbx_lxdh").blur(function () {

                if ($("#tbx_lxdh").val() == "") {
                    $("#lbl_lxdh").text("错误");
                    $("#lbl_lxdh").css("color", "#ff0000");
                }
                else {
                    if (!$("#tbx_lxdh").val().match(/^[1][3578]\d{9}$/)) {
                        $("#lbl_lxdh").text("错误：格式错误！");
                        $("#lbl_lxdh").css("color", "#ff0000");
                    }
                    else {
                        $("#lbl_lxdh").text("正确");
                        $("#lbl_lxdh").css("color", "#00ff00");
                    }
                }
               
            });
            //上级部门
            $("#ddlt_sjbm").change(function() {

            if ($("#ddlt_sjbm option:selected").val() != "-1") {
                $("#lbl_sjbm").text("正确");
                $("#lbl_sjbm").css("color", "#00ff00");
                } else {
                $("#lbl_sjbm").text("请选择");
                $("#lbl_sjbm").css("color", "#ff0000");
                }
            });
            //部门类别
            $("#ddlt_bmlb").change(function () {

                if ($("#ddlt_bmlb option:selected").val() != "-1") {
                    $("#lbl_bmlb").text("正确");
                    $("#lbl_bmlb").css("color", "#00ff00");
                } else {
                    $("#lbl_bmlb").text("请选择");
                    $("#lbl_bmlb").css("color", "#ff0000");
                }
            });
            //状态
            $("#ddlt_zt").change(function () {

                if ($("#ddlt_zt option:selected").val() != "-1") {
                    $("#lbl_zt").text("正确");
                    $("#lbl_zt").css("color", "#00ff00");
                } else {
                    $("#lbl_zt").text("请选择");
                    $("#lbl_zt").css("color", "#ff0000");
                }
            });
           
            
        });
    </script>
</body>
</html>
