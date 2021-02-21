<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SBGZ_Edit.aspx.cs" Inherits="CUST.WKG.SBGZ_Edit" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"=></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />

    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>
</head>
<body>
    <article class="page-container">
        <form id="Form1" runat="server" class="form form-horizontal">
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
              <table>
       <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               设备编号：  <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                <%--<asp:TextBox ID="tbx_sbbh" MaxLength="14" runat="server"  Height="26px" placeholder="设备编号"></asp:TextBox>--%>
                <asp:Label ID="tbx_sbbh" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lbl_sbbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                设备类型： <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       
                <asp:Label ID="lbl_sblx" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               故障起始时间：  <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                  <asp:TextBox ID="tbx_gzqssj" runat="server" Height="25px" placeholder="故障起始时间"  class="Wdate"   Width="60%"   onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                <asp:Label ID="lbl_gzqssj" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
              故障结束时间： <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                 <asp:TextBox ID="tbx_gzjssj" runat="server" Height="25px" placeholder="故障结束时间"  class="Wdate"   Width="60%"   onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
                <asp:Label ID="lbl_gzjssj" runat="server"></asp:Label>
            </td>
        </tr>
        
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              累计时长：  <asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
            <asp:TextBox ID="tbx_ljsc"  runat="server" Width="60%" Height="25px" placeholder="累计时长"></asp:TextBox>
                <asp:Label ID="lbl_ljsc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
              维修人： <asp:Label ID="Label22" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
             
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                 <asp:TextBox ID="tbx_wxr"  runat="server" Width="60%" Height="25px" placeholder="维修人"></asp:TextBox>
                <asp:Label ID="lbl_wxr" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
         <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             维修人部门：  <asp:Label ID="Label26" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                         <ContentTemplate>
                   <asp:DropDownList ID="ddlt_wxrbm" runat="server"   Height="25px" OnSelectedIndexChanged="ddlt_whrbm_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                             </ContentTemplate>
                         </asp:UpdatePanel>
                                <asp:Label ID="lbl_wxrbm" runat="server"></asp:Label>
            </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             维修人岗位：  <asp:Label ID="Label27" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                    <asp:DropDownList ID="ddlt_wxrgw" runat="server" Height="25px" ></asp:DropDownList>
                             </ContentTemplate>
                         </asp:UpdatePanel>
                         <asp:Label ID="lbl_wxrgw" runat="server"></asp:Label>
            </td>
    </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
         <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             故障现象：  <asp:Label ID="Label28" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
               <asp:TextBox ID="tbx_gzxx" runat="server" Width="60%" Height="40px" TextMode="MultiLine" style="resize:none;"  placeholder="故障现象"></asp:TextBox>
                         <asp:Label ID="lbl_gzxx" runat="server"></asp:Label>
            </td>
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             造成影响：  <asp:Label ID="Label29" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                   <asp:TextBox ID="tbx_zcyx"  runat="server" Width="60%" Height="40px" TextMode="MultiLine" style="resize:none;" placeholder="造成影响"></asp:TextBox>
                         <asp:Label ID="lbl_zcyx" runat="server"></asp:Label>
            </td>
    </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             处置过程：  <asp:Label ID="Label30" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
               <asp:TextBox ID="tbx_czgc"  runat="server" Width="60%" Height="40px" TextMode="MultiLine" style="resize:none;" placeholder="处置过程"></asp:TextBox>
                         <asp:Label ID="lbl_czgc" runat="server"></asp:Label>
            </td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  故障原因分析：  <asp:Label ID="Label31" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
               <asp:TextBox ID="tbx_gzyyfx"  runat="server" Width="60%" Height="40px" TextMode="MultiLine" style="resize:none;" placeholder="故障原因分析"></asp:TextBox>
                         <asp:Label ID="lbl_gzyyfx" runat="server"></asp:Label>
            </td>
             </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             故障板件处理结果：  <asp:Label ID="Label32" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                      <asp:TextBox ID="tbx_gzbjcljg"  runat="server" Width="60%" Height="40px" TextMode="MultiLine" style="resize:none;" placeholder="故障板件处理结果"></asp:TextBox>
                         <asp:Label ID="lbl_gzbjcljg" runat="server"></asp:Label>
            </td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  同类故障排除方法： <asp:Label ID="Label33" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
               <asp:TextBox ID="tbx_tlgzdpcff"  runat="server" Width="60%" Height="40px" TextMode="MultiLine" style="resize:none;" placeholder="同类故障的排除方法"></asp:TextBox>
                         <asp:Label ID="lbl_tlgzdpcff" runat="server"></asp:Label>
            </td>

             </tr>
                      <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             处理步骤：  <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                     <asp:TextBox ID="tbx_clbz"  runat="server" Width="60%" Height="40px"  TextMode="MultiLine" style="resize:none;" placeholder="处理步骤"></asp:TextBox>
                         <asp:Label ID="lbl_clbz" runat="server"></asp:Label>
            </td>

              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  建议措施： <asp:Label ID="Label4" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
             <asp:TextBox ID="tbx_jycs"  runat="server" Width="60%" Height="40px" TextMode="MultiLine" style="resize:none;" placeholder="建议措施"></asp:TextBox>
                         <asp:Label ID="lbl_jycs" runat="server"></asp:Label>
            </td>
             </tr>
                               <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             备注：  <asp:Label ID="Label3" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
                   <asp:TextBox ID="tbx_bz"  runat="server" Width="60%" Height="40px" TextMode="MultiLine" style="resize:none;" placeholder="备注"></asp:TextBox>
                         <asp:Label ID="lbl_bz" runat="server"></asp:Label>
            </td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                  维修文件上传： <asp:Label ID="Label6" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
            <%--<asp:TextBox ID="tbx_whwjsc"  runat="server" Width="60%" Height="25px" placeholder="维修文件上传"></asp:TextBox>--%>
                <Upload:InputFile ID="tbx_whwjsc" runat="server" />
                         <asp:Label ID="lbl_whwjsc" runat="server"></asp:Label>
            </td>

             </tr>
                   <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                设备种类： <asp:Label ID="lbl1" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       
            <asp:DropDownList ID="ddlt_sbzl" runat="server" Height="26px"></asp:DropDownList>
                <asp:Label ID="lbl_sbzl" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                数据所属部门： <asp:Label ID="lbl2" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       
            <asp:DropDownList ID="ddlt_sjszbm" runat="server" Height="26px"></asp:DropDownList>
                <asp:Label ID="lbl_sjszbm" runat="server"></asp:Label>
            </td>
        </tr>
                  <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                初审人： <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       
            <asp:DropDownList ID="ddlt_csr" runat="server" Height="26px"></asp:DropDownList>
                <asp:Label ID="lbl_csr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
                终审人： <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
       
            <asp:DropDownList ID="ddlt_zsr" runat="server" Height="26px"></asp:DropDownList>
                <asp:Label ID="lbl_zsr" runat="server"></asp:Label>
            </td>
        </tr>


    </table>
            <br />
            <div class="row cl" style="text-align: center; width: 80%; margin: 0 auto;">
                <table>
                    <tr>
                        <%-- <td style="text-align: right">
                            <asp:Button ID="btn_edit" runat="server"
                                Text="编辑" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_edit_Click"></asp:Button></td>
                        <td>&nbsp;</td>--%>
                        <td style="text-align: right">
                            <asp:Button ID="btn_save" runat="server"
                                Text="保存" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_save_Click"></asp:Button></td>
                        <td>&nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="Button2" runat="server"
                                Text="返回" class="btn  radius" BackColor="#60B1D7" ForeColor="White"
                                Width="199px" OnClick="btn_back_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" ClientIDMode="AutoID" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    文件列表
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    文件名
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    上传时间
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                   操作
                                </th>
                               
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                             <td>
                                <asp:Label ID="Label44"  runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label26"  runat="server" Text='<%#Eval("scsj") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                                <asp:LinkButton ID="lbtDown" CommandName="down" CommandArgument='<%#Eval("path") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" >下载</asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <script src="../../js/jquery-1.8.3.min.js"></script>

            <script type="text/javascript">
                $(document).ready(function () {

                    //设备类型
                    $("#ddlt_sblx").change(function () {
                        if ($("#ddlt_sblx option:selected").val() != "-1") {
                            $("#lbl_sblx").text("正确");
                            $("#lbl_sblx").css("color", "#00ff00");
                        } else {
                            $("#lbl_sblx").text("请选择");
                            $("#lbl_sblx").css("color", "#ff0000");
                        }
                    });
                  
                    //维护人部门
                    //$("#ddlt_whrbm").change(function () {
                    //    if ($("#ddlt_whrbm option:selected").val() != "-1") {
                    //        $("#lbl_whrbm").text("正确");
                    //        $("#lbl_whrbm").css("color", "#00ff00");
                    //    } else {
                    //        $("#lbl_whrbm").text("请选择");
                    //        $("#lbl_whrbm").css("color", "#ff0000");
                    //    }
                    //});
                    //维护人岗位
                    //$("#ddlt_whrgw").change(function () {
                    //    if ($("#ddlt_whrgw option:selected").val() != "-1") {
                    //        $("#lbl_whrgm").text("正确");
                    //        $("#lbl_whrgm").css("color", "#00ff00");
                    //    } else {
                    //        $("#lbl_whrgm").text("请选择");
                    //        $("#lbl_whrgm").css("color", "#ff0000");
                    //    }
                    //});
                 

                    //设备编号
                    $("#tbx_sbbh").blur(function () {
                        if ($("#tbx_sbbh").val().trim() != "") {
                            $("#lbl_sbbh").text("正确");
                            $("#lbl_sbbh").css("color", "#00ff00");

                        } else {
                            $("#lbl_sbbh").text("错误");
                            $("#lbl_sbbh").css("color", "#ff0000");
                        }
                    });

                    //故障起始时间
                    $("#tbx_gzqssj").blur(function () {
                        if ($("#tbx_gzqssj").val().trim() != "") {
                            $("#lbl_gzqssj").text("正确");
                            $("#lbl_gzqssj").css("color", "#00ff00");

                        } else {
                            $("#lbl_gzqssj").text("错误");
                            $("#lbl_gzqssj").css("color", "#ff0000");
                        }
                    });
                    //故障结束时间
                    $("#tbx_gzjssj").blur(function () {
                        if ($("#tbx_gzjssj").val().trim() != "") {
                            $("#lbl_gzjssj").text("正确");
                            $("#lbl_gzjssj").css("color", "#00ff00");

                        } else {
                            $("#lbl_gzjssj").text("错误");
                            $("#lbl_gzjssj").css("color", "#ff0000");
                        }
                    });

                    //累计时长
                    $("#tbx_ljsc").blur(function () {
                        if ($("#tbx_ljsc").val().trim() != "") {
                            $("#lbl_ljsc").text("正确");
                            $("#lbl_ljsc").css("color", "#00ff00");
                        }
                        else {
                            $("#lbl_ljsc").text("错误");
                            $("#lbl_ljsc").css("color", "#ff0000");
                        }

                    });
                    //维修人
                    $("#tbx_wxr").blur(function () {
                        if ($("#tbx_wxr").val().trim() != "") {
                            $("#lbl_wxr").text("正确");
                            $("#lbl_wxr").css("color", "#00ff00");
                        }
                        else {
                            $("#lbl_wxr").text("错误");
                            $("#lbl_wxr").css("color", "#ff0000");
                        }
                    });
                });

            </script>
        </form>
        </article>
</body>
</html>
