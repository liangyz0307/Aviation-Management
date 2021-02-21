<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_YS.aspx.cs" Inherits="CUST.WKG.BS_YS" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>航班运行报送</title>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div class="text-c"   style="text-align: center; width: 100%; margin: 0 auto;">
           报送编号：
             <asp:TextBox ID="tbx_bsbh" runat="server" style="width:100px;"></asp:TextBox>
            报送员工编号：
             <asp:TextBox ID="tbx_bsygbh" runat="server" style="width:100px;"></asp:TextBox>
            报送员工姓名：
            <asp:TextBox ID="tbx_bsygxm" runat="server" style="width:130px;" ></asp:TextBox>
          <%--  报送类型：
              <asp:DropDownList ID="ddlt_bslx" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>  --%>
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click"
                />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" BackColor="#60B1D7" ForeColor="White" Visible="true" OnClick="btn_add_Click" />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="21">
                                    预算
                                </th>
                            </tr>
                            <tr>
                                <th width="30"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="80"   style="text-align:center;vertical-align:middle;">
                                    员工编号
                                </th>
                                <th width="80"   style="text-align:center;vertical-align:middle;">
                                    员工姓名
                                </th>
                               <%--   <th width="80"  style="text-align:left;">
                                    岗位
                                </th>
                                <th width="80"  style="text-align:left;">
                                    部门
                                </th>


                                 <th width="80"  style="text-align:left;">
                                    报送编号
                                </th>
                                 <th width="80"  style="text-align:left;">
                                    报送员工
                                </th>
                              
                                <th width="80"  style="text-align:left;">
                                    报送岗位
                                </th>--%>
                                <th width="80"   style="text-align:center;vertical-align:middle;">
                                    报送类型
                                </th>
                               <%--  <th width="80"  style="text-align:left;">
                                    报送IP
                                </th>
                              --%>

                                <%--<th width="80"  style="text-align:left;">
                                    报送时间
                                </th>--%>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    申请部门
                                </th>
                                <th width="80"   style="text-align:center;vertical-align:middle;">
                                   预算总额
                                </th>
                                 <th width="80"  style="text-align:center;vertical-align:middle;">
                                    预算用途
                                </th>
                              
                                <th width="80"   style="text-align:center;vertical-align:middle;">
                                    预算来源
                                </th>



                                  <th width="80"   style="text-align:center;vertical-align:middle;">
                                    应用年限
                                </th>
                                <th width="80"   style="text-align:center;vertical-align:middle;">
                                   审批人
                                </th>
                                 <th width="100"   style="text-align:center;vertical-align:middle;">
                                   状态
                                </th>
                             <%--   <th width="100"  style="text-align:left;">
                                   备注
                                </th>--%>
                                <th width="80">
                                    操作
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                           
                            <td>
                                  <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                            
                            </td>
                            <%--<td>
                                  <asp:HyperLink ID="bsbh" runat="server" ForeColor="#60B1D7"   style="TEXT-DECORATION:underline"  NavigateUrl='<%#"ZXTZBS_Detail.aspx?sbbh="+Eval("bsbh")%>'  Text='<%#Eval("bsbh") %>'></asp:HyperLink> 
                            </td>--%>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("bh") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"  Font-Underline="true"        NavigateUrl='<%#"../BaoSong/BS_YS_Edit.aspx?bsbh=" + Eval("bsbh")%>' Text='<%# Eval("xm") %>'></asp:HyperLink> 
                            </td>
                           <%--  <td>
                                <asp:Label runat="server" Text='<%#Eval("gw") %>'></asp:Label>
                            </td>
                         
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                             <td>

                                <asp:Label  runat="server" Text='<%#Eval("bsbh") %>'></asp:Label>
                            </td>



                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("bsyg") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("bsgwmc") %>'></asp:Label>
                            </td>
                         --%>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("bslxmc") %>'></asp:Label>
                            </td>
                            <%-- <td>
                                <asp:Label  runat="server" Text='<%#Eval("bsip") %>'></asp:Label>
                            </td>--%>


                          <%--    <td>
                                <asp:Label  runat="server" Text='<%#Eval("bssjlx") %>'></asp:Label>
                            </td>--%>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("sqbmmc") %>'></asp:Label>
                            </td>

                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("ysze") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("ysyt") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("ysly") %>'></asp:Label>
                            </td>


                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("yynx") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("spr") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                            <%--  <td>
                                <asp:Label  runat="server" Text='<%#Eval("bz") %>'></asp:Label>
                            </td>--%>
                                                                   <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("bsbh")+"&"+ Eval("zt") %>' ForeColor="#60B1D7"  style="text-decoration:underline"
                                    runat="server" >提交</asp:LinkButton>
                               <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("bsbh")+"&"+ Eval("zt") %>' ForeColor="#60B1D7"  style="text-decoration:underline"
                                    runat="server" >审核</asp:LinkButton>
                               <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("bsbh")+"&"+ Eval("zt") %>' ForeColor="#60B1D7"  style="text-decoration:underline"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                               <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("bsbh")+"&"+ Eval("zt") %>' ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClientClick="return confirm('您确定要修改该信息？')">修改</asp:LinkButton>

                                    <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("bsbh")+"&"+ Eval("zt") %>' ForeColor="#60B1D7" Style="text-decoration: underline"
                                        runat="server" OnClientClick="return confirm('您确定要删除该条信息？')">删除</asp:LinkButton>
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
    </form>
</body>
</html>