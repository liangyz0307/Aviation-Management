﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZDGZXXGL.aspx.cs" Inherits="CUST.WKG.ZDGZXXGL" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>航班运行报送</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="text-c">
                报送编号：
             <asp:TextBox ID="tbx_bsbh" runat="server" Width="80px"></asp:TextBox>
                员工编号：
                   <asp:TextBox ID="tbx_bsyg" runat="server" Width="80px"></asp:TextBox>
                员工姓名：
                   <asp:TextBox ID="tbx_bsygxm" runat="server" Width="80px"></asp:TextBox>
                报送支线:
                 <asp:DropDownList ID="ddlt_bszx" runat="server" class="select-box" Height="25px" Width="75px">
                 </asp:DropDownList>
                执行支线：
                  <asp:DropDownList ID="ddlt_zxzx" runat="server" class="select-box" Width="70px" Height="25px">
              </asp:DropDownList>
                状态：
                  <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Width="70px" Height="25px">
              </asp:DropDownList>
                <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click" />
                &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" BackColor="#60B1D7" ForeColor="White" OnClick="btn_add_Click" />
            </div>
            <div class="mt-20">
                <asp:Repeater ID="rpt_zdgz" runat="server" OnItemCommand="rpt_zdgz_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="19">重点工作报送
                                    </th>
                                </tr>
                                <tr>
                                    <th width="30" style="text-align:center;vertical-align:middle;">序号
                                    </th>
                                  <%--  <th width="70" style="text-align:center;vertical-align:middle;">报送编号
                                    </th>--%>
                                    <th width="50" style="text-align:center;vertical-align:middle;">员工姓名
                                    </th>
                                    <th width="50" style="text-align:center;vertical-align:middle;">报送支线
                                    </th>                       
                                    <th width="50" style="text-align:center;vertical-align:middle;">报送类型
                                    </th>                             
                                    <th width="90" style="text-align:center;vertical-align:middle;">报送时间
                                    </th>                                   
                                    <th width="90" style="text-align:center;vertical-align:middle;">工作标题
                                    </th>
                                    <th width="70" style="text-align:center;vertical-align:middle;">执行支线
                                    </th>
                                    <th width="70" style="text-align:center;vertical-align:middle;">工作负责人</th>
                                    <th width="60"style="text-align:center;vertical-align:middle;">报送审批人
                                    </th>                             
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                    </th> 
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                    </th> 
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                    </th> 
                                    <th width="60"style="text-align:center;vertical-align:middle;">状态
                                    </th>
                                    <th width="120" style="text-align:center;vertical-align:middle;">操作
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
                                    <asp:HyperLink ID="hlnk_bsygxm" runat="server" ForeColor="Blue" Style="text-decoration: underline" NavigateUrl='<%#"ZDGZXXGL_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("bsygxm") %>'></asp:HyperLink>
                                </td>
                                 <td>
                                    <asp:Label runat="server" Text='<%#Eval("zxlxmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("bslxmc") %>'></asp:Label>
                                </td>                           
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("bssjgs") %>'></asp:Label>
                                </td>                               
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("gzbt") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("zxzxmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("gzfzrxm") %>'></asp:Label>
                                </td>
                            
                                <td>
                                    <asp:Label runat="server" Text='<%#Eval("sprxm") %>'></asp:Label>
                                </td>
                                <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                                </td>
                                <td>  
                                    <asp:Label ID="lbl_csr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_zsr" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_lrr" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                                </td>
                                <td >
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
                                   <asp:LinkButton ID="LinkButton1" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该重点工作信息？')">删除</asp:LinkButton>                            
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
    </form>
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.admin.js"></script>
    <script type="text/javascript" src="../css/js/H-ui.js"></script>
</body>
</html>
