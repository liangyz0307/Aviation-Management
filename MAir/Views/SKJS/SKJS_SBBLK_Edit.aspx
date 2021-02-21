<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SKJS_SBBLK_Edit.aspx.cs" Inherits="CUST.WKG.SKJS_SBBLK_Edit" %>
<%@ Register TagPrefix="hw" Namespace="UNLV.IAP.WebControls" Assembly="DropDownCheckList" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
    <style type="text/css">
  
    #login_syr  
    {  
        display:none;  
        border:1em solid #e4e5e6;  
        height:150px;  
        width:200px;  
        position:absolute;/*让节点脱离文档流,我的理解就是,从页面上浮出来,不再按照文档其它内容布局*/  
        top:20%;/*节点脱离了文档流,如果设置位置需要用top和left,right,bottom定位*/  
        left:40%;  
        z-index:2;/*个人理解为层级关系,由于这个节点要在顶部显示,所以这个值比其余节点的都大*/  
        background: white;  
    }  
            td.td_sjsc
            {
                background:#F6FAFD;
            }    
    #login_wxry  
    {  
        display:none;  
        border:1em solid #e4e5e6;  
        height:150px;  
        width:200px;  
        position:absolute;/*让节点脱离文档流,我的理解就是,从页面上浮出来,不再按照文档其它内容布局*/  
        top:20%;/*节点脱离了文档流,如果设置位置需要用top和left,right,bottom定位*/  
        left:40%;  
        z-index:2;/*个人理解为层级关系,由于这个节点要在顶部显示,所以这个值比其余节点的都大*/  
        background: white;  
    }  
    #over  
    {  
        width: 100%;  
        height: 100%;  
        opacity:0.8;/*设置背景色透明度,1为完全不透明,IE需要使用filter:alpha(opacity=80);*/  
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
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
            
            <div class="panel-head">
                <strong class="icon-reorder">设备病例库修改</strong>
            </div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">设 备 名 称：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_sbmc" runat="server" class="input-text"
                            Width="446px" MaxLength="10" ></asp:TextBox>
                        <asp:Label ID="lbl_sbmc" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">地 点：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_dd" runat="server" class="input-text"
                            Width="446px" MaxLength="10" ></asp:TextBox>
                        <asp:Label ID="lbl_dd" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">使 用 岗 位：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_sygw" runat="server" class="input-text"
                            Width="446px" MaxLength="50"></asp:TextBox>
                        <asp:Label ID="lbl_sygw" runat="server"></asp:Label>
                    </td>

                </tr>
                
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">使 用 人：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_syr" runat="server" class="input-text"
                            Width="446px" MaxLength="3" Enabled="false"></asp:TextBox>
                        <a href="javascript:show_syr()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_syr">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                部门： 
                                  <asp:DropDownList ID="ddlt_bmdm" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged1"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                岗位： 
                                  <asp:DropDownList ID="ddlt_gwdm" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_gwdm_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                员工： 
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
                                <table>
                                    <tr>
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_bc_syr" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClick="btn_bc_syr_Click" OnClientClick="hide()" Text="保存"
                                                Width="100px" />
                                        </td >
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_gb" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClientClick="hide()" Text="关闭"
                                                Width="100px" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over">
                        </div>
                        <asp:Label ID="lbl_syr" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">使 用 年 限：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_synx" runat="server" class="input-text"
                            Width="446px" MaxLength="10" ></asp:TextBox>
                        <asp:Label ID="lbl_synx" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">故 障 时 间：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                        <asp:TextBox ID="tbx_gzsj" runat="server" class="Wdate" Height="20px" Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox>
                        <asp:Label ID="lbl_gzsj" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">现 象：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_xx" runat="server" class="input-text"
                            Width="446px" MaxLength="200"></asp:TextBox>
                        <asp:Label ID="lbl_xx" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">原 因：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_yy" runat="server" class="input-text"
                            Width="446px" MaxLength="200" ></asp:TextBox>
                        <asp:Label ID="lbl_yy" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">排 故 方 式：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_pgfs" runat="server" class="input-text"
                            Width="446px" MaxLength="5" ></asp:TextBox>
                        <asp:Label ID="lbl_pgfs" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">排 故 时 间：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_pgsj" runat="server" class="Wdate" Height="20px" Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox>
                        <asp:Label ID="lbl_pgsj" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">保 养 频 次：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_bypc" runat="server" Width="446px" ></asp:DropDownList>
                        <asp:Label ID="lbl_bypc" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">维 修 人 员：&nbsp;&nbsp;</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_wxry" runat="server" class="input-text"
                            Width="446px" MaxLength="200" Enabled="False"></asp:TextBox>
                        <a href="javascript:show_wxry()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_wxry">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                部门： 
                                  <asp:DropDownList ID="ddlt_bmdm_wxry" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged2"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                岗位： 
                                  <asp:DropDownList ID="ddlt_gwdm_wxry" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_gwdm_SelectedIndexChanged2"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                员工： 
                                  <asp:DropDownList ID="ddlt_wxry" runat="server" class="select-box"
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
                                <table>
                                    <tr>
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_bc_wxry" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClick="btn_bc_wxry_Click" OnClientClick="hide()" Text="保存"
                                                Width="100px" />
                                        </td >
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_tc" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClientClick="hide()" Text="关闭"
                                                Width="100px" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over">
                        </div>
                        <asp:Label ID="lbl_wxry" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备 注：&nbsp;&nbsp;</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bz" runat="server" class="input-text"
                            Width="446px" MaxLength="200" ></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
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

<script type="text/javascript">
    $("#btn_save").click(function () {

         //设备名称
        $("#tbx_sbmc").blur(function () {
            if ($("#tbx_sbmc").val().trim() == "") {
                $("#lbl_sbmc").text("内容不能为空");
                $("#lbl_sbmc").css("color", "#ff0000");
            }
            else {
                $("#lbl_sbmc").text("正确");
                $("#lbl_sbmc").css("color", "#00ff00");
            }
        });
        //使用年限
        $("#tbx_yjje").blur(function () {
            if ($("#tbx_synx").val().trim() == "") {
                $("#lbl_synx").text("内容不能为空");
                $("#lbl_synx").css("color", "#ff0000");
            }
            else {
                var nx = /^[0-9]+(\.[0-9]{0,2})?$/
                if (!nx.test($("#tbx_synx").val())) {
                    $("#lbl_synx").text("请输入整数");
                    $("#lbl_synx").css("color", "#ff0000");
                }
                else {
                    $("#lbl_synx").text("正确");
                    $("#lbl_synx").css("color", "#00ff00");
                }


            }
        });
        //保养频次
        $("#ddlt_bypc").blur(function () {
            if ($("#ddlt_bypc option:selected").val() != "-1") {
                $("#lbl_bypc").text("正确");
                $("#lbl_bypc").css("color", "#00ff00");
            }
            else {
                $("#lbl_bypc").text("请选择");
                $("#lbl_bypc").css("color", "#ff0000");
            }
        });
        //地点
        $("#tbx_dd").blur(function () {
            if ($("#tbx_dd").val().trim() == "") {
                $("#lbl_dd").text("内容不能为空");
                $("#lbl_dd").css("color", "#ff0000");
            }
            else {
                $("#lbl_dd").text("正确");
                $("#lbl_dd").css("color", "#00ff00");
            }
        });
        //使用岗位
        $("#tbx_sygw").blur(function () {
            if ($("#tbx_sygw").val().trim() == "") {
                $("#lbl_sygw").text("内容不能为空");
                $("#lbl_sygw").css("color", "#ff0000");
            }
            else {
                $("#lbl_sygw").text("正确");
                $("#lbl_sygw").css("color", "#00ff00");
            }
        });
        //使用人
        $("#tbx_syr").blur(function () {
            if ($("#tbx_syr").val().trim() == "") {
                $("#lbl_syr").text("内容不能为空");
                $("#lbl_syr").css("color", "#ff0000");
            }
            else {
                $("#lbl_syr").text("正确");
                $("#lbl_syr").css("color", "#00ff00");
            }
        });
        //故障时间
        $("#tbx_gzsj").blur(function () {
            if ($("#tbx_gzsj").val().trim() == "") {
                $("#lbl_gzsj").text("内容不能为空");
                $("#lbl_gzsj").css("color", "#ff0000");
            }
            else {
                var ys = /^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$/;
                if (!ys.test($("#tbx_gzsj").val())) {
                    $("#lbl_gzsj").text("请输入正确格式如（1996-01-02）");
                    $("#lbl_gzsj").css("color", "#ff0000");
                }
                else {
                    $("#lbl_gzsj").text("正确");
                    $("#lbl_gzsj").css("color", "#00ff00");
                }
            }
        });
        //现象
        $("#tbx_xx").blur(function () {
            if ($("#tbx_xx").val().trim() == "") {
                $("#lbl_yxx").text("内容不能为空");
                $("#lbl_xx").css("color", "#ff0000");
            }
            else {
                $("#lbl_xx").text("正确");
                $("#lbl_xx").css("color", "#00ff00");
            }
        });
        //原因
        $("#tbx_yy").blur(function () {
            if ($("#tbx_yy").val().trim() == "") {
                $("#lbl_yy").text("内容不能为空");
                $("#lbl_yy").css("color", "#ff0000");
            }
            else {
                $("#lbl_yy").text("正确");
                $("#lbl_yy").css("color", "#00ff00");
            }
        });
        //排故方式
        $("#tbx_pgfs").blur(function () {
            if ($("#tbx_pgfs").val().trim() == "") {
                $("#lbl_pgfs").text("内容不能为空");
                $("#lbl_pgfs").css("color", "#ff0000");
            }
            else {
                $("#lbl_pgfs").text("正确");
                $("#lbl_pgfs").css("color", "#00ff00");
            }
        });
        //排故时间
        $("#tbx_pgsj").blur(function () {
            if ($("#tbx_pgsj").val() == "") {
                $("#lbl_pgsj").text("内容不能为空");
                $("#lbl_pgsj").css("color", "#ff0000");
            }
            else {
                if ($("#tbx_pgsj").val() == "") {
                    $("#lbl_pgsj").text("完成时间不能为空");
                    $("#lbl_pgsj").css("color", "#ff0000")
                }
                else {
                    var gzsj = $("#tbx_gzsj").val().trim();
                    var pgsj = $("#tbx_pgsj").val().trim();


                    if (new Date(wxrq.replace(/\-/g, '\/')) > new Date(djrq.replace(/\-/g, '\/'))) {
                        $("#lbl_pgsj").text("日期小于维修日期");
                        $("#lbl_pgsj").css("color", "#ff0000")
                    }
                    else {
                        $("#lbl_pgsj").text("正确");
                        $("#lbl_pgsj").css("color", "#00ff00");
                    }

                }
            }
        });
        //维修人员
        $("#tbx_wxry").blur(function () {
            if ($("#tbx_wxry").val().trim() == "") {
                $("#lbl_wxry").text("内容不能为空");
                $("#lbl_wxry").css("color", "#ff0000");
            }
            else {
                $("#lbl_wxry").text("正确");
                $("#lbl_wxry").css("color", "#00ff00");
            }
        });
        //备注
        $("#tbx_bz").blur(function () {
                $("#lbl_bz").text("正确");
                $("#lbl_bz").css("color", "#00ff00");
            
        });

    });
</script>
<script type="text/javascript">  
    var login_syr = document.getElementById('login_syr');  //弹出层中的登录框
    var login_wxyr = document.getElementById('login_wxry');
    var over = document.getElementById('over'); //弹出层
    function show_syr()  
    {  
        login_syr.style.display = "block";  
        over.style.display = "block";
    }
    function show_wxry() {
        login_wxry.style.display = "block";
        over.style.display = "block";
    }
    function btn_bc_syr()
    {
        btn_syr.style.display = "block";
    }
    $("#btn_bc_syr").click(function ()
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