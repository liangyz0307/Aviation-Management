<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CSPZ.aspx.cs" Inherits="CUST.WKG.CSPZ" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>参数管理</title>
      <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <style type="text/css">
         .auto-style10 {
             width: 20%;
         }
         .auto-style10 {
             width: 20%;
             height: 22px;
         }
         .auto-style10 {
             width: 30%;
             height: 22px;
         }
         .auto-style10 {
             width: 12%;
             height: 35px;
         }
         .auto-style9 {
             width: 38%;
             height: 35px;
         }
         .auto-style10 {
             height: 22px;
         }
         .auto-style11 {
             width: 30%;
         }
         .auto-style10 {
             width: 20%;
             height: 35px;
         }
         .auto-style10 {
             width: 30%;
             height: 35px;
         }
         .auto-style14 {
             width: 12%;
             height: 22px;
         }
         .auto-style15 {
             width: 38%;
             height: 22px;
         }
         .auto-style10 {
             width: 20%;
             height: 23px;
         }
         .auto-style10 {
             width: 30%;
             height: 23px;
         }
         .auto-style10 {
             width: 12%;
             height: 23px;
         }
         .auto-style10 {
             width: 38%;
             height: 23px;
         }
     </style>
</head>

<body>
     <article class="page-container">
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
    <div>
         <div >
       <%--   <fieldset style="width:92%" >--%>
                <%-- <legend style="font-size: 16px; font-weight: 600;">--%><h4 style="text-align:center">==检索功能页数配置==</h4><%--</legend>--%>
                 <div>
                      <table>
                          <tr>
                              <td style="width:12%"></td>
                              <td>
                                     <h5 style="font-weight: 600;">员工管理</h5>
                                <table style="border-bottom: thin inset #CCCCCC; height: 115px; margin-bottom: 0px;">
                                      <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              员工信息：</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_ygxx" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_ygxx" runat="server" ></asp:Label>
                                          </td>
                                          <td style="text-align:right" class="auto-style10">
                                              员工资质：</td>
                                          <td style="text-align:left" class="auto-style10">
                                              
                                              <asp:TextBox ID="tbx_ygzl" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_ygzl" runat="server" ></asp:Label>
                                              
                                          </td>
                                      </tr>
                                    <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              员工履历：</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_ygll" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_ygll" runat="server" ></asp:Label>
                                          </td>
                                          <td style="text-align:right" class="auto-style10">
                                            员工惩罚：</td>
                                          <td style="text-align:left" class="auto-style9"> 
                                              <asp:TextBox ID="tbx_ygcf" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_ygcf" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                     <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              员工奖励：</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_ygjl" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_ygjl" runat="server" ></asp:Label>
                                          </td>
                                          <td style="text-align:right" class="auto-style10">
                                            员工培训：</td>
                                          <td style="text-align:left" class="auto-style9"> 
                                              <asp:TextBox ID="tbx_ygpx" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_ygpx" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                    <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              员工职称：</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_ygzc" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_ygzc" runat="server" ></asp:Label>
                                          </td>
                                          <td style="text-align:right" class="auto-style10">
                                          </td>
                                          <td style="text-align:left" class="auto-style9"> 
                                            
                                          </td>
                                      </tr>
                                    </table>

                               <%--   <h5 style="font-weight: 600;">绩效管理</h5>
                                  <table style="border-bottom-style: inset; border-bottom-width: thin; border-bottom-color: #CCCCCC">
                                      <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              员工日志：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_ygrz" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_ygrz" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              &nbsp;</td>
                                          <td style="width:38%;text-align:left">
                                              &nbsp;</td>
                                      </tr>
                                  </table>--%>
                                  <h5 style="font-weight: 600;">设备管理</h5>

                                      <table style="border-bottom-style: inset; border-bottom-width: thin; border-bottom-color: #CCCCCC">
                                      <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              通信设备：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_txsb" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_txsb" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              导航设备：</td>
                                          <td style="width:38%;text-align:left">
                                              <asp:TextBox ID="tbx_dhsb" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_dhsb" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                            <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              气象设备：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_qxsb" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_qxsb" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              台站设备：</td>
                                          <td style="width:38%;text-align:left">
                                              <asp:TextBox ID="tbx_tzsb" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_tzsb" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                            <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              监视设备：</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_jssb" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_jssb" runat="server" ></asp:Label>
                                          </td>
                                          <td style="text-align:right" class="auto-style10">
                                              设备故障：</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_sbgz" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_sbgz" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                       <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              设备维护：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_sbwh" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_sbwh" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              备件管理：</td>
                                          <td style="width:38%;text-align:left"> 
                                              <asp:TextBox ID="tbx_bjgl" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_bjgl" runat="server"></asp:Label>
                                           </td>
                                      </tr>
                                           <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              备件出库：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_bjck" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_bjck" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              备件入库：</td>
                                          <td style="width:38%;text-align:left"> 
                                              <asp:TextBox ID="tbx_bjrk" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_bjrk" runat="server"></asp:Label>
                                           </td>
                                      </tr>
                                  </table>
                                   <h5 style="font-weight: 600;">航务综合信息报送</h5>
                               <table style="border-bottom-style: inset; border-bottom-width: thin; border-bottom-color: #CCCCCC">
                                     
                                    <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              值班安排：</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_zbap" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_zbap" runat="server" ></asp:Label>
                                          </td>
                                          <td style="text-align:right" class="auto-style10">
                                              工作进展:&nbsp;</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_gzjz" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_gzjz" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                            <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              重点工作：</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_zdgz" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_zdgz" runat="server" ></asp:Label>
                                          </td>
                                          <td style="text-align:right" class="auto-style10">
                                              预算申报:&nbsp;</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_ys" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_ys" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                            <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              维修费管理：</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_wxfgl" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_wxfgl" runat="server" ></asp:Label>
                                          </td>
                                          <td style="text-align:right" class="auto-style14">
                                             </td>
                                          <td style="text-align:left" class="auto-style15">
                                             
                                          </td>
                                      </tr>                                                                           
                                  </table>
                                  <h5 style="font-weight: 600;">安全信息管理系统</h5>
                               <table style="border-bottom-style: inset; border-bottom-width: thin; border-bottom-color: #CCCCCC">
                                      <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              安全信息：</td>
                                          <td style="text-align:left" class="auto-style10">
                                              <asp:TextBox ID="tbx_aqxx" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_aqxx" runat="server" ></asp:Label>
                                          </td>
                                          <td style="text-align:right" class="auto-style10">
                                              特情处置:</td>
                                          <td style="text-align:left" class="auto-style10">
                                              
                                              <asp:TextBox ID="tbx_tqcz" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_tqcz" runat="server"></asp:Label>
                                              
                                          </td>
                                      </tr>
                                    
                                           
                                        <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              报送事故：</td>
                                          <td style="text-align:left" class="auto-style11">
                                              <asp:TextBox ID="tbx_bssg" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_bssg" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              自愿报送:&nbsp;</td>
                                          <td style="width:38%;text-align:left">
                                              <asp:TextBox ID="tbx_zybs" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_zybs" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                            
                                           
                                  </table>
                                 <%-- <h5 style="font-weight: 600;">检索管理系统</h5>

                                      <table style="border-bottom-style: inset; border-bottom-width: thin; border-bottom-color: #CCCCCC">
                                      <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              报送检索：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_bsjs" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_bsjs" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              员工检索:&nbsp;</td>
                                          <td style="width:38%;text-align:left">
                                              <asp:TextBox ID="tbx_ygjs" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_ygjs" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                            <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              设备检索：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_sbjs" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_sbjs" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              后台检索:&nbsp;</td>
                                          <td style="width:38%;text-align:left">
                                              <asp:TextBox ID="tbx_htjs" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_htjs" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                            <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              备件检索：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_bjjs" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_bjjs" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              台站检索:&nbsp;</td>
                                          <td style="width:38%;text-align:left">
                                              <asp:TextBox ID="tbx_tzjs" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_tzjs" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                       <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              资料检索：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_zljs" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_zljs" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              &nbsp;</td>
                                          <td style="width:38%;text-align:left"> 
                                              &nbsp;</td>
                                      </tr>
                                  </table>--%>
                                     
                                
                                     <h5 style="font-weight: 600;">后台管理</h5>
                                      <table style="border-bottom-style: inset; border-bottom-width: thin; border-bottom-color: #CCCCCC">
                                      <tr>
                                          <td style="width:12%;text-align:right" class="auto-style10">
                                              字典管理：</td>
                                          <td style="width:38%;text-align:left">
                                              <asp:TextBox ID="tbx_zdgl" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_zdgl" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              日志管理：</td>
                                          <td style="width:38%;text-align:left">
                                              <asp:TextBox ID="tbx_rzgl" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_rzgl" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                            <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              用户管理：</td>
                                          <td style="text-align:left">
                                              <asp:TextBox ID="tbx_yhgl" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_yhgl" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              部门管理：</td>
                                          <td style="width:38%;text-align:left">
                                              <asp:TextBox ID="tbx_bmgl" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_bmgl" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                            <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              岗位管理：</td>
                                          <td style="text-align:left">
                                              <asp:TextBox ID="tbx_gwgl" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_gwgl" runat="server" ></asp:Label>
                                          </td>
                                         <td style="width:12%;text-align:right">
                                              发布公告:&nbsp;</td>
                                          <td style="width:38%;text-align:left">
                                              <asp:TextBox ID="tbx_fbgg" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_fbgg" runat="server" ></asp:Label>
                                          </td>
                                      </tr>
                                     
                                  </table>
                                      
                                  <h5 style="font-weight: 600;">五库建设</h5>
                                <table style="border-bottom-style: inset; border-bottom-width: thin; border-bottom-color: #CCCCCC">
                                      <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              设备病例库：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_sbblk" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_sbblk" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              危险源库
                                              :&nbsp;</td>
                                          <td style="width:38%;text-align:left">
                                              
                                              <asp:TextBox ID="tbx_wxyk" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_wxyk" runat="server" ></asp:Label>
                                              
                                          </td>
                                      </tr>
                                  <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              安全问题库：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_aqwtk" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_aqwtk" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:16%;text-align:right">
                                              安全隐患库
                                              :&nbsp;</td>
                                          <td style="width:38%;text-align:left">
                                              
                                              <asp:TextBox ID="tbx_aqyhk" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_aqyhk" runat="server" ></asp:Label>
                                              
                                          </td>
                                      </tr>
                                     <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              专家信息库：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_zjxxk" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_zjxxk" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                            </td>
                                          <td style="width:38%;text-align:left">
                                              
                                             
                                              
                                          </td>
                                      </tr>

                                    </table>


                             
                                  
                                  <h5 style="font-weight: 600;">资料库</h5>
                                <table style="border-bottom-style: inset; border-bottom-width: thin; border-bottom-color: #CCCCCC">
                                      <tr>
                                          <td style="text-align:right" class="auto-style10">
                                              资料管理：</td>
                                          <td style="width:30%;text-align:left">
                                              <asp:TextBox ID="tbx_zlgl" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_zlgl" runat="server" ></asp:Label>
                                          </td>
                                          <td style="width:12%;text-align:right">
                                              案例资料
                                              :&nbsp;</td>
                                          <td style="width:38%;text-align:left">
                                              
                                              <asp:TextBox ID="tbx_zjzlgl" runat="server" MaxLength="5" style="width:130px;height:18px;"></asp:TextBox>
                                              <asp:Label ID="lbl_zjzlgl" runat="server" ></asp:Label>
                                              
                                          </td>
                                      </tr>
                                   
                                  </table>
                                  <br />
                                  <div align="center">
                                     <asp:Button ID="btn_bj" runat="server" Text="编辑"   class="btn  radius" ForeColor="White" BackColor="#60B1D7 " Width="100px" OnCommand="btn_bj_Command" />
                                     <asp:Button ID="btn_qd" runat="server" Text="保存"   class="btn  radius" ForeColor="White" BackColor="#60B1D7 " Width="100px" OnClick="btn_qd_Click" Visible="False"/>
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       <asp:Button ID="Button1" runat="server" Text="返回"   class="btn  radius" ForeColor="White" BackColor="#60B1D7" Width="100px"/>
                                       
                                       </div>
                              </td>
                              <td style="width:12%"></td>
                          </tr>
                      </table>
                
              </div>

            <%--  </fieldset>--%>
       </div>
    </div>
          </form>
         </article>
      <!--_footer 作为公共模版分离出去-->

    <script type="text/javascript" src="../lib/jquery/1.9.1/jquery.min.js"></script>

    <script type="text/javascript" src="../lib/layer/2.1/layer.js"></script>

    <script type="text/javascript" src="../lib/icheck/jquery.icheck.min.js"></script>

    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/jquery.validate.min.js"></script>

    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/validate-methods.js"></script>

    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/messages_zh.min.js"></script>

    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>

    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>

    <!--/_footer /作为公共模版分离出去-->
    <!--请在下方写此页面业务相关的脚本-->
      <script  src="../css/js/jquery.js" type="text/javascript"></script>
        <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
      <script type="text/javascript">
           $(document).ready(function() {
                $("#tbx_ygrz").blur(function() {
                    if ($("#tbx_ygrz").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_ygrz").val()) == false) {
                            $("#lbl_ygrz").text("请输入5位数字！");
                            $("#lbl_ygrz").css("color", "#ff0000");
                        } else if ($("#tbx_ygrz").val()<= 0) {
                            $("#lbl_ygrz").text("输入必须大于0");
                            $("#lbl_ygrz").css("color", "#ff0000");
                        }
                        else {
                            $("#lbl_ygrz").text("正确");
                            $("#lbl_ygrz").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_ygrz").text("不能为空！");
                        $("#lbl_ygrz").css("color", "#ff0000");
                    }
                });
           $("#tbx_jcyxxx").blur(function() {
                    if ($("#tbx_jcyxxx").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_jcyxxx").val()) == false) {
                            $("#lbl_jcyxxx").text("请输入5位数字！");
                            $("#lbl_jcyxxx").css("color", "#ff0000");
                        } else if ($("#tbx_jcyxxx").val() <= 0) {
                            $("#lbl_jcyxxx").text("输入必须大于0");
                            $("#lbl_jcyxxx").css("color", "#ff0000");
                        } else {
                            $("#lbl_jcyxxx").text("正确");
                            $("#lbl_jcyxxx").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_jcyxxx").text("不能为空！");
                        $("#lbl_jcyxxx").css("color", "#ff0000");
                    }
                });
                $("#tbx_txsb").blur(function() {
                    if ($("#tbx_txsb").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_txsb").val()) == false) {
                            $("#lbl_txsb").text("请输入5位数字！");
                            $("#lbl_txsb").css("color", "#ff0000");
                        } else if ($("#tbx_txsb").val() <= 0) {
                            $("#lbl_txsb").text("输入必须大于0");
                            $("#lbl_txsb").css("color", "#ff0000");
                        } else {
                            $("#lbl_txsb").text("正确");
                            $("#lbl_txsb").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_txsb").text("不能为空！");
                        $("#lbl_txsb").css("color", "#ff0000");
                    }
                });
                $("#tbx_dhsb").blur(function() {
                    if ($("#tbx_dhsb").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_dhsb").val()) == false) {
                            $("#lbl_dhsb").text("请输入5位数字！");
                            $("#lbl_dhsb").css("color", "#ff0000");

                        } else if ($("#tbx_dhsb").val() <= 0) {
                            $("#lbl_dhsb").text("输入必须大于0");
                            $("#lbl_dhsb").css("color", "#ff0000");
                        } else {
                            $("#lbl_dhsb").text("正确");
                            $("#lbl_dhsb").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_dhsb").text("不能为空！");
                        $("#lbl_dhsb").css("color", "#ff0000");
                    }
                });
                $("#tbx_qxsb").blur(function() {
                    if ($("#tbx_qxsb").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_qxsb").val()) == false) {
                            $("#lbl_qxsb").text("请输入5位数字！");
                            $("#lbl_qxsb").css("color", "#ff0000");
                        } else if ($("#tbx_qxsb").val() <= 0) {
                            $("#lbl_qxsb").text("输入必须大于0");
                            $("#lbl_qxsb").css("color", "#ff0000");
                        } else {
                            $("#lbl_qxsb").text("正确");
                            $("#lbl_qxsb").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_qxsb").text("不能为空！");
                        $("#lbl_qxsb").css("color", "#ff0000");
                    }
                });
                $("#tbx_qbsb").blur(function() {
                    if ($("#tbx_qbsb").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_qbsb").val()) == false) {
                            $("#lbl_qbsb").text("请输入5位数字！");
                            $("#lbl_qbsb").css("color", "#ff0000");

                        } else if ($("#tbx_qbsb").val() <= 0) {
                            $("#lbl_qbsb").text("输入必须大于0");
                            $("#lbl_qbsb").css("color", "#ff0000");
                        } else {
                            $("#lbl_qbsb").text("正确");
                            $("#lbl_qbsb").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_qbsb").text("不能为空！");
                        $("#lbl_qbsb").css("color", "#ff0000");
                    }
                });
                $("#tbx_jswh").blur(function() {
                    if ($("#tbx_jswh").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_jswh").val()) == false) {
                            $("#lbl_jswh").text("请输入5位数字！");
                            $("#lbl_jswh").css("color", "#ff0000");
                        } else if ($("#tbx_jswh").val() <= 0) {
                            $("#lbl_jswh").text("输入必须大于0");
                            $("#lbl_jswh").css("color", "#ff0000");
                        } else {
                            $("#lbl_jswh").text("正确");
                            $("#lbl_jswh").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_jswh").text("不能为空！");
                        $("#lbl_jswh").css("color", "#ff0000");
                    }
                });
           $("#tbx_sbgl").blur(function() {
                    if ($("#tbx_sbgl").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_sbgl").val()) == false) {
                            $("#lbl_sbgl").text("请输入5位数字！");
                            $("#lbl_sbgl").css("color", "#ff0000");

                        } else if ($("#tbx_sbgl").val() <= 0) {
                            $("#lbl_sbgl").text("输入必须大于0");
                            $("#lbl_sbgl").css("color", "#ff0000");
                        } else {
                            $("#lbl_sbgl").text("正确");
                            $("#lbl_sbgl").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_sbgl").text("不能为空！");
                        $("#lbl_sbgl").css("color", "#ff0000");

                    }
                });
                $("#tbx_sbwh").blur(function() {
                    if ($("#tbx_sbwh").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_sbwh").val()) == false) {
                            $("#lbl_sbwh").text("请输入5位数字！");
                            $("#lbl_sbwh").css("color", "#ff0000");

                        } else if ($("#tbx_sbwh").val() <= 0) {
                            $("#lbl_sbwh").text("输入必须大于0");
                            $("#lbl_sbwh").css("color", "#ff0000");
                        } else {
                            $("#lbl_sbwh").text("正确");
                            $("#lbl_sbwh").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_sbwh").text("不能为空！");
                        $("#lbl_sbwh").css("color", "#ff0000");

                    }
                });
                $("#tbx_zdgl").blur(function() {
                    if ($("#tbx_zdgl").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_zdgl").val()) == false) {
                            $("#lbl_zdgl").text("请输入5位数字！");
                            $("#lbl_zdgl").css("color", "#ff0000");

                        } else if ($("#tbx_zdgl").val() <= 0) {
                            $("#lbl_zdgl").text("输入必须大于0");
                            $("#lbl_zdgl").css("color", "#ff0000");
                        } else {
                            $("#lbl_zdgl").text("正确");
                            $("#lbl_zdgl").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_zdgl").text("不能为空！");
                        $("#lbl_zdgl").css("color", "#ff0000");

                    }
                });
           $("#tbx_rzgl").blur(function() {
                    if ($("#tbx_rzgl").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_rzgl").val()) == false) {
                            $("#lbl_rzgl").text("请输入5位数字！");
                            $("#lbl_rzgl").css("color", "#ff0000");

                        } else if ($("#tbx_rzgl").val()<= 0) {
                            $("#lbl_rzgl").text("输入必须大于0");
                            $("#lbl_rzgl").css("color", "#ff0000");
                        }

                        else {
                            $("#lbl_rzgl").text("正确");
                            $("#lbl_rzgl").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_rzgl").text("不能为空！");
                        $("#lbl_rzgl").css("color", "#ff0000");tbx_yhgl

                    }
                });
                $("#tbx_yhgl").blur(function() {
                    if ($("#tbx_yhgl").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_yhgl").val()) == false) {
                            $("#lbl_yhgl").text("请输入5位数字！");
                            $("#lbl_yhgl").css("color", "#ff0000");

                        } else if ($("#tbx_yhgl").val() <= 0) {
                            $("#lbl_yhgl").text("输入必须大于0");
                            $("#lbl_yhgl").css("color", "#ff0000");
                        } else {
                            $("#lbl_yhgl").text("正确");
                            $("#lbl_yhgl").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_yhgl").text("不能为空！");
                        $("#lbl_yhgl").css("color", "#ff0000");

                    }
                });
                $("#tbx_bmgl").blur(function() {
                    if ($("#tbx_bmgl").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_bmgl").val()) == false) {
                            $("#lbl_bmgl").text("请输入5位数字！");
                            $("#lbl_bmgl").css("color", "#ff0000");

                        } else if ($("#tbx_bmgl").val() <= 0) {
                            $("#lbl_bmgl").text("输入必须大于0");
                            $("#lbl_bmgl").css("color", "#ff0000");
                        } else {
                            $("#lbl_bmgl").text("正确");
                            $("#lbl_bmgl").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_bmgl").text("不能为空！");
                        $("#lbl_bmgl").css("color", "#ff0000");

                    }
                });
                $("#tbx_gwgl").blur(function() {
                    if ($("#tbx_gwgl").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_gwgl").val()) == false) {
                            $("#lbl_gwgl").text("请输入5位数字！");
                            $("#lbl_gwgl").css("color", "#ff0000");

                        } else if ($("#tbx_gwgl").val() <= 0) {
                            $("#lbl_gwgl").text("输入必须大于0");
                            $("#lbl_gwgl").css("color", "#ff0000");
                        } else {
                            $("#lbl_gwgl").text("正确");
                            $("#lbl_gwgl").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_gwgl").text("不能为空！");
                        $("#lbl_gwgl").css("color", "#ff0000");
                    }
                });
                $("#tbx_fbgg").blur(function() {
                    if ($("#tbx_fbgg").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_fbgg").val()) == false) {
                            $("#lbl_fbgg").text("请输入5位数字！");
                            $("#lbl_fbgg").css("color", "#ff0000");

                        } else if ($("#tbx_fbgg").val() <= 0) {
                            $("#lbl_fbgg").text("输入必须大于0");
                            $("#lbl_fbgg").css("color", "#ff0000");
                        } else {
                            $("#lbl_fbgg").text("正确");
                            $("#lbl_fbgg").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_fbgg").text("不能为空！");
                        $("#lbl_fbgg").css("color", "#ff0000");
                    }
                });
                $("#tbx_ygxx").blur(function() {
                    if ($("#tbx_ygxx").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_ygxx").val()) == false) {
                            $("#lbl_ygxx").text("请输入5位数字！");
                            $("#lbl_ygxx").css("color", "#ff0000");
                        } else if ($("#tbx_ygxx").val() <= 0) {
                            $("#lbl_ygxx").text("输入必须大于0");
                            $("#lbl_ygxx").css("color", "#ff0000");
                        } else {
                            $("#lbl_ygxx").text("正确");
                            $("#lbl_ygxx").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_ygxx").text("不能为空！");
                        $("#lbl_ygxx").css("color", "#ff0000");
                    }
                });
                $("#tbx_ygzl").blur(function() {
                    if ($("#tbx_ygzl").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_ygzl").val()) == false) {
                            $("#lbl_ygzl").text("请输入5位数字！");
                            $("#lbl_ygzl").css("color", "#ff0000");
                        } else if ($("#tbx_ygzl").val() <= 0) {
                            $("#lbl_ygzl").text("输入必须大于0");
                            $("#lbl_ygzl").css("color", "#ff0000");
                        } else {
                            $("#lbl_ygzl").text("正确");
                            $("#lbl_ygzl").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_ygzl").text("不能为空！");
                        $("#lbl_ygzl").css("color", "#ff0000");
                    }
                });
                $("#tbx_ygll").blur(function() {
                    if ($("#tbx_ygll").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_ygll").val()) == false) {
                            $("#lbl_ygll").text("请输入5位数字！");
                            $("#lbl_ygll").css("color", "#ff0000");
                        } else if ($("#tbx_ygll").val() <= 0) {
                            $("#lbl_ygll").text("输入必须大于0");
                            $("#lbl_ygll").css("color", "#ff0000");
                        } else {
                            $("#lbl_ygll").text("正确");
                            $("#lbl_ygll").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_ygll").text("不能为空！");
                        $("#lbl_ygll").css("color", "#ff0000");
                    }
                });
           $("#tbx_tqcz").blur(function() {
                    if ($("#tbx_tqcz").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_tqcz").val()) == false) {
                            $("#lbl_tqcz").text("错误：请输入5位数字！");
                            $("#lbl_tqcz").css("color", "#ff0000");
                        } else if ($("#tbx_tqcz").val() <= 0) {
                            $("#lbl_tqcz").text("错误：输入必须大于0");
                            $("#lbl_tqcz").css("color", "#ff0000");
                        } else {
                            $("#lbl_tqcz").text("正确");
                            $("#lbl_tqcz").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_tqcz").text("错误：不能为空！");
                        $("#lbl_tqcz").css("color", "#ff0000");
                    }
                });
             
                $("#tbx_zbap").blur(function() {
                    if ($("#tbx_zbap").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_zbap").val()) == false) {
                            $("#lbl_zbap").text("错误：请输入5位数字！");
                            $("#lbl_zbap").css("color", "#ff0000");

                        } else if ($("#tbx_zbap").val() <= 0) {
                            $("#lbl_zbap").text("错误：输入必须大于0");
                            $("#lbl_zbap").css("color", "#ff0000");
                        } else {
                            $("#lbl_zbap").text("正确");
                            $("#lbl_zbap").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_zbap").text("错误：不能为空！");
                        $("#lbl_zbap").css("color", "#ff0000");
                    }
                });
                $("#tbx_gzjz").blur(function() {
                    if ($("#tbx_gzjz").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_gzjz").val()) == false) {
                            $("#lbl_gzjz").text("错误：请输入5位数字！");
                            $("#lbl_gzjz").css("color", "#ff0000");
                        } else if ($("#tbx_gzjz").val() <= 0) {
                            $("#lbl_gzjz").text("错误：输入必须大于0");
                            $("#lbl_gzjz").css("color", "#ff0000");
                        } else {
                            $("#lbl_gzjz").text("正确");
                            $("#lbl_gzjz").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_gzjz").text("错误：不能为空！");
                        $("#lbl_gzjz").css("color", "#ff0000");
                    }
                });
                $("#tbx_zdgz").blur(function() {
                    if ($("#tbx_zdgz").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_zdgz").val()) == false) {
                            $("#lbl_zdgz").text("错误：请输入5位数字！");
                            $("#lbl_zdgz").css("color", "#ff0000");
                        } else if ($("#tbx_zdgz").val() <= 0) {
                            $("#lbl_zdgz").text("错误：输入必须大于0");
                            $("#lbl_zdgz").css("color", "#ff0000");
                        } else {
                            $("#lbl_zdgz").text("正确");
                            $("#lbl_zdgz").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_zdgz").text("错误：不能为空！");
                        $("#lbl_zdgz").css("color", "#ff0000");
                    }
                });
                $("#tbx_ys").blur(function() {
                    if ($("#tbx_ys").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_ys").val()) == false) {
                            $("#lbl_ys").text("错误：请输入5位数字！");
                            $("#lbl_ys").css("color", "#ff0000");
                        } else if ($("#tbx_ys").val() <= 0) {
                            $("#lbl_ys").text("错误：输入必须大于0");
                            $("#lbl_ys").css("color", "#ff0000");
                        } else {
                            $("#lbl_ys").text("正确");
                            $("#lbl_ys").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_ys").text("错误：不能为空！");
                        $("#lbl_ys").css("color", "#ff0000");
                    }
                });
                $("#tbx_fxyfx").blur(function() {
                    if ($("#tbx_fxyfx").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_fxyfx").val()) == false) {
                            $("#lbl_fxyfx").text("错误：请输入5位数字！");
                            $("#lbl_fxyfx").css("color", "#ff0000");
                        } else if ($("#tbx_fxyfx").val() <= 0) {
                            $("#lbl_fxyfx").text("错误：输入必须大于0");
                            $("#lbl_fxyfx").css("color", "#ff0000");
                        } else {
                            $("#lbl_fxyfx").text("正确");
                            $("#lbl_fxyfx").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_fxyfx").text("错误：不能为空！");
                        $("#lbl_fxyfx").css("color", "#ff0000");
                    }
                });
                $("#tbx_gdzc").blur(function() {
                    if ($("#tbx_gdzc").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_gdzc").val()) == false) {
                            $("#lbl_gdzc").text("错误：请输入5位数字！");
                            $("#lbl_gdzc").css("color", "#ff0000");
                        } else if ($("#tbx_gdzc").val() <= 0) {
                            $("#lbl_gdzc").text("错误：输入必须大于0");
                            $("#lbl_gdzc").css("color", "#ff0000");
                        } else {
                            $("#lbl_gdzc").text("正确");
                            $("#lbl_gdzc").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_gdzc").text("错误：不能为空！");
                        $("#lbl_gdzc").css("color", "#ff0000");
                    }
                });
                $("#tbx_bxd").blur(function() {
                    if ($("#tbx_bxd").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_bxd").val()) == false) {
                            $("#lbl_bxd").text("错误：请输入5位数字！");
                            $("#lbl_bxd").css("color", "#ff0000");
                        } else if ($("#tbx_bxd").val() <= 0) {
                            $("#lbl_bxd").text("错误：输入必须大于0");
                            $("#lbl_bxd").css("color", "#ff0000");
                        } else {
                            $("#lbl_bxd").text("正确");
                            $("#lbl_bxd").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_bxd").text("错误：不能为空！");
                        $("#lbl_bxd").css("color", "#ff0000");
                    }
                });
                  $("#tbx_zybs").blur(function() {
                    if ($("#tbx_zybs").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_zybs").val()) == false) {
                            $("#lbl_zybs").text("错误：请输入5位数字！");
                            $("#lbl_zybs").css("color", "#ff0000");
                        } else if ($("#tbx_zybs").val() <= 0) {
                            $("#lbl_zybs").text("错误：输入必须大于0");
                            $("#lbl_zybs").css("color", "#ff0000");
                        } else {
                            $("#lbl_zybs").text("正确");
                            $("#lbl_zybs").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_zybs").text("错误：不能为空！");
                        $("#lbl_zybs").css("color", "#ff0000");
                    }
                });
                $("#tbx_sg").blur(function() {
                    if ($("#tbx_sg").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_sg").val()) == false) {
                            $("#lbl_sg").text("错误：请输入5位数字！");
                            $("#lbl_sg").css("color", "#ff0000");
                        } else if ($("#tbx_sg").val() <= 0) {
                            $("#lbl_sg").text("错误：输入必须大于0");
                            $("#lbl_sg").css("color", "#ff0000");
                        } else {
                            $("#lbl_sg").text("正确");
                            $("#lbl_sg").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_sg").text("错误：不能为空！");
                        $("#lbl_sg").css("color", "#ff0000");
                    }
                });
                $("#tbx_dzqm").blur(function() {
                    if ($("#tbx_dzqm").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_dzqm").val()) == false) {
                            $("#lbl_dzqm").text("错误：请输入5位数字！");
                            $("#lbl_dzqm").css("color", "#ff0000");
                        } else if ($("#tbx_dzqm").val() <= 0) {
                            $("#lbl_dzqm").text("错误：输入必须大于0");
                            $("#lbl_dzqm").css("color", "#ff0000");
                        } else {
                            $("#lbl_dzqm").text("正确");
                            $("#lbl_dzqm").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_dzqm").text("错误：不能为空！");
                        $("#lbl_dzqm").css("color", "#ff0000");
                    }
                });
           $("#tbx_jssb").blur(function() {
                    if ($("#tbx_jssb").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_jssb").val()) == false) {
                            $("#lbl_jssb").text("错误：请输入5位数字！");
                            $("#lbl_jssb").css("color", "#ff0000");
                        } else if ($("#tbx_jssb").val() <= 0) {
                            $("#lbl_jssb").text("错误：输入必须大于0");
                            $("#lbl_jssb").css("color", "#ff0000");
                        } else {
                            $("#lbl_jssb").text("正确");
                            $("#lbl_jssb").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_jssb").text("错误：不能为空！");
                        $("#lbl_jssb").css("color", "#ff0000");
                    }
                });
                $("#tbx_bsjs").blur(function() {
                    if ($("#tbx_bsjs").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_bsjs").val()) == false) {
                            $("#lbl_bsjs").text("错误：请输入5位数字！");
                            $("#lbl_bsjs").css("color", "#ff0000");
                        } else if ($("#tbx_bsjs").val() <= 0) {
                            $("#lbl_bsjs").text("错误：输入必须大于0");
                            $("#lbl_bsjs").css("color", "#ff0000");
                        } else {
                            $("#lbl_bsjs").text("正确");
                            $("#lbl_bsjs").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_bsjs").text("错误：不能为空！");
                        $("#lbl_bsjs").css("color", "#ff0000");
                    }
                });
                $("#tbx_ygjs").blur(function() {
                    if ($("#tbx_ygjs").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_ygjs").val()) == false) {
                            $("#lbl_ygjs").text("错误：请输入5位数字！");
                            $("#lbl_ygjs").css("color", "#ff0000");
                        } else if ($("#tbx_ygjs").val() <= 0) {
                            $("#lbl_ygjs").text("错误：输入必须大于0");
                            $("#lbl_ygjs").css("color", "#ff0000");
                        } else {
                            $("#lbl_ygjs").text("正确");
                            $("#lbl_ygjs").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_ygjs").text("错误：不能为空！");
                        $("#lbl_ygjs").css("color", "#ff0000");
                    }
                });
                $("#tbx_sbjs").blur(function() {
                    if ($("#tbx_sbjs").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_sbjs").val()) == false) {
                            $("#lbl_sbjs").text("错误：请输入5位数字！");
                            $("#lbl_sbjs").css("color", "#ff0000");

                        } else if ($("#tbx_sbjs").val() <= 0) {
                            $("#lbl_sbjs").text("错误：输入必须大于0");
                            $("#lbl_sbjs").css("color", "#ff0000");
                        } else {
                            $("#lbl_sbjs").text("正确");
                            $("#lbl_sbjs").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_sbjs").text("错误：不能为空！");
                        $("#lbl_sbjs").css("color", "#ff0000");
                    }
                });
                $("#tbx_htjs").blur(function() {
                    if ($("#tbx_htjs").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_htjs").val()) == false) {
                            $("#lbl_htjs").text("错误：请输入5位数字！");
                            $("#lbl_htjs").css("color", "#ff0000");
                        } else if ($("#tbx_htjs").val() <= 0) {
                            $("#lbl_htjs").text("错误：输入必须大于0");
                            $("#lbl_htjs").css("color", "#ff0000");
                        } else {
                            $("#lbl_htjs").text("正确");
                            $("#lbl_htjs").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_htjs").text("错误：不能为空！");
                        $("#lbl_htjs").css("color", "#ff0000");
                    }
                });
                $("#tbx_bjjs").blur(function() {
                    if ($("#tbx_bjjs").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_bjjs").val()) == false) {
                            $("#lbl_bjjs").text("错误：请输入5位数字！");
                            $("#lbl_bjjs").css("color", "#ff0000");
                        } else if ($("#tbx_bjjs").val() <= 0) {
                            $("#lbl_bjjs").text("错误：输入必须大于0");
                            $("#lbl_bjjs").css("color", "#ff0000");
                        } else {
                            $("#lbl_bjjs").text("正确");
                            $("#lbl_bjjs").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_bjjs").text("错误：不能为空！");
                        $("#lbl_bjjs").css("color", "#ff0000");
                    }
                });
                $("#tbx_tzjs").blur(function() {
                    if ($("#tbx_tzjs").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_tzjs").val()) == false) {
                            $("#lbl_tzjs").text("错误：请输入5位数字！");
                            $("#lbl_tzjs").css("color", "#ff0000");
                        } else if ($("#tbx_tzjs").val() <= 0) {
                            $("#lbl_tzjs").text("错误：输入必须大于0");
                            $("#lbl_tzjs").css("color", "#ff0000");
                        } else {
                            $("#lbl_tzjs").text("正确");
                            $("#lbl_tzjs").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_tzjs").text("错误：不能为空！");
                        $("#lbl_tzjs").css("color", "#ff0000");
                    }
                });
                   $("#tbx_zljs").blur(function() {
                    if ($("#tbx_zljs").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_zljs").val()) == false) {
                            $("#lbl_zljs").text("错误：请输入5位数字！");
                            $("#lbl_zljs").css("color", "#ff0000");
                        } else if ($("#tbx_zljs").val() <= 0) {
                            $("#lbl_zljs").text("错误：输入必须大于0");
                            $("#lbl_zljs").css("color", "#ff0000");
                        } else {
                            $("#lbl_zljs").text("正确");
                            $("#lbl_zljs").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_zljs").text("错误：不能为空！");
                        $("#lbl_zljs").css("color", "#ff0000");
                    }
                });
                $("#tbx_zlgl").blur(function() {
                    if ($("#tbx_zlgl").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_zlgl").val()) == false) {
                            $("#lbl_zlgl").text("错误：请输入5位数字！");
                            $("#lbl_zlgl").css("color", "#ff0000");
                        } else if ($("#tbx_zlgl").val() <= 0) {
                            $("#lbl_zlgl").text("错误：输入必须大于0");
                            $("#lbl_zlgl").css("color", "#ff0000");
                        } else {
                            $("#lbl_zlgl").text("正确");
                            $("#lbl_zlgl").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_zlgl").text("错误：不能为空！");
                        $("#lbl_zlgl").css("color", "#ff0000");
                    }
                });
                $("#tbx_zjzlgl").blur(function() {
                    if ($("#tbx_zjzlgl").val() != "") {
                        var reg = /^[0-9]*$/;
                        if (reg.test($("#tbx_zjzlgl").val()) == false) {
                            $("#lbl_zjzlgl").text("错误：请输入5位数字！");
                            $("#lbl_zjzlgl").css("color", "#ff0000");

                        } else if ($("#tbx_zjzlgl").val() <= 0) {
                            $("#lbl_zjzlgl").text("错误：输入必须大于0");
                            $("#lbl_zjzlgl").css("color", "#ff0000");
                        } else {
                            $("#lbl_zjzlgl").text("正确");
                            $("#lbl_zjzlgl").css("color", "#00ff00");
                        }
                    } else {
                    $("#lbl_zjzlgl").text("错误：不能为空！");
                        $("#lbl_zjzlgl").css("color", "#ff0000");

                    }
                });
           });
       </script>


  
</body>
 
</html>
