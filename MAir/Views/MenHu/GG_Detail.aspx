<%@ Page Title="" Language="C#" MasterPageFile="Sys.Master" AutoEventWireup="true" CodeBehind="GG_Detail.aspx.cs" Inherits="CUST.Web.MengHu.main.GG_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="kg_content" runat="server">
    <form runat="server">
    <div style="padding:20px;">
       
            <h3 style="color:#000000;height:50px;text-align:center;line-height:50px;font-size:20px;font-weight:bold;">
		      
                <asp:Label ID="lbl_title" runat="server" ></asp:Label>  
            </h3>
        <div style="height:30px;">
            <p style="text-align:center;letter-spacing:3px;">
           
            <asp:Label ID="Label2" runat="server" Text="时间："></asp:Label><asp:Label ID="lbl_sj" runat="server" ></asp:Label>  |
            <asp:Label ID="Label3" runat="server" Text="发布人："></asp:Label><asp:Label ID="lbl_fbr" runat="server" ></asp:Label> |
            <asp:Label ID="Label4" runat="server" Text="发布部门："></asp:Label><asp:Label ID="lbl_fbbm" runat="server" ></asp:Label>
            </p>
       </div>
       <div class="content" style="height:300px;" > 
            <p style="text-indent: 24pt;width:800px;margin:0 auto;"  >
                <asp:Label ID="lbl_detail" runat="server" style="font-size:16px;width:800px;word-break:break-all;word-spacing:2px;"></asp:Label>
            </p>
         
       </div>
   </div>
        </form>
</asp:Content>
