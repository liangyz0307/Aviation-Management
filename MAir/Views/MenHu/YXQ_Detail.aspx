<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MenHu/Sys.Master" AutoEventWireup="true" CodeBehind="YXQ_Detail.aspx.cs" Inherits="MAir.Views.MenHu.YXQ_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="kg_content" runat="server">
           <asp:Repeater ID="rp_yy" runat="server" Visible="false" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="margin-top:30px">
                        <thead>
                            <tr>
                                <th scope="col" colspan="3" style="text-align:center;font-size:16px" >
                                    英语等级有效期
                                 </th>
                            </tr>
                            <tr class="text-c">
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    类型
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                    执照文件号码
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    有效期(天)
                                </th>                                
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                <%#Eval("lx") %>
                            </td>
                            <td>
                                <%#Eval("s1") %>
                            </td>
                             <td>
                                <%#Eval("yydjyxq") %>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
    
           <asp:Repeater ID="rp_tj" runat="server" Visible="false" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="margin-top:30px">
                        <thead>
                            <tr>
                                <th scope="col"  colspan="3" style="text-align:center;font-size:16px" >
                                    体检有效期
                                 </th>
                            </tr>
                            <tr class="text-c">
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    类型
                                </th>  
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                    体检等级
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    有效期(天)
                                </th>                               
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">

                            <td>
                                <%#Eval("lxmc") %>
                            </td>
                             <td>
                                <%#Eval("tjdj") %>
                            </td>
                            <td>
                                <%#Eval("tjyxq") %>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

           <asp:Repeater ID="rp_zz" runat="server" Visible="false" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort" style="margin-top:30px">
                        <thead>
                            <tr>
                                <th scope="col"  colspan="3" style="text-align:center;font-size:16px" >
                                    执照有效期
                                 </th>
                            </tr>
                            <tr class="text-c">

                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    类型
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                    执照签注
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   签注项
                                </th>  
                                 <th width="90"  style="text-align:center;vertical-align:middle;">
                                    签注有效期(天)
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   异地签注有效期(天)
                                </th>                               
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                             <td>
                                <%#Eval("lx") %>
                            </td>
                            <td>
                                <%#Eval("zzqz") %>
                            </td>
                            <td>
                                <%#Eval("qzx") %>
                            </td>
                             <td>
                                <%#Eval("qzyxq") %>
                            </td>
                             <td>
                                <%#Eval("ydqzyxq") %>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

</asp:Content>
