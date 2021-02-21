<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_SBDetail.aspx.cs" Inherits="CUST.WKG.JS_SBDetail" %>

<!DOCTYPE html>

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
  
     <table  style="border:1px solid #C0D9D9;" id="t_dh" runat="server">
       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>导航设备详细信息</strong> 
            </td>
        </tr>  
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备编号：  
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:Label ID="lbl_sbbh" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              端距单位 ：
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc">
             
                <asp:Label ID="lbl_djdw" runat="server"></asp:Label>
            </td>
        </tr>
               <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               频率： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
             
                <asp:Label ID="lbl_pl" runat="server"></asp:Label>
            </td> 
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                呼号：
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               
                <asp:Label ID="lbl_hh" runat="server"></asp:Label>
            </td>
           
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                功能：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              
                <asp:Label ID="lbl_gn" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                数量：
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 
                <asp:Label ID="lbl_sl" runat="server"></asp:Label>
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备类别：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
               
                <asp:Label ID="lbl_sblb" runat="server"></asp:Label>
            </td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备种类：
            </td>
            <td style="width: 32%; text-align: left; vertical-align: middle;" class="td_sjsc" >
              
                <asp:Label ID="lbl_sbzl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               黄海高程：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              
                <asp:Label ID="lbl_hhgc" runat="server"></asp:Label>
            </td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               所属台站名称：
            </td>
            <td style="width: 32%; text-align: left; vertical-align: middle;" class="td_sjsc" >
               
                <asp:Label ID="lbl_sstzmc" runat="server"></asp:Label>
            </td>
        </tr> 
     
       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
           <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                天线高度：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
            
                <asp:Label ID="lbl_txgd" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                监控器方位：
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
              
                <asp:Label ID="lbl_jkqfw" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >   
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                磁偏差：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_cpc" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                地网直径：
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
               
                <asp:Label ID="lbl_dwzj" runat="server"></asp:Label>
            </td>
        </tr>  
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
           
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                地网高度：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                  
                <asp:Label ID="lbl_dwgd" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                地网类型：
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_dwlx" runat="server"></asp:Label>
            </td>
        </tr> 
       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               投产日期： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
               
                <asp:Label ID="lbl_tcrq" runat="server"></asp:Label>
            </td>
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               竣工日期： 
            </td>
            <td style="width: 32%; text-align: left; vertical-align: middle;" class="td_sjsc">
               
                <asp:Label ID="lbl_jgrq" runat="server"></asp:Label>
            </td>
        
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                开放许可到期日： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_kfxkdqr" runat="server"></asp:Label>
            </td> 
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                执照有效期：
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               
                <asp:Label ID="lbl_zzyxq" runat="server"></asp:Label>
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                飞行校验：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
             
                <asp:Label ID="lbl_fxjy" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
               飞行校验日期：
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc">
             
                <asp:Label ID="lbl_fxjyrq" runat="server"></asp:Label>
            </td>
        </tr>   
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
         
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              飞行校验周期： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
             
                <asp:Label ID="lbl_fxjyzq" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                地理位置  ：
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
              
                <asp:Label ID="lbl_dlwz" runat="server"></asp:Label>
            </td>
        </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                覆盖范围 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                   
                <asp:Label ID="lbl_fgfw" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                覆盖不符合说明  ：
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                
                <asp:Label ID="lbl_fgbfhsm" runat="server"></asp:Label>
            </td>
        </tr> 
        
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                大地坐标（北京54）经度 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_ddzbbjjd" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 大地坐标（北京54）纬度  ：
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
               
                <asp:Label ID="lbl_ddzbbjwd" runat="server"></asp:Label>
            </td>
        </tr>   
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               大地坐标（wgs84）经度：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"  >
                <asp:Label ID="lbl_ddzbwgsjd" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  大地坐标（wgs84）纬度  ： 
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_ddzbwgswd" runat="server"></asp:Label>
            </td>
        </tr>  
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               支线名称：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"  >
                <asp:Label ID="lbl_zxmc" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  保障情况： 
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_bzqk" runat="server"></asp:Label>
            </td>
        </tr>  
         <tr style="vertical-align: top;  width:100%;height:30px;  border-top:2px solid #C0D9D9;border:1px solid #C0D9D9;" >
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                 无线电设备发射核准证编号：
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     
                <asp:Label ID="lbl_wxdsbfshzzbh" runat="server"></asp:Label>
              </td>
               <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
             
                  无线电设备发射核准证件 ： 
              </td>
              <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:LinkButton ID="lbtn_wxdsbfshzzj" CommandName="down" CommandArgument='<%#Eval("wxdsbfshzzj") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClick="lbtn_wxdsbfshzzj_Click" ></asp:LinkButton>
                  <asp:Label ID="lbl_wxdsbfshzzj" runat="server"></asp:Label>
              </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               高程备注：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;height:50px;" class="td_sjsc"
               colspan="3"  >
                <asp:Label ID="lbl_gcbz" runat="server"></asp:Label>
            </td>
            
        </tr> 
  </table>
     <table style="border:1px solid #C0D9D9;" id="t_tx" runat="server" >
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>通信设备详细信息</strong> 
            </td>
        </tr>  
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备编号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
             
                <asp:Label ID="lbl_txsbbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                设备种类： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
            
                <asp:Label ID="lbl_txsbzl" runat="server"></asp:Label>
            </td>
        </tr>

          <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               所属台站名称： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       
                <asp:Label ID="lbl_txsstzmc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                竣工验收日期：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
               
                <asp:Label ID="lbl_jgysrq" runat="server" Height="25px"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           投产开放日期：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
         
                <asp:Label ID="lbl_tckfrq" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
             执照有效期：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
               
                <asp:Label ID="lbl_txzgyxq" runat="server"></asp:Label>
            </td>
        </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              设备产权单位： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
             
                <asp:Label ID="lbl_sbcqdw" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
              设备维护单位： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
             
                <asp:Label ID="lbl_sbwhdw" runat="server"></asp:Label>
            </td>
        </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">

                
              设备（临时）使用许可证号：
             
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
             
                <asp:Label ID="lbl_sblssyxkz" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
             通信方式：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
               
                <asp:Label ID="lbl_txfs" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备配置：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
            
                <asp:Label ID="lbl_sbpz" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
             设备用途：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                
                <asp:Label ID="lbl_sbyt" runat="server"></asp:Label>
            </td>
        </tr>

           <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             数量： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_txsl" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
              天线类型： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_txlx" runat="server"></asp:Label>
            </td>
        </tr>
             
           <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             遥控系统（主控方）： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_ykxtzkf" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
              遥控系统（受控方）： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_ykxtskf" runat="server"></asp:Label>
            </td>
        </tr>

              <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           工作频率： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_gzpl" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
            发射功率： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_fsgl" runat="server"></asp:Label>
            </td>
        </tr>
                 <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           供电方式	： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_gdfs" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
            传输种类： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_cszl" runat="server"></asp:Label>
            </td>
        </tr>

               <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           设备安装地点： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_sbazdd" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
            持有执照人数： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_cyzzrs" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           飞行校验： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"                >
                     <asp:Label ID="lbl_txfxjy" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          飞行校验日期： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"                >             
                <asp:Label ID="lbl_txfxjyrq" runat="server"></asp:Label>
            </td>
        </tr>
               <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           开放许可到期日： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"               >     
                <asp:Label ID="lbl_kfxkdrq" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          飞行校验周期： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"     >
                <asp:Label ID="lbl_txfxjyzq" runat="server"></asp:Label>
            </td>
        </tr>
       <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
           台站坐标（北京54）经度： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">     
                <asp:Label ID="lbl_tzzbjdbj" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               台站坐标（北京54）纬度： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_tzzbwdbj" runat="server"></asp:Label>
            </td>
        </tr>

       <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          台站坐标（wgs84）经度： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_tzzbjd" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
        台站坐标（wgs84）纬度： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_tzzbwd" runat="server"></asp:Label>
            </td>
        </tr>
               <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         黄海高程： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_txhhgc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          高程备注： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_txgcbz" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               是否为无线电设备： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_sfwwxdsb" runat="server"></asp:Label>
            </td>  
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                无线电设备发射核准证编号：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_wxdsbfshzz" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border-top:2px solid #C0D9D9;border:1px solid #C0D9D9;" >
               <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
             
                  无线电设备发射核准证件 ： 
              </td>
              <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:LinkButton ID="lbtn_txwxdsbfshzzj" CommandName="down" CommandArgument='<%#Eval("txwxdsbfshzzj") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClick="lbtn_txwxdsbfshzzj_Click">

                 </asp:LinkButton>

                  <asp:Label ID="lbl_txwxdsbfshzzj" runat="server"></asp:Label>
              </td>
                  <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               支线名称：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"  >
                <asp:Label ID="lbl_txzxmc" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  保障情况： 
            </td>
            <td style="width: 32%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_txbzqk" runat="server"></asp:Label>
            </td>
        </tr>  
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         备注： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;height:50px;" class="td_sjsc"
               colspan="3"  >
                <asp:Label ID="lbl_bz" runat="server"  Multiline="true" ></asp:Label>
            </td>
                
        </tr>
    </table>
  
    <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_qx" runat="server">
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>气象设备详细信息</strong> 
            </td>
        </tr> 
            <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          设备编号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_qxsbbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
        设备种类： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_qxsbzl" runat="server"></asp:Label>
            </td>
        </tr>

     <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          所属台站名称： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_qxsstzmc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          设备状态： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_sbzt" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         投产日期： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_qxtcrq" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          竣工日期： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_qxjgrq" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备配置： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_qxsbpz" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                设备用途：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_qxsbyt" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               数量： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_qxsl" runat="server"></asp:Label>
                <br />
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                运行情况：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_qxyxqk" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               传感器鉴定证书编号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_cgqjdzsbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                传感器鉴定证书：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:LinkButton ID="lbtn_cgqjdzs" CommandName="down" CommandArgument='<%#Eval("cgqjdzs") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClick="lbtn_cgqjdzs_Click" ></asp:LinkButton>
                <asp:Label ID="lbl_cgqjdzs" runat="server"></asp:Label>
            </td>
        </tr>
                <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               传感器鉴定有效期： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_cgqjdyxq" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               支线名称：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               <asp:Label ID="lbl_qxzxmc" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_qxbz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_yb" runat="server">
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>仪表设备详细信息</strong> 
            </td>
        </tr> 
            <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          设备编号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_ybsbbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
        设备种类： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_ybsbzl" runat="server"></asp:Label>
            </td>
        </tr>

     <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          设备名称： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_ybsbmc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          设备型号： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_ybsbxh" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         检测日期： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_ybjcrq" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          检测有效期： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_ybjcyxq" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               合格证编号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_ybhgzbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                合格证上传：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_ybhgzsc" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               上传时间： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_ybscsj" runat="server"></asp:Label>
                <br />
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                购置日期：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_ybgzrq" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               价格： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_ybjg" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                数量：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               
                <asp:Label ID="lbl_ybsl" runat="server"></asp:Label>
            </td>
        </tr>
       <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               投产日期： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_yybtcrq" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               生产厂家：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               <asp:Label ID="lbl_ybsccj" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               联系人： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_yblxr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               厂家通信方式：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               <asp:Label ID="lbl_ybcjtxfs" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备状态： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_ybsbzt" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               购置部门代码：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               <asp:Label ID="lbl_ybgzbmdm" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               产品参数： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_yybcpcs" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备配置：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               <asp:Label ID="lbl_ybsbpz" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备用途： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_ybsbyt" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               所属台站名称：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               <asp:Label ID="lbl_ybsszxmc" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               所属支线： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_ybsszx" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               保障情况：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               <asp:Label ID="lbl_ybbzqk" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_ybbz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_wh" runat="server">
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>设备维护详细信息</strong> 
            </td>
        </tr> 
       <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          设备类型： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_sblx" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
        维护人： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_whr" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          维护人部门： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_whrbm" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
        维护人岗位： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_whrgw" runat="server"></asp:Label>
            </td>
        </tr>
               <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          设备状态详细信息：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_sbztxxxx" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          维护记录：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_whjl" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         场地环境和电磁环境巡视记录： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_cdhjhdchjcsjl" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
        维护状态：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                ><asp:Label ID="lbl_whzt" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         维护文件： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                ><asp:LinkButton ID="lbtn_whwj" CommandName="down" CommandArgument='<%#Eval("whwjsc") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClick="lbtn_whwj_Click"></asp:LinkButton>
             <asp:Label ID="lbl_sbwhwj" runat="server"></asp:Label>
               
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
        维护时间：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                ><asp:Label ID="lbl_whsj" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              维护备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_whbz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_gz" runat="server">
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>设备故障详细信息</strong> 
            </td>
        </tr> 
       <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          故障起始时间： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_gzqssj" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
        故障结束时间： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_gzjssj" runat="server"></asp:Label>
            </td>
        </tr>
       <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          累计时长： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_ljsc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          维修人： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_wxr" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              维护人部门： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_wxrbm" runat="server"></asp:Label>
            </td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              维修人岗位： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_wxrgw" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
        故障现象： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_gzxx" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          造成影响： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_zcyx" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              处置过程： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_czgc" runat="server"></asp:Label>
            </td>
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              故障原因分析： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_gzyyfx" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              故障板件处理结果： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_gzbjcljg" runat="server"></asp:Label>
            </td>
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              同类故障的排除方法： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_tlgzpcff" runat="server"></asp:Label>
            </td>
        </tr>
             <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >           
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"                >
        维护文件： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:LinkButton ID="lbtn_wxwj" CommandName="down" CommandArgument='<%#Eval("wxwjsc") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClick="lbtn_wxwj_Click" ></asp:LinkButton>
               <asp:Label ID="lbl_wxwj" runat="server"></asp:Label>
            </td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">       
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"                >
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              处理步骤： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"  colspan="3">
                <asp:Label ID="lbl_clbz" runat="server"></asp:Label>
            </td>
           
        </tr> 
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              建议措施： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3" >
                <asp:Label ID="lbl_jycs" runat="server"></asp:Label>
            </td>
          
        </tr> 
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              故障备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_gzbz" runat="server"></asp:Label>
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
