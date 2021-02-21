<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SPRGL.aspx.cs" Inherits="CUST.WKG.SPRGL" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>审批人管理</title> 
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>
    <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    

</head>
<body>
     <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div >
       <div class="text-c">

            子系统:
            <asp:DropDownList ID="ddlt_zxt" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>

 
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click" />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_add_Click"  />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    审批人
                                </th>
                            </tr>
                            <tr class="text-c">                             
                                <th width="30"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                    子系统名称
                                </th>                                
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                    审批人
                                </th>
                                 <th width="60">
                                    操作
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
                                <asp:Label ID="lbl_zxtmc" runat="server" Text='<%#Eval("zxtmc") %>'></asp:Label>
                            </td>
                             <td>  
                                <asp:Label ID="lbl_bm" runat="server" Text='<%#Eval("sprxm") %>'></asp:Label>
                            </td>
                             
                           <td class="td-manage">
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' ForeColor="Blue"  Font-Underline="true" 
                                    runat="server" OnClientClick="return confirm('您确定要删除该用户信息？')">删除</asp:LinkButton>
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
                    <td align="center" width="100%" background="../images/menuFunction.gif">
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    </form>
</body>
</html>
