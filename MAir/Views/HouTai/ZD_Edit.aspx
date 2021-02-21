<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZD_Edit.aspx.cs" Inherits="CUST.WKG.ZD_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

 <head id="Head1" runat="server">
    <title></title>
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
</head>
<body>
    <article class="page-container">
	<form id="Form1" runat="server" class="form form-horizontal">
       
         <div class="panel-head">
            <strong class="icon-reorder">字典编辑</strong>
        </div>
        <table >
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    字 典 码：</td>
                <td style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> <asp:Label ID="lbl_zdm" runat="server" ></asp:Label></td>

            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    编 码：</td>
                <td style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> <asp:Label ID="lbl_bm" runat="server" ></asp:Label></td>
 
            </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    名 称：<span class="c-red">*</span></td>
                <td style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_mc" runat="server" class="input-text" placeholder="名称" 
                 Width="446px" MaxLength="100"></asp:TextBox><asp:Label ID="lbl_mc" runat="server" ></asp:Label></td>

                
            </tr>
        </table>
            
      
   


	<div class="row cl">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
            	<asp:Button ID="btn_bj" runat="server" 
                Text="编辑" class="btn  radius" ForeColor="White" BackColor="#60B1D7"  Width="120px" OnCommand="btn_bj_Command"  ></asp:Button>  
              
		    <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="120px"  onclick="btn_save_Click" Visible="False"></asp:Button>  
              &nbsp;  
              <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="120px"  onclick="btn_fh_Click"></asp:Button>  
		</div>
	</div>
	</form>
</article>
    <!--_footer 作为公共模版分离出去-->

    <script type="text/javascript" src="../lib/jquery/1.9.1/jquery.min.js"></script>

    <script type="text/javascript" src="../lib/layer/2.1/layer.js"></script>

    <script type="text/javascript" src="../lib/icheck/jquery.icheck.min.js"></script>

    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/jquery.validate.min.js"></script>

    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/validate-methods.js"></script>

    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/messages_zh.min.js"></script>

    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>

    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>

    <!--/_footer /作为公共模版分离出去-->
    <!--请在下方写此页面业务相关的脚本-->
     <script src="../css/js/jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $("#tbx_mc").blur(function() {
                if ($("#tbx_mc").val() != "") {
                    $("#lbl_mc").text("正确");
                    $("#lbl_mc").css("color", "#00ff00");
                } else {
                $("#lbl_mc").text("错误");
                $("#lbl_mc").css("color", "#ff0000");
                }
            });
            $("#btn_save").click(function () {

                if ($("#tbx_mc").val() == "") {
                    $("#lbl_mc").text("错误：名称不能为空！");
                    $("#lbl_mc").css("color", "#ff0000");
                    return false;
                }
            });
           
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('.skin-minimal input').iCheck({
                checkboxClass: 'icheckbox-blue',
                radioClass: 'iradio-blue',
                increaseArea: '20%'
            });

            $("#form-admin-add").validate({
                rules: {
                    adminName: {
                        required: true,
                        minlength: 4,
                        maxlength: 16
                    },
                    password: {
                        required: true,
                    },
                    password2: {
                        required: true,
                        equalTo: "#password"
                    },
                    sex: {
                        required: true,
                    },
                    phone: {
                        required: true,
                        isPhone: true,
                    },
                    email: {
                        required: true,
                        email: true,
                    },
                    adminRole: {
                        required: true,
                    },
                },
                onkeyup: false,
                focusCleanup: true,
                success: "valid",
                submitHandler: function (form) {
                    $(form).ajaxSubmit();
                    var index = parent.layer.getFrameIndex(window.name);
                    parent.$('.btn-refresh').click();
                    parent.layer.close(index);
                }
            });
        });
</script>

</body>


</html>
