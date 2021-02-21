<%@ Page Title="" Language="C#" MasterPageFile="Sys.Master" AutoEventWireup="true" CodeBehind="MHZYBS_GL.aspx.cs" Inherits="CUST.WKG.main.MHZYBS_GL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>自愿报送</title>
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
<asp:Content ID="Content2" ContentPlaceHolderID="kg_content" runat="server">
     <form  runat="server">
    <%--<asp:Button ID="btn_add" runat="server" class="btn radius" Text="自愿报送" BackColor="#60B1D7" ForeColor="White" OnClick="btn_add_Click"  />--%>
     <asp:Repeater ID="rpt_zybs" runat="server">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort" style="margin-top:30px">
                            <thead>
                                <tr>
                                 
                                    <th scope="col" colspan="16">自愿报送
                                    </th>
                                </tr>
                                <tr>
                                    <th width="30" style="text-align: left;">序号
                                    </th>
                                    <th width="80" style="text-align: left;">报送编号
                                    </th>
                                    <th width="100" style="text-align: left;">报送员工姓名
                                    </th>
                                    <th width="70" style="text-align: left;">报送类型
                                    </th>
                                    <th width="60" style="text-align: left;">报送时间
                                    </th>
                                     <th width="80" style="text-align: left;">审批人姓名
                                    </th>
                                     <th width="100" style="text-align: left;">状态
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>

                                <td>
                                 <asp:Label runat="server" Text='<%#Eval("num") %>'></asp:Label>
                            
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("bsbh") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:HyperLink ID="hlnk_bsygxm" runat="server" ForeColor="#60B1D7" Style="text-decoration: underline" NavigateUrl='<%#"MHZYBS_Edit.aspx?bsbh=" + Eval("bsbh")%>' Text='<%# Eval("xm") %>'></asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("bslxmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("bssjgs") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("sprxm") %>'></asp:Label>
                                </td>

                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                                </td>
                               
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
        
         </form>
</asp:Content>

