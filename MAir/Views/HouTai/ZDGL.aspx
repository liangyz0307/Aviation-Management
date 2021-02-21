<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZDGL.aspx.cs" Inherits="CUST.WKG.ZDGL" %>

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
  
    <div >
        <div class="text-c">
            字典项：
              <asp:DropDownList ID="ddlt_zdm" runat="server" class="select-box" Style="width: 180px; ">
            </asp:DropDownList>
            编码：
              <asp:TextBox ID="tbx_bm" runat="server" style="width:80px;height:20px;"></asp:TextBox>
             名称：
              <asp:TextBox ID="tbx_mc" runat="server" style="width:80px;height:20px;"></asp:TextBox>
             
            <asp:Button ID="btn_select" runat="server" class="btn  radius"  Text="查询" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_select_Click" />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7"/>
        </div>
          
        <div class="mt-20">
             <table >

            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table  class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    字典列表
                                </th>
                            </tr>
                            <tr class="text-c">
                              
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="20%"  style="text-align:center;vertical-align:middle;">
                                    字典项
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    编码
                                </th>
                                  <th width="20%"  style="text-align:center;vertical-align:middle;">
                                    名称
                                </th>
                               
                                <th width="45%">
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
                                <asp:Label ID="lbl_zdm" runat="server" vertical-align="left"  alight="left" Text='<%#Eval("zdm_mc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_bm" runat="server" Text='<%#Eval("BM") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("ZDM")+"&"+Eval("BM") +"&"+Eval("MC") +"&"+Eval("ZDM_MC")%>' ForeColor="Blue"  Font-Underline="true" 
                                    runat="server" > <asp:Label ID="lbl_mc" runat="server" Text='<%#Eval("MC") %>'></asp:Label></asp:LinkButton>
                               
                            </td>
                            
                           
                      
                           <td class="td-manage">
                                <%--<asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("ZDM")+"&"+Eval("BM") +"&"+Eval("MC") +"&"+Eval("ZDM_MC")%>' ForeColor="Blue"  Font-Underline="true" 
                                    runat="server" >编辑</asp:LinkButton>--%>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("ZDM")+"&"+Eval("BM") %>' ForeColor="Blue"  Font-Underline="true" 
                                    runat="server" OnClientClick="return confirm('您确定要删除该字典信息？')">删除</asp:LinkButton>
                              
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
                 
        </table>
            <table>
                <tr>
                    <td align="center" width="100%">
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
