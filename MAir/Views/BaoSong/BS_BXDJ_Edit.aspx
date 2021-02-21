<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_BXDJ_Edit.aspx.cs" Inherits="CUST.WKG.BS_BXDJ_Edit" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>报销登记</title>
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
            <td style="width: 6%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                 总计：   <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_zj"  runat="server" Width="60%" Height="25px"></asp:TextBox>
                        <asp:Label ID="lbl_zj" runat="server"></asp:Label>
            </td>
        </tr> 

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">
                实际预算执行机场：  <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:DropDownList ID="ddlt_sjyszxjc" width="30%" runat="server"></asp:DropDownList>
                <asp:Label ID="lbl_sjyszxjc" runat="server"></asp:Label>
            </td>
        </tr> 
                      
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
              <td style="width: 6%; text-align: right; vertical-align: middle;" class="td_sjsc">
                登记日期：  <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_djrq" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="登记日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox></td>
             <asp:Label ID="lbl_djrq" runat="server"></asp:Label>
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
            //总计
            $("#tbx_zj").blur(function ()
            {
                if ($("#tbx_zj").val().trim() == "")
                {
                    $("#lbl_zj").text("内容不能为空");
                    $("#lbl_zj").css("color", "#ff0000");
                }
                else
                {
                    $("#lbl_zj").text("正确");
                    $("#lbl_zj").css("color", "#00ff00");
                }
            });
            //实际预算执行机场
            $("#ddlt_sjyszxjc").blur(function ()
            {
                if ($("#ddlt_sjyszxjc option:selected").val() != "-1") {
                    $("#lbl_sjyszxjc").text("正确");
                    $("#lbl_sjyszxjc").css("color", "#00ff00");
                }
                else
                {
                    $("#lbl_sjyszxjc").text("请选择");
                    $("#lbl_sjyszxjc").css("color", "#ff0000");
                }
            });        
        } );
        </script>
</html>