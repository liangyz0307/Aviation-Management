<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SKJS_AQWTK_Detail.aspx.cs" Inherits="CUST.WKG.SKJS_AQWTK_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>安全问题库详情</title>
        <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
       <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
         <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>
     <%--   UEdit--%>
      <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.config.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/ueditor.all.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../UEdit/utf8-net/lang/zh-cn/zh-cn.js" charset="utf-8"></script>

    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
       
  
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
           <table style="border-top: 2px solid #C0D9D9; border-bottom: 2px solid #C0D9D9;">
                <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">岗位： 
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                                <asp:Label ID="lbl_gw" runat="server"></asp:Label>

                    </td>
                                        <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">安全问题名称：
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                                <asp:Label ID="lbl_aqwtmc" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">来源：  
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_ly" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">发生时间： 
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_fssj" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">涉及范畴： 
   
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_sjfc" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">时态： 
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_st" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">危险程度： 
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_wxcd" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">问题安全状态：     
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_wtaqzt" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">整改措施标准化情况：   
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_zgcsbzhqk" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">问题控制状态： 
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_wtkzzt" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">责任部门：  
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                        <asp:Label ID="lbl_zrbm" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">责任岗位： 
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                        <asp:Label ID="lbl_zrgw" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">涉及部门：   
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_sjbm" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">责任人：  
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_zrr" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 诱发原因分析：
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                      
                        <asp:Label ID="lbl_yfyy" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                    </tr>

                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 可能造成的问题或后果：
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_knzchg" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                    </tr>

                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 后果严重程度：
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_hgyzcd" runat="server"></asp:Label>
                    </td>
                    </tr>

                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 整改措施：
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_zgcs" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                    </tr>

                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 整改时限：
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_zgsx" runat="server"></asp:Label>
                    </td>
                    </tr>

                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 等效措施或预案：
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_dxcs" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>
                    </tr>
                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 与危险源相关联的事件或典型案例：
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_ywxyxg" TextMode="MultiLine" runat="server"></asp:Label>
                    </td>
                    </tr>
                               <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"  >备注：    
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_bz" runat="server" TextMode="MultiLine" ></asp:Label>
                    </td>

                </tr>
                                       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                 <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     数据所属部门：</td>
                 <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_shjsbmmc" runat="server" ></asp:Label>
                    </td>              
                <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     录入人：</td>
                 <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_lrr" runat="server" ></asp:Label>
                    </td>              
            </tr> 
                    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     初审人：</td>
                <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_csr" runat="server" ></asp:Label>
                    </td>              

               <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     终审人：</td>
                 <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_zsr" runat="server" ></asp:Label>
                    </td>              
            </tr>  

            </table>
              <br />
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="btn_fh" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_fh_Click"
                                Width="199px" ></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
 
        </form>
    </article>
    
</body>
    
</html>