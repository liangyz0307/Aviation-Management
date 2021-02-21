<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YHGL.aspx.cs" Inherits="CUST.WKG.YHGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
  
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
 </head>
<body>
     <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div >
         <table><tr>
           <td style="width:5%; "></td><td style="width:18%; " align="right">
             用户编号：
             <asp:TextBox ID="tbx_bh" runat="server" style="width:100px;height:24px;"></asp:TextBox></td>
           <td style="width:15%; " align="right">
            姓名：
             <asp:TextBox ID="tbx_xm" runat="server" style="width:100px;height:24px;"></asp:TextBox></td>
           <td style="width:20%; " align="right">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                      部门代码：
              <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 150px" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged"  AutoPostBack="true">
            </asp:DropDownList>
                       </ContentTemplate>
               </asp:UpdatePanel>
               </td>
           <td style="width:18%; " align="right">
             
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate>
                      岗位代码：
              <asp:DropDownList ID="ddlt_gwdm" runat="server" class="select-box" Style="width: 120px"  AutoPostBack="true">
            </asp:DropDownList>
                        </ContentTemplate>
               </asp:UpdatePanel>
               </td>
            <td  align="center"><asp:Button ID="btn_select" runat="server" class="btn  radius"  Text="查询" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_select_Click" />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7"/></td>
           
               </tr></table> 
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    用户列表
                                </th>
                            </tr>
                            <tr class="text-c">
                              
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                    用户编号
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    姓名
                                </th>
                                  <th width="80"  style="text-align:center;vertical-align:middle;">
                                    部门
                                </th>
                               
                                <th width="80">
                                    岗位
                                </th>
                                <th width="100">
                                    操作
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <%--<td>
                                <asp:CheckBox ID="cbx_qxx" runat="server" />
                            </td>--%>
                            <td>
                                  <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                              <%--  <%#Container.ItemIndex + 1%>--%>
                            </td>
                            <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("bh") %>'></asp:Label>
                            </td>
                            <td>
                              <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"  Font-Underline="true"      NavigateUrl='<%#"../HouTai/YH_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("XM") %>'></asp:HyperLink> 
 
                            </td>
                             <td>
                                 
                                <asp:Label ID="lbl_bm" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                            
                             <td>
                                <asp:Label ID="lbl_gw" runat="server" Text='<%#Eval("gw") %>'></asp:Label>
                            </td>
                      
                           <td class="td-manage">
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")%>' ForeColor="Blue"  Font-Underline="false"  runat="server"> 编辑</asp:LinkButton>
                               <asp:HyperLink ID="hl_yhpz" runat="server" ForeColor="Blue"  NavigateUrl='<%#"YH_JSPZ.aspx?id="+Eval("id")+"&bh="+Eval("bh")%>' Text="角色配置"></asp:HyperLink> 
                               &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' ForeColor="Blue"  Font-Underline="false" 
                                    runat="server" OnClientClick="return confirm('您确定要删除该用户信息？')">删除</asp:LinkButton>
                                <asp:LinkButton ID="lbtnKjrk" CommandName="KJRK" CommandArgument='<%#Eval("bh") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >分配快捷入口</asp:LinkButton>
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

  
    <script type="text/javascript" src="../../Content/css/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../../Content/css/h-ui.admin/js/H-ui.admin.js"></script>

   

    </form>
</body>
</html>
