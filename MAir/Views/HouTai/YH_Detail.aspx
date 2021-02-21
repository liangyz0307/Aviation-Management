<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YH_Detail.aspx.cs" Inherits="CUST.WKG.YH_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

 <head id="Head1" runat="server">
    <title></title>
   <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>

    <script type="text/javascript" src="../lib/respond.min.js"></script>

    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
 <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css"
        id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
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
	 <div class="panel-head" style="text-align:center">
            <strong class="icon-reorder">用户详情</strong>
        </div>
    <table >
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    用 户 编 号：</td>
                <td style="width:30%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_bh" runat="server" ></asp:Label>
                      </td>
                  <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      类 别：</td>
                <td style="width:30%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:Label ID="lbl_lb" runat="server" ></asp:Label>
                    </td>
            </tr>
           

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    名 称：</td>
                <td style="width:30%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:Label ID="lbl_mc" runat="server" ></asp:Label></td>
                 <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     开 始 时 间：</td>
                <td style="width:30%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_kssj" runat="server" ></asp:Label></td>
                
            </tr>
      
       

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    结 束 时 间：</td>
                <td style="width:30%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_jssj" runat="server" ></asp:Label></td>
              <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    是 否 是 权 限 用 户：</td>
                <td style="width:30%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:Label ID="lbl_sfsqxyh" runat="server" ></asp:Label></td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    是 否 启 用：</td>
                <td style="width:30%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_sfqy" runat="server" ></asp:Label></td>
              <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    序 列 号：</td>
                <td style="width:30%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:Label ID="lbl_xlh" runat="server" ></asp:Label></td>
                
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
               
              <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    所 属：</td>
                <td style="width:30%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:Label ID="lbl_ss" runat="server" ></asp:Label></td>
                 <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    是 否 是 管 理 用 户：</td>
                <td  colspan="3" style="width:30%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_sfsglyh" runat="server" ></asp:Label></td>
            </tr>
         
        

        
       
        </table>
<br />
	<div style="text-align:center">
		<div >
		      
              &nbsp;  
              <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="199px"  onclick="btn_fh_Click"></asp:Button>  
		</div>
	</div>
	</form>
</article>
    <!--_footer 作为公共模版分离出去-->

  
    <script type="text/javascript" src="../../Content/css/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../../Content/css/h-ui.admin/js/H-ui.admin.js"></script>

    <!--/_footer /作为公共模版分离出去-->
    <!--请在下方写此页面业务相关的脚本-->


</body>


</html>
