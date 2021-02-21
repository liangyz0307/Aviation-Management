<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SBWH_Edit.aspx.cs" Inherits="CUST.WKG.SBWH_Edit" %>

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
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">设备编号： 
                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                          <asp:Label ID="lbl_bh" runat="server" Text="Label"  Width="60%" ></asp:Label>
                    </td>
                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">设备类型： 
                        <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">

                         <asp:Label ID="lbl_sblx" runat="server"></asp:Label>
                    </td>

                </tr>
                   <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">设备状态详细信息： 
                        <asp:Label ID="Label24" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                      <asp:TextBox ID="tbx_sbztxxxx" MaxLength="14" runat="server" Width="60%" Height="25px" placeholder="设备状态详细信息"></asp:TextBox>
                         <asp:Label ID="lbl_sbztxxxx" runat="server"></asp:Label>
                    </td>

                </tr>

                  <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护状态： 
                        <asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:DropDownList ID="ddlt_whzt" runat="server"   Height="25px" ></asp:DropDownList>
                         <asp:Label ID="lbl_whzt" runat="server"></asp:Label>
                    </td>

                </tr>
                  <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护时间： 
                        <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                         <asp:TextBox ID="tbx_whsj" runat="server" Height="25px" placeholder="维护时间"  class="Wdate"     onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>

                          <asp:Label ID="lbl_whsj" runat="server"></asp:Label>
                    </td>

                </tr>
             
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护人部门： 
                        <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>&nbsp;
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                        <asp:DropDownList ID="ddlt_whrbm" runat="server"   Height="25px" OnSelectedIndexChanged="ddlt_whrbm_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                               <asp:Label ID="lbl_whrbm" runat="server"></asp:Label>
                              </ContentTemplate>
                         </asp:UpdatePanel>
                             
                    </td>
                </tr>
                <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护人岗位： 
                        <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>&nbsp;
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
                        <asp:DropDownList ID="ddlt_whrgw" runat="server"   Height="25px" OnSelectedIndexChanged="ddlt_whrgw_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                               <asp:Label ID="lbl_whrgw" runat="server"></asp:Label>
                              </ContentTemplate>
                         </asp:UpdatePanel>
                    </td>
                </tr>
                
                   <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护人： 
                        <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                  <ContentTemplate> 
                      <asp:DropDownList ID="ddlt_whr" runat="server" Height="25px" AutoPostBack="True" ></asp:DropDownList>
                          <asp:Label ID="lbl_whr" runat="server"></asp:Label>
                  </ContentTemplate>
               </asp:UpdatePanel>
                    
                    </td>
                </tr>
              
                    <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护记录： 
                        <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                          <asp:TextBox ID="tbx_whjl" runat="server" Width="60%" Height="50px" TextMode="MultiLine" style="resize:none"  placeholder="维护记录"></asp:TextBox>
                         <asp:Label ID="lbl_whjl" runat="server"></asp:Label>
                    </td>

                </tr>

                

                  <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">场地环境和电磁环境巡视记录： 
                        <asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                          <asp:TextBox ID="tbx_xsjl" runat="server" Width="60%" Height="50px" TextMode="MultiLine" style="resize:none" placeholder="场地环境和电磁环境巡视记录"></asp:TextBox>
                         <asp:Label ID="lbl_xsjl" runat="server"></asp:Label>
                    </td>

                </tr>


                  <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">备注： 
                        <asp:Label ID="Label20" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                          <asp:TextBox ID="tbx_bz" runat="server" Width="60%" Height="50px" TextMode="MultiLine" style="resize:none" placeholder="备注"></asp:TextBox>
                         <asp:Label ID="lbl_bz" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr style="vertical-align: top; width: 100%; height: 30px; border: 1px solid #C0D9D9;">
                    <td style="width: 30%; text-align: right; vertical-align: middle;" class="td_sjsc">维护文件上传： 
                        <asp:Label ID="Label22" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: middle;" class="td_sjsc">
                            <Upload:InputFile ID="Upath" runat="server"  Height="26px" placeholder="维护文件上传"/>
                        <asp:Label ID="lbl_path" runat="server"></asp:Label>
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
                          </tr>
                <tr>
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
                           </tr>
                <tr>
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
                           <%--<td style="text-align: right">
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
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
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
                            $("#lbl_sblx").text("请选择设备类型");
                            $("#lbl_sblx").css("color", "#ff0000");
                        }
                    });
                    //维护状态
                    $("#ddlt_whzt").change(function () {
                        if ($("#ddlt_whzt option:selected").val() != "-1") {
                            $("#lbl_whzt").text("正确");
                            $("#lbl_whzt").css("color", "#00ff00");
                        } else {
                            $("#lbl_whzt").text("请选择维护状态");
                            $("#lbl_whzt").css("color", "#ff0000");
                        }
                    });
                    //维护人部门
                    //$("#ddlt_whrbm").change(function () {
                    //    if ($("#ddlt_whrbm option:selected").val() != "-1") {
                    //        $("#lbl_whrbm").text("正确");
                    //        $("#lbl_whrbm").css("color", "#00ff00");
                    //    } else {
                    //        $("#lbl_whrbm").text("请选择维护人部门");
                    //        $("#lbl_whrbm").css("color", "#ff0000");
                    //    }
                    //});
                   // 维护人岗位
                    //$("#ddlt_whrgw").change(function () {
                    //    if ($("#ddlt_whrgw option:selected").val() != "-1") {
                    //        $("#lbl_whrgw").text("正确");
                    //        $("#lbl_whrgw").css("color", "#00ff00");
                    //    } else {
                    //        $("#lbl_whrgw").text("请选择维护人岗位");
                    //        $("#lbl_whrgw").css("color", "#ff0000");
                    //    }
                    //});
                    //维护人
                    //$("#ddlt_whr").change(function () {
                    //    if ($("#ddlt_whr option:selected").val() != "-1") {
                    //        $("#lbl_whr").text("正确");
                    //        $("#lbl_whr").css("color", "#00ff00");
                    //    } else {
                    //        $("#lbl_whr").text("请选择维护人");
                    //        $("#lbl_whr").css("color", "#ff0000");
                    //    }
                    //});
                    //设备状态详细信息
                    $("#tbx_sbztxxxx").blur(function () {
                        if ($("#tbx_sbztxxxx").val().trim() != "") {
                            $("#lbl_sbztxxxx").text("正确");
                            $("#lbl_sbztxxxx").css("color", "#00ff00");

                        } else {
                            $("#lbl_sbztxxxx").text("错误：设备状态详细信息不能为空");
                            $("#lbl_sbztxxxx").css("color", "#ff0000");
                        }
                    });
                    //场地环境和电磁环境巡视记录
                    $("#tbx_xsjl").blur(function () {
                        if ($("#tbx_xsjl").val().trim() != "") {
                            $("#lbl_xsjl").text("正确");
                            $("#lbl_xsjl").css("color", "#00ff00");

                        } else {
                            $("#lbl_xsjl").text("错误：场地环境和电磁环境巡视记录不能为空");
                            $("#lbl_xsjl").css("color", "#ff0000");
                        }
                    });

                    //维护时间
                    //$("#tbx_whsj").blur(function () {
                    //    if ($("#tbx_whsj").val().trim() != "") {
                    //        $("#lbl_whsj").text("正确");
                    //        $("#lbl_whsj").css("color", "#00ff00");
                    //    }
                    //    else {
                    //        $("#lbl_whsj").text("错误");
                    //        $("#lbl_whsj").css("color", "#ff0000");
                    //    }

                    //});
                    //维护记录
                    $("#tbx_whjl").blur(function () {
                        if ($("#tbx_whjl").val().trim() != "") {
                            $("#lbl_whjl").text("正确");
                            $("#lbl_whjl").css("color", "#00ff00");
                        }
                        else {
                            $("#lbl_whjl").text("错误：维护记录不能为空");
                            $("#lbl_whjl").css("color", "#ff0000");
                        }
                    });
                 });

            </script>
        </form>
        </article>
</body>
</html>
