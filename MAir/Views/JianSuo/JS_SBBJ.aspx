﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_SBBJ.aspx.cs" Inherits="CUST.WKG.JS_SBBJ" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
      <%--  <div class="page-container">--%>
            <div class="text-c">
                备件编号：
             <asp:TextBox ID="tbx_sbbh" runat="server" Style="width: 80px;height:26px" MaxLength="12"></asp:TextBox>
                备件名称：
               <asp:TextBox ID="tbx_sbmc" runat="server" Style="width: 80px;height:26px" MaxLength="50"></asp:TextBox>

               设备型号：
                   <asp:TextBox ID="tbx_sbxh" runat="server" Style="width: 80px;height:26px" MaxLength="10"></asp:TextBox>
                 备件分类：
               <asp:DropDownList ID="ddlt_bjfl" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>

            <td style="width:4%; " align="left">
                   状态：
             <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px; height: 28px;" >
            </asp:DropDownList></td>
                <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"   BackColor="#60B1D7" ForeColor="White"   OnClick="btn_select_Click" />
           
            </div>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">备件列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="40" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件编号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件名称
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">设备型号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件分类
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">板件中文名称
                                      </th>
                                  <th width="80" style="text-align: center; vertical-align: middle;">状态
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
                          <asp:HyperLink ID="hlnk_bjbh" runat="server"    ForeColor="Blue"  style="TEXT-DECORATION:underline"      NavigateUrl='<%#"JS_BJDetail.aspx?id=" + Eval("id")%>' Text='<%# Eval("BJBH") %>'></asp:HyperLink> 
                              </td>
                                  <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("BJMC") %>'></asp:Label>
                                </td>
                             
                                <td>
                                    <asp:Label ID="lbl_sbxh" runat="server" Text='<%#Eval("SBXH") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bjfl" runat="server" Text='<%#Eval("bjflmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_xb" runat="server" Text='<%#Eval("BJZWMC") %>'></asp:Label>
                                </td>
                            <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_byyx" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
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
      <%--  </div>--%>
        <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
        <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>
    </form>
</body>
</html>
