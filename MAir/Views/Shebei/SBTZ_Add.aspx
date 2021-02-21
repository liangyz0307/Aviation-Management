<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SBTZ_Add.aspx.cs" Inherits="CUST.WKG.SBTZ_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
   <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    
    
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
     
	<div class="panel-head">
            <strong class="icon-reorder">台站基本信息添加</strong>
        </div>
    <table >

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    台站名称：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_jc" runat="server" style="width:200px" AutoPostBack="True" ></asp:DropDownList>
                      <asp:DropDownList ID="ddlt_wz" runat="server"  style="width:200px"></asp:DropDownList>
                     <asp:DropDownList ID="ddlt_sblx" runat="server"  style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_jc" runat="server" ></asp:Label>
                    <asp:Label ID="lbl_wz" runat="server" ></asp:Label>
                    <asp:Label ID="lbl_sblx" runat="server" ></asp:Label>
                    </td>
            </tr>

             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    房屋信息：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_fwxx" runat="server" class="input-text" placeholder="建议填写砖混、标准机房" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_fwxx" runat="server" ></asp:Label>
                    </td>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    楼层：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_lc" runat="server" class="input-text" placeholder="楼层" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_lc" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    房间号：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_fjh" runat="server" class="input-text" placeholder="房间号" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_fjh" runat="server" ></asp:Label>
                    </td>
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    结构：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_jg" runat="server" class="input-text" placeholder="长*宽" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_jg" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   竣工时间：<span class="c-red">*</span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_jgsj" runat="server" class="input-text" style="width:200px" placeholder="竣工时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_jgsj" runat="server" ></asp:Label></td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    台站位置：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_tzwzxx" runat="server" class="input-text" placeholder="坐标" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_tzwzxx" runat="server" ></asp:Label>
                    </td>
            </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    机房输入线路情况：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_jfsrxlqk" runat="server" class="input-text" placeholder="建议填写：双路、单路、油机等" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_jfsrxlqk" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    机房总输出：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_jfzsc" runat="server" class="input-text" placeholder="建议填写：双ups（容量）、单ups（容量）、市电" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_jfzsc" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    机房总输出大小：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_jfzscdx" runat="server" class="input-text" placeholder="机房总输出大小" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_jfzscdx" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    机房总输出数量：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_jfzscsl" runat="server" class="input-text" placeholder="机房总输出数量" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_jfzscsl" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      上传：<span class="c-red">*</span></td>                    
                <td colspan="2" style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">                   
                    <asp:FileUpload ID="FileUpload_sc" runat="server" />
                    <asp:Label ID="lbl_sc" runat="server" ></asp:Label>
                </td>              
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    台站温度是否达标：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_tzwdsfdb" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_tzwdsfdb" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    不达标原因：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_bdbyy" runat="server" class="input-text" placeholder="不达标时填写，达标时填写达标" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_bdbyy" runat="server" ></asp:Label>
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
        </table>

	<div class="row cl">
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
    <script src="../css/js/jquery.js" type="text/javascript"></script>
      <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
       
</html>
