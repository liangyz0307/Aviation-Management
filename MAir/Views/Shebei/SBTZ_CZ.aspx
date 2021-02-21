<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SBTZ_CZ.aspx.cs" Inherits="CUST.WKG.SBTZ_CZ" %>

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
            <strong class="icon-reorder">设备台站子表管理</strong>
      
        
         
       
  </div>
         <strong class="icon-reorder">空调信息列表</strong><asp:Button ID="btn_add_kt"  runat="server"  class="btn  radius"  Text="添加" OnClick="btn_add_kt_Click" ForeColor="White" BackColor="#60B1D7" />
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
                                   是否匹配
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                   数量
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   品牌
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   安装时间
                                </th>
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   保修年限
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   是否安装紫气装置
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
                                <asp:Label ID="lbl_sfpb" runat="server" Text='<%#Eval("sfjbmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_sl" runat="server" Text='<%#Eval("sl") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="lbl_pp" runat="server" Text='<%#Eval("pp") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="lbl_azsj" runat="server" Text='<%#Eval("azsjmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="lbl_bxnx" runat="server" Text='<%#Eval("bxnx") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_sfazzqzz" runat="server" Text='<%#Eval("sfazzqzzmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("tzbh") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("tzbh") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该空调信息？')">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        <br />

        <strong class="icon-reorder">加湿器信息列表</strong><asp:Button ID="btn_add_jsq"  runat="server"  class="btn  radius"  Text="添加" OnClick="btn_add_jsq_Click" ForeColor="White" BackColor="#60B1D7" />
        <br />
        <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                          
                            <tr class="text-c">
                               
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                
                                 <th width="15%"  style="text-align:center;vertical-align:middle;">
                                   是否匹配
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                   数量
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   品牌
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   安装时间
                                </th>
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   保修年限
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
                                  <%#(cpage2-1)*psize2+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_sfpb" runat="server" Text='<%#Eval("sfjbmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_sl" runat="server" Text='<%#Eval("sl") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="lbl_pp" runat="server" Text='<%#Eval("pp") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="lbl_azsj" runat="server" Text='<%#Eval("azsjmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="lbl_bxnx" runat="server" Text='<%#Eval("bxnx") %>'></asp:Label>
                            </td>
                            
                             <td>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("tzbh") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("tzbh") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该加湿器信息？')">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        <br />

           <strong class="icon-reorder">防火设备信息列表</strong><asp:Button ID="btn_add_fhsb"  runat="server"  class="btn  radius"  Text="添加" OnClick="btn_add_fhsb_Click" ForeColor="White" BackColor="#60B1D7" />
        <br />
        <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="Repeater3_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                          
                            <tr class="text-c">
                               
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                
                                 <th width="15%"  style="text-align:center;vertical-align:middle;">
                                   灭火设备类型
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                   检测到期时间
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   灭火器个数
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
                                  <%#(cpage3-1)*psize3+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_mhsblx" runat="server" Text='<%#Eval("mhsblxmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_jcdqsj" runat="server" Text='<%#Eval("jcdqsjmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="lbl_mhqgs" runat="server" Text='<%#Eval("mhqgs") %>'></asp:Label>
                            </td>
    
                             <td>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("tzbh") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("tzbh") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该防火设备信息？')">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        <br />

         <strong class="icon-reorder">灭鼠及其他措施信息列表</strong><asp:Button ID="btn_add_mscs"  runat="server"  class="btn  radius"  Text="添加" OnClick="btn_add_mscs_Click" ForeColor="White" BackColor="#60B1D7" />
        <br />
        <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="Repeater4_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                          
                            <tr class="text-c">
                               
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   挡鼠板
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   粘鼠板个数
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   防盗措施是否具备
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   防洪措施是否具备
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   维修工具是否满足急修需求
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   机房防雷措施
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   防雷检测到期日期
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   是否有地暖
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
                                  <%#(cpage4-1)*psize4+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_dsb" runat="server" Text='<%#Eval("dsbmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_zsbgs" runat="server" Text='<%#Eval("zsbgs") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="lbl_fd" runat="server" Text='<%#Eval("fdmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_fh" runat="server" Text='<%#Eval("fhmc") %>'></asp:Label>

                            </td>
                            <td>
                                 <asp:Label ID="lbl_wxgj" runat="server" Text='<%#Eval("wxgjmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_jfflcs" runat="server" Text='<%#Eval("jfflcs") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_fljcdqrq" runat="server" Text='<%#Eval("fljcdqrq") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_sfydn" runat="server" Text='<%#Eval("sfydnmc") %>'></asp:Label>
                            </td>
                            
    
                             <td>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("tzbh") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("tzbh") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该灭鼠措施信息？')">删除</asp:LinkButton>
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
