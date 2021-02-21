<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FBGG_Add.aspx.cs" Inherits="CUST.WKG.FBGG_Add" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>发布公告</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
 <%--   UEdit--%>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.config.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.all.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/lang/zh-cn/zh-cn.js" charset="utf-8"></script>
     <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>
      <script type="text/javascript" src="../../Content/js/jquery.js" charset="utf-8"></script>
      <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js" charset="utf-8"></script>
</head>
<body>
 
    <form id="form1" runat="server">
      
    <div>
       <table style ="width:1080px;">
      
            <tr >
               <td style="width:150px" align="right">公告类型：<span class="c-red">*</span></td>
               <td style="width:800px" align="left">
                   <asp:DropDownList ID="ddlt_gglx" runat="server" Height="30px" Width="100px"> </asp:DropDownList>
                   <asp:Label ID="lbl_gglx" runat="server"></asp:Label>
                   <br />
                </td>
           </tr>
            <tr >
               <td style="width:150px;" align="right">公告标题：<span class="c-red">*</span></td>
               <td style="width:800px" align="left">
                   <asp:TextBox ID="tbx_bt" runat="server" class="td_sjsc" style="width:800px;height:24px;"></asp:TextBox>
                   <asp:Label ID="lbl_bt" runat="server"></asp:Label>
                   <br />
               </td>
           </tr>
            <tr>
               <td style="width:150px;" align="right">公告内容：</td>
               <td style="width:800px" align="left">

                   <asp:TextBox ID="txtEditorContents" name="txtEditorContents" runat="server" TextMode="MultiLine" Height="300px" Width="800px" ClientIDMode="Static"> </asp:TextBox>
               </td>
           </tr>
            <tr>
               <td style="width:150px;" align="right">办理时限：</td>
               <td style="width:800px" align="left">
                    <asp:TextBox ID="tbx_blsx" runat="server" class="input-text" 
                 Width="200px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
               </td>
           </tr>
            <tr>
               <td style="width:150px;" align="right">是否待办：</td>
               <td style="width:800px" align="left">
                   <asp:DropDownList ID="ddlt_sfdb" runat="server" Height="30px" Width="134px"> </asp:DropDownList>
               </td>
           </tr>
            <tr>
               <td style="width:150px" align="right">接收部门：<span class="c-red">*</span></td>
               <td style="width:800px" align="left">
                  <asp:CheckBoxList ID="cbxl_jsbm" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"></asp:CheckBoxList>
                   
                   
                   <asp:Label ID="lbl_jsbm" runat="server"></asp:Label>


               </td>
           </tr>
           <tr>               
               <td align="center" colspan="2">
                   <asp:Button ID="btn_bc" runat="server" Text="保存" class="btn  radius"  ForeColor="White" BackColor="#60B1D7" OnClick="btn_bc_Click" OnClientClick="blsx()" />
                   <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" OnClick="btn_fh_Click"/>
               </td>
           </tr>
       </table>
    </div>
    </form> 
    <!--请在下方写此页面业务相关的脚本-->
    <script  src="../css/js/jquery.js" type="text/javascript"></script>
    <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <script type="text/javascript">
        //实例化编辑器
        var ue = UE.getEditor('txtEditorContents');
        $(document).ready(function () {
          //标题
            $("#tbx_bt").blur(function() {
                if ($("#tbx_bt").val() != "") {
                    $("#lbl_bt").text("正确");
                    $("#lbl_bt").css("color", "#00ff00");
                } else {
                $("#lbl_bt").text("错误");
                $("#lbl_bt").css("color", "#ff0000");
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
                if ($("#lbx_jsr1").val() != "") {
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