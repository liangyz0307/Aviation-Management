<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BS_SG.aspx.cs" Inherits="CUST.WKG.BS_SG" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>事故报送</title>
     <script src="../../Content/js/jquery.js"></script>
     <script src="../../Content/js/lhgcalendar/lhgcalendar.js"></script>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
     <link href="../../Content/css/h-ui.admin/css/H-ui.admin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div class="text-c"  style="text-align: center; width: 100%; margin: 0 auto;" >
           报送岗位：
             <asp:DropDownList ID="ddlt_bsgw" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
            报送员工：
             <asp:TextBox ID="tbx_bsyg" runat="server" Width="128px"></asp:TextBox>
          发生时间
          <asp:TextBox ID="tbx_kssj" runat="server" Width="100px" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>--<asp:TextBox ID="tbx_jssj" onclick="lhgcalendar({format:'yyyy-MM-dd'})" runat="server" Width="100px"></asp:TextBox>
          状态：
           <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px"> </asp:DropDownList> 
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click"/>
            &nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" BackColor="#60B1D7" ForeColor="White" Visible="true" OnClick="btn_add_Click" />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater" runat="server" OnItemCommand="Repeater_ItemCommand" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="18">
                                    事故
                                </th>
                            </tr>
                            <tr>
                                <th width="30"  style="text-align:left;">
                                    序号
                                </th>
                                <th width="70"  style="text-align:left;">
                                    员工编号
                                </th>
                                <th width="70"  style="text-align:left;">
                                    员工姓名
                                </th>
                                <th width="90"  style="text-align:left;">
                                    事发时间
                                </th>
                                <th width="100"  style="text-align:left;">
                                   事故详情
                                </th>
                                 <th width="70"  style="text-align:left;">
                                    事故负责人
                                </th>
                              
                                  <th width="60"  style="text-align:left;">
                                   状态
                                </th>
                                <th width="70">
                                    操作
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                           
                            <td>
                                  <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                            
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("bh") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"  Font-Underline="true"        NavigateUrl='<%#"BSSG_Detail.aspx?bsbh=" + Eval("bsbh")%>' Text='<%# Eval("xm") %>'></asp:HyperLink> 
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("sfsjlx") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("sgxq") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("fzrxm") %>'></asp:Label>
                            </td>
                           
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                            <td class="td-manage">
                               <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("bsbh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("id") %>' ForeColor="blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("bsbh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("id") %>' ForeColor="blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("bsbh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("id") %>' ForeColor="blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("bsbh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("id") %>' ForeColor="blue" style="text-decoration:underline"
                                    runat="server">编辑</asp:LinkButton>
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("bsbh")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("id") %>' ForeColor="blue" style="text-decoration:underline"
                                    runat="server" OnClientClick="return confirm('您确定要删除该报送信息？')">删除</asp:LinkButton>
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
                    <td align="center" width="100%" >
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
