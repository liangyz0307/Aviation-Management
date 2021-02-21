<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YGGL.aspx.cs" Inherits="CUST.WKG.YGGL" %>
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
 
</head>
<body>
     <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div >
        <table>
                
            <tr>
                <td style="width:15%; " align="right">
                    员工编号：
                    <asp:TextBox ID="tbx_bh" runat="server" style="width:80px; height:24px">
                    </asp:TextBox>
                </td>

               <td style="width:17%; " align="right">    
                   员工姓名：
                   <asp:TextBox ID="tbx_ygxm" runat="server" style="width:80px;height:24px;">
                   </asp:TextBox>
               </td>
               <td style="width:12%; " align="right">
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                            部门：
                            <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 100px" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged" >
                            </asp:DropDownList>
                       </ContentTemplate>
                    </asp:UpdatePanel>    
               </td>
           <td style="width:12%; " align="right">
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate>
          
                      岗位：
              <asp:DropDownList ID="ddlt_gwdm" runat="server" class="select-box" Style="width: 80px"  >
            </asp:DropDownList>
                    </ContentTemplate>
               </asp:UpdatePanel>
               </td>
             <td style="width:12%; " align="right">
             
                     状态：
              <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px"  >
            </asp:DropDownList>
                       
               </td>
            <td  align="center">
                <asp:Button ID="btn_cx" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7" OnClick="btn_select_Click" />
                <asp:Button ID="btn_tj" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7"/>      
            </td>

            </tr>
            <tr>
                
                <td style="width:18%; " align="right">           
                     政治面貌：
                    <asp:DropDownList ID="ddlt_zzmm" runat="server" class="select-box" Style="width: 100px"  >
                    </asp:DropDownList>                      
               </td>
               <td style="width:10%; " align="right">           
                     合同类型：
                    <asp:DropDownList ID="ddlt_htlx" runat="server" class="select-box" Style="width: 80px"  >
                    </asp:DropDownList>                      
               </td>
               <td style="width:20%; " align="right">  
                     出生年份：
                    <asp:TextBox ID="tbx_csrq_qs" runat="server" class="input-text" placeholder="" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="60px">
                    </asp:TextBox>- -
                    <asp:TextBox ID="tbx_csrq_jz" runat="server" class="input-text" placeholder="" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="60px">
                    </asp:TextBox>
<%--                    <asp:DropDownList ID="ddlt_bjbs" runat="server" class="select-box" Style="width: 80px"  >
                    </asp:DropDownList> --%>
                </td>
                <td style="width:15%; " align="right">           
                     性别：
                    <asp:DropDownList ID="ddlt_xb" runat="server" class="select-box" Style="width: 80px" >
                    </asp:DropDownList>                      
               </td>
               <td style="width:15%; " align="right">           
                     民族：
                    <asp:DropDownList ID="ddlt_mz" runat="server" class="select-box" Style="width: 80px" >
                    </asp:DropDownList>                      
               </td>
               <td  align="center">      
                <asp:Button ID="btn_dc" runat="server" class="btn  radius" Text="导出" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_dc_Click" />
               </td>
            </tr>

        </table> 
      
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="18">
                                    员工列表
                                </th>
                            </tr>
                            <tr class="text-c">

                                <th width="20"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    员工编号
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    姓名
                                </th>
                                  <th width="100"  style="text-align:center;vertical-align:middle;">
                                    身份证号
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    民族
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    性别
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    部门
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    岗位
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    出生日期
                                </th>
                               <th width="50"  style="text-align:center;vertical-align:middle;">
                                  籍贯
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    学历
                                </th>                             
                               <th width="80"  style="text-align:center;vertical-align:middle;">
                                    专业名称
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    毕业时间
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    政治面貌
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    合同关系
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    合同类型
                                </th>
<%--                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>--%>

                                  <th width="50"  style="text-align:center;vertical-align:middle;">
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
                                <asp:Label ID="lbl_rznr" runat="server" Text='<%#Eval("BH") %>'></asp:Label>
                            </td>
                            <td>
                              
                         <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"  Font-Underline="true"      NavigateUrl='<%#"YG_Detail.aspx?bh=" + Eval("bh")+"&id="+Eval("id")%>' Text='<%# Eval("XM") %>'></asp:HyperLink> 

                            </td>
                             <td>
                                <asp:Label ID="lbl_sfzh" runat="server" Text='<%#Eval("SFZH") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("mzmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_xb" runat="server" Text='<%#Eval("xbmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("gwmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_csrq" runat="server" Text='<%#Eval("RQ") %>'></asp:Label>
                            </td>
                                    
                            <td>
                                <asp:Label ID="lbl_jg" runat="server" Text='<%#Eval("JG") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_xl" runat="server" Text='<%#Eval("xl") %>'></asp:Label>
                            </td>
                                                         <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("ZY") %>'></asp:Label>
                            </td>
                                                         <td>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("BYSJ") %>'></asp:Label>
                            </td>  
                                                          <td>
                                <asp:Label ID="lbl_zzmm" runat="server" Text='<%#Eval("zzmm") %>'></asp:Label>
                            </td>                 
                              <td>
                                <asp:Label ID="lbl_htgx" runat="server" Text='<%#Eval("htgx") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_htlx" runat="server" Text='<%#Eval("htlxdm") %>'></asp:Label>
                            </td>
<%--                            <td>
                                <asp:Label ID="lbl_zsr" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>--%>
<%--                            <td>
                                <asp:Label ID="lbl_csr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_zsr" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>--%>
                            <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_byyx" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                                 <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("BH")+"&"+Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("BH")+"&"+Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("BH")+"&"+Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("BH")+"&"+Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("BH")+"&"+Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该员工信息？')">删除</asp:LinkButton>
                              <%--   <asp:LinkButton ID="lbtnKjrk" CommandName="KJRK" CommandArgument='<%#Eval("bh") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >分配快捷入口</asp:LinkButton>--%>
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
                    <td align="center" width="100%" >
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
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
