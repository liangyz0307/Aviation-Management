<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BJ_Detail.aspx.cs" Inherits="CUST.WKG.BJ_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"=></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
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
    <table>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件编号：  <asp:Label ID="Label1" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                    <asp:Label ID="lbl_bjbh" runat="server"></asp:Label>
           
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件名称：  <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
             <%--   <asp:TextBox ID="tbx_bjmc" MaxLength="14" runat="server"  Width="60%" Height="25px" placeholder="备件名称"></asp:TextBox>--%>
                <asp:Label ID="lbl_bjmc" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备型号：  <asp:Label ID="Label3" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     <%--           <asp:TextBox ID="tbx_sbxh" MaxLength="14" runat="server"  Width="60%" Height="25px" placeholder="设备型号"></asp:TextBox>--%>
                <asp:Label ID="lbl_sbxh" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件分类：  <asp:Label ID="Label4" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       <%--          <asp:DropDownList ID="ddlt_bjfl" runat="server"  Height="25px"></asp:DropDownList>--%>

                <asp:Label ID="lbl_bjfl" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               板件中文名称：  <asp:Label ID="Label5" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
             <%--   <asp:TextBox ID="tbx_bjzwmc" MaxLength="14" runat="server"  Width="60%" Height="25px" placeholder="板件中文名称"></asp:TextBox>--%>
                <asp:Label ID="lbl_bjzwmc" runat="server"></asp:Label>
            </td>
        </tr>
      <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               内含组件：  <asp:Label ID="Label6" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              <%--  <asp:TextBox ID="tbx_nhzj" MaxLength="14" runat="server"  Width="60%" Height="25px" placeholder="内含组件"></asp:TextBox>--%>
                <asp:Label ID="lbl_nhzj" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               内含组件名称：  <asp:Label ID="Label7" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
               <%-- <asp:TextBox ID="tbx_nhzjmc" MaxLength="14" runat="server"  Width="60%" Height="25px" placeholder="内含组件名称"></asp:TextBox>--%>
                <asp:Label ID="lbl_nhzjmc" runat="server"></asp:Label>
            </td>
        </tr>
       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               英文名称：  <asp:Label ID="Label8" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
             <%--   <asp:TextBox ID="tbx_ywmc" MaxLength="14" runat="server"  Width="60%" Height="25px" placeholder="英文名称"></asp:TextBox>--%>
                <asp:Label ID="lbl_ywmc" runat="server"></asp:Label>
            </td>
        </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               原机数量：  <asp:Label ID="Label9" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
               <%-- <asp:TextBox ID="tbx_yjsl" MaxLength="14" runat="server"  Width="60%" Height="25px" placeholder="原机数量"></asp:TextBox>--%>
                <asp:Label ID="lbl_yjsl" runat="server"></asp:Label>
            </td>
        </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               板件识别号：  <asp:Label ID="Label10" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
            <%--    <asp:TextBox ID="tbx_bjsbh" MaxLength="14" runat="server"  Width="60%" Height="25px" placeholder="板件识别号"></asp:TextBox>--%>
                <asp:Label ID="lbl_bjsbh" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件适用：  <asp:Label ID="Label11" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <%--   <asp:DropDownList ID="ddlt_sy" runat="server"  Height="25px"></asp:DropDownList>--%>
                <asp:Label ID="lbl_sy" runat="server"></asp:Label>
            </td>
        </tr>
    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               现有备件数量：  <asp:Label ID="Label12" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       <%--<asp:TextBox ID="tbx_xybj" MaxLength="14" runat="server"  Width="60%" Height="25px" placeholder="现有备件数量"></asp:TextBox>--%>
                <asp:Label ID="lbl_xybj" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               存放位置：  <asp:Label ID="Label13" runat="server" ></asp:Label>
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
      <%-- <asp:TextBox ID="tbx_cfwz" MaxLength="14" runat="server"  Width="60%" Height="25px" placeholder="存放位置"></asp:TextBox>--%>
                <asp:Label ID="lbl_cfwz" runat="server"></asp:Label>
            </td>
        </tr>
     <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备注：  <asp:Label ID="Label14" runat="server" ></asp:Label>&nbsp;
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     <%--  <asp:TextBox ID="tbx_bz"  TextMode="MultiLine" style="resize:none" runat="server"  Width="60%" Height="50px" placeholder="备注"></asp:TextBox>--%>
                <asp:Label ID="lbl_bz" runat="server"></asp:Label>
            </td>
        </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               状态：  <asp:Label ID="lbl_zt" runat="server" ></asp:Label>&nbsp;
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     <%--  <asp:TextBox ID="tbx_bz"  TextMode="MultiLine" style="resize:none" runat="server"  Width="60%" Height="50px" placeholder="备注"></asp:TextBox>--%>
                <asp:Label ID="Label16" runat="server"></asp:Label>
            </td>
        </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:30%; text-align: right; vertical-align: middle;" class="td_sjsc">
               驳回原因：  <asp:Label ID="lbl_bhyy" runat="server" ></asp:Label>&nbsp;
            </td>
            <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     <%--  <asp:TextBox ID="tbx_bz"  TextMode="MultiLine" style="resize:none" runat="server"  Width="60%" Height="50px" placeholder="备注"></asp:TextBox>--%>
                <asp:Label ID="Label18" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    </br>
        <table>
                                                   <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                 <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     数据所属部门：</td>
                 <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_shjsbmmc" runat="server" ></asp:Label>
                    </td>              
                <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     录入人：</td>
                 <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_lrr" runat="server" ></asp:Label>
                    </td>              
            </tr> 
                    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     初审人：</td>
                <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_csr" runat="server" ></asp:Label>
                    </td>              

               <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     终审人：</td>
                 <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_zsr" runat="server" ></asp:Label>
                    </td>              
            </tr>  
        </table>
   <br />
	<div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
<%--                 <td style="text-align:right"> <asp:Button ID="btn_edit" runat="server" 
                Text="编辑" class="btn  radius"   BackColor="#60B1D7" ForeColor="White" 
                Width="199px" OnClick="btn_edit_Click"  ></asp:Button></td>
               <td>&nbsp;</td>--%>
<%--                <td style="text-align:center"> <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn  radius"   BackColor="#60B1D7" ForeColor="White" 
                Width="199px" OnClick="btn_save_Click"  ></asp:Button></td>
               <td>&nbsp;</td>--%>
                  <td style="text-align:center">
                      <asp:Button ID="btn_back" runat="server" 
                Text="返回" class="btn  radius"  BackColor="#60B1D7" ForeColor="White" 
                Width="199px"    OnClick="btn_back_Click"></asp:Button>
                  </td>
            </tr>
        </table>
	</div>
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            //备件分类
            $("#ddlt_bjfl").change(function () {
                if ($("#ddlt_bjfl option:selected").val() != "-1") {
                    $("#lbl_bjfl").text("正确");
                    $("#lbl_bjfl").css("color", "#00ff00");
                } else {
                    $("#lbl_bjfl").text("请选择");
                    $("#lbl_bjfl").css("color", "#ff0000");
                }
            });
            //适用
            $("#ddlt_sy").change(function () {
                if ($("#ddlt_sy option:selected").val() != "-1") {
                    $("#lbl_sy").text("正确");
                    $("#lbl_sy").css("color", "#00ff00");
                } else {
                    $("#lbl_sy").text("请选择");
                    $("#lbl_sy").css("color", "#ff0000");
                }
            });

            //备件名称
            $("#tbx_bjmc").blur(function () {
                if ($("#tbx_bjmc").val().trim() != "") {
                    $("#lbl_bjmc").text("正确");
                    $("#lbl_bjmc").css("color", "#00ff00");

                } else {
                    $("#lbl_bjmc").text("错误");
                    $("#lbl_bjmc").css("color", "#ff0000");
                }
            });
            //设备型号
            $("#tbx_sbxh").blur(function () {
                if ($("#tbx_sbxh").val().trim() != "") {
                    $("#lbl_sbxh").text("正确");
                    $("#lbl_sbxh").css("color", "#00ff00");
                }
                else {
                    $("#lbl_sbxh").text("错误");
                    $("#lbl_sbxh").css("color", "#ff0000");
                }

            });
            //板件中文名称
            $("#tbx_bjzwmc").blur(function () {

                if ($("#tbx_bjzwmc").val().trim() != "") {
                    $("#lbl_bjzwmc").text("正确");
                    $("#lbl_bjzwmc").css("color", "#00ff00");
                }
                else {
                    $("#lbl_bjzwmc").text("错误");
                    $("#lbl_bjzwmc").css("color", "#ff0000");
                }

            });
            //内含组件
            //$("#tbx_nhzj").blur(function () {

            //    if ($("#tbx_nhzj").val().trim() != "") {
            //        $("#lbl_nhzj").text("正确");
            //        $("#lbl_nhzj").css("color", "#00ff00");
            //    }
            //    else {
            //        $("#lbl_nhzj").text("错误");
            //        $("#lbl_nhzj").css("color", "#ff0000");
            //    }

            //});
            //内含组件名称
            //$("#tbx_nhzjmc").blur(function () {

            //    if ($("#tbx_nhzjmc").val().trim() != "") {
            //        $("#lbl_nhzjmc").text("正确");
            //        $("#lbl_nhzjmc").css("color", "#00ff00");
            //    }
            //    else {
            //        $("#lbl_nhzjmc").text("错误");
            //        $("#lbl_nhzjmc").css("color", "#ff0000");
            //    }

            //});
            //英文名称
            //$("#tbx_ywmc").blur(function () {

            //    if ($("#tbx_ywmc").val().trim() != "") {
            //        $("#lbl_ywmc").text("正确");
            //        $("#lbl_ywmc").css("color", "#00ff00");
            //    }
            //    else {
            //        $("#lbl_ywmc").text("错误");
            //        $("#lbl_ywmc").css("color", "#ff0000");
            //    }

            //});
            //原机数量
            //$("#tbx_yjsl").blur(function () {

            //    if ($("#tbx_yjsl").val().trim() != "") {
            //        $("#lbl_yjsl").text("正确");
            //        $("#lbl_yjsl").css("color", "#00ff00");
            //    }
            //    else {
            //        $("#lbl_yjsl").text("错误");
            //        $("#lbl_yjsl").css("color", "#ff0000");
            //    }

            //});
            //板件识别号
            $("#tbx_bjsbh").blur(function () {

                if ($("#tbx_bjsbh").val().trim() != "") {
                    $("#lbl_bjsbh").text("正确");
                    $("#lbl_bjsbh").css("color", "#00ff00");
                }
                else {
                    $("#lbl_bjsbh").text("错误");
                    $("#lbl_bjsbh").css("color", "#ff0000");
                }

            });
            //现有备件
            $("#tbx_xybj").blur(function () {

                if ($("#tbx_xybj").val().trim() != "") {
                    $("#lbl_xybj").text("正确");
                    $("#lbl_xybj").css("color", "#00ff00");
                }
                else {
                    $("#lbl_xybj").text("错误");
                    $("#lbl_xybj").css("color", "#ff0000");
                }

            });
            //存放位置
            $("#tbx_cfwz").blur(function () {

                if ($("#tbx_cfwz").val().trim() != "") {
                    $("#lbl_cfwz").text("正确");
                    $("#lbl_cfwz").css("color", "#00ff00");
                }
                else {
                    $("#lbl_cfwz").text("错误");
                    $("#lbl_cfwz").css("color", "#ff0000");
                }

            });


            //备注
            //$("#tbx_bz").blur(function () {

            //    if ($("#tbx_bz").val().trim() != "") {
            //        $("#lbl_bz").text("正确");
            //        $("#lbl_bz").css("color", "#00ff00");
            //    }
            //    else {
            //        $("#lbl_bz").text("错误");
            //        $("#lbl_bz").css("color", "#ff0000");
            //    }

            //});


        });

    </script>
    </form>
</body>
</html>
