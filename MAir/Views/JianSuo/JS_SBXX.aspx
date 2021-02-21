<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_SBXX.aspx.cs" Inherits="CUST.WKG.JS_SBXX" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>设备信息设备管理</title>
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
        <div class="text-c" id="sblx" runat ="server">
              设备类型：
           <asp:DropDownList ID="ddlt_sblx" runat="server" class="select-box" Style="width: 100px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_sblx_SelectedIndexChanged">
            </asp:DropDownList>
            设备种类：
              <asp:DropDownList ID="ddlt_sbzl" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>  
            所属台站名称：
             <asp:DropDownList ID="ddlt_sstzmc" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
              设备编号：
             <asp:TextBox ID="tbx_sbbh" runat="server" style="width:100px;height:25px;"></asp:TextBox>
           
            <asp:Button ID="btn_cx" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_cx_Click"/>         
        </div>
          <div class="mt-20" id="dhsb"  runat ="server">
              <asp:Repeater ID="rpt_sb" runat="server">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    设备列表
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="30"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    设备编号
                                </th>
                                <th width="70"  style="text-align:center;vertical-align:middle;">
                                    设备类型
                                </th>
                                  <th width="90"  style="text-align:center;vertical-align:middle;">
                                    设备种类
                                </th>
                                <th width="120"  style="text-align:center;vertical-align:middle;">
                                    所属台站名称
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    数量
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
                                  <asp:HyperLink ID="hpl_sbbh" runat="server" ForeColor="#60B1D7"   style="TEXT-DECORATION:underline"  NavigateUrl='<%#"JS_SBDetail.aspx?sbbh="+Eval("sbbh")+"&sblx="+Eval("sblx")%>'  Text='<%#Eval("sbbh") %>'></asp:HyperLink> 
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("sblx") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label runat="server" Text='<%#Eval("sbzlmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("sstz_mc") %>'></asp:Label>
                            </td>
                           </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("sl") %>'></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
               
          </div>
          <div class="mt-20" id="txsb" runat ="server">
           
               <table>
                <tr>
                    <td align="center" width="100%" >
                            <cc1:pager ID="pg_fy" runat="server" Width="98%"  OnPageChanged="pg_fy_PageChanged" />
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
