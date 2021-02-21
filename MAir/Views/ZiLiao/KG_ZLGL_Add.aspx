<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KG_ZLGL_Add.aspx.cs" Inherits="CUST.WKG.KG_ZLGL_Add" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>

    <script type="text/javascript" src="../lib/respond.min.js"></script>

    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
   
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
      <%--   <nav class="breadcrumb">个人信息管理 <span class="c-gray en">&gt;</span> 个人信息<span class="c-gray en">&gt;</span>员工添加
         </nav>--%>
	<div class="panel-head">
            <strong class="icon-reorder">资料添加</strong>
        </div>
    <table >
           
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    文 档 类 型：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_zllx1" runat="server" style="width:200px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_zllx1_SelectedIndexChanged"></asp:DropDownList>
                      <asp:DropDownList ID="ddlt_zllx2" runat="server"  style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_zllx1" runat="server" ></asp:Label>
                    <asp:Label ID="lbl_zllx2" runat="server" ></asp:Label>
                    </td>
            </tr>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     文 档 选 择：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <Upload:InputFile ID="AttachFile" runat="server" />
                    <%--<asp:Button ID="BtnUP" runat="server" Text="上传"  />--%>
                    <Upload:ProgressBar ID="ProgressBar1" runat='server'>
    </Upload:ProgressBar>
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

     <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    文件列表
                                </th>
                            </tr>
                            <tr class="text-c">
                               
                                 <th width="40"  style="text-align:left;vertical-align:middle;">
                                   文档类型
                                </th>
                                <th width="40"  style="text-align:left;vertical-align:middle;">
                                   文档名
                                </th>
                               
                                <th width="50"  style="text-align:left;vertical-align:middle;">
                                    文件路径
                                </th>
                               
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c" >
                            
                             <td style="width:27%;text-align:left;vertical-align:middle;">
                               <asp:Label ID="Label1"  runat="server" Text='<%#Eval("ZLLX1MC") %>'></asp:Label>
                            </td>
                            <td style="width:27%;text-align:left;vertical-align:middle;">
                               <asp:Label ID="Label2"  runat="server" Text='<%#Eval("ZLLX2MC") %>'></asp:Label>
                            </td>
                             <td style="width:27%;text-align:left;vertical-align:middle;">
                                 <asp:LinkButton ID="LinkButton1"  CommandName="down" CommandArgument='<%#Eval("wjlj") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" Text='<%#Eval("FileName") %>' ></asp:LinkButton>
                            </td>
                             
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
	</form>
</article>
    
</body>
    <script src="../css/js/jquery.js" type="text/javascript"></script>
      <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
       <script type="text/javascript">
        $(document).ready(function () {
            //资料类型一
            $("#ddlt_zllx1").change(function () {
                if ($("#ddlt_zllx1 option:selected").val() != "-1") {
                    $("#lbl_zllx1").text("正确");
                    $("#lbl_zllx1").css("color", "#00ff00");
                } else if
                    ($("#ddlt_zllx1 option:selected").val() != "0") {
                    $("#lbl_zllx1").text("正确");
                    $("#lbl_zllx1").css("color", "#00ff00");
                    $("#lbl_zllx2").text("正确");
                    $("#lbl_zllx2").css("color", "#00ff00");
            }
                  else
                    {
                    $("#lbl_zllx1").text("请选择");
                    $("#lbl_zllx1").css("color", "#ff0000");
                }
            });
          
        });
    </script> 
</html>
