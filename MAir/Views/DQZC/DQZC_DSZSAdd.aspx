<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DQZC_DSZSAdd.aspx.cs" Inherits="CUST.WKG.DQZC_DSZSAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">      
    <title>党史知识添加</title>
       <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />

     <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
       <script src="../css/js/jquery.js" type="text/javascript"></script>
       <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>
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
     <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
            }    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
      <table>    
     
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   发布人：</td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                    
                    <asp:Label ID="lbl_fbr" runat="server" ></asp:Label></td>
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   标题：<span class="c-red"></span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_bt" runat="server" class="input-text" style="width:200px" placeholder="标题" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_bt" runat="server" ></asp:Label></td>
            </tr>
          
        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">内容 ：<span class="c-red"></span></td>
                <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:TextBox ID="tbx_nr" name="tbx_ylnr" runat="server" TextMode="MultiLine" Height="120px" Width="550px" ClientIDMode="Static" placeholder="内容"></asp:TextBox>
                    <asp:Label ID="lbl_nr"   MaxLength="1900" runat="server"></asp:Label>
                </td>
            </tr>
       
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     发布时间：<span class="c-red"></span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="tbx_fbsj" runat="server" class="input-text" style="width:200px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_fbsj" runat="server" ></asp:Label></td>
            </tr>
       
    </table>
    <br/>
    <div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
                <td style="text-align:right">
                     <asp:Button ID="btn_bc" runat="server" Text="保存" class="btn radius"   BackColor="#ab2025" ForeColor="White"  Width="199px" OnClick="btn_bc_Click" >
                     </asp:Button>
                </td>            
                <td style="text-align:left"> &nbsp;&nbsp;
                     <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius"  BackColor="#ab2025" ForeColor="White"  Width="199px" OnClick="btn_fh_Click" >
                     </asp:Button>
                </td>
            </tr>
        </table>
	</div>
        <script src="../../Content/js/jquery.js" type="text/javascript"></script>
      <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
       <script type="text/javascript">
           $(document).ready(function () {
               //标题
               $("#tbx_bt").blur(function () {
                   if ($("#tbx_bt").val() != "") {
                       $("#lbl_bt").text("正确");
                       $("#lbl_bt").css("color", "#00ff00");
                   } else {
                       $("#lbl_bt").text("错误");
                       $("#lbl_bt").css("color", "#ff0000");
                   }
               });
               //内容
               $("#tbx_nr").blur(function () {
                   if ($("#tbx_nr").val() != "") {
                       $("#lbl_nr").text("正确");
                       $("#lbl_nr").css("color", "#00ff00");
                   } else {
                       $("#lbl_nr").text("错误");
                       $("#lbl_nr").css("color", "#ff0000");
                   }
               });
               //发布时间
               $("#tbx_fbsj").blur(function () {
                   if ($("#tbx_fbsj").val() != "") {
                       $("lbl_fbsj").text("正确");
                       $("#lbl_fbsj").css("color", "#00ff00");
                   } else {
                       $("#lbl_fbsj").text("错误");
                       $("#lbl_fbsj").css("color", "#ff0000");
                   }
               });
           });
       </script>
         <script src="../css/js/jquery.js" type="text/javascript"></script>
      <script type="text/javascript">
          //设置uedit 不可用
          var CheckF = $('#ChangeFlag').val();
          var ue1 = UE.getEditor('<%=tbx_nr.ClientID %>');

          //这里设置了一个监听器，每次页面刷新的时候都会执行，当标签changeFlag的值为1的时候，编辑器不可编辑
          ue1.addListener('ready', function () {
              if (CheckF == 'false') {
                  ue.setDisabled();
              }
          });

          //实例化编辑器
          var ue1 = UE.getEditor('tbx_nr');

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
        </form>
</asp:Content>