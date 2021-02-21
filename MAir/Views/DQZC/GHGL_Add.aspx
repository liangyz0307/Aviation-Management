<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GHGL_Add.aspx.cs" Inherits="MAir.Views.DQZC.GHGL_Add" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>工会管理添加</title>
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
            <strong class="icon-reorder">文件上传</strong>
        </div>
    <table >
           
           <%-- <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    文 档 类 型：<span class="c-red">*</span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                    <asp:DropDownList ID="ddlt_wdlx" runat="server" style="width:200px"></asp:DropDownList>
                    <asp:Label ID="lbl_wdlx" runat="server" ></asp:Label>
                    </td>
            </tr>--%>

        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     文 档 选 择：<span class="c-red"></span></td>
                <td colspan="2" style="width:40%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    <Upload:InputFile ID="AttachFile" runat="server" />
                    <%--<asp:Button ID="BtnUP" runat="server" Text="上传"  />--%>
                    <Upload:ProgressBar ID="ProgressBar1" runat='server'>
    </Upload:ProgressBar>
                </td>
                
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   上传人：</td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                    
                    <asp:Label ID="lbl_scr" runat="server" ></asp:Label></td>
            </tr>
            <%--<tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   上传IP：</td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                    
                    <asp:Label ID="lbl_scip" runat="server" ></asp:Label></td>
            </tr> --%>    
       
      
        </table>

	<div class="row cl">
		<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
		    <asp:Button ID="btn_save" runat="server" 
                Text="保存" class="btn  radius" ForeColor="White" BackColor="#ab2025" 
                Width="199px" OnClick="btn_save_Click"   ></asp:Button> 
            &nbsp; 
            <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#ab2025"
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
                            <%--<tr class="text-c">
                               
                                 <th width="40"  style="text-align:left;vertical-align:middle;">
                                   文档类型
                                </th>--%>
                                <th width="40"  style="text-align:left;vertical-align:middle;">
                                   文档名
                                </th>
                               
                                <th width="50"  style="text-align:left;vertical-align:middle;">
                                    上传时间
                                </th>
                               
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c" >
                            
                             <%--<td style="width:27%;text-align:left;vertical-align:middle;">
                               <asp:Label ID="Label1"  runat="server" Text='<%#Eval("WDLXMC") %>'></asp:Label>
                            </td>--%>
                             <td style="width:27%;text-align:left;vertical-align:middle;">
                                 <asp:LinkButton ID="LinkButton1"  CommandName="down" CommandArgument='<%#Eval("SCLJ") %>'  ForeColor="blue" style="text-decoration:underline"
                                    runat="server" Text='<%#Eval("FileName") %>' ></asp:LinkButton>
                               <%-- <asp:Label ID="Label2"  runat="server" Text='<%#Eval("FileName_px") %>'></asp:Label>--%>
                            </td>
                            <%-- <td style="width:27%;text-align:left;vertical-align:middle;">
                                 <asp:LinkButton ID="LinkButton2"  CommandName="down" CommandArgument='<%#Eval("aqjyda") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" Text='<%#Eval("FileName") %>' ></asp:LinkButton>
                               <%-- <asp:Label ID="Label3"  runat="server" Text='<%#Eval("FileName_jy") %>'></asp:Label>--%>
                            </td>
                             <td style="width:19%;text-align:left;vertical-align:middle;">
                                <asp:Label ID="Label44"  runat="server" Text='<%#Eval("FileTime") %>'></asp:Label>
                            </td>
                          <%--  <td style="width:40%" class="td-manage">
                                <asp:LinkButton ID="lbtDown"  CommandName="down" CommandArgument='<%#Eval("YuanshiFileName") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" >下载</asp:LinkButton>
                           
                           
                                <asp:LinkButton ID="lbtDelete" CommandName="delete" CommandArgument='<%#Eval("YuanshiFileName") %>'  ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server"   OnClientClick="return confirm('您确定要删除该文件？')">删除</asp:LinkButton>
                            </td>--%>
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
               //文档类型
               $("#ddlt_wdlx").change(function () {
                   if ($("#ddlt_wdlx option:selected").val() != "-1") {
                       $("#lbl_wdlx").text("正确");
                       $("#lbl_wdlx").css("color", "#00ff00");
                   } else {
                       $("#lbl_wdlx").text("请选择");
                       $("#lbl_wdlx").css("color", "#ff0000");
                   }
               });

           });
    </script> 
</html>

