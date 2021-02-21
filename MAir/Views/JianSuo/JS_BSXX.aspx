<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_BSXX.aspx.cs" Inherits="CUST.WKG.JS_BSXX" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>
<%--<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>报送信息设备管理</title>
    
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
        <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"  />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div >
        <div class="text-c">
            报送类型：
           <asp:DropDownList ID="ddlt_bslx" runat="server" class="select-box" Style="width: 140px">
            </asp:DropDownList>
              报送岗位：
            <asp:DropDownList ID="ddlt_bsgw" runat="server" class="select-box" Style="width: 140px" AutoPostBack="True" >
            </asp:DropDownList>
            报送员工：
             <asp:TextBox ID="tbx_bsyg" runat="server"  class="Wdate"    Height="20px" ></asp:TextBox>
            报送时间：
                  <asp:TextBox ID="tbx_bssj" runat="server"  class="Wdate"    Height="20px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
              —<asp:TextBox ID="tbx_jssj" runat="server"  class="Wdate"    Height="20px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click"
               />
           
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    报送系统检索
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="30"  style="text-align:left;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    报送编号
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    报送类型
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    报送员工
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    报送岗位
                                </th>
                                 <th width="80"  style="text-align:center;vertical-align:middle;">
                                    报送时间
                                </th>
                              
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    审批人
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
                                  <asp:HyperLink ID="hpl_sbbh" runat="server" ForeColor="#60B1D7"   style="TEXT-DECORATION:underline"  NavigateUrl='<%#"JS_BSDetail.aspx?bsbh="+Eval("bsbh")+"&bslx="+Eval("bslx")%>'  Text='<%#Eval("bsbh") %>'></asp:HyperLink> 
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("bslx_mc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label runat="server" Text='<%#Eval("bsygxm") %>'></asp:Label>
                            </td>
                         
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("bsgw_mc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("bssjmc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("sprxm") %>'></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
    <script type="text/javascript" src="../src/jquery-1.11.2.js"></script>  
    <script type="text/javascript" src="../src/query.js"></script>  
    <script type="text/javascript" src="../src/paging.js"></script>   
    <script type="text/javascript" src="../src/require.js"></script>
             <table>
                <tr>
                    <td align="center" width="100%" >
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
             <%--  <div id="pageTool"></div>
		<div id="pageToolbar"></div>
		<script>
		    $('#pageTool').Paging(
            {
                pagesize:<%=cpage%>, count: <%=psize%>, callback: function (page, size, count)
                {
		        	console.log(arguments)
		        	alert('当前第 ' +page +'页,每页 '+size+'条,总页数：'+count+'页')
                }
            });
		$('#pageToolbar').Paging({pagesize:<%=cpage%>,count:<%=psize%>,toolbar:true});
		</script>
           --%>
        </div>
    </div>

 
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
          <script src="../css/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
  
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>

</form>
</body>
</html>
