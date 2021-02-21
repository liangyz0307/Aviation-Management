<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DHSB_Add.aspx.cs" Inherits="CUST.WKG.DHSB_Add" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>导航设备设备添加</title>
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
         
         .auto-style1 {
             width: 20%;
             height: 30px;
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
                 <asp:TextBox ID="tbx_sbbh" runat="server" MaxLength="14"  Height="26px" ReadOnly="True"  ></asp:TextBox>
                 <asp:Label ID="lbl_sbbh" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              设备型号 ： <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_sbxh" runat="server"  Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_sbxh" runat="server"></asp:Label>
            </td>
        </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              台站名称种类 ： <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                 <asp:DropDownList ID="ddlt_tzmczl" runat="server" Width="230px"   Height="26px"   OnSelectedIndexChanged="ddlt_sblx_change" AutoPostBack="true" ></asp:DropDownList>
                <asp:Label ID="lbl_tzmczl" runat="server"></asp:Label>
            </td>
             </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
                                  <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                所属机场： <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:DropDownList ID="ddlt_jc" runat="server" Width="130px"   Height="26px" OnSelectedIndexChanged="ddlt_jc_change" AutoPostBack="true" ></asp:DropDownList>
                <asp:Label ID="lbl_jc" runat="server"></asp:Label>
            </td>
                 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                频率： <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:TextBox ID="tbx_pl" runat="server"  Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:DropDownList ID="ddlt_pldw" runat="server" Width="130px"   Height="26px" ></asp:DropDownList>
                <asp:Label ID="lbl_pl" runat="server"></asp:Label>
            </td>
           
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                呼号： <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:TextBox ID="tbx_hh" runat="server"   Height="26px" MaxLength="50" ></asp:TextBox>
                <asp:Label ID="lbl_hh" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线中心地面高程： <asp:Label ID="Label25" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                  <asp:TextBox ID="tbx_txzxdmgc" runat="server"   Height="26px"  MaxLength="10" ></asp:TextBox>
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
                 <asp:TextBox ID="tbx_tx" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="Label106" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_tx" runat="server"></asp:Label>
            </td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               校飞周期：  <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_jfzq" runat="server"   Height="26px" MaxLength="10"  ></asp:TextBox>
                <asp:Label ID="lbl_jfzq" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               校飞到期日期： <asp:Label ID="Label35" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:TextBox ID="tbx_jfdqrq" runat="server"    Height="26px" MaxLength="10"  class="Wdate"  Width="150px"    onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                <asp:Label ID="lbl_jfdqrq" runat="server"></asp:Label>
            </td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               投产开放时间： <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_tckfsj" runat="server"    Height="26px" MaxLength="10"   class="Wdate"  Width="150px"    onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                <asp:Label ID="lbl_tckfsj" runat="server"></asp:Label>
            </td>
        </tr> 
     
       <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               投产校飞时间： <asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_tcjfsj" runat="server"    Height="26px" MaxLength="10"   class="Wdate"  Width="150px"    onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
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
                 <asp:TextBox ID="tbx_tcsm" runat="server"   Height="26px" MaxLength="50"   ></asp:TextBox>
                <asp:Label ID="lbl_tcsm" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                末次飞行校验日期： <asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:TextBox ID="tbx_mcfxjyrq" runat="server"    Height="26px" MaxLength="10"   class="Wdate"  Width="150px"    onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                <asp:Label ID="lbl_mcfxjyrq" runat="server"></asp:Label>
            </td>
        </tr>  
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
           
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                末次飞行校验结果： <asp:Label ID="Label22" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:DropDownList ID="ddlt_mcfxjyjg" runat="server" Width="130px"   Height="26px" ></asp:DropDownList>
                <asp:Label ID="lbl_mcfxjyjg" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                末次飞行校验结果说明： <asp:Label ID="Label21" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_mcfxjyjgsm" runat="server"   Height="26px" MaxLength="50"  ></asp:TextBox>
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
                <asp:TextBox ID="tbx_ddzbbjjd" runat="server"   Height="26px" MaxLength="20" ></asp:TextBox>
                <asp:Label ID="lbl_ddzbbjjd" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 大地坐标（北京54）纬度  ： <asp:Label ID="Label30" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                  <asp:TextBox ID="tbx_ddzbbjwd" runat="server"   Height="26px" MaxLength="20" ></asp:TextBox>
                <asp:Label ID="lbl_ddzbbjwd" runat="server"></asp:Label>
            </td>
        </tr>   
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             
           
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               大地坐标（wgs84）经度： <asp:Label ID="Label33" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_ddzbwgsjd" runat="server"   Height="26px" MaxLength="20"  ></asp:TextBox>
                <asp:Label ID="lbl_ddzbwgsjd" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  大地坐标（wgs84）纬度  ： <asp:Label ID="Label32" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                  <asp:TextBox ID="tbx_ddzbwgswd" runat="server"   Height="26px" MaxLength="20" ></asp:TextBox>
                <asp:Label ID="lbl_ddzbwgswd" runat="server"></asp:Label>
            </td>
        </tr>  
                <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             
           
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               数量： <asp:Label ID="Label111" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_sl" runat="server"   Height="26px" MaxLength="10"  ></asp:TextBox>
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
                 <asp:TextBox ID="tbx_sbcj" runat="server"   Height="26px"  MaxLength="50"   ></asp:TextBox>
                 <asp:Label ID="lbl_sbcj" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              输出功率 ： <asp:Label ID="Label24" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_scgl" runat="server"  Height="26px" MaxLength="10"  ></asp:TextBox>
                 <asp:DropDownList ID="ddlt_scgldw" runat="server" Width="130px"   Height="26px" ></asp:DropDownList>
                <asp:Label ID="lbl_scgl" runat="server"></asp:Label>
            </td>
        </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备出厂编号：  <asp:Label ID="Label107" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_sbccbh" runat="server"  Height="26px" MaxLength="50" ></asp:TextBox>
                <asp:Label ID="lbl_sbccbh" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              覆盖范围 ： <asp:Label ID="Label109" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_fgfw" runat="server"  Height="26px" MaxLength="20" ></asp:TextBox>
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
                  <asp:TextBox ID="tbx_jpdzxjl" runat="server"  Height="26px" MaxLength="10"  ></asp:TextBox>
                                <asp:Label ID="Label11" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_jpdzxjl" runat="server"></asp:Label>
            </td>
           
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                跑道长度： <asp:Label ID="Label116" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:TextBox ID="tbx_pdcd" runat="server"   Height="26px"  MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_pdcd" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                使用年限： <asp:Label ID="Label118" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                  <asp:TextBox ID="tbx_synx" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_synx" runat="server"></asp:Label>
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%; height:30px; border-bottom:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               交流供电：  <asp:Label ID="Label121" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                 <asp:TextBox ID="tbx_jlgd" runat="server"   Height="26px"  MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_jlgd" runat="server"></asp:Label>
            </td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               交流供电大小：  <asp:Label ID="Label124" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_jlgddx" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_jlgddx" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               交流供电数量： <asp:Label ID="Label126" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                              <asp:TextBox ID="tbx_jlgdsl" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                              <asp:Label ID="lbl_jlgdsl" runat="server"></asp:Label>
            </td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               直流供电： <asp:Label ID="Label128" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_zlgd" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_zlgd" runat="server"></asp:Label>
            </td>
        </tr> 
     
       <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               直流供电大小： <asp:Label ID="Label130" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                  <asp:TextBox ID="tbx_zlgddx" runat="server"   Height="26px" MaxLength="10"  ></asp:TextBox>
                <asp:Label ID="lbl_zlgddx" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                直流供电数量： <asp:Label ID="Label132" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_zlgdsl" runat="server"   Height="26px" MaxLength="10"  ></asp:TextBox>
                <asp:Label ID="lbl_zlgdsl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >   
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                保护区范围： <asp:Label ID="Label134" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                                   <asp:FileUpload ID="FileUpload_bhq" runat="server" />
                    <br />       
                    <asp:Label ID="lbl_bhqfw" runat="server" ></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                设备传输情况： <asp:Label ID="Label136" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:TextBox ID="tbx_sbcsqk" runat="server"   Height="26px" MaxLength="100" ></asp:TextBox>
                <asp:Label ID="lbl_sbcsqk" runat="server"></asp:Label>
            </td>
        </tr>  
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
           
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                设备防雷配置： <asp:Label ID="Label138" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_sbflpz" runat="server"   Height="26px" MaxLength="100" ></asp:TextBox>
                <asp:Label ID="lbl_sbflpz" runat="server"></asp:Label>
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
                <asp:TextBox ID="tbx_dbsj" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_dbsj" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              设备保管人： <asp:Label ID="Label28" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_sbbgr" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_dmsbtxlx" runat="server"   Height="26px" MaxLength="10"  ></asp:TextBox>
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
                <asp:TextBox ID="tbx_hxsbpdh" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_hxsbpdh" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线阵型号 ：  <asp:Label ID="Label50" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_hxsbtxzxh" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_hxsbtxzzs" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_hxsbtxzzs" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线阵距跑道末端距离 ： <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_hxsbjpdmdjl" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_hxsbjpdrkjl" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="Label45" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_hxsbjpdrkjl" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线阵距跑道中心垂直距离 ： <asp:Label ID="Label46" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_hxsbpdzxczjl" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_sjxhj" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_sjxhj" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  设计入口高度 ： <asp:Label ID="Label53" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_sjrkgd" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_sjrkgd" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线阵型号 ：  <asp:Label ID="Label55" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_xhtxzxh" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_tcxtxgd" runat="server"   Height="26px"  ></asp:TextBox>
                <asp:Label ID="Label60" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_tcxtxgd" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  目前下天线高度 ： <asp:Label ID="Label61" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_mqxtxgd" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_tcstxgd" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="Label65" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_tcstxgd" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  目前上天线高度 ： <asp:Label ID="Label67" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_mqstxgd" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_txtgd" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="Label54" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_txtgd" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                  距跑道入口内撤距离 ： <asp:Label ID="Label58" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_pdrkncjl" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_pdzcxcj" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="Label66" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_pdzcxcj" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  位于跑道中心线 ： <asp:Label ID="Label70" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_wypdzxx" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_mjjzgrdh" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_cjycpc" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_cjycpc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  跑道号 ： <asp:Label ID="Label74" runat="server" Text="*" ForeColor="White"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_cjypdh" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_cjypdh" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                端距 ：  <asp:Label ID="Label76" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_cjydj" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="Label88" runat="server" Text="米" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbl_cjydj" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  波道号 ： <asp:Label ID="Label78" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                 <asp:TextBox ID="tbx_bdh" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_cjyjspl" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_cjyjspl" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                       系统延迟 ： <asp:Label ID="Label86" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_cjyxtyc" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_cjyxtyc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                脉冲间隔 ： <asp:Label ID="Label73" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
               <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:TextBox ID="tbx_cjymcjg" runat="server"   Height="26px"  MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_qxxbcpc" runat="server"   Height="26px" MaxLength="10"  ></asp:TextBox>
                <asp:Label ID="lbl_qxxbcpc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网高度 ： <asp:Label ID="Label77" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_qxxbdwgd" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_qxxbjkqfw" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_qxxbjkqfw" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网直径 ： <asp:Label ID="Label84" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                 <asp:TextBox ID="tbx_qxxbdwzj" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_qxxbpdh" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_qxxbpdh" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                       端距 ： <asp:Label ID="Label91" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_qxxbdj" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_wfxxbcpc" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_wfxxbcpc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网高度 ： <asp:Label ID="Label85" runat="server" Text="*" ForeColor="White"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_wfxxbdwgd" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_wfxxbjkqfw" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_wfxxbjkqfw" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网直径 ： <asp:Label ID="Label93" runat="server" Text="*" ForeColor="White"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                 <asp:TextBox ID="tbx_wfxxbdwzj" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_wfxxbpdh" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_wfxxbpdh" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                       端距 ： <asp:Label ID="Label99" runat="server" Text="*" ForeColor="White"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:TextBox ID="tbx_wfxxbdj" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <asp:TextBox ID="tbx_zdxbpdh" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
                <asp:Label ID="lbl_zdxbpdh" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  端距 ： <asp:Label ID="Label92" runat="server" Text="*" ForeColor="Red"></asp:Label>
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:TextBox ID="tbx_zdxbdj" runat="server"   Height="26px" MaxLength="10" ></asp:TextBox>
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
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"><asp:Label ID="Label2" runat="server" ></asp:Label></td>                           
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
    <script type="text/javascript">
        $(document).ready(function () {
        });
    </script>
	</form>
</body>
</html>
