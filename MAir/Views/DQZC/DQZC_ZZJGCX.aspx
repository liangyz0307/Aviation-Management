<%@ Page Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DQZC_ZZJGCX.aspx.cs" Inherits="CUST.WKG.DQZC_ZZJGCX" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>组织结构</title>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  /> 
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
   
       <div class="text-c">

             党组织名称：
             <asp:TextBox ID="txb_dzzmc" runat="server" style="width:70px;height:24px;"></asp:TextBox>
            基层党支部名称：
             <asp:TextBox ID="txb_jcdzbmc" runat="server" style="width:70px;height:24px;"></asp:TextBox>
            党小组名称：
             <asp:TextBox ID="txb_dxzmc" runat="server" style="width:70px;height:24px;"></asp:TextBox>
             
           
            <td style="width:5%; " align="right">状态：
              <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px; height: 28px;"  AutoPostBack="true">
            </asp:DropDownList></td>

            <asp:Button ID="btn_select" runat="server" class="btn  radius"  Text="查询" ForeColor="White" BackColor="#ab2025"
                OnClick="btn_select_Click" />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#ab2025"/>        
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover  table-sort">
                        <thead>
                           <tr>
                                <th scope="col" colspan="16">
                                    组织结构信息查询
                                </th>
                            </tr>
                            <tr class="text-c">
                              <th width="15%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                    党组织名称
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                   基层党支部名称
                                </th>
                                  <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    党小组名称
                                </th>     
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                   状态
                                </th>
                                <th width="35%">
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
                                <asp:Label ID="Labe_dzzmc" runat="server" Text='<%#Eval("dzzmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:HyperLink ID="Labe_jcdzbmc" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"DQZC_ZZJGCX_JCDZB.aspx?jcdzbmc=" + Eval("jcdzbmc")%>' Text='<%# Eval("jcdzbmc") %>'></asp:HyperLink> 
                            </td>
                             <td>
                                 <asp:HyperLink ID="Labe_dxzmc" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"DQZC_ZZJGCX_DXZ.aspx?dxzmc=" + Eval("dxzmc")%>' Text='<%# Eval("dxzmc") %>'></asp:HyperLink> 

                            </td>
                            
                           
                            <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                                </td>
      
                          <td class="td-manage">
                                 <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
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
                    <td  style="text-align :center;width:100%"  >
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%"  OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
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
         <script src="../../Content/js/jquery.js" type="text/javascript"></script>
        <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script> 
       
        </form>
   
</asp:Content>


