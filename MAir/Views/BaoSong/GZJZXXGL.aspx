<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GZJZXXGL.aspx.cs" Inherits="CUST.WKG.GZJZXXGL" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>航班运行报送</title>
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="text-c">
                 报送部门:
                 <asp:DropDownList ID="ddlt_bsbm" runat="server" class="select-box" Height="25px" Width="95px">
                 </asp:DropDownList>
                报送支线:
                 <asp:DropDownList ID="ddlt_zxmc" runat="server" class="select-box" Height="25px" Width="95px">
                 </asp:DropDownList>
                状态:
              <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px"  AutoPostBack="true">
            </asp:DropDownList>

                <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click" />
                &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" BackColor="#60B1D7" ForeColor="White" OnClick="btn_add_Click" />
            </div>
            <div class="mt-20">
                <asp:Repeater ID="rpt_gzjz" runat="server" OnItemCommand="rpt_gzjz_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="19">工作进展报送
                                    </th>
                                </tr>
                                <tr>
                                    <th width="30" style="text-align:center;vertical-align:middle;">序号
                                    </th>
                                    <th width="70" style="text-align:center;vertical-align:middle;">报送部门
                                    </th>
                                    <th width="70"style="text-align:center;vertical-align:middle;">报送时间
                                    </th>
                                    <th width="70"style="text-align:center;vertical-align:middle;">报送支线
                                    </th>
                                    <th width="100" style="text-align:center;vertical-align:middle;">工作主题
                                    </th>
                                    <th width="70"style="text-align:center;vertical-align:middle;">完成进度
                                    </th>
                                    <th width="70" style="text-align:center;vertical-align:middle;">工作负责人
                                    </th>                             
                                     <th width="60" style="text-align:center;vertical-align:middle;">状态
                                    </th>
                                    <th width="60" style="text-align:center;vertical-align:middle;">操作
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
                              <asp:HyperLink  runat="server"    ForeColor="blue"   style="TEXT-DECORATION:underline"    NavigateUrl='<%#"GZJZXXGL_Detail.aspx?id=" + Eval("id")+"&bzsjc=" + Eval("sjc")+"&zt=" + Eval("zt")+"&sjbs=" + Eval("sjbs")%>' Text='<%# Eval("bsbmmc") %>'></asp:HyperLink> 
                               </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("bmbssj") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("bszxmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("gzzt") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("wcjd") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("gzfzrxm") %>'></asp:Label>
                                </td>
                                  <td>
                                    <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                                </td>

                                <td class="td-manage">
                               <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="blue"  style="text-decoration:underline"
                                    runat="server" >提交</asp:LinkButton>
                               <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="blue"  style="text-decoration:underline"
                                    runat="server" >审核</asp:LinkButton>
                               <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="blue"  style="text-decoration:underline"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                               <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="blue" style="text-decoration:underline"
                                    runat="server" OnClientClick="return confirm('您确定要修改该信息？')">修改</asp:LinkButton>
                               <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="blue" Style="text-decoration: underline"
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
                        <td align="center" width="100%">
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />

                        </td>
                    </tr>
                </table>
            </div>
        </div>

                <asp:HiddenField ID="HF_yc" runat="server" />
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.admin.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.js"></script>
            </form>
</body>
</html>
