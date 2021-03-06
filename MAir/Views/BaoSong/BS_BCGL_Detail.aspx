﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_BCGL_Detail.aspx.cs" Inherits="CUST.WKG.BS_BCGL_Detail" %>

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
        <style type="text/css">  
    #login  
    {  
        display:none;  
        border:1em solid #e4e5e6;  
        height:450px;  
        width:500px;  
        position:absolute;/*让节点脱离文档流,我的理解就是,从页面上浮出来,不再按照文档其它内容布局*/  
        top:5%;/*节点脱离了文档流,如果设置位置需要用top和left,right,bottom定位*/  
        left:30%;  
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
        #LinkButton1 {
            background-image:url(../../Content/images/add.png)
        }   

   </style>  
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
            <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
                <tr  style="vertical-align: top;  width:100%;border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle; height: 33px;" class="td_sjsc">日期：</td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 33px;" class="td_sjsc">                     
                        <asp:Label ID="lbl_rq" runat="server" Width="300" Height="25px"></asp:Label>
                    </td>
                      <td style="width: 20%; text-align: right; vertical-align: middle; height: 33px;" class="td_sjsc"> <span class="c-red"></span></td>
                    <td style="width: 30%;  text-align: left; vertical-align: middle; height: 33px;" class="td_sjsc">
                      
                    </td>
                </tr>
              
                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">值班领导：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                          <asp:Label ID="lbl_zbld" runat="server"></asp:Label>
                    </td>
                      <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">值班领导电话：<span class="c-red"></span></td>
                    <td  style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_zblddh" runat="server"></asp:Label>
                    </td>
                         </tr>
                  <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">塔台值班：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_ttzb" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">塔台值班电话：<span class="c-red"></span></td>
                    <td  style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_ttzbdh" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                </tr>
                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">飞服值班：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_ffzb" runat="server"></asp:Label>
                    </td>
                                        <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">飞服值班电话：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_ffzbdh" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">通导值班：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_tdzb" runat="server"></asp:Label>
                    </td>
                                        <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">通导值班电话：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_tdzbdh" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">观测值班：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_gczb" runat="server"></asp:Label>
                    </td>
                                       <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">观测值班电话：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_gczbdh" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                </tr>
  
                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">预报值班：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_ybzb" runat="server"></asp:Label>
                    </td>
                                       <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">预报值班电话：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_ybzbdh" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                </tr>
                <%--<tr   style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">录入人：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_lrr" runat="server"></asp:Label>
                    </td>
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">初审人：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_csr" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                </tr>
                <tr   style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">终审人：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_zsr" runat="server"></asp:Label>
                    </td>
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">审核时间：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_shsj" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                    </tr>--%>

              
                 </table>
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="btn_fh" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_fh_Click" Style="margin-bottom: 0px"></asp:Button>
                           

                            </td>
                    </tr>
                </table>
            </div>
 
        </form>
    </article>
    </body>

</html>
