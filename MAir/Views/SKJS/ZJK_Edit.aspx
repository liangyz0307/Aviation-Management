<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZJK_Edit.aspx.cs" Inherits="CUST.WKG.ZJK_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>专家库编辑</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
   
</head>
<body>
    <article class="page-container">
<form id="Form1" runat="server" class="form form-horizontal">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
	<div class="panel-head">
            <strong class="icon-reorder">专家库编辑</strong>
        </div>
    <table >


          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   姓名：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                    <asp:TextBox ID="tbx_xm" runat="server" class="input-text" Width="446px" MaxLength="20" placeholder="姓名"></asp:TextBox>
                    <asp:Label ID="lbl_xm" runat="server" ></asp:Label></td>
          </tr>
           
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    专家类型：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_zjlx" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_zjlx" runat="server" ></asp:Label></td>
          </tr>

          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    驻地：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_zd" runat="server" class="input-text" Width="446px" MaxLength="20" placeholder="驻地(不能超过20字！)"></asp:TextBox>
                    <asp:Label ID="lbl_zd" runat="server" ></asp:Label></td>         
          </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    从事工作：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_csgz" runat="server" class="input-text" Width="446px" MaxLength="20" placeholder="从事工作(不能超过20字！)"></asp:TextBox>
                    <asp:Label ID="lbl_csgz" runat="server" ></asp:Label></td>         
          </tr>

          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    专业：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_zy" runat="server" class="input-text" Width="446px" MaxLength="20" placeholder="专业(不能超过20字！)"></asp:TextBox>
                    <asp:Label ID="lbl_zy" runat="server" ></asp:Label></td>         
          </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    专长：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_zc" runat="server" class="input-text" Width="446px" ></asp:TextBox>
                    <asp:Label ID="lbl_zc" runat="server" ></asp:Label></td>         
          </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    联系方式：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_lxfs" runat="server" class="input-text" Width="446px" MaxLength="11" placeholder="联系方式(不能超过11位！)"></asp:TextBox>
                    <asp:Label ID="lbl_lxfs" runat="server" ></asp:Label></td>         
          </tr>

          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    初审人：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_csr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_csr" runat="server" ></asp:Label></td>
          </tr>

          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    终审人：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_zsr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_zsr" runat="server" ></asp:Label></td>
          </tr>

         

          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    数据所属部门：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_bmdm" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_bmdm" runat="server" ></asp:Label></td>
          </tr>
        </table>
	<div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
		    <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="199px" OnClick="btn_save_Click"  ></asp:Button> 
            &nbsp; 
            <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_fh_Click"   ></asp:Button> 
		</div>
	</div>   
	</form>
</article>
</body>
</html>
