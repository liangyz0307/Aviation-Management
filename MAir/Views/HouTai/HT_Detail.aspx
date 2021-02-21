<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HT_Detail.aspx.cs" Inherits="CUST.WKG.HT_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <title>合同详情</title>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>
     <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
     <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
              
            }    
    </style>
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
</head>
<body>
     <article class="page-container">
<form id="Form1" runat="server" class="form form-horizontal">
     
    <div class="panel-head">
            <strong class="icon-reorder">合同添加</strong>
        </div>
    <table >
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    合同名称：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                     
                    <asp:Label ID="lbl_htmc" runat="server" ></asp:Label>
                </td>
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    签订方：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                
                    <asp:Label ID="lbl_qdf" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    总额：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    
                    <asp:Label ID="lbl_ze" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    签订日期：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                    
                    <asp:Label ID="lbl_qdrq" runat="server" ></asp:Label>
                </td>
            </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    期限：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_kssj" runat="server" ></asp:Label>
                     --
                    <asp:Label ID="lbl_jssj" runat="server" ></asp:Label>
                </td>                
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    状态：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                  <asp:Label ID="lbl_zt" runat="server" ></asp:Label>
                </td>
                
            </tr>
          
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   负责人：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">                       
                    <asp:Label ID="lbl_fzr" runat="server" ></asp:Label>
                </td>
                
            </tr>
            <tr style="vertical-align: top;  width:100%;height:50px; border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%; height:50px;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   备注：</td>
                <td   style="width:40%;height:50px;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:Label ID="lbl_bz" runat="server"  TextMode="MultiLine" BorderStyle="None"  style="resize:none;"  Height ="50px" width="490px"  ></asp:Label>
                </td>
         </tr>
        </table>
	        <div>
			<div >
                <div style="text-align:center;">
                <asp:Button ID="btn_fh" runat="server" Text="返回" 
                    class="btn  radius" Width="191px"  BackColor="#60B1D7"  ForeColor="White" OnClick="btn_fh_Click"></asp:Button>
			</div>
          </div>
		</div>            
	</form>
</article>
</body>
</html>
