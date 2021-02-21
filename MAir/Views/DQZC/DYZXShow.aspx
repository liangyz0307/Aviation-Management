<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DYZXShow.aspx.cs" Inherits="CUST.WKG.DYZXShow" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>党员在线</title>
     <!--[if lt IE 9]> 
     <script type="text/javascript" src="../lib/html5.js"></script>
     <script type="text/javascript" src="../lib/respond.min.js"></script>
     <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
     <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
       <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />
       <script src="../css/js/jquery.js" type="text/javascript"></script>
       <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script type="text/javascript" src="../../Content/js/jalendar.js"></script>
     <script type="text/javascript" src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
     <%--<link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />--%>
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
    <div >
        <div>  姓名：
             <asp:TextBox ID="txb_xm" runat="server" style="width:70px;height:24px;"></asp:TextBox>
         
             时间：
             <asp:TextBox ID="tbx_kssj" runat="server" class="input-text" placeholder="开始日期"  onclick="lhgcalendar({format:'yyyy-MM-dd'})"  Width="90px"></asp:TextBox>-<asp:TextBox ID="tbx_jssj" runat="server" class="input-text" placeholder="截止日期"  onclick="lhgcalendar({format:'yyyy-MM-dd'})"  Width="90px"></asp:TextBox>
            <%--时间：
             <asp:TextBox ID="tbx_kssj" runat="server" class="input-text" placeholder="开始日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="90px"></asp:TextBox>-<asp:TextBox ID="tbx_jssj" runat="server" class="input-text" placeholder="截止日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="90px"></asp:TextBox>
            <%--  用工形式：
              <asp:DropDownList ID="ddlt_ygxs" runat="server" class="select-box" Style="width: 80px" AutoPostBack="True" >
            </asp:DropDownList>--%>
           <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#ab2025" ForeColor="White" OnClick="btn_select_Click"  /> 
            <%--<asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加"  BackColor="#ab2025" ForeColor="White" OnClick="btn_add_Click"  />          --%>
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server"   >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover  table-sort" style="width:976px; table-layout: fixed;">
                        <thead>
                          <%--  <tr>
                                <th scope="col" colspan="16">
                                    党员主要事迹
                                </th>
                            </tr>--%>
                             <tr class="text-c">
                                    <th width="10%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">姓名
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">部门
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">岗位
                                    </th>
                                    <th width="10%" style="text-align: center; vertical-align: middle;">时间

                                    </th>
                                    <th width="20%" style="text-align: center; vertical-align: middle;">主要事迹
                                    </th> 
                                    <%--<th width="10%" style="text-align: center; vertical-align: middle;">状态
                                    </th>
                                                                        
                                    <th width="20%">操作
                                    </th>--%>
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
                                    <%--<asp:Label ID="Labe_jcr" runat="server" Text='<%#Eval("jcrxm") %>'></asp:Label>--%>
                                      <asp:HyperLink ID="hlnk_jcr" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"DYZXShowDetail.aspx?id=" + Eval("id")%>' Text='<%# Eval("xm") %>'></asp:HyperLink> 
                                </td>
                                <td>
                                    <asp:Label ID="Labe_bjcr" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("gwmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_jcsj" runat="server" Text='<%#Eval("sjmc") %>'></asp:Label>
                                </td>
                                <td style="text-align: center; white-space: nowrap;text-overflow: ellipsis;overflow: hidden; vertical-align: middle;">
                                 <%-- <asp:Label ID="Labe_jcd"  runat="server" Text='<%#GetCut(Eval("zysj").ToString().Trim(),20) %>' ToolTip ='<%#Eval("zysj")%>'></asp:Label>--%>
                                     <asp:Label ID="Label2" runat="server" Text='<%#Eval("zysj") %>' ToolTip ='<%#Eval("zysj")%>'>></asp:Label>
                                </td>
                               <%-- <td>
                                    <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                                </td>                                                                                                
                               
                                  <td class="td-manage">

                               <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="#60B1D7"  style="text-decoration:underline"
                                    runat="server" >提交</asp:LinkButton>
                               <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="#60B1D7"  style="text-decoration:underline"
                                    runat="server" >审核</asp:LinkButton>
                               <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="#60B1D7"  style="text-decoration:underline"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                               <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClientClick="return confirm('您确定要修改该信息？')">修改</asp:LinkButton>

                               <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClientClick="return confirm('您确定要删除该信息？')">删除</asp:LinkButton>
                          
                            </td>--%>
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
    <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
    <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
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
</asp:Content>
