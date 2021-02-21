<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YGCF_Edit.aspx.cs" Inherits="CUST.WKG.YGCF_Edit" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
      #login ,#login_1
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
   
    #over  ,#over_1
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
            <strong class="icon-reorder">员工惩罚添加</strong>
        </div>
    <table >            
       <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">责任人：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_fzr" runat="server" class="input-text"
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
                        <asp:Label ID="lbl_fzr" runat="server"></asp:Label>
                    </td>
                </tr> 
 

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   惩罚时间：<span class="c-red">*</span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_cfsj" runat="server" class="input-text" style="width:200px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_cfsj" runat="server" ></asp:Label></td>
            </tr>



        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">受罚人：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_sfr" runat="server" class="input-text"
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
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                            <asp:DropDownList ID="ddlt_bmdm1" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged1"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 岗位： 
                            <asp:DropDownList ID="ddlt_gwdm1" runat="server" AutoPostBack="True"
                                class="select-box" OnSelectedIndexChanged="ddlt_gwdm_SelectedIndexChanged1"
                                Style="width: 130px">
                            </asp:DropDownList>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 员工： 
                            <asp:DropDownList ID="ddlt_sfr" runat="server" class="select-box"
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
                                    ForeColor="White" OnClick="btn_bc_Click1" OnClientClick="hide_1()" Text="保存"
                                    Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_gb1" runat="server" BackColor="#60B1D7" class="btn  radius"
                                    ForeColor="White" OnClientClick="hide_1()" Text="关闭"
                                    Width="100px" />
                            </div>
                        </div>
                            <%-- 背景层--%>
                        <div id="over_1">
                        </div>
                        <asp:Label ID="lbl_sfr" runat="server"></asp:Label>
                    </td>
                </tr> 

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    事件种类：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_sjzl" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_sjzl" runat="server" ></asp:Label>
                    </td>
            </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">简要经历和原因 ：</td>
                <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:TextBox ID="tbx_jyjlhyy" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="75px" Width="450px" ClientIDMode="Static" MaxLength="100"></asp:TextBox>
                    <asp:Label ID="lbl_jyjlhyy" runat="server"></asp:Label>
                </td>
            </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">承担责任 ：</td>
                <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:TextBox ID="tbx_cdzr" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="75px" Width="450px" ClientIDMode="Static" MaxLength="100"></asp:TextBox>
                    <asp:Label ID="lbl_cdzr" runat="server"></asp:Label>
                </td>
            </tr>
                
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">处理意见 ：</td>
                <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:TextBox ID="tbx_clyj" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="75px" Width="450px" ClientIDMode="Static" MaxLength="100"></asp:TextBox>
                    <asp:Label ID="lbl_clyj" runat="server"></asp:Label>
                </td>
            </tr>

          <%--<tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
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
             <script type="text/javascript" src="../css/js/jquery.js"></script>
            <script type="text/javascript" src="../css/js/H-ui.admin.js"></script>
            <script type="text/javascript" src="../css/js/H-ui.js"></script>
</article>
    
</body>
    <script src="../../Content/js/jquery.js" type="text/javascript"></script>
      <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <script src="../css/js/jquery.js" type="text/javascript"></script>
      <script type="text/javascript">
          //设置uedit 不可用
          var CheckF = $('#ChangeFlag').val();
          var ue1 = UE.getEditor('<%=tbx_jyjlhyy.ClientID %>');
          var ue2 = UE.getEditor('<%=tbx_cdzr.ClientID %>');
          var ue3 = UE.getEditor('<%=tbx_clyj.ClientID %>');
          //这里设置了一个监听器，每次页面刷新的时候都会执行，当标签changeFlag的值为1的时候，编辑器不可编辑
          ue1.addListener('ready', function () {
              if (CheckF == 'false') {
                  ue1.setDisabled();
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

          //实例化编辑器
          var ue1 = UE.getEditor('tbx_jyjlhyy');
          var ue2 = UE.getEditor('tbx_cdzr');
          var ue3 = UE.getEditor('tbx_clyj');

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
     var login_1 = document.getElementById('login_1');  //弹出层中的登录框
     var over_1 = document.getElementById('over_1'); //弹出层
     function show_1() {
         login_1.style.display = "block";
         login_1.style.position = "absoulte";
         login_1.style.alignContent = "center";
         login_1.style.zIndex = "5555";
         login_1.style.top = (document.documentElement.clientHeight - login_1.offsetHeight) / 2 + "px";
         login_1.style.left = (document.documentElement.clientWidth - login_1.offsetWidth) / 2 + "px";
         over_1.style.display = "block";
         over.style.position = "absoulte";
         over.style.alignContent = "center";

     }
     $("#btn_bc_1").click(function () {
         hide_1();
     });
     function hide_1() {
         login_1.style.display = "none";
         over_1.style.display = "none";
     }
</script>

    <script type="text/javascript">


        var login_csr = document.getElementById('login_csr');  //弹出层中的登录框
        var over_csr = document.getElementById('over_csr'); //弹出层
        function show_csr() {
            login_csr.style.display = "block";
            login_csr.style.position = "absoulte";
            login_csr.style.alignContent = "center";
            login_csr.style.zIndex = "5555";
            login_csr.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
            login_csr.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
            over_csr.style.display = "block";
            over_csr.style.position = "absoulte";
            over_csr.style.alignContent = "center";
        }
        $("#btn_bc_3").click(function () {
            hide_csr();
        });
        function hide_csr() {
            login_csr.style.display = "none";
            over_csr.style.display = "none";
        }
</script> 


 <script type="text/javascript">

     var login_zsr = document.getElementById('login_zsr');  //弹出层中的登录框
     var over_zsr = document.getElementById('over_zsr'); //弹出层
     function show_zsr() {
         login_zsr.style.display = "block";
         login_zsr.style.position = "absoulte";
         login_zsr.style.alignContent = "center";
         login_zsr.style.zIndex = "5555";
         login_zsr.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
         login_zsr.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
         over_zsr.style.display = "block";
         over_zsr.style.position = "absoulte";
         over_zsr.style.alignContent = "center";
     }
     $("#btn_bc_4").click(function () {
         hide_zsr();
     });
     function hide_zsr() {
         login_zsr.style.display = "none";
         over_zsr.style.display = "none";

     }
 </script> 
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

    }
    $("#btn_bc").click(function () {
        hide();
    });
    function hide() {
        login.style.display = "none";
        over.style.display = "none";
    }
</script>
</html>
