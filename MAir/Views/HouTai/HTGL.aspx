<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HTGL.aspx.cs" Inherits="CUST.WKG.HTGL" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>合同管理</title> 
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
             合同名称：
             <asp:TextBox ID="tbx_htmc" runat="server"  class="Wdate"  Width="80px"   Height="20px" ></asp:TextBox>
             签订方：
             <asp:TextBox ID="tbx_qdf" runat="server"  class="Wdate"  Width="80px"   Height="20px" ></asp:TextBox>
             负责人：
             <asp:TextBox ID="tbx_fzr" runat="server"  class="Wdate" Width="60px"    Height="20px" ></asp:TextBox>
              状态：
            <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width:70px" AutoPostBack="True" >
            </asp:DropDownList>
            期限：
                  <asp:TextBox ID="tbx_qxkssj" runat="server"  class="Wdate" Width="70px"    Height="20px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
              —<asp:TextBox ID="tbx_qxjssj" runat="server"  class="Wdate"  Width="70px"   Height="20px"  onclick="lhgcalendar({format:'yyyy-MM-dd '})"></asp:TextBox>

            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click"  />
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
                                    合同列表
                                </th>
                            </tr>
                            <tr class="text-c">                             
                                <th width="30"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                    合同名称
                                </th>                                
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                    签订方
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    负责人
                                </th>
                                <th width="70"  style="text-align:center;vertical-align:middle;">
                                    总额（万元）
                                </th>
                                  <th width="60"  style="text-align:center;vertical-align:middle;">
                                    签订日期
                                </th>                              
                                <th width="100">
                                    期限
                                </th>
                                <th width="40">
                                    状态
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
                                <asp:LinkButton ID="lbtnDetail" CommandName="Detail" CommandArgument='<%#Eval("id")%>' ForeColor="Blue"  Font-Underline="true"  runat="server">                                                           
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("htmc") %>'></asp:Label></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lbl_xm" runat="server" Text='<%#Eval("qdf") %>'></asp:Label>
                            </td>
                             <td>  
                                <asp:Label ID="lbl_bm" runat="server" Text='<%#Eval("fzr") %>'></asp:Label>
                            </td>
                             <td>                                 
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("ze") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_gw" runat="server" Text='<%#Eval("qdsj") %>'></asp:Label>
                            </td>
                            <td>                                 
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("kssj") %>'></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("jssj") %>'></asp:Label>
                            </td>                           
                             <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                           <td class="td-manage">
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' ForeColor="Blue"  Font-Underline="true" 
                                    runat="server" OnClientClick="return confirm('您确定要删除该用户信息？')">删除</asp:LinkButton>
                            <%--   <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id") %>' ForeColor="Blue"  Font-Underline="true" 
                                    runat="server" >编辑</asp:LinkButton>--%>
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
