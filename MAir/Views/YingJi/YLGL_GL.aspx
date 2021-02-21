<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YLGL_GL.aspx.cs" Inherits="CUST.WKG.YLGL_GL" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>导航设备设备管理</title>
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
        <div class="text-c" >
            地区：
            <asp:DropDownList ID="ddlt_dq" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
            预案名：
              <asp:DropDownList ID="ddlt_yam" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>  
            演练形式：
             <asp:DropDownList ID="ddlt_ylxs" runat="server" class="select-box" Style="width: 100px">
             </asp:DropDownList>
            
             状态：
            <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White"
                OnClick="btn_select_Click" />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" OnClick="btn_add_Click"  BackColor="#60B1D7" ForeColor="White" />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="rpt_ylgl" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="rpt_ylgl_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    演练列表
                                </th>
                            </tr>
                            <tr class="text-c">
                             
                              
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                    预案名
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    演练时间
                                </th>
                                 <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    支线名称
                                </th>
                                  <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    演练形式
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
                            <td>
                                <asp:HyperLink ID="YLGL_Edit" runat="server" ForeColor="blue" Style="text-decoration: underline" NavigateUrl='<%#"YLGL_Detail.aspx?bh=" + Eval("bh")%>' Text='<%# Eval("yammc") %>'></asp:HyperLink>
                            </td>
                             <td>
                                <asp:Label runat="server" Text='<%#Eval("ylsjmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%#Eval("dqmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("ylxsmc") %>'></asp:Label>
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
                              <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_zt"  runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                            <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("bh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("bh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr") +"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("bh") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("bh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("bh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该演练信息？？')">删除</asp:LinkButton>
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
                    <td align="center" width="96%" >
                        <cc1:Pager ID="pg_fy" runat="server" Width="96%" OnPageChanged="pg_fy_PageChanged" />
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
