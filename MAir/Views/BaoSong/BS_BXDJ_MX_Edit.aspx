<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_BXDJ_MX_Edit.aspx.cs" Inherits="CUST.WKG.BS_BXDJ_MX_Edit" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>维修费用</title>
      <script src="../../Content/js/jquery.js"></script>
     <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
     <article class="page-container">
    <form id="form1" runat="server">
        <div  style="padding:1%">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
        <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
        
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                 人工费明细：   <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 80%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_rgfmx"  runat="server" Width="60%" Height="25px"></asp:TextBox>
                        <asp:Label ID="lbl_rgfmx" runat="server"></asp:Label>
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                 人工费数量：   <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 80%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_rgfsl"  runat="server" Width="60%" Height="25px"></asp:TextBox>
                        <asp:Label ID="lbl_rgfsl" runat="server"></asp:Label>
            </td>
        </tr>
                <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                 人工费不含税：   <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 80%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_rgfbhs"  runat="server" Width="60%" Height="25px"></asp:TextBox>
                        <asp:Label ID="lbl_rgfbhs" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                 人工费含税：   <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 80%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_rgfhs"  runat="server" Width="60%" Height="25px"></asp:TextBox>
                        <asp:Label ID="lbl_rgfhs" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                 配件名称：   <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 80%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_pjmc"  runat="server" Width="60%" Height="25px"></asp:TextBox>
                        <asp:Label ID="lbl_pjmc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                 配件数量：   <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 80%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_pjsl"  runat="server" Width="60%" Height="25px"></asp:TextBox>
                        <asp:Label ID="lbl_pjsl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                 配件费用不含税：   <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 80%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_pjfybhs"  runat="server" Width="60%" Height="25px"></asp:TextBox>
                        <asp:Label ID="lbl_pjfybhs" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                 配件费用含税：   <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 80%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_pjfyhs"  runat="server" Width="60%" Height="25px"></asp:TextBox>
                        <asp:Label ID="lbl_pjfyhs" runat="server"></asp:Label>
            </td>
        </tr>
            
            
    </table>
              <br />
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btn_save" runat="server"
                                Text="保存" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_save_Click" ></asp:Button></td>
                        <td>&nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="btn_fh" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_fh_Click"
                                Width="199px" ></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
          </div>
    </form>
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.admin.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.js"></script>
</article>
</body>
    <script type="text/javascript">
        
        $(document).ready(function () {
            //人工费明细
            $("#tbx_rgfmx").blur(function ()
            {
                if ($("#tbx_rgfmx").val().trim() == "")
                {
                    $("#lbl_rgfmx").text("内容不能为空");
                    $("#lbl_rgfmx").css("color", "#ff0000");
                }
                else
                {
                    $("#lbl_rgfmx").text("正确");
                    $("#lbl_rgfmx").css("color", "#00ff00");
                }
            });
            //人工费数量
            $("#tbx_rgfsl").blur(function () {
                if ($("#tbx_rgfsl").val().trim() == "") {
                    $("#lbl_rgfsl").text("内容不能为空");
                    $("#lbl_rgfsl").css("color", "#ff0000");
                }
                else {
                    $("#lbl_rgfsl").text("正确");
                    $("#lbl_rgfsl").css("color", "#00ff00");
                }
            });
            //人工费不含税
            $("#tbx_rgfbhs").blur(function () {
                if ($("#tbx_rgfbhs").val().trim() == "") {
                    $("#lbl_rgfbhs").text("内容不能为空");
                    $("#lbl_rgfbhs").css("color", "#ff0000");
                }
                else {
                    $("#lbl_rgfbhs").text("正确");
                    $("#lbl_rgfbhs").css("color", "#00ff00");
                }
            });
            //人工费含税
            $("#tbx_rgfhs").blur(function () {
                if ($("#tbx_rgfhs").val().trim() == "") {
                    $("#lbl_rgfhs").text("内容不能为空");
                    $("#lbl_rgfhs").css("color", "#ff0000");
                }
                else {
                    $("#lbl_rgfhs").text("正确");
                    $("#lbl_rgfhs").css("color", "#00ff00");
                }
            });
            //配件名称
            $("#tbx_pjmc").blur(function () {
                if ($("#tbx_pjmc").val().trim() == "") {
                    $("#lbl_pjmc").text("内容不能为空");
                    $("#lbl_pjmc").css("color", "#ff0000");
                }
                else {
                    $("#lbl_pjmc").text("正确");
                    $("#lbl_pjmc").css("color", "#00ff00");
                }
            });
            //配件数量
            $("#tbx_pjsl").blur(function () {
                if ($("#tbx_pjsl").val().trim() == "") {
                    $("#lbl_pjsl").text("内容不能为空");
                    $("#lbl_pjsl").css("color", "#ff0000");
                }
                else {
                    $("#lbl_pjsl").text("正确");
                    $("#lbl_pjsl").css("color", "#00ff00");
                }
            });
            //配件费用不含税
            $("#tbx_pjfybhs").blur(function () {
                if ($("#tbx_pjfybhs").val().trim() == "") {
                    $("#lbl_pjfybhs").text("内容不能为空");
                    $("#lbl_pjfybhs").css("color", "#ff0000");
                }
                else {
                    $("#lbl_pjfybhs").text("正确");
                    $("#lbl_pjfybhs").css("color", "#00ff00");
                }
            });
            //配件费用含税
            $("#tbx_pjfyhs").blur(function () {
                if ($("#tbx_pjfyhs").val().trim() == "") {
                    $("#lbl_pjfyhs").text("内容不能为空");
                    $("#lbl_pjfyhs").css("color", "#ff0000");
                }
                else {
                    $("#lbl_pjfyhs").text("正确");
                    $("#lbl_pjfyhs").css("color", "#00ff00");
                }
            });
        } );
        </script>
</html>
