<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YJ_YAGL.aspx.cs" Inherits="CUST.WKG.YJ_YAGL" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>预案管理</title>
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
    <div >
        <div class="text-c">
            名称：
             <asp:DropDownList ID="ddlt_mc" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
            地区：
            <asp:DropDownList ID="ddlt_dq" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
            专业：
            <asp:DropDownList ID="ddlt_zy" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
             状态：
            <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
           
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White"
          OnClick="btn_select_Click"      />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" OnClick="btn_add_Click"  BackColor="#60B1D7" ForeColor="White" />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="width:976px; table-layout: fixed;">
                        <thead>
                         <%--   <tr>
                                <th scope="col" colspan="18">
                                    预案管理列表
                                </th>
                            </tr>--%>
                            <tr class="text-c">
                                <th width="2%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                    名称
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    地区
                                </th>
                                  <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    专业
                                </th>
                           
                                 <th width="20%"  style="text-align:center;vertical-align:middle;">
                                    预案内容
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                                <th width="20%">
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
                       
                            <td >
                                <asp:HyperLink ID="hlnk_yagl_edit" runat="server" ForeColor="blue" Style="text-decoration: underline" NavigateUrl='<%#"YAGL_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("mc") %>'></asp:HyperLink>
                            </td>
                            
                         
                             <td >
                                <asp:Label  runat="server" Text='<%# Eval("zxdm") %>'></asp:Label>
                            </td>
                             <td >
                                <asp:Label  runat="server" Text='<%#Eval("zylx") %>'></asp:Label>
                            </td>
                              <td  style="white-space: nowrap;text-overflow: ellipsis;overflow: hidden;">                         
                               <%--   <asp:Label ID="Label1"  runat="server" Text='<%#GetCut(Eval("yanr").ToString().Trim(),20) %>' ToolTip ='<%#Eval("yanr")%>'></asp:Label>--%>
                                   <asp:Label ID="Label1" runat="server" Text='<%#Eval("yanr") %>' ToolTip ='<%#Eval("yanr")%>'>></asp:Label>
                           </td>
                                <td >
                                <asp:Label ID="Label2"  runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                            </td>
                                <td >
                                <asp:Label ID="Label3"  runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>
                                <td >
                                <asp:Label ID="Label4"  runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                                <td >
                                <asp:Label ID="Label5"  runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                              <td title='<%# Eval("bhyy") %>' >
                                <asp:Label ID="lbl_zt"  runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                            <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr") +"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('删除该预案同时会删除该预案的演练，请问您是否删除？')">删除</asp:LinkButton>
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
        <asp:HiddenField ID="HF_yc" runat="server"/>
    <script type="text/javascript">
        //单个按钮驳回
        function rec() {
            var excuse;
            excuse = prompt("请输入驳回原因：");
            if (excuse == null)
            { return false; }
            else {
                document.getElementById("<%=HF_yc.ClientID %>").value = excuse;
                        }

                    }
    </script>  
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>   
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>
    </form>
</body>
</html>
