<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="ZBJS_Index.aspx.cs" Inherits="CUST.WKG.ZBJS_Index" %>
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
        <div style="left:0px; margin-top: 0px; width: 20%; float: left; height:588px;background-color: #f2f9fd;" >
        

             <h2><span class="icon-user"style="font-size:20px; align-content:center" >支部建设</span></h2>
            <h2><span class="icon-user"></span></h2>
            <ul >
                <li style="height: 27px;"><a id="A1" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=1" target="right" runat="server" style="align-content:center">年度计划及总结</a></li>
                <li style="height: 27px;"><a id="A2" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=2" target="right" runat="server">党员发展</a></li>
                <li style="height: 27px;"><a id="A3" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=3" target="right" runat="server">廉政建设</a></li>
                <li style="height: 27px;"><a id="A4" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=4" target="right" runat="server">组织生活会</a></li>
                <li style="height: 27px;"><a id="A5" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=5" target="right" runat="server">党的知识</a></li>
                <li style="height: 27px;"><a id="A6" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=6" target="right" runat="server">党内相关规章制度</a></li>
                <li style="height: 27px;"><a id="A7" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=7" target="right" runat="server">党建报告</a></li>
                <li style="height: 27px;"><a id="A8" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=8" target="right" runat="server">年度计划及总结</a></li>
                <li style="height: 27px;"><a id="A9" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=9" target="right" runat="server">党风廉政建设</a></li>
                <li style="height: 27px;"><a id="A10" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=10" target="right" runat="server">组织生活会</a></li>
                <li style="height: 27px;"><a id="A11" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=11" target="right" runat="server">民主生活会</a></li>
                <li style="height: 27px;"><a id="A12" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=12" target="right" runat="server">新闻报道</a></li>
                <li style="height: 27px;"><a id="A13" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=13" target="right" runat="server">思想动态调查</a></li>
                <li style="height: 27px;"><a id="A14" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=14" target="right" runat="server">换届选举</a></li>
                <li style="height: 27px;"><a id="A15" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=15" target="right" runat="server">党员发展及推优评选</a></li>
                <li style="height: 27px;"><a id="A16" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=16" target="right" runat="server">党员培训档案</a></li>
                <li style="height: 27px;"><a id="A17" href="~/Views/DQZC/DQZC_ZBJS.aspx?lx=17" target="right" runat="server">支部其他重要文件</a></li>
               
            </ul>
        </div>

           
    
    <div class="admin" style="margin-top:0px;width: 70%;float:left; height: 272px;" >
         <iframe id="myFrame" rameborder="0" frameborder="no" style=" overflow-y:visible;width: 113%; height: 492px;" scrolling="visible"  name="right"  runat="server">
           
        </iframe>
      </div>
       
  </div>
</asp:Content>

