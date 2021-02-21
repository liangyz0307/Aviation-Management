<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZZ_Edit_YY.aspx.cs" Inherits="MAir.Views.YuanGong.ZZ_Edit_YY" %>

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
            <strong class="icon-reorder">员工英语资质编辑</strong>
        </div>
    <table >
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   员 工 编 号：</td>
                <td style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_bh" runat="server" ></asp:Label>
                      </td>
            </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    英 语 等 级：<span class="c-red">*</span></td>
                <td style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_yydj" runat="server"></asp:DropDownList>
                    <asp:Label ID="lbl_yydj" runat="server" ></asp:Label>
                    </td>
            </tr>

            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    英 语 有 效 期：</td>
                <td style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:TextBox ID="tbx_yyyxq" runat="server" class="input-text" placeholder="英语有效期" 
                 Width="446px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8" ></asp:TextBox>
                    <asp:Label ID="lbl_yyyxq" runat="server" ></asp:Label>
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
                <td style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
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
                Width="199px"  onclick="btn_save_Click"></asp:Button>  
              &nbsp;  
              <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px"  onclick="btn_fh_Click"></asp:Button>  
		</div>
	</div>
	</form>
</article>
    <!--_footer 作为公共模版分离出去-->

   

    <script type="text/javascript" src="../../Content/js/H-ui.js"></script>

    <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>

    <!--/_footer /作为公共模版分离出去-->
    <!--请在下方写此页面业务相关的脚本-->
    <script src="../../Content/js/jquery.js" type="text/javascript"></script>
      <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
   <%-- <script type="text/javascript">
        $(document).ready(function() {
            //英语有效期1
            $("#tbx_yyyxq").click(function () {

                $("#lbl_yyyxq").text("正确");
                $("#lbl_yyyxq").css("color", "#00ff00");

            });
            
            //备注8
            $("#tbx_bz").blur(function () {
                $("#lbl_bz").text("正确");
                $("#lbl_bz").css("color", "#00ff00");

            });
            //英语等级28
            $("#ddlt_yydj").change(function () {
                if ($("#ddlt_yydj option:selected").val() != "-1") {
                    $("#lbl_yydj").text("正确");
                    $("#lbl_yydj").css("color", "#00ff00");
                } else {
                    $("#lbl_yydj").text("请选择");
                    $("#lbl_yydj").css("color", "#ff0000");
                }

            });

          
           
        });
    </script>--%>
  

</body>


</html>

