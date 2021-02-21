<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DQZC_DYGL.aspx.cs" Inherits="CUST.WKG.MenHu.main.DQZC_DYGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>党员管理</title>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div >
        <div>
                姓名：
            <asp:TextBox ID="tbx_xm" runat="server"  class="Wdate"  Width="40px"   Height="20px" ></asp:TextBox>
              身份证号：
            <asp:TextBox ID="tbx_sfzh" runat="server"  class="Wdate"    Height="30px" ></asp:TextBox>
             <td style="width:4%; " align="left">部门：
             <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 100px; height: 28px;">
            </asp:DropDownList></td>
               党内职务：
           <asp:TextBox ID="tbx_dnzw" runat="server" Style="width: 90px"   class="Wdate"    Height="20px" ></asp:TextBox>            
                基础党支部名称：
            <asp:DropDownList ID="ddlt_jcdzbmc" runat="server" class="select-box" Style="width: 90px" AutoPostBack="True" >
            </asp:DropDownList>
               党小组名称：
            <asp:DropDownList ID="ddlt_dxzmc" runat="server" class="select-box" Style="width:90px" AutoPostBack="True" >
            </asp:DropDownList>
             <td style="width:20%; " align="right">             
                     状态：
              <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px"  AutoPostBack="true">
            </asp:DropDownList>                       
               </td>  
            <%--  用工形式：
              <asp:DropDownList ID="ddlt_ygxs" runat="server" class="select-box" Style="width: 80px" AutoPostBack="True" >
            </asp:DropDownList>--%>
           <td align="right" >
           <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#ab2025" ForeColor="White" OnClick="btn_select_Click"  /> 
             </td>          
            <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加"  BackColor="#ab2025" ForeColor="White" OnClick="btn_add_Click"  />  
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover  table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    党员管理列表
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th style="text-align:center;vertical-align:middle;width:20px">
                                    序号
                                </th>
                                <th style="text-align:center;vertical-align:middle;width:60px">
                                    姓名
                                </th>
                                 <th style="text-align:center;vertical-align:middle;width:60px">
                                    党内职务
                                </th>                              
                                <th style="text-align:center;vertical-align:middle;width:60px">
                                    用工形式
                                </th>
                                 <th style="text-align:center;vertical-align:middle;width:60px">
                                    基础党支部名称
                                </th>
                                 <th style="text-align:center;vertical-align:middle;width:70px">
                                    党小组名称
                                </th>                              
                                <th style="text-align:center;vertical-align:middle;width:40px">
                                    党总支名称
                                </th>
                                 <th style="text-align:center;vertical-align:middle;width:60px">
                                    状态
                                </th>
                                 <th style="text-align:center;vertical-align:middle;width:60px">
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
                                  <asp:HyperLink ID="hpl_sbbh" runat="server" ForeColor="blue"   style="TEXT-DECORATION:underline"  NavigateUrl='<%#"DQZC_DYDetail.aspx?bh="+Eval("bh")+"&xm="+Eval("xm")%>'  Text='<%#Eval("xm") %>'></asp:HyperLink> 
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("dnzw") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("ygxs_mc")%>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label1"  runat="server" Text='<%#Eval("dzb_mc")%>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label2"  runat="server" Text='<%#Eval("dxz_mc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("dzz_mc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label ID="lbl_zt"  runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                                    <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("bh")+"&"+Eval("xm")%>'  ForeColor="blue"  style="TEXT-DECORATION:underline"
                                        runat="server">编辑</asp:LinkButton>
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("bh") %>'   ForeColor="blue"  style="TEXT-DECORATION:underline"
                                    runat="server" OnClientClick="return confirm('您确定要删除该党员信息？')">删除</asp:LinkButton>
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
                    <td  style="text-align :center;width:100%"  >
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%"  OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
        <%-- <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/css/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../../Content/css/h-ui.admin/js/H-ui.admin.js"></script>--%>
        </form>
</asp:Content>
