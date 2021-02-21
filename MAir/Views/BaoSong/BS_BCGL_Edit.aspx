<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_BCGL_Edit.aspx.cs" Inherits="CUST.WKG.BS_BCGL_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title></title>
    <script type ="text/javascript"  src="../../Content/js/jquery.js"></script>
    <script type ="text/javascript"  src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <%--   UEdit--%>
      <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.config.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.all.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/lang/zh-cn/zh-cn.js" charset="utf-8"></script>
         <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>
         <script type="text/javascript" src="../../Content/js/jquery.js"></script>
     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
      #login ,#login_1,#login_csr,#login_zsr,#login1,#login2,#login3,#login4,#login5
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
   
    #over  ,#over_1,#over_csr,#over_zsr, #over1 , #over2 , #over3 , #over4 , #over5 
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
     
	<div class="panel-head">
            <strong class="icon-reorder">值班表信息添加</strong>
        </div>
    <table >

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
<%--                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    星期：<span class="c-red">*</span></td>--%>
               <%-- <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_xq" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_xq" runat="server" ></asp:Label>
                    </td>--%>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   日期：<span class="c-red">*</span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_rq" runat="server" class="input-text" style="width:200px" placeholder="竣工时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_rq" runat="server" ></asp:Label></td>
            </tr>
      
         <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">值班领导：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_zbld" runat="server" class="input-text"
                    Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                <a href="javascript:show()">
                    <img alt="" src="../../Content/images/add.png" /></a>
                    <%--   填写内容层  --%>
                <div id="login">
                    <table>
                        <tr class="td_sjsc"
                            style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                            <td class="td_sjsc" colspan="2"
                                style="width: 60%; text-align: left; vertical-align: middle;">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 地区： 
                            <asp:DropDownList ID="ddlt_dq" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_dq_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bm" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bm_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 值班领导： 
                            <asp:DropDownList ID="ddlt_zbld" runat="server" class="select-box"
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
                        <asp:Label ID="lbl_zbld" runat="server"></asp:Label>
                    </td>
                </tr> 
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    值班领导电话：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_zblddh" runat="server" class="input-text" placeholder="填写手机号、电话号" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_zblddh" runat="server" ></asp:Label>
                    </td>
            </tr>

         <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">塔台值班：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_ttzb" runat="server" class="input-text"
                    Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                <a href="javascript:show1()">
                    <img alt="" src="../../Content/images/add.png" /></a>
                    <%--   填写内容层  --%>
                <div id="login1">
                    <table>
                        <tr class="td_sjsc"
                            style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                            <td class="td_sjsc" colspan="2"
                                style="width: 60%; text-align: left; vertical-align: middle;">
                                
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 地区： 
                            <asp:DropDownList ID="ddlt_dq1" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_dq1_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bm1" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bm1_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 塔台值班： 
                            <asp:DropDownList ID="ddlt_ttzb" runat="server" class="select-box"
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
                                <asp:Button ID="btn_bc1" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc1_Click" OnClientClick="hide1()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb1" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide1()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                            <%-- 背景层--%>
                        <div id="over1">
                        </div>
                        <asp:Label ID="lbl_ttzb" runat="server"></asp:Label>
                    </td>
                </tr> 

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   塔台值班电话：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_ttzbdh" runat="server" class="input-text" placeholder="填写手机号、电话号" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_ttzbdh" runat="server" ></asp:Label>
                    </td>
            </tr>

        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">飞服值班：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_ffzb" runat="server" class="input-text"
                    Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                <a href="javascript:show2()">
                    <img alt="" src="../../Content/images/add.png" /></a>
                    <%--   填写内容层  --%>
                <div id="login2">
                    <table>
                        <tr class="td_sjsc"
                            style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                            <td class="td_sjsc" colspan="2"
                                style="width: 60%; text-align: left; vertical-align: middle;"> 
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 地区： 
                            <asp:DropDownList ID="ddlt_dq2" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_dq2_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bm2" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bm2_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 飞服值班： 
                            <asp:DropDownList ID="ddlt_ffzb" runat="server" class="select-box"
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
                                <asp:Button ID="btn_bc2" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc2_Click" OnClientClick="hide2()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb2" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide2()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                            <%-- 背景层--%>
                        <div id="over2">
                        </div>
                        <asp:Label ID="lbl_ffzb" runat="server"></asp:Label>
                    </td>
                </tr> 

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     飞服值班电话：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_ffzbdh" runat="server" class="input-text" placeholder="填写手机号、电话号" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_ffzbdh" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">通导值班：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_tdzb" runat="server" class="input-text"
                    Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                <a href="javascript:show3()">
                    <img alt="" src="../../Content/images/add.png" /></a>
                    <%--   填写内容层  --%>
                <div id="login3">
                    <table>
                        <tr class="td_sjsc"
                            style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                            <td class="td_sjsc" colspan="2"
                                style="width: 60%; text-align: left; vertical-align: middle;"> 
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 地区： 
                            <asp:DropDownList ID="ddlt_dq3" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_dq3_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bm3" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bm3_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 通导值班： 
                            <asp:DropDownList ID="ddlt_tdzb" runat="server" class="select-box"
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
                                <asp:Button ID="btn_bc3" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc3_Click" OnClientClick="hide3()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb3" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide3()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                            <%-- 背景层--%>
                        <div id="over3">
                        </div>
                        <asp:Label ID="lbl_tdzb" runat="server"></asp:Label>
                    </td>
                </tr> 

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    通导值班电话：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_tdzbdh" runat="server" class="input-text" placeholder="填写手机号、电话号" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_tdzbdh" runat="server" ></asp:Label>
                    </td>
            </tr>
        
        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">观测值班：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_gczb" runat="server" class="input-text"
                    Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                <a href="javascript:show4()">
                    <img alt="" src="../../Content/images/add.png" /></a>
                    <%--   填写内容层  --%>
                <div id="login4">
                    <table>
                        <tr class="td_sjsc"
                            style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                            <td class="td_sjsc" colspan="2"
                                style="width: 60%; text-align: left; vertical-align: middle;"> 
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 地区： 
                            <asp:DropDownList ID="ddlt_dq4" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_dq4_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bm4" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bm4_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 观测值班： 
                            <asp:DropDownList ID="ddlt_gczb" runat="server" class="select-box"
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
                                <asp:Button ID="btn_bc4" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc4_Click" OnClientClick="hide4()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb4" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide4()" Text="关闭"
                                    Width="100px" OnClick="btn_bc4_Click" />
                            </div>
                        </div>
                            <%-- 背景层--%>
                        <div id="over4">
                        </div>
                        <asp:Label ID="lbl_gczb" runat="server"></asp:Label>
                    </td>
                </tr> 

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    观测值班电话：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_gczbdh" runat="server" class="input-text" placeholder="填写手机号、电话号" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_gczbdh" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">预报值班：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_ybzb" runat="server" class="input-text"
                    Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                <a href="javascript:show5()">
                    <img alt="" src="../../Content/images/add.png" /></a>
                    <%--   填写内容层  --%>
                <div id="login5">
                    <table>
                        <tr class="td_sjsc"
                            style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                            <td class="td_sjsc" colspan="2"
                                style="width: 60%; text-align: left; vertical-align: middle;"> 
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 地区： 
                            <asp:DropDownList ID="ddlt_dq5" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_dq5_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bm5" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bm5_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 预报值班： 
                            <asp:DropDownList ID="ddlt_ybzb" runat="server" class="select-box"
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
                                <asp:Button ID="btn_bc5" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc5_Click" OnClientClick="hide5()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="ddlt_gb5" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide5()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                            <%-- 背景层--%>
                        <div id="over5">
                        </div>
                        <asp:Label ID="lbl_ybzh" runat="server"></asp:Label>
                    </td>
                </tr> 
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    预报值班电话：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_ybzbdh" runat="server" class="input-text" placeholder="填写手机号、电话号" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_ybzbdh" runat="server" ></asp:Label>
                    </td>
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    数据所在部门：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_sjszbm" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_sjszbm" runat="server" ></asp:Label>
                    </td>
              </tr>
          
        </table>

	<div class="row cl">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
		    <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="199px" OnClick="btn_save_Click"  ></asp:Button> 
            &nbsp; 
            <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_fh_Click"   ></asp:Button> 
		</div>
	</div>

	</form>
</article>
    
</body>
    <script src="../css/js/jquery.js" type="text/javascript"></script>
      <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
        <script src="../css/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
         var login = document.getElementById('login');  //弹出层中的登录框
         var over = document.getElementById('over'); //弹出层
         function show() {
             login.style.display = "block";
             login.style.position = "absoulte";
             login.style.alignContent = "center";
             login.style.zIndex = "5555";
             login.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
             login.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
             over.style.display = "block";
             over.style.position = "absoulte";
             over.style.alignContent = "center";
         }
         $("#btn_bc").click(function () {
             hide();
         });
         function hide() {
             login.style.display = "none";
             over.style.display = "none";
         }
</script> 
      <script type="text/javascript">
         var login1 = document.getElementById('login1');  //弹出层中的登录框
         var over1 = document.getElementById('over1'); //弹出层
         function show1() {
             login1.style.display = "block";
             login1.style.position = "absoulte";
             login1.style.alignContent = "center";
             login1.style.zIndex = "5555";
             login1.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
             login1.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
             over1.style.display = "block";
             over1.style.position = "absoulte";
             over1.style.alignContent = "center";
         }
         $("#btn_bc1").click(function () {
             hide1();
         });
         function hide1() {
             login1.style.display = "none";
             over1.style.display = "none";
         }
</script> 
      <script type="text/javascript">
         var login2 = document.getElementById('login2');  //弹出层中的登录框
         var over2 = document.getElementById('over2'); //弹出层
         function show2() {
             login2.style.display = "block";
             login2.style.position = "absoulte";
             login2.style.alignContent = "center";
             login2.style.zIndex = "5555";
             login2.style.top = (document.documentElement.clientHeight - login2.offsetHeight) / 2 + "px";
             login2.style.left = (document.documentElement.clientWidth - login2.offsetWidth) / 2 + "px";
             over2.style.display = "block";
             over2.style.position = "absoulte";
             over2.style.alignContent = "center";
         }
         $("#btn_bc2").click(function () {
             hide2();
         });
         function hide2() {
             login2.style.display = "none";
             over2.style.display = "none";
         }
</script> 
      <script type="text/javascript">
         var login3 = document.getElementById('login3');  //弹出层中的登录框
         var over3 = document.getElementById('over3'); //弹出层
         function show3() {
             login3.style.display = "block";
             login3.style.position = "absoulte";
             login3.style.alignContent = "center";
             login3.style.zIndex = "5555";
             login3.style.top = (document.documentElement.clientHeight - login3.offsetHeight) / 2 + "px";
             login3.style.left = (document.documentElement.clientWidth - login3.offsetWidth) / 2 + "px";
             over3.style.display = "block";
             over3.style.position = "absoulte";
             over3.style.alignContent = "center";
         }
         $("#btn_bc3").click(function () {
             hide3();
         });
         function hide3() {
             login3.style.display = "none";
             over3.style.display = "none";
         }
</script> 
      <script type="text/javascript">
         var login4 = document.getElementById('login4');  //弹出层中的登录框
         var over4 = document.getElementById('over4'); //弹出层
         function show4() {
             login4.style.display = "block";
             login4.style.position = "absoulte";
             login4.style.alignContent = "center";
             login4.style.zIndex = "5555";
             login4.style.top = (document.documentElement.clientHeight - login4.offsetHeight) / 2 + "px";
             login4.style.left = (document.documentElement.clientWidth - login4.offsetWidth) / 2 + "px";
             over4.style.display = "block";
             over4.style.position = "absoulte";
             over4.style.alignContent = "center";
         }
         $("#btn_bc4").click(function () {
             hide4();
         });
         function hide4() {
             login4.style.display = "none";
             over4.style.display = "none";
         }
</script> 
      <script type="text/javascript">
         var login5 = document.getElementById('login5');  //弹出层中的登录框
         var over5 = document.getElementById('over5'); //弹出层
         function show5() {
             login5.style.display = "block";
             login5.style.position = "absoulte";
             login5.style.alignContent = "center";
             login5.style.zIndex = "5555";
             login5.style.top = (document.documentElement.clientHeight - login5.offsetHeight) / 2 + "px";
             login5.style.left = (document.documentElement.clientWidth - login5.offsetWidth) / 2 + "px";
             over5.style.display = "block";
             over5.style.position = "absoulte";
             over5.style.alignContent = "center";
         }
         $("#btn_bc5").click(function () {
             hide5();
         });
         function hide5() {
             login5.style.display = "none";
             over5.style.display = "none";
         }
</script> 
</html>
