<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_BSDetail.aspx.cs" Inherits="CUST.WKG.JS_BSDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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

<form id="Form1" runat="server" class="form form-horizontal">
   
     <table width="100%"  align="center"   cellspacing="0" cellpadding="0" id="t_jbxx"  runat="server">
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>报送基本信息</strong> 
            </td>
        </tr>  
     <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               报送编号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
             
                <asp:Label ID="lbl_bsbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                报送类型： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
            
                <asp:Label ID="lbl_bslx" runat="server"></asp:Label>
            </td>
        </tr>
       <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               报送员工： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       
                <asp:Label ID="lbl_bsyg" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                报送岗位：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
               
                <asp:Label ID="lbl_bsgw" runat="server" Height="25px"></asp:Label>
            </td>
        </tr>
       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
         <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           报送时间：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
         
                <asp:Label ID="lbl_bssj" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
             报送IP：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
               
                <asp:Label ID="lbl_bsip" runat="server"></asp:Label>
            </td>
        </tr>
       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              审批人： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             
                <asp:Label ID="lbl_spr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">    
              
            </td>
        </tr>
      </table>    
    
  
    <table width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_bxd" runat="server">
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>报销单报送详细信息</strong> 
            </td>
        </tr>  
      <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                物品名称：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_wpmc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
             物品类别：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
               
                <asp:Label ID="lbl_wplb" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               单价：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
            
                <asp:Label ID="lbl_dj" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
             数量：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_sl" runat="server"></asp:Label>
            </td>
        </tr>

           <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             生产厂家： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_sccj" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
              购买用途： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_gmyt" runat="server"></asp:Label>
            </td>
        </tr>
             
           <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
            购置人： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_gzr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
             购买日期： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_gmrq" runat="server"></asp:Label>
            </td>
        </tr>

              <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           报销人： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_bxr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
            合计： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_hj" runat="server"></asp:Label>
            </td>
        </tr>
                 <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           负责人	： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_fzr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
            审查意见： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_scyj" runat="server"></asp:Label>
            </td>
        </tr>

               <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           报销形式： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_bxxs" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
            应退金额： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_ytje" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           应补金额： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_ybje" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                状态：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_bxdzt" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_bxdbz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
       
      <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_dzqm" runat="server">
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>电子签名报送详细信息</strong> 
            </td>
        </tr>  
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           签名代码： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_qmdm" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          签名： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_qm" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           状态： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_dzqmzt" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >

            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_dzqmbz" runat="server"></asp:Label>
            </td>
        </tr>
     </table>
  

    <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_fxy" runat="server"> 
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>风险源报送详细信息</strong> 
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              风险源名称： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_fxymc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
           风险源范畴： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
              
                <asp:Label ID="lbl_fxyfc" runat="server"></asp:Label>
            </td>
        </tr>

        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          时态： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
     
                <asp:Label ID="lbl_st" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          风险情景发生的可能性    ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              
                <asp:Label ID="lbl_fxknx" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         风险程度： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_fxcd" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          后果： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_hg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               状态： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_zt" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                风险控制措施：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_fxkzcs" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               控制状态： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_kzzt" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                控制措施标准化情况：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_kzcsbzhqk" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               应急措施： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_yjcs" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                责任部门：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_zrbm" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               责任人： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_zrr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              状态：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_fxyzt" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_fxy" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    
    <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_gdzc" runat="server"> 
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>固定资产报送详细信息</strong> 
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          资产编号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_zcbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
        资产名称： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_zcmc" runat="server"></asp:Label>
            </td>
        </tr>

               <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          单价： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_zcdj" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          数量    ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_zcsl" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         资产类别： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_zclb" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          使用方向： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_syfx" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               存放地点： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_cfdd" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                使用部门：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_sybm" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               资产来源： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_zcly" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                购置日期：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_zcgzrq" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               入账形式： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_rzxs" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                入账日期：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_rzrq" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           状态： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_gdzczt" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >

            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_gdzcbz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
   
     <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_gzjz" runat="server"> 
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>工作进展报送详细信息</strong> 
            </td>
        </tr> 
       <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          支线名称： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_zxmc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
        工作内容： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_gznr" runat="server"></asp:Label>
            </td>
        </tr>

               <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          完成进度：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_wcjd" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          工作负责人：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_gzfzr" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         工作轮次： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_gzlc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
            状态：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                > <asp:Label ID="lbl_gzjzzt" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_gzjz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
   
     <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_hbyxxx" runat="server"> 
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>航班运行报送详细信息</strong> 
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          航班号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_hbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
        航班类型： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_hblx" runat="server"></asp:Label>
            </td>
        </tr>
       <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          支线名称： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_hbzxmc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          气象情况： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_qxqk" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         出发城市： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_cfcs" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          出发日期： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_cfrq" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               到达日期： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_ddrq" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             状态：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                   <asp:Label ID="lbl_hbyxzt" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

     <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_sg" runat="server">
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>事故报送详细信息</strong> 
            </td>
        </tr> 
            <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          事发时间： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_sfsj" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          事故详情： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_sgxq" runat="server"></asp:Label>
            </td>
        </tr>

               <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          事故负责人：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_sgfzr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                状态：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_sgzt" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_sgbz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

   
     <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_tq" runat="server">
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>特情处置报送详细信息</strong> 
            </td>
        </tr> 
            <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          管制情况： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_gzqk" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          事件涉及的航空器和机组有关情况： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_sjqk" runat="server"></asp:Label>
            </td>
        </tr>

        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          空管相关设备运行状况：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_sbyxqk" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           事发时间：
                 </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_tqsfsj" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          责任单位：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_zrdw" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           负责人：
                 </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_tqfzr" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          报告时间：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_bgsj" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 状态：</td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">  
                <asp:Label ID="lbl_tqzt" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_tqbz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

     <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_ys" runat="server">
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>预算报送详细信息</strong> 
            </td>
        </tr> 
            <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          申请部门： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_sqbm" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          预算总额： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_ysze" runat="server"></asp:Label>
            </td>
        </tr>

        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               预算用途：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_ysyt" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           应用年限：
                 </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_yynx" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          预算来源：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_ysly" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                状态：
                 </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:Label ID="lbl_yszt" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_ysbz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_zbap" runat="server">
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>值班安排报送详细信息</strong> 
            </td>
        </tr> 
            <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          值班员编号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_zbap" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          值班时间： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_zbsj" runat="server"></asp:Label>
            </td>
        </tr>

        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               值班地点：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_zbdd" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           值班轮次：
                 </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_zblc" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               状态：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_zazt" runat="server"></asp:Label>
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
                <asp:Label ID="lbl_zbbz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
   
     <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_zdgz" runat="server">
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>重点工作报送详细信息</strong> 
            </td>
        </tr> 
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             重点工作内容： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_zdgznr" runat="server"></asp:Label>
            </td>
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             报送支线： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_bszx" runat="server"></asp:Label>
            </td>
        </tr>

        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               工作负责人：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_zdgzfzr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           工作轮次：
                 </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_zdgzlc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          执行支线： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_zxzx" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                状态：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_zdgzzt" runat="server"></asp:Label>
            </td>
          </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_zdgz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>


    <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_zy" runat="server">
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>自愿报送详细信息</strong> 
            </td>
        </tr> 
            <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             报送描述： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_bsms" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          解决方案： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_jjfa" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             状态： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_zyzt" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
     
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
               
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_zybz" runat="server"></asp:Label>
            </td>
        </tr>
    </table> 
    <div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
                <td style="text-align:center">
                     <asp:Button ID="btn_fh" runat="server"  Text="返回" class="btn radius"   BackColor="#60B1D7" ForeColor="White" Width="199px" OnClick="btn_fh_Click" >

                     </asp:Button>
                </td>
            </tr>
        </table>
	</div>
    	</form>

</body>
</html>
