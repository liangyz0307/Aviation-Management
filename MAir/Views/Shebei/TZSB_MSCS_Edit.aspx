<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TZSB_MSCS_Edit.aspx.cs" Inherits="CUST.WKG.TZSB_MSCS_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>台站设备灭鼠措施编辑</title>
    <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"=></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <style type="text/css">
        .auto-style1 {
            width: 20%;
            height: 30px;
        }
        .auto-style2 {
            width: 80%;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table>
        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    挡鼠板：<span class="c-red"></span></td>
   <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_dsb" runat="server" style="width:70px" ></asp:DropDownList>
                    <asp:Label ID="lbl_dsb" runat="server" ></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">粘鼠板个数：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zsbgs" runat="server" class="input-text"
                            Width="50px" MaxLength="10" Enabled="True"></asp:TextBox>
                        <asp:Label ID="lbl_zsbgs" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    防洪措施是否具备：<span class="c-red"></span></td>
   <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_fh" runat="server" style="width:70px" ></asp:DropDownList>
                    <asp:Label ID="lbl_fh" runat="server" ></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    防盗措施是否具备：<span class="c-red"></span></td>
   <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_fd" runat="server" style="width:70px" ></asp:DropDownList>
                    <asp:Label ID="lbl_fd" runat="server" ></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    维修工具是否满足该设备故障时紧急维修需求：<span class="c-red"></span></td>
   <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_wxgj" runat="server" style="width:70px" ></asp:DropDownList>
                    <asp:Label ID="lbl_wxgj" runat="server" ></asp:Label>
                    </td>
                </tr>
                
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    机房防雷措施：<span class="c-red"></span></td>
   <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:TextBox ID="tbx_jfflcs" runat="server" class="input-text"
                            Width="50px" MaxLength="10" Enabled="True" ></asp:TextBox>
                    <asp:Label ID="lbl_jfflcs" runat="server" ></asp:Label>
                    </td>
                </tr>

            

           <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">防雷检测到期日期：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_fljcdqrq" runat="server" class="input-text" Width="100px" MaxLength="10" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:Label ID="lbl_fljcdqrq" runat="server"></asp:Label>
                    </td>
                </tr>

             
            <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="auto-style1">
                    是否有地暖：<span class="c-red"></span></td>
   <td colspan="2" style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="auto-style2">  
                    <asp:DropDownList ID="ddlt_sfydn" runat="server" style="width:70px"></asp:DropDownList>
                    <asp:Label ID="lbl_sfydn" runat="server" ></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="auto-style1">
                    驳回原因：<span class="c-red"></span></td>
   <td colspan="2" style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="auto-style2">  
                    <asp:TextBox ID="tbx_bhyy" runat="server" class="input-text"
                            Width="50px" MaxLength="10" Enabled="True" style="height: 19px" ></asp:TextBox>
                    <asp:Label ID="lbl_bhyy" runat="server" ></asp:Label>
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
