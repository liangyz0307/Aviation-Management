<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SKJS_WXY.aspx.cs" Inherits="CUST.WKG.SKJS_WXY" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>三库建设危险源</title>
       <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div class="text-c"   style="text-align: center; width: 100%; margin: 0 auto;">
         
            危险源名称：
             <asp:TextBox ID="tbx_mc" runat="server" Width="123px" OnTextChanged="tbx_bsygbh_TextChanged"></asp:TextBox>
            岗位：
            <asp:DropDownList ID="ddlt_gw" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList> 
            状态：
            <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px"></asp:DropDownList>
            控制状态：
              <asp:DropDownList ID="ddlt_kzzt" runat="server" class="select-box" Style="width: 80px">
            </asp:DropDownList> 
             <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click"   />
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" BackColor="#60B1D7" ForeColor="White" Visible="true" OnClick="btn_add_Click" />
         
             
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="27">
                                   风险源分析
                                </th>
                            </tr>
                            <tr>
                                <th width="30"   style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="100"  style="text-align:center;vertical-align:middle;">
                                    危险源名称
                                </th>
                                <th width="70"   style="text-align:center;vertical-align:middle;">
                                    岗位
                                </th>
                                <th width="50"   style="text-align:center;vertical-align:middle;">
                                    时态
                                </th>

                                <th width="80"   style="text-align:center;vertical-align:middle;">
                                    发生的可能性
                                </th>
                                <th width="80"   style="text-align:center;vertical-align:middle;">
                                   控制状态
                                </th>
                                                                                                  </th>
                                  <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                </th>
                                  <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th> 
                               <th width="50"   style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                                <th width="80">
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
                                <asp:HyperLink ID="hlnk_xm" runat="server" ForeColor="Blue"  Font-Underline="true"        NavigateUrl='<%#"../SKJS/SKJS_WXY_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("mc") %>'></asp:HyperLink> 
                            </td>
                         
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("gwmc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("stmc") %>'></asp:Label>
                            </td>

                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("knxmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("kzztmc") %>'></asp:Label>
                            </td>
                               <td>
                                 <asp:Label ID="lbl_fzr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>  
                             </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                                <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="#60B1D7" Style="text-decoration: underline"
                                    runat="server">提交</asp:LinkButton>
                                <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="#60B1D7" Style="text-decoration: underline"
                                    runat="server">审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="#60B1D7" Style="text-decoration: underline"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs" )%>' ForeColor="#60B1D7" Style="text-decoration: underline"
                                    runat="server" OnClientClick="return confirm('您确定要编辑该信息？')">编辑</asp:LinkButton>
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="#60B1D7" Style="text-decoration: underline"
                                    runat="server" OnClientClick="return confirm('您确定要删除该信息？')">删除</asp:LinkButton>
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
                    <td align="center" width="98%" >
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged"  />
                    </td>
                </tr>
            </table>
        </div>
    </div>
                <asp:HiddenField ID="HF_yc" runat="server" />
        <script type="text/javascript" src="../css/js/jquery.js"></script>
        <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
        <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
    </form>
</body>
</html>
