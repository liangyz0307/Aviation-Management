﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_TQCZ_Edit.aspx.cs" Inherits="CUST.WKG.BS_TQCZ_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
       <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
        <link  rel="stylesheet" type="text/css" href="../../Content/css/ygxz.css"/>
     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
      <article class="page-container">
<form id="Form1" runat="server" class="form form-horizontal">
    
	<div class="panel-head">
            <strong class="icon-reorder">特情处置修改</strong>
        </div>
       <table >
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   员 工 编 号：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   
                    <asp:Label ID="lbl_bh" runat="server" ></asp:Label>
                      </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    报 送 岗 位：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
              
                     <asp:Label ID="lbl_bsgw" runat="server" ></asp:Label>
                    </td>
            </tr>

         
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    报 送 时 间：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:TextBox ID="tbx_bssj" runat="server"  class="Wdate"   Height="20px"  Width="150px" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                    <asp:Label ID="lbl_bssj" runat="server" ></asp:Label>
                </td>
                
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   管 制 情 况：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_gzqk" runat="server" class="input-text" 
                 Width="150px" MaxLength="50" ></asp:TextBox>
                    <asp:Label ID="lbl_qzqk" runat="server" ></asp:Label>
                </td>
            </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   事件涉及的航空器和机组有关情况：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:TextBox ID="tbx_sjqk" runat="server" class="input-text" 
                 Width="150px" MaxLength="50" ></asp:TextBox>
                    <asp:Label ID="lbl_sjqk" runat="server" ></asp:Label>
                </td>
                
            </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   空管相关设备运行状况：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:TextBox ID="tbx_sbyxqk" runat="server" class="input-text"
                 Width="150px" MaxLength="50" ></asp:TextBox>
                    <asp:Label ID="lbl_sbyxqk" runat="server" ></asp:Label>
                </td>
                
            </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   事 发 时 间：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:TextBox ID="tbx_sfsj" runat="server" class="Wdate" 
                 Width="150px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="lbl_sfsj" runat="server" ></asp:Label>
                </td>
                
            </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   责 任 单 位：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <asp:DropDownList ID="ddlt_zrbm" runat="server" Width="150px"></asp:DropDownList>
                     <asp:Label ID="lbl_zrdw" runat="server" ></asp:Label>
                </td>
                
            </tr>


             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   负 责 人 ：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_fzr" runat="server" class="input-text"
                 Width="150px" MaxLength="10" Enabled="False"></asp:TextBox>
                     
                   <a href="javascript:show_yg()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_yg">
                            <table>
                                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                部门： 
                                             <asp:DropDownList ID="ddlt_bmdm" runat="server" AutoPostBack="True"
                                                 class="select-box" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged"  Style="width: 130px">
                                             </asp:DropDownList>
                                                           <br /> 岗位： 
                                                <asp:DropDownList ID="ddlt_gwdm" runat="server" class="select-box"  AutoPostBack="True"  Style="width: 130px" OnSelectedIndexChanged="ddlt_gwdm_SelectedIndexChanged"></asp:DropDownList>                                        
                                                           <br /> 员工： 
                                                <asp:DropDownList ID="ddlt_yg" runat="server"  class="select-box" Style="width: 130px"></asp:DropDownList>                                    
                                                <br />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <div style="text-align: center">
                                <table>
                                    <tr>
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_zrr" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClick="btn_zrr_Click" OnClientClick="hide()" Text="保存"
                                                Width="100px" />
                                        </td >
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_gb" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClientClick="hide()" Text="关闭"
                                                Width="100px" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over">
                        </div>
                </td>
                
            </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   报 告 时 间 ：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   <asp:TextBox ID="tbx_bgsj" runat="server" class="Wdate" 
                 Width="150px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="lbl_bgsj" runat="server" ></asp:Label>
                </td>
                
        </tr>
        <tr style="vertical-align: top;  width:100%;height:55px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    备 注：&nbsp;&nbsp;</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_bz" runat="server" class="input-text" 
                 Width="500px"  Multiply="true" Height="50px"></asp:TextBox>
                    <asp:Label ID="lbl_bz" runat="server" ></asp:Label>
                </td>
                
            </tr>
        </table>


	   <div class="row cl">
                <div class="row cl" style="text-align: center; width: 100%; margin: 0 auto;">
                    <table>
                        <tr>
                            <td style="text-align: center ; width: 40%;" >
                                <asp:Button ID="btn_save" runat="server"
                                    Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                    Width="199px" OnClick="btn_save_Click" ></asp:Button>
                                <asp:Button ID="btn_fh" runat="server"
                                    Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                    Width="199px" OnClick="btn_fh_Click" Style="margin-bottom: 0px"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
	</form>
</article>
</body>

   <script type="text/javascript">
       var login = document.getElementById('login_yg');
       var over = document.getElementById('over'); //弹出层
       function show_yg() {
           login.style.display = "block";
           over.style.display = "block";
       }
       $("#btn_zrr").click(function () {
           hide();
       });
       function hide() {
           login.style.display = "none";
           over.style.display = "none";
       }
    </script> 
</html>

