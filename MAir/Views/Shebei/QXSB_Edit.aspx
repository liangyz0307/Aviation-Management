<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QXSB_Edit.aspx.cs" Inherits="CUST.WKG.QXSB_Edit" %>

<%@ Register assembly="Brettle.Web.NeatUpload" namespace="Brettle.Web.NeatUpload" tagprefix="Upload" %>
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
            td.td_sjsc
            {
                background:#F6FAFD;
              
            }
          .auto-style1 {
              width: 20%;
              height: 30px;
          }
    </style>
</head>
<body>
  <article class="page-container">
<form id="Form1" runat="server" class="form form-horizontal">
     <asp:HiddenField  ID="hf_temp" runat="server"/>

    <table>

                    <tr style="vertical-align: top;  width:100%;height:30px;  border-bottom:1px solid #C0D9D9; " >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              台站名称种类 ： <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                 <asp:DropDownList ID="ddlt_tzmczl" runat="server" Width="230px"   Height="26px"   OnSelectedIndexChanged="ddlt_sblx_change" AutoPostBack="true" ></asp:DropDownList>
                <asp:Label ID="lbl_tzmczl" runat="server"></asp:Label>
            </td>
             </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             设备名称：<asp:Label ID="Label1" runat="server"></asp:Label></td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
            <asp:TextBox ID="tbx_sbmc" runat="server" MaxLength="3"  Height="26px" placeholder="设备名称"></asp:TextBox>
            <asp:Label ID="lbl_sbmc" runat="server"></asp:Label></td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             型号/规格：<asp:Label ID="Label2" runat="server"></asp:Label></td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
            <asp:TextBox ID="tbx_xh" runat="server" MaxLength="3"  Height="26px" placeholder="型号/规格"></asp:TextBox>
            <asp:Label ID="lbl_xh" runat="server"></asp:Label></td>
         </tr>

         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             制造厂家：<asp:Label ID="Label3" runat="server"></asp:Label></td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
            <asp:TextBox ID="tbx_zzcj" runat="server" MaxLength="3"  Height="26px" placeholder="制造厂家"></asp:TextBox>
            <asp:Label ID="lbl_zzcj" runat="server"></asp:Label></td>
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             出厂编号：  <asp:Label ID="Label4" runat="server"></asp:Label></td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
            <asp:TextBox ID="tbx_ccbh" runat="server" MaxLength="3"  Height="26px" placeholder="出厂编号"></asp:TextBox>
            <asp:Label ID="lbl_ccbh" runat="server"></asp:Label></td> 
          </tr>      

          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              投产日期：<asp:Label ID="Label5" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_tcrq" runat="server" Height="26px" placeholder="投产日期"  class="Wdate"   onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
             <asp:Label ID="lbl_tcrq" runat="server"></asp:Label></td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             竣工日期：<asp:Label ID="Label6" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_jgrq" runat="server" Height="26px" placeholder="竣工日期"  class="Wdate"   onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
             <asp:Label ID="lbl_jgrq" runat="server"></asp:Label></td>
           </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              启用时间：<asp:Label ID="Label7" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_qysj" runat="server" Height="26px" placeholder="启用时间"  class="Wdate"   onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
             <asp:Label ID="lbl_qysj" runat="server"></asp:Label></td>
             <td style="width:20%; text-align: right; vertical-align: middle; height: 13px;" class="td_sjsc">
              运行情况：<asp:Label ID="Label8" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle; height: 13px;" class="td_sjsc">
             <asp:DropDownList ID="ddlt_yxqk" runat="server"  Height="26px"></asp:DropDownList>
             <asp:Label ID="lbl_yxqk" runat="server"></asp:Label></td>    
           </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              设备状态：<asp:Label ID="Label9" runat="server"></asp:Label></td>
              <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
              <asp:DropDownList ID="ddlt_sbzt" runat="server"  Height="26px" ></asp:DropDownList>
              <asp:Label ID="lbl_sbzt" runat="server"></asp:Label></td>
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              设备用途：<asp:Label ID="Label10" runat="server"></asp:Label></td>
              <td style="width:30%; text-align: left; vertical-align: middle;" class="td_sjsc">
              <asp:DropDownList ID="ddlt_sbyt" runat="server"  Height="26px" ></asp:DropDownList>
              <asp:Label ID="lbl_sbyt" runat="server"></asp:Label></td>
           </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              所属支线：<asp:Label ID="Label11" runat="server"></asp:Label></td>
              <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
              <asp:DropDownList ID="ddlt_sszx" runat="server"  Height="26px" OnSelectedIndexChanged="ddlt_jc_change" AutoPostBack="true"></asp:DropDownList>
              <asp:Label ID="lbl_sszx" runat="server"></asp:Label></td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              安装位置：<asp:Label ID="Label12" runat="server"></asp:Label></td>
              <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              <asp:TextBox ID="tbx_azwz" runat="server" MaxLength="3"  Height="26px" placeholder="安装位置"></asp:TextBox>
              <asp:Label ID="lbl_azwz" runat="server"></asp:Label></td>
           </tr>

           <tr style="vertical-align: top;  width:100%;border:1px solid #C0D9D9;" >
             <td style="text-align: right; vertical-align: middle;" class="auto-style1">
              检定日期：<asp:Label ID="Label13" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
             <asp:TextBox ID="tbx_jdrq" runat="server" Height="26px" placeholder="检定日期"  class="Wdate"   onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
             <asp:Label ID="lbl_jdrq" runat="server"></asp:Label></td>
             <td style="width:20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
             检定有效期：<asp:Label ID="Label14" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
             <asp:TextBox ID="tbx_jdyxq" runat="server" Height="26px" placeholder="检定有效期"  class="Wdate"   onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
             <asp:Label ID="lbl_jdyxq" runat="server"></asp:Label></td>
           </tr>

           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              检定证书编号：<asp:Label ID="Label15" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_jdzsbh" runat="server" MaxLength="3"  Height="26px" placeholder="检定证书编号" OnTextChanged="tbx_jdzsbh_TextChanged"></asp:TextBox>
            <asp:Label ID="lbl_jdzsbh" runat="server"></asp:Label></td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
             上传传感器检定证书：<asp:Label ID="Label16" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <Upload:InputFile ID="tbx_sccgqjdzs" runat="server"  placeholder="上传传感器检定证书" Height="26px" />
             <asp:Label ID="lbl_sccgqjdzs" runat="server"></asp:Label></td>
           </tr>
         
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              检定预算：<asp:Label ID="Label17" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_jdys" runat="server" MaxLength="3"  Height="26px" placeholder="检定预算"></asp:TextBox>
            <asp:Label ID="lbl_jdys" runat="server"></asp:Label></td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              检定方式：<asp:Label ID="Label18" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:DropDownList ID="ddlt_jdfs" runat="server"  Height="26px" ></asp:DropDownList>
              <asp:Label ID="lbl_jdfs" runat="server"></asp:Label></td>
           </tr>
           
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              检定单位：<asp:Label ID="Label19" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_jddw" runat="server" Height="26px" placeholder="检定单位"  class="Wdate"></asp:TextBox>
             <asp:Label ID="lbl_jddw" runat="server"></asp:Label></td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              检定结论：<asp:Label ID="Label20" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_jdjl" runat="server" Height="26px" placeholder="检定结论"  class="Wdate"></asp:TextBox>
             <asp:Label ID="lbl_jdjl" runat="server"></asp:Label></td>
           </tr>
           
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              防雷检测日期：<asp:Label ID="Label21" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_fljcrq" runat="server" Height="26px" placeholder="防雷检测日期"  class="Wdate"   onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
             <asp:Label ID="lbl_fljcrq" runat="server"></asp:Label></td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              防雷检测有效期：<asp:Label ID="Label22" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_fljcyxq" runat="server" Height="26px" placeholder="防雷检测有效期"  class="Wdate"   onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
             <asp:Label ID="lbl_fljcyxq" runat="server"></asp:Label></td>
           </tr> 
           
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              电阻实测值：<asp:Label ID="Label23" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_dzscz" runat="server" Height="26px" placeholder="电阻实测值"  class="Wdate"></asp:TextBox>
             <asp:Label ID="lbl_dzscz" runat="server"></asp:Label></td>
             <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              设备故障履历：<asp:Label ID="Label24" runat="server"></asp:Label></td>
             <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
             <asp:TextBox ID="tbx_sbgzll" runat="server" Height="26px" placeholder="设备故障履历"  class="Wdate"   onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
             <asp:Label ID="lbl_sbgzll" runat="server"></asp:Label></td>
           </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                初审人：  <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:DropDownList ID="ddlt_csr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_csr" runat="server" ></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                终审人： <asp:Label ID="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:DropDownList ID="ddlt_zsr" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_zsr" runat="server" ></asp:Label>
            </td>
        </tr> 
           <tr>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                数据所在部门： <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:DropDownList ID="ddlt_sjszbm" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_sjszbm" runat="server" ></asp:Label>
                
            </td>
                                         <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                设备编号：  <asp:Label ID="Label81" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                    <asp:TextBox ID="tbx_sbbh" runat="server" Height="25px" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="lbl_sbbh" runat="server"></asp:Label>
        </tr> 
            
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              备注：  <asp:Label ID="Label25" runat="server" Text="*" ForeColor="white"></asp:Label></td>
              <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
             <asp:TextBox ID="tbx_bz" runat="server" Height="50px" Width="80%" TextMode="MultiLine" style="resize:none;" placeholder="备注"></asp:TextBox>
             <asp:Label ID="lbl_bz" runat="server"></asp:Label></td>
           </tr>
    </table>
    <br />
<br />
	<div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
                <%-- <td style="text-align:right"> <asp:Button ID="btn_edit" runat="server" 
                Text="编辑" class="btn radius"   BackColor="#60B1D7" ForeColor="White" 
                Width="199px" OnClick="btn_edit_Click"  ></asp:Button></td>
               <td>&nbsp;</td>--%>

                <td style="text-align:right"> <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn radius"   BackColor="#60B1D7" ForeColor="White" 
                Width="199px" OnClick="btn_save_Click"  ></asp:Button></td>
               <td>&nbsp;</td>
                  <td style="text-align:left">
                      <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius"  BackColor="#60B1D7" ForeColor="White" 
                Width="199px"    OnClick="btn_back_Click"></asp:Button>
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
                           
                            <td class="td-manage">
                                <asp:LinkButton ID="lbtDown"  CommandName="down" CommandArgument='<%#Eval("sccgqjdzs") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" >下载</asp:LinkButton>
                           
                           
                              <%--  <asp:LinkButton ID="lbtDelete" CommandName="delete" CommandArgument='<%#Eval("wxdsbfshzzj") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server"   OnClientClick="return confirm('您确定要删除该文件？')">删除</asp:LinkButton>--%>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
      <script src="../css/js/jquery.js" type="text/javascript"></script>
     <script src="../css/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            //支线代码
            $("#ddlt_zxdm").change(function () {
                if ($("#ddlt_zxdm option:selected").val() != "-1") {
                    $("#lbl_zxdm").text("正确");
                    $("#lbl_zxdm").css("color", "#00ff00");
                } else {
                    $("#lbl_zxdm").text("请选择");
                    $("#lbl_zxdm").css("color", "#ff0000");
                }
            });

            //设备种类
            $("#ddlt_sbzl").change(function () {
                if ($("#ddlt_sbzl option:selected").val() != "-1") {
                    $("#lbl_sbzl").text("正确");
                    $("#lbl_sbzl").css("color", "#00ff00");
                } else {
                    $("#lbl_sbzl").text("请选择");
                    $("#lbl_sbzl").css("color", "#ff0000");
                }
            });

            //设备状态
            $("#ddlt_sbzt").change(function () {
                if ($("#ddlt_sbzt option:selected").val() != "-1") {
                    $("#lbl_sbzt").text("正确");
                    $("#lbl_sbzt").css("color", "#00ff00");
                } else {
                    $("#lbl_sbzt").text("请选择");
                    $("#lbl_sbzt").css("color", "#ff0000");
                }
            });


            //设备用途
            $("#ddlt_sbyt").change(function () {
                if ($("#ddlt_sbyt option:selected").val() != "-1") {
                    $("#lbl_sbyt").text("正确");
                    $("#lbl_sbyt").css("color", "#00ff00");
                } else {
                    $("#lbl_sbyt").text("请选择");
                    $("#lbl_sbyt").css("color", "#ff0000");
                }
            });


            
            //设备编号
            //$("#tbx_sbbh").blur(function () {
            //    if ($("#tbx_sbbh").val().trim() != "") {
            //        $("#lbl_sbbh").text("正确");
            //        $("#lbl_sbbh").css("color", "#00ff00");

            //    } else {
            //        $("#lbl_sbbh").text("错误：设备编号不能为空");
            //        $("#lbl_sbbh").css("color", "#ff0000");
            //    }
            //});

            //传感器检定证书编号

            $("#tbx_cgqjdzsbh").blur(function () {
                if ($("#tbx_cgqjdzsbh").val().trim() != "") {
                    $("#lbl_cgqjdzsbh").text("正确");
                    $("#lbl_cgqjdzsbh").css("color", "#00ff00");

                } else {
                    $("#lbl_cgqjdzsbh").text("错误：传感器检定证书编号不能为空");
                    $("#lbl_cgqjdzsbh").css("color", "#ff0000");
                }
            });


          
            //所属台站名称

            $("#ddlt_sstzmc").change(function () {
                if ($("#ddlt_sstzmc option:selected").val() != "-1") {
                    $("#lbl_sstzmc").text("正确");
                    $("#lbl_sstzmc").css("color", "#00ff00");
                } else {
                    $("#lbl_sstzmc").text("请选择");
                    $("#lbl_sstzmc").css("color", "#ff0000");
                }
            });
           
         

            //运行情况
            $("#ddlt_yxqk").change(function () {
                if ($("#ddlt_yxqk option:selected").val() != "-1") {
                    $("#lbl_yxqk").text("正确");
                    $("#lbl_yxqk").css("color", "#00ff00");
                } else {
                    $("#lbl_yxqk").text("请选择");
                    $("#lbl_yxqk").css("color", "#ff0000");
                }
            });

            //传感器检定有效期
            
            $("#tbx_cgqjdyxq").blur(function () {
                if ($("#tbx_cgqjdyxq").val().trim() != "") {
                    $("#lbl_cgqjdyxq").text("正确");
                    $("#lbl_cgqjdyxq").css("color", "#00ff00");
                }
                else {
                    $("#lbl_cgqjdyxq").text("错误：传感器检定有效期不能为空");
                    $("#lbl_cgqjdyxq").css("color", "#ff0000");
                }

            });

           
          
            //设备配置
            $("#tbx_sbpz").blur(function () {
                if ($("#tbx_sbpz").val().trim() != "") {
                    $("#lbl_sbpz").text("正确");
                    $("#lbl_sbpz").css("color", "#00ff00");
                }
                else {
                    $("#lbl_sbpz").text("错误：设备配置不能为空");
                    $("#lbl_sbpz").css("color", "#ff0000");
                }

            });
            //数量
            $("#tbx_sl").blur(function () {
                if ($("#tbx_sl").val().trim() != "") {
                    $("#lbl_sl").text("正确");
                    $("#lbl_sl").css("color", "#00ff00");
                }
                else {
                    $("#lbl_sl").text("错误：数量不能为空");
                    $("#lbl_sl").css("color", "#ff0000");
                }
            });
            //设备投产日期
            //$("#tbx_tcrq").blur(function () {
            //    if ($("#tbx_tcrq").val().trim() != "") {
            //        $("#lbl_tcrq").text("正确");
            //        $("#lbl_tcrq").css("color", "#00ff00");
            //    }
            //    else {
            //        $("#lbl_tcrq").text("错误：设备投产日期不能为空");
            //        $("#lbl_tcrq").css("color", "#ff0000");
            //    }

            //});
            //设备竣工日期
            //$("#tbx_jgrq").blur(function () {
            //    if ($("#tbx_jgrq").val().trim() != "") {
            //        $("#lbl_jgrq").text("正确");
            //        $("#lbl_jgrq").css("color", "#00ff00");
            //    }
            //    else {
            //        $("#lbl_jgrq").text("错误：设备竣工日期不能为空");
            //        $("#lbl_jgrq").css("color", "#ff0000");
            //    }

            //});
          

          
            // 路径
            $("#tbx_path").blur(function () {
                if ($("#tbx_path").val().trim() != "") {
                    $("#lbl_lj").text("正确");
                    $("#lbl_lj").css("color", "#00ff00");
                }
                else {
                    $("#lbl_lj").text("错误");
                    $("#lbl_lj").css("color", "#ff0000");
                }

            });
          //  备注
            //$("#tbx_bz").blur(function () {

            //    if ($("#tbx_bz").val().trim() != "") {
            //        $("#lbl_bz").text("正确");
            //        $("#lbl_bz").css("color", "#00ff00");
            //    }
            //    else {
            //        $("#lbl_bz").text("错误：备注不能为空");
            //        $("#lbl_bz").css("color", "#ff0000");
            //    }

            //});

            //数量  只能输入正整数
            //$("#tbx_sl").blur(function () {
            //    if ($("tbx_sl").val != "") {
            //        var reg = /^[0-9]*[1-9][0-9]*$/;
            //        if (reg.test($("#tbx_sl").val()) == false) {
            //            $("#lbl_sl").text("错误:请输入正整数");
            //            $("#lbl_sl").css("color", "#ff0000");
            //        }
            //        else {
            //            $("#lbl_sl").text("正确");
            //            $("#lbl_sl").css("color", "#00ff00");
            //        }
            //    }
            //    else {
            //        $("#lbl_sl").text("错误:数量不能为空！");
            //        $("#lbl_sl").css("color", "#ff0000");
            //    }
            //});


        });

    </script>
	</form>
</article>
</body>
</html>
