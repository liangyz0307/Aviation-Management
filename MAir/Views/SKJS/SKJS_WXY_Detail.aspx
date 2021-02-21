<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SKJS_WXY_Detail.aspx.cs" Inherits="CUST.WKG.SKJS_WXY_Detail" %>
<%@ Register TagPrefix="hw" Namespace="UNLV.IAP.WebControls" Assembly="DropDownCheckList" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            <%--<div style="padding: 1%">
            选择员工：<hw:DropDownCheckList ID="ddl" runat="server" RepeatColumns="1"
                DisplayTextWidth="130" DropImageSrc="../../Contrent/images/admin_ico3.gif" TextWhenNoneChecked="--请选择--"
                DisplayBoxCssStyle=" cursor: pointer; background-color: #FFFFFF;" class="select-box"
                CheckListCssStyle="overflow:hidden; padding: 6px; background-color: #cccccc"
                DisplayTextList="Labels" ClientCodeLocation="DropDownCheckList.js"
                DataTextField="Name" DataValueField="ID">
            </hw:DropDownCheckList>
            <asp:Button ID="btn_syr" runat="server" OnClientClick="hide()" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="120px" Text="保存" OnClick="btn_syr_Click" />
        </div>--%>
      <%--   <nav class="breadcrumb">个人信息管理 <span class="c-gray en">&gt;</span> 个人信息<span class="c-gray en">&gt;</span>员工添加
         </nav>--%>
	<div class="panel-head">
                <strong class="icon-reorder">安全风险添加</strong>
            </div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc"> 岗 位：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_gw" runat="server"></asp:Label>
                    </td>


                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">危险源名称：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_mc" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">危 险 源 范 畴：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_fc" runat="server"></asp:Label>
                    </td>

                        <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">责任人：</td>
                        <td colspan="2" style="width: 20%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_syr" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">月 份 ：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_yf" runat="server"></asp:Label>
                    </td>

 
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">时 态：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_st" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">风险发生的可能性：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_knx" runat="server"></asp:Label>
                    </td>


                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">后果的严重性：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_yzx" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">风 险 程 度：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_fxcd" runat="server"></asp:Label>
                    </td>
  
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">状 态：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_zt" runat="server"></asp:Label>
                    </td>
                </tr>
               
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">控 制 状 态：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_kzzt" runat="server"></asp:Label>
                    </td>

                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9; height: 27px;" class="td_sjsc">控制措施标准化情况：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 27px;" class="td_sjsc">
                        <asp:Label ID="lbl_bzh" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">责任部门(二级)：<span class="c-red"></span> </td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                        <asp:Label ID="lbl_bmej" runat="server"></asp:Label>
                    </td>


                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">责任部门(三级)：<span class="c-red"></span> </td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_bmsj" runat="server"></asp:Label>
                    </td>

                </tr>
               
                <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">配 合 部 门：<span class="c-red"></span> </td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                        <asp:Label ID="lbl_phbm" runat="server"></asp:Label>
    
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">数据所属部门：<span class="c-red"></span> </td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                        <asp:Label ID="lbl_shjsbmmc" runat="server"></asp:Label>
                    </td>
                     <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">录 入 人：<span class="c-red"></span> </td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                        <asp:Label ID="lbl_lrr" runat="server"></asp:Label>

                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">初 审 人：<span class="c-red"></span> </td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                        <asp:Label ID="lbl_csr" runat="server"></asp:Label>
                    </td>
                 <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">终 审 人：<span class="c-red"></span> </td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                        <asp:Label ID="lbl_zsr" runat="server"></asp:Label>
           
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc"> </td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                       
                    </td>

              
                <tr style="vertical-align: top; width: 100%; height: 100px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">应 急 措 施：<span class="c-red"></span></td>
                    <td colspan="4" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                    
                        <asp:Label ID="lbl_yj" runat="server" TextMode="MultiLine"  Height="70px" Width="750px" Style="resize: none;"></asp:Label>
                    </td>

                </tr>
              <tr style="vertical-align: top; width: 100%; height: 100px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">诱 发 原 因 ：<span class="c-red"></span></td>
                    <td colspan="4" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
		
                        <asp:Label ID="lbl_yy" runat="server"></asp:Label>
                    </td>

                </tr>
                     <tr style="vertical-align: top; width: 100%; height: 100px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">风险控制预案：<span class="c-red"></span></td>
                    <td colspan="4" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                  
                        <asp:Label ID="lbl_ya" runat="server" TextMode="MultiLine"  Height="70px" Width="750px" Style="resize: none;"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 100px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">后 果 ：<span class="c-red"></span></td>
                    <td colspan="4" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">

                        <asp:Label ID="lbl_hg" runat="server" TextMode="MultiLine"  Height="70px" Width="750px" Style="resize: none;"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 100px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">相关典型案例 ：<span class="c-red"></span></td>
                    <td colspan="4" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_xgal" runat="server" TextMode="MultiLine"  Height="70px" Width="750px" Style="resize: none;"></asp:Label>
                    </td>

                </tr>
                              
            </table>


            <div class="row cl">
                <div class="row cl" style="text-align: center; width: 100%; margin: 0 auto;">
                    <table>
                        <tr>
                            <td style="text-align: center">

                                <asp:Button ID="btn_fh" runat="server"
                                    Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                    Width="199px" OnClick="btn_fh_Click" Style="margin-bottom: 0px"></asp:Button>
                            </td>
                        </tr>
                    </table>
	</form>
</article>
</body>
</html>

