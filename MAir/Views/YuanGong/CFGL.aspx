<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CFGL.aspx.cs" Inherits="CUST.WKG.CFGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <style type="text/css">
        td.td_sjsc {
            background: #F6FAFD;
        }
        .auto-style4 {
            width: 13%;
        }
        .auto-style5 {
            width: 5%;
        }
        .auto-style6 {
            width: 7%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table>
                <tr>
<%--             <td align="left" class="auto-style6">受罚人：
             <asp:TextBox ID="tbx_sfr" runat="server" Width="100px"></asp:TextBox></td>--%>
                    <td align="left" class="auto-style6">事件种类：             
             <asp:DropDownList ID="ddlt_sjzl" runat="server" class="select-box" Width="120px">
             </asp:DropDownList></td>
                    <td align="left" class="auto-style6">部门：             
             <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Width="149px">
             </asp:DropDownList></td>
                    <td align="left" class="auto-style5">状态：
              <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box"   Width="78px">
            </asp:DropDownList></td>

                    <td align="left" class="auto-style4">惩罚时间：
             <asp:TextBox ID="tbx_kssj" runat="server" class="input-text" placeholder="开始日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="89px"></asp:TextBox>-<asp:TextBox ID="tbx_jssj" runat="server" class="input-text" placeholder="截止日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})"  TextMode="SingleLine" Width="91px"></asp:TextBox></td>
                    <td style="width: 7%" align="center">
                        <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                            OnClick="btn_select_Click" />
                        &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7" />
                         &nbsp;
     <asp:Button ID="btn_dc" runat="server" class="btn  radius" Text="导出" OnClick="btn_dc_Click" ForeColor="White" BackColor="#60B1D7" />
                    </td>
                </tr>
            </table>
            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>

                                <tr>
                                    <th scope="col" colspan="16">不安全事件处罚列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="5%"  style="text-align:center;vertical-align:middle;">
                                         序号
                                    </th>
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                        受罚人
                                    </th>
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                        数据所属部门
                                    </th>
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                        事件种类
                                    </th>
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                        承担责任
                                    </th>
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                        处理意见
                                    </th>
                                   <th width="6%"  style="text-align:center;vertical-align:middle;">
                                         初审人
                                   </th>
                                  <th width="6%"  style="text-align:center;vertical-align:middle;">
                                         终审人
                                  </th>
                                  <th width="8%"  style="text-align:center;vertical-align:middle;">
                                         日期
                                  </th>
                                  <th width="6%"  style="text-align:center;vertical-align:middle;">
                                         录入人
                                  </th> 
                                  <th width="6%"  style="text-align:center;vertical-align:middle;">
                                         状态
                                  </th>
                                  <th width="12%"  style="text-align:center;vertical-align:middle;">
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
                                    <asp:HyperLink ID="hlnk_sfr" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"YGCF_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("sfrxm") %>'></asp:HyperLink> 

                                </td>
                                <td>
                                    <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_sjzl" runat="server" Text='<%#Eval("sjzlmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cdzr" runat="server" Text='<%#Eval("cdzr") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_clyj" runat="server" Text='<%#Eval("clyj") %>'></asp:Label>
                                </td>
                                 <td>
                                 <asp:Label ID="lbl_csr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                            <td>
                                    <asp:Label ID="Labe_cfsj" runat="server" Text='<%#Eval("cfsjmc") %>'></asp:Label>
                                </td>
                             <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
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
                                    runat="server" OnClientClick="return confirm('您确定要删除该惩罚信息？')">删除</asp:LinkButton>
                                    
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

        <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
        <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
    </form>
</body>
</html>
