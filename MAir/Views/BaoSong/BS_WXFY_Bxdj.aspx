<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_WXFY_Bxdj.aspx.cs" Inherits="CUST.WKG.BS_WXFY_Bxdj" %>
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
            td.td_sjsclbt_tj
            {
                background:#F6FAFD;
              
            }    
    </style>
</head>
<body>
    <article class="page-container">
	<form id="Form1" runat="server" class="form form-horizontal">
	 <div class="panel-head" style="text-align:center">
            <strong class="icon-reorder">报销登记</strong>
           
  </div>
       <br />
       <strong class="icon-reorder">报销登记</strong><asp:Button ID="btn_add_bxdj"  runat="server"  class="btn  radius"  Text="添加"  ForeColor="White" BackColor="#60B1D7" OnClick="btn_add_bxdj_click"/>

        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr class="text-c">
                               
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                   项目名称
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   总计
                                </th>                             
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    实际预算执行机场
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    登记日期
                                </th>
                                
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    操作
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
                                <asp:Label ID="lbl_xmmc" runat="server" Text='<%#Eval("xmmcmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_zj" runat="server" Text='<%#Eval("zj") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_sjzxjc" runat="server" Text='<%#Eval("sjyszxjcmc") %>'></asp:Label>
                            </td>                             
                             <td>
                                <asp:Label ID="lbl_djrq" runat="server" Text='<%#Eval("djrqmc") %>'></asp:Label>
                            </td> 
                                            
                       <td class="td-manage">
                             
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("xmmc")+"&"+ Eval("zt") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该报销登记吗？')">删除</asp:LinkButton>
                            </td>                       
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        <br />
         <strong class="icon-reorder">报销明细</strong><asp:Button ID="btn_add_bxdj_mx"  runat="server"  class="btn  radius"  Text="添加"  ForeColor="White" BackColor="#60B1D7" OnClick="btn_add_bxdj_mx_click"/>
        <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand" OnItemDataBound="Repeater2_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr class="text-c">                              
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                   人工费明细
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                   人工费数量
                                </th>
                                 <th width="90"  style="text-align:center;vertical-align:middle;">
                                   人工费(不含税)
                                </th>
                                 <th width="80"  style="text-align:center;vertical-align:middle;">
                                    人工费(含税)
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                   配件名称
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                   配件数量
                                </th>
                                 <th width="80"  style="text-align:center;vertical-align:middle;">
                                   配件费用(不含税)
                                </th>
                                 <th width="80"  style="text-align:center;vertical-align:middle;">
                                    配件费用(含税)
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    操作
                                </th>
                              
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                  <%#(cpage2-1)*psize2+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_rgfmx" runat="server" Text='<%#Eval("rgfmx") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_rgfsl" runat="server" Text='<%#Eval("rgfsl") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_rgfbhs" runat="server" Text='<%#Eval("rgfbhs") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_rgfhs" runat="server" Text='<%#Eval("rgfhs") %>'></asp:Label>
                            </td>  
                            <td>
                                 <asp:Label ID="lbl_pjmc" runat="server" Text='<%#Eval("pjmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="lbl_pjsl" runat="server" Text='<%#Eval("pjsl") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_pjfybhs" runat="server" Text='<%#Eval("pjfybhs") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_pjfyhs" runat="server" Text='<%#Eval("pjfyhs") %>'></asp:Label>
                            </td>                            
                       <td class="td-manage">
                                
                                <asp:LinkButton ID="lbtDelete2" CommandName="Delete" CommandArgument='<%#Eval("mxbh")+"&"+ Eval("zt") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该明细费用？')">删除</asp:LinkButton>
                            </td>                       
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