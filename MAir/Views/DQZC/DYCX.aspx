<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DYCX.aspx.cs" Inherits="CUST.WKG.DYCX" %>

<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>党员管理</title>
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css" />
     <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css"  /> 
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
   
       <div >
        <div>
           姓 名：
             <asp:TextBox ID="txb_xm" runat="server" style="width:80px;height:24px;"></asp:TextBox>
             
           政治面貌：
              <asp:DropDownList ID="ddlt_zzmmdm" runat="server" class="select-box" Style="width: 80px; height: 28px;"  AutoPostBack="true">
            </asp:DropDownList>
           
            状 态：
              <asp:DropDownList ID="ddlt_zt" runat="server" class="select-box" Style="width: 80px; height: 28px;"  AutoPostBack="true">
            </asp:DropDownList>
            <tr style="vertical-align: top;  width:500%;height:20px;  border:1px solid #C0D9D9;" class="td_sjsc">
            <td style=" width:30%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   入党时间：<span class="c-red"></span></td>
                <td style=" width:25%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="txb_jrdzzsj" runat="server" class="input-text" style="width:100px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>--  <asp:TextBox ID="txb_jrdzzsj1" runat="server" class="input-text" style="width:100px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                   <%-- <asp:Label ID="lbl_jrdzzsj" runat="server" ></asp:Label></td>--%>
            </tr>
            <td style=" width:25%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   转正时间：<span class="c-red"></span></td>
                <td style=" width:80%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                      <asp:TextBox ID="txb_zwzsdyrq" runat="server" class="input-text" style="width:100px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>--  <asp:TextBox ID="txb_zwzsdyrq1" runat="server" class="input-text" style="width:100px" placeholder="日期" onclick="lhgcalendar({format:'yyyy-MM-dd'})" 
                 ></asp:TextBox>
                     &nbsp;&nbsp; 部 门：
             <asp:DropDownList ID="ddlt_bmdm" runat="server" class="select-box" Style="width: 100px; height: 28px;">
            </asp:DropDownList></td>
                   <%-- <asp:Label ID="lbl_zwzsdyrq" runat="server" ></asp:Label></td>   --%>
            <asp:Button ID="btn_select" runat="server" style="right" class="btn  radius"  Text="查询" ForeColor="White" BackColor="#ab2025"
                OnClick="btn_select_Click" />
            &nbsp;&nbsp;
             <asp:Button ID="btn_add" runat="server" class="btn  radius" Text="添加" OnClick="btn_add_Click" ForeColor="White" BackColor="#ab2025"/>        
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover  table-sort">
                        <thead>
                           <tr>
                                <th scope="col" colspan="16">
                                    党员信息查询
                                </th>
                            </tr>
                            <tr class="text-c">
                              
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                   姓名
                                </th>
                                  <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    公民身份证号
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    性别
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   出生日期
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                   学历
                                </th>
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   政治面貌
                                </th>
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   入党时间
                                </th>
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   转正时间
                                </th>
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                   联系电话
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                   状态
                                </th>
                                <th width="45%">
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
                                   
                                    <asp:HyperLink ID="hlnk_xm" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"DYGL_Detail.aspx?bh=" + Eval("bh")%>' Text='<%# Eval("xm") %>'></asp:HyperLink> 

                                </td>
                             <td>
                                <asp:Label ID="Labe_sfzh" runat="server" Text='<%#Eval("sfzh") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="Labe_xbdm" runat="server" Text='<%#Eval("xbdmmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_csrq" runat="server" Text='<%#Eval("csrqmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_xldm" runat="server" Text='<%#Eval("xldmmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_zzmmdm" runat="server" Text='<%#Eval("zzmmdmmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_jrdzzsj" runat="server" Text='<%#Eval("jrdzzsjmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_zwzsdyrq" runat="server" Text='<%#Eval("zwzsdyrqmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_lxdh" runat="server" Text='<%#Eval("lxdh") %>'></asp:Label>
                            </td>
                            <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                                </td>
      
                          <td class="td-manage">
                                 <asp:LinkButton ID="lbt_tj" CommandName="Update_TJ" CommandArgument='<%#Eval("bh")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >提交</asp:LinkButton>
                                 <asp:LinkButton ID="lbt_sh" CommandName="Update_SH" CommandArgument='<%#Eval("bh")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >审核</asp:LinkButton>
                                <asp:LinkButton ID="lbt_bh" CommandName="Update_BH" CommandArgument='<%#Eval("bh")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" OnClientClick="return rec()">驳回</asp:LinkButton>
                                <asp:LinkButton ID="lbtEdit" CommandName="Edit" CommandArgument='<%#Eval("bh")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
                                    runat="server" >编辑</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("bh")+"&"+ Eval("zt") %>' ForeColor="Blue"  Font-Underline="true"
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
                    <td  style="text-align :center;width:100%"  >
                        <cc1:Pager ID="pg_fy" runat="server" Width="98%"  OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
      </div>
    </div>
  
         <asp:HiddenField ID="HF_yc" runat="server"/>
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
         <script src="../../Content/js/jquery.js" type="text/javascript"></script>
        <script src="../../Content/js/lhgcalendar/lhgcalendar.js" type="text/javascript"></script> 
       
        </form>
   
</asp:Content>

