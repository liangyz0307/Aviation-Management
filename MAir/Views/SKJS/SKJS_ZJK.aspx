<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SKJS_ZJK.aspx.cs" Inherits="CUST.WKG.SKJS_ZJK" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
   <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
    <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
     <style type="text/css">
         .auto-style4 {
             width: 6%;
         }
         .auto-style7 {
             width: 11%;
         }
         .auto-style9 {
             width: 9%;
         }
         .auto-style10 {
             width: 5%;
         }
         .auto-style11 {
             width: 8%;
         }
     </style>
</head>
<body>
     <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div >
         <table><tr>           

              <td align="left" class="auto-style9">姓名：
             <asp:TextBox ID="tbx_xm" runat="server" Width="90px"></asp:TextBox></td>
              <td align="left" class="auto-style9">数据所属部门：
             <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 90px; height: 28px;">
            </asp:DropDownList></td>

             <td align="left" class="auto-style10">专家类型：
             <asp:DropDownList ID="ddlt_zjlx" runat="server" class="select-box" Style="width: 70px; height: 28px;" >
            </asp:DropDownList></td>

          <td align="left" class="auto-style4">
                   状态：
             <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px; height: 28px;" >
            </asp:DropDownList></td>

            <td  style="width:6%"  align="center">
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_select_Click" />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7"/>
                  </td>
              </tr>
           
         </table> 
         
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    专家信息
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                   专家姓名 
                                </th>
                                 <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    专家类型
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    驻地
                                </th>
                
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    从事工作
                                </th>
                                 <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    专业
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    专长
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    联系方式
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                </th>
                                  <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                </th>
                                  <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
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
                                <asp:HyperLink ID="hlnk_sjr" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"ZJK_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("xm") %>'></asp:HyperLink> 

                            </td>           
                            <td>
                                <asp:Label ID="lbl_zjlx" runat="server" Text='<%#Eval("zjlxmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_zd" runat="server" Text='<%#Eval("zd") %>'></asp:Label>
                            </td>
  
                             <td>
                                 <asp:Label ID="lbl_csgz" runat="server" Text='<%#Eval("csgz") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_zy" runat="server" Text='<%#Eval("zy") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_zc" runat="server" Text='<%#Eval("zc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_lxfs" runat="server" Text='<%#Eval("lxfs") %>'></asp:Label>
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
                                    runat="server" OnClientClick="return confirm('您确定要删除该专家信息？')">删除</asp:LinkButton>
                                    
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
                    <td align="center" width="100%" background="../images/menuFunction.gif">
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
