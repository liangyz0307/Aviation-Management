<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SKJS_AQYHK.aspx.cs" Inherits="CUST.WKG.SKJS_AQYHK" %>
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
        td.td_sjsc {
            background: #F6FAFD;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div>
      <div class="text-c"   style="text-align: center; width: 100%; margin: 0 auto;">
             填表人编号:
             <asp:TextBox ID="tbx_ygbh" runat="server" style="width:100px;height:24px;" ></asp:TextBox> 
            隐患等级:
            <asp:DropDownList ID="ddlt_yhdj" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
            来源:
            <asp:DropDownList ID="ddlt_ly" runat="server" Style="width: 100px"  Height="24px"></asp:DropDownList>
                               状态:
              <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px" >
            </asp:DropDownList>
            填表日期:
             <asp:TextBox ID="tbx_tbrq_ks" runat="server" style="width:80px;height:24px;" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
           <asp:TextBox ID="tbx_tbrq_js" runat="server" style="width:80px;height:24px;" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
               
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click" />
            &nbsp;
            <asp:Button ID="btn_add" runat="server" class="btn radius" Text="添加" BackColor="#60B1D7" ForeColor="White" Visible="true" OnClick="btn_add_Click" />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"  OnItemDataBound="Repeater1_ItemDataBound"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="23">
                                    安全隐患库
                                </th>
                            </tr>
                            <tr>
                                 <th width="30"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    填报单位
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    隐患发现时间
                                </th>
                              
                                 <th width="80"  style="text-align:center;vertical-align:middle;">
                                   整改完成时限
                                </th>
                                  <th width="80"  style="text-align:center;vertical-align:middle;">
                                   整改验证人
                                 </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                </th>
                                  <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th> 
                              <th width="40"  style="text-align:center;vertical-align:middle;">
                                   状态
                                </th>
                                <th width="160"style="text-align:center;vertical-align:middle;">
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
                                <asp:HyperLink ID="hlnk_tbdw" runat="server" ForeColor="#60B1D7" Style="text-decoration: underline" NavigateUrl='<%#"SKJS_AQYHK_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("tbdwmc") %>'></asp:HyperLink>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("yhfxsjz") %>'></asp:Label>
                            </td>

                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("zgwcsxz") %>'></asp:Label>
                            </td>
                            <td>
                            <asp:Label  runat="server" Text='<%#Eval("zgyzr") %>'></asp:Label>
                            </td>

                            <td>
                             <asp:Label ID="lbl_fzr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                              <asp:Label ID="Label1" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                             <td>
                              <asp:Label ID="Label2" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>  
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>

                            <td class="td-manage">

                               <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs" )%>' ForeColor="#60B1D7"  style="text-decoration:underline"
                                    runat="server" >提交</asp:LinkButton>
                               <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="#60B1D7"  style="text-decoration:underline"
                                    runat="server" >审核</asp:LinkButton>
                               <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="#60B1D7"  style="text-decoration:underline"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                               <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs" )%>' ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClientClick="return confirm('您确定要修改该信息？')">修改</asp:LinkButton>

                               <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="#60B1D7" style="text-decoration:underline"
                                    runat="server" OnClientClick="return confirm('您确定要删除该信息？')">删除</asp:LinkButton>
                          
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
                    <td align="center" width="98%" >
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged"  />
                    </td>
                </tr>
            </table>
        </div>
    </div>
     <asp:HiddenField ID="HF_yc" runat="server"/>
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
                        else {
                            document.getElementById("<%=HF_yc.ClientID %>").value = excuse;
                        }
                          
    }
            
</script>
    </form>
</body>
</html>
