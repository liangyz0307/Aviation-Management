<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DYZXShowDetail.aspx.cs" Inherits="CUST.WKG.DYZXShowDetail" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<%--<!DOCTYPE html>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>党员在线详情</title>
      <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  />
       <script src="../css/js/jquery.js" type="text/javascript"></script>
     <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
            }    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
     <table>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              优秀党员： 
            
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
          
                 <asp:Label ID="lbl_yxdy" runat="server"></asp:Label>
            </td>
        </tr>      
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              部门： 
             
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                   
                 <asp:Label ID="lbl_bm" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                岗位： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_gw" runat="server"></asp:Label>
            </td>            
        </tr> 
          
          
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              主要事迹： 
                  </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                   <asp:Label ID="lbl_zysj" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              时间： 
                </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                  <asp:Label ID="lbl_sjmc" runat="server"></asp:Label>
            </td>
        </tr>
         <%-- <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              状态： 
                  </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                   <asp:Label ID="lbl_zt" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
              驳回原因： 
                  </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                   <asp:Label ID="lbl_bhyy" runat="server"></asp:Label>
            </td>
        </tr>--%>
    </table>
     <div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>      
                <td style="text-align:center"> &nbsp;&nbsp;
                     <asp:Button ID="btn_fh" runat="server" Text="返回" class="btn  radius"  BackColor="#990000" ForeColor="White"  Width="199px" OnClick="btn_fh_Click"  >
                     </asp:Button>
                </td>
            </tr>
        </table>
   </div>
        </form>
</asp:Content>
