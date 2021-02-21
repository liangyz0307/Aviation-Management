<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_WXFY_Detail.aspx.cs" Inherits="CUST.WKG.BS_WXFY_Detail" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

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
    </style>
</head>

<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div class="panel-head">
            <strong class="icon-reorder">请示登记详情</strong>
        </div>
               <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">项目名称：</td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">                     
                        <asp:Label ID="lbl_xmmc" runat="server" Width="300" Height="25px"></asp:Label>
                    </td>
                      <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">登记单位：<span class="c-red"></span></td>
                    <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                      <asp:Label ID="lbl_djdw" runat="server" Width="446px" ></asp:Label>
                    </td>
                </tr>
              
                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">预算批复：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                          <asp:Label ID="lbl_yspf" runat="server"></asp:Label>
                    </td>
                      <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">维修类别：<span class="c-red"></span></td>
                    <td  style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_wxlb" runat="server"></asp:Label>
                    </td>
                         </tr>
                  <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">设备类别：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                         <asp:Label ID="lbl_sblb" runat="server" ></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">设备名称：<span class="c-red"></span></td>
                    <td  style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_sbmc" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                </tr>
                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">存放地点：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_cfdd" runat="server"></asp:Label>
                    </td>
                        <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">供应商/维修单位：<span class="c-red"></span></td>
                    <td  style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_gys_wxdw" runat="server"></asp:Label>
                        
                    </td>
                </tr>
                       
                <tr   style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">维修日期：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_wxrq" runat="server"></asp:Label>
                    </td>
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">维修预算：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_wxys" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                </tr>
                                   <tr   style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">板件名称：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_bjmc" runat="server"></asp:Label>
                    </td>
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">预算执行机场：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_yszxjc" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                </tr>

                <tr   style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">执行额度：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_zxed" runat="server"></asp:Label>
                    </td>
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">剩余额度：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_syed" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                </tr>
                <tr   style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_nd" runat="server"></asp:Label>
                    </td>
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">驳回原因：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_bhyy" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                </tr>
                <tr   style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">请&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;示：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                         <asp:Label ID="lbl_qs" runat="server" ></asp:Label>
                   <asp:Button ID="btn_qs" runat="server"  class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                   Width  ="70px" OnClick="btn_qs_down_Click" Text="下载" ></asp:Button> 
                    </td>
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">故障报告：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                      <asp:Label ID="lbl_gzbg" runat="server" ></asp:Label>
                   <asp:Button ID="btn_gzbg" runat="server"  class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                   Width  ="70px" OnClick="btn_gzbg_down_Click"  Text="下载"  ></asp:Button> 
                    </td>
                </tr>
                <tr   style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">其他附件：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_qtfj" runat="server" ></asp:Label>
                        <asp:Button ID="btn_qtfj" runat="server" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                   Width  ="70px" OnClick="btn_qtfj_down_Click"  Text="下载"  ></asp:Button> 
                    </td>
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc"><span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                     
                    </td>
                </tr>
                 </table>
        <div class="row cl">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
            <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_fh_Click"   ></asp:Button> 
		</div>
        <input id="ChangeFlag" runat="server" type="hidden" />
	</div>  
	</form>
</article>    
</body>
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.admin.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.js"></script>
    <script src="../../Content/js/jquery.js" type="text/javascript"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <script src="../css/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="../lib/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="../lib/layer/2.1/layer.js"></script>
    <script type="text/javascript" src="../lib/icheck/jquery.icheck.min.js"></script>
    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/validate-methods.js"></script>
    <script type="text/javascript" src="../lib/jquery.validation/1.14.0/messages_zh.min.js"></script>
    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>
</html>

