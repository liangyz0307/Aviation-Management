<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SKJS_AQWTK_Add.aspx.cs" Inherits="CUST.WKG.SKJS_AQWTK_Add" %>
<%@ Register TagPrefix="hw" Namespace="UNLV.IAP.WebControls" Assembly="DropDownCheckList" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>安全问题库添加</title>
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
      <script src="../../Content/js/jquery.js"></script>
     <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
   
    #login_zrr
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
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>         
        <div>
            <table style="border-top: 2px solid #C0D9D9; border-bottom: 2px solid #C0D9D9;">
                <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;">
                       <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">岗位： 
                        <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                             <asp:DropDownList ID="ddlt_gw" Width="30%" runat="server"></asp:DropDownList>
                                <asp:Label ID="lbl_gw" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">安全问题名称：
            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="tbx_aqwtmc" runat="server" Width="60%" Height="25px" placeholder="安全问题名称"></asp:TextBox>
                                <asp:Label ID="lbl_aqwtmc" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                 
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">来源：  
                        <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_ly" Width="30%" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_ly" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">发现时间： 
                        <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:TextBox ID="tbx_fssj" runat="server" Width="60%" Height="25px" placeholder="发现时间"  onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:Label ID="lbl_fssj" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">涉及范畴： 
                        <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_sjfc" Width="30%" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_sjfc" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">时态： 
                        <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_st" Width="30%" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_st" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">危险程度： 
                        <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_wxcd" Width="30%" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_wxcd" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">问题安全状态：     
                        <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_wtaqzt" Width="30%" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_wtzt" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">整改措施标准化情况：   
                        <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zgcsbzhqk" Width="30%" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_zgcsbzhqk" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">问题控制状态： 
                        <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                       <asp:DropDownList ID="ddlt_wtkzzt" Width="30%" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_wtkzzt" runat="server"></asp:Label>
                    </td>
                </tr>
                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">责任部门：  
                        <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zrbm" Width="30%" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_zrbm" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">责任岗位： 
                        <asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zrgw" runat="server" Width="30%"></asp:DropDownList>
                        <asp:Label ID="lbl_zrgw" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">涉及部门：   
                        <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_sjbm" Width="30%" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_sjbm" runat="server"></asp:Label>
                    </td>
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">责任人：  
                        <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zrr" runat="server" Width="60%" Height="25px" class="Wdate" placeholder="责任人"></asp:TextBox>
                         <a  href="javascript:show_zrr()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_zrr">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                部门： 
                                  <asp:DropDownList ID="ddlt_bmdm" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged2"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                岗位： 
                                  <asp:DropDownList ID="ddlt_gwdm" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_gwdm_SelectedIndexChanged2"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                员工： 
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
                                <table>
                                    <tr>
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_bc_wxry" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClick="btn_bc_zrr_Click" OnClientClick="hide()" Text="保存"
                                                Width="100px" />
                                        </td >
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_tc" runat="server" BackColor="#60B1D7" class="btn  radius"
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
                        <asp:Label ID="lbl_zrr" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 诱发原因分析：
                         <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                         <asp:TextBox ID="tbx_yfyy" name="tbx_yfyy" runat="server" TextMode="MultiLine" Height="200px" Width="800px" ClientIDMode="Static"> </asp:TextBox>
                        <asp:Label ID="lbl_yfyy" runat="server"></asp:Label>
                    </td>
                    </tr>

                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 可能造成的问题或后果：
                         <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                         <asp:TextBox ID="tbx_knzchg" name="tbx_knzchg" runat="server" TextMode="MultiLine" Height="200px" Width="800px" ClientIDMode="Static"> </asp:TextBox>
                        <asp:Label ID="lbl_knzchg" runat="server"></asp:Label>
                    </td>
                    </tr>

                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 后果严重程度：
                         <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                       <asp:DropDownList ID="ddlt_hgyzcd" Width="10%" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_hgyzcd" runat="server"></asp:Label>
                    </td>
                    </tr>
                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">

                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">整改时限： 
                        <asp:Label ID="Label24" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td colspan="3" style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:TextBox ID="tbx_zgsx" runat="server" Width="30%" Height="25px" placeholder="整改时限"  onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:Label ID="lbl_zgsx" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 整改措施：
                         <asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                         <asp:TextBox ID="tbx_zgcs" name="tbx_zgcs" runat="server" TextMode="MultiLine" Height="200px" Width="800px" ClientIDMode="Static"> </asp:TextBox>
                        <asp:Label ID="lbl_zgcs" runat="server"></asp:Label>
                    </td>
                    </tr>


                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 等效措施或预案：
                         <asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                         <asp:TextBox ID="tbx_dxcs" name="tbx_dxcs" runat="server" TextMode="MultiLine" Height="200px" Width="800px" ClientIDMode="Static"> </asp:TextBox>
                        <asp:Label ID="lbl_dxcs" runat="server"></asp:Label>
                    </td>
                    </tr>
                                    <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc"> 与危险源相关联的事件或典型案例：
                         <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" colspan="3">
                         <asp:TextBox ID="tbx_ywxyxg" name="tbx_dxcs" runat="server" TextMode="MultiLine" Height="200px" Width="800px" ClientIDMode="Static"> </asp:TextBox>
                        <asp:Label ID="lbl_ywxyxg" runat="server"></asp:Label>
                    </td>
                    </tr>

                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">备注：    
                        <asp:Label ID="Label13" runat="server" Text="*" ForeColor="White"></asp:Label>
                    </td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:TextBox ID="tbx_bz" runat="server" Width="60%" Height="25px" placeholder="备注"></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                    数据所在部门：<span class="c-red">*</span></td>
                 <td colspan="3" style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:DropDownList ID="ddlt_sjszbm" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_sjszbm" runat="server" ></asp:Label>
                    </td>
            </tr>


            <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9; height: 30px;"  class="td_sjsc">
                    初审人：<span class="c-red">*</span></td>
                <td colspan="3" style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:DropDownList ID="ddlt_csr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_csr" runat="server" ></asp:Label>
                    </td>
            </tr>
                   <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                    终审人：<span class="c-red">*</span></td>
                 <td colspan="3" style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:DropDownList ID="ddlt_zsr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_zsr" runat="server" ></asp:Label>
                    </td>
                          </tr>
            </table>
              <br />
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btn_save" runat="server"
                                Text="保存" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_save_Click" ></asp:Button></td>
                        <td>&nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="btn_fh" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White" OnClick="btn_fh_Click"
                                Width="199px" ></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
          </div>
    </form>
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.admin.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.js"></script>
         </article>
</body>
    <script type="text/javascript">
        
        $(document).ready(function () {
            //岗位
            $("#ddlt_gw").blur(function ()
            {
                if ($("#ddlt_gw option:selected").val() == "-1")
                {
                    $("#lbl_gw").text("内容不能为空");
                    $("#lbl_gw").css("color", "#ff0000");
                }
                else
                {
                    $("#lbl_gw").text("正确");
                    $("#lbl_gw").css("color", "#00ff00");
                }
            });
            //安全问题名称
            $("#tbx_aqwtmc").blur(function () {
                if ($("#tbx_aqwtmc").val().trim() == "") {
                    $("#lbl_aqwtmc").text("内容不能为空");
                    $("#lbl_aqwtmc").css("color", "#ff0000");
                }
                else {
                    $("#lbl_aqwtmc").text("正确");
                    $("#lbl_aqwtmc").css("color", "#00ff00");
                }

            });
            //来源
            $("#ddlt_ly").blur(function () {
                if ($("#ddlt_ly option:selected").val() == "-1") {
                    $("#lbl_ly").text("内容不能为空");
                    $("#lbl_ly").css("color", "#ff0000");
                }
                else {
                    $("#lbl_ly").text("正确");
                    $("#lbl_ly").css("color", "#00ff00");
                }
            });
            //发现时间
            $("#tbx_fssj").blur(function () {
                if ($("#tbx_fssj").val().trim() == "") {
                    $("#lbl_fssj").text("内容不能为空");
                    $("#lbl_fssj").css("color", "#ff0000");
                }
                else {
                    var ys = /^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$/;
                    if (!ys.test($("#tbx_fssj").val())) {
                        $("#lbl_fssj").text("请输入正确格式如（1996-01-02）");
                        $("#lbl_fssj").css("color", "#ff0000");
                    }
                    else {
                        $("#lbl_fssj").text("正确");
                        $("#lbl_fssj").css("color", "#00ff00");
                    }
                }
            });
            //涉及范畴
            $("#ddlt_sjfc").blur(function () {
                if ($("#ddlt_sjfc option:selected").val() == "-1") {
                    $("#lbl_sjfc").text("内容不能为空");
                    $("#lbl_sjfc").css("color", "#ff0000");
                }
                else {
                    $("#lbl_sjfc").text("正确");
                    $("#lbl_sjfc").css("color", "#00ff00");
                }
            });
            //时态
            $("#ddlt_st").blur(function () {
                if ($("#ddlt_st option:selected").val() == "-1") {
                    $("#lbl_st").text("内容不能为空");
                    $("#lbl_st").css("color", "#ff0000");
                }
                else {
                    $("#lbl_st").text("正确");
                    $("#lbl_st").css("color", "#00ff00");
                }
            });
            //危险程度
            $("#ddlt_wxcd").blur(function () {
                if ($("#ddlt_wxcd option:selected").val() == "-1") {
                    $("#lbl_wxcd").text("内容不能为空");
                    $("#lbl_wxcd").css("color", "#ff0000");
                }
                else {
                    $("#lbl_wxcd").text("正确");
                    $("#lbl_wxcd").css("color", "#00ff00");
                }
            });
            //问题安全状态
            $("#ddlt_wtaqzt").blur(function () {
                if ($("#ddlt_wtaqzt option:selected").val() == "-1") {
                    $("#lbl_wtzt").text("内容不能为空");
                    $("#lbl_wtzt").css("color", "#ff0000");
                }
                else {
                    $("#lbl_wtzt").text("正确");
                    $("#lbl_wtzt").css("color", "#00ff00");
                }
            });
            //整改措施标准化情况
            $("#ddlt_zgcsbzhqk").blur(function () {
                if ($("#ddlt_zgcsbzhqk option:selected").val() == "-1") {
                    $("#lbl_zgcsbzhqk").text("内容不能为空");
                    $("#lbl_zgcsbzhqk").css("color", "#ff0000");
                }
                else {
                    $("#lbl_zgcsbzhqk").text("正确");
                    $("#lbl_zgcsbzhqk").css("color", "#00ff00");
                }
            });
            //问题控制状态
            $("#ddlt_wtkzzt").blur(function () {
                if ($("#ddlt_wtkzzt option:selected").val() == "-1") {
                    $("#lbl_wtkzzt").text("内容不能为空");
                    $("#lbl_wtkzzt").css("color", "#ff0000");
                }
                else {
                    $("#lbl_wtkzzt").text("正确");
                    $("#lbl_wtkzzt").css("color", "#00ff00");
                }
            });
            //责任部门
            $("#ddlt_zrbm").blur(function () {
                if ($("#ddlt_zrbm option:selected").val() == "-1") {
                    $("#lbl_zrbm").text("内容不能为空");
                    $("#lbl_zrbm").css("color", "#ff0000");
                }
                else {
                    $("#lbl_zrbm").text("正确");
                    $("#lbl_zrbm").css("color", "#00ff00");
                }
            });
            //责任岗位
            $("#ddlt_zrgw").blur(function () {
                if ($("#ddlt_zrgw option:selected").val() == "-1") {
                    $("#lbl_zrgw").text("内容不能为空");
                    $("#lbl_zrgw").css("color", "#ff0000");
                }
                else {
                    $("#lbl_zrgw").text("正确");
                    $("#lbl_zrgw").css("color", "#00ff00");
                }
            });
            //涉及部门
            $("#ddlt_sjbm").blur(function () {
                if ($("#ddlt_sjbm option:selected").val() == "-1") {
                    $("#lbl_sjbm").text("内容不能为空");
                    $("#lbl_sjbm").css("color", "#ff0000");
                }
                else {
                    $("#lbl_sjbm").text("正确");
                    $("#lbl_sjbm").css("color", "#00ff00");
                }
            });
            //责任人
            $("#tbx_zrr").blur(function () {
                if ($("#tbx_zrr").val().trim() == "") {
                    $("#lbl_zrr").text("请选择");
                    $("#lbl_zrr").css("color", "#ff0000");
                }
                else {
                    $("#lbl_zrr").text("正确");
                    $("#lbl_zrr").css("color", "#00ff00");
                }
            });
            //诱发原因分析
            $("#tbx_yfyy").blur(function () {
                if ($("#tbx_yfyy").val().trim() == "") {
                    $("#lbl_yfyy").text("内容不能为空");
                    $("#lbl_yfyy").css("color", "#ff0000");
                }
                else {
                    $("#lbl_yfyy").text("正确");
                    $("#lbl_yfyy").css("color", "#00ff00");
                }
            });
            //可能造成的问题或后果
            $("#tbx_knzchg").blur(function () {
                if ($("#tbx_knzchg").val().trim() == "") {
                    $("#lbl_knzchg").text("内容不能为空");
                    $("#lbl_knzchg").css("color", "#ff0000");
                }
                else {
                    $("#lbl_knzchg").text("正确");
                    $("#lbl_knzchg").css("color", "#00ff00");
                }
            });
            //后果严重程度
            $("#ddlt_hgyzcd").blur(function () {
                if ($("#ddlt_hgyzcd option:selected").val() == "-1") {
                    $("#lbl_hgyzcd").text("内容不能为空");
                    $("#lbl_hgyzcd").css("color", "#ff0000");
                }
                else {
                    $("#lbl_hgyzcd").text("正确");
                    $("#lbl_hgyzcd").css("color", "#00ff00");
                }
            });
            //整改措施
            $("#tbx_zgcs").blur(function () {
                if ($("#tbx_zgcs").val().trim() == "") {
                    $("#lbl_zgcs").text("内容不能为空");
                    $("#lbl_zgcs").css("color", "#ff0000");
                }
                else {
                    $("#lbl_zgcs").text("正确");
                    $("#lbl_zgcs").css("color", "#00ff00");
                }
            });
            //整改时限
            $("#tbx_zgsx").blur(function () {
                if ($("#tbx_zgsx").val().trim() == "") {
                    $("#lbl_zgsx").text("内容不能为空");
                    $("#lbl_zgsx").css("color", "#ff0000");
                }
                else {
                    var ys = /^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$/;
                    if (!ys.test($("#tbx_zgsx").val())) {
                        $("#lbl_zgsx").text("请输入正确格式如（1996-01-02）");
                        $("#lbl_zgsx").css("color", "#ff0000");
                    }
                    else {
                        $("#lbl_zgsx").text("正确");
                        $("#lbl_zgsx").css("color", "#00ff00");
                    }
                }
            });
            //等效措施或预案
            $("#tbx_dxcs").blur(function () {
                if ($("#tbx_dxcs").val().trim() == "") {
                    $("#lbl_dxcs").text("内容不能为空");
                    $("#lbl_dxcs").css("color", "#ff0000");
                }
                else {
                    $("#lbl_dxcs").text("正确");
                    $("#lbl_dxcs").css("color", "#00ff00");
                }
            });
            //与危险源相关联的事件或典型案例
            $("#tbx_ywxyxg").blur(function () {
                if ($("#tbx_ywxyxg").val().trim() == "") {
                    $("#lbl_ywxyxg").text("内容不能为空");
                    $("#lbl_ywxyxg").css("color", "#ff0000");
                }
                else {
                    $("#lbl_ywxyxg").text("正确");
                    $("#lbl_ywxyxg").css("color", "#00ff00");
                }
            });
            //备注
            $("#tbx_bz").blur(function () {
                if ($("#tbx_bz").val().trim() == "") {
                    $("#lbl_bz").text("内容不能为空");
                    $("#lbl_bz").css("color", "#ff0000");
                }
                else {
                    $("#lbl_bz").text("正确");
                    $("#lbl_bz").css("color", "#00ff00");
                }
            });
        } );
        </script>
    <script type="text/javascript">  
    var login_zrr = document.getElementById('login_zrr');
    var over = document.getElementById('over'); //弹出层
    function show_zrr() {
        login_zrr.style.display = "block";
        over.style.display = "block";
    };
    function hide()  
    {
        login.style.display = "none";
        over.style.display = "none";
    } 
</script> 

</html>
