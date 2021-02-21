<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GZJZXXGL_Detail.aspx.cs" Inherits="CUST.WKG.GZJZXXGL_Detail" %>

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
                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">报送员工：</td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">                     
                        <asp:Label ID="lbl_bsyg" runat="server" Width="300" Height="25px"></asp:Label>
                    </td>
                      <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">报送部门：<span class="c-red"></span></td>
                    <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                      <asp:Label ID="lbl_bsbm" runat="server" Width="446px" placeholder="报送部门"></asp:Label>
                    </td>
                </tr>
              
                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">报送支线：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                          <asp:Label ID="lbl_bszx" runat="server"></asp:Label>
                    </td>
                      <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">报送时间：<span class="c-red"></span></td>
                    <td  style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_bssj" runat="server"></asp:Label>
                    </td>
                         </tr>
                <tr   style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">工作负责人：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_gzfzr" runat="server"></asp:Label>
                    </td>
                     <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">工作轮次：<span class="c-red"></span></td>
                    <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_gzlc" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">完成进度：<span class="c-red"></span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_wcjd" runat="server"></asp:Label>
                    </td>
                        <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">完成时限：<span class="c-red"></span></td>
                    <td  style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:Label ID="lbl_wcsx" runat="server"></asp:Label>
                        
                    </td>
                </tr>
                       
                                  <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">工作主题：<span class="c-red"></span></td>
                    <td colspan="3" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:Label ID="lbl_gzzt" runat="server"></asp:Label>
                    </td>

                </tr>
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">工作内容：<span class="c-red"></span></td>
                    <td colspan="3" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                   
                        <asp:Label ID="lbl_gznr" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr  style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9;">
                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">备注：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                        <asp:Label ID="lbl_bz" runat="server" TextMode="MultiLine"></asp:Label>
                    </td>                 
                </tr>
                  <div class="mt-20">
                            <asp:Repeater ID="rpt_gzjz" runat="server" >
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th width="80" style="text-align: center ;">工作步骤
                                    </th>
                                    <th width="20" style="text-align: center;">完成时限
                                    </th>
                                    

                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("gzbz") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("wcsx") %>'></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                 <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                       </div>
                 </table>
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                         <table>
                  <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">            

             
               <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                  初 审 人：<span class="c-red"></span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"><asp:Label ID="lbl_csr" runat="server" ></asp:Label></td>     
                                    <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   终 审 人：<span class="c-red"></span></td>
                <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"><asp:Label ID="lbl_zsr" runat="server" ></asp:Label></td>                      
            </tr>
        
          
                </table>
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
      <script type="text/javascript">  
         var login = document.getElementById('login');  //弹出层中的登录框
    var over = document.getElementById('over'); //弹出层
    function show_gzfzrxm()
    {  
        login.style.display = "block";
        over.style.display = "block";
    }
    function btn_bc_syr1()
    {
        btn_syr.style.display = "block";
    }
    $("#btn_bc_syr1").click(function ()
    {
        hide();
    });
    function hide()  
    {
        login.style.display = "none";
        over.style.display = "none";
    } 
</script> 
<script src="../css/js/jquery.js" type="text/javascript"></script>
   <script type="text/javascript">

          //实例化编辑器
          var ue = UE.getEditor('tbx_gznr');

</script>
<script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
<script type="text/javascript">

    var i = 0;

    $("#btn_save").click(function () {

        //报送时间
        if ($("#tbx_bssj").val() != "") {
            $("#lbl_bssj").text("正确");
            $("#lbl_bssj").css("color", "#00ff00");
        } else {
            $("#lbl_bssj").text("报送时间不能为空");
            $("#lbl_bssj").css("color", "#ff0000");
            i = 1;
        }

        //支线名称

        if ($("#ddlt_bszx").val().trim() == "-1") {
            $("#lbl_bszx").text("错误：请选择！");
            $("#lbl_bszx").css("color", "#ff0000");
            $("#lbl_bszx").focus();
            i = 1;
        }
        else {
            $("#lbl_bszx").text("正确");
            $("#lbl_bszx").css("color", "#00ff00");
        }
        //执行支线
        if ($("#ddlt_zxzx").val().trim() == "-1") {
            $("#lbl_zxzx").text("错误：请选择！");
            $("#lbl_zxzx").css("color", "#ff0000");
            $("#lbl_zxzx").focus();
            i = 1;
        }
        else {
            $("#lbl_zxzx").text("正确");
            $("#lbl_zxzx").css("color", "#00ff00");
        }

        //工作内容
        $("#tbx_gznr").blur(function () {
        if ($("#tbx_gznr").val() != "") {
            $("#lbl_gznr").text("正确");
            $("#lbl_gznr").css("color", "#00ff00");
        } else {
            $("#lbl_gznr").text("工作内容不能为空");
            $("#lbl_gznr").css("color", "#ff0000");
            i = 1;
        }
        });

        //完成进度
        if ($("#tbx_wcjd").val() != "") {
            $("#lbl_wcjd").text("正确");
            $("#lbl_wcjd").css("color", "#00ff00");
        } else {
            $("#lbl_wcjd").text("完成进度不能为空");
            $("#lbl_wcjd").css("color", "#ff0000");
            i = 1;
        }
        //工作轮次
        if ($("#tbx_gzlc").val() != "") {
            var re = /^\d+(?=\.{0,1}\d+$|$)/
            if (!re.test($("#tbx_gzlc").val())) {
                $("#lbl_gzlc").text("请输入数字！");
                $("#lbl_gzlc").css("color", "#ff0000");
                i = 1;
            }
            else {
                $("#lbl_gzlc").text("正确");
                $("#lbl_gzlc").css("color", "#00ff00");
            }
        }
        else {

            $("#lbl_gzlc").text("工作轮次不能为空");
            $("#lbl_gzlc").css("color", "#ff0000");
            i = 1;
        }


        //备注
        //$("#tbx_bz").blur(function () {
        $("#lbl_bz").text("正确");
        $("#lbl_bz").css("color", "#00ff00");
        //});
        if (i == 0) {
            return true;
        }
        else {
            i = 0;
            return false;
        }
        //});

    });
</script>

</html>
