<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LL_Edit_Edit.aspx.cs" Inherits="CUST.WKG.LL_Edit_Edit" %>
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
	 <div class="panel-head">
            <strong class="icon-reorder">员工履历编辑</strong>
        </div>
    <table >
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   员 工 编 号：</td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_bh" runat="server" ></asp:Label>
                      </td>
            </tr>
      <%--  <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
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
                 Width="446px" MaxLength="20">
                    </asp:TextBox>
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
                      <asp:TextBox ID="tbx_gzdd" runat="server" class="input-text" placeholder="工作地点(不能超过20字！)" 
                 Width="446px" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="lbl_gzdd" runat="server" ></asp:Label>
                </td>
                
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    起 始 日 期：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_qzrq" runat="server" class="input-text" placeholder="起止日期" 
                 Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
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
             <%--<asp:Button ID="Button1" runat="server" 
                Text="编辑" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px"  onclick="btn_Edit_Click"></asp:Button>--%> 
		    <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="199px"  onclick="btn_save_Click"></asp:Button>  
              &nbsp;  
              <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="199px"  onclick="btn_fh_Click"></asp:Button>  
		</div>
	</div>
        <br />
      
	</form>
</article>
</body>
      <script src="../../Content/js/jquery.js" type="text/javascript"></script>
      <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
     <%--<script type="text/javascript">
        $(document).ready(function () {
            //工作单位
            $("#tbx_gzdw").click(function () {

                $("#lbl_zzdw").text("正确");
                $("#lbl_zzdw").css("color", "#00ff00");

            });
            //工作部门
            $("#tbx_gzbm").blur(function () {
                $("#lbl_gzbm").text("正确");
                $("#lbl_gzbm").css("color", "#00ff00");

            });
            //工作岗位
            $("#tbx_gzgw").blur(function () {
                $("#lbl_gzgw").text("正确");
                $("#lbl_gzgw").css("color", "#00ff00");

            });
            //工作地点
            $("#tbx_gzdd").blur(function () {
                $("#lbl_gzdd").text("正确");
                $("#lbl_gzdd").css("color", "#00ff00");

            });
            //起止日期
            $("#tbx_qzrq").blur(function () {
                $("#lbl_qzrq").text("正确");
                $("#lbl_qzrq").css("color", "#00ff00");

            });
            //截止日期
            $("#tbx_jzrq").blur(function () {
                $("#lbl_jzrq").text("正确");
                $("#lbl_jzrq").css("color", "#00ff00");

            });

            //备注
            $("#tbx_bz").blur(function () {
                $("#lbl_bz").text("正确");
                $("#lbl_bz").css("color", "#00ff00");

            });
          
        });
    </script> --%>
</html>
