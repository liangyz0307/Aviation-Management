<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind= "DSZSShow.aspx.cs" Inherits="CUST.WKG.DSZSShow" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>党史知识</title>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  /> 
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
    <div >
        <div class="text-c"   style="text-align: center; width: 100%; margin: 0 auto;">
                标题：
            <asp:TextBox ID="tbx_bt" runat="server"  class="Wdate"  Width="80px"   Height="20px" ></asp:TextBox>
            &nbsp;&nbsp;
              发布时间：
            <asp:TextBox ID="tbx_fbsjks" runat="server"  class="Wdate"    Height="20px" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
               -
           <asp:TextBox ID="tbx_fbsjjs" runat="server" Style="width: 110px"   class="Wdate"    Height="20px" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox> 
             <%-- 状态：
              <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box"  Style="width: 100px">
            </asp:DropDownList>   --%>                            
           <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#ab2025" ForeColor="White" OnClick="btn_select_Click"  /> 
          <%-- <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加"  BackColor="#ab2025" ForeColor="White" OnClick="btn_add_Click"  />  --%>        
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover  table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    党史知识列表
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th style="text-align:center;vertical-align:middle;width:10%">
                                    序号
                                </th>
                                
                                 <th style="text-align:center;vertical-align:middle;width:20%">
                                    标题
                                </th>                              
                               
                               <%--  <th style="text-align:center;vertical-align:middle;width:10%">
                                    发布人
                                </th>--%>
                                 <th style="text-align:center;vertical-align:middle;width:20%">
                                    发布时间
                                </th>                              
                                 <%--<th width="10%" style="text-align: center; vertical-align: middle;">
                                     状态
                                    </th>
                                 <th style="text-align:center;vertical-align:middle;width:25%">
                                    操作
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
                                  <asp:HyperLink ID="hlnk_bt" runat="server" ForeColor="#990000"   style="TEXT-DECORATION:underline"  NavigateUrl='<%#"DSZSShowDetail.aspx?id="+Eval("id")%>'  Text='<%#Eval("bt") %>'></asp:HyperLink> 
                            </td>
                           <%--  <td>
                                <asp:Label ID="lbl_fbr"  runat="server" Text='<%#Eval("fbr") %>'></asp:Label>
                            </td>--%>
                            <td>
                                <asp:Label ID="lbl_fbsj"  runat="server" Text='<%#Eval("fbsjmc")%>'></asp:Label>
                            </td>
                             <%--<td>
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
                    <td  style="text-align :center;width:100%"  >
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%"  OnPageChanged="pg_fy_PageChanged" />
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
         <script src="../../Content/js/jquery.js" type="text/javascript"></script>
        <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script> 
       
        </form>
   
</asp:Content>