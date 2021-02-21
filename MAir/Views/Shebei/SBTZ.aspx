<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SBTZ.aspx.cs" Inherits="CUST.WKG.SBTZ" %>

<!DOCTYPE html>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>台站管理</title>
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
    <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"=></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div >
        <div class="text-c">
           
            台站名称：
              <asp:DropDownList ID="ddlt_jc" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>  
               <asp:DropDownList ID="ddlt_wz" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
               <asp:DropDownList ID="ddlt_sblx" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
            房屋信息：
             <asp:TextBox ID="tbx_fwxx" runat="server" style="width:100px;height:25px;" MaxLength="10"></asp:TextBox>
             状态：
            <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 100px">
                </asp:DropDownList>
            <td  style="width:6%"  align="center">
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_select_Click" />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7"/>
                  </td>
              &nbsp; <asp:Button ID="btn_dc" runat="server" class="btn  radius" Text="导出" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_dc_Click" />

        </div>
        
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="20">
                                    台站设备列表
                                </th>
                            </tr>
                            <tr class="text-c">
                             
                              
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    台站名称
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                  <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    房屋信息
                                </th>
                           
                                 <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    楼层
                                </th>
                              
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    房间号
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    结构
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    竣工时间
                                </th>
                                 <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    台站位置信息
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    机房输入线路情况
                                </th>
                               <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    机房总输出
                                </th>
                               <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    台站温度是否达标
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
                                <th width="20%"  style="text-align:center;vertical-align:middle;">
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
                                <asp:HyperLink   runat="server"  ForeColor="Blue" style="TEXT-DECORATION:underline" NavigateUrl='<%#"SBTZ_Detail.aspx?id=" + Eval("id")%>'  Text='<%#Eval("jcmc")+" "+ Eval("wz")+" "+ Eval("sblxmc") %>' ></asp:HyperLink> 
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("fwxx") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("lc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("fjh") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("jg") %>'></asp:Label>
                            </td>
                           </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("jgsj") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("tzwzxx") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("jfsrxlqk") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("jfzsc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("tzwdsfdbmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                            <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_byyx" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
                            </td>   
                               <td class="td-manage">
                                 <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") +"&"+ Eval("tzbh")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr") +"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") +"&"+ Eval("tzbh")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")  +"&"+ Eval("tzbh")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") +"&"+ Eval("tzbh")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") +"&"+ Eval("tzbh") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该台站信息？')">删除</asp:LinkButton>
                             &nbsp;
                                <asp:LinkButton ID="lbtCZGL" CommandName="CZGL" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") +"&"+ Eval("tzbh")%> ' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >子表操作管理</asp:LinkButton>
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

