<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AQXX_Edit.aspx.cs" Inherits="CUST.WKG.AQXX_Edit" %>

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
    <link  rel="stylesheet" type="text/css" href="../../Content/css/ygxz.css"/>

     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
         .auto-style1 {
             background: #F6FAFD;
             width: 30%;
             height: 35px;
         }
         .auto-style2 {
             background: #F6FAFD;
             width: 40%;
             height: 35px;
         }
         .auto-style3 {
             background: #F6FAFD;
             width: 30%;
             height: 31px;
         }
         .auto-style4 {
             background: #F6FAFD;
             width: 40%;
             height: 31px;
         }
    </style>
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
         #login_yg
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
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">

            <div class="panel-head">
                <strong class="icon-reorder">风险源分析编辑</strong>
            </div>
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送员工：</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_bh" runat="server" Width="150px"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送岗位：</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">              
                        <asp:Label ID="lbl_bsgw" runat="server" Width="150px"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送时间：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bssj" runat="server" class="Wdate" Height="20px" Width="250px" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:Label ID="lbl_bssj" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">责任部门：&nbsp;&nbsp;</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zrbm" runat="server" Width="250px"></asp:DropDownList>
                        <asp:Label ID="lbl_zrbm" runat="server"></asp:Label>
                    </td>

                </tr>
                

                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备注：&nbsp;&nbsp;</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bz" runat="server" class="input-text"
                            Width="250px" MaxLength="200"></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 30%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">特情处置：<span class="c-red"></span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_tqcz" runat="server" Height="25px" OnSelectedIndexChanged="ddlt_tqcz_change" AutoPostBack="true"></asp:DropDownList>
                        
                    </td>


                </tr>
            </table>

            <div id="div_tqczf" style="text-align:center" runat="server">
            <strong class="icon-reorder">否</strong>
            </div>
            <div id="div_tqczs" style="text-align:center" runat="server">
        <strong class="icon-reorder">是</strong>
        

            <table >
            <%--<tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                  报送员工：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">           
                    <asp:Label ID="lbl_bh1" runat="server" ></asp:Label>
                      </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    报送岗位：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                     <asp:Label ID="lbl_bsgw1" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    报送时间：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:TextBox ID="tbx_bssj1" runat="server"  class="Wdate"   Height="20px"  Width="150px" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                    <asp:Label ID="lbl_bssj1" runat="server" ></asp:Label>
                </td>
                
            </tr>--%>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   管制情况：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_gzqk" runat="server" class="input-text" 
                 Width="150px" MaxLength="50" ></asp:TextBox>
                    <asp:Label ID="lbl_gzqk" runat="server" ></asp:Label>
                </td>
            </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   事件涉及的航空器和机组有关情况：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:TextBox ID="tbx_sjqk" runat="server" class="input-text" 
                 Width="150px" MaxLength="50" ></asp:TextBox>
                    <asp:Label ID="lbl_sjqk" runat="server" ></asp:Label>
                </td>
                
            </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   空管相关设备运行状况：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:TextBox ID="tbx_sbyxqk" runat="server" class="input-text"
                 Width="150px" MaxLength="50" ></asp:TextBox>
                    <asp:Label ID="lbl_sbyxqk" runat="server" ></asp:Label>
                </td>
                
            </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   事发时间：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:TextBox ID="tbx_sfsj" runat="server" class="Wdate" 
                 Width="150px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="lbl_sfsj" runat="server" ></asp:Label>
                </td>
                
            </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   责任单位：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <asp:DropDownList ID="ddlt_zrdw" runat="server" Width="150px"></asp:DropDownList>
                     <asp:Label ID="lbl_zrdw" runat="server" ></asp:Label>
                </td>
                
            </tr>


             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   负责人 ：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                <asp:TextBox ID="tbx_fzr" runat="server" class="input-text"
                 Width="150px" MaxLength="10" Enabled="False"></asp:TextBox>
                     
                   <a href="javascript:show_yg()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_yg">
                            <table>
                                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                部门： 
                                             <asp:DropDownList ID="ddlt_bmdm" runat="server" AutoPostBack="True"
                                                 class="select-box" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged"  Style="width: 130px">
                                             </asp:DropDownList>
                                                           <br /> 岗位： 
                                                <asp:DropDownList ID="ddlt_gwdm" runat="server" class="select-box"  AutoPostBack="True"  Style="width: 130px" OnSelectedIndexChanged="ddlt_gwdm_SelectedIndexChanged"></asp:DropDownList>                                        
                                                           <br /> 员工： 
                                                <asp:DropDownList ID="ddlt_yg" runat="server"  class="select-box" Style="width: 130px"></asp:DropDownList>                                    
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
                                            <asp:Button ID="btn_zrr" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClick="btn_zrr_Click" OnClientClick="hide()" Text="保存"
                                                Width="100px" />
                                        </td >
                                        <td style="width: 30%; text-align: left">
                                            <asp:Button ID="btn_gb" runat="server" BackColor="#60B1D7" class="btn  radius"
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
                </td>
                
            </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   报告时间 ：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   <asp:TextBox ID="tbx_bgsj" runat="server" class="Wdate" 
                 Width="150px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="lbl_bgsj" runat="server" ></asp:Label>
                </td>
                
        </tr>
        <%--<tr style="vertical-align: top;  width:100%;height:55px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    备注：&nbsp;&nbsp;</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_bz1" runat="server" class="input-text" 
                 Width="500px"  Multiply="true" Height="50px"></asp:TextBox>
                    <asp:Label ID="lbl_bz1" runat="server" ></asp:Label>
                </td>
                
            </tr>--%>
        </table>
</div>
            <div class="row cl">
                <div class="row cl" style="text-align: center; width: 100%; margin: 0 auto;">
                    <table>
                        <tr>
                            <td style="text-align: right">
                                <asp:Button ID="btn_save" runat="server"
                                    Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                                    Width="199px" OnClick="btn_save_Click"></asp:Button></td>
                            <td>&nbsp;</td>
                            <td style="text-align: left">
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
    var login_yg = document.getElementById('login_yg');
    var over = document.getElementById('over'); //弹出层
    function show_yg() {
        login_yg.style.display = "block";
        over.style.display = "block";
    }
    $("#btn_zrr").click(function () {
        hide();
    });
    function hide() {
        login_yg.style.display = "none";
        over.style.display = "none";
    }
</script>
<script type="text/javascript">  
    var login = document.getElementById('login');  //弹出层中的登录框
    var over = document.getElementById('over'); //弹出层
    function show()  
    {  
        login.style.display = "block";
        login.style.position = "absoulte";
        login.style.alignContent = "center";
        login.style.zIndex = "5555";
        login.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
        login.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
        over.style.display = "block";
   
    }
    $("#btn_bc").click(function ()
    {
        hide();
    });
    function hide()  
    {
        login.style.display = "none";
        over.style.display = "none";
    }  
</script>    
<script type="text/javascript">  
    var login = document.getElementById('login');  //弹出层中的登录框
    var over = document.getElementById('over'); //弹出层
    function show()  
    {  
        login.style.display = "block";
        login.style.position = "absoulte";
        login.style.alignContent = "center";
        login.style.zIndex = "5555";
        login.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
        login.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
        over.style.display = "block";
   
    }
    $("#btn_bc").click(function ()
    {
        hide();
    });
    function hide()  
    {
        login.style.display = "none";
        over.style.display = "none";
    }  
</script>
</html>
