<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TXSB_Add.aspx.cs" Inherits="CUST.WKG.TXSB_Add" %>

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
            数据所属部门：  <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:DropDownList ID="ddlt_sjssbm" runat="server" Height="25px"></asp:DropDownList>
                <asp:Label ID="lbl_sjssbm" runat="server"></asp:Label>
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
                 <asp:DropDownList ID="ddlt_tzmczl" runat="server" Width="230px"   Height="26px" OnSelectedIndexChanged="ddlt_sblx_change" AutoPostBack="true" ></asp:DropDownList>
                <asp:Label ID="lbl_tzmczl" runat="server"></asp:Label>
            </td>

        </tr>  

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              投产开放时间：  <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:TextBox ID="tbx_tckfsj" runat="server" class="input-text" style="width:200px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox>
                <asp:Label ID="lbl_tckfsj" runat="server"></asp:Label>
            </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              数量： <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:TextBox ID="tbx_sl" runat="server" MaxLength="3" Height="25px"></asp:TextBox>
                <asp:Label ID="lbl_sl" runat="server"></asp:Label>
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
                   设备序号可证上传：  <asp:Label ID="Label26" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:FileUpload ID="tbx_sbxkzsc" runat="server" />
                    <asp:Label ID="lbl_sbxkzsc" runat="server" ></asp:Label>
                </td>         
            </tr>
           <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 用途：  <asp:Label ID="Label38" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:DropDownList ID="ddlt_yt" runat="server" Height="25px"></asp:DropDownList>
                    <asp:Label ID="lbl_yt" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                交流供电：  <asp:Label ID="Label41" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_jlgd" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_jlgd" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 交流供电大小：  <asp:Label ID="Label40" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                    <asp:TextBox ID="tbx_jlgddx" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_jlgddx" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                交流供电数量：  <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                    <asp:TextBox ID="tbx_jlgdsl" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_jlgdsl" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 直流供电：  <asp:Label ID="Label42" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_zlgd" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zlgd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                直流供电大小：  <asp:Label ID="Label46" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_zlgddx" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zlgddx" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 直流供电数量：  <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_zlgdsl" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zlgdsl" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   保护区范围：  <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:FileUpload ID="tbx_bhqfw" runat="server" />
                    <asp:Label ID="lbl_bhqfw" runat="server" ></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 设备传输情况：  <asp:Label ID="Label47" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_sbcsqk" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_sbcsqk" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                设备防雷配置：  <asp:Label ID="Label50" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_sbflpz" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_sbflpz" runat="server"></asp:Label>
                </td>          
            </tr>

            <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                 现所属机场：  <asp:Label ID="Label49" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:DropDownList ID="ddlt_xssjc" runat="server" Height="25px"></asp:DropDownList>
                    <asp:Label ID="lbl_xssjc" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                调拨时间：  <asp:Label ID="Label52" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_dbsj" runat="server" class="input-text" style="width:200px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox>
                    <asp:Label ID="lbl_dbsj" runat="server"></asp:Label>
                </td>          
            </tr>

             <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">设备保管人：</td>
                <td colspan="1" style="width: 10%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_sbbgr" runat="server" class="input-text"
                    Width="200px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                <a href="javascript:show()">
                    <img alt="" src="../../Content/images/add.png" /></a>
                    <%--   填写内容层  --%>
                <div id="login">
                    <table>
                        <tr class="td_sjsc"
                            style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                            <td class="td_sjsc" colspan="2"
                                style="width: 60%; text-align: left; vertical-align: middle;">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bmdm" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 岗位： 
                            <asp:DropDownList ID="ddlt_gwdm" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_gwdm_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 设备保管人： 
                            <asp:DropDownList ID="ddlt_sbbgr" runat="server" class="select-box"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                           </table>
                            <br />
                            <div style="text-align: center">
                                <asp:Button ID="btn_bc" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc_Click" OnClientClick="hide()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                            <%-- 背景层--%>
                        <div id="over">
                        </div>
                        <asp:Label ID="lbl_sbbgr" runat="server"></asp:Label>
                </td>
                                 <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                设备编号：  <asp:Label ID="Label81" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_sbbh" runat="server" Height="25px" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="lbl_sbbh" runat="server"></asp:Label>
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
                 设备型号：  <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_sbxh" runat="server" Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_sbxh" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
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
                   现有用户数：  <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_yyjly_xyyhs" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_yyjly_xyyhs" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   语音信道数：  <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_yyjly_yyxds" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_yyjly_yyxds" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   数据信道数：  <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                  <asp:TextBox ID="tbx_yyjly_sjxds" runat="server"   Height="25px"></asp:TextBox>
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
                  站点类型： <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_wxdmzxt_zdlx" runat="server" Height="25px"></asp:DropDownList>
                     <asp:Label ID="lbl_wxdmzxt_zdlx" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线口径：  <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_wxdmzxt_txkj" runat="server"   Height="25px"></asp:TextBox>米
                    <asp:Label ID="lbl_wxdmzxt_txkj" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  室外单元功率： <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_wxdmzxt_swdygl" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_wxdmzxt_swdygl" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   发射频率：  <asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_wxdmzxt_fspl" runat="server"   Height="25px"></asp:TextBox>MHZ
                    <asp:Label ID="lbl_wxdmzxt_fspl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  接收频率： <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_wxdmzxt_jspl" runat="server"   Height="25px"></asp:TextBox>MHZ
                     <asp:Label ID="lbl_wxdmzxt_jspl" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   信道数：  <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_wxdmzxt_xds" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_wxdmzxt_xds" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  台站坐标(北京54)经度： <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_wxdmzxt_tzzb_bj54_jd" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_wxdmzxt_tzzb_bj54_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   台站坐标(北京54)纬度：  <asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_wxdmzxt_tzzb_bj54_wd" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_wxdmzxt_tzzb_bj54_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  台站坐标(wgs84)经度： <asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_wxdmzxt_tzzb_wgs84_jd" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_wxdmzxt_tzzb_wgs84_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   台站坐标(wgs84)纬度：  <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_wxdmzxt_tzzb_wgs84_wd" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_wxdmzxt_tzzb_wgs84_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线设置地点： <asp:Label ID="Label22" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_wxdmzxt_txszdd" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_wxdmzxt_txszdd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线基础高程：  <asp:Label ID="Label25" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_wxdmzxt_txjcgc" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_wxdmzxt_txjcgc" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  无线电台执照有效期： <asp:Label ID="Label24" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_wxdmzxt_wxdtzzyxq" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_wxdmzxt_wxdtzzyxq" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   上传：  <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:FileUpload ID="tbx_wxdmzxt_sc" runat="server" />
                    <asp:Label ID="lbl_wxdmzxt_sc" runat="server" ></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_sgpdktxxt" style="text-align:center" runat="server">
        <strong class="icon-reorder">甚高频地空通信系统</strong>
        <table>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  设备配置： <asp:Label ID="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_sgpdktxxt_sbpz" runat="server" Height="25px"></asp:DropDownList>
                     <asp:Label ID="lbl_sgpdktxxt_sbpz" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   设备信道数：  <asp:Label ID="Label30" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_sgpdktxxt_sbxds" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_sgpdktxxt_sbxds" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线类型： <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_sgpdktxxt_txlx" runat="server" Height="25px"></asp:DropDownList>
                     <asp:Label ID="lbl_sgpdktxxt_txlx" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   投产校飞日期：  <asp:Label ID="Label32" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_sgpdktxxt_tcjfrq" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="投产校飞日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                    <asp:Label ID="lbl_sgpdktxxt_tcjfrq" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  发射频率： <asp:Label ID="Label31" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_sgpdktxxt_fspl" runat="server"   Height="25px"></asp:TextBox>MHZ
                     <asp:Label ID="lbl__sgpdktxxt_fspl" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   输出功率：  
                    <asp:Label ID="Label34" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_sgpdktxxt_scgl" runat="server"   Height="25px"></asp:TextBox>         
                    <asp:Label ID="lbl_sgpdktxxt_scgl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  传输方式： <asp:Label ID="Label33" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_sgpdktxxt_csfs" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_sgpdktxxt_csfs" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   上传：  <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:FileUpload ID="tbx_sgpdktxxt_sc" runat="server" />
                    <asp:Label ID="lbl_sgpdktxxt_sc" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                  台站坐标(北京54)经度： <asp:Label ID="Label48" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                     <asp:TextBox ID="tbx_sgpdktxxt_tzzb_bj54_jd" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_sgpdktxxt_tzzb_bj54_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                   台站坐标(北京54)纬度：  <asp:Label ID="Label54" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_sgpdktxxt_tzzb_bj54_wd" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_sgpdktxxt_tzzb_bj54_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  台站坐标(wgs84)经度： <asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_sgpdktxxt_tzzb_wgs84_jd" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_sgpdktxxt_tzzb_wgs84_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   台站坐标(wgs84)纬度：  <asp:Label ID="Label58" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_sgpdktxxt_tzzb_wgs84_wd" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_sgpdktxxt_tzzb_wgs84_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线基础高程： <asp:Label ID="Label53" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_sgpdktxxt_txjcgc" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_sgpdktxxt_txjcgc" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线高度：  <asp:Label ID="Label57" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_sgpdktxxt_txgd" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_sgpdktxxt_txgd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线设置地点： <asp:Label ID="Label55" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_sgpdktxxt_txszdd" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_sgpdktxxt_txszdd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   无线电台执照有效期：  <asp:Label ID="Label60" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                     <asp:TextBox ID="tbx_sgpdktxxt_wxdtzzyxq" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_sgpdktxxt_wxdtzzyxq" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线生产厂家： <asp:Label ID="Label59" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_sgpdktxxt_txsccj" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_sgpdktxxt_txsccj" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线型号：  <asp:Label ID="Label62" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                     <asp:TextBox ID="tbx_sgpdktxxt_txxh_lx" runat="server"   Height="25px"></asp:TextBox>
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
                  系统配置： <asp:Label ID="Label61" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_yyjhxt_nh_xtpz" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_yyjhxt_nh_xtpz" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   席位具体配置：  <asp:Label ID="Label64" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                     <asp:TextBox ID="tbx_yyjhxt_nh_xwjtpz" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_yyjhxt_nh_xwjtpz" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  系统软件版本： <asp:Label ID="Label63" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_yyjhxt_nh_xtrjbb" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_yyjhxt_nh_xtrjbb" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   接口数量：  <asp:Label ID="Label66" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_yyjhxt_nh_jksl_yx" runat="server"   Height="25px"></asp:TextBox>(有线)个
                    <asp:TextBox ID="tbx_yyjhxt_nh_jksl_wx" runat="server"   Height="25px"></asp:TextBox>(无线)个
                    <asp:Label ID="lbl_yyjhxt_nh_jksl_yx" runat="server"></asp:Label>
                    <asp:Label ID="lbl_yyjhxt_nh_jksl_wx" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  MFC协议： <asp:Label ID="Label65" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_yyjhxt_nh_MFCxy" runat="server" Height="25px"></asp:DropDownList>
                     <asp:Label ID="lbl_yyjhxt_nh_MFCxy" runat="server"></asp:Label>
                </td>
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  Q-SIG协议： <asp:Label ID="Label35" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_yyjhxt_nh_QSIGxy" runat="server" Height="25px"></asp:DropDownList>
                     <asp:Label ID="lbl_yyjhxt_nh_QSIGxy" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  IP协议： <asp:Label ID="Label67" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_yyjhxt_nh_IPxy" runat="server" Height="25px"></asp:DropDownList>
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
                  系统配置： <asp:Label ID="Label68" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_zdzbxt_xtpz" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_zdzbxt_xtpz" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   系统软件版本：  <asp:Label ID="Label70" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                     <asp:TextBox ID="tbx_zdzbxt_xtrjbb" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_zdzbxt_xtrjbb" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  在用系统： <asp:Label ID="Label69" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_zdzbxt_zyxt" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_zdzbxt_zyxt" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   终端用户列表：  <asp:Label ID="Label72" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                     <asp:TextBox ID="tbx_zdzbxt_zdyhlb" runat="server"   Height="25px"></asp:TextBox>
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
                  设备配置： <asp:Label ID="Label71" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_gpdktxxt_sbpz" runat="server" Height="25px"></asp:DropDownList>
                     <asp:Label ID="lbl_gpdktxxt_sbpz" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   设备信道数：  <asp:Label ID="Label74" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                     <asp:TextBox ID="tbx_gpdktxxt_sbxds" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_gpdktxxt_sbxds" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线类型： <asp:Label ID="Label73" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_gpdktxxt_txlx" runat="server" Height="25px"></asp:DropDownList>
                     <asp:Label ID="lbl_gpdktxxt_txlx" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   投产校飞日期：  <asp:Label ID="Label76" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_gpdktxxt_tcjfrq" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="投产校飞日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                    <asp:Label ID="lbl_gpdktxxt_tcjfrq" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  发射频率： <asp:Label ID="Label75" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_gpdktxxt_fspl" runat="server"   Height="25px"></asp:TextBox>MHZ
                     <asp:Label ID="lbl_gpdktxxt_fspl" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   输出功率：  <asp:Label ID="Label78" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">      
                    <asp:TextBox ID="tbx_gpdktxxt_scgl" runat="server"   Height="25px"></asp:TextBox>         
                    <asp:Label ID="lbl_gpdktxxt_scgl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  传输方式： <asp:Label ID="Label77" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_gpdktxxt_csfs" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_gpdktxxt_csfs" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   上传：  <asp:Label ID="Label79" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:FileUpload ID="tbx_gpdktxxt_sc" runat="server" />
                    <asp:Label ID="lbl_gpdktxxt_sc" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  台站坐标(北京54)经度： <asp:Label ID="Label80" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_gpdktxxt_tzzb_bj54_jd" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_gpdktxxt_tzzb_bj54_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   台站坐标(北京54)纬度：  <asp:Label ID="Label82" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_gpdktxxt_tzzb_bj54_wd" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_gpdktxxt_tzzb_bj54_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  台站坐标(wgs84)经度： <asp:Label ID="Label84" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_gpdktxxt_tzzb_wgs84_jd" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_gpdktxxt_tzzb_wgs84_jd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   台站坐标(wgs84)纬度：  <asp:Label ID="Label86" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_gpdktxxt_tzzb_wgs84_wd" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_gpdktxxt_tzzb_wgs84_wd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线基础高程： <asp:Label ID="Label88" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_gpdktxxt_txjcgc" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_gpdktxxt_txjcgc" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线高度：  <asp:Label ID="Label90" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                    <asp:TextBox ID="tbx_gpdktxxt_txgd" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_gpdktxxt_txgd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线设置地点： <asp:Label ID="Label92" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_gpdktxxt_txszdd" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_gpdktxxt_txszdd" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   无线电台执照有效期：  <asp:Label ID="Label94" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                     <asp:TextBox ID="tbx_gpdktxxt_wxdtzzyxq" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_gpdktxxt_wxdtzzyxq" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  天线生产厂家： <asp:Label ID="Label96" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                     <asp:TextBox ID="tbx_gpdktxxt_txsccj" runat="server"   Height="25px"></asp:TextBox>
                     <asp:Label ID="lbl_gpdktxxt_txsccj" runat="server"></asp:Label>
                </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                   天线型号：  <asp:Label ID="Label98" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">               
                     <asp:TextBox ID="tbx_gpdktxxt_txxh_lx" runat="server"   Height="25px"></asp:TextBox>
                    <asp:Label ID="lbl_gpdktxxt_txxh_lx" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
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
