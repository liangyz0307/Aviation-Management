<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JCJL_Edit.aspx.cs" Inherits="CUST.WKG.JCJL_Edit" %>
<%@ Register TagPrefix="hw" Namespace="UNLV.IAP.WebControls" Assembly="DropDownCheckList" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
      #login  
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
      jsc
            {
                background:#F6FAFD;
            }  
    #over  
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
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
     <strong class="icon-reorder">检查记录编辑</strong>
    </div>
        <div>
        <table>
             <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_jcsj">
                     <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj"> 检 查 时 间：<span class="c-red">*</span></td>
                     <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj">
                         <asp:TextBox ID="tbx_jcsj" runat="server" class="input-text" onclick="lhgcalendar({format:'yyyy-MM-dd'})" placeholder="检查时间" Width="444px"></asp:TextBox>
                        <asp:Label ID="lbl_jcsj" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">被 检 单 位：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_bjdw" runat="server" Width="455px" Height="27px"></asp:DropDownList>
                        <asp:Label ID="lbl_bjdw" runat="server"></asp:Label>
                    </td>
           </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">填 报 单 位：</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_tbdw" runat="server" class="input-text" Width="446px" Height="20px" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbl_tbdw" runat="server"></asp:Label>
                    </td>
           </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_jcsj">
                     <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc"> 检 查 项 目：</td>
                     <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_jcxm" runat="server" class="input-text" Width="446px"  Enabled="False" Height="20px"></asp:TextBox>
                        <asp:Label ID="lbl_jcxm" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_jcsj">
                     <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">检 查 结 果 ：<span class="c-red">*</span></td>
                     <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_jcjg" runat="server" Width="455px" Height="27px" AutoPostBack="True"></asp:DropDownList>
                        <asp:Label ID="lbl_jcjg" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_jcsj">
                     <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj"> 整 改 意 见:<span class="c-red">*</span></td>
                     <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj">
                        <asp:TextBox ID="tbx_zgyj" runat="server" class="input-text" Width="446px"  Enabled="true" Height="20px"></asp:TextBox>
                        <asp:Label ID="lbl_zgyj" runat="server"></asp:Label>
                    </td>
             </tr>
<%--            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_jcsj"> 
                     <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj"> 责 任 单 位：<span class="c-red">*</span></td>
                     <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj">
                        <asp:DropDownList ID="ddlt_tzzrdw" runat="server" Width="453px" Height="22px"></asp:DropDownList>
                        <asp:Label ID="lbl_tzzrdw" runat="server"></asp:Label>
                    </td>
             </tr>--%>
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_jcsj">
                     <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj"> 责 任 人：</td>
                     <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj">
                        <asp:TextBox ID="tbx_tzzrry" runat="server" class="input-text" Width="446px"  Height="20px"></asp:TextBox>
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
                                      class="select-box" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged1"
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
                                  <asp:DropDownList ID="ddlt_syr" runat="server" class="select-box"
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
                                <asp:Button ID="btn_bc" runat="server" BackColor="#60B1D7" class="btn  radius"
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
                        <asp:Label ID="lbl_tzzrry" runat="server"></asp:Label>
                    </td>
             </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_jcsj">
                     <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj"> 落实情况反馈：<span class="c-red">*</span></td>
                     <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj">
                        <asp:TextBox ID="tbx_lsqkfk" runat="server" class="input-text" Width="446px"  Enabled="true" Height="20px"></asp:TextBox>
                        <asp:Label ID="lbl_lsqkfk" runat="server"></asp:Label>
                    </td>
             </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_jcsj">
                     <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj"> 备 注：<span class="c-red">*</span></td>
                     <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj">
                        <asp:TextBox ID="tbx_bz" runat="server" class="input-text" Width="446px"  Enabled="true" Height="20px"></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>
             </tr>
             <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_jcsj">
                     <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj"> 上 传 文 件：</td>
                     <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj">
                         <asp:FileUpload ID="fiup_wj" runat="server" />
                        
                    </td>
             </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_jcsj">
                     <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj"> 检 查 人：</td>
                     <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_jcsj">
                        <asp:Label ID="lbl_jcr" runat="server"></asp:Label>
                    </td>
             </tr>
        </table>
       <div class="row cl">
                <div class="row cl" style="text-align: center; width: 100%; margin: 0 auto;">
         <table>
                        <tr>                            
                        <td>
                                <asp:Button ID="btn_Save" runat="server"
                                    Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                                    Width="150px" style="margin-left: 0px" OnClick="btn_Save_Click"  ></asp:Button>
                            </td>
                            <td style="text-align:left;width: 40%;">
                                <asp:Button ID="btn_fh" runat="server"
                                    Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                    Width="150px"  Style="margin-bottom: 0px" OnClick="btn_fh_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
           </div>
    </div>
    </form>
</body>
     <script type="text/javascript">
         var login = document.getElementById('login');  //弹出层中的登录框
         var over = document.getElementById('over'); //弹出层
         function show() {
             login.style.display = "block";
             over.style.display = "block";
         }
         $("#btn_bc").click(function () {
             hide();
         });
         function hide() {
             login.style.display = "none";
             over.style.display = "none";
         }
</script> 
</html>
