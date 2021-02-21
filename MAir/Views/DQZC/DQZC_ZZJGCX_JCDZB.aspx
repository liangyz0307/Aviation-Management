<%@ Page Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DQZC_ZZJGCX_JCDZB.aspx.cs" Inherits="CUST.WKG.DQZC_ZZJGCX_JCDZB" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>组织结构详情</title>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  /> 
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
   
       
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover  table-sort">
                        <thead>
                           <tr>
                                <th scope="col" colspan="16">
                                    基层党支部人员
                                </th>
                            </tr>
                            <tr class="text-c">
                              <th width="15%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    姓名
                                </th>   
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                   基层党支部名称
                                </th>
                                  <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    党小组名称
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
                                <asp:Label ID="lbl_xm" runat="server" Text='<%#Eval("xm") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Labe_jcdzbmc" runat="server" Text='<%#Eval("jcdzbmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_dxzmc" runat="server" Text='<%#Eval("dxzmc") %>'></asp:Label>
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
     
         <script src="../../Content/js/jquery.js" type="text/javascript"></script>
        <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script> 
       
        </form>
   
</asp:Content>


