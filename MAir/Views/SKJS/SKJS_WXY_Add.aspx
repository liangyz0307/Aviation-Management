<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SKJS_WXY_Add.aspx.cs" Inherits="CUST.WKG.SKJS_WXY_Add" %>
<%@ Register TagPrefix="hw" Namespace="UNLV.IAP.WebControls" Assembly="DropDownCheckList" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
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
      jsc
            {
                background:#F6FAFD;
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
            <div class="panel-head">
                <strong class="icon-reorder">安全风险添加</strong>
            </div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc"> 岗 位：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_gw" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_gw" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">危险源名称：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_mc" runat="server" class="input-text"
                            Width="446px" MaxLength="10" Height="20px" OnTextChanged="tbx_mc_TextChanged" ></asp:TextBox>
                        <asp:Label ID="lbl_mc" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">危 险 源 范 畴：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_fc" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_fc" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">责任人：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_syr" runat="server" class="input-text"
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
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                                  <asp:DropDownList ID="ddlt_bmdm" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged1"
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
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 员工： 
                                  <asp:DropDownList ID="ddlt_syr" runat="server" class="select-box"
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
                        <asp:Label ID="lbl_syr" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">月 份 ：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_yf" runat="server" class="input-text"
                            Width="446px" MaxLength="2000" Height="21px"></asp:TextBox>

                        <asp:Label ID="lbl_yf" runat="server"></asp:Label>
                    </td>

                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">时 态：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_st" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_st" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">风险发生的可能性：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_knx" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_knx" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">后果的严重性：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_yzx" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_yzx" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">风 险 程 度：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_fxcd" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_fxcd" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">状 态：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zt" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_zt" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">控 制 状 态：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_kzzt" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_kzzt" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">控制措施标准化情况：</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_bzh" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_bzh" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">责任部门(二级) </td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_bmej" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_bmej" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">责任部门(三级)： </td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_bmsj" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_bmsj" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">配 合 部 门： </td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_phbm" runat="server" Width="446px"></asp:DropDownList>
                        <asp:Label ID="lbl_phbm" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">相关典型案例 ：</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_xgal" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="200px" Width="450px" ClientIDMode="Static"></asp:TextBox>
                        <asp:Label ID="lbl_xgal" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">诱 发 原 因 ：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_yy" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="200px" Width="450px" ClientIDMode="Static"></asp:TextBox>
                        <asp:Label ID="lbl_yy" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">后 果 ：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_hg" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="200px" Width="450px" ClientIDMode="Static"></asp:TextBox>
                        <asp:Label ID="lbl_hg" runat="server"></asp:Label>
                    </td>

                </tr>
                
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">风险控制预案：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_ya" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="200px" Width="450px" ClientIDMode="Static"></asp:TextBox>
                        <asp:Label ID="lbl_ya" runat="server"></asp:Label>
                    </td>

                </tr>
            
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">应 急 措 施：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_yj" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="200px" Width="450px" ClientIDMode="Static" OnTextChanged="tbx_yj_TextChanged"></asp:TextBox>
                        <asp:Label ID="lbl_yj" runat="server"></asp:Label>
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


              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    初审人：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_csr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_csr" runat="server" ></asp:Label>
                    </td>
            </tr>
                    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    终审人：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_zsr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_zsr" runat="server" ></asp:Label>
                    </td>
               
            
            </table>


            <div class="row cl">
                <div class="row cl" style="text-align: center; width: 100%; margin: 0 auto;">
                    <table>
                        <tr>
                            <td style="text-align: right">
                                <asp:Button ID="btn_save" runat="server"
                                    Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                    Width="199px" OnClick="btn_save_Click"></asp:Button></td>
                            <td>&nbsp;</td>
                            <td style="text-align: left">
                                <asp:Button ID="btn_fh" runat="server"
                                    Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                    Width="199px" OnClick="btn_fh_Click" Style="margin-bottom: 0px"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </form>
           <script type="text/javascript" src="../css/js/jquery.js"></script>
            <script type="text/javascript" src="../css/js/H-ui.admin.js"></script>
             <script type="text/javascript" src="../css/js/H-ui.js"></script>
    </article>
</body>

<script type="text/javascript">
    //  风 险 源 范 畴
    $(document).ready(function () {
        //名称
        $("#tbx_mc").blur(function() {
            if ($("#tbx_mc").val() != "") {
                $("#lbl_mc").text("正确");
                $("#lbl_mc").css("color", "#00ff00");
            } else {
                $("#lbl_mc").text("内容不能为空");
                $("#lbl_mc").css("color", "#ff0000");
            }
        });
        //月份
        //预计金额
        $("#tbx_yjje").blur(function () {
            if ($("#tbx_yjje").val().trim() == "") {
                $("#lbl_yjje").text("内容不能为空");
                $("#lbl_yjje").css("color", "#ff0000");
            }
            else {
                var ys = /^[0-9]+(\.[0-9]{0,2})?$/
                if (!ys.test($("#tbx_yjje").val())) {
                    $("#lbl_yjje").text("请输入整数或小数");
                    $("#lbl_yjje").css("color", "#ff0000");
                }
                else {
                    $("#lbl_yjje").text("正确");
                    $("#lbl_yjje").css("color", "#00ff00");
                }


            }
        });
        //月份
        $("#tbx_yf").blur(function () {
            if ($("#tbx_yf").val().trim() == "") {
                $("#lbl_yf").text("内容不能为空");
                $("#lbl_yf").css("color", "#ff0000");
            }
            else {
                var ys = /^(0?[[1-9]|1[0-2])$/
                if (!ys.test($("#tbx_yf").val())) {
                    $("#lbl_yf").text("月份格式不正确");
                    $("#lbl_yf").css("color", "#ff0000");
                }
                else {
                    $("#lbl_yf").text("正确");
                    $("#lbl_yf").css("color", "#00ff00");
                }


            }
        });
        //岗位
        $("#ddlt_gw").blur(function () {

            if ($("#ddlt_gw option:selected").val() != "-1") {
                $("#lbl_gw").text("正确");  
                $("#lbl_gw").css("color", "#00ff00");
            } else {
                $("#lbl_gw").text("请选择");
                $("#lbl_gw").css("color", "#ff0000");
            }

        });
       //原因
        $("#tbx_yy").blur(function () {
            if ($("#tbx_yy").val() != "") {
                $("#lbl_yy").text("正确");
                $("#lbl_yy").css("color", "#00ff00");
            } else {
                $("#lbl_yy").text("内容不能为空");
                $("#lbl_yy").css("color", "#ff0000");
            }
        });


        //后果

        $("#ddlt_hg").blur(function () {

            if ($("#ddlt_hg option:selected").val() != "-1") {
                $("#lbl_hg").text("正确");
                $("#lbl_hg").css("color", "#00ff00");
            } else {
                $("#lbl_hg").text("请选择");
                $("#lbl_hg").css("color", "#ff0000");
            }

        });
        //相关案例

        $("#tbx_xgal").blur(function () {
            if ($("#tbx_xgal").val() != "") {
                $("#lbl_xgal").text("正确");
                $("#lbl_xgal").css("color", "#00ff00");
            } 
        });

       
        //预案

        $("#tbx_ya").blur(function () {
            if ($("#tbx_ya").val() != "") {
                $("#lbl_ya").text("正确");
                $("#lbl_ya").css("color", "#00ff00");
            } else {
                $("#lbl_ya").text("内容不能为空");
                $("#lbl_ya").css("color", "#ff0000");
            }
        });

        //标准化情况
        $("#ddlt_bzh").blur(function () {

            if ($("#ddlt_bzh option:selected").val() != "-1") {
                $("#lbl_bzh").text("正确");
                $("#lbl_bzh").css("color", "#00ff00");
            }

        });
        //应急措施
        $("#tbx_yj").blur(function () {
            if ($("#tbx_yj").val() != "") {
                $("#lbl_yj").text("正确");
                $("#lbl_yj").css("color", "#00ff00");
            } else {
                $("#lbl_yj").text("内容不能为空");
                $("#lbl_yj").css("color", "#ff0000");
            }
        });

        //责任人

        $("#tbx_syr").blur(function () {
            if ($("#tbx_syr").val() != "") {
                $("#lbl_syr").text("正确");
                $("#lbl_syr").css("color", "#00ff00");
            } 
        });


        //范畴

        $("#ddlt_fc").blur(function () {

            if ($("#ddlt_fc option:selected").val() != "-1") {
                $("#lbl_fc").text("正确");
                $("#lbl_fc").css("color", "#00ff00");
            } else {
                $("#lbl_fc").text("请选择");
                $("#lbl_fc").css("color", "#ff0000");
            }

        });

        //时态

        $("#ddlt_st").blur(function () {

            if ($("#ddlt_st option:selected").val() != "-1") {
                $("#lbl_st").text("正确");
                $("#lbl_st").css("color", "#00ff00");
            } else {
                $("#lbl_st").text("请选择");
                $("#lbl_st").css("color", "#ff0000");
            }

        });

        //发生的可能性

        $("#ddlt_knx").blur(function () {

            if ($("#ddlt_knx option:selected").val() != "-1") {
                $("#lbl_knx").text("正确");
                $("#lbl_knx").css("color", "#00ff00");
            } else {
                $("#lbl_knx").text("请选择");
                $("#lbl_knx").css("color", "#ff0000");
            }

        });

        //后果的严重性

        $("#ddlt_yzx").blur(function () {

            if ($("#ddlt_yzx option:selected").val() != "-1") {
                $("#lbl_yzx").text("正确");
                $("#lbl_yzx").css("color", "#00ff00");
            } else {
                $("#lbl_yzx").text("请选择");
                $("#lbl_yzx").css("color", "#ff0000");
            }

        });
        //风险程度
        $("#ddlt_fxcd").blur(function () {

            if ($("#ddlt_fxcd option:selected").val() != "-1") {
                $("#lbl_fxcd").text("正确");
                $("#lbl_fxcd").css("color", "#00ff00");
            } else {
                $("#lbl_fxcd").text("请选择");
                $("#lbl_fxcd").css("color", "#ff0000");
            }

        });



        //状态

        $("#ddlt_zt").blur(function () {

            if ($("#ddlt_zt option:selected").val() != "-1") {
                $("#lbl_zt").text("正确");
                $("#lbl_zt").css("color", "#00ff00");
            } else {
                $("#lbl_zt").text("请选择");
                $("#lbl_zt").css("color", "#ff0000");
            }

        });




        //控 制 状 态

        $("#ddlt_kzzt").blur(function () {

            if ($("#ddlt_kzzt option:selected").val() != "-1") {
                $("#lbl_kzzt").text("正确");
                $("#lbl_kzzt").css("color", "#00ff00");
            } else {
                $("#lbl_kzzt").text("请选择");
                $("#lbl_kzzt").css("color", "#ff0000");
            }

        });
        //控制措施标准化情况 

        $("#ddlt_bzhqk").blur(function () {

            if ($("#ddlt_bzhqk option:selected").val() != "-1") {
                $("#lbl_bzhqk").text("正确");
                $("#lbl_bzhqk").css("color", "#00ff00");
            } 

        });

        //责任部门（二级）
        $("#ddlt_bmej").blur(function () {

            if ($("#ddlt_bmej option:selected").val() != "-1") {
                $("#lbl_bmej").text("正确");
                $("#lbl_bmej").css("color", "#00ff00");
            } 

        });
        //责任部门（三级）
        $("#ddlt_bmsj").blur(function () {

            if ($("#ddlt_bmsj option:selected").val() != "-1") {
                $("#lbl_bmsj").text("正确");
                $("#lbl_bmsj").css("color", "#00ff00");
            } 

        });
        //配合部门

        $("#ddlt_phbm").blur(function () {

            if ($("#ddlt_phbm option:selected").val() != "-1") {
                $("#lbl_phbm").text("正确");
                $("#lbl_phbm").css("color", "#00ff00");
            } 

        });
    });
</script>
<script src="../css/js/jquery.js" type="text/javascript"></script>
      <script type="text/javascript">
          //设置uedit 不可用
          var CheckF = $('#ChangeFlag').val();
          var ue1 = UE.getEditor('<%=tbx_yy.ClientID %>');
          var ue2 = UE.getEditor('<%=tbx_hg.ClientID %>');
          var ue3 = UE.getEditor('<%=tbx_xgal.ClientID %>');
          var ue4 = UE.getEditor('<%=tbx_ya.ClientID %>');
	  var ue5 = UE.getEditor('<%=tbx_yj.ClientID %>');
        //这里设置了一个监听器，每次页面刷新的时候都会执行，当标签changeFlag的值为1的时候，编辑器不可编辑
        ue1.addListener('ready', function () {
            if (CheckF == 'false') {
                ue.setDisabled();
            }
        });
        ue2.addListener('ready', function () {
            if (CheckF == 'false') {
                ue2.setDisabled();
            }
        });
        ue3.addListener('ready', function () {
            if (CheckF == 'false') {
                 ue3.setDisabled();
            }
        });
	ue4.addListener('ready', function () {
            if (CheckF == 'false') {
                 ue4.setDisabled();
            }
        });
	ue5.addListener('ready', function () {
            if (CheckF == 'false') {
                 ue5.setDisabled();
            }
        });
        //实例化编辑器
        var ue = UE.getEditor('tbx_yy');
        var ue2 = UE.getEditor('tbx_hg');
        var ue3 = UE.getEditor('tbx_xgal');
	    var ue4 = UE.getEditor('tbx_ya');
	    var ue5 = UE.getEditor('tbx_yj');
        //禁用编辑器
        function setDisabled() {
            UE.getEditor('editor').setDisabled('fullscreen');
            disableBtn("enable");
        }
        //启用编辑器
        function setEnabled() {
            UE.getEditor('editor').setEnabled();
            enableBtn();
        }
</script>
     <script type="text/javascript">  
    var login = document.getElementById('login');  //弹出层中的登录框
    var over = document.getElementById('over'); //弹出层
    function show()  
    {  
        login.style.display = "block";  
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
