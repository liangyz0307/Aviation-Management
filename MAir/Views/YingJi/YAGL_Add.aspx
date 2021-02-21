<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YAGL_Add.aspx.cs" Inherits="CUST.WKG.YAGL_Add" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>预案管理</title>
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
               <td style="width:150px" align="right">名称：<span class="c-red">*</span></td>
               <td style="width:800px" align="left">
                     <asp:TextBox ID="tbx_mc" runat="server" class="td_sjsc" style="width:200px;height:24px;"></asp:TextBox>
                   <asp:Label ID="lbl_mc" runat="server"></asp:Label>
                   <br />
                </td>
           </tr>
            <tr >
               <td style="width:150px;" align="right">地区：<span class="c-red">*</span></td>
               <td style="width:800px" align="left">
                   <asp:DropDownList ID="ddlt_dq"  runat="server"  style="width:100px;height:24px"></asp:DropDownList>
                   <asp:Label ID="lbl_dq" runat="server"></asp:Label>
                   <br />
               </td>
           </tr>
            <tr >
               <td style="width:150px;" align="right">专业：<span class="c-red">*</span></td>
               <td style="width:800px" align="left">
                   <asp:DropDownList ID="ddlt_zy"  runat="server"  style="width:100px;height:24px"></asp:DropDownList>
                   <asp:Label ID="lbl_zy" runat="server"></asp:Label>
                   <br />
               </td>
           </tr>
            <tr>
               <td style="width:150px;" align="right">预案内容：</td>
               <td style="width:800px" align="left">

                   <asp:TextBox ID="txtEditorContents" name="txtEditorContents" runat="server" TextMode="MultiLine" Height="300px" Width="800px" ClientIDMode="Static"> </asp:TextBox>
               </td>
           </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    数据所在部门：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_sjszbm" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_sjszbm" runat="server" ></asp:Label>
                    </td>
            </tr>
               <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    初审人：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_csr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_csr" runat="server" ></asp:Label>
                    </td>
            </tr>
                    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    终审人：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_zsr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_zsr" runat="server" ></asp:Label>
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
    <script type="text/javascript">

        //实例化编辑器
        var ue = UE.getEditor('txtEditorContents');
</script>
    <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
   <%-- <script type="text/javascript">
        $(document).ready(function () {
          //名称
            $("#tbx_mc").blur(function() {
                if ($("#tbx_mc").val() != "") {
                    $("#lbl_mc").text("正确");
                    $("#lbl_mc").css("color", "#00ff00");
                } else {
                $("#lbl_mc").text("内容不能为空");
                $("#lbl_mc").css("color", "#ff0000");
                }
            });
            //地区
            $("#ddlt_dq").blur(function () {

                if ($("#ddlt_dq option:selected").val() != "-1") {
                    $("#lbl_dq").text("正确");  
                    $("#lbl_dq").css("color", "#00ff00");
                } else {
                    $("#lbl_dq").text("请选择");
                    $("#lbl_dq").css("color", "#ff0000");
                }

            });
        //专业
                $("#ddlt_zy").blur(function () {
                    if ($("#ddlt_zy option:selected").val() != '-1') {
                        $("#lbl_zy").text("正确");
                        $("#lbl_zy").css("color", "#00ff00");
                    }
                    else
                    {
                        $("#lbl_zy").text("请选择");
                        $("#lbl_zy").css("color","#ff0000")
                    }
                   
            });
            
        });
    </script>--%>
</body>
</html>