<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_WXFY.aspx.cs" Inherits="CUST.WKG.BS_WXFY" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>维修费用管理</title>
       <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css"/>
       <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"  />
       <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
       <script type="text/javascript" src="../../Content/js/jquery.js"></script>
       <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div >
        <div class="text-c">
             年度：
             <asp:TextBox ID="tbx_nd" runat="server" class="input-text" Style="width: 100px; height: 28px;" placeholder="年份" onclick="lhgcalendar({format:'yyyy'})"></asp:TextBox>
           登记单位：
             <asp:DropDownList ID="ddlt_djdw" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
            维修类别：
            <asp:DropDownList ID="ddlt_wxlb" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>        
            状态：
            <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>          
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White"
          OnClick="btn_select_Click"      />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" OnClick="btn_add_Click"  BackColor="#60B1D7" ForeColor="White" />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="18">
                                    维修类型列表
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="30"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="120"  style="text-align:center;vertical-align:middle;">
                                    项目名称
                                </th>
                                <th width="70"  style="text-align:center;vertical-align:middle;">
                                    年度 
                                </th>
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    登记单位
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                   预算批复 
                                </th>
                                  <th width="40"  style="text-align:center;vertical-align:middle;">
                                    维修类别
                                </th>
                                <th width="120"  style="text-align:center;vertical-align:middle;">
                                    设备类别
                                </th>
                                 <th width="120"  style="text-align:center;vertical-align:middle;">
                                    设备名称
                                </th>                            
                                <th width="120"  style="text-align:center;vertical-align:middle;">
                                    存放地点
                                </th>
                                <th width="120"  style="text-align:center;vertical-align:middle;">
                                    维修日期
                                </th><th width="120"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                 <th width="120"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                <th width="120"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                <th width="120"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                     状态
                                </th>
                                <th width="150">
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
                                <asp:HyperLink ID="hlnk_xmmc" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"BS_WXFY_Detail.aspx?wxbh=" + Eval("wxbh")%>' Text='<%# Eval("xmmcmc") %>'></asp:HyperLink> 
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("nd") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%#Eval("djdwmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label runat="server" Text='<%#Eval("yspfmc") %>'></asp:Label>
                            </td>                       
                             <td>
                                <asp:Label  runat="server" Text='<%# Eval("wxlbmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("sblbmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("sbmcmc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("cfddmc") %>'></asp:Label>
                            </td>
                           </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("wxrqmc")%>'></asp:Label>
                            </td>
                               <td>
                                <asp:Label  runat="server" Text='<%#Eval("bmdmmc")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("csrxm")%>'></asp:Label>
                            </td>
                                                         <td>
                                <asp:Label  runat="server" Text='<%#Eval("zsrxm")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("lrrxm")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_ztmc"  runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                                 <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("wxbh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("wxbh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("wxbh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("wxbh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("wxbh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该条请示登记？')">删除</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtBxdj" CommandName="Bxdj" CommandArgument='<%#Eval("xmmc")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >报销登记</asp:LinkButton>
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
                          
    }</script>
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
        
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>

  

    </form>
</body>
</html>
