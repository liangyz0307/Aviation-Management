<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSSB_Add.aspx.cs" Inherits="CUST.WKG.JSSB_Add" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
      <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
      #login
     {  
        display:none; 
        border:1em solid #e4e5e6;  
        height:202px;  
        width:326px;  
        position:absolute;/*让节点脱离文档流,我的理解就是,从页面上浮出来,不再按照文档其它内容布局*/  
        top:5%;/*节点脱离了文档流,如果设置位置需要用top和left,right,bottom定位*/  
        left:65%;  
        z-index:2;/*个人理解为层级关系,由于这个节点要在顶部显示,所以这个值比其余节点的都大*/  
        background: white;  
    }   
   
    #over
    {  
        width: 100%;  
        height: 100%;  
        opacity:0.5;/*设置背景色透明度,1为完全不透明,IE需要使用filter:alpha(opacity=80);*/  
        filter:alpha(opacity=80);  
        display: none;  
        position:absolute;  
        top:0;  
        left:0;  
        z-index:1;  
        background: silver;  
    }
          .auto-style1 {
              height: 180px;
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
                 设备编号：  <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_sbbh" runat="server" Height="25px" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="lbl_sbbh" runat="server"></asp:Label>
                </td>
                                       <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             所属机场：  <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:DropDownList ID="ddlt_jc" runat="server" Height="25px" OnSelectedIndexChanged="ddlt_jc_change" AutoPostBack="true"></asp:DropDownList>
                <asp:Label ID="lbl_jc" runat="server"></asp:Label>
            </td>
                </tr>
              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              台站名称种类 ： <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                 <asp:DropDownList ID="ddlt_tzmczl" runat="server" Width="230px"   Height="26px" OnSelectedIndexChanged="ddlt_sblx_change" AutoPostBack="true"></asp:DropDownList>
                <asp:Label ID="lbl_tzmczl" runat="server"></asp:Label>
            </td>
        </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              所属支线： <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:DropDownList ID="ddlt_sszx" runat="server" Height="25px"></asp:DropDownList>
                 <asp:Label ID="lbl_sszx" runat="server"></asp:Label>
            </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                电台执照到期时间：  <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_dtzzdqsj" runat="server" class="input-text" style="width:200px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox>
                    <asp:Label ID="lbl_dtzzdqsj" runat="server"></asp:Label>
                </td>             
        </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             设备状态：  <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:DropDownList ID="ddlt_sbzt" runat="server" Height="25px"></asp:DropDownList>
                <asp:Label ID="lbl_sbzt" runat="server"></asp:Label>
            </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             设备生产厂家：  <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:TextBox ID="tbx_sbsccj" runat="server" Height="25px"></asp:TextBox>
                <asp:Label ID="lbl_sbsccj" runat="server"></asp:Label>
            </td>
        </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 设备出厂编号：  <asp:Label ID="Label36" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_sbccbh" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_sbccbh" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   上传：  <asp:Label ID="Label26" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:FileUpload ID="tbx_sc" runat="server" />
                    <asp:Label ID="lbl_sc" runat="server" ></asp:Label>
                </td>         
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                数据所属部门：  <asp:Label ID="Label38" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:DropDownList ID="ddlt_sjssbm" runat="server" Height="25px"></asp:DropDownList>
                <asp:Label ID="lbl_sjssbm" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                所属台站：  <asp:Label ID="Label41" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_sstz" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_sstz" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle; height: 31px;" class="td_sjsc">
                 设备型号：  <asp:Label ID="Label40" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle; height: 31px;" class="td_sjsc" >
                    <asp:TextBox ID="tbx_sbxh" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_sbxh" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle; height: 31px;" class="td_sjsc"> 
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle; height: 31px;" class="td_sjsc" >
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 竣工日期：  <asp:Label ID="Label42" runat="server" Text="*" ForeColor="Red"   ></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_jgrq" runat="server" Height="25px" class="input-text" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                    <asp:Label ID="lbl_jgrq" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 投产校验日期：  <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"  ></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_tcjyrq" runat="server" Height="25px" class="input-text" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                    <asp:Label ID="lbl_tcjyrq" runat="server"></asp:Label>
                </td>        
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 投产开放或备案日期：  <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red" ></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_tckfhbarq" runat="server" Height="25px" class="input-text" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox>
                    <asp:Label ID="lbl_tckfhbarq" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   主要技术参数填写：  <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_zyjscstx" runat="server" Height="25px" />
                    <asp:Label ID="lbl_zyjscstx" runat="server" ></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 供电方式：  <asp:Label ID="Label47" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_gdfs" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_gdfs" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                传输方式：  <asp:Label ID="Label50" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_csfs" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_csfs" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                大地坐标(北京54)经度：  <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_ddzb_bj54_jd" runat="server" class="input-text" style="width:200px"></asp:TextBox>
                    <asp:Label ID="lbl_ddzb_bj54_jd" runat="server"></asp:Label>
                </td> 
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                大地坐标(北京54)纬度：  <asp:Label ID="Label52" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_ddzb_bj54_wd" runat="server" class="input-text" style="width:200px"></asp:TextBox>
                    <asp:Label ID="lbl_ddzb_bj54_wd" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                大地坐标（wgs84）经度：  <asp:Label ID="Label24" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_ddzb_wgs84_jd" runat="server" class="input-text" style="width:200px"></asp:TextBox>
                    <asp:Label ID="lbl_ddzb_wgs84_jd" runat="server"></asp:Label>
                </td> 
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                大地坐标（wgs84）纬度：  <asp:Label ID="Label46" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_ddzb_wgs84_wd" runat="server" class="input-text" style="width:200px"></asp:TextBox>
                    <asp:Label ID="lbl_ddzb_wgs84_wd" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 初审人：  <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:DropDownList ID="ddlt_csr" runat="server" Height="25px"></asp:DropDownList>
                    <asp:Label ID="lbl_csr" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                终审人：  <asp:Label ID="Label51" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:DropDownList ID="ddlt_zsr" runat="server" Height="25px"></asp:DropDownList>
                    <asp:Label ID="lbl_zsr" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                </td>          
            </tr>
    </table>
    </div>
    <br />
    <%-- 一级雷达--%>
    <div id="div_yjld" style="text-align:center" runat="server">
        <strong class="icon-reorder">一级雷达</strong>
        <table>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   雷达工作频率：  <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_gzpl1" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_gzpl1" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   测试信标型号：  <asp:Label ID="Label83" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_csxbxh1" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_csxbxh1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   雷达峰值功率：  <asp:Label ID="Label87" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_fzgl1" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_fzgl1" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线设置地点：  <asp:Label ID="Label108" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_ld_txszdd1" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_txszdd1" runat="server"></asp:Label>               
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线基础高程：  <asp:Label ID="Label110" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_txjcgc1" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_txjcgc1" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线高度：  <asp:Label ID="Label112" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_ld_txgd1" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_txgd1" runat="server"></asp:Label>               
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线生产厂家：  <asp:Label ID="Label114" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_txsccj1" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_txsccj1" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线型号_类型：  <asp:Label ID="Label116" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_ld_txxh_lx1" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_txxh_lx1" runat="server"></asp:Label>               
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   覆盖情况：  <asp:Label ID="Label118" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_fgqk1" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_fgqk1" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                无线电台执照有效期：  <asp:Label ID="Label120" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_wxdtzzyxq1" runat="server" class="input-text" style="width:200px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox>
                    <asp:Label ID="lbl_wxdtzzyxq1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   上传：  <asp:Label ID="Label122" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:FileUpload ID="tbx_ld_sc1" runat="server" />
                    <asp:Label ID="lbl_ld_sc1" runat="server" ></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                </td>
            </tr>
        </table>
    </div>
    <%-- 二级雷达--%>
    <div id="div_ejld" style="text-align:center" runat="server">
        <strong class="icon-reorder">二级雷达</strong>
        <table class="auto-style1">
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   雷达工作频率：  <asp:Label ID="Label91" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_gzpl2" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_gzpl2" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   测试信标型号：  <asp:Label ID="Label95" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_csxbxh2" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_csxbxh2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   雷达峰值功率：  <asp:Label ID="Label99" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_fzgl2" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_fzgl2" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线设置地点：  <asp:Label ID="Label93" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_ld_txszdd2" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_txszdd2" runat="server"></asp:Label>               
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线基础高程：  <asp:Label ID="Label97" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_txjcgc2" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_txjcgc2" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线高度：  <asp:Label ID="Label101" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_ld_txgd2" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_txgd2" runat="server"></asp:Label>               
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线生产厂家：  <asp:Label ID="Label100" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_txsccj2" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_txsccj2" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线型号_类型：  <asp:Label ID="Label103" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_ld_txxh_lx2" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_txxh_lx2" runat="server"></asp:Label>               
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   覆盖情况：  <asp:Label ID="Label102" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_ld_fgqk2" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_ld_fgqk2" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                无线电台执照有效期：  <asp:Label ID="Label104" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_wxdtzzyxq2" runat="server" class="input-text" style="width:200px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox>
                    <asp:Label ID="lbl_wxdtzzyxq2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   上传：  <asp:Label ID="Label106" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:FileUpload ID="tbx_ld_sc2" runat="server" />
                    <asp:Label ID="lbl_ld_sc2" runat="server" ></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                </td>
            </tr>
        </table>
    </div>
    <%-- 场面监视设备--%>
    <div id="div_cmjssb" style="text-align:center" runat="server">
        <strong class="icon-reorder">场面监视设备</strong>   
    </div>
    <%-- 自动相关监视系统设备(ADSB)--%>
    <div id="div_zdxgjsxtsb" style="text-align:center" runat="server">
        <strong class="icon-reorder">自动相关监视系统设备(ADSB)</strong>
        <table>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   工作频率：  <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_zdxgjsxtsb_gzpl" runat="server"   Height="25px"></asp:TextBox>米
                    <asp:Label ID="lbl_zdxgjsxtsb_gzpl" runat="server"></asp:Label>
                </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  是否配测试信标： <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_zdxgjsxtsb_sfpcsxb" runat="server" Height="25px"></asp:DropDownList>
                     <asp:Label ID="lbl_zdxgjsxtsb_sfpcsxb" runat="server"></asp:Label>
                </td>
                
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  测试信标型号： <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_zdxgjsxtsb_csxbxh" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_zdxgjsxtsb_csxbxh" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   测试信标S模式地址代码：  <asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_zdxgjsxtsb_csxbsmsdzdm" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zdxgjsxtsb_csxbsmsdzdm" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  持有执照人数： <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_zdxgjsxtsb_cyzzrs" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_zdxgjsxtsb_cyzzrs" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   峰值功率：  <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_zdxgjsxtsb_fzgl" runat="server"   Height="25px"></asp:TextBox>MHZ
                    <asp:Label ID="lbl_zdxgjsxtsb_fzgl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  传输方式： <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_zdxgjsxtsb_csfs" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_zdxgjsxtsb_csfs" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线设置地点：  <asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_zdxgjsxtsb_txszdd" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zdxgjsxtsb_txszdd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线基础高程： <asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_zdxgjsxtsb_txjcgc" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_zdxgjsxtsb_txjcgc" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线生产厂家：  <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_zdxgjsxtsb_txsccj" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zdxgjsxtsb_txsccj" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线型号_类型： <asp:Label ID="Label22" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_zdxgjsxtsb_txxh_lx" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_zdxgjsxtsb_txxh_lx" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   无线电台执照有效期：  <asp:Label ID="Label25" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_zdxgjsxtsb_wxdtzzyxq" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zdxgjsxtsb_wxdtzzyxq" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   上传：  <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:FileUpload ID="tbx_zdxgjsxtsb_sc" runat="server" />
                    <asp:Label ID="lbl_zdxgjsxtsb_sc" runat="server" ></asp:Label>
                </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                </td>
                
            </tr>
        </table>
    </div>
    <%-- 多点定位系统--%>
    <div id="div_dddwxt" style="text-align:center" runat="server">
        <strong class="icon-reorder">多点定位系统</strong>
        <table>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  工作频率： <asp:Label ID="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_dddwxt_gzpl" runat="server" Height="25px"></asp:DropDownList>
                     <asp:Label ID="lbl_dddwxt_gzpl" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   发射台峰值功率：  <asp:Label ID="Label30" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_dddwxt_fstfzgl" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_dddwxt_fstfzgl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线设置地点： <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_dddwxt_txszdd" runat="server" Height="25px"></asp:DropDownList>
                     <asp:Label ID="lbl_dddwxt_txszdd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线基础高程：  <asp:Label ID="Label32" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_dddwxt_txjcgc" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="投产校飞日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                    <asp:Label ID="lbl_dddwxt_txjcgc" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线生产厂家： <asp:Label ID="Label31" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_dddwxt_txsccj" runat="server"   Height="25px"></asp:TextBox>MHZ
                     <asp:Label ID="lbl__dddwxt_txsccj" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线型号_类型：  
                    <asp:Label ID="Label34" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_dddwxt_txxh_lx" runat="server"   Height="25px"></asp:TextBox>         
                    <asp:Label ID="lbl_dddwxt_txxh_lx" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  无线电台执照有效期： <asp:Label ID="Label33" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_dddwxt_wxdtzzyxq" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_dddwxt_wxdtzzyxq" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   上传：  <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:FileUpload ID="tbx_dddwxt_sc" runat="server" />
                    <asp:Label ID="lbl_dddwxt_sc" runat="server" ></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <%-- 自动化系统--%>
    <div id="div_zdhxt" style="text-align:center" runat="server">
        <strong class="icon-reorder">自动化系统</strong>
        <table>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  监视源引接线路： <asp:Label ID="Label61" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_zdhxt_jsyyjxl" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_zdhxt_jsyyjxl" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   系统软件版本：  <asp:Label ID="Label64" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                     <asp:TextBox ID="tbx_zdhxt_xtrjbb" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zdhxt_xtrjbb" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  系统规模： <asp:Label ID="Label63" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_zdhxt_xtgm" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_zdhxt_xtgm" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   ATC管制扇区数：  <asp:Label ID="Label66" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_zdhxt_ATCgzsqs" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zdhxt_ATCgzsqs" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  _A—SMGCS系统分级： <asp:Label ID="Label65" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_zdhxt_A_SMGCSxtfj" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zdhxt_A_SMGCSxtfj" runat="server"></asp:Label>
                </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  持有执照人数： <asp:Label ID="Label35" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_zdhxt_cyzzrs" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zdhxt_cyzzrs" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <%-- 空中交通管制自动化系统--%>
    <div id="div_zdzbxt" style="text-align:center" runat="server">
        <strong class="icon-reorder">空中交通管制自动化系统</strong>
    </div>
	<div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
                <td style="text-align:right"> <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn radius"   BackColor="#60B1D7" ForeColor="White" 
                Width="199px" OnClick="btn_save_Click"  ></asp:Button></td>
               <td>&nbsp;</td>
                  <td style="text-align:left">
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
    <script type="text/javascript">  
    var login = document.getElementById('login');  //弹出层中的登录框
    var over = document.getElementById('over'); //弹出层
    function show()  
    {  
        login.style.display = "block";
        login.style.position = "absoulte";
        login.style.alignContent = "center";
        login.style.zIndex = "5555";
        login.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
        login.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
        over.style.display = "block";
   
    }
    $("#btn_bc").click(function ()
    {
        hide();
    });
    function hide()  
    {
        login.style.display = "none";
        over.style.display = "none";
    }  
</script>    
</html>
