<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_BJDetail.aspx.cs" Inherits="CUST.WKG.JS_BJDetail" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <script src="../css/js/jquery.js" type="text/javascript"></script>

    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
    <style type="text/css">
        td.td_sjsc
            {
                background:#F6FAFD;
              
            }    
         .overlay
          {  
              background-color:#000;  
              opacity: .7;  
              filter:alpha(opacity=70);  
              position: fixed;  
              top:0;  
              left:0;  
              width:100%;  
              height:100%;  
              z-index: 10; 
              overflow:scroll; 
            
          }  
    </style>
</head>
<body>
   <article >
<form id="Form1" runat="server" class="form form-horizontal">
  
      <table  width="100%"  align="center"   cellspacing="0" cellpadding="0"  id="t_qx" runat="server">
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>备件详细信息</strong> 
            </td>
        </tr> 
            <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          备件编号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_bjbh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
           备件名称： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_bjmc" runat="server"></asp:Label>
            </td>
        </tr>

     <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
          设备型号： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_sbxh" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          备件分类： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_bjfl" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
         板件中文名称： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc"
                >
     
                <asp:Label ID="lbl_bjzwmc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc"
                >
          内含组件： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"
                >
              
                <asp:Label ID="lbl_nhzj" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               内含组件名称： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_nhzjmc" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                英文名称：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_ywmc" runat="server"></asp:Label>
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               原机数量： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_yjsl" runat="server"></asp:Label>
                <br />
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                板件识别号：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_bjsbh" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件适用： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_bjsy" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                现有备件数量：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                <asp:Label ID="lbl_xybjsl" runat="server"></asp:Label>
            </td>
        </tr>
                <tr style="vertical-align: top;  width:100%;height:30px; border:1px solid #C0D9D9;" >
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               存放位置： 
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                <asp:Label ID="lbl_cfwz" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              
            </td>
        </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;height:60px;" class="td_sjsc"  colspan="3">    
                <asp:Label ID="lbl_bz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    
      <table>
                                                   <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                 <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     数据所属部门：</td>
                 <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_shjsbmmc" runat="server" ></asp:Label>
                    </td>              
                <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     录入人：</td>
                 <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_lrr" runat="server" ></asp:Label>
                    </td>              
            </tr> 
                    <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     初审人：</td>
                <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_csr" runat="server" ></asp:Label>
                    </td>              

               <td style="width: 20%; text-align: right; vertical-align: middle; height: 30px;" class="td_sjsc">
                     终审人：</td>
                 <td style="width: 30%; text-align: left; vertical-align: middle; height: 30px;" class="td_sjsc">
                   <asp:Label ID="lbl_zsr" runat="server" ></asp:Label>
                    </td>              
            </tr>  
        </table>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>备件出库信息</strong> 
            </td>
        </tr> 
          <asp:Repeater ID="Repeater_ck" runat="server"  >
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">备件出库列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="20" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件名称
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件分类
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件适用
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">出库经办人
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">库房负责人
                                    </th>

                                    <th width="50" style="text-align: center; vertical-align: middle;">出库数量
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">出库时间
                                    </th>
                                    <th width="30" style="text-align: center; vertical-align: middle;">状态
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">  
                               <td>
                                     <%#(cpage_ck-1)*psize_ck+(Container.ItemIndex + 1)%>                           
                                </td> 
                               <td> 
                    <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"   style="TEXT-DECORATION:underline"    NavigateUrl='<%#"JS_BJ_CK_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("bjmc") %>'></asp:HyperLink> 
                               </td>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sfzh" runat="server" Text='<%#Eval("bjfl_mc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_xb" runat="server" Text='<%#Eval("bjsy_mc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("jbrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_csrq" runat="server" Text='<%#Eval("fzrxm") %>'></asp:Label>
                                </td>
                                
                                 <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("cksl") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("cksjz") %>'></asp:Label>
                                </td>
                                <td title='<%# Eval("bhyy") %>'>
                                    <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                                </td>
                               
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
    </table>
                <table>
                <tr>
                    <td   align="center" width="100%" >
                        <cc1:Pager ID="pg_fy_ck" runat="server" Width="95%" OnPageChanged="pg_fy_PageChanged_ck" />
                    </td>
                </tr>
            </table>
     <asp:Table  ID="tab_ck" style="Z-INDEX: 104; LEFT: 35px;  TOP: 89px" runat="server" BackColor="#F6FAFD"   GridLines="Both" BorderColor="#C0D9D9" BorderStyle="Dotted" BorderWidth="1px" CellPadding="0" CellSpacing="0"   Width="100%" runat="server">
     
  </asp:Table>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: center;font-size:larger; vertical-align: middle;" class="td_sjsc" colspan="4" >
              <strong>备件入库信息</strong> 
            </td>
        </tr> 
           <asp:Repeater ID="Repeater_rk" runat="server"  >
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">备件入库列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="20" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件名称
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件分类
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件适用
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">入库经办人
                                    </th>
                                     <th width="60" style="text-align: center; vertical-align: middle;">库房负责人
                                    </th>
                                    
                                    <th width="50" style="text-align: center; vertical-align: middle;">入库数量
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">入库时间
                                    </th>
                                    <th width="30" style="text-align: center; vertical-align: middle;">状态

                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">  
                               <td>
                                     <%#(cpage_rk-1)*psize_rk+(Container.ItemIndex + 1)%>                           
                                </td> 
                               <td> 
                    <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"   style="TEXT-DECORATION:underline"    NavigateUrl='<%#"JS_BJ_RK_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("bjmc") %>'></asp:HyperLink> 
                               </td>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sfzh" runat="server" Text='<%#Eval("bjfl_mc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_xb" runat="server" Text='<%#Eval("bjsy_mc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("jbrxm") %>'></asp:Label>
                                </td>
                                   <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("fzrxm") %>'></asp:Label>
                                </td>
                              
                                 <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("rksl") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("rksjz") %>'></asp:Label>
                                </td>
                                 <td title='<%# Eval("bhyy") %>'>
                                    <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
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
                    <td  style="text-align:center;width:100%">
                        <cc1:Pager ID="pg_fy_rk" runat="server" Width="95%" OnPageChanged="pg_fy_PageChanged_rk" />
                    </td>
                </tr>
            </table>
    </table>

    <asp:Table  ID="tab_rk" style="Z-INDEX: 104; LEFT: 35px;  TOP: 89px" runat="server" BackColor="#F6FAFD"   GridLines="Both" BorderColor="#C0D9D9" BorderStyle="Dotted" BorderWidth="1px" CellPadding="0" CellSpacing="0"   Width="100%" runat="server">
     
  </asp:Table>

	 <div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
                <td style="text-align:center">
                     <asp:Button ID="btn_back" runat="server"  Text="返回" class="btn radius"   BackColor="#60B1D7" ForeColor="White" Width="199px" OnClick="btn_back_Click"  >

                     </asp:Button>
                </td>
            </tr>
        </table>
	</div>
        <script type="text/javascript" src="../css/js/jquery.js"></script>
    <script type="text/javascript" src="../static/h-ui/js/H-ui.js"></script>
        
    <script type="text/javascript" src="../static/h-ui.admin/js/H-ui.admin.js"></script>
</form>
</article>
    
</body>
</html>
