<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LLGL.aspx.cs" Inherits="CUST.WKG.LLGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
   
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
   
</head>
<body>
     <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
  <%--  <nav class="breadcrumb"> <span class="c-gray en">&gt;</span> 员工信息管理 <span class="c-gray en">&gt;</span> 员工信息
        </nav>--%>
    <div >
         <table><tr>
           <td style="width:15%; "></td><td style="width:15%; " align="right">
             员工编号：
             <asp:TextBox ID="tbx_bh" runat="server" style="width:80px; height:24px;"></asp:TextBox></td>
           <td style="width:12%; " align="right">
            姓名：
             <asp:TextBox ID="tbx_xm" runat="server" style="width:80px;height:24px;"></asp:TextBox></td>
           <td style="width:20%; " align="right">
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                      部门：
              <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 150px" AutoPostBack="true" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged"  >
            </asp:DropDownList>
                    </ContentTemplate>
               </asp:UpdatePanel>       
               </td>
           <td style="width:18%; " align="right">
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate>
            
                      岗位：
              <asp:DropDownList ID="ddlt_gwdm" runat="server" class="select-box" Style="width: 120px" AutoPostBack="true">
            </asp:DropDownList>
                  </ContentTemplate>
               </asp:UpdatePanel>    
               </td>
            <td  align="center">
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_select_Click" />
            &nbsp;
<%--             <asp:Button ID="btn_gjjs" runat="server" class="btn  radius" Text="高级检索"  ForeColor="White" BackColor="#60B1D7" OnClick="btn_gjjs_Click"/>--%>
                  </td></tr></table> 
         
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    员工履历列表
                                </th>
                            </tr>
                            <tr class="text-c">
                         
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                    员工编号
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    姓名
                                </th>
                                  
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    部门
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
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
                         
                            <td>
                                  <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("BH") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"  Font-Underline="true"        NavigateUrl='<%#"LL_Detail.aspx?ygbh=" + Eval("bh")%>' Text='<%# Eval("XM") %>'></asp:HyperLink> 
                            </td>
                             
                             <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("gw") %>'></asp:Label>
                            </td>
                         <%--   <td>
                                <asp:Label ID="lbl_gzdd" runat="server" Text='<%#Eval("gzdd") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_gzdw" runat="server" Text='<%#Eval("gzdw") %>'></asp:Label>
                            </td>--%>
                            
                            
                             
                      
                            <td class="td-manage">
                               
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("bh")+"&"+ Eval("bmdm") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >履历管理</asp:LinkButton>
                                &nbsp;
                              <%--  <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("bh") %>' ForeColor="Blue" Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该员工履历信息？')">删除</asp:LinkButton>--%>
                              <%--  &nbsp;
                                <asp:LinkButton ID="lbtTjtz" CommandName="EditZT" CommandArgument='<%#Eval("id") %>'
                                    runat="server" OnClientClick="return confirm('您确定要提交该员工信息，提交之后将不可更改？')"><i class="Hui-iconfont">&#xe631;</i>提交</asp:LinkButton>--%>
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
                    <td align="center" width="100%">
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

  

    <script type="text/javascript" src="../../Content/js/H-ui.js"></script>

    <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>

   

    </form>
</body>
</html>
