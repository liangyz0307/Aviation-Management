﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZZ_Detail.aspx.cs" Inherits="CUST.WKG.ZZ_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

 <head id="Head1" runat="server">
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
	 <div class="panel-head" style="text-align:center">
            <strong class="icon-reorder">员工资质详情</strong>
       
  </div>
         <strong class="icon-reorder">英语资质列表</strong><br />
        <asp:Repeater ID="Repeater1" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr class="text-c">
                               
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                   英语等级
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   英语有效期
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                  <%#(cpage1-1)*psize1+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("yydjmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("yyyxqmc") %>'></asp:Label>
                            </td>
                            
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        <br />
        
         <strong class="icon-reorder">执照资质列表</strong><asp:Repeater ID="Repeater2" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                          <%--  <tr>
                                <th scope="col" colspan="16">
                                    员工履历列表
                                </th>
                            </tr>--%>
                            <tr class="text-c">
                               
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                   执照文件号码
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   执照编号
                                </th>
                                 <th width="90"  style="text-align:center;vertical-align:middle;">
                                   执照颁发日期
                                </th>
                                <%-- <th width="50"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>--%>
                                
                              
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                           <%-- <td>
                                <asp:CheckBox ID="cbx_qxx" runat="server" />
                            </td>--%>
                            <td>
                                  <%#(cpage2-1)*psize2+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("zzwjhm") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("zzbh") %>'></asp:Label>
                            </td>
                              <td>
                                 <asp:Label ID="Label2" runat="server" Text='<%#Eval("bfrq") %>'></asp:Label>
                            </td>
                            
                             <%-- <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>--%>
                             
                     
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        <br />
          <strong class="icon-reorder">签注资质列表</strong><asp:Repeater ID="Repeater3" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                          <%--  <tr>
                                <th scope="col" colspan="16">
                                    员工履历列表
                                </th>
                            </tr>--%>
                            <tr class="text-c">
                               
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                   签注专业
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   签注类别
                                </th>
                               <th width="60"  style="text-align:center;vertical-align:middle;">
                                   签注项
                                </th>
                                  <th width="60"  style="text-align:center;vertical-align:middle;">
                                   签注有效期
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   签注地
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   异地签注
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   异地签注项
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   异地签注有效期
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   异地签注地
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   体检等级
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   体检有效期
                                </th>
                                <%-- <th width="50"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>--%>
                                
                              
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                           <%-- <td>
                                <asp:CheckBox ID="cbx_qxx" runat="server" />
                            </td>--%>
                            <td>
                                  <%#(cpage3-1)*psize3+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("qzzymc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("qzlbmc") %>'></asp:Label>
                            </td>
                              <td>
                                 <asp:Label ID="Label3" runat="server" Text='<%#Eval("qzxmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label4" runat="server" Text='<%#Eval("qzyxqmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label5" runat="server" Text='<%#Eval("qzd") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label6" runat="server" Text='<%#Eval("ydqzmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label7" runat="server" Text='<%#Eval("ydqzxmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label8" runat="server" Text='<%#Eval("ydqzyxqmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label9" runat="server" Text='<%#Eval("ydqzd") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label10" runat="server" Text='<%#Eval("tjdjmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label11" runat="server" Text='<%#Eval("tjyxqmc") %>'></asp:Label>
                            </td>
                            <%--  <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>--%>
                             
                      
                       
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
	<div style="text-align:center">
		<div>
		      
              &nbsp;  
              <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="199px"  onclick="btn_fh_Click"></asp:Button>  
		</div>
	</div>
        
	</form>
</article>
  
    <script type="text/javascript" src="../../Content/js/H-ui.js"></script>

    <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
    


</body>


</html>
