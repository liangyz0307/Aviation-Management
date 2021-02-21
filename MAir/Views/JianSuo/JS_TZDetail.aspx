<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_TZDetail.aspx.cs" Inherits="CUST.WKG.JSuo.main.JS_TZDetail" %>

<!DOCTYPE html>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
       <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>

    <script type="text/javascript" src="../lib/respond.min.js"></script>

    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
<link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
    <style type="text/css">
        td.td_sjsc
            {
                background:#F6FAFD;
              
            }    
         .overlay
          {  
              background-color:#000;  
              opacity: .7;  
              filter:alpha(opacity=70);  
              position: fixed;  
              top:0;  
              left:0;  
              width:100%;  
              height:100%;  
              z-index: 10; 
              overflow:scroll; 
            
          }  
    </style>
</head>
<body>
  <article >
<form id="Form1" runat="server" class="form form-horizontal">
  
      <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_qx" runat="server">
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>台站详细信息</strong> 
            </td>
        </tr> 
            <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          台站编号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_tzbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
           台站类型： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_tzlx" runat="server"></asp:Label>
            </td>
        </tr>

     <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          台站名称： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_tzmc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          所属地： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_ssd" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         申请单位： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_sqdw" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          场地及电磁环境符合情况： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_fhqk" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              黄海高程：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_hhgc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                所属空管局：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_ssjgj" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               所在地理位置： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_dlwz" runat="server"></asp:Label>
                <br />
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                不符情况说明：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_bfhqk" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               大地坐标（北京54）经度： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_ddzbjd" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               大地坐标（北京54）纬度：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_ddzbwd" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                大地坐标（wgs84）经度：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_ddzbjdw" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               大地坐标（wgs84）纬度：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              <asp:Label ID="lbl_ddzbwdw" runat="server"></asp:Label>
            </td>
        </tr>
    
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              高程备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_gcbz" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                台址批复编号：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_tzpfbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               台址批复：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:LinkButton ID="lbtn_tzpf" CommandName="down" CommandArgument='<%#Eval("tzpf") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClick="lbtn_tzpf_Click"  ></asp:LinkButton>
                <asp:Label ID="lbl_tzpf" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               频率批复编号：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_plpfbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               频率批复：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:LinkButton ID="lbtn_plpf" CommandName="down" CommandArgument='<%#Eval("plpf") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClick="lbtn_plpf_Click" ></asp:LinkButton>
                  <asp:Label ID="lbl_plpf" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               识别码批复编号：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_sbmpfbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               识别码批复：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:LinkButton ID="lbtn_sbmpf" CommandName="down" CommandArgument='<%#Eval("sbmpf") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClick="lbtn_sbmpf_Click"></asp:LinkButton>
                <asp:Label ID="lbl_sbmpf" runat="server"></asp:Label>
            </td>
              </tr>
              <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              投产使用许可证或批复编号：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_xkzbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               投产使用许可证或批复：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:LinkButton ID="lbtn_tcsyxkzhpf" CommandName="down" CommandArgument='<%#Eval("tcsyxkzhpf") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClick="lbtn_tcsyxkzhpf_Click"></asp:LinkButton>
               <asp:Label ID="lbl_tcsyxkzhpf" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                台站基础资料：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:LinkButton ID="lbtn_tzjczlsc" CommandName="down" CommandArgument='<%#Eval("tzjczlsc") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClick="lbtn_tzjcjl_Click" ></asp:LinkButton>
                <asp:Label ID="lbl_tzjczlsc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_bz" runat="server"></asp:Label>
            </td>
        </tr>
      
         
    </table>
 
    
	 <div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
                <td style="text-align:center">
                     <asp:Button ID="btn_fh" runat="server"  Text="返回" class="btn radius"   BackColor="#60B1D7" ForeColor="White" Width="199px" OnClick="btn_fh_Click"  >

                     </asp:Button>
                </td>
            </tr>
        </table>
	</div>
</form>
</article>
    
</body>
</html>
