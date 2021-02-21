<%@ Page Title="" Language="C#" MasterPageFile="Sys.Master" AutoEventWireup="true" CodeBehind="MHLL_GL.aspx.cs" Inherits="CUST.WKG.main.MHLL_GL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title></title>
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>

    <script type="text/javascript" src="../lib/respond.min.js"></script>

    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="kg_content" runat="server" >
    <asp:Repeater ID="Repeater1" runat="server" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="margin-top:30px">
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
                                 <th width="70"  style="text-align:center;vertical-align:middle;">
                                    工作地点
                                </th>
                                 <th width="70"  style="text-align:center;vertical-align:middle;">
                                    工作单位
                                </th>
                                  <th width="70"  style="text-align:center;vertical-align:middle;">
                                    起止日期
                                </th>
                                 <th width="70"  style="text-align:center;vertical-align:middle;">
                                    截止日期
                                </th>
                             
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                          
                            <td>
                                 <asp:Label ID="Label3" runat="server" Text='<%#Eval("num") %>'></asp:Label>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("ygbh") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"  Font-Underline="true"        NavigateUrl='<%#"../main/MHLL_Edit.aspx?id=" + Eval("id")%>' Text='<%# Eval("XM") %>'></asp:HyperLink> 
                            </td>
                             
                             <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("gzdw") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("gzbm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_gzdd" runat="server" Text='<%#Eval("gzgw") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_gzdw" runat="server" Text='<%#Eval("gzdd") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("qzrq") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("jzrq") %>'></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
</asp:Content>
