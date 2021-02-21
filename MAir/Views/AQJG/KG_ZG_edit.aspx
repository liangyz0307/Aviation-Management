<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KG_ZG_edit.aspx.cs" Inherits="CUST.WKG.KG_ZG_edit" %>

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
      <script type="text/javascript" src="../../UEdit/utf8-net/AQJG.config.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.all.min.js"  charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/lang/zh-cn/zh-cn.js" charset="utf-8"></script>
         <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>
         <script type="text/javascript" src="../../Content/js/jquery.js"></script>
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
            <strong class="icon-reorder">员工整改编辑</strong>
        </div>
    <table >
        <tr>
          <td style=" width:16%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   编 号：</td>
                <td colspan="2" style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:Label ID="lbl_id" runat="server" ></asp:Label>
                      </td>
            </tr>
         <tr style="vertical-align: top;  width:100%;border:1px solid #C0D9D9;" class="td_zgxm">
            <td style=" text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" width="30%" class="auto-style2">
                   检查单：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="auto-style3"> 
                    <asp:DropDownList ID="ddlt_jcd" runat="server" Width="532px" AutoPostBack="True"  Enabled="False"></asp:DropDownList>
                    <asp:Label ID="lbl_jcd" runat="server" ></asp:Label></td>
            </tr>
         <tr style="vertical-align: top;  width:100%;border:1px solid #C0D9D9;" class="td_zgxm">
            <td style=" text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" width="30%" class="auto-style2">
                   整改项目：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="auto-style3"> 
                    <asp:TextBox ID="tbx_zgxm" runat="server" Enabled="False" Width="518px"></asp:TextBox>
                    <asp:Label ID="lbl_zgxm" runat="server" ></asp:Label></td>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_zgsx">
            <td style=" text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="auto-style1">
                   整改时限：<span class="c-red">*</span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_zgsx"> 
                      <asp:TextBox ID="tbx_zgsx" runat="server" class="input-text" style="width:200px" placeholder="整改时限" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_zgsx" runat="server" ></asp:Label></td>
            </tr>



   <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">责任人：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_zrr" runat="server" class="input-text"
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
                            <asp:DropDownList ID="ddlt_zrr" runat="server" class="select-box"
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
                        <asp:Label ID="lbl_zrr" runat="server"></asp:Label>
                    </td>
                </tr> 

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_zgsx">
            <td style=" text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="auto-style1">
                   上传文件：<span class="c-red">*</span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_zgsx"> 
                     
                    <asp:FileUpload ID="fiup_wj" runat="server" />
                     <%--<asp:Button ID="btn_sc" runat="server" 
                Text="上传" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="80px" OnClick="btn_sc_Click"  ></asp:Button>--%> 
                </td>
            </tr>

                    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_wtly">
                <td style=" text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="auto-style1">
                   问题来源：<span class="c-red">*</span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_wtly"> 
                      <asp:TextBox ID="tbx_wtly" runat="server" class="input-text" style="resize:none;" placeholder="问题来源" TextMode="MultiLine" Height="44px" Width="431px"  
                 ></asp:TextBox>
                    <asp:Label ID="lbl_wtly" runat="server" ></asp:Label></td>
            </tr>


        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_wtlb">
            <td style=" text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="auto-style1">
                   问题类别：<span class="c-red">*</span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_wtlb"> 
                      <asp:TextBox ID="tbx_wtlb" runat="server" class="input-text" style="resize:none;" placeholder="问题类别" TextMode="MultiLine" Height="54px" Width="431px"  
                 ></asp:TextBox>
                    <asp:Label ID="lbl_wtlb" runat="server" ></asp:Label></td>
            </tr>
          <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 18%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改方案 ：<span class="c-red">*</span></td></td>
                <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:TextBox ID="tbx_zgfa" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="120px" Width="637px" ClientIDMode="Static"></asp:TextBox>
                    <asp:Label ID="lbl_zgfa" runat="server"></asp:Label>
                </td>
            </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 18%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改进度 ：<span class="c-red">*</span></td></td>
                <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:TextBox ID="tbx_zgjd" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="120px" Width="638px" ClientIDMode="Static"></asp:TextBox>
                    <asp:Label ID="lbl_zgjd" runat="server"></asp:Label>
                </td>
            </tr>
                
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 18%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">风险控制措施 ：<span class="c-red">*</span></td></td>
                <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:TextBox ID="tbx_fxkzcs" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="120px" Width="637px" ClientIDMode="Static"></asp:TextBox>
                    <asp:Label ID="lbl_fxkzcs" runat="server"></asp:Label>
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
       <script type="text/javascript">
           $(document).ready(function () {
               //整改时限
               $("#tbx_zgsx").blur(function () {
                   if ($("#tbx_zgsx").val() != "") {
                       $("#lbl_zgsx").text("正确");
                       $("#lbl_zgsx").css("color", "#00ff00");
                   } else {
                       $("#lbl_zgsx").text("错误");
                       $("#lbl_zgsx").css("color", "#ff0000 ");
                   }
               });
               //责任人
               $("#tbx_zrr").blur(function () {
                   if ($("#tbx_zrr").val() != "") {
                       $("#lbl_zrr").text("正确");
                       $("#lbl_zrr").css("color", "#00ff00");
                   } else {
                       $("#lbl_zrr").text("错误");
                       $("#lbl_zrr").css("color", "#ff0000");
                   }
               });
               //整改方案
               $("#tbx_zgfa").blur(function () {
                   if ($("#tbx_zgfa").val() != "") {
                       $("#lbl_zgfa").text("正确");
                       $("#lbl_zgfa").css("color", "#00ff00");
                   } else {
                       $("#lbl_zgfa").text("错误");
                       $("#lbl_zgfa").css("color", "#ff0000");
                   }
               });
               //整改进度
               $("#tbx_zgjd").blur(function () {
                   if ($("#tbx_zgjd").val() != "") {
                       $("#lbl_zgjd").text("正确");
                       $("#lbl_zgjd").css("color", "#00ff00");
                   } else {
                       $("#lbl_zgjd").text("错误");
                       $("#lbl_zgjd").css("color", "#ff0000");
                   }
               });

               //风险控制措施
               $("#tbx_fxkzcs").blur(function () {
                   if ($("#tbx_fxkzcs").val() != "") {
                       $("#lbl_fxkzcs").text("正确");
                       $("#lbl_fxkzcs").css("color", "#00ff00");
                   } else {
                       $("#lbl_fxkzcs").text("错误");
                       $("#lbl_fxkzcs").css("color", "#ff0000");
                   }
               });
               //问题来源
               $("#tbx_wtly").change(function () {
                   if ($("#tbx_wtly option:selected").val() != "-1") {
                       $("#lbl_wtly").text("正确");
                       $("#lbl_wtly").css("color", "#00ff00");
                   } else {
                       $("#lbl_wtly").text("请选择");
                       $("#lbl_wtly").css("color", "#ff0000");
                   }
               });

               //问题类别
               $("#tbx_wtlb").change(function () {
                   if ($("#tbx_wtlb option:selected").val() != "-1") {
                       $("#lbl_wtlb").text("正确");
                       $("#lbl_wtlb").css("color", "#00ff00");
                   } else {
                       $("#lbl_wtlb").text("请选择");
                       $("#lbl_wtlb").css("color", "#ff0000");
                   }
               });

           });
  </script> 
    <script src="../css/js/jquery.js" type="text/javascript"></script>
      <script type="text/javascript">
          //设置uedit 不可用
          var CheckF = $('#ChangeFlag').val();
          var ue1 = UE.getEditor('<%=tbx_zgfa.ClientID %>');
          var ue2 = UE.getEditor('<%=tbx_zgjd.ClientID %>');
          var ue3 = UE.getEditor('<%=tbx_fxkzcs.ClientID %>');
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

          //实例化编辑器
          var ue1 = UE.getEditor('tbx_zgfa');
          var ue2 = UE.getEditor('tbx_zgjd');
          var ue3 = UE.getEditor('tbx_fxkzcs');

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
         function show() {
             login.style.display = "block";
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



