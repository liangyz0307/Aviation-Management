<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YLGL_Add.aspx.cs" Inherits="CUST.WKG.YLGL_Add" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>危险源</title>
     <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
        <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
      <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <%--   UEdit--%>
      <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.config.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.all.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/lang/zh-cn/zh-cn.js" charset="utf-8"></script>
         <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>
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
            td.td_sjsc
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
    <form id="form1" runat="server" class="form form-horizontal">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <table>
      <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc"> 
          <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">预案名：<span class="c-red">*</span></td>
          <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
              <asp:DropDownList ID="ddlt_yam" runat="server" Width="446px" placeholder="预案名" DataTextField="mc" DataValueField="sjc"></asp:DropDownList>
              <asp:Label ID="lbl_yam" runat="server" ></asp:Label>
          </td>
       </tr>
       
         <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc"> 
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">支线名称：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zxmc" runat="server" Width="446px" placeholder="支线名称" ></asp:DropDownList>
                        <asp:Label ID="lbl_zxmc" runat="server"></asp:Label>
                    </td>
       </tr>

        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc"> 
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">演练形式：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_ylxs" runat="server" Width="446px" placeholder="演练形式"></asp:DropDownList>
                        <asp:Label ID="lbl_ylxs" runat="server" ></asp:Label>
                    </td>
       </tr>

        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc"> 
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">演练时间：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_ylsj" runat="server" class="input-text" placeholder="演练时间"
                            Width="446px" MaxLength="50" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Height="20px"></asp:TextBox>
                        <asp:Label ID="lbl_ylsj" runat="server"></asp:Label>
                    </td>
       </tr>
                  <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <td style="width: 10%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">参与人员：</td>
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
        </tr>

         <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc"> 
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">演练内容：</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_ylnr" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="200px" Width="450px" ClientIDMode="Static" OnTextChanged="tbx_ylnr_TextChanged" ></asp:TextBox>
                        <asp:Label ID="lbl_ylnr" runat="server" ></asp:Label>
                    </td>
       </tr>

         <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc"> 
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">演练总结：</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_ylzj" name="tbx_ylzj" runat="server" TextMode="MultiLine" Height="200px" Width="450px" ClientIDMode="Static" ></asp:TextBox>
                        <asp:Label ID="lbl_ylzj" runat="server" ></asp:Label>
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
	     <div class="row cl" style="text-align: center; width: 45%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: left">
			    <asp:Button ID="btn_save" runat="server" Text="保存" 
                    class="btn  radius"  BackColor="#60B1D7"  ForeColor="White" Width="199px" OnClick="btn_save_Click"></asp:Button>
                <asp:Button ID="btn_fh" runat="server" Text="返回" 
                    class="btn  radius" Width="199px"  BackColor="#60B1D7"  ForeColor="White" OnClick="btn_fh_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
        </div>
    </form> 
    </article>
    </body>
  <script src="../css/js/jquery.js" type="text/javascript"></script>
      <script type="text/javascript">
          //设置uedit 不可用
          var CheckF = $('#ChangeFlag').val();
          var ue1 = UE.getEditor('<%=tbx_ylnr.ClientID %>');
          var ue2 = UE.getEditor('<%=tbx_ylzj.ClientID %>');
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

        //实例化编辑器
        var ue = UE.getEditor('tbx_ylnr');
        var ue2 = UE.getEditor('tbx_ylzj');
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
<script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
<%--<script type="text/javascript">
    $(document).ready(function () {
        //预案名
	$("#ddlt_yam").blur(function () {

                if ($("#ddlt_yam option:selected").val() != "-1") {
                    $("#lbl_yam").text("正确");  
                    $("#lbl_yam").css("color", "#00ff00");
                } else {
                    $("#lbl_yam").text("请选择");
                    $("#lbl_yam").css("color", "#ff0000");
                }

            });
        //演练形式
        $("#ddlt_ylxs").blur(function () {

                if ($("#ddlt_ylxs option:selected").val() != "-1") {
                    $("#lbl_ylxs").text("正确");  
                    $("#lbl_ylxs").css("color", "#00ff00");
                } else {
                    $("#lbl_ylxs").text("请选择");
                    $("#lbl_ylxs").css("color", "#ff0000");
                }

            });

        //演练时间
        $("#tbx_ylsj").blur(function() {
                if ($("#tbx_ylsj").val() != "") {
                    $("#lbl_ylsj").text("正确");
                    $("#lbl_ylsj").css("color", "#00ff00");
                } else {
                $("#lbl_ylsj").text("时间不能为空");
                $("#lbl_ylsj").css("color", "#ff0000");
                }
            });


        //支线名称

        $("#ddlt_zxmc").blur(function () {

                if ($("#ddlt_zxmc option:selected").val() != "-1") {
                    $("#lbl_zxmc").text("正确");  
                    $("#lbl_zxmc").css("color", "#00ff00");
                } else {
                    $("#lbl_zxmc").text("请选择");
                    $("#lbl_zxmc").css("color", "#ff0000");
                }

            });

      
        //演练内容
        $("#tbx_ylnr").blur(function () {
        if ($("#tbx_ylnr").val() != "") {
            $("#lbl_ylnr").text("正确");
            $("#lbl_ylnr").css("color", "#00ff00");
        } 
        });
	
	//参与人员
        $("#tbx_syr").blur(function () {
        if ($("#tbx_syr").val() != "") {
            $("#lbl_syr").text("正确");
            $("#lbl_syr").css("color", "#00ff00");
        } 
        });

        //演练总结
        $("#tbx_ylzj").blur(function () {
            if ($("#tbx_ylzj").val() != "") {
                $("#lbl_ylzj").text("正确");
                $("#lbl_ylzj").css("color", "#00ff00");
            }
        });

 
    });
</script>--%>
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