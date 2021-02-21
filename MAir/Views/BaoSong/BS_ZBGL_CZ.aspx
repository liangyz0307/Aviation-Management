<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_ZBGL_CZ.aspx.cs" Inherits="CUST.WKG.BS_ZBGL_CZ" %>

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
            <strong class="icon-reorder">值班人员管理</strong>
      
        
         
       
  </div>
         <strong class="icon-reorder">值班人员信息列表</strong><asp:Button ID="btn_add_zbyg"  runat="server"  class="btn  radius"  Text="添加" OnClick="btn_add_zbyg_Click" ForeColor="White" BackColor="#60B1D7" />
        <br />
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                          
                            <tr class="text-c">
                               
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                
                                 <th width="15%"  style="text-align:center;vertical-align:middle;">
                                   值班岗位
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                   值班员工
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   值班电话
                                </th>
                                
                                 
                                 <th width="20%"  style="text-align:center;vertical-align:middle;">
                                    操作
                                </th>
                              
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
                                  <%#(cpage1-1)*psize1+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_sfpb" runat="server" Text='<%#Eval("zbgwmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_sl" runat="server" Text='<%#Eval("zbygxm") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="lbl_pp" runat="server" Text='<%#Eval("zbdh") %>'></asp:Label>
                            </td>
                            
                             <td>
                                
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("xh") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该值班员工信息？')">删除</asp:LinkButton>
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
        <asp:HiddenField ID="HF_yc" runat="server"/>
	</form>
</article>
  
    <script type="text/javascript" src="../../Content/js/H-ui.js"></script>

    <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
    <script type="text/javascript">

    //单个按钮驳回
    function rec() {
                        var excuse;
                        excuse = prompt("请输入驳回原因：");
                        if (excuse == null)
                        { return false; }
                        else {
                            document.getElementById("<%=HF_yc.ClientID %>").value = excuse;
                        }
                          
    }
            
</script>


</body>


</html>
