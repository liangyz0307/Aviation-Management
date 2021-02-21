<%@ Page Language="C#"MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DQZC_ZZJGAdd.aspx.cs" Inherits="CUST.WKG.DQZC_ZZJGAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">      
    <title>组织结构信息添加</title>
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
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 
class="td_sjsc">
                    党组织名称：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 
class="td_sjsc">  
                   <asp:TextBox ID="tbx_dzzmc" runat="server" class="input-text" placeholder="党组织名称" 
style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_dzzmc" runat="server" ></asp:Label>
                    </td>
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 
class="td_sjsc">
                    基层党支部名称：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 
class="td_sjsc">  
                   <asp:TextBox ID="tbx_jcdzbmc" runat="server" class="input-text" placeholder="基层党支部名称" 
style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_jcdzbmc" runat="server" ></asp:Label>
                    </td>
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 
class="td_sjsc">
                    党小组名称：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 
class="td_sjsc">  
                   <asp:TextBox ID="tbx_dxzmc" runat="server" class="input-text" placeholder="党小组名称" 
style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_dxzmc" runat="server" ></asp:Label>
                    </td>
            </tr>
 
    </table>
    <br/>
   <div class="row cl">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
		    <asp:Button ID="btn_Add" runat="server" 
                Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="199px" OnClick="btn_save_Click"  ></asp:Button> 
            &nbsp; 
            <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_fh_Click"   ></asp:Button> 
		</div>
	</div>
       <script src="../../Content/js/jquery.js" type="text/javascript"></script>
      <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
       <script type="text/javascript">
           $(document).ready(function () {

              
               
               //党组织名称  
               $("#tbx_dzzmc").blur(function () {
                   if ($("#lbl_dzzmc").val() != "") {
                       $("#lbl_dzzmc").text("正确");
                       $("#lbl_dzzmc").css("color", "#00ff00");
                   } else {
                       $("#lbl_dzzmc").text("错误!不能为空");
                       $("#lbl_dzzmc").css("color", "#ff0000");
                   }
               });
               //基层党支部名称
               $("#tbx_jcdzbmc").change(function () {
                   if ($("#ddlt_jcdzbmc option:selected").val() != "-1") {
                       $("#lbl_jcdzbmc").text("正确");
                       $("#lbl_jcdzbmc").css("color", "#00ff00");
                   } else {
                       $("#lbl_jcdzbmc").text("请选择");
                       $("#lbl_jcdzbmc").css("color", "#ff0000");
                   }
               });
               //党小组名称
               $("#tbx_dxzmc").change(function () {
                   if ($("#ddlt_dxzmc option:selected").val() != "-1") {
                       $("#lbl_dxzmc").text("正确");
                       $("#lbl_dxzmc").css("color", "#00ff00");
                   } else {
                       $("#lbl_dxzmc").text("请选择");
                       $("#lbl_dxzmc").css("color", "#ff0000");
                   }
               });


           }) </script>
        
        </form>
</asp:Content>