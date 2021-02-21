<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZCGL_Detail_YGXX.aspx.cs" Inherits="CUST.WKG.ZCGL_Detail_YGXX" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
            <strong class="icon-reorder">员工职称详情</strong>
        </div>
    <table >           
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     受聘人：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_spr" runat="server" ></asp:Label>
                    </td>             
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     类别：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_lb" runat="server" ></asp:Label>
                    </td>     
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     级别：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_jb" runat="server" ></asp:Label>
                    </td>             
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     资格：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zg" runat="server" ></asp:Label>
                    </td>             
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     是否聘任：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_pr" runat="server" ></asp:Label>
                    </td>              
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     资格审权单位：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zgsqdw" runat="server" ></asp:Label>
                    </td>             
            </tr>                
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     获得时间：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_hdsj" runat="server" ></asp:Label>
                    </td>             
            </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     到期时间：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_dqsj" runat="server" ></asp:Label>
                    </td>             
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     聘任时间：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_prsj" runat="server" ></asp:Label>
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
                   <%-- <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:40%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     审核时间：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_shsj" runat="server" ></asp:Label>
                    </td>              
            </tr> --%>
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
</html>
