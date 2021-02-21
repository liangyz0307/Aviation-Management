<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YH_JSPZ.aspx.cs" Inherits="CUST.WKG.YH_JSPZ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

 <head id="Head1" runat="server">
    <title></title>
  
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>

    <script type="text/javascript" src="../lib/respond.min.js"></script>

    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css"
        id="skin" />
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
	 <div class="panel-head" style="text-align:center">
            <strong class="icon-reorder" style="font-size:20px">用户角色配置</strong>
        </div>
        
 <%--  <div style="text-align:center">
      用户编号：
       <asp:Label ID="lbl_yhbh" runat="server" ></asp:Label>
   </div>--%>
<br />
       <table style="width:100%">
<tr>
<td style="width:48%">
<table style="width:100%; margin-right: 0px;">
<tr  style="width:48%">
    <td align="center"  style=" width:60%;height:20px;" >
        未分配角色</td>
    </tr>
    <tr style="width:90%">
    <td style="width:60%">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
    <div style="overflow:scroll;border:1px solid #000;width:100%; height:270px;" >
    
        <asp:CheckBoxList ID="cbxl_wfpjs" runat="server" Height="17px" Width="98%" 
            RepeatColumns="1" RepeatDirection="Horizontal" >
        </asp:CheckBoxList> 
        
    </div>
    </ContentTemplate>
                </asp:UpdatePanel> 
    </td>
    </tr>
    <tr style="width:60%">
    <td style=" width:60%">
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
    <asp:CheckBox ID="cbx_wfp" runat="server" AutoPostBack="True" OnCheckedChanged="cbx_wfp_CheckedChanged" 
            />全选
            </ContentTemplate>
                </asp:UpdatePanel> 
    </td>
    </tr>
</table>
</td>
   <td style="width:2%">
    </td>
<td style="width:4%">
    
    <table>
    <tr>
    <td style="height:40px">
    </td>
    </tr>
    <tr>
    <td style="height:40px">
    </td>
    </tr>
    <tr  style=" height:60px">
    <td align="center" style="width:80px;"  >
        <asp:Button ID="btn_add_js" runat="server" Text=" ====》" Width="80px" 
                     class="btn  radius" ForeColor="White" BackColor="#60B1D7" OnClick="btn_add_js_Click"  />
    </td>
    </tr>
    
    <tr height="60px">
    <td align="center"  style="width:80px">
        <asp:Button ID="btn_del_js" runat="server" Text="《====" Width="80px" 
                     class="btn  radius" ForeColor="White" BackColor="#60B1D7" OnClick="btn_del_js_Click"  />
    </td>
    </tr>
          <tr style=" height:60px">
    <td align="center"    style="width:80px">
       <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="80px"  onclick="btn_fh_Click"></asp:Button>  
    </td>
    </tr>
    </table>
    </td>
    <td  style="width:2%">

    </td>
    <td style="width:50%" >
    <table style="width:100%">
    <tr style="width:90%">
    <td align="center"  style="height:20px;" >
        已分配角色</td>
    </tr>
    <tr>
    <td style="height:40px">
    <div style="overflow:scroll;border:1px solid #000;width:100%; height:270px;" >
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
        <asp:CheckBoxList ID="cbxl_yfpjs" runat="server" Height="16px" Width="98%" 
            RepeatColumns="1" RepeatDirection="Horizontal">
        </asp:CheckBoxList>
    </ContentTemplate>
                </asp:UpdatePanel>
    </div>
    </td>
    </tr>
    <tr>
    <td style="width:50%">
    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
    <asp:CheckBox ID="cbx_yfp" runat="server" AutoPostBack="True" OnCheckedChanged="cbx_yfp_CheckedChanged" 
            />全选
            </ContentTemplate>
                </asp:UpdatePanel>
    </td>
    </tr>
    </table>
    </td>

</tr>
</table>
	
	</form>
</article>
    <!--_footer 作为公共模版分离出去-->

   

    
    <script type="text/javascript" src="../../Content/css/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../../Content/css/h-ui.admin/js/H-ui.admin.js"></script>

    <!--/_footer /作为公共模版分离出去-->
    <!--请在下方写此页面业务相关的脚本-->

  

</body>


</html>
