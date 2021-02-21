<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_TZXX.aspx.cs" Inherits="CUST.WKG.JS_TZXX" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>台站管理</title>
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
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
             台站名称：
             <asp:TextBox ID="tbx_tzmc" runat="server" Style="width: 80px;height:24px;"></asp:TextBox>
            台站类型：
           <asp:DropDownList ID="ddlt_tzlx" runat="server" class="select-box" Style="width: 140px" AutoPostBack="True" >
            </asp:DropDownList> 
             所属空管局：
           <asp:DropDownList ID="ddlt_ssjgj" runat="server" class="select-box" Style="width: 140px" AutoPostBack="True" >
            </asp:DropDownList>
              申请单位：
           <asp:DropDownList ID="ddlt_sqdw" runat="server" class="select-box" Style="width: 140px" AutoPostBack="True" >
            </asp:DropDownList>
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click"  />
           
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    台账检索
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="30"  style="text-align:left;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    台站编号
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    台站名称
                                </th>
                              
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    台站类型
                                </th>
                                 <th width="80"  style="text-align:center;vertical-align:middle;">
                                    所属监管局
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    申请单位
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    场地及电磁环境符合情况
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr >
                           
                            <td>
                                  <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                            
                            </td>
                            <td>
                                  <asp:HyperLink ID="hpl_sbbh" runat="server" ForeColor="#60B1D7"   style="TEXT-DECORATION:underline"  NavigateUrl='<%#"JS_TZDetail.aspx?tzbh="+Eval("tzbh")%>'  Text='<%#Eval("tzbh") %>'></asp:HyperLink> 
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("tzmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label runat="server" Text='<%#Eval("tzlxmc") %>'></asp:Label>
                            </td>
                         
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("ssjgjmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("sqdwmc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("CDJDCHJFHQKmc") %>'></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <table>
                <tr>
                    <td align="center" width="100%" >
                            <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

 
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
          <script src="../css/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
  
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>

</form>
</body>
</html>
