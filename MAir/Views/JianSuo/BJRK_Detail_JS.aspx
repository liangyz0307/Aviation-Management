<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BJRK_Detail_JS.aspx.cs" Inherits="CUST.WKG.BJRK_Detail_JS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
            td.td_sjsc
            {
                background:#F6FAFD;
            }    
        
    </style>
</head>
<body>
         <article class="page-container">
    <form id="Form1" runat="server" class="form form-horizontal">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
       <table  style="border-top:2px solid #C0D9D9;border:2px solid #C0D9D9;">
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件编号：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                
                 <asp:Label ID="lbl_bjbh" runat="server" ></asp:Label>
            </td>
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件名称：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:Label ID="lbl_bjmc" runat="server"  ></asp:Label>
            </td> 
        </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件类型：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_bjfl" runat="server"></asp:Label>
            </td>
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件适用：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_bjsy" runat="server"></asp:Label>
            </td> 
        </tr>
              
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                
                 经办人部门：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               
                 
                <asp:Label ID="lbl_jbrbm" runat="server"></asp:Label>
               
            </td>
                 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                经办人岗位：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
            
                  
                <asp:Label ID="lbl_jbrgw" runat="server"></asp:Label>
                
            </td>
        </tr> 
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                负责人部门：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 
              
                <asp:Label ID="lbl_fzrbm" runat="server"></asp:Label>
                    
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                负责人岗位： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                   
                <asp:Label ID="lbl_fzrgw" runat="server"></asp:Label>
                      
            </td>
        </tr> 
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               入库经办人：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 
          
                   
                <asp:Label ID="lbl_jbr" runat="server"></asp:Label>
             
            </td> 
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                库房负责人： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              
                  
               
                <asp:Label ID="lbl_fzr" runat="server"></asp:Label>
                  
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                入库数量：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                
                <asp:Label ID="lbl_rksl" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                入库时间：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_rksj" runat="server"></asp:Label>
            </td>
        </tr> 
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              存放位置 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               
                <asp:Label ID="lbl_cfwz" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
             驳回原因：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_bhyy" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              初审人 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               
                <asp:Label ID="lbl_csr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
             终审人 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_zsr" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              录入人 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               
                <asp:Label ID="lbl_lrr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
             数据所在部门 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_sjszbm" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                入库备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                 <asp:Label ID="lbl_bz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
   <br />
	<div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
                  
               <td style="text-align:center">
                   <asp:Button ID="btn_fh" runat="server"  Text="返回" class="btn radius"   Width="199px"  BackColor="#60B1D7" ForeColor="White"  OnClick="btn_back_Click">
                   </asp:Button>
               </td>
            </tr>
        </table>
	</div>

        
  </form>

                 </article>
   
</body>
</html>
