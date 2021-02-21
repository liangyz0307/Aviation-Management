<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_HWGLB_Edit.aspx.cs" Inherits="CUST.WKG.BS_HWGLB_Edit" %>

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

        #login, #login_1, #login_csr, #login_zsr {
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

        #over, #over_1, #over_csr, #over_zsr {
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
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">星期：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjzl">
                        <asp:DropDownList ID="ddlt_xq" runat="server" Style="width: 200px"></asp:DropDownList>
                        <asp:Label ID="lbl_xq" runat="server"></asp:Label>
                    </td>
                </tr>
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
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">移动电话：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_yddh" runat="server" class="input-text" placeholder="填写移动电话" Style="width: 300px"></asp:TextBox>
                        <asp:Label ID="lbl_yddh" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">固定电话：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_gddh" runat="server" class="input-text" placeholder="填写固定电话" Style="width: 300px"></asp:TextBox>
                        <asp:Label ID="lbl_gddh" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">导航保障室：</td>
                    <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_dhbzs" runat="server" class="input-text"
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
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 导航保障室： 
                            <asp:DropDownList ID="ddlt_dhbzs" runat="server" class="select-box"
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
                        <asp:Label ID="lbl_dhbzs" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">数据所在部门：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjzl">
                        <asp:DropDownList ID="ddlt_sjszbm" runat="server" Style="width: 200px"></asp:DropDownList>
                        <asp:Label ID="lbl_sjszbm" runat="server"></asp:Label>
                    </td>
                </tr>


                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备注：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 80%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bz" runat="server" class="input-text" placeholder="填写备注" Style="width: 300px"></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
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
</html>
