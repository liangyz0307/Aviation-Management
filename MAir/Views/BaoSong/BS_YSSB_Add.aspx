<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_YSSB_Add.aspx.cs" Inherits="CUST.WKG.BS_YSSB_Add" %>

<!DOCTYPE html>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>运行信息报送</title>
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
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
     <script type="text/javascript" src="../../UEdit/UEditor_TextBox.js" charset="utf-8"></script>
      <script type="text/javascript" src="../../Content/js/jquery.js" charset="utf-8"></script>
      <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js" charset="utf-8"></script>
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
        <div  style="padding:1%">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
        <table>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc"> 填 报 单 位：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_tbdw" runat="server" class="input-text"
                            Width="446px" MaxLength="10"  Height="20px"></asp:TextBox>
                        <asp:Label ID="lbl_tbdw" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">预 算 类 型：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_yslx" runat="server" Width="145px"  Height="20px"></asp:DropDownList>
                        <asp:Label ID="lbl_yslx" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">申 报 年 份：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_sbnf" runat="server" 
                            Width="446px" MaxLength="10"  Height="20px" class="Wdate" placeholder="登记日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:Label ID="lbl_sbnf" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">项 目 名 称：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_xmmc" runat="server" class="input-text" 
                            Width="446px" MaxLength="50" Height="20px" ></asp:TextBox>
                        <asp:Label ID="lbl_xmmc" runat="server"></asp:Label>
                    </td>

                </tr>


                <tr style="vertical-align: top; width: 100%; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">维 护 单 位：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                        <asp:TextBox ID="tbx_whdw" runat="server"  Height="20px" Width="446px"  class="input-text" ></asp:TextBox>
                        <asp:Label ID="lbl_whdw" runat="server"></asp:Label>
                    </td>

                </tr>
            <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">状 态：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_zt" runat="server" Width="145px"  Height="20px"></asp:DropDownList>
                        <asp:Label ID="lbl_zt" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">预 计 金 额：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_yjje" runat="server" class="input-text" 
                            Width="446px" Height="20px"></asp:TextBox>
                        <asp:Label ID="lbl_yjje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">实 际 执 行 金 额：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_sjzxje" runat="server" class="input-text" 
                            Width="446px" MaxLength="20" Height="20px"></asp:TextBox>
                        <asp:Label ID="lbl_sjzxje" runat="server"></asp:Label>
                    </td>

                </tr>

                 <tr  border: 1px solid #C0D9D9;" class="td_sjsc">
               <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">预算增项：</td>
               <td style="width:800px" align="left" class="td_sjsc">

                   <asp:TextBox ID="tbx_yszx" name="txtEditorContents" runat="server" TextMode="MultiLine" Height="100px" Width="446px" ClientIDMode="Static"> </asp:TextBox>
                   <asp:Label ID="lbl_yszx" runat="server" ></asp:Label>
               </td>
           </tr>
                             <tr  border: 1px solid #C0D9D9;" class="td_sjsc">
               <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">调整原因：</td>
               <td style="width:800px" align="left" class="td_sjsc">

                   <asp:TextBox ID="tbx_tzyy" name="txtEditorContents" runat="server" TextMode="MultiLine" Height="100px" Width="446px" ClientIDMode="Static"> </asp:TextBox>
                   <asp:Label ID="lbl_tzyy" runat="server" ></asp:Label>
               </td>
           </tr>
                
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">完 成 时 间：<span class="c-red">*</span></td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_wcsj" runat="server" class="Wdate" placeholder="登记日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                            Width="446px" MaxLength="10" Height="20px" ></asp:TextBox>
                        <asp:Label ID="lbl_wcsj" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;" class="td_sjsc">
                    <td style="width: 20%; text-align: right; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">备 注：</td>
                    <td colspan="2" style="width: 40%; text-align: left; vertical-align: middle; border: 1px solid #C0D9D9;" class="td_sjsc">
                        <asp:TextBox ID="tbx_bz" runat="server" class="input-text" 
                            Width="446px" MaxLength="200" Height="20px"></asp:TextBox>
                        <asp:Label ID="lbl_bz" runat="server"></asp:Label>
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
              <br />
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table style="width:100%">
                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="btn_save" runat="server"
                                Text="保存" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_save_Click" ></asp:Button></td>
                        <td>&nbsp;</td>
                        <td style="text-align: center">
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
    <script src="../css/js/jquery.js" type="text/javascript"></script>
   <script type="text/javascript">

          //实例化编辑器
          var ue = UE.getEditor('tbx_yszxtzyy');

</script>
<script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        //填报单位
        $("#tbx_tbdw").blur(function () {
            if ($("#tbx_tbdw").val().trim() == "") {
                $("#lbl_tbdw").text("内容不能为空");
                $("#lbl_tbdw").css("color", "#ff0000");
            }
            else {
                $("#lbl_tbdw").text("正确");
                $("#lbl_tbdw").css("color", "#00ff00");
            }
        });
        //预计金额
        $("#tbx_yjje").blur(function () {
            if ($("#tbx_yjje").val().trim() == "") {
                $("#lbl_yjje").text("内容不能为空");
                $("#lbl_yjje").css("color", "#ff0000");
            }
            else {
                var ys = /^[0-9]+(\.[0-9]{0,2})?$/
                if (!ys.test($("#tbx_yjje").val())) {
                    $("#lbl_yjje").text("请输入整数或小数");
                    $("#lbl_yjje").css("color", "#ff0000");
                }
                else {
                    $("#lbl_yjje").text("正确");
                    $("#lbl_yjje").css("color", "#00ff00");
                }


            }
        });
        //预算类型
        $("#ddlt_yslx").blur(function () {
            if ($("#ddlt_yslx option:selected").val() != "-1") {
                $("#lbl_yslx").text("正确");
                $("#lbl_yslx").css("color", "#00ff00");
            }
            else {
                $("#lbl_yslx").text("请选择");
                $("#lbl_yslx").css("color", "#ff0000");
            }
        });
        //项目名称
        $("#tbx_xmmc").blur(function () {
            if ($("#tbx_xmmc").val().trim() == "") {
                $("#lbl_xmmc").text("内容不能为空");
                $("#lbl_xmmc").css("color", "#ff0000");
            }
            else {
                $("#lbl_xmmc").text("正确");
                $("#lbl_xmmc").css("color", "#00ff00");
            }
        });
        //维护单位
        $("#tbx_whdw").blur(function () {
            if ($("#tbx_whdw").val().trim() == "") {
                $("#lbl_whdw").text("内容不能为空");
                $("#lbl_whdw").css("color", "#ff0000");
            }
            else {
                $("#lbl_whdw").text("正确");
                $("#lbl_whdw").css("color", "#00ff00");
            }
        });
        //实际执行金额
        $("#tbx_sjzxje").blur(function () {
            if ($("#tbx_sjzxje").val().trim() == "") {
                $("#lbl_sjzxje").text("内容不能为空");
                $("#lbl_sjzxje").css("color", "#ff0000");
            }
            else {
                var ys = /^[0-9]+(\.[0-9]{0,2})?$/
                if (!ys.test($("#tbx_sjzxje").val())) {
                    $("#lbl_sjzxje").text("请输入整数或小数");
                    $("#lbl_sjzxje").css("color", "#ff0000");
                }
                else {
                    $("#lbl_sjzxje").text("正确");
                    $("#lbl_sjzxje").css("color", "#00ff00");
                }


            }
        });
        //申报年份
        $("#tbx_sbnf").blur(function () {
            //if ($("#tbx_sbnf").val().trim() == "") {
            //    $("#lbl_sbnf").text("内容不能为空");
            //    $("#lbl_sbnf").css("color", "#ff0000");
            //}
            //else {
                var ys = /^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$/;
                if (!ys.test($("#tbx_sbnf").val())) {
                    $("#lbl_sbnf").text("请输入正确格式如（1996-01-02）");
                    $("#lbl_sbnf").css("color", "#ff0000");
                }
                else {
                    $("#lbl_sbnf").text("正确");
                    $("#lbl_sbnf").css("color", "#00ff00");
                }
            //}
        });
        //预算增项、调整原因
        $("#tbx_yszxtzyy").blur(function () {
            if ($("#tbx_yszxtzyy").val().trim() == "") {
                $("#lbl_yszxtzyy").text("内容不能为空");
                $("#lbl_yszxtzyy").css("color", "#ff0000");
            }
            else {
                $("#lbl_yszxtzyy").text("正确");
                $("#lbl_yszxtzyy").css("color", "#00ff00");
            }
        });
        //完成时间
        $("#tbx_wcsj").blur(function () {
            if ($("#tbx_wcsj").val() == "") {
                $("#lbl_wcsj").text("内容不能为空");
                $("#lbl_wcsj").css("color", "#ff0000");
            }
            else {
                if ($("#tbx_wcsj").val() == "") {
                    $("#lbl_wcsj").text("维修日期不能为空");
                    $("#lbl_wcsj").css("color", "#ff0000")
                }
                else {
                    var djrq = $("#tbx_wcsj").val().trim();
                    var wxrq = $("#tbx_wcsj").val().trim();


                    if (new Date(wxrq.replace(/\-/g, '\/')) > new Date(djrq.replace(/\-/g, '\/'))) {
                        $("#lbl_wcsj").text("日期小于维修日期");
                        $("#lbl_wcsj").css("color", "#ff0000")
                    }
                    else {
                        $("#lbl_wcsj").text("正确");
                        $("#lbl_wcsj").css("color", "#00ff00");
                    }

                }
            }
        });
        //备注
        $("#tbx_bz").blur(function () {
                $("#lbl_bz").text("正确");
                $("#lbl_bz").css("color", "#00ff00");
            
        });

    });
</script>
</html>
