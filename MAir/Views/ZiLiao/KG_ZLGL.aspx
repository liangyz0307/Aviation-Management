<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KG_ZLGL.aspx.cs" Inherits="CUST.WKG.KG_ZLGL" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <title>资料管理</title>
    <script src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
   <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>     
</head>
<body>
     <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div >
         <table><tr>
               <td style="width:20%; " align="left">
               资料类型：
             <asp:DropDownList ID="ddlt_zllx1" runat="server" height="30px" style="width:80px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_zllx1_SelectedIndexChanged"></asp:DropDownList>
             <asp:DropDownList ID="ddlt_zllx2" runat="server" height="30px" Style="width: 80px" ></asp:DropDownList>
                上传时间：
          <asp:TextBox ID="tbx_kssj" runat="server" style="width:100px;height:28px;" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>-
 <asp:TextBox ID="tbx_jssj"  runat="server" style="width:100px;height:28px;" onclick="lhgcalendar({format:'yyyy-MM-dd'})"
                            Width="100px" MaxLength="10" Enabled="True"></asp:TextBox>                              
                    <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_select_Click" />
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7"/>
               
                   </td>
          </tr>
             <tr> <td style="width:16%; " align="right">
              </td>
             </tr>

         </table> 
         
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    资料管理列表
                                </th>
                            </tr>
                            <tr class="text-c">
                                 <th width="5%" style="width:20px; vertical-align:middle;">序号
                                    </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                    资料名
                                </th>
                                   <th width="30"  style="text-align:center;vertical-align:middle;">
                                    资料大类
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    资料小类
                                </th>
                                <th width="50"  style="text-align:center;vertical-align:middle;">
                                    上传时间
                                </th>
                                 <th width="30"  style="text-align:center;vertical-align:middle;">
                                    上传用户
                                </th>
                                 <th width="40"  style="text-align:center;vertical-align:middle;">
                                    上传用户部门
                                </th>
                                 <th width="40"  style="text-align:center;vertical-align:middle;">
                                    岗位
                                </th>  
                                 <th width="40" style="text-align:center;vertical-align:middle;">数据所属部门
                                    </th>
                                <th width="40" style="text-align:center;vertical-align:middle;">状态
                                    </th>
                                    <th width="40">操作
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                         <tr>
                            <td>                               
                                  <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                            </td>
                              <td>
                                  <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue" Font-Underline="true" CommandName="down" CommandArgument='<%#Eval("zt")+"&"+ Eval("id")+"&"+Eval("zlm")+"&"+ Eval("wjlj")+"&"+ Eval("bmdm") %>' Text='<%# Eval("zlm") %>'></asp:LinkButton>
                            
                            </td>
                             <td>
                                <asp:Label ID="Label_zllx1" runat="server" Text='<%#Eval("zllx1mc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label_zllx2" runat="server" Text='<%#Eval("zllx2mc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_sj" runat="server" Text='<%#Eval("scsjmc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("yhxm") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Label_bm" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label_gw" runat="server" Text='<%#Eval("gwmc") %>'></asp:Label>
                            </td>
                                  <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("sjssbm") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                                <td class="td-manage">
                                    <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%# Eval("zt")+"&"+ Eval("id")+"&"+ Eval("zlm")+"&"+ Eval("wjlj")+"&"+Eval("bmdm") %>' ForeColor="blue" Style="text-decoration: underline"
                                    runat="server">提交</asp:LinkButton>
                                    <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%# Eval("zt")+"&"+ Eval("id")+"&"+ Eval("zlm")+"&"+ Eval("wjlj")+"&"+Eval("bmdm") %>' ForeColor="blue" Style="text-decoration: underline"
                                    runat="server">审核</asp:LinkButton>
                                    <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%# Eval("zt")+"&"+ Eval("id")+"&"+ Eval("zlm")+"&"+ Eval("wjlj")+"&"+Eval("bmdm") %>' ForeColor="blue" Style="text-decoration: underline"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                    <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%# Eval("zt")+"&"+ Eval("id")+"&"+Eval("zlm")+"&"+ Eval("wjlj")+"&"+ Eval("bmdm") %>' ForeColor="blue" Style="text-decoration: underline"
                                    runat="server" OnClientClick="return confirm('您确定要删除该信息？')">删除</asp:LinkButton>
                            </td>
                        </tr>
                        </tr>
                    </>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <table>
                    <tr>
                        <td align="center" width="98%">
                            <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:HiddenField ID="HF_yc" runat="server" />
        <script type="text/javascript" src="../css/js/jquery.js"></script>
        <script type="text/javascript" src="../../Content/js/H-ui.js"></script>
        <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>
        <script type="text/javascript">  
        //单个按钮驳回
    function rec() {
                        var excuse;
                        excuse = prompt("请输入驳回原因：");
                        if (excuse == null)
                        { return false; }
                        else {1
                            document.getElementById("<%=HF_yc.ClientID %>").value = excuse;
                        }       
    }
            var login_syr = document.getElementById('login_syr');  //弹出层中的登录框
            var login_wxyr = document.getElementById('login_wxry');
            var over = document.getElementById('over'); //弹出层
            function show_syr() {
                login_syr.style.display = "block";
                over.style.display = "block";
            }
            function show_wxry() {
                login_wxry.style.display = "block";
                over.style.display = "block";
            }
            function btn_bc_syr() {
                btn_syr.style.display = "block";
            }
            $("#btn_bc_syr").click(function () {
                hide();
            });
            function hide() {
                login.style.display = "none";
                over.style.display = "none";
            }
        </script>
    </form>
</body>
</html>
