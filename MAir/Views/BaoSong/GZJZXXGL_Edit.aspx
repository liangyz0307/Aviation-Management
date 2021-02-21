<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GZJZXXGL_Edit.aspx.cs" Inherits="CUST.WKG.GZJZXXGL_Edit" %>

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
        height:160px;  
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
        #LinkButton1 {
            background-image:url(../../Content/images/add.png)
        }
    </style>  
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
            <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送员工：</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">                     
                        <asp:Label ID="lbl_bsyg" runat="server" Width="300" Height="25px"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送部门：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                                                  <asp:Label ID="lbl_bsbm" runat="server"></asp:Label>
                    </td>
                </tr>
              
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送支线：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_bszx" runat="server" Width="446px" placeholder="报送支线"></asp:DropDownList>
                          <asp:Label ID="lbl_bszx" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">报送时间：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bssj" runat="server" class="input-text" placeholder="报送时间"
                            Width="446px" MaxLength="50" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:Label ID="lbl_bssj" runat="server"></asp:Label>
                    </td>
                 </tr>
                          <asp:HiddenField ID="gzfzrHiddenField" runat="server" />  
                       <tr  style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">工作负责人：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_gzfzr" Width="446px" MaxLength="15" runat="server" class="input-text" placeholder="工作负责人" ></asp:TextBox>
                                                  <a href="javascript:show_gzfzrxm()">
                            <img alt="" src="../../Content/images/add.png" /></a>
                        <%--   填写内容层  --%>
                                                <div id="login">
                            <table>
                                <tr class="td_sjsc"
                                    style="vertical-align: top; width: 100%; height: 60px; border: 1px solid #C0D9D9;">
                                    <td class="td_sjsc" colspan="2"
                                        style="width: 60%; text-align: left; vertical-align: middle;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门： 
                                  <asp:DropDownList ID="ddlt_bmdm1" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_bmdm1_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 岗位： 
                                  <asp:DropDownList ID="ddlt_gwdm1" runat="server" AutoPostBack="True"
                                      class="select-box" OnSelectedIndexChanged="ddlt_gwdm1_SelectedIndexChanged"
                                      Style="width: 130px">
                                  </asp:DropDownList>
                                                <br />
                                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 员工： 
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
                                            <asp:Button ID="btn_bc_syr1" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClick="btn_bc_syr1_Click" OnClientClick="hide()" Text="保存"
                                                Width="100px" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btn_gb1" runat="server" BackColor="#60B1D7" class="btn  radius"
                                                ForeColor="White" OnClientClick="hide()" Text="关闭"
                                                Width="100px" />
                               </div>
                        </div>
                        <%-- 背景层--%>
                        <div id="over">
                        </div>
                        <asp:Label ID="lbl_gzfzr" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">工作轮次：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_gzlc" Width="446px" MaxLength="10" runat="server" class="input-text" placeholder="工作伦次"></asp:TextBox>
                        <asp:Label ID="lbl_gzlc" runat="server"></asp:Label>
                    </td>

                </tr>
                  <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">工作主题：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_gzzt" name="tbx_gzzt" runat="server" class="input-text" Height="80px" TextMode="MultiLine"
                            Width="446px" MaxLength="2000" placeholder="工作主题"   ></asp:TextBox>
                        <asp:Label ID="lbl_gzzt" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">工作内容：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_gznr" name="tbx_gznr" runat="server" TextMode="MultiLine" Height="200px" Width="450px" ClientIDMode="Static" axLength="2000"> </asp:TextBox>
                        <asp:Label ID="lbl_gznr" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">完成进度：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_wcjd" Width="446px" MaxLength="50" runat="server" class="input-text" placeholder="完成进度"></asp:TextBox>
                        <asp:Label ID="lbl_wcjd" runat="server"></asp:Label>
                    </td>

                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">完成时限：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_wcsx" runat="server" class="input-text" placeholder="完成时限"
                            Width="446px" MaxLength="20" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:Label ID="lbl_wcsx" runat="server"></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                    <td class="td_sjsc" colspan="2" style="text-align:center;border: 1px solid #C0D9D9;" >
                      
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                             <ContentTemplate>
                               <asp:placeholder id="plah_gzbz" runat="server"></asp:placeholder>
                               <br />
                               <asp:Button ID="btn_gzbz" runat="server" Text="添加工作步骤" class="btn  radius" BackColor="#60B1D7"
                                  ForeColor="White" Width="199px" OnClick="btn_gzbz_Click"  ></asp:Button>
                               <asp:Button ID="btn_scgzbz" runat="server" Text="删除工作步骤" class="btn  radius" BackColor="#60B1D7"
                              ForeColor ="White" Width="199px" OnClick="btn_scgzbz_Click"  ></asp:Button>
                           </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>            
             
                
                <tr style="vertical-align: top; width: 100%; height: 50px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备注：<span class="c-red">&nbsp;&nbsp</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bz" Width="446px" MaxLength="2000" TextMode="MultiLine"  Height="50px" runat="server" class="input-text" placeholder="备注"></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>
                   
                </tr>
                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">初审人：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_csr" runat="server" Width="446px" placeholder="报送支线"></asp:DropDownList>
                          <asp:Label ID="lbl_csr" runat="server"></asp:Label>
                    </td>

                </tr>
                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">终审人：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zsr" runat="server" Width="446px" placeholder="报送支线"></asp:DropDownList>
                          <asp:Label ID="lbl_zsr" runat="server"></asp:Label>
                    </td>

                </tr>
                                                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 14%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">数据所在部门：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_sjszbm" runat="server" style="width:446px"></asp:DropDownList>
                          <asp:Label ID="lbl_sjszbm" runat="server"></asp:Label>
                    </td>

                </tr>
            </table>
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btn_save" runat="server"
                                Text="保存" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_save_Click"></asp:Button></td>
                        <td style="text-align: left">
                            <asp:Button ID="btn_fh" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_fh_Click"></asp:Button>
                           

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
        login.style.position = "absoulte";
        login.style.alignContent = "center";
        login.style.zIndex = "5555";
        login.style.top = (document.documentElement.clientHeight - login.offsetHeight) / 2 + "px";
        login.style.left = (document.documentElement.clientWidth - login.offsetWidth) / 2 + "px";
        over.style.display = "block";
        gzfzrHiddenField.value = 1;
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
    <script src="../css/js/jquery.js" type="text/javascript"></script>
<script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
<script type="text/javascript">
    //$("#btn_save").click(function () {
    //    var i = 0;
    //    //报送时间
    //        if ($("#tbx_bssj").val().trim() == "") {
    //            $("#lbl_bssj").text("内容不能为空");
    //            $("#lbl_bssj").css("color", "#ff0000");
    //        }
    //        else {
    //            var ys = /^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$/;
    //            if (!ys.test($("#tbx_bssj").val())) {
    //                $("#lbl_bssj").text("请输入正确格式如（1996-01-02）");
    //                $("#lbl_bssj").css("color", "#ff0000");
    //            }
    //            else {
    //                $("#lbl_bssj").text("正确");
    //                $("#lbl_bssj").css("color", "#00ff00");
    //            }
    //        }
    //    //完成时限
    //        if ($("#tbx_wcsx").val().trim() == "") {
    //            $("#lbl_wcsx").text("内容不能为空");
    //            $("#lbl_wcsx").css("color", "#ff0000");
    //        }
    //        else {
    //            var ys = /^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$/;
    //            if (!ys.test($("#tbx_wcsx").val())) {
    //                $("#lbl_wcsx").text("请输入正确格式如（1996-01-02）");
    //                $("#lbl_wcsx").css("color", "#ff0000");
    //            }
    //            else {
    //                $("#lbl_wcsx").text("正确");
    //                $("#lbl_wcsx").css("color", "#00ff00");
    //            }
    //        }

    //    //步骤完成时限
    //        if ($("#tbx_bzwcsx").val().trim() == "") {
    //            $("#lbl_bzwcsx").text("内容不能为空");
    //            $("#lbl_bzwcsx").css("color", "#ff0000");
    //        }
    //        else {
    //            var ys = /^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$/;
    //            if (!ys.test($("#tbx_bzwcsx").val())) {
    //                $("#lbl_bzwcsx").text("请输入正确格式如（1996-01-02）");
    //                $("#lbl_bzwcsx").css("color", "#ff0000");
    //            }
    //            else {
    //                $("#lbl_bzwcsx").text("正确");
    //                $("#lbl_bzwcsx").css("color", "#00ff00");
    //            }
    //        }


    //    //支线名称

    //    if ($("#ddlt_bszx").val().trim() == "-1") {
    //        $("#lbl_bszx").text("错误：请选择！");
    //        $("#lbl_bszx").css("color", "#ff0000");
    //        $("#lbl_bszx").focus();
    //        i = 1;
    //    }
    //    else {
    //        $("#lbl_bszx").text("正确");
    //        $("#lbl_bszx").css("color", "#00ff00");
    //    }


    //    ////工作内容
    //    //if ($("#tbx_gznr").val() != "") {
    //    //    $("#lbl_gznr").text("正确");
    //    //    $("#lbl_gznr").css("color", "#00ff00");
    //    //} else {
    //    //    $("#lbl_gznr").text("工作内容不能为空");
    //    //    $("#lbl_gznr").css("color", "#ff0000");
    //    //    i = 1;
    //    //}


    //    //完成进度
    //    if ($("#tbx_wcjd").val() != "") {
    //        $("#lbl_wcjd").text("正确");
    //        $("#lbl_wcjd").css("color", "#00ff00");
    //    } else {
    //        $("#lbl_wcjd").text("完成进度不能为空");
    //        $("#lbl_wcjd").css("color", "#ff0000");
    //        i = 1;
    //    }
    //    //工作主题
    //    if ($("#tbx_gzzt").val() != "") {
    //        $("#lbl_gzzt").text("正确");
    //        $("#lbl_gzzt").css("color", "#00ff00");
    //    } else {
    //        $("#lbl_gzzt").text("工作主题不能为空");
    //        $("#lbl_gzzt").css("color", "#ff0000");
    //        i = 1;
    //    }
    //    //工作步骤
    //    if ($("#tbx_gzbz").val() != "") {
    //        $("#lbl_gzbz").text("正确");
    //        $("#lbl_gzbz").css("color", "#00ff00");
    //    } else {
    //        $("#lbl_gzbz").text("工作主题不能为空");
    //        $("#lbl_gzbz").css("color", "#ff0000");
    //        i = 1;
    //    }
    //    //工作轮次
    //    if ($("#tbx_gzlc").val() != "") {
    //        var re = /^\d+(?=\.{0,1}\d+$|$)/
    //        if (!re.test($("#tbx_gzlc").val())) {
    //            $("#lbl_gzlc").text("请输入数字！");
    //            $("#lbl_gzlc").css("color", "#ff0000");
    //            i = 1;
    //        }
    //        else {
    //            $("#lbl_gzlc").text("正确");
    //            $("#lbl_gzlc").css("color", "#00ff00");
    //        }
    //    }
    //    else {

    //        $("#lbl_gzlc").text("工作轮次不能为空");
    //        $("#lbl_gzlc").css("color", "#ff0000");
    //        i = 1;
    //    }


    //   // 备注
    //    $("#tbx_bz").blur(function () {
    //    $("#lbl_bz").text("正确");
    //    $("#lbl_bz").css("color", "#00ff00");
    //    });
    //    if (i == 0) {
    //        return true;
    //    }
    //    else {
    //        i = 0;
    //        return false;
    //    }

    //});
</script>

</html>
