﻿<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DYGL_Edit.aspx.cs" Inherits="CUST.WKG.DYGL_Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">      
    <title>党员管理编辑页面</title>
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
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    员工编号：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_bh" runat="server" class="input-text" placeholder="员工编号" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_bh" runat="server" ></asp:Label>
                    </td>
            </tr>

       <%--  <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    党组织名称：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_dzzmc" runat="server" class="input-text" placeholder="党组织名称" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_dzzmc" runat="server" ></asp:Label>
                    </td>
            </tr>--%>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    基层党支部名称：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_jcdzbmc" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_jcdzbmc" runat="server" ></asp:Label>
                    </td>
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    党小组名称：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_dxzmc" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_dxzmc" runat="server" ></asp:Label>
                    </td>
            </tr>
       

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    党内职务：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_dnzw" runat="server" class="input-text" placeholder="党内职务" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_dnzw" runat="server" ></asp:Label>
                    </td>
            </tr>
       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    用工形式：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_ygxs" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_ygxs" runat="server" ></asp:Label>
                    </td>
            </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                    党员类型：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_dylx" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_dylx" runat="server" ></asp:Label>
                    </td>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   递交入党申请书时间：<span class="c-red"></span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc"> 
                      <asp:TextBox ID="tbx_djrdsqssj" runat="server" class="input-text" style="width:200px" 

placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_djrdsqssj" runat="server" ></asp:Label></td>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   列为入党积极分子时间：<span class="c-red"></span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc"> 
                      <asp:TextBox ID="tbx_lwrdjjfzsj" runat="server" class="input-text" style="width:200px" 

placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_lwrdjjfzsj" runat="server" ></asp:Label></td>
            </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   第一培养人：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">  
                   <asp:TextBox ID="tbx_pyr1" runat="server" class="input-text" placeholder="姓名" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_pyr1" runat="server" ></asp:Label>
                    </td>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   第二培养人：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">  
                   <asp:TextBox ID="tbx_pyr2" runat="server" class="input-text" placeholder="姓名" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_pyr2" runat="server" ></asp:Label>
                    </td>
            </tr>
          

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   积极分子培训班毕业时间：<span class="c-red"></span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc"> 
                      <asp:TextBox ID="tbx_jjfzpxbbysj" runat="server" class="input-text" style="width:200px" 

placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_jjfzpxbbysj" runat="server" ></asp:Label></td>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   确定为发展对象时间：<span class="c-red"></span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc"> 
                      <asp:TextBox ID="tbx_qdwfzdxsj" runat="server" class="input-text" style="width:200px" 

placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_qdwfzdxsj" runat="server" ></asp:Label></td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   发展为预备党员时间：<span class="c-red"></span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc"> 
                      <asp:TextBox ID="tbx_jrdzzsj" runat="server" class="input-text" style="width:200px" placeholder="

日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_jrdzzsj" runat="server" ></asp:Label></td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   转为正式党员时间：<span class="c-red"></span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc"> 
                      <asp:TextBox ID="tbx_zwzsdyrq" runat="server" class="input-text" style="width:200px" 

placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_zwzsdyrq" runat="server" ></asp:Label></td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   第一介绍人：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">  
                   <asp:TextBox ID="tbx_jsr1" runat="server" class="input-text" placeholder="姓名" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_jsr1" runat="server" ></asp:Label>
                    </td>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   第二介绍人：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">  
                   <asp:TextBox ID="tbx_jsr2" runat="server" class="input-text" placeholder="姓名" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_jsr2" runat="server" ></asp:Label>
                    </td>
            </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                    转正情况：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_zzqk" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_zzqk" runat="server" ></asp:Label>
                    </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   党费金额：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">  
                   <asp:TextBox ID="tbx_dfje" runat="server" class="input-text" placeholder="姓名" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_dfje" runat="server" ></asp:Label>
                    </td>
            </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc">
                   党费交至日期：<span class="c-red"></span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" 

class="td_sjsc"> 
                      <asp:TextBox ID="tbx_dfjzrq" runat="server" class="input-text" style="width:200px" 

placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                    <asp:Label ID="lbl_dfjzrq" runat="server" ></asp:Label></td>
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   备注：<span class="c-red"></span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:TextBox ID="tbx_bz" runat="server" class="input-text" placeholder="备注" style="width:300px"
                 ></asp:TextBox>
                    <asp:Label ID="lbl_bz" runat="server" ></asp:Label>
                    </td>
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

               //员工编号
               $("#tbx_bh").blur(function () {
                   if ($("#lbl_bh").val() != "") {
                       $("#lbl_bh").text("正确");
                       $("#lbl_bh").css("color", "#00ff00");
                   } else {
                       $("#lbl_bh").text("错误!不能为空");
                       $("#lbl_bh").css("color", "#ff0000");
                   }
               });
               
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
               $("#ddlt_jcdzbmc").change(function () {
                   if ($("#ddlt_jcdzbmc option:selected").val() != "-1") {
                       $("#lbl_jcdzbmc").text("正确");
                       $("#lbl_jcdzbmc").css("color", "#00ff00");
                   } else {
                       $("#lbl_jcdzbmc").text("请选择");
                       $("#lbl_jcdzbmc").css("color", "#ff0000");
                   }
               });
               //党小组名称
               $("#ddlt_dxzmc").change(function () {
                   if ($("#ddlt_dxzmc option:selected").val() != "-1") {
                       $("#lbl_dxzmc").text("正确");
                       $("#lbl_dxzmc").css("color", "#00ff00");
                   } else {
                       $("#lbl_dxzmc").text("请选择");
                       $("#lbl_dxzmc").css("color", "#ff0000");
                   }
               });
               //党内职务
               $("#tbx_dnzw").blur(function () {
                   if ($("#lbl_dnzw").val() != "") {
                       $("#lbl_dnzw").text("正确");
                       $("#lbl_dnzw").css("color", "#00ff00");
                   } else {
                       $("#lbl_dnzw").text("错误!不能为空");
                       $("#lbl_dnzw").css("color", "#ff0000");
                   }
               });
               //用工形式
               $("#ddlt_ygxs").change(function () {
                   if ($("#ddlt_ygxs option:selected").val() != "-1") {
                       $("#lbl_ygxs").text("正确");
                       $("#lbl_ygxs").css("color", "#00ff00");
                   } else {
                       $("#lbl_ygxs").text("请选择");
                       $("#lbl_ygxs").css("color", "#ff0000");
                   }
               });
               //加入党组织时间
               $("#tbx_jrdzzsj").blur(function () {
                   if ($("#lbl_jrdzzsj").val() != "") {
                       $("#lbl_jrdzzsj").text("正确");
                       $("#lbl_jrdzzsj").css("color", "#00ff00");
                   } else {
                       $("#lbl_jrdzzsj").text("错误!不能为空");
                       $("#lbl_jrdzzsj").css("color", "#ff0000");
                   }
               });
               //转为正式党员日期
               $("#tbx_zwzsdyrq").blur(function () {
                   if ($("#lbl_zwzsdyrq").val() != "") {
                       $("#lbl_zwzsdyrq").text("正确");
                       $("#lbl_zwzsdyrq").css("color", "#00ff00");
                   } else {
                       $("#lbl_zwzsdyrq").text("错误!不能为空");
                       $("#lbl_zwzsdyrq").css("color", "#ff0000");
                   }
               });
               
              

           }) </script>
        </form>
</asp:Content>