<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_CBSGLB_Add.aspx.cs" Inherits="CUST.WKG.BS_CBSGLB_Add" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
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

        #login, #login_1, #login_2, #login_3, #login_4, #login_5 {
            display: none;
            border: 1em solid #e4e5e6;
            height: 202px;
            width: 326px;
            position: absolute; /*让节点脱离文档流,我的理解就是,从页面上浮出来,不再按照文档其它内容布局*/
            top: 5%; /*节点脱离了文档流,如果设置位置需要用top和left,right,bottom定位*/
            left: 65%;
            z-index: 2; /*个人理解为层级关系,由于这个节点要在顶部显示,所以这个值比其余节点的都大*/
            background: white;
        }

        #over, #over_1, #over_2, #over_3, #over_4, #over_5 {
            width: 100%;
            height: 100%;
            opacity: 0.5; /*设置背景色透明度,1为完全不透明,IE需要使用filter:alpha(opacity=80);*/
            filter: alpha(opacity=80);
            display: none;
            position: absolute;
            top: 0;
            left: 0;
            z-index: 1;
            background: silver;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="panel-head">
                <strong class="icon-reorder">值班表信息添加</strong>
            </div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">日期：<span class="c-red">*</span></td>
                    <td style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_rq" runat="server" class="input-text" Style="width: 200px" placeholder="竣工时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:Label ID="lbl_rq" runat="server"></asp:Label></td>
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

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">塔台值班：</td>
                    <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_ttzb" runat="server" class="input-text"
                            Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                        <a href="javascript:show_1()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_1">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 地区： 
                            <asp:DropDownList ID="ddlt_dq_1" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_dq_1_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bm_1" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bm_1_SelectedIndexChanged"
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
                                <asp:Button ID="btn_bc_1" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc_1_Click" OnClientClick="hide()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb_1" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over_1">
                        </div>
                        <asp:Label ID="lbl_ttzb" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">塔台值班电话：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_ttzbdh" runat="server" class="input-text" placeholder="填写塔台值班电话" Style="width: 300px"></asp:TextBox>
                        <asp:Label ID="lbl_ttzbdh" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">站调值班：</td>
                    <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zdzb" runat="server" class="input-text"
                            Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                        <a href="javascript:show_2()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_2">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 地区： 
                            <asp:DropDownList ID="ddlt_dq_2" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_dq_2_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bm_2" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bm_2_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 站调值班： 
                            <asp:DropDownList ID="ddlt_zdzb" runat="server" class="select-box"
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
                                <asp:Button ID="btn_bc_2" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc_2_Click" OnClientClick="hide()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb_2" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over_2">
                        </div>
                        <asp:Label ID="lbl_zdzb" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">站调值班电话：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zdzbdh" runat="server" class="input-text" placeholder="填写站调值班电话" Style="width: 300px"></asp:TextBox>
                        <asp:Label ID="lbl_zdzbdh" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">通导值班：</td>
                    <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_tdzb" runat="server" class="input-text"
                            Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                        <a href="javascript:show_3()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_3">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 地区： 
                            <asp:DropDownList ID="ddlt_dq_3" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_dq_3_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bm_3" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bm_3_SelectedIndexChanged"
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
                                <asp:Button ID="btn_bc_3" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc_3_Click" OnClientClick="hide()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb_3" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over_3">
                        </div>
                        <asp:Label ID="lbl_tdzb" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">通导值班电话：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_tdzbdh" runat="server" class="input-text" placeholder="填写通导值班电话" Style="width: 300px"></asp:TextBox>
                        <asp:Label ID="lbl_tdzbdh" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">气象预报：</td>
                    <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_qxyb" runat="server" class="input-text"
                            Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                        <a href="javascript:show_4()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_4">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 地区： 
                            <asp:DropDownList ID="ddlt_dq_4" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_dq_4_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bm_4" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bm_4_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 气象预报： 
                            <asp:DropDownList ID="ddlt_qxyb" runat="server" class="select-box"
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
                                <asp:Button ID="btn_bc_4" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc_4_Click" OnClientClick="hide()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb_4" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over_4">
                        </div>
                        <asp:Label ID="lbl_qxyb" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">气象预报电话：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_qxybdh" runat="server" class="input-text" placeholder="填写气象预测电话" Style="width: 300px"></asp:TextBox>
                        <asp:Label ID="lbl_qxybdh" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">观测：</td>
                    <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_gc" runat="server" class="input-text"
                            Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                        <a href="javascript:show_5()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_5">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 地区： 
                            <asp:DropDownList ID="ddlt_dq_5" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_dq_5_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bm_5" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bm_5_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 观测： 
                            <asp:DropDownList ID="ddlt_gc" runat="server" class="select-box"
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
                                <asp:Button ID="btn_bc_5" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc_5_Click" OnClientClick="hide()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb_5" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over_5">
                        </div>
                        <asp:Label ID="lbl_gc" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">观测电话：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_gcdh" runat="server" class="input-text" placeholder="填写观测电话" Style="width: 300px"></asp:TextBox>
                        <asp:Label ID="lbl_gcdh" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">数据所在部门：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjzl">
                        <asp:DropDownList ID="ddlt_sjszbm" runat="server" Style="width: 200px"></asp:DropDownList>
                        <asp:Label ID="lbl_sjszbm" runat="server"></asp:Label>
                    </td>
                </tr>

            </table>

            <div class="row cl">
                <div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
                    <asp:Button ID="btn_save" runat="server"
                        Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                        Width="199px" OnClick="btn_save_Click"></asp:Button>
                    &nbsp; 
            <asp:Button ID="btn_fh" runat="server"
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_fh_Click"></asp:Button>
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
    var login_1 = document.getElementById('login_1');  //弹出层中的登录框
    var over_1 = document.getElementById('over_1'); //弹出层
    function show_1() {
        login_1.style.display = "block";
        login_1.style.position = "absoulte";
        login_1.style.alignContent = "center";
        login_1.style.zIndex = "5555";
        login_1.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
        login_1.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
        over_1.style.display = "block";
        over_1.style.position = "absoulte";
        over_1.style.alignContent = "center";
    }
    $("#btn_bc_1").click(function () {
        hide();
    });
    function hide() {
        login_1.style.display = "none";
        over_1.style.display = "none";
    }
</script>

<script type="text/javascript">
    var login_2 = document.getElementById('login_2');  //弹出层中的登录框
    var over_2 = document.getElementById('over_2'); //弹出层
    function show_2() {
        login_2.style.display = "block";
        login_2.style.position = "absoulte";
        login_2.style.alignContent = "center";
        login_2.style.zIndex = "5555";
        login_2.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
        login_2.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
        over_2.style.display = "block";
        over_2.style.position = "absoulte";
        over_2.style.alignContent = "center";
    }
    $("#btn_bc_2").click(function () {
        hide();
    });
    function hide() {
        login_2.style.display = "none";
        over_2.style.display = "none";
    }
</script>

<script type="text/javascript">
    var login_3 = document.getElementById('login_3');  //弹出层中的登录框
    var over_3 = document.getElementById('over_3'); //弹出层
    function show_3() {
        login_3.style.display = "block";
        login_3.style.position = "absoulte";
        login_3.style.alignContent = "center";
        login_3.style.zIndex = "5555";
        login_3.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
        login_3.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
        over_3.style.display = "block";
        over_3.style.position = "absoulte";
        over_3.style.alignContent = "center";
    }
    $("#btn_bc_3").click(function () {
        hide();
    });
    function hide() {
        login_3.style.display = "none";
        over_3.style.display = "none";
    }
</script>

<script type="text/javascript">
    var login_4 = document.getElementById('login_4');  //弹出层中的登录框
    var over_4 = document.getElementById('over_4'); //弹出层
    function show_4() {
        login_4.style.display = "block";
        login_4.style.position = "absoulte";
        login_4.style.alignContent = "center";
        login_4.style.zIndex = "5555";
        login_4.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
        login_4.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
        over_4.style.display = "block";
        over_4.style.position = "absoulte";
        over_4.style.alignContent = "center";
    }
    $("#btn_bc_4").click(function () {
        hide();
    });
    function hide() {
        login_4.style.display = "none";
        over_4.style.display = "none";
    }
</script>

<script type="text/javascript">
    var login_5 = document.getElementById('login_5');  //弹出层中的登录框
    var over_5 = document.getElementById('over_5'); //弹出层
    function show_5() {
        login_5.style.display = "block";
        login_5.style.position = "absoulte";
        login_5.style.alignContent = "center";
        login_5.style.zIndex = "5555";
        login_5.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
        login_5.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
        over_5.style.display = "block";
        over_5.style.position = "absoulte";
        over_5.style.alignContent = "center";
    }
    $("#btn_bc_5").click(function () {
        hide();
    });
    function hide() {
        login_5.style.display = "none";
        over_5.style.display = "none";
    }
</script>
</html>
