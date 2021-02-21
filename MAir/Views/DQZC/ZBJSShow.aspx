<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZBJSShow.aspx.cs" Inherits="CUST.WKG.ZBJSShow" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title></title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>

    <style type="text/css">
        .auto-style1 {
            width: 132%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div class="text-c"   style="text-align: center; width: 100%; margin: 0 auto;">
          上传时间：
                <asp:TextBox ID="tbx_kssj" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="开始时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>-<asp:TextBox ID="tbx_jssj" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="截止时间" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox></td>
                    
                
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#ab2025" ForeColor="White" OnClick="btn_select_Click" 
                />
            &nbsp;
            
        
             </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="21">
                                    支部建设
                                </th>
                            </tr>
                            <tr>
                                <th width="10"  style="text-align:center;">
                                    序号
                                </th>
                                 <th width="180"  style="text-align:center;">
                                    文件名
                                </th>
                                <th width="80"  style="text-align:center;">
                                    上传时间
                                </th>
                              <%--  <th width="80"  style="text-align:center;">
                                    上传人
                                </th>                   
                                
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                   状态
                                </th>  
                                <th width="80"  style="text-align:center;"> --%>
                                                
                             </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                               <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                            </td>
                            <td>                                    
                                      <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue" Font-Underline="true" CommandName="down" CommandArgument='<%#Eval("wjm")+"&"+ Eval("sclj") %>' Text='<%# Eval("wjm") %>'></asp:LinkButton>
                                </td>
                           <td>
                                <asp:Label ID="Label2"  runat="server" Text='<%#Eval("scsjmc") %>'></asp:Label>
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
                    <td align="center" class="auto-style1" >
                        <cc1:pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
    </form>
</body>
</html>

