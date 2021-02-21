<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LL_Add.aspx.cs" Inherits="CUST.WKG.LL_Add" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
  
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
      <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="Link1" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
   
   
     <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
              
            }    
    </style>
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
      #login ,#login_1,#login_csr,#login_zsr
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
   
    #over  ,#over_1,#over_csr,#over_zsr
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
      <%--   <nav class="breadcrumb">个人信息管理 <span class="c-gray en">&gt;</span> 个人信息<span class="c-gray en">&gt;</span>员工添加
         </nav>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
	<div class="panel-head">
            <strong class="icon-reorder">员工履历添加</strong>
        </div>
    <table >


          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   员 工 编 号：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                  <%-- <asp:TextBox ID="tbx_bh" runat="server" class="input-text" placeholder="员工编号" 
                 Width="446px" MaxLength="10"></asp:TextBox>--%>
                    <asp:Label ID="lbl_bh" runat="server" ></asp:Label>
                      </td>
            </tr>   
    
 
<%--        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    数据所属部门：<span class="c-red">*</span></td>
                <td colspan="2" style="width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjzl">  
                    <asp:DropDownList ID="ddlt_bmdm" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_bmdm" runat="server" ></asp:Label>
                    </td>
            </tr>--%>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    工 作 单 位：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:TextBox ID="tbx_gzdw" runat="server" class="input-text" placeholder="工作单位(不能超过20字！)" 
                 Width="446px" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="lbl_gzdw" runat="server" ></asp:Label>
                    </td>
            </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    工 作 部 门：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_gzbm" runat="server" class="input-text" placeholder="工作部门(不能超过20字！)" 
                 Width="446px" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="lbl_gzbm" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    工 作 岗 位：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_gzgw" runat="server" class="input-text" placeholder="工作岗位(不能超过20字！)" 
                 Width="446px" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="lbl_gzgw" runat="server" ></asp:Label>
                </td>
                
            </tr>
       

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    工 作 地 点：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_gzdd" runat="server" placeholder="工作地点(不能超过20字！)" class="input-text"
                 Width="446px" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="lbl_gzdd" runat="server" ></asp:Label>
                </td>
                
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    起 始 日 期：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_qzrq" runat="server" class="input-text" placeholder="起止日期" 
                 Width="446px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="lbl_qzrq" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    截 止 日 期：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                       <asp:TextBox ID="tbx_jzrq" runat="server" class="input-text" placeholder="截止日期" 
                 Width="446px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="lbl_jzrq" runat="server" ></asp:Label>
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
         
        
        
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    备 注：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_bz" runat="server" class="input-text" placeholder="备注" 
                 Width="446px" MaxLength="200"></asp:TextBox>
                    <asp:Label ID="lbl_bz" runat="server" ></asp:Label>
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
    
</body>
    <script src="../../Content/js/jquery.js" type="text/javascript"></script>
      <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
       <%--<script type="text/javascript">
        //$(document).ready(function () {
        //    ////员工编号
        //    //$("#tbx_bh").blur(function () {
        //    //    if ($("#tbx_bh").val() != "") {
        //    //        $("#lbl_bh").text("正确");
        //    //        $("#lbl_bh").css("color", "#00ff00");
        //    //    } else {
        //    //        $("#lbl_bh").text("错误");
        //    //        $("#lbl_bh").css("color", "#ff0000");
        //    //    }
        //    //});
        //    //工作单位
        //    $("#tbx_gzdw").click(function () {
               
        //            $("#lbl_zzdw").text("正确");
        //            $("#lbl_zzdw").css("color", "#00ff00");
              
        //    });
        //    //工作部门
        //    $("#tbx_gzbm").blur(function () {
        //            $("#lbl_gzbm").text("正确");
        //            $("#lbl_gzbm").css("color", "#00ff00");
               
        //    });
        //    //工作岗位
        //    $("#tbx_gzgw").blur(function () {
        //            $("#lbl_gzgw").text("正确");
        //            $("#lbl_gzgw").css("color", "#00ff00");
              
        //    });
        //    //工作地点
        //    $("#tbx_gzdd").blur(function () {
        //            $("#lbl_zzdd").text("正确");
        //            $("#lbl_zzdd").css("color", "#00ff00");
               
        //    });
        //    //起止日期
        //    $("#tbx_qzrq").blur(function () {
        //            $("#lbl_qzrq").text("正确");
        //            $("#lbl_qzrq").css("color", "#00ff00");
               
        //    });
        //    //截止日期
        //    $("#tbx_jzrq").blur(function () {
        //            $("#lbl_jzrq").text("正确");
        //            $("#lbl_jzrq").css("color", "#00ff00");
               
        //    });
           
        //    //备注
        //    $("#tbx_bz").blur(function () {
        //            $("#lbl_bz").text("正确");
        //            $("#lbl_bz").css("color", "#00ff00");
                   
        //    });
          
        //});
    </script> --%>
    <script type="text/javascript">


        var login_csr = document.getElementById('login_csr');  //弹出层中的登录框
        var over_csr = document.getElementById('over_csr'); //弹出层
        function show_csr() {
            login_csr.style.display = "block";
            login_csr.style.position = "absoulte";
            login_csr.style.alignContent = "center";
            login_csr.style.zIndex = "5555";
            login_csr.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
            login_csr.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
            over_csr.style.display = "block";
            over_csr.style.position = "absoulte";
            over_csr.style.alignContent = "center";
        }
        $("#btn_bc_3").click(function () {
            hide_csr();
        });
        function hide_csr() {
            login_csr.style.display = "none";
            over_csr.style.display = "none";
        }
</script> 


 <script type="text/javascript">

     var login_zsr = document.getElementById('login_zsr');  //弹出层中的登录框
     var over_zsr = document.getElementById('over_zsr'); //弹出层
     function show_zsr() {
         login_zsr.style.display = "block";
         login_zsr.style.position = "absoulte";
         login_zsr.style.alignContent = "center";
         login_zsr.style.zIndex = "5555";
         login_zsr.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
         login_zsr.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
         over_zsr.style.display = "block";
         over_zsr.style.position = "absoulte";
         over_zsr.style.alignContent = "center";
     }
     $("#btn_bc_4").click(function () {
         hide_zsr();
     });
     function hide_zsr() {
         login_zsr.style.display = "none";
         over_zsr.style.display = "none";

     }
 </script> 


 <script type="text/javascript">
     var login_1 = document.getElementById('login_1');  //弹出层中的登录框
     var over_1 = document.getElementById('over_1'); //弹出层
     function show_1() {
         login_1.style.display = "block";
         login_1.style.position = "absoulte";
         login_1.style.alignContent = "center";
         login_1.style.zIndex = "5555";
         login_1.style.top = (document.documentElement.clientHeight - login_1.offsetHeight) / 2 + "px";
         login_1.style.left = (document.documentElement.clientWidth - login_1.offsetWidth) / 2 + "px";
         over_1.style.display = "block";

     }
     $("#btn_bc_1").click(function () {
         hide_1();
     });
     function hide_1() {
         login_1.style.display = "none";
         over_1.style.display = "none";
     }
</script>
</html>
