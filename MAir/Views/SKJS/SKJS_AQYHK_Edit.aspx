<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SKJS_AQYHK_Edit.aspx.cs" Inherits="CUST.WKG.SKJS_AQYHK_Edit" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
            <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
      <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
      <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
    <style type="text/css">
  
    #login_zgzrrxm  
    {  
        display:none;  
        border:1em solid #e4e5e6;  
        height:150px;  
        width:200px;  
        position:absolute;/*让节点脱离文档流,我的理解就是,从页面上浮出来,不再按照文档其它内容布局*/  
        top:20%;/*节点脱离了文档流,如果设置位置需要用top和left,right,bottom定位*/  
        left:40%;  
        z-index:2;/*个人理解为层级关系,由于这个节点要在顶部显示,所以这个值比其余节点的都大*/  
        background: white;  
    }  
            td.td_sjsc
            {
                background:#F6FAFD;
            }    
    #login_zgdbzrrxm
    {  
        display:none;  
        border:1em solid #e4e5e6;  
        height:150px;  
        width:200px;  
        position:absolute;/*让节点脱离文档流,我的理解就是,从页面上浮出来,不再按照文档其它内容布局*/  
        top:20%;/*节点脱离了文档流,如果设置位置需要用top和left,right,bottom定位*/  
        left:40%;  
        z-index:2;/*个人理解为层级关系,由于这个节点要在顶部显示,所以这个值比其余节点的都大*/  
        background: white;  
    }  
        #login_zgyzrxm
    {  
        display:none;  
        border:1em solid #e4e5e6;  
        height:150px;  
        width:200px;  
        position:absolute;/*让节点脱离文档流,我的理解就是,从页面上浮出来,不再按照文档其它内容布局*/  
        top:20%;/*节点脱离了文档流,如果设置位置需要用top和left,right,bottom定位*/  
        left:40%;  
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
        </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
            <div class="panel-head">
                <strong class="icon-reorder">安全隐患库编辑</strong>
            </div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">填报单位：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                      <asp:DropDownList ID="ddlt_tbdw" runat="server" Width="446px" Enabled="true"></asp:DropDownList>
                        <asp:Label ID="lbl_tbdw" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align:  middle;  border: 1px solid #C0D9D9;" class="td_sjsc">来源：<span class="c-red">*</span></td>
                    <td colspan="2" style="width:  40%; text-align: left; vertical-align: middle;  border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_ly" runat="server" Width="446px" Enabled="true"></asp:DropDownList>
                        <asp:Label ID="lbl_ly" runat="server"></asp:Label>
                    </td>

                </tr>


                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">隐患发现时间：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_yhfxsj" runat="server" class="Wdate" Height="20px" Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Enabled="true"></asp:TextBox>
                        <asp:Label ID="lbl_yhfxsj" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">隐患描述：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_yhms" runat="server" class="input-text" Enabled="true"
                            Width="446px" MaxLength="3000"></asp:TextBox>
                        <asp:Label ID="lbl_yhms" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">可能造成的危害：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_knzcwh" runat="server" class="input-text" Enabled="true"
                            Width="446px"  MaxLength="3000"></asp:TextBox>
                        <asp:Label ID="lbl_knzcwh" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">隐患等级：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:DropDownList ID="ddlt_yhdj" runat="server" Width="446px" Enabled="true"></asp:DropDownList>
                        <asp:Label ID="lbl_yhdj" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">评估分级批准：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_pgfjpz" runat="server" class="input-text" Enabled="true"
                            Width="446px"  MaxLength="3000"></asp:TextBox>
                        <asp:Label ID="lbl_pgfjpz" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改策略以及临时控制措施：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zgcs" runat="server" class="input-text" Enabled="true"
                            Width="446px"  MaxLength="3000"></asp:TextBox>
                        <asp:Label ID="lbl_zgcs" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">预计投入费用：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_yjtrfy" runat="server" class="input-text" Enabled="true"
                            Width="446px"  MaxLength="3000"></asp:TextBox>
                        <asp:Label ID="lbl_yjtrfy" runat="server"></asp:Label>
                    </td>

                </tr>
                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改完成时限：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <asp:TextBox ID="tbx_zgwcsx" runat="server" class="Wdate" Height="20px" Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Enabled="true"></asp:TextBox>
                        <asp:Label ID="lbl_zgwcsx" runat="server"></asp:Label>
                    </td>

                </tr>
                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">完成进度描述：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_wcjdms" runat="server" class="input-text" Enabled="true"
                            Width="446px"  MaxLength="3000"></asp:TextBox>
                        <asp:Label ID="lbl_wcjdms" runat="server"></asp:Label>
                    </td>

                </tr>
                                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改责任单位：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zgzrdw" runat="server" Enabled="true" Width="446px">
                        </asp:DropDownList>
                        <asp:Label ID="lbl_zgzrdw" runat="server"></asp:Label>
                    </td>
                                                  
                </tr>
                <asp:HiddenField ID="zgzrrxmHiddenField" runat="server" />  
                                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改责任人：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zgzrrxm" runat="server" class="input-text" Enabled="true"
                            Width="446px" MaxLength="1000"></asp:TextBox>
                          <a href="javascript:show_zgzrrxm()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_zgzrrxm">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                部门： 
                                  <asp:DropDownList ID="ddlt_bmdm1" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_bmdm1_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                岗位： 
                                  <asp:DropDownList ID="ddlt_gwdm1" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_gwdm1_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                员工： 
                                  <asp:DropDownList ID="ddlt_syr1" runat="server" class="select-box"
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
                                <table>
                                    <tr>
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_bc_syr1" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClick="btn_bc_syr1_Click" OnClientClick="hide()" Text="保存"
                                                Width="100px" />
                                        </td >
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_gb1" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClientClick="hide()" Text="关闭"
                                                Width="100px" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over">
                        </div>
                        <asp:Label ID="lbl_zgzrrxm" runat="server"></asp:Label>
                    </td>
                       
                </tr>
                <asp:HiddenField ID="zgdbzrrxmHiddenField" runat="server" />     
                                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改督办责任人：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zgdbzrrxm" runat="server" class="input-text" Enabled="true"
                            Width="446px" MaxLength="1000"></asp:TextBox>
                                                  <a href="javascript:show_zgdbzrrxm()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_zgdbzrrxm">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                部门： 
                                  <asp:DropDownList ID="ddlt_bmdm2" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_bmdm2_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                岗位： 
                                  <asp:DropDownList ID="ddlt_gwdm2" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_gwdm2_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                员工： 
                                  <asp:DropDownList ID="ddlt_syr2" runat="server" class="select-box"
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
                                <table>
                                    <tr>
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_bc_syr2" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClick="btn_bc_syr2_Click" OnClientClick="hide()" Text="保存"
                                                Width="100px" />
                                        </td >
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_gb2" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClientClick="hide()" Text="关闭"
                                                Width="100px" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over">
                        </div>
                        <asp:Label ID="lbl_zgdbzrrxm" runat="server"></asp:Label>
                    </td>

                </tr>
                                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改方案批准：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                          <asp:TextBox ID="tbx_zgfapz" runat="server" class="input-text" Enabled="true"
                            Width="446px"  MaxLength="3000"></asp:TextBox>
                        <asp:Label ID="lbl_zgfapz" runat="server"></asp:Label>
                    </td>

                </tr>
                                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改验证结果：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zgyzjg" runat="server" class="input-text" Enabled="true"
                            Width="446px"  MaxLength="3000"></asp:TextBox>
                        <asp:Label ID="lbl_zgyzjg" runat="server"></asp:Label>
                    </td>

                </tr>
                <asp:HiddenField ID="zgyzrxmHiddenField" runat="server" />     
                                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改验证人：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zgyzrxm" runat="server" class="input-text" Enabled="true"
                            Width="446px" MaxLength="1000"></asp:TextBox>
                                                  <a href="javascript:show_zgyzrxm()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_zgyzrxm">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                部门： 
                                  <asp:DropDownList ID="ddlt_bmdm3" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_bmdm3_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                岗位： 
                                  <asp:DropDownList ID="ddlt_gwdm3" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_gwdm3_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                员工： 
                                  <asp:DropDownList ID="ddlt_syr3" runat="server" class="select-box"
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
                                <table>
                                    <tr>
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_bc_syr3" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClick="btn_bc_syr3_Click" OnClientClick="hide()" Text="保存"
                                                Width="100px" />
                                        </td >
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_gb3" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClientClick="hide()" Text="关闭"
                                                Width="100px" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over">
                        </div>
                        <asp:Label ID="lbl_zgyzrxm" runat="server"></asp:Label>
                    </td>

                </tr>
                                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改关闭时间：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_zggbsj" runat="server" class="Wdate" Height="20px" Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Enabled="true"></asp:TextBox>
                        <asp:Label ID="lbl_zggbsj" runat="server"></asp:Label>
                    </td>

                </tr>
                                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改关闭标准：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zggbbz" runat="server" class="input-text" Enabled="true"
                            Width="446px"  MaxLength="3000"></asp:TextBox>
                        <asp:Label ID="lbl_zggbbz" runat="server"></asp:Label>
                    </td>

                </tr>
                                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">整改关闭批准：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zggbpz" runat="server" Enabled="true" Width="446px">
                        </asp:DropDownList>
                        <asp:Label ID="lbl_zggbpz" runat="server"></asp:Label>
                    </td>

                </tr>
                                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">相关台账保存情况：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_xgtzbcqk" runat="server" class="input-text" Enabled="true"
                            Width="446px"  MaxLength="3000"></asp:TextBox>
                        <asp:Label ID="lbl_xgtzbcqk" runat="server"></asp:Label>
                    </td>

                </tr>

                                        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    数据所在部门：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_sjszbm" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_sjszbm" runat="server" ></asp:Label>
                    </td>
            </tr>


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
                <div class="row cl" style="text-align: center; width: 100%; margin: 0 auto;">
                    <table>
                        <tr>
                            <td style="text-align: right">

                                <asp:Button ID="btn_save" runat="server"
                                    Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                    Width="199px" OnClick="btn_save_Click" ></asp:Button></td>
                            <td>&nbsp;</td>
                            <td style="text-align: center">
                                <asp:Button ID="btn_fh" runat="server"
                                    Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                                    Width="199px" OnClick="btn_fh_Click" Style="margin-bottom: 0px"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </form>
    </article>
</body>
     <script type="text/javascript">  
         var login_zgzrrxm = document.getElementById('login_zgzrrxm');  //弹出层中的登录框
         var login_zgdbzrrxm = document.getElementById('login_zgdbzrrxm');
         var login_zgyzrxm = document.getElementById('login_zgyzrxm');
    var over = document.getElementById('over'); //弹出层
    function show_zgzrrxm()
    {
        zgzrrxmHiddenField.value = 1;
        login_zgzrrxm.style.display = "block";
        over.style.display = "block";
    }
    function show_zgdbzrrxm()
    {
        zgdbzrrxmHiddenField.Value = 1;
        login_zgdbzrrxm.style.display = "block";
        over.style.display = "block";
    }
        function show_zgyzrxm() {
            zgyzrxmHiddenField.Value = 1;
        login_zgyzrxm.style.display = "block";
        over.style.display = "block";
    }
    function btn_bc_syr1()
    {
        btn_syr.style.display = "block";
        btn_syr.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
    }
    $("#btn_bc_syr1").click(function ()
    {
        hide();
    });
    function btn_bc_syr2() {
        btn_syr.style.display = "block";
    }
    $("#btn_bc_syr2").click(function () {
        hide();
    });
    function btn_bc_syr3() {
        btn_syr.style.display = "block";
    }
    $("#btn_bc_syr3").click(function () {
        hide();
    });
    function hide()  
    {
        login.style.display = "none";
        over.style.display = "none";
    } 
</script> 
    

<script type="text/javascript">

    var i = 0;

    
    $("#btn_save").click(function () {


        //填报单位
        if ($("#ddlt_tbdw").val().trim() == "-1") {
            $("#lbl_tbdw").text("错误：请选择！");
            $("#lbl_tbdw").css("color", "#ff0000");
            $("#lbl_tbdw").focus();
            return false;
        }
        else {
            $("#lbl_tbdw").text("正确");
            $("#lbl_tbdw").css("color", "#00ff00");
        }
        //来源

        if ($("#ddlt_ly").val().trim() == "-1") {
            $("#lbl_ly").text("错误：请选择！");
            $("#lbl_ly").css("color", "#ff0000");
            $("#lbl_ly").focus();
            return false;
        }
        else {
            $("#lbl_ly").text("正确");
            $("#lbl_ly").css("color", "#00ff00");
        }


        //隐患发现时间

        $("#tbx_zyhfxsj").blur(function () {
            if ($("#tbx_yhfxsj").val().trim() == "") {
                $("#lbl_yhfxsj").text("内容不能为空");
                $("#lbl_yhfxsj").css("color", "#ff0000");
            }
            else {
                var ys = /^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$/;
                if (!ys.test($("#tbx_yhfxsj").val())) {
                    $("#lbl_yhfxsj").text("请输入正确格式如（1996-01-02）");
                    $("#lbl_yhfxsj").css("color", "#ff0000");
                }
                else {
                    $("#lbl_yhfxsj").text("正确");
                    $("#lbl_yhfxsj").css("color", "#00ff00");
                }
            }
        });

        //整改责任人

        if ($("#tbx_zgzrrxm").val() != "") {
            $("#lbl_zgzrrxm").text("正确");
            $("#lbl_zgzrrxm").css("color", "#00ff00");
        } else {
            $("#lbl_zgzrrxm").text("错误");
            $("#lbl_zgzrrxm").css("color", "#ff0000");
            i = 1;
        }

        //整改验证人

        if ($("#tbx_zgyzrxm").val() != "") {
            $("#lbl_zgyzrxm").text("正确");
            $("#lbl_zgyzrxm").css("color", "#00ff00");
        } else {
            $("#lbl_zgyzrxm").text("错误");
            $("#lbl_zgyzrxm").css("color", "#ff0000");
            i = 1;
        }

        //整改督办责任人

        if ($("#tbx_zgdbzrrxm").val() != "") {
            $("#lbl_zgdbzrrxm").text("正确");
            $("#lbl_zgdbzrrxm").css("color", "#00ff00");
        } else {
            $("#lbl_zgdbzrrxm").text("错误");
            $("#lbl_zgdbzrrxm").css("color", "#ff0000");
            i = 1;
        }
        //隐患描述

        $("#lbl_yhms").text("正确");
        $("#lbl_yhms").css("color", "#00ff00");


        //可能造成危害

        $("#lbl_knzcwh").text("正确");
        $("#lbl_knzcwh").css("color", "#00ff00");
       
        
        //隐患等级

        $("#lbl_yhdj").text("正确");
        $("#lbl_yhdj").css("color", "#00ff00");

        //评估分级批准

        $("#lbl_pgfjpz").text("正确");
        $("#lbl_pgfjpz").css("color", "#00ff00");
        //整改策略以及临时控制措施

        $("#lbl_zgcs").text("正确");
        $("#lbl_zgcs").css("color", "#00ff00");
        //预计投入费用

        $("#lbl_yjtrfy").text("正确");
        $("#lbl_yjtrfy").css("color", "#00ff00");

        //整改完成时限

        $("#tbx_zgwcsx").blur(function () {
            if ($("#tbx_zgwcsx").val().trim() == "") {
                $("#lbl_zgwcsx").text("内容不能为空");
                $("#lbl_zgwcsx").css("color", "#ff0000");
            }
            else {
                var ys = /^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$/;
                if (!ys.test($("#tbx_zgwcsx").val())) {
                    $("#lbl_zgwcsx").text("请输入正确格式如（1996-01-02）");
                    $("#lbl_zgwcsx").css("color", "#ff0000");
                }
                else {
                    $("#lbl_zgwcsx").text("正确");
                    $("#lbl_zgwcsx").css("color", "#00ff00");
                }
            }
        });
            //整改关闭时间

            $("#tbx_zggbsj").blur(function () {
            if ($("#tbx_zggbsj").val().trim() == "") {
                $("#lbl_zggnsj").text("内容不能为空");
                $("#lbl_zggnsj").css("color", "#ff0000");
            }
            else {
                var ys = /^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$/;
                if (!ys.test($("#tbx_zggbsj").val())) {
                    $("#lbl_zggnsj").text("请输入正确格式如（1996-01-02）");
                    $("#lbl_zggnsj").css("color", "#ff0000");
                }
                else {
                    $("#lbl_zggnsj").text("正确");
                    $("#lbl_zggnsj").css("color", "#00ff00");
                }
            }
            });
                //完成进度描述

                $("#lbl_wcjdms").text("正确");
                $("#lbl_wcjdms").css("color", "#00ff00");
                //整改责任单位

                if ($("#ddlt_zgzrdw").val().trim() == "-1") {
                    $("#lbl_zgzrdw").text("错误：请选择！");
                    $("#lbl_zgzrdw").css("color", "#ff0000");
                    $("#lbl_zgzrdw").focus();
                    return false;
                }
                else {
                    $("#lbl_zgzrdw").text("正确");
                    $("#lbl_zgzrdw").css("color", "#00ff00");
                }
                //整改关闭批准

                if ($("#ddlt_zggbpz").val().trim() == "-1") {
                    $("#lbl_zggbpz").text("错误：请选择！");
                    $("#lbl_zggbpz").css("color", "#ff0000");
                    $("#lbl_zggbpz").focus();
                    return false;
                }
                else {
                    $("#lbl_zggbpz").text("正确");
                    $("#lbl_zggbpz").css("color", "#00ff00");

                }
                //整改方案批准

                $("#lbl_zgfapz").text("正确");
                $("#lbl_zgfapz").css("color", "#00ff00");
                //整改验证结果

                $("#lbl_zgyzjg").text("正确");
                $("#lbl_zgyzjg").css("color", "#00ff00");

                //整改关闭标准

                $("#lbl_zgyzbz").text("正确");
                $("#lbl_zgyzbz").css("color", "#00ff00");
                //相关台账保存情况

                $("#lbl_xgtzbcqk").text("正确");
                $("#lbl_xgtzbcqk").css("color", "#00ff00");
    
            });

        
</script>
</html>