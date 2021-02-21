<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="ZBJSShow_Index.aspx.cs" Inherits="CUST.WKG.ZBJSShow_Index" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>支部建设</title>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  /> 
     
</asp:Content>
   <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div style="background-color: #f2f9fd;">
        <div style="left:0px; margin-top: 0px; width: 20%; float: left; height:508px;background-color: #f2f9fd;">
             <h2><span class="icon-user"style="font-size:20px;">支部建设</span></h2>
            <h2><span class="icon-user"></span></h2>
            <ul style="display: block;background-color: #f2f9fd;">
                <li style="height: 27px;"><a id="A1" href="~/Views/DQZC/ZBJSShow.aspx?lx=1" target="right" runat="server">年度计划及总结</a></li>
                <li style="height: 27px;"><a id="A2" href="~/Views/DQZC/ZBJSShow.aspx?lx=2" target="right" runat="server">党员发展</a></li>
                <li style="height: 27px;"><a id="A3" href="~/Views/DQZC/ZBJSShow.aspx?lx=3" target="right" runat="server">廉政建设</a></li>
                <li style="height: 27px;"><a id="A4" href="~/Views/DQZC/ZBJSShow.aspx?lx=4" target="right" runat="server">组织生活会</a></li>
                <li style="height: 27px;"><a id="A5" href="~/Views/DQZC/ZBJSShow.aspx?lx=5" target="right" runat="server">党的知识</a></li>
            </ul>
        </div>

           
    
    <div class="admin" style="margin-top:0px;width: 70%;float:left; height: 272px;" >
         <iframe id="myFrame" rameborder="0" frameborder="no" style=" overflow-y:visible;width: 113%; height: 492px;" scrolling="visible"  name="right"  runat="server">
           
        </iframe>
      </div>
       
  </div>
</asp:Content>

