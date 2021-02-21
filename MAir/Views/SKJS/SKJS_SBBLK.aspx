<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SKJS_SBBLK.aspx.cs" Inherits="CUST.WKG.SKJS_SBBLK" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>三库建设</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div >
        <div class="text-c">
            保养频次：
            <asp:DropDownList ID="ddlt_bypc" runat="server" CssClass="select-box" Style="width: 100px">
            </asp:DropDownList>
            设备名称：
              <asp:TextBox ID="tbx_sbmc" runat="server" Height="20px"></asp:TextBox>
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White"
          OnClick="btn_select_Click"      />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" OnClick="btn_add_Click"  BackColor="#60B1D7" ForeColor="White" />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="18">
                                    三库建设列表
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    设备名称
                                </th>
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                   地点 
                                </th>
                                  <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    使用岗位
                                </th>
                           
                                 <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    使用人
                                </th>
                              
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    使用年限
                                </th>
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                   故障时间
                                </th>
                           
                                  <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    排故方式
                                </th>
                               
                                 <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                </th>
                                  <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th> 
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                                <th width="15%">
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
                                <asp:HyperLink ID="hlnk_sbmc" runat="server" ForeColor="#60B1D7" Style="text-decoration: underline" NavigateUrl='<%#"SKJS_SBBLK_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("sbmc") %>'></asp:HyperLink>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%#Eval("dd") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label runat="server" Text='<%#Eval("sygw") %>'></asp:Label>
                            </td>
                         
                             <td>
                                <asp:Label  runat="server" Text='<%# Eval("syrxm") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("synx") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("gzsjs") %>'></asp:Label>
                            </td>
                            
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("pgfs") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_fzr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_zsrxm" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_lrrxm" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>  
                            <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_byyx" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
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
                                    runat="server" OnClientClick="return confirm('您确定要删除该设备病例信息？')">删除</asp:LinkButton>
                                    
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

  
         <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>

    </form>
</body>
</html>