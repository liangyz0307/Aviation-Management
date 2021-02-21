<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DQZC_DYZXEdit.aspx.cs" Inherits="CUST.WKG.DQZC_DYZXEdit" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title>党员在线添加</title>
      <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
       <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />
       <script src="../css/js/jquery.js" type="text/javascript"></script>
       <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>
     <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
       <%--   UEdit--%>
      <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.config.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.all.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/lang/zh-cn/zh-cn.js" charset="utf-8"></script>
         <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>
         <script type="text/javascript" src="../../Content/js/jquery.js"></script>     
     <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
            }    
    </style>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="panel-head">
            <strong class="icon-reorder">优秀党员编辑</strong>
        </div>
      <table>  
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   员 工 编 号：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                    <asp:Label ID="lbl_ygbh" runat="server" ></asp:Label>
                </td>
            </tr>  
     
         <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">优秀党员：</td>
                <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_yxdy" runat="server" class="input-text"
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
                            <asp:DropDownList ID="ddlt_yxdy" runat="server" class="select-box"
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
                                <asp:Button ID="Button1" runat="server" BackColor="#60B1D7" class="btn  radius"
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
                        <asp:Label ID="lbl_yxdy" runat="server"></asp:Label>
                    </td>
                </tr> 
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   时间：<span class="c-red"></span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_sj" runat="server" class="input-text" style="width:200px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_sj" runat="server" ></asp:Label></td>
            </tr>
 
       <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">主要事迹 ：</td>
                <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:TextBox ID="tbx_zysj" name="tbx_ylnr" runat="server" TextMode="MultiLine"  MaxLength="2500" Height="120px" Width="550px" ClientIDMode="Static"></asp:TextBox>
                    <asp:Label ID="lbl_zysj" runat="server"></asp:Label>
                </td>
            </tr>
        
    </table>
    <br/>
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
    <input id="ChangeFlag" runat="server" type="hidden" />
	</div>  
        </form>
     <script src="../../Content/js/jquery.js" type="text/javascript"></script>
      <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
       <script type="text/javascript">
           $(document).ready(function () {

               //主要事迹
               $("#tbx_zysj").blur(function () {
                   if ($("#tbx_zysj").val() != "") {
                       $("#tbx_zysj").text("正确");
                       $("#tbx_zysj").css("color", "#00ff00");
                   } else {
                       $("#tbx_zysj").text("错误");
                       $("#tbx_zysj").css("color", "#ff0000");
                   }
               });
              
               //优秀党员
               $("#ddlt_yxdy").change(function () {
                   if ($("#ddlt_yxdy option:selected").val() != "-1") {
                       $("#lbl_yxdy").text("正确");
                       $("#lbl_yxdy").css("color", "#00ff00");
                   } else {
                       $("#lbl_yxdy").text("请选择");
                       $("#lbl_yxdy").css("color", "#ff0000");
                   }
               });
           })</script> 
    <script src="../css/js/jquery.js" type="text/javascript"></script>
      <script type="text/javascript">
          //设置uedit 不可用
          var CheckF = $('#ChangeFlag').val();
          var ue1 = UE.getEditor('<%=tbx_zysj.ClientID %>');
          //这里设置了一个监听器，每次页面刷新的时候都会执行，当标签changeFlag的值为1的时候，编辑器不可编辑
          ue1.addListener('ready', function () {
              if (CheckF == 'false') {
                  ue.setDisabled();
              }
          });

          //实例化编辑器
          var ue1 = UE.getEditor('tbx_zysj');

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
         login_1.style.top = (document.documentElement.clientHeight - login_1.offsetHeight) / 2 + "px";
         login_1.style.left = (document.documentElement.clientWidth - login_1.offsetWidth) / 2 + "px";
         over_1.style.display = "block";

     }
     $("#btn_bc_1").click(function () {
         hide_1();
     });
     function hide_1() {
         login_1.style.display = "none";
         over_1.style.display = "none";
     }
</script>
</asp:Content>
