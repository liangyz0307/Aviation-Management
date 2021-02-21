<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AL_Add.aspx.cs" Inherits="CUST.WKG.AL_Add" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

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
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
   <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
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
      <%--   <nav class="breadcrumb">个人信息管理 <span class="c-gray en">&gt;</span> 个人信息<span class="c-gray en">&gt;</span>员工添加
         </nav>--%>
	<div class="panel-head">
            <strong class="icon-reorder">案例添加</strong>
        </div>
    <table >
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    案 例 名 称：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_alm" runat="server" class="input-text" placeholder="案例名称" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_alm" runat="server" ></asp:Label>
                    </td>
            </tr>

          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    案 例 来 源：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_ally" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_ally" runat="server" ></asp:Label>
                    </td>
            </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    案 例 类 型：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_allx1" runat="server" style="width:200px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_allx1_SelectedIndexChanged"></asp:DropDownList>
                      <asp:DropDownList ID="ddlt_allx2" runat="server"  style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_allx1" runat="server" ></asp:Label>
                    <asp:Label ID="lbl_allx2" runat="server" ></asp:Label>
                    </td>
            </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     文 档 选 择：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <Upload:InputFile ID="AttachFile" runat="server" />
                    <%--<asp:Button ID="BtnUP" runat="server" Text="上传"  />--%>
                    <Upload:ProgressBar ID="ProgressBar1" runat='server'>
    </Upload:ProgressBar>
                </td>
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   案 例 发 生 时 间：<span class="c-red">*</span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_fssj" runat="server" class="input-text" style="width:200px" placeholder="案例发生时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_fssj" runat="server" ></asp:Label></td>
            </tr>

       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   案 例 等 级：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_aldj" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_aldj" runat="server" ></asp:Label>
                    </td>
            </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   案 例 分 析：<span class="c-red">*</span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_alfx" runat="server" class="input-text" style="width:300px; height:100px;resize:none;" placeholder="案例发生原因" TextMode="MultiLine"  
                 ></asp:TextBox>
                    <asp:Label ID="lbl_alfx" runat="server" ></asp:Label></td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   案 例 描 述：<span class="c-red">*</span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_alms" runat="server" class="input-text" style="width:300px;height:100px;resize:none;" placeholder="案例描述" TextMode="MultiLine"  
                 ></asp:TextBox>
                    <asp:Label ID="lbl_alms" runat="server" ></asp:Label></td>
            </tr>


        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    数据所在部门：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_sjszbm" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_sjszbm" runat="server" ></asp:Label>
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
	</div>

	</form>
</article>
    
</body>
    <script src="../css/js/jquery.js" type="text/javascript"></script>
      <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
       <script type="text/javascript">
           $(document).ready(function () {
               //案例名
               $("#tbx_alm").blur(function () {
                   if ($("#tbx_alm").val() != "") {
                       $("#lbl_alm").text("正确");
                       $("#lbl_alm").css("color", "#00ff00");
                   } else {
                       $("#lbl_alm").text("错误");
                       $("#lbl_alm").css("color", "#ff0000");
                   }
               });
               //案例分析
               $("#tbx_alfx").blur(function () {
                   if ($("#tbx_alfx").val() != "") {
                       $("#lbl_alfx").text("正确");
                       $("#lbl_alfx").css("color", "#00ff00");
                   } else {
                       $("#lbl_alfx").text("错误");
                       $("#lbl_alfx").css("color", "#ff0000");
                   }
               });
               //案例描述
               $("#tbx_alms").blur(function () {
                   if ($("#tbx_alms").val() != "") {
                       $("#lbl_alms").text("正确");
                       $("#lbl_alms").css("color", "#00ff00");
                   } else {
                       $("#lbl_alms").text("错误");
                       $("#lbl_alms").css("color", "#ff0000");
                   }
               });
               //案例来源
               $("#ddlt_ally").change(function () {
                   if ($("#ddlt_ally option:selected").val() != "-1") {
                       $("#lbl_ally").text("正确");
                       $("#lbl_ally").css("color", "#00ff00");
                   } else {
                       $("#lbl_ally").text("请选择");
                       $("#lbl_ally").css("color", "#ff0000");
                   }
               });

               //案例类型
               //$("#ddlt_allx").change(function () {
               //    if ($("#ddlt_allx option:selected").val() != "-1") {
               //        $("#lbl_allx").text("正确");
               //        $("#lbl_allx").css("color", "#00ff00");
               //    } else {
               //        $("#lbl_allx").text("请选择");
               //        $("#lbl_allx").css("color", "#ff0000");
               //    }
               //});

               //资料类型一
               $("#ddlt_allx1").change(function () {
                   if ($("#ddlt_allx1 option:selected").val() != "-1") {
                       $("#lbl_allx1").text("正确");
                       $("#lbl_allx1").css("color", "#00ff00");
                   }
                   //else if
                   // ($("#ddlt_allx1 option:selected").val() != "0") {
                   //    $("#lbl_allx1").text("正确");
                   //    $("#lbl_allx1").css("color", "#00ff00");
                   //    $("#lbl_allx2").text("正确");
                   //    $("#lbl_allx2").css("color", "#00ff00");
                   //}
                   else {
                       $("#lbl_allx1").text("请选择");
                       $("#lbl_allx1").css("color", "#ff0000");
                       $("#lbl_allx2").text("请选择");
                       $("#lbl_allx2").css("color", "#ff0000");
                   }

               });

           });
    </script> 
</html>