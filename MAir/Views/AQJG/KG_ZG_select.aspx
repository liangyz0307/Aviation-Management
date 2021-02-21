<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KG_ZG_select.aspx.cs" Inherits="CUST.WKG.KG_ZG_select" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<style type="text/css">
    
    .auto-style4 {
        width: 13%;
    }
    .auto-style6 {
        width: 32%
    }
        
    .auto-style7 {
        left: 0;
        right: auto;
        width: 152px;
    }
        
    .auto-style11 {
        width: 8%;
    }
    .auto-style13 {
        width: 9%;
    }
        
    .auto-style14 {
        width: 10%;
    }
        
</style>

<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>   
     <script type="text/javascript" src="../../Content/js/jquery.js"></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>  
</head>       
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <div >
      <table>
        <tr>
<%--         <td align="left" width="5%" class="auto-style0">责任人：</td>
          <td style="width: 7%;" align="left">
             <asp:TextBox ID="tbx_zrr" runat="server" Style="width: 100px; height: 28px;"></asp:TextBox>
          </td>--%>
         <td align="left" class="auto-style11">问题来源：</td>
           <td style="width: 8%;" align="left"> 
               <asp:TextBox ID="tbx_wtly" runat="server" Style="width: 100px; height: 28px;"></asp:TextBox>
          <td align="left" class="auto-style0" style="width: 6%;">
            检查单：</td>
            <td style="text-align:left" class="auto-style11">            
            <asp:DropDownList ID="ddlt_jcd" runat="server" class="select-box" Style="width: 150px; height: 28px;" OnSelectedIndexChanged="ddlt_jcd_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList></td>
         <td align="left" class="auto-style13">
            整改项目：</td>
                    <td style="text-align:left" class="auto-style4">
            <asp:DropDownList ID="ddlt_zgxm" runat="server" class="select-box" Style="width: 150px; height: 28px;"  AutoPostBack="true">
               </asp:DropDownList></td>
          <td align="left" class="auto-style7" style="width: 6%;">
              状态：</td>
                    <td style="text-align:left" class="auto-style14">
              <asp:DropDownList ID="ddlt_zgzt" runat="server" class="select-box" Style="width: 70px; height: 28px;"  AutoPostBack="true">
            </asp:DropDownList>
          </td>
            <td align="left" class="auto-style6" width="10%">
                        整改时限：
             <asp:TextBox ID="tbx_zgsxks" runat="server" class="input-text" placeholder="开始日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="85px"></asp:TextBox>-<asp:TextBox ID="tbx_zgsxjs" runat="server" class="input-text" placeholder="截止日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" Width="85px"></asp:TextBox></td>   
             <td align="left" class="auto-style4">          
                <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_select_Click" />
                 <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7"/>
            </td>
          </tr>
         </table>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="400">
                                                                           长春保障部自查整改表
                                </th>
                            </tr>
                            <tr class="text-c">
                                 <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    责任人
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    检查单
                                </th>
                                <th width="15%"  style="text-align:center;vertical-align:middle;">
                                    整改项目
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    整改时限
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    问题来源
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   整改进度
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   问题类别
                                </th>
                                 <th width="10%" style="text-align: center; vertical-align: middle;">
                                     状态
                                 </th>
                                  <th width="15%">
                                      操作
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
                                    <%-- <asp:Label ID="Labe_sfr" runat="server" Text='<%#Eval("sfrxm") %>'></asp:Label>--%>
                                    <asp:HyperLink ID="hlnk_zrr" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"KG_ZGdetail.aspx?id=" + Eval("id")%>' Text='<%# Eval("zrrxm") %>'></asp:HyperLink> 

                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("jcdmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_zgxm" runat="server" Text='<%#Eval("zgxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_zgsx" runat="server" Text='<%#Eval("zgsxmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Labe_wtly" runat="server" Text='<%#Eval("wtly") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_zgjd" runat="server" Text='<%#Eval("zgjd") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_wtlb" runat="server" Text='<%#Eval("wtlb") %>'></asp:Label>
                                </td>
                             <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_byyx" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
                             </td>
                                <td class="td-manage">
                                 <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该惩罚信息？')">删除</asp:LinkButton>

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
                            <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged" />
                        </td>
                    </tr>
                </table>
        </div>
    </div>
         <asp:HiddenField ID="HF_yc" runat="server"/>
    <script type="text/javascript" src="../css/js/jquery.js"></script>

    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>

    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>
    <script type="text/javascript">
        //单个按钮驳回
        function rec() {
            var excuse;
            excuse = prompt("请输入驳回原因：");
            if (excuse == null)
            { return false; }
            else {
                document.getElementById("<%=HF_yc.ClientID %>").value = excuse;
                        }

                    }
    </script>

    <script src="../css/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script>
    </form>
     <p>
         -</p>
</body>
</html>
