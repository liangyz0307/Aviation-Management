<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DHSB_Edit.aspx.cs" Inherits="CUST.WKG.DHSB_Edit" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>导航设备设备编辑</title>
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
     <form id="jbxx" runat="server" class="form form-horizontal">
        <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
                                        <tr>

                                      <th scope="col" colspan="16">
                                    基本信息
                                </th>
                            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备编号：  <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:TextBox ID="tbx_sbbh" runat="server" MaxLength="14"  Height="26px"    placeholder="设备编号" ReadOnly="True"  ></asp:TextBox>
                 <asp:Label ID="lbl_sbbh" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              设备型号 ： <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_sbxh" runat="server"  Height="26px" MaxLength="10" placeholder="设备型号 "></asp:TextBox>
                <asp:Label ID="lbl_sbxh" runat="server"></asp:Label>
            </td>
        </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              台站名称种类 ： <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                 <asp:DropDownList ID="ddlt_tzmczl" runat="server" Width="230px"   Height="26px" OnSelectedIndexChanged="ddlt_sblx_change" AutoPostBack="true" ></asp:DropDownList>
                <asp:Label ID="lbl_tzmczl" runat="server"></asp:Label>
            </td>
                        </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                机场： <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:DropDownList ID="ddlt_jc" runat="server" Width="130px"   Height="26px" OnSelectedIndexChanged="ddlt_jc_change" AutoPostBack="true"></asp:DropDownList>
                <asp:Label ID="lbl_jc" runat="server"></asp:Label>
            </td>
                 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                频率： <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:TextBox ID="tbx_pl" runat="server"  Height="26px" MaxLength="10" placeholder="频率 "></asp:TextBox>
                <asp:DropDownList ID="ddlt_pldw" runat="server" Width="130px"   Height="26px" ></asp:DropDownList>
                <asp:Label ID="lbl_pl" runat="server"></asp:Label>
            </td>
        </tr>
              
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                呼号： <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:TextBox ID="tbx_hh" runat="server"   Height="26px" MaxLength="50" placeholder="呼号 "></asp:TextBox>
                <asp:Label ID="lbl_hh" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线中心地面高程： <asp:Label ID="Label25" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                  <asp:TextBox ID="tbx_txzxdmgc" runat="server"   Height="26px"  MaxLength="50" placeholder=" 天线中心地面高程"></asp:TextBox>
                <asp:Label ID="Label105" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_txzxdmgc" runat="server"></asp:Label>
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%; height:30px; border-bottom:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               天线：  <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                 <asp:TextBox ID="tbx_tx" runat="server"   Height="26px" MaxLength="10" placeholder=" 天线"></asp:TextBox>
                <asp:Label ID="Label106" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_tx" runat="server"></asp:Label>
            </td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               校飞周期：  <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_jfzq" runat="server"   Height="26px" MaxLength="10"  placeholder=" 校飞周期"></asp:TextBox>
                <asp:Label ID="lbl_jfzq" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               校飞到期日期： <asp:Label ID="Label35" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:TextBox ID="tbx_jfdqrq" runat="server"    Height="26px" MaxLength="10" placeholder="飞行校验日期 " class="Wdate"  Width="150px"    onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                <asp:Label ID="lbl_jfdqrq" runat="server"></asp:Label>
            </td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               投产开放时间： <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_tckfsj" runat="server"    Height="26px" MaxLength="10"  placeholder="投产开放时间 " class="Wdate"  Width="150px"    onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                <asp:Label ID="lbl_tckfsj" runat="server"></asp:Label>
            </td>
        </tr> 
     
       <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               投产校飞时间： <asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_tcjfsj" runat="server"    Height="26px" MaxLength="10"  placeholder="投产校飞时间 " class="Wdate"  Width="150px"    onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                <asp:Label ID="lbl_tcjfsj" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                投产是否限用： <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:DropDownList ID="ddlt_tcxy" runat="server" Width="130px"   Height="26px" ></asp:DropDownList>
                <asp:Label ID="lbl_tcxy" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >   
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                投产说明： <asp:Label ID="Label20" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:TextBox ID="tbx_tcsm" runat="server"   Height="26px" MaxLength="50"   placeholder="投产说明 "></asp:TextBox>
                <asp:Label ID="lbl_tcsm" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                末次飞行校验日期： <asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:TextBox ID="tbx_mcfxjyrq" runat="server"    Height="26px" MaxLength="10"  placeholder="末次飞行校验日期 " class="Wdate"  Width="150px"    onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                <asp:Label ID="lbl_mcfxjyrq" runat="server"></asp:Label>
            </td>
        </tr>  
        <tr style="vertical-align: top;  width:100%;border-bottom:1px solid #C0D9D9;" >
           
            <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                末次飞行校验结果： <asp:Label ID="Label22" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" >
                <asp:DropDownList ID="ddlt_mcfxjyjg" runat="server" Width="130px"   Height="26px" ></asp:DropDownList>
                <asp:Label ID="lbl_mcfxjyjg" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc" >
                末次飞行校验结果说明： <asp:Label ID="Label21" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" >
                <asp:TextBox ID="tbx_mcfxjyjgsm" runat="server"   Height="26px" MaxLength="50"  placeholder="末次飞行校验结果说明 "></asp:TextBox>
                <asp:Label ID="lbl_mcfxjyjgsm" runat="server"></asp:Label>
            </td>
        </tr> 
                    <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               原所属机场：  <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
               <asp:DropDownList ID="ddlt_yssjc" runat="server" Width="130px"   Height="26px" ></asp:DropDownList>
                <asp:Label ID="lbl_yssjc" runat="server"></asp:Label>
            </td> 
                                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
            </td> 
                          </tr> 
          
    </table>
         <br />
    <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;" >
       
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                大地坐标（北京54）经度 ： <asp:Label ID="Label31" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_ddzbbjjd" runat="server"   Height="26px" MaxLength="20" placeholder="大地坐标（北京54）经度 "></asp:TextBox>
                <asp:Label ID="lbl_ddzbbjjd" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 大地坐标（北京54）纬度  ： <asp:Label ID="Label30" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                  <asp:TextBox ID="tbx_ddzbbjwd" runat="server"   Height="26px" MaxLength="20" placeholder="大地坐标（北京54）纬度 "></asp:TextBox>
                <asp:Label ID="lbl_ddzbbjwd" runat="server"></asp:Label>
            </td>
        </tr>   
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             
           
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               大地坐标（wgs84）经度： <asp:Label ID="Label33" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_ddzbwgsjd" runat="server"   Height="26px" MaxLength="20"  placeholder="大地坐标（wgs84）经度 "></asp:TextBox>
                <asp:Label ID="lbl_ddzbwgsjd" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  大地坐标（wgs84）纬度  ： <asp:Label ID="Label32" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                  <asp:TextBox ID="tbx_ddzbwgswd" runat="server"   Height="26px" MaxLength="20" placeholder="大地坐标（wgs84）纬度 "></asp:TextBox>
                <asp:Label ID="lbl_ddzbwgswd" runat="server"></asp:Label>
            </td>
        </tr>  
                <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             
           
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               数量： <asp:Label ID="Label111" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_sl" runat="server"   Height="26px" MaxLength="10"  placeholder="数量 "></asp:TextBox>
                <asp:Label ID="lbl_sl" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
            </td>
        </tr>  
  </table>
                  <br />

  <table >
         <tr style="vertical-align: top;  width:100%;height:30px;  border-top:2px solid #C0D9D9;border-bottom:1px solid #C0D9D9;" >
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                 无线电设备发射核准证：  <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_wxdsbfshzzbh" runat="server"   Height="26px"  placeholder="无线电设备发射核准证编号 "></asp:TextBox>
                <asp:Label ID="lbl_wxdsbfshzzbh" runat="server"></asp:Label>
              </td>
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
            末次校飞报告：  <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_mcjfbgbh" runat="server"   Height="26px"  placeholder="末次校飞报告编号 "></asp:TextBox>
                <asp:Label ID="lbl_mcjfbgbh" runat="server"></asp:Label>
              </td>
        </tr>
  </table>
    <table >
         <tr style="vertical-align: top;  width:100%;height:30px;border-bottom:2px solid #C0D9D9;" >
             
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
             
                  无线电设备发射核准证件 ： <asp:Label ID="Label36" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:FileUpload ID="FileUpload_wxd" runat="server" />
                    <br />       
                    <asp:Label ID="lbl_wxdsbfshzzsc" runat="server" ></asp:Label>
              </td>
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                   末次校飞报告 ： <asp:Label ID="Label6" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:FileUpload ID="FileUpload_mcjf" runat="server" />
                    <br />       
                    <asp:Label ID="lbl_mcjfbgsc" runat="server" ></asp:Label>
              </td>
        </tr>
  </table>
          <table >
         <tr style="vertical-align: top;  width:100%;height:30px;  border-top:2px solid #C0D9D9;border-bottom:1px solid #C0D9D9;" >
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                 频率呼号文件：  <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_pvhhwnbh" runat="server"   Height="26px"  placeholder="频率呼号文件 "></asp:TextBox>
                <asp:Label ID="lbl_pvhhwnbh" runat="server"></asp:Label>
              </td>
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
            设备许可证：  <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_sbxkzbh" runat="server"   Height="26px"  placeholder="设备许可证编号 "></asp:TextBox>
                <asp:Label ID="lbl_sbxkzbh" runat="server"></asp:Label>
              </td>
        </tr>
  </table>
    <table >
         <tr style="vertical-align: top;  width:100%;height:30px;border-bottom:2px solid #C0D9D9;" >
             
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
             
                  频率呼号文件 ： <asp:Label ID="Label13" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:FileUpload ID="FileUpload_plhh" runat="server" />
                    <br />       
                    <asp:Label ID="lbl_pvhhwjsc" runat="server" ></asp:Label>
              </td>
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                   设备许可证 ： <asp:Label ID="Label26" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:FileUpload ID="FileUpload_sbxk" runat="server" />
                    <br />       
                    <asp:Label ID="lbl_sbxkzsc" runat="server" ></asp:Label>
              </td>
        </tr>
  </table>
          <table >
         <tr style="vertical-align: top;  width:100%;height:30px;  border-top:2px solid #C0D9D9;border-bottom:1px solid #C0D9D9;" >
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                 台址批复文件：  <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_tzpfwjbh" runat="server"   Height="26px"  placeholder="无线电设备发射核准证编号 "></asp:TextBox>
                <asp:Label ID="lbl_tzpfwjbh" runat="server"></asp:Label>
              </td>
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                  之前上传文件时间：  <asp:Label ID="Label115" runat="server" Text="*" ForeColor="Red"></asp:Label>
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:Label ID="lbl_scwjsjc" runat="server"></asp:Label>
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              </td>
        </tr>
  </table>
    <table >
         <tr style="vertical-align: top;  width:100%;height:30px;border-bottom:2px solid #C0D9D9;" >
             
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
             
                  台址批复文件 ： <asp:Label ID="Label110" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              <asp:FileUpload ID="FileUpload_tzpf" runat="server" />
                    <br />       
                    <asp:Label ID="lbl_tzpfwjsc" runat="server" ></asp:Label>
              </td>
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              </td>
        </tr>
  </table>

                  <br />

          <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">

        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备厂家：  <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:TextBox ID="tbx_sbcj" runat="server" MaxLength="14"  Height="26px"    placeholder="设备厂家"  ></asp:TextBox>
                 <asp:Label ID="lbl_sbcj" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              输出功率 ： <asp:Label ID="Label24" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_scgl" runat="server"  Height="26px"  placeholder="输出功率 "></asp:TextBox>
                 <asp:DropDownList ID="ddlt_scgldw" runat="server" Width="130px"   Height="26px" ></asp:DropDownList>
                <asp:Label ID="lbl_scgl" runat="server"></asp:Label>
            </td>
        </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备出厂编号：  <asp:Label ID="Label107" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_sbccbh" runat="server"  Height="26px"  placeholder="设备出厂编号 "></asp:TextBox>
                <asp:Label ID="lbl_sbccbh" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              覆盖范围 ： <asp:Label ID="Label109" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_fgfw" runat="server"  Height="26px"  placeholder="输出功率 "></asp:TextBox>
                 <asp:DropDownList ID="ddlt_fgfwdw" runat="server" Width="130px"   Height="26px" ></asp:DropDownList>
                <asp:Label ID="lbl_fgfw" runat="server"></asp:Label>
            </td>
        </tr>
               <tr style="vertical-align: top;  width:100%;height:30px;   border-bottom:1px solid #C0D9D9;" > 
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备状态：  <asp:Label ID="Label112" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
               <asp:DropDownList ID="ddlt_sbzt" runat="server" Width="130px"   Height="26px" ></asp:DropDownList>
                <asp:Label ID="lbl_sbzt" runat="server"></asp:Label>
            </td> 
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                距跑道中心距离： <asp:Label ID="Label114" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:TextBox ID="tbx_jpdzxjl" runat="server"  Height="26px"  placeholder="距跑道中心距离 "></asp:TextBox>
                                <asp:Label ID="Label11" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_jpdzxjl" runat="server"></asp:Label>
            </td>
           
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                跑道长度： <asp:Label ID="Label116" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:TextBox ID="tbx_pdcd" runat="server"   Height="26px"  placeholder="跑道长度 "></asp:TextBox>
                <asp:Label ID="lbl_pdcd" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                使用年限： <asp:Label ID="Label118" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                  <asp:TextBox ID="tbx_synx" runat="server"   Height="26px"  placeholder=" 使用年限"></asp:TextBox>
                <asp:Label ID="lbl_synx" runat="server"></asp:Label>
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%; height:30px; border-bottom:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               交流供电：  <asp:Label ID="Label121" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                 <asp:TextBox ID="tbx_jlgd" runat="server"   Height="26px"  placeholder=" 交流供电"></asp:TextBox>
                <asp:Label ID="lbl_jlgd" runat="server"></asp:Label>
            </td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               交流供电大小：  <asp:Label ID="Label124" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_jlgddx" runat="server"   Height="26px"  placeholder=" 交流供电大小"></asp:TextBox>
                <asp:Label ID="lbl_jlgddx" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               交流供电数量： <asp:Label ID="Label126" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                              <asp:TextBox ID="tbx_jlgdsl" runat="server"   Height="26px"  placeholder=" 交流供电数量"></asp:TextBox>
                              <asp:Label ID="lbl_jlgdsl" runat="server"></asp:Label>
            </td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               直流供电： <asp:Label ID="Label128" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_zlgd" runat="server"   Height="26px"  placeholder=" 直流供电"></asp:TextBox>
                <asp:Label ID="lbl_zlgd" runat="server"></asp:Label>
            </td>
        </tr> 
     
       <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               直流供电大小： <asp:Label ID="Label130" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                  <asp:TextBox ID="tbx_zlgddx" runat="server"   Height="26px"  placeholder=" 直流供电大小"></asp:TextBox>
                <asp:Label ID="lbl_zlgddx" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                直流供电数量： <asp:Label ID="Label132" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_zlgdsl" runat="server"   Height="26px"  placeholder=" 直流供电数量"></asp:TextBox>
                <asp:Label ID="lbl_zlgdsl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >   
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                保护区范围： <asp:Label ID="Label134" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_bhq" runat="server"></asp:TextBox>
                 <asp:FileUpload ID="FileUpload_bhq" runat="server" />
                    <br />       
                    <asp:Label ID="lbl_bhqfw" runat="server" ></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                设备传输情况： <asp:Label ID="Label136" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:TextBox ID="tbx_sbcsqk" runat="server"   Height="26px"  placeholder=" 设备传输情况"></asp:TextBox>
                <asp:Label ID="lbl_sbcsqk" runat="server"></asp:Label>
            </td>
        </tr>  
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
           
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                设备防雷配置： <asp:Label ID="Label138" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_sbflsz" runat="server"   Height="26px"  placeholder=" 设备防雷配置"></asp:TextBox>
                <asp:Label ID="lbl_sbflsz" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              现所属机场： <asp:Label ID="Label108" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
            <asp:DropDownList ID="ddlt_xssjc" runat="server" Width="130px"   Height="26px" ></asp:DropDownList>
              <asp:Label ID="lbl_xssjc" runat="server"></asp:Label>
            </td>
        </tr> 
                      <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
           
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                调拨时间： <asp:Label ID="Label15" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_dbsj" runat="server"   Height="26px"  placeholder=" 设备防雷配置"></asp:TextBox>
                <asp:Label ID="lbl_dbsj" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              设备保管人： <asp:Label ID="Label28" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_sbbgr" runat="server"   Height="26px"  placeholder=" 设备防雷配置"></asp:TextBox>
                <asp:Label ID="lbl_sbbgr" runat="server"></asp:Label>
            </td>
        </tr> 
          
    </table>
                      
         <div id = "wxdhsb" runat ="server" class="mt-20">
         <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
                                         <tr>
                                <th scope="col" colspan="16">
                                    卫星导航地面设备
                                </th>
                            </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线类型 ：  <asp:Label ID="Label49" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_dmsbtxlx" runat="server"   Height="26px" MaxLength="10"  placeholder="天线类型 "></asp:TextBox>
                <asp:Label ID="lbl_dmsbtxlx" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"></td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> </td>
                  </tr>

              </table>
             </div>

          <div id = "hxsb" runat ="server" class="mt-20">
         <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
                                         <tr>
                                <th scope="col" colspan="16">
                                     航向设备(仪表着陆系统LOC)
                                </th>
                            </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                类别 ： <asp:Label ID="Label34" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:DropDownList ID="ddlt_hxsblb" runat="server" Height="26px" Width="130px"></asp:DropDownList>
                <asp:Label ID="lbl_hxsblb" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  跑道号 ： <asp:Label ID="Label38" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_hxsbpdh" runat="server"   Height="26px" MaxLength="10" placeholder="跑道号 "></asp:TextBox>
                <asp:Label ID="lbl_hxsbpdh" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线阵型号 ：  <asp:Label ID="Label50" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_hxsbtxzxh" runat="server"   Height="26px" MaxLength="10" placeholder="天线阵型号 "></asp:TextBox>
                <asp:Label ID="lbl_hxsbtxzxh" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线阵类型 ： <asp:Label ID="Label42" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:DropDownList ID="ddlt_hxsbtxzlx" runat="server" Height="26px" Width="130px"></asp:DropDownList>
                <asp:Label ID="lbl_hxsbtxzlx" runat="server"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线阵子数 ： <asp:Label ID="Label40" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_hxsbtxzzs" runat="server"   Height="26px" MaxLength="10" placeholder="天线阵子数 "></asp:TextBox>
                <asp:Label ID="lbl_hxsbtxzzs" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线阵距跑道末端距离 ： <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_hxsbjpdmdjl" runat="server"   Height="26px" MaxLength="10" placeholder="天线阵距跑道末端距离 "></asp:TextBox>
                <asp:Label ID="Label41" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_hxsbjpdmdjl" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线阵距跑道入口端距离 ： <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_hxsbjpdrkjl" runat="server"   Height="26px" MaxLength="10" placeholder="天线阵距跑道入口端距离 "></asp:TextBox>
                <asp:Label ID="Label45" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_hxsbjpdrkjl" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线阵距跑道中心垂直距离 ： <asp:Label ID="Label46" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_hxsbpdzxczjl" runat="server"   Height="26px" MaxLength="10" placeholder="天线阵距跑道中心垂直距离 "></asp:TextBox>
                <asp:Label ID="Label47" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_hxsbpdzxczjl" runat="server"></asp:Label>
            </td>
                  </tr>

              </table>
             </div>

         <div id = "xhsb" runat ="server" class="mt-20">
         <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
                                         <tr>
                                <th scope="col" colspan="16">
                                     下滑设备（仪表着陆系统GP）
                                </th>
                            </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                设计下滑角 ： <asp:Label ID="Label51" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_sjxhj" runat="server"   Height="26px" MaxLength="10" placeholder="设计下滑角 "></asp:TextBox>
                <asp:Label ID="lbl_sjxhj" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  设计入口高度 ： <asp:Label ID="Label53" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_sjrkgd" runat="server"   Height="26px" MaxLength="10" placeholder="设计入口高度 "></asp:TextBox>
                <asp:Label ID="lbl_sjrkgd" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线阵型号 ：  <asp:Label ID="Label55" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_xhtxzxh" runat="server"   Height="26px" MaxLength="10" placeholder="天线阵型号 "></asp:TextBox>
                <asp:Label ID="lbl_xhtxzxh" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线阵类型 ： <asp:Label ID="Label57" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:DropDownList ID="ddlt_xhtxzlx" runat="server" Height="26px" Width="130px"></asp:DropDownList>
                <asp:Label ID="lbl_xhtxzlx" runat="server"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                投产下天线高度 ：  <asp:Label ID="Label59" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_tcxtxgd" runat="server"   Height="26px"  placeholder="投产下天线高度 "></asp:TextBox>
                <asp:Label ID="Label60" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_tcxtxgd" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  目前下天线高度 ： <asp:Label ID="Label61" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_mqxtxgd" runat="server"   Height="26px" MaxLength="10" placeholder="目前下天线高度 "></asp:TextBox>
                <asp:Label ID="Label62" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_mqxtxgd" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 投产上天线高度： <asp:Label ID="Label64" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_tcstxgd" runat="server"   Height="26px" MaxLength="10" placeholder="投产上天线高度 "></asp:TextBox>
                <asp:Label ID="Label65" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_tcstxgd" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  目前上天线高度 ： <asp:Label ID="Label67" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_mqstxgd" runat="server"   Height="26px" MaxLength="10" placeholder="目前上天线高度 "></asp:TextBox>
                <asp:Label ID="Label68" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_mqstxgd" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 天线塔高度： <asp:Label ID="Label52" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_txtgd" runat="server"   Height="26px" MaxLength="10" placeholder="天线塔高度 "></asp:TextBox>
                <asp:Label ID="Label54" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_txtgd" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                  距跑道入口内撤距离 ： <asp:Label ID="Label58" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_pdrkncjl" runat="server"   Height="26px" MaxLength="10" placeholder="距跑道入口内撤距离 "></asp:TextBox>
                <asp:Label ID="Label63" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_pdrkncjl" runat="server"></asp:Label>
            </td>
                  </tr>
                    <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 距跑道中线垂距 ： <asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_pdzcxcj" runat="server"   Height="26px" MaxLength="10" placeholder="距跑道中线垂距 "></asp:TextBox>
                <asp:Label ID="Label66" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_pdzcxcj" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  位于跑道中心线 ： <asp:Label ID="Label70" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_wypdzxx" runat="server"   Height="26px" MaxLength="10" placeholder="位于跑道中心线 "></asp:TextBox>
                <asp:Label ID="Label71" runat="server" Text="侧" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_wypdzxx" runat="server"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 盲降基准高RDH ： <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_mjjzgrdh" runat="server"   Height="26px" MaxLength="10" placeholder="盲降基准高RDH "></asp:TextBox>
                <asp:Label ID="Label69" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_mjjzgrdh" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"></td>
               <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">  </td>
                  </tr>
              </table>
             </div>

         <div id = "cjy" runat ="server" class="mt-20">
         <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
                                         <tr>
                                <th scope="col" colspan="16">
                                     测距仪(DME)
                                </th>
                            </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                磁偏差 ： <asp:Label ID="Label72" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_cjycpc" runat="server"   Height="26px" MaxLength="10" placeholder="磁偏差 "></asp:TextBox>
                <asp:Label ID="lbl_cjycpc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  跑道号 ： <asp:Label ID="Label74" runat="server" Text="*" ForeColor="White"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_cjypdh" runat="server"   Height="26px" MaxLength="10" placeholder="跑道号 "></asp:TextBox>
                <asp:Label ID="lbl_cjypdh" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                端距 ：  <asp:Label ID="Label76" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_cjydj" runat="server"   Height="26px" MaxLength="10" placeholder="端距 "></asp:TextBox>
                <asp:Label ID="Label88" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_cjydj" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  波道号 ： <asp:Label ID="Label78" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                 <asp:TextBox ID="tbx_bdh" runat="server"   Height="26px" MaxLength="10" placeholder="波道号 "></asp:TextBox>
                <asp:Label ID="lbl_bdh" runat="server"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                配套设备 ：  <asp:Label ID="Label80" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:DropDownList ID="ddlt_cjyptsb" runat="server" Height="26px" Width="130px"></asp:DropDownList>
                <asp:Label ID="lbl_cjyptsb" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  接收频率 ： <asp:Label ID="Label83" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_cjyjspl" runat="server"   Height="26px" MaxLength="10" placeholder="接收频率 "></asp:TextBox>
                <asp:Label ID="lbl_cjyjspl" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                       系统延迟 ： <asp:Label ID="Label86" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_cjyxtyc" runat="server"   Height="26px" MaxLength="10" placeholder="系统延迟 "></asp:TextBox>
                <asp:Label ID="lbl_cjyxtyc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                脉冲间隔 ： <asp:Label ID="Label73" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
               <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:TextBox ID="tbx_cjymcjg" runat="server"   Height="26px"  MaxLength="10" placeholder="脉冲间隔 "></asp:TextBox>
                <asp:Label ID="lbl_cjymcjg" runat="server"></asp:Label>
               </td>
                  </tr>
             
              </table>
             </div>

                  <div id = "qxxb" runat ="server" class="mt-20">
         <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
                                         <tr>
                                <th scope="col" colspan="16">
                                     全向信标（VO2）
                                </th>
                            </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                磁偏差 ： <asp:Label ID="Label48" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_qxxbcpc" runat="server"   Height="26px" MaxLength="10"  placeholder="磁偏差 "></asp:TextBox>
                <asp:Label ID="lbl_qxxbcpc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网高度 ： <asp:Label ID="Label77" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_qxxbdwgd" runat="server"   Height="26px" MaxLength="10" placeholder="地网高度 "></asp:TextBox>
                <asp:Label ID="Label94" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_qxxbdwgd" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                监控器方位 ：  <asp:Label ID="Label81" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_qxxbjkqfw" runat="server"   Height="26px" MaxLength="10" placeholder="监控器方位 "></asp:TextBox>
                <asp:Label ID="lbl_qxxbjkqfw" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网直径 ： <asp:Label ID="Label84" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                 <asp:TextBox ID="tbx_qxxbdwzj" runat="server"   Height="26px" MaxLength="10" placeholder="地网直径 "></asp:TextBox>
                <asp:Label ID="Label98" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_qxxbdwzj" runat="server"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                地网类型 ：  <asp:Label ID="Label87" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:DropDownList ID="ddlt_qxxbdwlx" runat="server" Height="26px" Width="130px"></asp:DropDownList>
                <asp:Label ID="lbl_qxxbdwlx" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  跑道号 ： <asp:Label ID="Label89" runat="server" Text="*" ForeColor="White"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_qxxbpdh" runat="server"   Height="26px" MaxLength="10" placeholder="跑道号 "></asp:TextBox>
                <asp:Label ID="lbl_qxxbpdh" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                       端距 ： <asp:Label ID="Label91" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_qxxbdj" runat="server"   Height="26px" MaxLength="10" placeholder="端距 "></asp:TextBox>
                <asp:Label ID="Label100" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_qxxbdj" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               </td>
               <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               </td>
                  </tr>
             
              </table>
             </div>

         <div id = "wfxxb" runat ="server" class="mt-20">
         <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
                                         <tr>
                                <th scope="col" colspan="16">
                                     无方向信标（NDB）
                                </th>
                            </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                磁偏差 ： <asp:Label ID="Label75" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_wfxxbcpc" runat="server"   Height="26px" MaxLength="10" placeholder="磁偏差 "></asp:TextBox>
                <asp:Label ID="lbl_wfxxbcpc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网高度 ： <asp:Label ID="Label85" runat="server" Text="*" ForeColor="White"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_wfxxbdwgd" runat="server"   Height="26px" MaxLength="10" placeholder="地网高度 "></asp:TextBox>
                <asp:Label ID="Label102" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_wfxxbdwgd" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                监控器方位 ：  <asp:Label ID="Label90" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_wfxxbjkqfw" runat="server"   Height="26px" MaxLength="10" placeholder="监控器方位 "></asp:TextBox>
                <asp:Label ID="lbl_wfxxbjkqfw" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网直径 ： <asp:Label ID="Label93" runat="server" Text="*" ForeColor="White"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                 <asp:TextBox ID="tbx_wfxxbdwzj" runat="server"   Height="26px" MaxLength="10" placeholder="地网直径 "></asp:TextBox>
                <asp:Label ID="Label103" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_wfxxbdwzj" runat="server"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                地网类型 ：  <asp:Label ID="Label95" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:DropDownList ID="ddlt_wfxxbdwlx" runat="server" Height="26px" Width="130px"></asp:DropDownList>
                <asp:Label ID="lbl_wfxxbdwlx" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  跑道号 ： <asp:Label ID="Label97" runat="server" Text="*" ForeColor="White"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_wfxxbpdh" runat="server"   Height="26px" MaxLength="10" placeholder="跑道号 "></asp:TextBox>
                <asp:Label ID="lbl_wfxxbpdh" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                       端距 ： <asp:Label ID="Label99" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_wfxxbdj" runat="server"   Height="26px" MaxLength="10" placeholder="端距 "></asp:TextBox>
                <asp:Label ID="Label101" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_wfxxbdj" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               </td>
               <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               </td>
                  </tr>
             
              </table>
             </div>

         <div id = "zdxb" runat ="server" class="mt-20">
         <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
                                         <tr>
                                <th scope="col" colspan="16">
                                    指点信标
                                </th>
                            </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                跑道号 ： <asp:Label ID="Label82" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_zdxbpdh" runat="server"   Height="26px" MaxLength="10" placeholder="跑道号 "></asp:TextBox>
                <asp:Label ID="lbl_zdxbpdh" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  端距 ： <asp:Label ID="Label92" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_zdxbdj" runat="server"   Height="26px" MaxLength="10" placeholder="端距 "></asp:TextBox>
                <asp:Label ID="Label104" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_zdxbdj" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                类型选择 ：  <asp:Label ID="Label96" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:DropDownList ID="ddlt_zdxblxxz" runat="server" Height="26px" Width="130px"></asp:DropDownList>
                <asp:Label ID="lbl_zdxblxxz" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"> </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">  </td>
                  </tr>
             
              </table>
             </div>

   <br />
	<div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
         <table>
                  <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">            
              <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   数据所属部门：<span class="c-red">*</span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:DropDownList ID="ddlt_sjszbm" runat="server"></asp:DropDownList>
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"><asp:Label ID="lbl_sjssbm" runat="server" ></asp:Label></td>
             
               <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                  初 审 人：<span class="c-red">*</span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:DropDownList ID="ddlt_csr" runat="server"></asp:DropDownList>
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"><asp:Label ID="lbl_csr" runat="server" ></asp:Label></td>                           
            </tr>
        
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              
              <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   终 审 人：<span class="c-red">*</span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:DropDownList ID="ddlt_zsr" runat="server"></asp:DropDownList>
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"><asp:Label ID="lbl_zsr" runat="server" ></asp:Label></td>
             

               <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
               </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      </td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"><asp:Label ID="Label79" runat="server" ></asp:Label></td>                           
            </tr>
                </table>
        <table>
            <tr>
                <td style="text-align:right"> 
                    <asp:Button ID="save" runat="server"  Text="保存" class="btn  radius"  Width="199px" OnClick="btn_save_Click" BackColor="#60B1D7" ForeColor="White" >
                    </asp:Button>
                </td>
               <td>&nbsp;</td>
               <td style="text-align:left">
                   <asp:Button ID="back" runat="server"  Text="返回" class="btn radius"   Width="199px"  BackColor="#60B1D7" ForeColor="White"  OnClick="btn_back_Click">
                   </asp:Button>
               </td>
            </tr>
        </table>
        
	</div>
        <%-- <br />
         <br />
         <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">文件列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="90" style="text-align: center; vertical-align: middle;">文件名
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">上传时间
                                    </th>

                                    </th>
                                    <th width="100">操作
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text='<%#Eval("filename") %>'></asp:Label>
                                </td>
                               <td> 
                                   <asp:Label ID="lbl_rznr" runat="server" Text='<%#Eval("scsj") %>'></asp:Label>
                               </td>
                                </td>
                                <td class="td-manage">
                                    &nbsp;
                                <asp:LinkButton ID="lbtdownload" CommandName="download"  CommandArgument='<%#Eval("sbbh") %>' ForeColor="#60B1D7" style="TEXT-DECORATION:underline"
                                    runat="server" >下载</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
         <br /> --%>

    <script type="text/javascript">
        $(document).ready(function () {
           
            //按钮判断
            $("#save").click(function () {
                //if ($("#tbx_sbbh").val().trim() == "") {
                //    $("#lbl_sbbh").text("错误：设备编号不能为空");
                //    $("#lbl_sbbh").css("color", "#ff0000");
                //    $("#tbx_sbbh").focus();
                //    flag = false;
                //}
                var flag = true;

                if ($("#tbx_tcrq").val().trim() == "") {
                    $("#lbl_tcrq").text("错误：投产日期不能为空");
                    $("#lbl_tcrq").css("color", "#ff0000");
                    $("#tbx_tcrq").focus();
                    flag = false;
                }

                //if ($("#tbx_sbbh").val().trim().length != 10) {
                //    $("#lbl_sbbh").text("错误：设备编号为十位");
                //    $("#lbl_sbbh").css("color", "#ff0000");
                //    $("#tbx_sbbh").focus();
                //    flag = false;
                //}
                if ($("#tbx_djdw").val().trim() == "") {
                    $("#lbl_djdw").text("错误：端距单位不能为空");
                    $("#lbl_djdw").css("color", "#ff0000");
                    $("#tbx_djdw").focus();
                    flag = false;
                }
                if ($("#tbx_pl").val().trim() == "") {
                    $("#lbl_pl").text("错误：设备频率不能空");
                    $("#lbl_pl").css("color", "#ff0000");
                    $("#tbx_pl").focus();
                    flag = false;

                }
                if ($("#tbx_hh").val().trim() == "") {
                    $("#lbl_hh").text("错误：呼号不能空");
                    $("#lbl_hh").css("color", "#ff0000");
                    $("#tbx_hh").focus();
                    flag = false;
                }
                if ($("#tbx_gn").val().trim() == "") {
                    $("#lbl_gn").text("错误：设备功能不能为空");
                    $("#lbl_gn").css("color", "#ff0000");
                    $("#tbx_gn").focus();
                    flag = false;
                }
                if ($("#tbx_sl").val().trim() == "") {
                    $("#lbl_sl").text("错误：设备数量不能为空");
                    $("#lbl_sl").css("color", "#ff0000");
                    $("#tbx_sl").focus();
                    flag = false;
                }
                if ($("#ddlt_sblb option:selected").val().trim() == "-1") {
                    $("#lbl_sblb").text("请选择");
                    $("#lbl_sblb").css("color", "#ff0000");
                    $("#ddlt_sblb").focus();
                    flag = false;

                }
                if ($("#ddlt_sbzl option:selected").val().trim() == "-1") {
                    $("#lbl_sbzl").text("请选择");
                    $("#lbl_sbzl").css("color", "#ff0000");
                    $("#ddlt_sbzl").focus();
                    flag = false;
                }
                if ($("#tbx_hhgc").val().trim() == "") {
                    $("#lbl_hhgc").text("错误：黄海高程不能为空");
                    $("#lbl_hhgc").css("color", "#ff0000");
                    $("#tbx_hhgc").focus();
                    flag = false;
                }
                if ($("#ddlt_sstzmc  option:selected").val().trim() == "-1") {
                    $("#lbl_sstzmc").text("请选择");
                    $("#lbl_sstzmc").css("color", "#ff0000");
                    $("#ddlt_sstzmc").focus();
                    flag = false;
                }
                if ($("#tbx_txgd").val().trim() == "") {
                    $("#lbl_txgd").text("错误：天线高度不能为空");
                    $("#lbl_txgd").css("color", "#ff0000");
                    $("#tbx_txgd").focus();
                    flag = false;
                }
                if ($("#tbx_jkqfw").val().trim() == "") {
                    $("#lbl_jkqfw").text("错误：监控器方位不能为空");
                    $("#lbl_jkqfw").css("color", "#ff0000");
                    $("#tbx_jkqfw").focus();
                    flag = false;
                }
                if ($("#tbx_cpc").val().trim() == "") {
                    $("#lbl_cpc").text("错误：磁偏差不能为空");
                    $("#lbl_cpc").css("color", "#ff0000");
                    $("#tbx_cpc").focus();
                    flag = false;
                }
                if ($("#tbx_dwzj").val().trim() == "") {
                    $("#lbl_dwzj").text("错误：地网直径不能为空");
                    $("#lbl_dwzj").css("color", "#ff0000");
                    $("#tbx_dwzj").focus();
                    flag = false;
                }
                if ($("#tbx_dwgd").val().trim() == "") {
                    $("#lbl_dwgd").text("错误：地网高度不能为空");
                    $("#lbl_dwgd").css("color", "#ff0000");
                    $("#tbx_dwgd").focus();
                    flag = false;
                }
                if ($("#ddlt_dwlx  option:selected").val().trim() == "-1") {
                    $("#lbl_dwlx").text("请选择");
                    $("#lbl_dwlx").css("color", "#ff0000");
                    $("#ddlt_dwlx").focus();
                    flag = false;
                }
                if ($("#tbx_fxjyzq").val().trim() == "") {
                    $("#lbl_fxjyzq").text("错误：飞行校验周期不能为空");
                    $("#lbl_fxjyzq").css("color", "#ff0000");
                    $("#tbx_fxjyzq").focus();
                    flag = false;
                }
                if ($("#tbx_dlwz").val().trim() == "") {
                    $("#lbl_dlwz").text("错误：地理位置不能为空");
                    $("#lbl_dlwz").css("color", "#ff0000");
                    $("#tbx_dlwz").focus();
                    flag = false;
                }
                if ($("#ddlt_fgfw  option:selected").val().trim() == "-1") {
                    $("#lbl_fgfw").text("请选择");
                    $("#lbl_fgfw").css("color", "#ff0000");
                    $("#ddlt_fgfw").focus();
                    flag = false;
                }
                if ($("#ddlt_fxjy  option:selected").val().trim() == "-1") {
                    $("#lbl_fxjy").text("请选择");
                    $("#lbl_fxjy").css("color", "#ff0000");
                    $("#ddlt_fxjy").focus();
                    flag = false;
                }
                if ($("#tbx_zzyxq").val().trim() == "") {
                    $("#lbl_zzyxq").text("错误：执照有效期不能为空");
                    $("#lbl_zzyxq").css("color", "#ff0000");
                    $("#tbx_zzyxq").focus();
                    flag = false;
                }
                if ($("#tbx_ddzbbjjd").val().trim() == "") {
                    $("#lbl_ddzbbjjd").text("错误：大地坐标（北京54）经度不能为空");
                    $("#lbl_ddzbbjjd").css("color", "#ff0000");
                    $("#tbx_ddzbbjjd").focus();
                    flag = false;
                }
                if ($("#tbx_ddzbbjwd").val().trim() == "") {
                    $("#lbl_ddzbbjwd").text("错误：大地坐标（北京54）纬度不能为空");
                    $("#lbl_ddzbbjwd").css("color", "#ff0000");
                    $("#tbx_ddzbbjwd").focus();
                    flag = false;
                }
                if ($("#tbx_ddzbwgsjd").val().trim() == "") {
                    $("#lbl_ddzbwgsjd").text("错误：大地坐标（wgs84）经度不能为空");
                    $("#lbl_ddzbwgsjd").css("color", "#ff0000");
                    $("#tbx_ddzbwgsjd").focus();
                    flag = false;
                }
                if ($("#tbx_ddzbwgswd").val().trim() == "") {
                    $("#lbl_ddzbwgswd").text("错误：大地坐标（wgs84）纬度不能为空");
                    $("#lbl_ddzbwgswd").css("color", "#ff0000");
                    $("#tbx_ddzbwgswd").focus();
                    flag = false;
                }
                if ($("#tbx_wxdsbfshzzbh").val() == "") {
                    $("#lbl_wxdsbfshzzbh").text("错误：无线电设备发射核准证编号不能空");
                    $("#lbl_wxdsbfshzzbh").css("color", "#ff0000");
                    $("#tbx_wxdsbfshzzbh").focus();
                    flag = false;
                }
                if ($("#tbx_tcrq").val().trim() == "") {
                    $("#lbl_tcrq").text("错误：投放日期不能空");
                    $("#lbl_tcrq").css("color", "#ff0000");
                    $("#tbx_tcrq").focus();
                    flag = false;
                }
                if ($("#tbx_jgrq").val().trim() == "") {
                    $("#lbl_jgrq").text("错误：竣工日期不能为空");
                    $("#lbl_jgrq").css("color", "#ff0000");
                    $("#tbx_jgrq").focus();
                    flag = false;
                }
                if ($("#tbx_fxjyrq").val().trim() == "") {
                    $("#lbl_fxjyrq").text("错误：飞行校验日期不能为空");
                    $("#lbl_fxjyrq").css("color", "#ff0000");
                    $("#tbx_fxjyrq").focus();
                    flag = false;
                }
                if ($("#tbx_kfxkdqr").val().trim() == "") {
                    $("#lbl_kfxkdqr").text("错误：开发许可到期日不能为空");
                    $("#lbl_kfxkdqr").css("color", "#ff0000");
                    $("#tbx_kfxkdqr").focus();
                    flag = false;
                }

                if ($("#ddlt_bzqk  option:selected").val().trim() == "-1") {
                    $("#lbl_bzqk").text("请选择");
                    $("#lbl_bzqk").css("color", "#ff0000");
                    $("#ddlt_bzqk").focus();
                    flag = false;
                }
                if ($("#ddlt_zxdm  option:selected").val().trim() == "-1") {
                    $("#lbl_zxdm").text("请选择");
                    $("#lbl_zxdm").css("color", "#ff0000");
                    $("#ddlt_zxdm").focus();
                    flag = false;
                }
               
                return flag;
            });

            //单个判断


            //保障情况
            $("#ddlt_bzqk").change(function () {
                if ($("#ddlt_bzqk option:selected").val() != "-1") {
                    $("#lbl_bzqk").text("正确");
                    $("#lbl_bzqk").css("color", "#00ff00");
                } else {
                    $("#lbl_bzqk").text("请选择");
                    $("#lbl_bzqk").css("color", "#ff0000");
                }
            });
            //支线代码
            $("#ddlt_zxdm").change(function () {
                if ($("#ddlt_zxdm option:selected").val() != "-1") {
                    $("#lbl_zxdm").text("正确");
                    $("#lbl_zxdm").css("color", "#00ff00");
                } else {
                    $("#lbl_zxdm").text("请选择");
                    $("#lbl_zxdm").css("color", "#ff0000");
                }
            });
                //设备编号 tbx_sbbh
                //$("#tbx_sbbh").blur(function () {
                //    if ($("#tbx_sbbh").val().trim() != "") {
                //        if ($("#tbx_sbbh").val().trim().length != "14") {
                //            $("#lbl_sbbh").text("错误:设备编号位14位");
                //            $("#lbl_sbbh").css("color", "#ff0000");
                //        }
                //        else {
                //            $("#lbl_sbbh").text("正确");
                //            $("#lbl_sbbh").css("color", "#00ff00");
                //        }
                //    }
                //    else {
                //        $("#lbl_sbbh").text("错误：设备编号不能为空");
                //        $("#lbl_sbbh").css("color", "#ff0000");
                //    }

                //});
                //设备类别 ddlt_sblb
                $("#ddlt_sblb").change(function () {
                    if ($("#ddlt_sblb option:selected").val().trim() != "-1") {
                        $("#lbl_sblb").text("正确");
                        $("#lbl_sblb").css("color", "#00ff00");
                    } else {
                        $("#lbl_sblb").text("请选择");
                        $("#lbl_sblb").css("color", "#ff0000");
                    }
                });
                //地网类型 ddlt_dwlx
                $("#ddlt_dwlx").change(function () {
                    if ($("#ddlt_dwlx option:selected").val().trim() != "-1") {
                        $("#lbl_dwlx").text("正确");
                        $("#lbl_dwlx").css("color", "#00ff00");
                    } else {
                        $("#lbl_dwlx").text("请选择");
                        $("#lbl_dwlx").css("color", "#ff0000");
                    }
                });
                //设备种类 ddlt_sbzl
                $("#ddlt_sbzl").change(function () {

                    if ($("#ddlt_sbzl option:selected").val().trim() != "-1") {
                        $("#lbl_sbzl").text("正确");
                        $("#lbl_sbzl").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_sbzl").text("请选择");
                        $("#lbl_sbzl").css("color", "#ff0000");
                    }

                });
                //设备频率 tbx_pl
                $("#tbx_pl").blur(function () {
                    if ($("#tbx_pl").val().trim() != "") {
                        $("#lbl_pl").text("正确");
                        $("#lbl_pl").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_pl").text("错误：设备频率不能空");
                        $("#lbl_pl").css("color", "#ff0000");
                    }
                });
                //呼号 tbx_hh
                $("#tbx_hh").blur(function () {
                    if ($("#tbx_hh").val().trim() != "") {
                        $("#lbl_hh").text("正确");
                        $("#lbl_hh").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_hh").text("错误：呼号不能空");
                        $("#lbl_hh").css("color", "#ff0000");
                    }
                });
                //无线电设备发射核准证编号 tbx_wxdsbfshzzbh
                $("#tbx_wxdsbfshzzbh").blur(function () {
                    if ($("#tbx_wxdsbfshzzbh").val().trim() != "") {
                        $("#lbl_wxdsbfshzzbh").text("正确");
                        $("#lbl_wxdsbfshzzbh").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_wxdsbfshzzbh").text("错误：无线电设备发射核准证编号不能空");
                        $("#lbl_wxdsbfshzzbh").css("color", "#ff0000");
                    }
                });
                //无线电设备发射核准证件 tbx_wxdsbfshzzj
                $("#tbx_wxdsbfshzzj").blur(function () {
                    if ($("#tbx_wxdsbfshzzj").val().trim() != "") {
                        $("#lbl_wxdsbfshzzj").text("正确");
                        $("#lbl_wxdsbfshzzj").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_wxdsbfshzzj").text("错误：无线电设备发射核准证件不能空");
                        $("#lbl_wxdsbfshzzj").css("color", "#ff0000");
                    }
                });

                //天线高度 tbx_txgd
                $("#tbx_txgd").blur(function () {

                    if ($("#tbx_txgd").val().trim() != "") {
                        $("#lbl_txgd").text("正确");
                        $("#lbl_txgd").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_txgd").text("错误：天线高度不能为空");
                        $("#lbl_txgd").css("color", "#ff0000");
                    }

                });
                //监控器方位 tbx_jkqfw
                $("#tbx_jkqfw").blur(function () {

                    if ($("#tbx_jkqfw").val().trim() != "") {
                        $("#lbl_jkqfw").text("正确");
                        $("#lbl_jkqfw").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_jkqfw").text("错误：监控器方位不能为空");
                        $("#lbl_jkqfw").css("color", "#ff0000");
                    }

                });
                //磁偏差 tbx_cpc
                $("#tbx_cpc").blur(function () {

                    if ($("#tbx_cpc").val().trim() != "") {
                        $("#lbl_cpc").text("正确");
                        $("#lbl_cpc").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_cpc").text("错误：磁偏差不能为空");
                        $("#lbl_cpc").css("color", "#ff0000");
                    }

                });
                //地网直径 tbx_dwzj
                $("#tbx_dwzj").blur(function () {

                    if ($("#tbx_dwzj").val().trim() != "") {
                        $("#lbl_dwzj").text("正确");
                        $("#lbl_dwzj").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_dwzj").text("错误：地网直径不能为空");
                        $("#lbl_dwzj").css("color", "#ff0000");
                    }

                });
                //地网高度 tbx_dwgd
                $("#tbx_dwgd").blur(function () {

                    if ($("#tbx_dwgd").val().trim() != "") {
                        $("#lbl_dwgd").text("正确");
                        $("#lbl_dwgd").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_dwgd").text("错误：地网高度不能为空");
                        $("#lbl_dwgd").css("color", "#ff0000");
                    }

                });
                //地网类型 tbx_dwlx
                $("#tbx_dwlx").blur(function () {

                    if ($("#tbx_dwlx").val().trim() != "") {
                        $("#lbl_dwlx").text("正确");
                        $("#lbl_dwlx").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_dwlx").text("错误：地网类型不能为空");
                        $("#lbl_dwlx").css("color", "#ff0000");
                    }

                });
                //设备功能 tbx_gn
                $("#tbx_gn").blur(function () {
                    if ($("#tbx_gn").val().trim() != "") {

                        $("#lbl_gn").text("正确");
                        $("#lbl_gn").css("color", "#00ff00");

                    } else {
                        $("#lbl_gn").text("错误：设备功能不能为空");
                        $("#lbl_gn").css("color", "#ff0000");
                    }
                });
                //设备数量 tbx_sl
                $("#tbx_sl").blur(function () {
                    if ($("#tbx_sl").val().trim() != "") {
                        $("#lbl_sl").text("正确");
                        $("#lbl_sl").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_sl").text("错误：设备数量不能为空");
                        $("#lbl_sl").css("color", "#ff0000");
                    }

                });
                //端距单位 tbx_djdw
                $("#tbx_djdw").blur(function () {

                    if ($("#tbx_djdw").val().trim() != "") {
                        $("#lbl_djdw").text("正确");
                        $("#lbl_djdw").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_djdw").text("错误：端距单位不能为空");
                        $("#lbl_djdw").css("color", "#ff0000");
                    }

                });
                //飞行校验 tbx_fxjy
                $("#ddlt_fxjy").change(function () {
                    if ($("#ddlt_fxjy").val().trim() != "-1") {
                        $("#lbl_fxjy").text("正确");
                        $("#lbl_fxjy").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_fxjy").text("请选择");
                        $("#lbl_fxjy").css("color", "#ff0000");
                    }

                });
                //飞行校验周期 tbx_fxjyzq
                $("#tbx_fxjyzq").blur(function () {
                    if ($("#tbx_fxjyzq").val().trim() != "") {
                        $("#lbl_fxjyzq").text("正确");
                        $("#lbl_fxjyzq").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_fxjyzq").text("错误：飞行校验周期不能为空");
                        $("#lbl_fxjyzq").css("color", "#ff0000");
                    }

                });
                //地理位置 tbx_dlwz
                $("#tbx_dlwz").blur(function () {

                    if ($("#tbx_dlwz").val().trim() != "") {
                        $("#lbl_dlwz").text("正确");
                        $("#lbl_dlwz").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_dlwz").text("错误：地理位置不能为空");
                        $("#lbl_dlwz").css("color", "#ff0000");
                    }

                });
                //覆盖范围 ddlt_fgfw
                $("#ddlt_fgfw").change(function () {
                    if ($("#ddlt_fgfw").val().trim() != "-1") {
                        $("#lbl_fgfw").text("正确");
                        $("#lbl_fgfw").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_fgfw").text("请选择");
                        $("#lbl_fgfw").css("color", "#ff0000");
                    }

                });
                //大地坐标（北京54）经度 tbx_ddzbbjjd
                $("#tbx_ddzbbjjd").blur(function () {
                    if ($("#tbx_ddzbbjjd").val().trim() != "") {
                        $("#lbl_ddzbbjjd").text("正确");
                        $("#lbl_ddzbbjjd").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_ddzbbjjd").text("错误：大地坐标（北京54）经度不能为空");
                        $("#lbl_ddzbbjjd").css("color", "#ff0000");
                    }

                });
                //大地坐标（北京54）纬度  tbx_ddzbbjwd
                $("#tbx_ddzbbjwd").blur(function () {
                    if ($("#tbx_ddzbbjwd").val().trim() != "") {
                        $("#lbl_ddzbbjwd").text("正确");
                        $("#lbl_ddzbbjwd").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_ddzbbjwd").text("错误：大地坐标（北京54）纬度不能为空");
                        $("#lbl_ddzbbjwd").css("color", "#ff0000");
                    }

                });
                //大地坐标（wgs84）经度  tbx_ddzbwgsjd
                $("#tbx_ddzbwgsjd").blur(function () {
                    if ($("#tbx_ddzbwgsjd").val().trim() != "") {
                        $("#lbl_ddzbwgsjd").text("正确");
                        $("#lbl_ddzbwgsjd").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_ddzbwgsjd").text("错误：大地坐标（wgs84）经度不能为空");
                        $("#lbl_ddzbwgsjd").css("color", "#ff0000");
                    }

                });
                //大地坐标（wgs84）纬度  tbx_ddzbwgswd
                $("#tbx_ddzbwgswd").blur(function () {
                    if ($("#tbx_ddzbwgswd").val().trim() != "") {
                        $("#lbl_ddzbwgswd").text("正确");
                        $("#lbl_ddzbwgswd").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_ddzbwgswd").text("错误：大地坐标（wgs84）纬度不能为空");
                        $("#lbl_ddzbwgswd").css("color", "#ff0000");
                    }

                });
                //黄海高程 tbx_hhgc
                $("#tbx_hhgc").blur(function () {
                    if ($("#tbx_hhgc").val().trim() != "") {
                        $("#lbl_hhgc").text("正确");
                        $("#lbl_hhgc").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_hhgc").text("错误：黄海高程不能为空");
                        $("#lbl_hhgc").css("color", "#ff0000");
                    }

                });
                //所属台站名称 tbx_sstzmc
                $("#ddlt_sstzmc").change(function () {
                    if ($("#ddlt_sstzmc").val().trim() != "-1") {
                        $("#lbl_sstzmc").text("正确");
                        $("#lbl_sstzmc").css("color", "#00ff00");
                    }
                    else {
                        $("#lbl_sstzmc").text("请选择");
                        $("#lbl_sstzmc").css("color", "#ff0000");
                    }

                });
            
        });
    </script>
	</form>
</body>
</html>
