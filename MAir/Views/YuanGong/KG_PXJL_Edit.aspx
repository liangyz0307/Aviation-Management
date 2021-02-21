<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KG_PXJL_Edit.aspx.cs" Inherits="CUST.WKG.KG_PXJL_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
      <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
          <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.config.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.all.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/lang/zh-cn/zh-cn.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>
      <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
        #login_pxs,#login_sjyz, #login_fzr 
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
            <div class="panel-head">
            <strong class="icon-reorder">员工培训记录编辑</strong>
 </div>
        <table>
                        <asp:HiddenField ID="sjyzHiddenField" runat="server" />  
           <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                     <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">受教育者：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_sjyz" runat="server" class="input-text"
                    Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                <a href="javascript:show_sjyz()">
                    <img alt="" src="../../Content/images/add.png" /></a>
                    <%--   填写内容层  --%>
                <div id="login_sjyz">
                    <table>
                        <tr class="td_sjsc"
                            style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                            <td class="td_sjsc" colspan="2"
                                style="width: 60%; text-align: left; vertical-align: middle;">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_sjyzbmdm" runat="server" AutoPostBack="True"
                                class="select-box" 
                                Style="width: 130px" OnSelectedIndexChanged="ddlt_sjyzbmdm_SelectedIndexChanged" >
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 岗位： 
                            <asp:DropDownList ID="ddlt_sjyzgwdm" runat="server" AutoPostBack="True"
                                class="select-box" 
                                Style="width: 130px" OnSelectedIndexChanged="ddlt_sjyzgwdm_SelectedIndexChanged">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 员工： 
                            <asp:DropDownList ID="ddlt_sjyz" runat="server" class="select-box"
                                Style="width: 130px" >
                            </asp:DropDownList>
                                        <br />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                           </table>
                            <br />
                            <div style="text-align: center">
                                <asp:Button ID="Button1" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc_Click_sjyz" OnClientClick="hide()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button2" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                            <%-- 背景层--%>
                        <div id="over">
                        </div>
                        <asp:Label ID="lbl_sjyz" runat="server"></asp:Label>
                    </td>
                </tr>
            <asp:HiddenField ID="fzrHiddenField" runat="server" />  
             <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">负责人：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_fzr" runat="server" class="input-text"
                    Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                <a href="javascript:show_fzr()">
                    <img alt="" src="../../Content/images/add.png" /></a>
                    <%--   填写内容层  --%>
                <div id="login_fzr">
                    <table>
                        <tr class="td_sjsc"
                            style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                            <td class="td_sjsc" colspan="2"
                                style="width: 60%; text-align: left; vertical-align: middle;">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_fzrbmdm" runat="server" AutoPostBack="True"
                                class="select-box" 
                                Style="width: 130px" OnSelectedIndexChanged="ddlt_fzrbmdm_SelectedIndexChanged" >
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 岗位： 
                            <asp:DropDownList ID="ddlt_fzrgwdm" runat="server" AutoPostBack="True"
                                class="select-box" 
                                Style="width: 130px" OnSelectedIndexChanged="ddlt_fzrgwdm_SelectedIndexChanged" >
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 员工： 
                            <asp:DropDownList ID="ddlt_fzr" runat="server" class="select-box"
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
                                <asp:Button ID="Button3" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClick="btn_bc_Click_fzr" OnClientClick="hide()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button4" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                            <%-- 背景层--%>
                        <div id="over">
                        </div>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>

                        <asp:HiddenField ID="pxsHiddenField" runat="server" />  
           <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">培训师：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_pxs" runat="server" class="input-text"
                    Width="446px" MaxLength="3" Enabled="false" Height="20px"></asp:TextBox>
                <a href="javascript:show_pxs()">
                    <img alt="" src="../../Content/images/add.png" /></a>
                    <%--   填写内容层  --%>
                <div id="login_pxs">
                    <table>
                        <tr class="td_sjsc"
                            style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                            <td class="td_sjsc" colspan="2"
                                style="width: 60%; text-align: left; vertical-align: middle;">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_pxsbmdm" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_pxsbmdm_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 岗位： 
                            <asp:DropDownList ID="ddlt_pxsgwdm" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_pxsgwdm_SelectedIndexChanged"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 员工： 
                            <asp:DropDownList ID="ddlt_pxs" runat="server" class="select-box"
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
                                    ForeColor="White" OnClick="btn_bc_Click_pxs" OnClientClick="hide()" Text="保存"
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
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr> 
        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    事件类型：<span class="c-red">*</span></td>
   <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_type" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_type" runat="server" ></asp:Label>
                    </td>
                </tr>
           <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">日期：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_rqsj" runat="server" class="input-text" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                            Width="446px" MaxLength="10" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_rqsj" runat="server"></asp:Label>
                    </td>
                </tr>
           <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">学时：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_xs" runat="server" class="input-text"
                            Width="446px" MaxLength="10"  Enabled="True" ></asp:TextBox>
                        <asp:Label ID="lbl_xs" runat="server"></asp:Label>
                    </td>
                </tr>
             <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">教学内容：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_jxnr" runat="server" ClientIDMode="Static" Height="120px" name="tbx_jxnr" TextMode="MultiLine" Width="550px"></asp:TextBox>
                  <asp:Label ID="lbl_jxnr" runat="server"></asp:Label>
                          </td>
                </tr>
           <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">课时：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_ks" runat="server" class="input-text"
                            Width="446px" MaxLength="10" onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;" Enabled="True"></asp:TextBox>
                        <asp:Label ID="lbl_ks" runat="server"></asp:Label>
                    </td>
                </tr>
           <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                   <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    级别：<span class="c-red">*</span></td>
   <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_jb" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_jb" runat="server" ></asp:Label>
                    </td>
                </tr>


           <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">考核方式：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_khfs" runat="server" class="input-text"
                            Width="446px" MaxLength="10" Enabled="True"></asp:TextBox>
                        <asp:Label ID="lbl_khfs" runat="server"></asp:Label>
                    </td>
                </tr>
           <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                  <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    考核结果：<span class="c-red">*</span></td>
   <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_khjg" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_khjg" runat="server" ></asp:Label>
                    </td>
                </tr>


                      <%--  <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    数据所在部门：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_sjszbm" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_sjszbm" runat="server" ></asp:Label>
                    </td>
            </tr>--%>


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
</body>
         <script type="text/javascript">  
             var login_pxs = document.getElementById('login_pxs');  //弹出层中的登录框
             var login_sjyz = document.getElementById('login_sjyz');  //弹出层中的登录框
             var login_fzr = document.getElementById('login_fzr');  //弹出层中的登录框
    var over = document.getElementById('over'); //弹出层
    function show_pxs()
    {
        pxsHiddenField.Value = 1;
        login_pxs.style.display = "block";
        over.style.display = "block";
    }
    function show_sjyz() {
        sjyzHiddenField.Value = 1;
        login_sjyz.style.display = "block";
        over.style.display = "block";
    }
    function show_fzr() {
        fzrHiddenField.Value = 1;
        login_fzr.style.display = "block";
        over.style.display = "block";
    }
    function btn_bc_Click_pxs()
    {
        btn_syr.style.display = "block";
    }
    $("#btn_bc_Click_pxs").click(function ()
    {
        hide();
    });
    function btn_bc_Click_sjyz() {
        btn_syr.style.display = "block";
    }
    $("#btn_bc_Click_sjyz").click(function () {
        hide();
    });
    function btn_bc_Click_fzr() {
        btn_syr.style.display = "block";
    }
    $("#btn_bc_Click_fzr").click(function () {
        hide();
    });
    function hide()  
    {
        pxs.style.display = "none";
        over.style.display = "none";
    } 

</script> 
      <%-- <script type="text/javascript">
           //类型
           $("#ddlt_type").change(function () {
               if ($("#ddlt_type option:selected").val() != "-1") {
                   $("#lbl_type").text("正确");
                   $("#lbl_type").css("color", "#00ff00");
               } else {
                   $("#lbl_type").text("请选择");
                   $("#lbl_type").css("color", "#ff0000");
               }
           });
           //日期
           $("#tbx_rqsj").blur(function () {
               if ($("#tbx_rqsj").val() != "") {
                   $("#lbl_rqsj").text("正确");
                   $("#lbl_rqsj").css("color", "#00ff00");
               } else {
                   $("#lbl_rqsj").text("错误");
                   $("#lbl_rqsj").css("color", "#ff0000");
               }
           });
           //学时
           $("#tbx_xs").blur(function () {
               if ($("#tbx_xs").val() != "") {
                   $("#lbl_xs").text("正确");
                   $("#lbl_xs").css("color", "#00ff00");
               } else {
                   $("#lbl_xs").text("错误");
                   $("#lbl_xs").css("color", "#ff0000");
               }
           });
           //课时
           $("#tbx_ks").blur(function () {
               if ($("#tbx_ks").val() != "") {
                   $("#lbl_ks").text("正确");
                   $("#lbl_ks").css("color", "#00ff00");
               } else {
                   $("#lbl_ks").text("错误");
                   $("#lbl_ks").css("color", "#ff0000");
               }
           });
           //级别
           $("#ddlt_jb").change(function () {
               if ($("#ddlt_jb option:selected").val() != "-1") {
                   $("#lbl_jb").text("正确");
                   $("#lbl_jb").css("color", "#00ff00");
               } else {
                   $("#lbl_jb").text("请选择");
                   $("#lbl_jb").css("color", "#ff0000");
               }
           });
           //培训师
           $("#tbx_pxs").blur(function () {
               if ($("#tbx_pxs").val() != "") {
                   $("#lbl_pxs").text("正确");
                   $("#lbl_pxs").css("color", "#00ff00");
               } else {
                   $("#lbl_pxs").text("错误");
                   $("#lbl_pxs").css("color", "#ff0000");
               }
           });
           //考核方式
           $("#tbx_khfs").blur(function () {
               if ($("#tbx_khfs").val() != "") {
                   $("#lbl_khfs").text("正确");
                   $("#lbl_khfs").css("color", "#00ff00");
               } else {
                   $("#lbl_khfs").text("错误");
                   $("#lbl_khfs").css("color", "#ff0000");
               }
           });
           //考核结果
           $("#ddlt_khjg").change(function () {
               if ($("#ddlt_khjg option:selected").val() != "-1") {
                   $("#lbl_khjg").text("正确");
                   $("#lbl_khjg").css("color", "#00ff00");
               } else {
                   $("#lbl_khjg").text("请选择");
                   $("#lbl_khjg").css("color", "#ff0000");
               }
           });
           //受教育者
           $("#tbx_sjyz").blur(function () {
               if ($("#tbx_sjyz").val() != "") {
                   $("#lbl_sjyz").text("正确");
                   $("#lbl_sjyz").css("color", "#00ff00");
               } else {
                   $("#lbl_sjyz").text("错误");
                   $("#lbl_sjyz").css("color", "#ff0000");
               }
           });
           //负责人
           $("#tbx_fzr").blur(function () {
               if ($("#tbx_fzr").val() != "") {
                   $("#lbl_fzr").text("正确");
                   $("#lbl_fzr").css("color", "#00ff00");
               } else {
                   $("#lbl_fzr").text("错误");
                   $("#lbl_fzr").css("color", "#ff0000");
               }
           });
</script> --%>
      <script src="../css/js/jquery.js" type="text/javascript"></script>
          <script type="text/javascript">
          //设置uedit 不可用
          var CheckF = $('#ChangeFlag').val();
          var ue1 = UE.getEditor('<%=tbx_jxnr.ClientID %>');
        //这里设置了一个监听器，每次页面刷新的时候都会执行，当标签changeFlag的值为1的时候，编辑器不可编辑
        ue1.addListener('ready', function () {
            if (CheckF == 'false') {
                ue1.setDisabled();
            }
        });

        //实例化编辑器
        var ue1 = UE.getEditor('tbx_jxnr');

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
</html>