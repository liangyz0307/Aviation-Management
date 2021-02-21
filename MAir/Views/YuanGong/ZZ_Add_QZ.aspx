<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZZ_Add_QZ.aspx.cs" Inherits="CUST.WKG.ZZ_Add_QZ" %>

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
      <%--   <nav class="breadcrumb">个人信息管理 <span class="c-gray en">&gt;</span> 个人信息<span class="c-gray en">&gt;</span>员工添加
         </nav>--%>
      <div class="panel-head">
            <strong class="icon-reorder">员工签注资质添加</strong>
        </div>
    <table >
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   员 工 编 号：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                    
                    <asp:Label ID="lbl_bh" runat="server" ></asp:Label>
                      </td>
            </tr>
           
        
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    签 注 专 业：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    
                       <asp:DropDownList ID="ddlt_qzzy" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlt_qzzy_SelectedIndexChanged" ></asp:DropDownList>
                    <asp:Label ID="lbl_qzzy" runat="server" ></asp:Label>
                      
                </td>
                
            </tr>
          </ContentTemplate>
               </asp:UpdatePanel>
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate>
         <tr id="qzlb" runat="server" style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    执 照 签 注 类 别：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   
                      <asp:DropDownList ID="ddlt_zzqzlb" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlt_zzqzlb_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Label ID="lbl_zzqzlb" runat="server" ></asp:Label>
                     
                </td>
                
            </tr>
                       </ContentTemplate>
               </asp:UpdatePanel>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    签 注 项：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:DropDownList ID="ddlt_zzqzx" runat="server"></asp:DropDownList>
                    <asp:Label ID="lbl_zzqzx" runat="server" ></asp:Label>
                </td>
                
            </tr>
            <tr id="zzqzd" runat="server" style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    执 照 签 注 地：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_zzqzd" runat="server" class="input-text" placeholder="执照签注地" 
                 Width="446px" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="lbl_zzqzd" runat="server" ></asp:Label>
                </td>
                
            </tr>
       
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    注 册 类 别 有 效 期：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_zclbyxq" runat="server" class="input-text" placeholder="注册类别有效期" 
                 Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8" ></asp:TextBox>
                    <asp:Label ID="lbl_zclbyxq" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr id="ydqz" runat="server" style="vertical-align: top;  width:100%;border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9; height: 30px;" class="td_sjsc">
        异 地 签 注：<span class="c-red">*</span>
</td>
                <td style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9; height: 30px;" class="td_sjsc">
                      <asp:DropDownList ID="ddlt_ydqz" runat="server" OnSelectedIndexChanged="ddlt_ydqz_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <asp:Label ID="lbl_ydqz" runat="server" ></asp:Label>
                &nbsp;
                </td>
                
            </tr>
         <tr id="ydqzx" runat="server" style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                
                             
                    异 地 签 注 项：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     <asp:DropDownList ID="ddlt_ydqzx" runat="server"></asp:DropDownList>
                    <asp:Label ID="lbl_ydqzx" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr id="ydqzd" runat="server" style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    异 地 签 注 地：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_ydqzd" runat="server" class="input-text" placeholder="异地签注地" 
                 Width="446px" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="lbl_ydqzd" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr id="ydqzyxq" runat="server" style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    异 地 签 注 有 效 期：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <asp:TextBox ID="tbx_ydqzyxq" runat="server" class="input-text" placeholder="异地签注有效期" 
                 Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8" ></asp:TextBox>
                    <asp:Label ID="lbl_ydqzyxq" runat="server" ></asp:Label>
                </td>
                
            </tr>
        <tr id="tjdj" runat="server" style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9; height: 25px;" class="td_sjsc">
                    体 检 等 级：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9; height: 25px;" class="td_sjsc">
                      <asp:DropDownList ID="ddlt_tjdj" runat="server"></asp:DropDownList>
                    <asp:Label ID="lbl_tjdj" runat="server" ></asp:Label>
                </td>
                
            </tr>
         <tr id="tjyxq" runat="server" style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9; height: 39px;" class="td_sjsc">
                   体 检 有 效 期：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9; height: 39px;" class="td_sjsc">
                      <asp:TextBox ID="tbx_tjyxq" runat="server" class="input-text" placeholder="体检有效期" 
                 Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8" ></asp:TextBox>
                    <asp:Label ID="lbl_tjyxq" runat="server" ></asp:Label>
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
   <%-- <script type="text/javascript">
        $(document).ready(function () {
            //隐藏（不占用）
            //document.getElementById("ydqz").style.display = "none";
            //document.getElementById("ydqzx").style.display = "none";
            //document.getElementById("ydqzd").style.display = "none";
            //document.getElementById("ydqzyxq").style.display = "none";
            //document.getElementById("tjdj").style.display = "none";
            //document.getElementById("tjyxq").style.display = "none";
            //document.getElementById("zzqzd").style.display = "none";
            //显示（不占用）document.getElementById("控件ID").style.display = "inline";
            //隐藏(占用)document.getElementById("ydqz").style.visibility = "hidden";
            //显示(占用)：document.getElementById("控件ID").style.visibility="visible";
           
          
            //注册类别有效期5
            $("#tbx_zclbyxq").blur(function () {
                    $("#lbl_zclbyxq").text("正确");
                    $("#lbl_zclbyxq").css("color", "#00ff00");
               
            });
            //异地签注有效期6
            $("#tbx_ydqzyxq").blur(function () {
                    $("#lbl_ydqzyxq").text("正确");
                    $("#lbl_ydqzyxq").css("color", "#00ff00");
              
            });
            //体检有效期7
            $("#tbx_tjyxq").blur(function () {
                    $("#lbl_tjyxq").text("正确");
                    $("#lbl_tjyxq").css("color", "#00ff00");
               
            });
            //备注8
            $("#tbx_bz").blur(function () {
                    $("#lbl_bz").text("正确");
                    $("#lbl_bz").css("color", "#00ff00");
                   
            });
           

            //签注专业
            //$("#ddlt_qzzy").change(function () {
            //    if ($("#ddlt_qzzy option:selected").val() != "-1") {
            //        $("#lbl_qzzy").text("正确");
            //        $("#lbl_qzzy").css("color", "#00ff00");
            //        //管制专业
            //        if ($("#ddlt_qzzy option:selected").val() == "1") {
            //            document.getElementById("qzlb").style.display = "none";
            //            document.getElementById("zzqzd").style.visibility = "visible";
            //            // $("#zzqzd").show();
            //            $("#ydqz").show();
            //            $("#tjdj").show();
            //            // $("#tjyxq").show();
            //            $("#zzqzd").show();
            //        } else
            //        {
            //            $("#qzlb").show();
            //            $("#zzqzd").hide();
            //            $("#ydqz").hide();
            //            $("#tjdj").hide();
            //            $("#zzqzd").hide();
            //        }
            //    } else {
            //        $("#lbl_qzzy").text("请选择");
            //        $("#lbl_qzzy").css("color", "#ff0000");
            //    }

            //});

            //执照签注类别23
            $("#ddlt_zzqzlb").change(function () {
                if ($("#ddlt_zzqzlb option:selected").val() != "-1") {
                    $("#lbl_zzqzlb").text("正确");
                    $("#lbl_zzqzlb").css("color", "#00ff00");
                } else {
                    $("#lbl_zzqzlb").text("请选择");
                    $("#lbl_zzqzlb").css("color", "#ff0000");
                }

            });
            ////异地签注25
            //$("#ddlt_ydqz").change(function () {
            //    if ($("#ddlt_ydqz option:selected").val() != "-1") {
            //        $("#lbl_ydqz").text("正确");
            //        $("#lbl_ydqz").css("color", "#00ff00");
            //        if ($("#ddlt_ydqz option:selected").val() != "1") {
            //            ydqzd.show();
            //            ydqzx.show();
            //            ydqzyxq.show();
            //        } else
            //        {
            //            ydqzd.hide();
            //            ydqzx.hide();
            //            ydqzyxq.hide();
            //        }
            //    } else {
            //        $("#lbl_ydqz").text("请选择");
            //        $("#lbl_ydqz").css("color", "#ff0000");
            //    }

            //});
            //异地签注类别26
            $("#ddlt_ydqzlb").change(function () {
                if ($("#ddlt_ydqzlb option:selected").val() != "-1") {
                    $("#lbl_ydqzlb").text("正确");
                    $("#lbl_ydqzlb").css("color", "#00ff00");
                } else {
                    $("#lbl_ydqzlb").text("请选择");
                    $("#lbl_ydqzlb").css("color", "#ff0000");
                }

            });
            //体检等级30
            $("#ddlt_tjdj").change(function () {
                if ($("#ddlt_tjdj option:selected").val() != "-1") {
                    $("#lbl_tjdj").text("正确");
                    $("#lbl_tjdj").css("color", "#00ff00");
                } else {
                    $("#lbl_tjdj").text("请选择");
                    $("#lbl_tjdj").css("color", "#ff0000");
                }

            });
           
            
           
        });
    </script>--%>
</html>
