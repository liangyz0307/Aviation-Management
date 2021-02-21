<%@ Page Language="C#" MasterPageFile="Sys.Master"  AutoEventWireup="true" CodeBehind="PersonPwdXG.aspx.cs" Inherits="CUST.Web.MengHu.main.PersonPwdXG" %>
<asp:Content ID="KG_head" ContentPlaceHolderID="head" runat="server">
    <link href="../css/manage.css" rel="stylesheet" type="text/css" />
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
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
    </style>
</asp:Content>
  <asp:Content ID="KG_content" ContentPlaceHolderID="kg_content" runat="server" >
     
	<form runat="server">
        <br />
        <br />
        <br />
    <!--/_footer /作为公共模版分离出去-->
    <!--请在下方写此页面业务相关的脚本 col-xs-4 col-sm-3:bootstrap -->

	<div class="row cl">
		<label class="form-label col-xs-4 col-sm-3" style="text-align:right;padding:0px" >员工编号：</label>
		<div class="formControls col-xs-8 col-sm-9" style="padding:0px">
		    <asp:Label ID="lbl_ygbh" runat="server" ></asp:Label>
		</div>
	</div>
        <br />
	<div class="row cl">
		<label class="form-label col-xs-4 col-sm-3" style="text-align:right;padding:0px"><span class="c-red">*</span>初始密码：</label>
		<div class="formControls col-xs-8 col-sm-9" style="padding:0px">
		    <asp:TextBox ID="tbx_csmm" runat="server" class="input-text" placeholder="初始密码" 
                TextMode="Password" Width="446px"></asp:TextBox>
		</div>
	</div>
	<div class="row cl">
		<label class="form-label col-xs-4 col-sm-3" style="text-align:right;padding:0px"><span class="c-red">*</span>新&nbsp;&nbsp;密&nbsp;码：</label>
		<div class="formControls col-xs-8 col-sm-9" style="padding:0px">
		    <asp:TextBox ID="tbx_nmm" runat="server" class="input-text" placeholder="新密码" 
                TextMode="Password" Width="446px"></asp:TextBox>
		</div>
	</div>
	<div class="row cl">
		<label class="form-label col-xs-4 col-sm-3" style="text-align:right;padding:0px"><span class="c-red">*</span>确认密码：</label>
		<div class="formControls col-xs-8 col-sm-9" style="padding:0px">
		    <asp:TextBox ID="tbx_qnmm" runat="server" class="input-text" placeholder="确认密码" 
                TextMode="Password" Width="446px"></asp:TextBox>
		</div>
	</div>
	
	<div class="row cl">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
		    <asp:Button ID="btn_save" runat="server" 
                Text="&nbsp;&nbsp;提&nbsp;&nbsp;交&nbsp;&nbsp;" class="btn btn-primary radius" 
                onclick="btn_save_Click" Width="199px"></asp:Button>
		</div>
	</div>
        
    <script type="text/javascript">
        $(function () {
	$('.skin-minimal input').iCheck({
		checkboxClass: 'icheckbox-blue',
		radioClass: 'iradio-blue',
		increaseArea: '20%'
	});
	
	$("#form-admin-add").validate({
		rules:{
			adminName:{
				required:true,
				minlength:4,
				maxlength:16
			},
			password:{
				required:true,
			},
			password2:{
				required:true,
				equalTo: "#password"
			},
			sex:{
				required:true,
			},
			phone:{
				required:true,
				isPhone:true,
			},
			email:{
				required:true,
				email:true,
			},
			adminRole:{
				required:true,
			},
		},
		onkeyup:false,
		focusCleanup:true,
		success:"valid",
		submitHandler:function(form){
			$(form).ajaxSubmit();
			var index = parent.layer.getFrameIndex(window.name);
			parent.$('.btn-refresh').click();
			parent.layer.close(index);
		}
	});
});
</script>
	</form>
    <!--_footer 作为公共模版分离出去-->

    

</asp:Content>
