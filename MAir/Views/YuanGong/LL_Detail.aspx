<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LL_Detail.aspx.cs" Inherits="CUST.WKG.LL_Detail" %>

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
            <strong class="icon-reorder">员工履历详情</strong>
        </div>
  
        <br />
        <asp:Repeater ID="Repeater1" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr class="text-c">
                               
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                   工作单位
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   工作部门
                                </th>
                                  
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                   工作岗位
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    工作地点
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    起止日期
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    截止日期
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                  <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("gzdw") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("gzbm") %>'></asp:Label>
                            </td>
                             
                             <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("gzgw") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("gzdd") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_gzdd" runat="server" Text='<%#Eval("qzrq") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_gzdw" runat="server" Text='<%#Eval("jzrq") %>'></asp:Label>
                            </td>
                          
                      
                       
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        <br />
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
