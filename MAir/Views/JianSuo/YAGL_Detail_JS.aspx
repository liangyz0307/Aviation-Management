<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YAGL_Detail_JS.aspx.cs" Inherits="CUST.WKG.YAGL_Detail_JS" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <%--   UEdit--%>
      <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.config.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.all.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/lang/zh-cn/zh-cn.js" charset="utf-8"></script>
         <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>
         <script type="text/javascript" src="../../Content/js/jquery.js"></script>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="panel-head">
            <strong class="icon-reorder">员工奖励详情</strong>
        </div>
    <table >           
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     名称：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_mc" runat="server" ></asp:Label>
                    </td>             
            </tr>
 
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     地区：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_dq" runat="server" ></asp:Label>
                    </td>     
            </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     专业：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zy" runat="server" ></asp:Label>
                    </td>             
            </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     预案内容：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_yanr" runat="server" ></asp:Label>
                    </td>             
            </tr>
                 
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     状态：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zt" runat="server" ></asp:Label>
                    </td>              
            </tr> 
        
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     数据所在部门：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_sjssbm" runat="server" ></asp:Label>
                    </td>             
            </tr>
        
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     驳回原因：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bhyy" runat="server" ></asp:Label>
                    </td>              
            </tr> 
        
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     录入人：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_lrr" runat="server" ></asp:Label>
                    </td>              
            </tr> 
                    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     初审人：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_csr" runat="server" ></asp:Label>
                    </td>              
            </tr> 
                    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     终审人：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zsr" runat="server" ></asp:Label>
                    </td>              
            </tr> 
               <%--     <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     审核时间：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_shsj" runat="server" ></asp:Label>
                    </td>     --%>         
            </tr> 
                            
        </table>

<div class="row cl">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
            <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_fh_Click"   ></asp:Button> 
		</div>
        <input id="ChangeFlag" runat="server" type="hidden" />
	</div>  
	</form>
             <script type="text/javascript" src="../css/js/jquery.js"></script>
            <script type="text/javascript" src="../css/js/H-ui.admin.js"></script>
            <script type="text/javascript" src="../css/js/H-ui.js"></script>
</article>
    
</body>
    <script src="../../Content/js/jquery.js" type="text/javascript"></script>
      <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
 
    <script src="../css/js/jquery.js" type="text/javascript"></script>
</html>