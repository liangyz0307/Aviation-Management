<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_YJGL.aspx.cs" Inherits="CUST.WKG.JS_YJGL" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />
    <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;             
            }         
         .auto-style1 {
             width: 20%;
             height: 30px;
         }         
     </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_cxmk" style="text-align:center" runat="server" >
                   请选择查询模块：
            <asp:DropDownList ID="ddlt_cxmk" runat="server" CssClass="select-box" Style="width: 100px" AutoPostBack="true" OnSelectedIndexChanged="ddlt_cxmk_SelectedIndexChanged">
            </asp:DropDownList>
         </div>
    <div id="div_yagl" style="text-align:center" runat="server" >
      <div >
        <div class="text-c">
            名称：
             <asp:DropDownList ID="ddlt_mc_yagl" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
            地区：
            <asp:DropDownList ID="ddlt_dq_yagl" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
            专业：
            <asp:DropDownList ID="ddlt_zy_yagl" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
             状态：
            <asp:DropDownList ID="ddlt_zt_yagl" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
           
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White"
          OnClick="btn_selectYAGL_Click"/>
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater_yagl" runat="server"  OnItemDataBound="Repeater_YAGL_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="18">
                                    预案管理列表
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="2%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                    名称
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    地区
                                </th>
                                  <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    专业
                                </th>
                           
                                 <th width="20%"  style="text-align:center;vertical-align:middle;">
                                    预案内容
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">                    
                            <td>
                              <%#(cpage_yagl-1)*psize_yagl+(Container.ItemIndex + 1)%>
                            </td>
                       
                            <td >
                                <asp:HyperLink ID="hlnk_yagl_edit" runat="server" ForeColor="#60B1D7" Style="text-decoration: underline" NavigateUrl='<%#"YAGL_Detail_JS.aspx?id=" + Eval("id")%>' Text='<%# Eval("mc") %>'></asp:HyperLink>
                            </td>
                            
                         
                             <td >
                                <asp:Label  runat="server" Text='<%# Eval("zxdm") %>'></asp:Label>
                            </td>
                             <td >
                                <asp:Label  runat="server" Text='<%#Eval("zylx") %>'></asp:Label>
                            </td>
                              <td  >                         
                                  <asp:Label ID="Label1"  runat="server" Text='<%#GetCut(Eval("yanr").ToString().Trim(),20) %>' ToolTip ='<%#Eval("yanr")%>'></asp:Label>
                           </td>
                                <td >
                                <asp:Label ID="Label2"  runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                            </td>
                                <td >
                                <asp:Label ID="Label3"  runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>
                                <td >
                                <asp:Label ID="Label4"  runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                                <td >
                                <asp:Label ID="Label5"  runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label ID="lbl_zt_yagl"  runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
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
                        <td align="center" width="100%">
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_yagl_PageChanged" />
                        </td>
                    </tr>
                </table>
        </div>
    </div>  
    </div>
        <%--演练管理--%>
        <div id="div_ylgl" style="text-align:center" runat="server" >
       <div>
        <div class="text-c" >
            地区：
            <asp:DropDownList ID="ddlt_dq_ylgl" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
            预案名：
              <asp:DropDownList ID="ddlt_yam_ylgl" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>  
            演练形式：
             <asp:DropDownList ID="ddlt_ylxs_ylgl" runat="server" class="select-box" Style="width: 100px">
             </asp:DropDownList>           
             状态：
            <asp:DropDownList ID="ddlt_zt_ylgl" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White"
                OnClick="btn_selectYLGL_Click" />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater_ylgl" runat="server"  OnItemDataBound="Repeater_YLGL_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    演练列表
                                </th>
                            </tr>
                            <tr class="text-c">
                             
                              
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                    预案名
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    演练时间
                                </th>
                                 <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    支线名称
                                </th>
                                  <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    演练形式
                              <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                              <%#(cpage_ylgl-1)*psize_ylgl+(Container.ItemIndex + 1)%>
                            </td>
                            <td>
                                <asp:HyperLink ID="YLGL_Edit" runat="server" ForeColor="#60B1D7" Style="text-decoration: underline" NavigateUrl='<%#"YLGL_Detail_JS.aspx?bh=" + Eval("bh")%>' Text='<%# Eval("yammc") %>'></asp:HyperLink>
                            </td>
                             <td>
                                <asp:Label runat="server" Text='<%#Eval("ylsjmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%#Eval("dqmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("ylxsmc") %>'></asp:Label>
                            </td>        
                            <td >
                                <asp:Label ID="Label2"  runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                            </td>
                                <td >
                                <asp:Label ID="Label3"  runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>
                                <td >
                                <asp:Label ID="Label4"  runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                                <td >
                                <asp:Label ID="Label5"  runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label ID="lbl_zt_ylgl"  runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
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
                    <td align="center" width="96%" >
                        <cc1:Pager ID="Pager1" runat="server" Width="96%" OnPageChanged="pg_ylgl_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
            </div>
    </form>
</body>
</html>
