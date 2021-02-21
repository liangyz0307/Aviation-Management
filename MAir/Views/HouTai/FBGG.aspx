<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FBGG.aspx.cs" Inherits="CUST.WKG.FBGG" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
    <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>

    <script type="text/javascript" src="../lib/respond.min.js"></script>

    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <script src="../../Content/js/jquery.js" type="text/javascript"></script>
     <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script> 
 
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
       <table>           
           <tr>
               <td style="width:5%; "></td>
               <td style="width:16%; " align="left">公告类型：<asp:DropDownList ID="ddlt_gglx" Style="width: 150px" class="select-box"  runat="server">
                   </asp:DropDownList>
               </td>
               <td style="width:16%; " align="left">标题：
               <asp:TextBox ID="tbx_bt" runat="server"  Width="150px" Height="23px"></asp:TextBox></td>
               <td style="width:22%; " align="left">发布时间：
                     <asp:TextBox ID="tbx_sj1" runat="server" class="input-text" placeholder="开始时间" 
                 Width="98px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
                <span style="padding:0 5px;">-</span>
                   <asp:TextBox ID="tbx_sj2" runat="server" class="input-text" placeholder="结束时间" 
                 Width="98px" onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="8"></asp:TextBox>
               <td style="width:10%; " align="center"><asp:Button ID="btn_select" runat="server" Text="查询" class="btn  radius" ForeColor="White" BackColor="#60B1D7" OnClick="btn_select_Click"/>&nbsp;
                  <asp:Button ID="btn_add" runat="server" Text="添加" class="btn  radius" ForeColor="White" BackColor="#60B1D7" OnClick="btn_add_Click" /></td>
           </tr>
       </table>
       <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    公告信息
                                </th>
                            </tr>
                            <tr class="text-c">
                              
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                    类型
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    标题
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    接收部门
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
                            <%--<td>
                                <asp:CheckBox ID="cbx_qxx" runat="server" />
                            </td>--%>
                            <td>
                                  <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                            
                            </td>
                            <td>
                                <asp:Label ID="lbl_lx" runat="server" Text='<%#Eval("lxmc") %>'></asp:Label>
                            </td>
                            <td>
                               <asp:HyperLink ID="lbl_bt" runat="server" ForeColor="#60B1D7"   style="TEXT-DECORATION:underline"  NavigateUrl='<%#"FBGG_Detail.aspx?id="+Eval("id")%>'  Text='<%#Eval("bt") %>'></asp:HyperLink> 
                            </td>
                                <td>
                                <asp:Label ID="lbl_jsbm" runat="server" Text='<%#Eval("jsbmmc") %>'></asp:Label>
                            </td>
                           <td class="td-manage">
                                
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' ForeColor="Blue"  Font-Underline="true" 
                                    runat="server" OnClientClick="return confirm('您确定要删除该公告信息？')">删除</asp:LinkButton>
                              
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
    </form>
    <script type="text/javascript" src="../lib/jquery/1.9.1/jquery.min.js"></script>

    <script type="text/javascript" src="../lib/layer/2.1/layer.js"></script>

    <script type="text/javascript" src="../lib/laypage/1.2/laypage.js"></script>

    <script type="text/javascript" src="../lib/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript" src="../lib/datatables/1.10.0/jquery.dataTables.min.js"></script>

    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>

      <script  src="../css/js/jquery.js" type="text/javascript"></script>
        <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    <script type="text/javascript">
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
</script>
</body>
</html>
