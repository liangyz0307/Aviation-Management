<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LL_Edit.aspx.cs" Inherits="CUST.WKG.LL_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

 <head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"/>
      <style type="text/css">
            td.td_sjsc
            {
                background:#F6FAFD;
              
            }    
    </style>
</head>
<body>
    <article class="page-container">
	<form id="Form1" runat="server" class="form form-horizontal">
	 <div class="panel-head" style="text-align:center">
            <strong class="icon-reorder">员工履历管理</strong>
      
        
         
        </div>
  <div> <asp:Button ID="btn_add"  runat="server"  class="btn  radius"  Text="添加履历" OnClick="btn_add_Click" ForeColor="White" BackColor="#60B1D7"/>

  </div>
        <br />
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                          <%--  <tr>
                                <th scope="col" colspan="16">
                                    员工履历列表
                                </th>
                            </tr>--%>
                            <tr class="text-c">
                               
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                               <%-- <th width="6%"  style="text-align:center;vertical-align:middle;">
                                   数据所属部门
                                </th>--%>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   工作单位
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                   工作部门
                                </th>
                                  
                                 <th width="6%"  style="text-align:center;vertical-align:middle;">
                                   工作岗位
                                </th>
                                 <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    工作地点
                                </th>
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    起止日期
                                </th>
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    截止日期
                                </th>
                                 <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th> 
                                 <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                </th>
                                  <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                 <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                                 <th width="14%"  style="text-align:center;vertical-align:middle;">
                                    操作
                                </th>
                              
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                           <%-- <td>
                                <asp:CheckBox ID="cbx_qxx" runat="server" />
                            </td>--%>
                            <td>
                                  <%#(cpage-1)*psize+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <%-- <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>--%>
                            <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("gzdw") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("gzbm") %>'></asp:Label>
                            </td>
                             
                             <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("gzgw") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("gzdd") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_gzdd" runat="server" Text='<%#Eval("qzrq") %>'></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lbl_gzdw" runat="server" Text='<%#Eval("jzrq") %>'></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lbl_lrr" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lbl_csr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lbl_zsr" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                              <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_byyx" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>
                             
                       <td class="td-manage">
                            <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr") +"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("id") + "&" + Eval("zt") + "&" + Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs")%>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id")+"&"+ Eval("zt")+"&"+ Eval("bmdm")+"&"+ Eval("lrr")+"&"+ Eval("csr")+"&"+ Eval("zsr")+"&"+ Eval("sjc")+"&"+ Eval("sjbs") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return confirm('您确定要删除该履历信息？')">删除</asp:LinkButton>
                              <%--  &nbsp;
                                <asp:LinkButton ID="lbtTjtz" CommandName="EditZT" CommandArgument='<%#Eval("id") %>'
                                    runat="server" OnClientClick="return confirm('您确定要提交该员工信息，提交之后将不可更改？')"><i class="Hui-iconfont">&#xe631;</i>提交</asp:LinkButton>--%>
                            </td>
                       
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        <br />
        <div id="edit"></div>
	<div style="text-align:center">
		<div>
		      
              &nbsp;  
              <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7" 
                Width="199px"  onclick="btn_fh_Click"></asp:Button>  
		</div>
	</div>
        <asp:HiddenField ID="HF_yc" runat="server"/>
	</form>
</article>
  
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


</body>


</html>
