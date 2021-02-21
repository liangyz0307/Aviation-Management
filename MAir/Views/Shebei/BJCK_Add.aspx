<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BJCK_Add.aspx.cs" Inherits="CUST.WKG.BJCK_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>备件添加</title>
      <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
    <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"=></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
     <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
            }    
    </style>
</head>
<body>
    <article class="page-container">
     <form id="Form1" runat="server" class="form form-horizontal">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
       <table  style="border-top:2px solid #C0D9D9;border:2px solid #C0D9D9;">
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件编号：  <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                   <asp:TextBox ID="tbx_bjbh" runat="server" Height="26px" MaxLength="14"  placeholder="备件编号" ></asp:TextBox>
                 <asp:Label ID="lbl_bjbh" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              存放位置 ：  <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:TextBox ID="tbx_cfwz" runat="server" Height="26px"  placeholder="存放位置"></asp:TextBox>
                <asp:Label ID="lbl_cfwz" runat="server"></asp:Label>
            </td>
        
        </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                经办人部门：  <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                 <asp:DropDownList ID="ddlt_jbrbm" runat="server" Height="26px" OnSelectedIndexChanged="ddlt_jbrbm_SelectedIndexChanged"  Width="100px" AutoPostBack="True"></asp:DropDownList>
                <asp:Label ID="lbl_jbrbm" runat="server"></asp:Label>
                         </ContentTemplate>
               </asp:UpdatePanel>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                负责人部门： <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate>
                  <asp:DropDownList ID="ddlt_fzrbm" runat="server" Height="26px" OnSelectedIndexChanged="ddlt_fzrbm_SelectedIndexChanged"  Width="100px" AutoPostBack="True"></asp:DropDownList>
                <asp:Label ID="lbl_fzrbm" runat="server"></asp:Label>
                         </ContentTemplate>
               </asp:UpdatePanel>
            </td>
        </tr> 
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                经办人岗位： <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                  <ContentTemplate>
                 <asp:DropDownList ID="ddlt_jbrgw" runat="server"  Width="100px" Height="26px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_jbrgw_SelectedIndexChanged"></asp:DropDownList>
                <asp:Label ID="lbl_jbrgw" runat="server"></asp:Label>
                        </ContentTemplate>
               </asp:UpdatePanel>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                负责人岗位： <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
               <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                  <ContentTemplate>
                   <asp:DropDownList ID="ddlt_fzrgw" runat="server"  Width="100px" Height="26px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_fzrgw_SelectedIndexChanged"></asp:DropDownList>
                <asp:Label ID="lbl_fzrgw" runat="server"></asp:Label>
                         </ContentTemplate>
               </asp:UpdatePanel>
            </td>
        </tr> 
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               出库经办人： <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                  <ContentTemplate>
                 <asp:DropDownList ID="ddlt_jbr" runat="server" Width="100px" Height="26px" AutoPostBack="True"></asp:DropDownList>
                   
                <asp:Label ID="lbl_jbr" runat="server"></asp:Label>
                            </ContentTemplate>
               </asp:UpdatePanel>
            </td> 
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                库房负责人：  <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                  <ContentTemplate>
                   <asp:DropDownList ID="ddlt_fzr" runat="server" Height="26px" Width="100px"></asp:DropDownList>
                <asp:Label ID="lbl_fzr" runat="server"></asp:Label>
                           </ContentTemplate>
               </asp:UpdatePanel>
            </td>
           
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                出库数量：  <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:TextBox ID="tbx_cksl" runat="server" Height="26px"  placeholder="出库数量" MaxLength="6" onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;"></asp:TextBox>
                <asp:Label ID="lbl_cksl" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                出库时间： <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                  <asp:TextBox ID="tbx_cksj" runat="server" Height="26px" placeholder="出库时间" onclick="lhgcalendar({format:'yyyy-MM-dd hh:mm:ss'})"></asp:TextBox>
                <asp:Label ID="lbl_cksj" runat="server"></asp:Label>
            </td>
        </tr> 
                      <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                初审人：  <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                  <asp:DropDownList ID="ddlt_csr" runat="server" style="width:100px"></asp:DropDownList>
                    <asp:Label ID="lbl_csr" runat="server" ></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                终审人： <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:DropDownList ID="ddlt_zsr" runat="server" style="width:100px"></asp:DropDownList>
                    <asp:Label ID="lbl_zsr" runat="server" ></asp:Label>
            </td>
        </tr> 
           <tr>
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                数据所在部门： <asp:Label ID="Label13" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:DropDownList ID="ddlt_sjszbm" runat="server" style="width:100px"></asp:DropDownList>
                    <asp:Label ID="lbl_sjszbm" runat="server" ></asp:Label>
                
            </td>
        </tr> 
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                出库备注：  <asp:Label ID="Label11" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                  <asp:TextBox ID="tbx_bz" runat="server" TextMode="MultiLine"  placeholder="出库备注"  style="resize:none;" Height ="50px" width="750px" ></asp:TextBox>
            </td>
        </tr>
    </table>
   <br />
         	<div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
                <td style="text-align:right"> <asp:Button ID="btn_bc" runat="server" 
                Text="保存" class="btn radius"   BackColor="#60B1D7" ForeColor="White" 
                Width="199px" OnClick="btn_bc_Click"  ></asp:Button></td>
               <td>&nbsp;</td>
                  <td style="text-align:left">
                      <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius"  BackColor="#60B1D7" ForeColor="White" 
                Width="199px"    OnClick="btn_fh_Click"></asp:Button>
                  </td>
            </tr>
        </table>
	</div>
         <%-- <script type="text/javascript">
              $(document).ready(function () {
                  //备件编号
                  $("#tbx_bjbh").blur(function () {
                      if ($("#tbx_bjbh").val().trim() != "") {
                          $("#lbl_bjbh").text("正确");
                          $("#lbl_bjbh").css("color", "#00ff00");

                      } else {
                          $("#lbl_bjbh").text("错误");
                          $("#lbl_bjbh").css("color", "#ff0000");
                      }
                  });
                  $("#tbx_cfwz").blur(function () {
                      if ($("#tbx_cfwz").val().trim() != "") {
                          $("#lbl_cfwz").text("正确");
                          $("#lbl_cfwz").css("color", "#00ff00");

                      } else {
                          $("#lbl_cfwz").text("错误");
                          $("#lbl_cfwz").css("color", "#ff0000");
                      }
                  });
                  $("#tbx_cksl").blur(function () {
                      if ($("#tbx_cksl").val().trim() != "") {
                          $("#lbl_cksl").text("正确");
                          $("#lbl_cksl").css("color", "#00ff00");

                      } else {
                          $("#lbl_cksl").text("错误");
                          $("#lbl_cksl").css("color", "#ff0000");
                      }
                  });
                  //$("#tbx_cksj").blur(function () {
                  //    if ($("#tbx_cksj").val().trim() != "") {
                  //        $("#lbl_cksj").text("正确");
                  //        $("#lbl_cksj").css("color", "#00ff00");

                  //    } else {
                  //        $("#lbl_cksj").text("错误");
                  //        $("#lbl_cksj").css("color", "#ff0000");
                  //    }
                  //});
                  //负责人
                 
                  $("#ddlt_fzr").change(function () {
                      if ($("#ddlt_fzr option:selected").val() != "-1") {
                          $("#lbl_fzr").text("正确");
                          $("#lbl_fzr").css("color", "#00ff00");
                      } else {
                          $("#lbl_fzr").text("请选择");
                          $("#lbl_fzr").css("color", "#ff0000");
                      }
                  });
                  $("#ddlt_jbrgw").change(function () {
                      if ($("#ddlt_jbrgw option:selected").val() != "-1") {
                          $("#lbl_jbrgw").text("正确");
                          $("#lbl_jbrgw").css("color", "#00ff00");
                      } else {
                          $("#lbl_jbrgw").text("请选择");
                          $("#lbl_jbrgw").css("color", "#ff0000");
                      }
                  });
                  $("#ddlt_fzrgw").change(function () {
                      if ($("#ddlt_fzrgw option:selected").val() != "-1") {
                          $("#lbl_fzrgw").text("正确");
                          $("#lbl_fzrgw").css("color", "#00ff00");
                      } else {
                          $("#lbl_fzrgw").text("请选择");
                          $("#lbl_fzrgw").css("color", "#ff0000");
                      }
                  });
                  $("#ddlt_fzrbm").change(function () {
                      if ($("#ddlt_fzrbm option:selected").val() != "-1") {
                          $("#lbl_fzrbm").text("正确");
                          $("#lbl_fzrbm").css("color", "#00ff00");
                      } else {
                          $("#lbl_fzrbm").text("请选择");
                          $("#lbl_fzrbm").css("color", "#ff0000");
                      }
                  });
                  $("#ddlt_jbrbm").change(function () {
                      if ($("#ddlt_jbrbm option:selected").val() != "-1") {
                          $("#lbl_jbrbm").text("正确");
                          $("#lbl_jbrbm").css("color", "#00ff00");
                      } else {
                          $("#lbl_jbrbm").text("请选择");
                          $("#lbl_jbrbm").css("color", "#ff0000");
                      }
                  });
                  $("#ddlt_jbr").change(function () {
                      if ($("#ddlt_jbr option:selected").val() != "-1") {
                          $("#lbl_jbr").text("正确");
                          $("#lbl_jbr").css("color", "#00ff00");
                      } else {
                          $("#lbl_jbr").text("请选择");
                          $("#lbl_jbr").css("color", "#ff0000");
                      }
                  });


                  //按钮判断
                  $("#btn_bc").click(function () {
                      var flag = 0;
                      if ($("#tbx_bjbh").val().trim() == "") {
                          $("#lbl_bjbh").text("错误：备件编号不能为空");
                          $("#lbl_bjbh").css("color", "#ff0000");
                          $("#tbx_bjbh").focus();
                          flag = 1;
                          //return false;
                      }
                      else {
                          $("#lbl_bjbh").text("正确");
                          $("#lbl_bjbh").css("color", "#00ff00");
                      }
                      if ($("#tbx_cfwz").val().trim() == "") {
                          $("#lbl_cfwz").text("错误：存放位置不能为空");
                          $("#lbl_cfwz").css("color", "#ff0000");
                          $("#tbx_cfwz").focus();
                          flag = 1;
                          //return false;
                      }
                      else {
                          $("#lbl_cfwz").text("正确");
                          $("#lbl_cfwz").css("color", "#00ff00");
                      }
                      if ($("#ddlt_jbrbm").val().trim() == "-1") {
                          $("#lbl_jbrbm").text("错误：请选择经办人部门");
                          $("#lbl_jbrbm").css("color", "#ff0000");
                          $("#ddlt_jbrbm").focus();
                          flag = 1;
                          //return false;
                      }
                      else {
                          $("#lbl_jbrbm").text("正确");
                          $("#lbl_jbrbm").css("color", "#00ff00");
                      }
                      if ($("#ddlt_fzrbm").val().trim() == "-1") {
                          $("#lbl_fzrbm").text("错误：请选择负责人部门");
                          $("#lbl_fzrbm").css("color", "#ff0000");
                          $("#ddlt_fzrbm").focus();
                          flag = 1;
                          //return false;
                      }
                      else {
                          $("#lbl_fzrbm").text("正确");
                          $("#lbl_fzrbm").css("color", "#00ff00");
                      }
                      if ($("#ddlt_jbrgw").val().trim() == "-1") {
                          $("#lbl_jbrgw").text("错误：请选择经办人岗位");
                          $("#lbl_jbrgw").css("color", "#ff0000");
                          $("#ddlt_jbrgw").focus();
                          flag = 1;
                          //return false;
                      }
                      else {
                          $("#lbl_jbrgw").text("正确");
                          $("#lbl_jbrgw").css("color", "#00ff00");
                      }
                      if ($("#ddlt_fzrgw").val().trim() == "-1") {
                          $("#lbl_fzrgw").text("错误：请选择负责人岗位");
                          $("#lbl_fzrgw").css("color", "#ff0000");
                          $("#ddlt_fzrgw").focus();
                          flag = 1;
                          //return false;
                      }
                      else {
                          $("#lbl_fzrgw").text("正确");
                          $("#lbl_fzrgw").css("color", "#00ff00");
                      }

                      if ($("#ddlt_jbr").val().trim() == "-1") {
                          $("#lbl_jbr").text("错误：请选择经办人");
                          $("#lbl_jbr").css("color", "#ff0000");
                          $("#ddlt_jbr").focus();
                          flag = 1;
                          //return false;
                      }
                      else {
                          $("#lbl_jbr").text("正确");
                          $("#lbl_jbr").css("color", "#00ff00");
                      }
                      if ($("#ddlt_fzr").val().trim() == "-1") {
                          $("#lbl_fzr").text("错误：请选择负责人");
                          $("#lbl_fzr").css("color", "#ff0000");
                          $("#ddlt_fzr").focus();
                          flag = 1;
                          //return false;
                      }
                      else {
                          $("#lbl_fzr").text("正确");
                          $("#lbl_fzr").css("color", "#00ff00");
                      }
                      if ($("#tbx_cksl").val().trim() == "") {
                          $("#lbl_cksl").text("错误：出库数量不能为空");
                          $("#lbl_cksl").css("color", "#ff0000");
                          $("#tbx_cksl").focus();
                          flag = 1;
                          //return false;
                      }
                      else {
                          $("#lbl_cksl").text("正确");
                          $("#lbl_cksl").css("color", "#00ff00");
                      }
                      if ($("#tbx_cksj").val().trim() == "") {
                          $("#lbl_cksj").text("错误：出库时间不能为空");
                          $("#lbl_cksj").css("color", "#ff0000");
                          $("#tbx_cksj").focus();
                          flag = 1;
                          //return false;
                      }
                      else {
                          $("#lbl_cksj").text("正确");
                          $("#lbl_cksj").css("color", "#00ff00");
                      }
                      if (flag == 1)
                      {
                          return false;
                      }

                  });
              });
              </script>--%>
  </form>
         </article>





</body>
</html>
