<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GW_Edit.aspx.cs" Inherits="CUST.WKG.GW_Edit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">
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
         <div class="panel-head">
            <strong class="icon-reorder">岗位编辑</strong>
        </div>
        <table >
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:40%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    部 门：</td>
                <td style="width:60%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                    <asp:Label ID="lbl_bm" Width="150px" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:40%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    岗 位 代 码：</td>
                <td colspan="2" style="width:60%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_gwdm" runat="server" Width="150px" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:40%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    岗 位 名 称：<span class="c-red">*</span>
                </td>
                <td colspan="2" style="width:60%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                     <asp:TextBox ID="tbx_gwmc" runat="server" class="input-text" placeholder="负责人" 
                    Width="150px" MaxLength="10"></asp:TextBox><asp:Label ID="lbl_gwmc" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    类 别：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:DropDownList ID="ddlt_lb" Width="150px" runat="server"></asp:DropDownList>
                   <asp:Label ID="lbl_lb" runat="server" ></asp:Label>
                </td>     
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
		<div style="text-align:center">
		    <asp:Button ID="btn_save" runat="server"  Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="120px"  onclick="btn_save_Click" ></asp:Button>  &nbsp;  
              <asp:Button ID="btn_fh" runat="server"   Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="120px"  onclick="btn_fh_Click"></asp:Button>  
		</div>
	</div>
	</form>
</article>
    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>
    <script src="../css/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //岗位名称
            $("#tbx_gwmc").blur(function() {
                if ($("#tbx_gwmc").val() != "") {
                    $("#lbl_gwmc").text("正确");
                    $("#lbl_gwmc").css("color", "#00ff00");
                } else
                {
                    $("#lbl_gwmc").text("错误");
                    $("#lbl_gwmc").css("color", "#ff0000");
                }
            });
            //类别
            $("#ddlt_lb").change(function () {

                if ($("#ddlt_lb option:selected").val() != "-1") {
                    $("#lbl_lb").text("正确");
                    $("#lbl_lb").css("color", "#00ff00");
                } else {
                    $("#lbl_lb").text("请选择");
                    $("#lbl_lb").css("color", "#ff0000");
                }
            });
        });
    </script>
 
</body>
</html>
