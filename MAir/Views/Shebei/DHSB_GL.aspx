<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DHSB_GL.aspx.cs" Inherits="CUST.WKG.DHSB_GL" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>导航设备设备管理</title>
    <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"=></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div >
        <div class="text-c">
           设备型号：
             <asp:TextBox ID="tbx_sbxh" runat="server" style="width:100px;height:25px;" MaxLength="10"></asp:TextBox>
            设备类型：
            <asp:DropDownList ID="ddlt_sblx" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
            台站名称种类：
              <asp:DropDownList ID="ddlt_tzmczl_tzmc" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
               <asp:DropDownList ID="ddlt_tzmczl_wz" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
               <asp:DropDownList ID="ddlt_tzmczl_sblx" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
        </div>
        <div class="text-c">
            所属机场：
             <asp:DropDownList ID="ddlt_yssjc" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
            校飞到期日期：
            <asp:TextBox ID="tbx_jfdqrq" runat="server" style="width:100px;height:24px;"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="10"></asp:TextBox>
                            <asp:Label ID="lbl_jfdqrq" runat="server"></asp:Label>
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White"
                OnClick="btn_select_Click" />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" OnClick="btn_add_Click"  BackColor="#60B1D7" ForeColor="White" />
          
&nbsp;
  <asp:Button ID="btn_dc" runat="server" class="btn  radius" Text="导出" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_dc_Click" />
          

        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    导航设备列表
                                </th>
                            </tr>
                            <tr class="text-c">
                             
                              
                                <th width="70"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="180"  style="text-align:center;vertical-align:middle;">
                                    设备型号
                                </th>
                                <th width="180"  style="text-align:center;vertical-align:middle;">
                                    所属台站名称
                                </th>
                                  <th width="190"  style="text-align:center;vertical-align:middle;">
                                    所属机场
                                </th>
                                    <th width="190"  style="text-align:center;vertical-align:middle;">
                                    设备类型
                                </th>
                                <th width="180"  style="text-align:center;vertical-align:middle;">
                                    校飞周期
                                </th>
                              <th width="180"  style="text-align:center;vertical-align:middle;">
                                    校飞到期日期
                                </th>
                              <th width="70" style="text-align: center; vertical-align: middle;">
                                  初审人
                               </th>
                               <th width="70" style="text-align: center; vertical-align: middle;">
                                   终审人
                               </th>
                               <th width="70" style="text-align: center; vertical-align: middle;">
                                   录入人
                                <th width="180"  style="text-align:center;vertical-align:middle;">
                                   状态
                                </th>                           
                                <th width="160">
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
                                  <asp:HyperLink ID="sbxh_mc" runat="server" ForeColor="Blue"   style="TEXT-DECORATION:underline"  NavigateUrl='<%#"DHSB_Detail.aspx?id="+Eval("id")%>'  Text='<%#Eval("sbxh") %>'></asp:HyperLink> 
                            </td>
                             <td>
                                <asp:Label runat="server" Text='<%#Eval("sstz_mc") %>'></asp:Label>
                            </td>
                         
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("yssjc_mc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("sblxmc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("jfzq") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("jfdqrqz") %>'></asp:Label>
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
                            <td>
                                <asp:Label id="ztmc" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                                <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")  %>' ForeColor="blue" style="text-decoration:underline"
                                    runat="server" OnClientClick="return confirm('您确定要删除该设备信息？')">删除</asp:LinkButton>
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

 
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
        
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>
     <asp:HiddenField ID="HF_yc" runat="server"/>
  
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
</body>
</html>
