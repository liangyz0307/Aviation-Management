<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SPR_Add.aspx.cs" Inherits="CUST.WKG.SPR_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title></title>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>
     <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
     <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
            }    
    </style>
   <style type="text/css">
        #login_spr
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

    <div class="panel-head">
            <strong class="icon-reorder">审批人添加</strong>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
        </div>
    <table >
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:40%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    子系统名称：<span class="c-red">*</span></td>
                <td colspan="2" style="width:75%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                    <asp:DropDownList ID="ddlt_zxt" runat="server">
                    </asp:DropDownList>
                   
                    <asp:Label ID="lbl_zxt" runat="server" ></asp:Label>
                </td>
            </tr>
        <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">审批人：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_spr" runat="server" class="input-text" Enabled="false"
                            Width="250px" MaxLength="100"></asp:TextBox>
                          <a href="javascript:show_spr()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                        <div id="login_spr">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                部门： 
                                  <asp:DropDownList ID="ddlt_bmdm" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                岗位： 
                                  <asp:DropDownList ID="ddlt_gwdm" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_gwdm_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                员工： 
                                  <asp:DropDownList ID="ddlt_spr" runat="server" class="select-box"
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
                                            <asp:Button ID="btn_bc_spr" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClick="btn_bc_spr_Click" OnClientClick="hide()" Text="保存"
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
                        <asp:Label ID="lbl_spr" runat="server"></asp:Label>
                    </td>

                </tr>

       
        </table>
	 

	<div class="row cl">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
		    <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_save_Click"  ></asp:Button> 
            &nbsp; 
            <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px" OnClick="btn_fh_Click"   ></asp:Button> 
		</div>
	</div>
	</form>
</article>

     <script  src="../css/js/jquery.js" type="text/javascript"></script>
         <script type="text/javascript">  
     var login_spr = document.getElementById('login_spr');  //弹出层中的登录框
     var over = document.getElementById('over'); //弹出层

    function show_spr() {
        login_spr.style.display = "block";
        over.style.display = "block";
    }
    $("#btn_bc_spr").click(function () {
        hide();
    });
    function btn_bc_spr() {
        btn_syr.style.display = "block";
    } $("#btn_bc_spr").click(function () {
        hide();
    });
    function hide()  
    {
        login.style.display = "none";
        over.style.display = "none";
    }

</script> 
    <script type="text/javascript">
        $(document).ready(function () {

            //审批人
            $("#tbx_spr").blur(function() {
                if ($("#tbx_spr").val() != "") {
                    $("#lbl_spr").text("正确");
                    $("#lbl_spr").css("color", "#00ff00");
                } else
                {
                    $("#lbl_spr").text("错误");
                    $("#lbl_spr").css("color", "#ff0000");
                }
                  
            });
           
            //上级部门
            $("#ddlt_zxt").change(function() {

                if ($("#ddlt_zxt option:selected").val() != "-1") {
                $("#lbl_zxt").text("正确");
                $("#lbl_zxt").css("color", "#00ff00");
                } else {
                    $("#lbl_zxt").text("请选择");
                    $("#lbl_zxt").css("color", "#ff0000");
                }
            });
            
        });
    </script>
</body>
</html>