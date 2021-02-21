<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WXFY_Edit.aspx.cs" Inherits="CUST.WKG.WXFY_Edit" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>维修费用</title>
      <script src="../../Content/js/jquery.js"></script>
     <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />   
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
   
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
     <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
     <article class="page-container">
    <form id="form1" runat="server">
        <div  style="padding:1%">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
        <table  style="border-top:2px solid #C0D9D9;border-bottom:2px solid #C0D9D9;">
        <tr style="vertical-align: top;  width:100%;border:1px solid #C0D9D9;">
           <td style="width:20%; text-align:right; vertical-align: middle; height: 30px;" class="td_sjsc">
               登记单位：
            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc" >
                   <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                  <ContentTemplate>
                        <asp:DropDownList ID="ddlt_djdw" width="50%" runat="server"></asp:DropDownList>
                        <asp:Label ID="lbl_djdw"  runat="server"></asp:Label>       
                          </ContentTemplate>
               </asp:UpdatePanel>                      
            </td>
        </tr>


        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 6%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                 预算批复：   <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_yspf"  runat="server" Width="60%" Height="25px"></asp:TextBox>万
                        <asp:Label ID="lbl_yspf" runat="server"></asp:Label>
            </td>
        </tr> 


        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">
                维修类别：  <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:DropDownList ID="ddlt_wxlb" width="30%" runat="server"></asp:DropDownList>
                <asp:Label ID="lbl_wxlb" runat="server"></asp:Label>
            </td>
        </tr> 
                      
        <tr style="vertical-align: top;  width:100%;border:1px solid #C0D9D9;" >           
            <td style="width: 6%; text-align: right; vertical-align: middle;" class="td_sjsc">
                供应商/维修单位：  <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
               <asp:TextBox ID="tbx_gys_wxdw" runat="server" Width="60%" Height="25px" ></asp:TextBox>
                <asp:Label ID="lbl_gys_wxdw" runat="server"></asp:Label>
            </td>
        </tr> 

        <tr style="vertical-align: top;  width:100%;border:1px solid #C0D9D9;" >           
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">
                设备类别 <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:DropDownList ID="ddlt_sblb_sbzl" width="30%" runat="server" OnSelectedIndexChanged="ddlt_sbzl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:DropDownList ID="ddlt_sblb_sbwz" width="30%" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="ddlt_sblb_sblx" width="30%" runat="server"></asp:DropDownList>               

                <asp:Label ID="lbl_sblb" runat="server"></asp:Label>
            </td>
        </tr> 

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">
                存放地点：<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:DropDownList ID="ddlt_cfdd" width="30%" runat="server"></asp:DropDownList>
                <asp:TextBox ID="tbx_cfdd_qt"  runat="server" Width="50%" Height="25px" placeholder=" 存放地点"></asp:TextBox>
                <asp:Label ID="lbl_cfdd" runat="server"></asp:Label>
            </td>
        </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
              <td style="width: 6%; text-align: right; vertical-align: middle;" class="td_sjsc">
                维修日期：      <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_qswxrq" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox></td>
             <asp:Label ID="lbl_pjfyhs" runat="server"></asp:Label>
        </tr>
      
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">
                维修预算：<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:TextBox ID="tbx_wxys"  runat="server" Width="50%" Height="25px" ></asp:TextBox>万
                <asp:Label ID="lbl_wxys" runat="server"></asp:Label>
            </td>
        </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
            <td style="width: 6%; text-align: right; vertical-align: middle;" class="td_sjsc">
                板件名称：  <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
               <asp:TextBox ID="tbx_bjmc" runat="server" Width="60%" Height="25px"></asp:TextBox>
                <asp:Label ID="lbl_bjmc" runat="server"></asp:Label>
            </td>
        </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      请示：<span class="c-red">*</span></td>                    
                <td colspan="2" style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">                   
                    <asp:FileUpload ID="FileUpload_qs" runat="server" />
                    <asp:Label ID="lbl_qs" runat="server" ></asp:Label>
                </td>              
        </tr>
          
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      故障报告：<span class="c-red">*</span></td>
                <td colspan="2" style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <asp:FileUpload ID="FileUpload_gzbg" runat="server" />
                    <asp:Label ID="lbl_gzbg" runat="server" ></asp:Label>
                </td>              
        </tr>    
            
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      其他附件：<span class="c-red">*</span></td>
                <td colspan="2" style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <asp:FileUpload ID="FileUpload_qtfj" runat="server" />

                    <asp:Label ID="lbl_qtfj" runat="server" ></asp:Label>
                </td>              
        </tr>    

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
            <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">
                预算执行机场：<asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:DropDownList ID="ddlt_yszxjc" width="30%" runat="server"></asp:DropDownList>
                <asp:Label ID="lbl_yszxjc" runat="server"></asp:Label>
            </td>
        </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
              <td style="width: 6%; text-align: right; vertical-align: middle;" class="td_sjsc">
                年度：      <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 62%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:TextBox ID="tbx_nd" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="年度" onclick="lhgcalendar({format:'yyyy'})"></asp:TextBox>
           
                <asp:Label ID="lbl_nd" runat="server"></asp:Label>
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
            //登记单位
            $("#tbx_djdw").blur(function ()
            {
                if ($("#tbx_djdw").val().trim() == "")
                {
                    $("#lbl_djdw").text("内容不能为空");
                    $("#lbl_djdw").css("color", "#ff0000");
                }
                else
                {
                    $("#lbl_djdw").text("正确");
                    $("#lbl_djdw").css("color", "#00ff00");
                }
            });
            //预算费用
            $("#tbx_ysfy").blur(function ()
            {
                if ($("#tbx_ysfy").val().trim() == "")
                {
                    $("#lbl_ysfy").text("内容不能为空");
                    $("#lbl_ysfy").css("color", "#ff0000");
                }
                else
                {
                    var ys =/^[0-9]+(\.[0-9]{0,2})?$/
                    if (!ys.test($("#tbx_ysfy").val()))
                    {
                        $("#lbl_ysfy").text("请输入整数或小数");
                        $("#lbl_ysfy").css("color", "#ff0000");
                    }
                    else
                    {
                        $("#lbl_ysfy").text("正确");
                        $("#lbl_ysfy").css("color", "#00ff00");
                    }
                }
            });
            //维修类型
            $("#ddlt_wxlb").blur(function ()
            {
                if ($("#ddlt_wxlb option:selected").val() != "-1") {
                    $("#lbl_wxlb").text("正确");
                    $("#lbl_wxlb").css("color", "#00ff00");
                }
                else
                {
                    $("#lbl_wxlx").text("请选择");
                    $("#lbl_wxlx").css("color", "#ff0000");
                }
            });
            //设备名称
            $("#tbx_sbmc").blur(function ()
            {
                if ($("#tbx_sbmc").val().trim() == "") {
                    $("#lbl_sbmc").text("内容不能为空");
                    $("#lbl_sbmc").css("color", "#ff0000");
                }
                else {
                    $("#lbl_sbmc").text("正确");
                    $("#lbl_sbmc").css("color", "#00ff00");
                }
            });
            //存放地点
            $("#tbx_cfdd").blur(function () {
                if ($("#tbx_cfdd").val().trim() == "") {
                    $("#lbl_cfdd").text("内容不能为空");
                    $("#lbl_cfdd").css("color", "#ff0000");
                }
                else {
                    $("#lbl_cfdd").text("正确");
                    $("#lbl_cfdd").css("color", "#00ff00");
                }
            });
            //维修单位
            $("#tbx_wxdw").blur(function () {
                if ($("#tbx_wxdw").val().trim() == "") {
                    $("#lbl_wxdw").text("内容不能为空");
                    $("#lbl_wxdw").css("color", "#ff0000");
                }
                else {
                    $("#lbl_wxdw").text("正确");
                    $("#lbl_wxdw").css("color", "#00ff00");
                }
            });
            //维修日期
            $("#tbx_wxrq").blur(function ()
            {
                if ($("#tbx_wxrq").val().trim() == "") {
                    $("#lbl_wxrq").text("内容不能为空");
                    $("#lbl_wxrq").css("color", "#ff0000");
                }
                else {
                    var ys = /^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$/;
                    if (!ys.test($("#tbx_wxrq").val())) {
                        $("#lbl_wxrq").text("请输入正确格式如（1996-01-02）");
                        $("#lbl_wxrq").css("color", "#ff0000");
                    }
                    else {
                        $("#lbl_wxrq").text("正确");
                        $("#lbl_wxrq").css("color", "#00ff00");
                    }
                 }
            });
            //人工费用
            $("#tbx_rgfy").blur(function () {
                if ($("#tbx_rgfy").val().trim() == "") {
                    $("#lbl_rgfy").text("内容不能为空");
                    $("#lbl_rgfy").css("color", "#ff0000");
                }
                else {
                    var ys = /^[0-9]+(\.[0-9]{0,2})?$/
                    if (!ys.test($("#tbx_rgfy").val())) {
                        $("#lbl_rgfy").text("请输入整数或小数");
                        $("#lbl_rgfy").css("color", "#ff0000");
                    }
                    else {
                        $("#lbl_rgfy").text("正确");
                        $("#lbl_rgfy").css("color", "#00ff00");
                    }
                 }
            });
            //配件名称
            $("#tbx_pjmc").blur(function () {
                if ($("#tbx_pjmc").val().trim() == "") {
                    $("#lbl_pjmc").text("内容不能为空");
                    $("#lbl_pjmc").css("color", "#ff0000");
                }
                else {
                    $("#lbl_pjmc").text("正确");
                    $("#lbl_pjmc").css("color", "#00ff00");
                }
            });
            //数量
            $("#tbx_sl").blur(function () {
                if ($("#tbx_sl").val().trim() == "") {
                    $("#lbl_sl").text("内容不能为空");
                    $("#lbl_sl").css("color", "#ff0000");
                }
                else {
                    var ys = /^-?[0-9]\d*$/
                    if (!ys.test($("#tbx_sl").val())) {
                        $("#lbl_sl").text("请输入整数");
                        $("#lbl_sl").css("color", "#ff0000");
                    }
                    else {
                        $("#lbl_sl").text("正确");
                        $("#lbl_sl").css("color", "#00ff00");
                    }
                }
            });
            //配件费用不含税
            $("#tbx_pjfybhs").blur(function () {
                if ($("#tbx_pjfybhs").val().trim() == "") {
                    $("#lbl_pjfybhs").text("内容不能为空");
                    $("#lbl_pjfybhs").css("color", "#ff0000");
                }
                else {
                    var ys = /^[0-9]+(\.[0-9]{0,2})?$/
                    if (!ys.test($("#tbx_pjfybhs").val())) {
                        $("#lbl_pjfybhs").text("请输入整数或小数");
                        $("#lbl_pjfybhs").css("color", "#ff0000");
                    }
                    else {
                        $("#lbl_pjfybhs").text("正确");
                        $("#lbl_pjfybhs").css("color", "#00ff00");
                    }
                }
            });
            //配件费不含税
            $("#tbx_pjfyhs").blur(function () {
                if ($("#tbx_pjfyhs").val().trim() == "") {
                    $("#lbl_pjfyhs").text("内容不能为空");
                    $("#lbl_pjfyhs").css("color", "#ff0000");
                }
                else {
                    var ys = /^[0-9]+(\.[0-9]{0,2})?$/
                    if (!ys.test($("#tbx_pjfyhs").val())) {
                        $("#lbl_pjfyhs").text("请输入整数或小数");
                        $("#lbl_pjfyhs").css("color", "#ff0000");
                    }
                    else {
                        $("#lbl_pjfyhs").text("正确");
                        $("#lbl_pjfyhs").css("color", "#00ff00");
                    }
                }
            });
            //总计
            $("#tbx_zj").blur(function () {
                if ($("#tbx_zj").val().trim() == "") {
                    $("#lbl_zj").text("内容不能为空");
                    $("#lbl_zj").css("color", "#ff0000");
                }
                else {
                  
                    var ys = /^[0-9]+(\.[0-9]{0,2})?$/
                    if (!ys.test($("#tbx_zj").val())) {
                        $("#lbl_zj").text("请输入整数或小数");
                        $("#lbl_zj").css("color", "#ff0000");
                    }
                    else {
                        if ($("#tbx_ysfy").val().trim() == "")
                        {
                            $("#lbl_zj").text("预算费用不能为空");
                            $("#lbl_zj").css("color", "#ff0000");
                        }
                        else
                        {
                            $("#lbl_zj").text("正确");
                            $("#lbl_zj").css("color", "#00ff00");
                            var sum = parseFloat($("#tbx_ysfy").val()) - parseFloat($("#tbx_zj").val());
                            $("#lbl_wxfye").text(sum);
                        }
                         }
                }
            });
            //登记日期
            $("#tbx_djrq").blur(function ()
                {
                if ($("#tbx_djrq").val() == "") {
                    $("#lbl_djrq").text("内容不能为空");
                    $("#lbl_djrq").css("color", "#ff0000");
                }
                else {
                    if ($("#tbx_qswxrq").val() == "")
                    {
                        $("#lbl_qswxrq").text("维修日期不能为空");
                        $("#lbl_qswxrq").css("color", "#ff0000")
                    }
                    else
                    {
                        var djrq = $("#tbx_qswxrq").val().trim();
                        var wxrq = $("#tbx_qswxrq").val().trim();
                      
                     
                       if (new Date(wxrq.replace(/\-/g, '\/')) > new Date(djrq.replace(/\-/g, '\/')))
                       {
                            $("#lbl_djrq").text("日期小于维修日期");
                            $("#lbl_djrq").css("color", "#ff0000")
                       }
                        else
                        {
                            $("#lbl_djrq").text("正确");
                            $("#lbl_djrq").css("color", "#00ff00");
                        }

                    }
                }
            });

        } );
        </script>
</html>
