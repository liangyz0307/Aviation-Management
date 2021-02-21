<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GWGL.aspx.cs" Inherits="CUST.WKG.GWGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
   <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
 
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
<div>
        <table>
       <tr>
           
           <td style="width:15%; " align="right">             
                部门：               
                  <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box"  Style="width: 100px"  AutoPostBack="true"  >
                 </asp:DropDownList>
           </td>
           <td style="width:15%; " align="right">
                岗位代码：
              
                <asp:TextBox ID="tbx_gwdm" runat="server" style="width:100px;height:24px;"></asp:TextBox>
           </td>
           <td style="width:15%; " align="right">
               岗位名称：
              <asp:TextBox ID="tbx_gwmc" runat="server" style="width:80px;height:24px;"></asp:TextBox>
           </td>
         
           <td style="width:20%; " align="right">
                 类别：
              <asp:DropDownList ID="ddlt_bmlb" runat="server" class="select-box" Style="width: 150px" ></asp:DropDownList>                      
           </td>   
             <td style="width:15%; " align="right">                 
               状态：              
                 <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px" ></asp:DropDownList>
           </td>        
           <td  align="center">
               <asp:Button ID="btn_select" runat="server" class="btn  radius"  Text="查询" ForeColor="White" BackColor="#60B1D7" OnClick="btn_select_Click" />
               &nbsp;
               <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7"/>
           </td> 
     </tr>
</table>        
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    岗位列表
                                </th>
                            </tr>
                            <tr class="text-c">                             
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                    部门
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    岗位
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    类别
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>                              
                                <th width="100">
                                    操作
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                  <%#(cpage - 1) * psize + (Container.ItemIndex + 1)%>
                            </td>
                            <td>                                 
                             <asp:HyperLink ID="hlnk_gw" runat="server"    ForeColor="#60B1D7"   style="TEXT-DECORATION:underline"    NavigateUrl='<%#"GW_Edit.aspx?gwdm=" + Eval("gwdm")%>' Text='<%# Eval("gw") %>'></asp:HyperLink> 
                            </td>
                            <td>
                             <asp:Label ID="lbl_bm" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                               <td>
                                    <asp:Label ID="lbl_bmlb" runat="server" Text='<%#Eval("bmlb") %>'></asp:Label>
                            </td>
                             <td>
                               <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("gwdm") %>' ForeColor="Blue"  Font-Underline="true" 
                                runat="server" OnClientClick="return confirm('您确定要删除该岗位信息？')">删除</asp:LinkButton>                              
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
                    <td align="center" width="100%" background="../images/menuFunction.gif">
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
</div>

<%--    <script type="text/javascript" src="../lib/jquery/1.9.1/jquery.min.js"></script>

    <script type="text/javascript" src="../lib/layer/2.1/layer.js"></script>

    <script type="text/javascript" src="../lib/laypage/1.2/laypage.js"></script>

    <script type="text/javascript" src="../lib/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript" src="../lib/datatables/1.10.0/jquery.dataTables.min.js"></script>

    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>--%>

    <%--<script type="text/javascript">
        /*用户-添加*/
        function member_add(title, url, w, h) {
            layer_show(title, url, w, h);
        }
        /*用户-查看*/
        function member_show(title, url, id, w, h) {
            layer_show(title, url, w, h);
        }
        /*工作日志-提交*/
        function member_stop(obj, id) {
            layer.confirm('确认要提交吗？', function (index) {
                //UpdateYGRZByID(id);
                $(obj).parents("tr").find(".td-status").html('<span class="label label-defaunt radius">已提交</span>');
                $(obj).remove();
                layer.msg('已提交!', { icon: 5, time: 1000 });
            });
        }
        /*工作日志-编辑*/
        function member_edit(title, url, id, w, h) {
            layer_show(title, url, w, h);
        }
        /*密码-修改*/
        function change_password(title, url, id, w, h) {
            layer_show(title, url, w, h);
        }
        /*工作日志-删除*/
        function member_del(obj, id) {
            layer.confirm('确认要删除吗？', function (index) {
                //DeleteYGRZByID(id);
                $(obj).parents("tr").remove();
                layer.msg('已删除!', { icon: 1, time: 1000 });
            });
        }
</script>--%>

    </form>
</body>
</html>
