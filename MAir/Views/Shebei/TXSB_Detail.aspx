<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TXSB_Detail.aspx.cs" Inherits="CUST.WKG.TXSB_Detail" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
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
     <asp:ScriptManager runat="server"></asp:ScriptManager>  
     <asp:HiddenField  ID="hf_temp" runat="server"/>
     <div id="div_jbxx" runat="server">
        <table>
       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >

            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
            数据所属部门：  <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_sjssbm" runat="server"></asp:Label>
            </td>  
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              设备类型： <asp:Label ID="Label13" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>            
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_sblx" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               位置：  <asp:Label ID="Label6" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                <asp:Label ID="lbl_wz" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              所属机场： <asp:Label ID="Label9" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_ssjc" runat="server"></asp:Label>
            </td>
        </tr>    
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              投产开放时间：  <asp:Label ID="Label10" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_tckfsj" runat="server"></asp:Label>
            </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              数量： <asp:Label ID="Label39" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_sl" runat="server"></asp:Label>
            </td>         
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             设备状态：  <asp:Label ID="Label20" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_sbzt" runat="server"></asp:Label>
            </td>
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             设备生产厂家：  <asp:Label ID="Label8" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_sbsccj" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 设备出厂编号：  <asp:Label ID="Label36" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_sbccbh" runat="server"></asp:Label>
                </td>

                 <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">设备序号可证下载：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                      <asp:Label ID="lbl_sbxkzsc" runat="server" ></asp:Label>
                   <asp:Button ID="btn_gzbg" runat="server"  class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                   Width  ="70px" OnClick="btn_sbxkzsc_down_Click"  Text="下载"  ></asp:Button> 
                    </td>       
            </tr>
           <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 用途：  <asp:Label ID="Label38" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_yt" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                交流供电：  <asp:Label ID="Label41" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_jlgd" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 交流供电大小：  <asp:Label ID="Label40" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                    <asp:Label ID="lbl_jlgddx" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                交流供电数量：  <asp:Label ID="Label43" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                    <asp:Label ID="lbl_jlgdsl" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 直流供电：  <asp:Label ID="Label42" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_zlgd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                直流供电大小：  <asp:Label ID="Label46" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_zlgddx" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 直流供电数量：  <asp:Label ID="Label45" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_zlgdsl" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">保护区范围：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                      <asp:Label ID="lbl_bhqfw" runat="server" ></asp:Label>
                   <asp:Button ID="Button1" runat="server"  class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                   Width  ="70px" OnClick="btn_bhqfw_down_Click"  Text="下载"  ></asp:Button> 
                </td>           
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 设备传输情况：  <asp:Label ID="Label47" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_sbcsqk" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                设备防雷配置：  <asp:Label ID="Label50" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_sbflpz" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 现所属机场：  <asp:Label ID="Label49" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_xssjc" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                调拨时间：  <asp:Label ID="Label52" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_dbsj" runat="server"></asp:Label>
                </td>          
            </tr>
             <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 设备保管人：  <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_sbbgr" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 设备型号：  <asp:Label ID="Label44" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_sbxh" runat="server"></asp:Label>
                </td>         
            </tr>
                <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 初审人：  <asp:Label ID="Label14" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_csr" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                终审人：  <asp:Label ID="Label51" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:Label ID="lbl_zsr" runat="server"></asp:Label>
                </td>          
            </tr>


    </table>
    </div>
    <br />
    <div id="div_sjl" style="text-align:center" runat="server">
        <strong class="icon-reorder">数据链</strong>
    </div>
    <div id="div_sjtx" style="text-align:center" runat="server">
        <strong class="icon-reorder">数据通信</strong>
    </div>
    <div id="div_yyjly" style="text-align:center" runat="server">
        <strong class="icon-reorder">语音记录仪</strong>
        <table>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   现有用户数：  <asp:Label ID="Label3" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_yyjly_xyyhs" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   语音信道数：  <asp:Label ID="Label4" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_yyjly_yyxds" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   数据信道数：  <asp:Label ID="Label5" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_yyjly_sjxds" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                </td>
            </tr>
        </table>       
    </div>
    <div id="div_wxdmzxt" style="text-align:center" runat="server">
        <strong class="icon-reorder">卫星地面站系统</strong>
        <table>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  站点类型： <asp:Label ID="Label7" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_wxdmzxt_zdlx" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线口径：  <asp:Label ID="Label11" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">                                 
                    <asp:Label ID="lbl_wxdmzxt_txkj" runat="server"></asp:Label>米
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  室外单元功率： <asp:Label ID="Label12" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_wxdmzxt_swdygl" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   发射频率：  <asp:Label ID="Label16" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_wxdmzxt_fspl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  接收频率： <asp:Label ID="Label15" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_wxdmzxt_jspl" runat="server"></asp:Label>MHZ
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   信道数：  <asp:Label ID="Label18" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_wxdmzxt_xds" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  台站坐标(北京54)经度： <asp:Label ID="Label17" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_wxdmzxt_tzzb_bj54_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   台站坐标(北京54)纬度：  <asp:Label ID="Label21" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_wxdmzxt_tzzb_bj54_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  台站坐标(wgs84)经度： <asp:Label ID="Label19" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_wxdmzxt_tzzb_wgs84_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   台站坐标(wgs84)纬度：  <asp:Label ID="Label23" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_wxdmzxt_tzzb_wgs84_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线设置地点： <asp:Label ID="Label22" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_wxdmzxt_txszdd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线基础高程：  <asp:Label ID="Label25" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_wxdmzxt_txjcgc" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  无线电台执照有效期： <asp:Label ID="Label24" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_wxdmzxt_wxdtzzyxq" runat="server"></asp:Label>
                </td>

                                 <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">上传：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                      <asp:Label ID="lbl_wxdmzxt_sc" runat="server" ></asp:Label>
                   <asp:Button ID="Button2" runat="server"  class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                   Width  ="70px" OnClick="btn_wxdmzxt_sc_down_Click"  Text="下载"  ></asp:Button> 
                    </td> 
            </tr>
        </table>
    </div>
    <div id="div_sgpdktxxt" style="text-align:center" runat="server">
        <strong class="icon-reorder">甚高频地空通信系统</strong>
        <table>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  设备配置： <asp:Label ID="Label28" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_sgpdktxxt_sbpz" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   设备信道数：  <asp:Label ID="Label30" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_sgpdktxxt_sbxds" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线类型： <asp:Label ID="Label29" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_sgpdktxxt_txlx" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   投产校飞日期：  <asp:Label ID="Label32" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_sgpdktxxt_tcjfrq" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                  发射频率： <asp:Label ID="Label31" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                     <asp:Label ID="lbl_sgpdktxxt_fspl" runat="server"></asp:Label>MHZ
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                   输出功率：  
                    <asp:Label ID="Label34" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                    <asp:Label ID="lbl_sgpdktxxt_scgl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  传输方式： <asp:Label ID="Label33" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_sgpdktxxt_csfs" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">上传：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                      <asp:Label ID="lbl_sgpdktxxt_sc" runat="server" ></asp:Label>
                   <asp:Button ID="Button3" runat="server"  class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                   Width  ="70px" OnClick="btn_sgpdktxxt_sc_down_Click"  Text="下载"  ></asp:Button> 
                    </td> 

            </tr>
            <tr style="vertical-align: top;  width:100%;border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                  台站坐标(北京54)经度： <asp:Label ID="Label48" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                     <asp:Label ID="lbl_sgpdktxxt_tzzb_bj54_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                   台站坐标(北京54)纬度：  <asp:Label ID="Label54" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">               
                    <asp:Label ID="lbl_sgpdktxxt_tzzb_bj54_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  台站坐标(wgs84)经度： <asp:Label ID="Label56" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_sgpdktxxt_tzzb_wgs84_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   台站坐标(wgs84)纬度：  <asp:Label ID="Label58" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_sgpdktxxt_tzzb_wgs84_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线基础高程： <asp:Label ID="Label53" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_sgpdktxxt_txjcgc" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线高度：  <asp:Label ID="Label57" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_sgpdktxxt_txgd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线设置地点： <asp:Label ID="Label55" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_sgpdktxxt_txszdd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   无线电台执照有效期：  <asp:Label ID="Label60" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_sgpdktxxt_wxdtzzyxq" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线生产厂家： <asp:Label ID="Label59" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_sgpdktxxt_sccj" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线型号：  <asp:Label ID="Label62" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_sgpdktxxt_txxh_lx" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <div id="div_yyjhxt_nh" style="text-align:center" runat="server">
        <strong class="icon-reorder">语音交换系统(内话)</strong>
        <table>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  系统配置： <asp:Label ID="Label61" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_yyjhxt_nh_xtpz" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   席位具体配置：  <asp:Label ID="Label64" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_yyjhxt_nh_xwjtpz" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  系统软件版本： <asp:Label ID="Label63" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_yyjhxt_nh_xtrjbb" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   接口数量：  <asp:Label ID="Label66" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_yyjhxt_nh_jksl_yx" runat="server"></asp:Label>(有线)个
                    <asp:Label ID="lbl_yyjhxt_nh_jksl_wx" runat="server"></asp:Label>(无线)个
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  MFC协议： <asp:Label ID="Label65" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_yyjhxt_nh_MFCxy" runat="server"></asp:Label>
                </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  Q-SIG协议： <asp:Label ID="Label35" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_yyjhxt_nh_QSIGxy" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  IP协议： <asp:Label ID="Label67" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_yyjhxt_nh_IPxy" runat="server"></asp:Label>
                </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                </td>
            </tr>
        </table>
    </div>
    <div id="div_zdzbxt" style="text-align:center" runat="server">
        <strong class="icon-reorder">自动转报系统</strong>

        <table>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  系统配置： <asp:Label ID="Label68" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_zdzbxt_xtpz" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   系统软件版本：  <asp:Label ID="Label70" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_zdzbxt_xtrjbb" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  在用系统： <asp:Label ID="Label69" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_zdzbxt_zyxt" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   终端用户列表：  <asp:Label ID="Label72" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_zdzbxt_zdyhlb" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_gpdktxxt" style="text-align:center" runat="server">
        <strong class="icon-reorder">高频地空通信系统</strong>
        <table>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  设备配置： <asp:Label ID="Label71" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_gpdktxxt_sbpz" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   设备信道数：  <asp:Label ID="Label74" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_gpdktxxt_sbxds" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线类型： <asp:Label ID="Label73" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_gpdktxxt_txlx" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   投产校飞日期：  <asp:Label ID="Label76" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_gpdktxxt_tcjfrq" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  发射频率： <asp:Label ID="Label75" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_gpdktxxt_fspl" runat="server"></asp:Label>MHZ
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   输出功率：  <asp:Label ID="Label78" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">      
                    <asp:Label ID="lbl_gpdktxxt_scgl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  传输方式： <asp:Label ID="Label77" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_gpdktxxt_csfs" runat="server"></asp:Label>
                </td>

                   <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">上传：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                      <asp:Label ID="lbl_gpdktxxt_sc" runat="server" ></asp:Label>
                   <asp:Button ID="Button4" runat="server"  class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                   Width  ="70px" OnClick="btn_gpdktxxt_sc_down_Click"  Text="下载"  ></asp:Button> 
                    </td> 
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  台站坐标(北京54)经度： <asp:Label ID="Label80" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_gpdktxxt_tzzb_bj54_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   台站坐标(北京54)纬度：  <asp:Label ID="Label82" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_gpdktxxt_tzzb_bj54_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  台站坐标(wgs84)经度： <asp:Label ID="Label84" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_gpdktxxt_tzzb_wgs84_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   台站坐标(wgs84)纬度：  <asp:Label ID="Label86" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_gpdktxxt_tzzb_wgs84_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线基础高程： <asp:Label ID="Label88" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_gpdktxxt_txjcgc" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线高度：  <asp:Label ID="Label90" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_gpdktxxt_txgd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线设置地点： <asp:Label ID="Label92" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_gpdktxxt_txszdd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   无线电台执照有效期：  <asp:Label ID="Label94" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_gpdktxxt_wxdtzzyxq" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线生产厂家： <asp:Label ID="Label96" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:Label ID="lbl_gpdktxxt_txsccj" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线型号：  <asp:Label ID="Label98" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:Label ID="lbl_gpdktxxt_txxh_lx" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
                  <td style="text-align:center">
                      <asp:Button ID="btn_back" runat="server" 
                Text="返回" class="btn  radius"  BackColor="#60B1D7" ForeColor="White" 
                Width="199px"    OnClick="btn_back_Click"></asp:Button>
                  </td>
            </tr>
        </table>
	</div>
	</form>

</article>
</body>
</html>
