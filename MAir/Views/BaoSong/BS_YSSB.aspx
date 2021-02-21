<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_YSSB.aspx.cs" Inherits="CUST.WKG.BS_YSSB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>预算申报</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css"
        id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <script src="../css/js/jquery.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="text-c">
            预算类型：
             <asp:DropDownList ID="ddlt_yslx" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
            状态：
            <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
            申报状态：
            <asp:DropDownList ID="ddlt_sbzt" runat="server" CssClass="select-box" Style="width:100px"></asp:DropDownList>
            填报单位：
              <asp:TextBox ID="tbx_tbdw" runat="server" Height="20px"></asp:TextBox>
           
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White"
          OnClick="btn_select_Click"      />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" OnClick="btn_add_Click"  BackColor="#60B1D7" ForeColor="White" />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="rpt_gzjz_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="18">
                                    预算申报
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="30"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="80" style="text-align:center;vertical-align:middle;">
                                    填报单位
                                </th>
                                <th width="80" style="text-align:center;vertical-align:middle;">
                                    预算类型
                                </th>
                                <th width="60" style="text-align:center;vertical-align:middle;">
                                   申报年份 
                                </th>
                                  <th width="60"  style="text-align:center;vertical-align:middle;">
                                    项目名称
                                </th>
                           
                                 <th width="60" style="text-align:center;vertical-align:middle;">
                                    维护单位
                                </th>
                              
                                <th width="100"  style="text-align:center;vertical-align:middle;">
                                    预计金额
                                </th>

                                  <th width="60"  style="text-align:center;vertical-align:middle;">
                                    完成时间
                                </th>
                                  <th width="60" style="text-align:center;vertical-align:middle;">
                                    申报状态
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                </th>
                                  <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                </th> <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th> 
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                                <th width="40">
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
                                <asp:HyperLink ID="hlnk_tbdw" runat="server" ForeColor="Blue" Style="text-decoration: underline" NavigateUrl='<%#"BS_YSSB_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("tbdw") %>'></asp:HyperLink>
                            </td>
                             <td>
                                <asp:Label runat="server" Text='<%#Eval("yslxmc") %>'></asp:Label>
                            </td>
                         
                             <td>
                                <asp:Label  runat="server" Text='<%# Eval("sbnfs") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("xmmc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("whdw") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("yjje") %>'></asp:Label>
                            </td>
                           </td>

                   <td>
                                <asp:Label  runat="server" Text='<%#Eval("wcsjs") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("sbztmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_ztmc" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                                <td class="td-manage">
                               <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("sbzt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  style="text-decoration:underline"
                                    runat="server" >提交</asp:LinkButton>
                               <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("sbzt") +"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue" style="text-decoration:underline"
                                    runat="server" >审核</asp:LinkButton>
                               <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id")+"&"+ Eval("sbzt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue" style="text-decoration:underline"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                               <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("sbzt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue" style="text-decoration:underline"
                                    runat="server" OnClientClick="return confirm('您确定要修改该信息？')">修改</asp:LinkButton>

                                    <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("sbzt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue" Style="text-decoration: underline"
                                        runat="server" OnClientClick="return confirm('您确定要删除该条信息？')">删除</asp:LinkButton>
                                </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
             &thinsp;	
                <br />
            <table style="width: 100%;">
                    <asp:HiddenField ID="HF_yc" runat="server" />
                </table>
              <table>
                    <tr>
                        <td align="center" width="100%">
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                        </td>
                    </tr>
                </table>
        </div>
    </form>
</body>
</html>
