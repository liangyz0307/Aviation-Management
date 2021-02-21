<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_YGXX.aspx.cs" Inherits="CUST.WKG.JS_YGXX" %>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>员工检索系统</title>
    <!--[if lt IE 9]>     
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
  <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"  />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />

    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
</head>
<body>
  <form id="form1" runat="server">
    <div >
        <div class="text-c" id="sblx" runat ="server">
        
            员工编号：
              <asp:TextBox ID="tbx_ygbh" runat="server" style="width:100px;height:25px;"></asp:TextBox>
            姓名：
            <asp:TextBox ID="tbx_xm" runat="server" style="width:100px;height:25px;"></asp:TextBox>
                性别：
           <asp:DropDownList ID="ddlt_xb" runat="server" class="select-box" Style="width: 100px" AutoPostBack="True" >
            </asp:DropDownList>
               政治面貌：
           <asp:DropDownList ID="ddlt_zzmm" runat="server" class="select-box" Style="width: 100px" AutoPostBack="True" >
            </asp:DropDownList>
              部门名称：
           <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 100px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_bmdm_SelectedIndexChanged">
            </asp:DropDownList>
            岗位名称：
              <asp:DropDownList ID="ddlt_gwdm" runat="server" class="select-box" Style="width: 100px">
           </asp:DropDownList>  
            <asp:Button ID="btn_cx" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_cx_Click"/>         
        </div>
          <div class="mt-20" id="dhsb"  runat ="server">
             <asp:Repeater ID="Repeater1" runat="server" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    员工列表
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="30"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                    姓名
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    员工编号
                                </th>
                               
                                  <th width="30"  style="text-align:center;vertical-align:middle;">
                                    性别
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    部门
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    岗位
                                </th>
                                 <th width="80"  style="text-align:center;vertical-align:middle;">
                                    联系方式
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
                              
                         <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="#60B1D7"   Font-Underline="true"      NavigateUrl='<%#"../JianSuo/JS_YGDetail.aspx?bh=" + Eval("bh")%>' Text='<%# Eval("XM") %>'></asp:HyperLink> 

                            </td>
                              <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("BH") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_sfzh" runat="server" Text='<%#Eval("xb") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("gwmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_zzmm" runat="server" Text='<%#Eval("lxdh") %>'></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
             
          </div>
          <table>
                <tr>
                    <td align="center" width="100%" >
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
  <script type="text/javascript" src="../src/jquery-1.11.2.js"></script>  
    <script type="text/javascript" src="../src/query.js"></script>  
    <script type="text/javascript" src="../src/paging.js"></script>   
    <script type="text/javascript" src="../src/require.js"></script>
       <%--         <div id="pageTool"></div>
		<div id="pageToolbar"></div>
		<script>
		    $('#pageTool').Paging(
            {
                pagesize:<%=psize%>, count: <%=zcount%>, callback: function (page, size, count)
                {
		        	console.log(arguments)
		        	alert('当前第 ' +page +'页,每页 '+size+'条,总页数：'+count+'页')
                }
            });
		$('#pageToolbar').Paging({pagesize:<%=psize%>,count:<%=zcount%>,toolbar:true});
		</script>
    </div>
    <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
          <script src="../css/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
  
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>--%>

</form>
</body>
</html>
