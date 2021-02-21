<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TZSB_JSQQK_Add.aspx.cs" Inherits="CUST.WKG.TZSB_JSQQK_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>台站设备加湿器情况</title>
    <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"=></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table>
        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    是否配备：<span class="c-red"></span></td>
   <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_sfpb" runat="server" style="width:70px" ></asp:DropDownList>
                    <asp:Label ID="lbl_sfpb" runat="server" ></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">数量：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_sl" runat="server" class="input-text"
                            Width="50px" MaxLength="10" Enabled="True"></asp:TextBox>
                        <asp:Label ID="lbl_sl" runat="server"></asp:Label>
                    </td>
                </tr>

                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">品牌：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_pp" runat="server" class="input-text"
                            Width="50px" MaxLength="10" Enabled="True" ></asp:TextBox>
                        <asp:Label ID="lbl_pp" runat="server"></asp:Label>
                    </td>
                </tr>
           <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">安装时间：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_azsj" runat="server" class="input-text" Width="100px" MaxLength="10" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:Label ID="lbl_azsj" runat="server"></asp:Label>
                    </td>
                </tr>

              <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">保修年限：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bxnx" runat="server" class="input-text"
                            Width="50px" MaxLength="10" Enabled="True" style="height: 19px" ></asp:TextBox>
                        <asp:Label ID="lbl_bxnx" runat="server"></asp:Label>
                    </td>
                </tr>
                </table>
        </div>
                <div id="pxs">
                    <table>
 
                           </table>
                            <br />
                            <div style="text-align: center">
                                <asp:Button ID="btn_bc" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc_Click" OnClientClick="hide()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White"  Text="返回"
                                    Width="100px" OnClick="btn_gb_Click" />
                            </div>
                        </div>  
    </form>
</body>
</html>
