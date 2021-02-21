<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HT_Edit.aspx.cs" Inherits="CUST.WKG.HT_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>合同编辑</title>
   
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>
     <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
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
            <strong class="icon-reorder">合同编辑</strong>
        </div>
    <table >
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    合同名称：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                     <asp:TextBox ID="tbx_htmc" runat="server" class="input-text" 
                     Width="220px" ></asp:TextBox>
                    <asp:Label ID="lbl_htmc" runat="server" ></asp:Label>
                </td>
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    签订方：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                  <asp:TextBox ID="tbx_qdf" runat="server" class="input-text" Width="220px" ></asp:TextBox>
                    <asp:Label ID="lbl_qdf" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    总额：<span class="c-white">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                     <asp:TextBox ID="tbx_ze" runat="server" class="input-text"
                 Width="180px" ></asp:TextBox> <asp:Label ID="lbl_wy" runat="server" Text="万元" Width="40px" Font-Bold="True" Font-Size="10pt"></asp:Label>
                    <asp:Label ID="lbl_ze" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    签订日期：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_qdrq" runat="server" class="input-text" 
                 Width="220px" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                    <asp:Label ID="lbl_qdrq" runat="server" ></asp:Label>
                </td>
            </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    期限：<span class="c-white">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_qxkssj" runat="server" class="input-text" 
                 Width="100px" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                     --<asp:TextBox ID="tbx_qxjssj" runat="server" class="input-text"
                 Width="100px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox>
                    <asp:Label ID="lbl_qxsj" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    状态：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <asp:DropDownList ID="ddlt_zt" runat="server" Height="30px"  Width="220px"></asp:DropDownList>
                     <asp:Label ID="lbl_zt" runat="server" ></asp:Label>
                </td>
                
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    状态备注：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   <asp:TextBox ID="tbx_ztbz" runat="server" class="input-text" 
                 Width="220px" ></asp:TextBox>
                    <asp:Label ID="lbl_ztbz" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   负责人：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                          <asp:TextBox ID="tbx_fzr" runat="server" class="input-text" 
                 Width="220px" ></asp:TextBox>
                  
                    <asp:Label ID="lbl_fzr" runat="server" ></asp:Label>
                </td>
                
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   备注：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_bz" runat="server" class="input-text"   nValidate="{required:true}"
                 Width="220px" ></asp:TextBox>
                    <asp:Label ID="lbl_bz" runat="server" ></asp:Label>
                </td>
                
         </tr>
        </table>
	    <div>
			<div >
                <div style="text-align:center;">
			    <asp:Button ID="btn_save" runat="server" Text="保存" 
                    class="btn  radius"  BackColor="#60B1D7"  ForeColor="White" Width="191px" OnClick="btn_save_Click" ></asp:Button>
                &nbsp;
                <asp:Button ID="btn_fh" runat="server" Text="返回" 
                    class="btn  radius" Width="191px"  BackColor="#60B1D7"  ForeColor="White" OnClick="btn_fh_Click"></asp:Button>
			</div>
          </div>
		</div>
       <script type="text/javascript">      
           //$(function ()
           //{
           //    $("#Form1").validate();
           //     });
        
        //按钮判断
        $("#btn_save").click(function ()
        {
            var flag = true;
                if ($("#tbx_htmc").val().trim() == "") 
                {
                    $("#lbl_htmc").text("错误：合同名称不能为空");
                    $("#lbl_htmc").css("color", "#ff0000");
                    $("#tbx_htmc").focus();
                    flag = false;
                }
                if ($("#tbx_qdf").val().trim() == "")
                {
                    $("#lbl_qdf").text("错误：签订方不能为空");
                    $("#lbl_qdf").css("color", "#ff0000");
                    $("#tbx_qdf").focus();
                    flag = false;
                }
                //if ($("#tbx_ze").val().trim() == "")
                //{
                //    $("#lbl_ze").text("错误：总额不能为空");
                //    $("#lbl_ze").css("color", "#ff0000");
                //    $("#tbx_ze").focus();
                //    flag = false;
                //}
                if ($("#tbx_qdrq").val().trim() == "")
                {
                    alert(1);
                    $("#lbl_qdrq").text("错误：签订日期不能为空");
                    $("#lbl_qdrq").css("color", "#ff0000");
                    $("#tbx_qdrq").focus();
                    flag = false;
                }
                //if ($("#tbx_qxkssj").val().trim() == "")
                //{
                //    $("#lbl_qxsj").text("错误：期限开始时间不能为空");
                //    $("#lbl_qxsj").css("color", "#ff0000");
                //    $("#tbx_qxkssj").focus();
                //    flag = false;
                //}
                //if ($("#tbx_qxjssj").val().trim() == "")
                //{
                //    $("#lbl_qxsj").text("错误：期限结束时间不能为空");
                //    $("#lbl_qxsj").css("color", "#ff0000");
                //    $("#tbx_qxjssj").focus();
                //    flag = false;
                //}
                //if ($("#tbx_qxkssj").val().trim() < $("#tbx_qdrq").val().trim()) {
                //    $("#lbl_qdrq").text("错误：签订日期不能大于期限开始时间");
                //    $("#lbl_qdrq").css("color", "#ff0000");
                //    $("#tbx_qdrq").focus();
                //    flag = false;
                //}
                //if ($("#tbx_qxjssj").val().trim() < $("#tbx_qxkssj").val().trim()) {
                //    $("#lbl_qxsj").text("错误：期限开始时间大于期限结束时间");
                //    $("#lbl_qxsj").css("color", "#ff0000");
                //    $("#tbx_qxjssj").focus();
                //    flag = false;
                //}
                if ($("#tbx_fzr").val().trim() == "") {
                    $("#lbl_fzr").text("错误：负责人不能为空");
                    $("#lbl_fzr").css("color", "#ff0000");
                    $("#tbx_fzr").focus();
                    flag = false;
                }
                if ($("#ddlt_zt option:selected").val().trim() == "-1")
                {
                    $("#lbl_zt").text("错误：请选择状态");
                    $("#lbl_zt").css("color", "#ff0000");
                    $("#ddlt_zt").focus();
                    flag = false;
                }
                return flag;
            });
        $(document).ready(function () {
            $("#ddlt_zt").change(function () {
                if ($("#ddlt_zt option:selected").val() != "-1") {
                    $("#lbl_zt").text("正确");
                    $("#lbl_zt").css("color", "#00ff00");
                } else {
                    $("#lbl_zt").text("请选择");
                    $("#lbl_zt").css("color", "#ff0000");
                }
            });
            $("#tbx_htmc").blur(function () {
                if ($("#tbx_htmc").val().trim() != "") {
                    if ($("#tbx_htmc").val().trim().length <= 100) {
                        $("#lbl_htmc").text("正确");
                        $("#lbl_htmc").css("color", "#00ff00");
                    } else {
                        $("#lbl_htmc").text("错误：合同名称太长");
                        $("#lbl_htmc").css("color", "#ff0000");
                    }
                }
                else {
                    $("#lbl_htmc").text("错误：合同名称不能空");
                    $("#lbl_htmc").css("color", "#ff0000");
                }
            });
            $("#tbx_qdf").blur(function () {
                if ($("#tbx_qdf").val().trim() != "") {
                    $("#lbl_qdf").text("正确");
                    $("#lbl_qdf").css("color", "#00ff00");
                }
                else {
                    $("#lbl_qdf").text("错误：签订方不能空");
                    $("#lbl_qdf").css("color", "#ff0000");
                }
            });
            $("#tbx_ze").blur(function () {
                if ($("#tbx_ze").val().trim() != "") {
                    $("#lbl_ze").text("正确");
                    $("#lbl_ze").css("color", "#00ff00");
                }
                else {
                    $("#lbl_ze").text("错误：总额不能空");
                    $("#lbl_ze").css("color", "#ff0000");
                }
            });
            $("#tbx_qdrq").click(function () {
                $("#lbl_qdrq").text("");
            });
            $("#tbx_qxkssj").click(function () {
                $("#lbl_qxsj").text("");
            });
            $("#tbx_qxjssj").click(function () {
                $("#lbl_qxsj").text("");
            });
            //$("#tbx_qdrq").blur(function () {
            //    if ($("#tbx_qdrq").val().trim() != "") {

            //        $("#lbl_qdrq").text("正确");
            //        $("#lbl_qdrq").css("color", "#00ff00");
            //    }
            //    else {
            //        $("#lbl_qdrq").text("错误：签订日期不能空");
            //        $("#lbl_qdrq").css("color", "#ff0000");
            //    }
            //});
            //$("#tbx_qxkssj").blur(function () {
            //    if ($("#tbx_qxkssj").val().trim() != "") {
            //        $("#lbl_qxsj").text("正确");
            //        $("#lbl_qxsj").css("color", "#00ff00");
            //    }
            //    else {
            //        $("#lbl_qxsj").text("错误：期限开始时间不能空");
            //        $("#lbl_qxsj").css("color", "#ff0000");
            //    }
            //});
            //$("#tbx_qxjssj").blur(function () {
            //    if ($("#tbx_qxjssj").val().trim() != "") {
            //        $("#lbl_qxsj").text("正确");
            //        $("#lbl_qxsj").css("color", "#00ff00");
            //    }
            //    else {
            //        $("#lbl_qxsj").text("错误：期限结束时间不能空");
            //        $("#lbl_qxsj").css("color", "#ff0000");
            //    }
            //});
            $("#tbx_fzr").blur(function () {
                if ($("#tbx_fzr").val().trim() != "") {
                    $("#lbl_fzr").text("正确");
                    $("#lbl_fzr").css("color", "#00ff00");
                }
                else {
                    $("#lbl_fzr").text("错误：负责人不能空");
                    $("#lbl_fzr").css("color", "#ff0000");
                }
            });
        });
   </script>
   
	</form>
</article>
</body>
</html>
