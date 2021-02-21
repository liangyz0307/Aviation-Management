<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DHSB_Detail.aspx.cs" Inherits="CUST.WKG.DHSB_Detail" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>导航设备设备详情</title>
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
               设备编号：  
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:Label ID="lbl_sbbh" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              设备型号 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_sbxh" runat="server"></asp:Label>
            </td>
        </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备类型：  
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_sblx" runat="server" ></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              台站名称种类 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_tzmczl_tzmc" runat="server"></asp:Label>
                <asp:Label ID="lbl_tzmczl_wz" runat="server"></asp:Label>
                <asp:Label ID="lbl_tzmczl_sblx" runat="server"></asp:Label>
            </td>
        </tr>
               <tr style="vertical-align: top;  width:100%;height:30px;   border-bottom:1px solid #C0D9D9;" > 
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               原所属机场： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_yssjc" runat="server"></asp:Label>
            </td> 
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                频率： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_pl" runat="server"></asp:Label>
                <asp:Label ID="lbl_pldw" runat="server"></asp:Label>
            </td>
           
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                呼号：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_hh" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线中心地面高程： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_txzxdmgc" runat="server"></asp:Label>
                <asp:Label ID="Label105" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%; height:30px; border-bottom:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               天线： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_tx" runat="server"></asp:Label>
                <asp:Label ID="Label106" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               校飞周期：  
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_jfzq" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               校飞到期日期：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_jfdqrq" runat="server"></asp:Label>
            </td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               投产开放时间： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_tckfsj" runat="server"></asp:Label>
            </td>
        </tr> 
     
       <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               投产校飞时间： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_tcjfsj" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                投产是否限用： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_tcxy" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >   
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                投产说明： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_tcsm" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                末次飞行校验日期： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_mcfxjyrq" runat="server"></asp:Label>
            </td>
        </tr>  
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
           
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                末次飞行校验结果： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_mcfxjyjg" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                末次飞行校验结果说明：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_mcfxjyjgsm" runat="server"></asp:Label>
            </td>
        </tr> 
          
    </table>
         <br />
    <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;" >
       
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                大地坐标（北京54）经度 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_ddzbbjjd" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 大地坐标（北京54）纬度  ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_ddzbbjwd" runat="server"></asp:Label>
            </td>
        </tr>   
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             
           
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               大地坐标（wgs84）经度： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_ddzbwgsjd" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  大地坐标（wgs84）纬度  ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_ddzbwgswd" runat="server"></asp:Label>
            </td>
        </tr>  
                <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             
           
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               数量： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
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
       <%--  <tr style="vertical-align: top;  width:100%;height:30px;  border-top:2px solid #C0D9D9;border-bottom:1px solid #C0D9D9;" >
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                 无线电设备发射核准证编号：  
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:Label ID="lbl_wxdsbfshzz" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lbl_wxdsbfshzzbh" runat="server"></asp:Label>
              </td>
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
            末次校飞报告编号：  </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:Label ID="lbl_mcjfbg" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lbl_mcjfbgbh" runat="server"></asp:Label>
              </td>
        </tr>--%>
  </table>
    <table >
         <tr style="vertical-align: top;  width:100%;height:30px;border-bottom:2px solid #C0D9D9;" >
             
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
             
                  无线电设备发射核准证件 ： <asp:Label ID="Label36" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:Label ID="lbl_Wxd" runat="server" style=" position:relative" Text="lbl_wxd"></asp:Label>
                  <asp:Button ID="btn_wxd_xz" runat="server" style=" position:relative; top: 0px; left: 71px;" ForeColor="White" BackColor="#60B1D7" Text="下载" Width="54px" OnClick="btn_wxd_xz_Click" />
                  <br />       
              </td>
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                   末次校飞报告 ： <asp:Label ID="Label7" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_mcjf" runat="server" style=" position:relative" Text="lbl_mcjf"></asp:Label>
                  <asp:Button ID="btn_mcjf_xz" runat="server" style=" position:relative; top: 0px; left: 71px;" ForeColor="White" BackColor="#60B1D7" Text="下载" Width="54px" OnClick="btn_mcjf_xz_Click" />
                    <br />       
              </td>
        </tr>
  </table>
          <table >
  </table>
    <table >
         <tr style="vertical-align: top;  width:100%;height:30px;border-bottom:2px solid #C0D9D9;" >
             
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
             
                  频率呼号文件 ： <asp:Label ID="Label29" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:Label ID="lbl_plhh" runat="server" style=" position:relative" Text="lbl_plhh"></asp:Label>
                  <asp:Button ID="btn_plhh_xz" runat="server" style=" position:relative; top: 0px; left: 71px;" ForeColor="White" BackColor="#60B1D7" Text="下载" Width="54px" OnClick="btn_plhh_xz_Click" />
              </td>
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                   设备许可证 ： <asp:Label ID="Label79" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                   <asp:Label ID="lbl_sbxkz" runat="server" style=" position:relative" Text="lbl_sbxkz"></asp:Label>
                  <asp:Button ID="bth_sbxkz_xz" runat="server" style=" position:relative; top: 0px; left: 71px; height: 22px;" ForeColor="White" BackColor="#60B1D7" Text="下载" Width="54px" OnClick="bth_sbxkz_xz_Click" />
              </td>
        </tr>
  </table>
          <table >
  </table>
    <table >
         <tr style="vertical-align: top;  width:100%;height:30px;border-bottom:2px solid #C0D9D9;" >
             
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
             
                  台址批复文件 ： <asp:Label ID="Label113" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:Label ID="lbl_tzpf" runat="server" style=" position:relative" Text="lbl_tzpf"></asp:Label>
                  <asp:Button ID="btn_tzpf_xz" runat="server" style=" position:relative; top: 0px; left: 71px;" ForeColor="White" BackColor="#60B1D7" Text="下载" Width="54px" OnClick="btn_tzpf_xz_Click" />
              </td>
              <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                  之前上传文件时间：  </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:Label ID="lbl_scwjsjc" runat="server"></asp:Label>
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              </td>
        </tr>
  </table>


          <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">

        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备厂家： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:Label ID="lbl_sbcj" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              输出功率 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_scgl" runat="server"></asp:Label>
                <%--<asp:Label ID="lbl_scgldw" runat="server"></asp:Label>--%>
            </td>
        </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备出厂编号：  
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_sbccbh" runat="server"></asp:Label>
            </td>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              覆盖范围 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_fgfw" runat="server"></asp:Label>
                <asp:Label ID="lbl_fgfwdw" runat="server"></asp:Label>
            </td>
        </tr>
               <tr style="vertical-align: top;  width:100%;height:30px;   border-bottom:1px solid #C0D9D9;" > 
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备状态：  
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_sbzt" runat="server"></asp:Label>
            </td> 
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                距跑道中心距离： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              
                <asp:Label ID="lbl_jpdzxjl" runat="server"></asp:Label>
                                  <asp:Label ID="Label11" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
           
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                跑道长度： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_pdcd" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                使用年限： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_synx" runat="server"></asp:Label>
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%; height:30px; border-bottom:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               交流供电：  
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_jlgd" runat="server"></asp:Label>
            </td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               交流供电大小：  
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_jlgddx" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               交流供电数量： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                              <asp:Label ID="lbl_jlgdsl" runat="server"></asp:Label>
            </td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               直流供电： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_zlgd" runat="server"></asp:Label>
            </td>
        </tr> 
     
       <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               直流供电大小： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_zlgddx" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                直流供电数量： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_zlgdsl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >   
            <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                  保护区范围 ： <asp:Label ID="lbl_bhqfw" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
              </td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:Label ID="lbl_bhq" runat="server" style=" position:relative" Text="lbl_bhq"></asp:Label>
                  <asp:Button ID="lbl_bhq_xz" runat="server" style=" position:relative; top: 0px; left: 71px;" ForeColor="White" BackColor="#60B1D7" Text="下载" Width="54px" OnClick="lbl_bhq_xz_Click" />
              </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                设备传输情况： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_sbcsqk" runat="server"></asp:Label>
            </td>            
        </tr>   
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
           
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              设备保管人： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_sbbgr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                设备防雷配置： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_sbflsz" runat="server"></asp:Label>
            </td>             
        </tr> 
        <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
           
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              现所属机场： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
              <asp:Label ID="lbl_xssjc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                调拨时间： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_dbsj" runat="server"></asp:Label>
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
                天线类型 ：  
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
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
                类别 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_hxsblb" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  跑道号 ： 
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_hxsbpdh" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线阵型号 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_hxsbtxzxh" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线阵类型 ： 
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_hxsbtxzlx" runat="server"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线阵子数 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_hxsbtxzzs" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线阵距跑道末端距离 ： 
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                
                <asp:Label ID="lbl_hxsbjpdmdjl" runat="server"></asp:Label>
                <asp:Label ID="Label41" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线阵距跑道入口端距离 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                
                <asp:Label ID="lbl_hxsbjpdrkjl" runat="server"></asp:Label>
                <asp:Label ID="Label45" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线阵距跑道中心垂直距离 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 

                <asp:Label ID="lbl_hxsbpdzxczjl" runat="server"></asp:Label>
                                <asp:Label ID="Label47" runat="server" Text="米" ForeColor="Black"></asp:Label>
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
                设计下滑角 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_sjxhj" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  设计入口高度 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_sjrkgd" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                天线阵型号 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_xhtxzxh" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线阵类型 ： 
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_xhtxzlx" runat="server"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                投产下天线高度 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_tcxtxgd" runat="server"></asp:Label>
                                <asp:Label ID="Label60" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  目前下天线高度 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
               
                <asp:Label ID="lbl_mqxtxgd" runat="server"></asp:Label>
                 <asp:Label ID="Label62" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 投产上天线高度：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_tcstxgd" runat="server"></asp:Label>
                  <asp:Label ID="Label65" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  目前上天线高度 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_mqstxgd" runat="server"></asp:Label>
                 <asp:Label ID="Label68" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 天线塔高度：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc"
                >
               
                <asp:Label ID="lbl_txtgd" runat="server"></asp:Label>
                 <asp:Label ID="Label54" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                  距跑道入口内撤距离 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc"> 
             
                <asp:Label ID="lbl_pdrkncjl" runat="server"></asp:Label>
                   <asp:Label ID="Label63" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
                  </tr>
                    <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 距跑道中线垂距 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_pdzcxcj" runat="server"></asp:Label>
                 <asp:Label ID="Label66" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  位于跑道中心线 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_wypdzxx" runat="server"></asp:Label>
                   <asp:Label ID="Label71" runat="server" Text="侧" ForeColor="Black"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 盲降基准高RDH ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_mjjzgrdh" runat="server"></asp:Label>
                 <asp:Label ID="Label69" runat="server" Text="米" ForeColor="Black"></asp:Label>
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
                磁偏差 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_cjycpc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  跑道号 ： 
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_cjypdh" runat="server"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                端距 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_cjydj" runat="server"></asp:Label>
                 <asp:Label ID="Label88" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  波道号 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_bdh" runat="server"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                配套设备 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_cjyptsb" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  接收频率 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_cjyjspl" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                       系统延迟 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_cjyxtyc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                脉冲间隔 ：
               </td>
               <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
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
                磁偏差 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_qxxbcpc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网高度 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_qxxbdwgd" runat="server"></asp:Label>
                  <asp:Label ID="Label94" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                监控器方位 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_qxxbjkqfw" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网直径 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
            
                <asp:Label ID="lbl_qxxbdwzj" runat="server"></asp:Label>
                    <asp:Label ID="Label98" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                地网类型 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_qxxbdwlx" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  跑道号 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_qxxbpdh" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                       端距 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                
                <asp:Label ID="lbl_qxxbdj" runat="server"></asp:Label>
                <asp:Label ID="Label100" runat="server" Text="米" ForeColor="Black"></asp:Label>
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
                磁偏差 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_wfxxbcpc" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网高度 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
               
                <asp:Label ID="lbl_wfxxbdwgd" runat="server"></asp:Label>
                 <asp:Label ID="Label102" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                监控器方位 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_wfxxbjkqfw" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  地网直径 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_wfxxbdwzj" runat="server"></asp:Label>
                <asp:Label ID="Label103" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
                  </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                地网类型 ： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_wfxxbdwlx" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  跑道号 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_wfxxbpdh" runat="server"></asp:Label>
            </td>
                  </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle; height: 19px;" class="td_sjsc">
                       端距 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle; height: 19px;" class="td_sjsc"
                >
                <asp:Label ID="lbl_wfxxbdj" runat="server"></asp:Label>
                  <asp:Label ID="Label101" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle; height: 19px;" class="td_sjsc">
               </td>
               <td style="width: 30%;  text-align: left; vertical-align: middle; height: 19px;" class="td_sjsc">
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
                跑道号 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_zdxbpdh" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  端距 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_zdxbdj" runat="server"></asp:Label>
                 <asp:Label ID="Label104" runat="server" Text="米" ForeColor="Black"></asp:Label>
            </td>
                  </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                类型选择 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_zdxblxxz" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"> </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">  </td>
                  </tr>
             
              </table>
             </div>

                  <div id = "Div1" runat ="server" class="mt-20">
         <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
                                         <tr>
                                <th scope="col" colspan="16">
                                    状态信息
                                </th>
                            </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;" >
                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                状态 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <asp:Label ID="lbl_zt" runat="server"></asp:Label>
            </td>
               <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  驳回原因 ：
               </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"> 
                <asp:Label ID="lbl_bhyy" runat="server"></asp:Label>
            </td>
                  </tr>
             
              </table>
                </div>
             <br/>  
        <br/>
                     <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="btn_fh" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White" 
                                Width="199px" OnClick="btn_fh_Click" ></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
               
	</form>
</body>
</html>
