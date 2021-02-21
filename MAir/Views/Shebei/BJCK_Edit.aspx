<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BJCK_Edit.aspx.cs" Inherits="CUST.WKG.BJCK_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>备件详情</title>
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
    <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"=></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server" class="form form-horizontal">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <table style="border-top: 2px solid #C0D9D9; border-bottom: 2px solid #C0D9D9;">
            <tr style="vertical-align: top; width: 100%; height: 30px; border-bottom: 1px solid #C0D9D9;">
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">备件编号：<asp:Label ID="Label3" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">

                    <asp:Label ID="lbl_bjbh" runat="server"></asp:Label>
                </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">备件名称：<asp:Label ID="Label4" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_bjmc" runat="server"></asp:Label>
                </td>
            </tr>


            <tr style="vertical-align: top; width: 100%; height: 30px; border-bottom: 1px solid #C0D9D9;">
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">经办人部门：
                    <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlt_jbrbm" runat="server" OnSelectedIndexChanged="ddlt_jbrbm_SelectedIndexChanged" Width="100px" AutoPostBack="True"></asp:DropDownList>
                            <asp:Label ID="lbl_jbrbm" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">负责人部门：<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlt_fzrbm" runat="server" OnSelectedIndexChanged="ddlt_fzrbm_SelectedIndexChanged" Width="100px" AutoPostBack="True"></asp:DropDownList>
                            <asp:Label ID="lbl_fzrbm" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border-bottom: 1px solid #C0D9D9;">
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">经办人岗位：<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlt_jbrgw" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_jbrgw_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Label ID="lbl_jbrgw" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">负责人岗位：
                    <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlt_fzrgw" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_fzrgw_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Label ID="lbl_fzrgw" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border-bottom: 1px solid #C0D9D9;">
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">出库经办人：
                    <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlt_jbr" runat="server" Width="100px"></asp:DropDownList>

                            <asp:Label ID="lbl_jbr" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">库房负责人：
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlt_fzr" runat="server" Width="100px"></asp:DropDownList>

                            <asp:Label ID="lbl_fzr" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>

            </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border-bottom: 1px solid #C0D9D9;">
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">出库数量：
                    <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_cksl" runat="server" placeholder="出库数量" Height="26px" MaxLength="6" onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;"></asp:TextBox>
                    <asp:Label ID="lbl_cksl" runat="server"></asp:Label>
                </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">出库时间：<asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_cksj" runat="server" Height="26px" placeholder="出库时间" onclick="lhgcalendar({format:'yyyy-MM-dd hh:mm:ss'})"></asp:TextBox>
                    <asp:Label ID="lbl_cksj" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border-bottom: 1px solid #C0D9D9;">
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">存放位置 ：<asp:Label ID="Label13" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_cfwz" placeholder="存放位置" runat="server" Height="26px"></asp:TextBox>
                    <asp:Label ID="lbl_cfwz" runat="server"></asp:Label>
                </td>

             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                数据所在部门： <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:DropDownList ID="ddlt_sjszbm" runat="server" style="width:100px"></asp:DropDownList>
                    <asp:Label ID="lbl_sjszbm" runat="server" ></asp:Label>
                
            </td>


            </tr>
                                  <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                初审人：  <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:DropDownList ID="ddlt_csr" runat="server" style="width:100px"></asp:DropDownList>
                    <asp:Label ID="lbl_csr" runat="server" ></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                终审人： <asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:DropDownList ID="ddlt_zsr" runat="server" style="width:100px"></asp:DropDownList>
                    <asp:Label ID="lbl_zsr" runat="server" ></asp:Label>
            </td>
        </tr> 

            <tr style="vertical-align: top; width: 100%; height: 30px; border-bottom: 1px solid #C0D9D9;">

                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">出库备注：
                    <asp:Label ID="Label14" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                    <asp:TextBox ID="tbx_bz" runat="server" TextMode="MultiLine" Style="resize: none;" placeholder="出库备注" Height="70px" Width="750px"></asp:TextBox>

                </td>

            </tr>
        </table>
        <br />
        <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
            <table>
                <tr>
                    <td style="text-align: right ">
                        <asp:Button ID="btn_bc" runat="server" Text="保存" class="btn  radius" Width="199px" OnClick="btn_save_Click" BackColor="#60B1D7" ForeColor="White"></asp:Button>
                    </td>
                    <td>&nbsp;</td>
                    <td style="text-align: left">
                        <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn radius" Width="199px" BackColor="#60B1D7" ForeColor="White" OnClick="btn_back_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </div>


        
    </form>



</body>
</html>
