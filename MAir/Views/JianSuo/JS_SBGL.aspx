<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_SBGL.aspx.cs" Inherits="CUST.WKG.JS_SBGL" %>
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
            td.td_sjsc
            {
                background:#F6FAFD;
              
            } 
         
         .auto-style1 {
             width: 20%;
             height: 30px;
         }
         
     </style>
</head>
<body>
    <form id="form1" runat="server">

   <div id="div_cxmk" style="text-align:center" runat="server" >
                   请选择查询模块：
            <asp:DropDownList ID="ddlt_cxmk" runat="server" CssClass="select-box" Style="width: 100px" AutoPostBack="true" OnSelectedIndexChanged="ddlt_cxmk_SelectedIndexChanged">
            </asp:DropDownList>
         </div>

        <%--导航设备--%>
        <div id="div_dhsb" style="text-align:center" runat="server" >
            <div >
                <div class="text-c">
                    设备型号：
                    <asp:TextBox ID="tbx_sbxh_dhsb" runat="server" style="width:100px;height:25px;" MaxLength="10"></asp:TextBox>
                    设备类型：
                    <asp:DropDownList ID="ddlt_sblx_dhsb" runat="server" class="select-box" Style="width: 100px">
                    </asp:DropDownList>
                    台站名称种类：
                    <asp:DropDownList ID="ddlt_tzmczl_tzmc" runat="server" class="select-box" Style="width: 100px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlt_tzmczl_wz" runat="server" class="select-box" Style="width: 100px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlt_tzmczl_sblx" runat="server" class="select-box" Style="width: 100px">
                    </asp:DropDownList>
                </div>
                <div class="text-c">
                所属机场：
                <asp:DropDownList ID="ddlt_yssjc" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
                校飞到期日期：
                <asp:TextBox ID="tbx_jfdqrq" runat="server" style="width:100px;height:24px;"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" MaxLength="10"></asp:TextBox>
                            <asp:Label ID="lbl_jfdqrq" runat="server"></asp:Label>
                <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White"
                OnClick="btn_SelectDHSB_Click" />
            </div>
                <div class="mt-20">
                    <asp:Repeater ID="Repeater_dhsb" runat="server" OnItemDataBound="Repeater_DHSB_ItemDataBound">
                    <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    导航设备列表
                                </th>
                            </tr>
                            <tr class="text-c">                            
                                <th width="70"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="180"  style="text-align:center;vertical-align:middle;">
                                    设备型号
                                </th>
                                <th width="180"  style="text-align:center;vertical-align:middle;">
                                    所属台站名称
                                </th>
                                  <th width="190"  style="text-align:center;vertical-align:middle;">
                                    所属机场
                                </th>
                                    <th width="190"  style="text-align:center;vertical-align:middle;">
                                    设备类型
                                </th>
                                <th width="180"  style="text-align:center;vertical-align:middle;">
                                    校飞周期
                                </th>
                              <th width="180"  style="text-align:center;vertical-align:middle;">
                                    校飞到期日期
                                </th>
                              <th width="70" style="text-align: center; vertical-align: middle;">
                                  初审人
                               </th>
                               <th width="70" style="text-align: center; vertical-align: middle;">
                                   终审人
                               </th>
                               <th width="70" style="text-align: center; vertical-align: middle;">
                                   录入人
                               </th>
                               <th width="180"  style="text-align:center;vertical-align:middle;">
                                   状态
                               </th>                           
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">                          
                            <td>
                                  <%#(cpage_dhsb-1)*psize_dhsb+(Container.ItemIndex + 1)%>                           
                            </td>
                            <td>
                                  <asp:HyperLink ID="sbxh_mc" runat="server" ForeColor="Blue"   style="TEXT-DECORATION:underline"  NavigateUrl='<%#"DHSB_Detail_JS.aspx?id="+Eval("id")%>'  Text='<%#Eval("sbxh") %>'></asp:HyperLink> 
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%#Eval("sstz_mc") %>'></asp:Label>
                            </td>
                         
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("yssjc_mc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("sblxmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("jfzq") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("jfdqrqz") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_csr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_zsr" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_lrr" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label id="lbl_zt_dhsb" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
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
                        <cc1:Pager ID="pg_dhsb" runat="server" Width="98%" OnPageChanged="pg_dhsb_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
            </div>
        </div>


        <%--通信设备--%>
        <div id="div_txsb" style="text-align:center" runat="server" >
            <div>
                <div class="text-c">
                所属机场：
               <asp:DropDownList ID="ddlt_ssjc_txsb" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
                位置：
                 <asp:DropDownList ID="ddlt_wz_txsb" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
                设备类型：
               <asp:DropDownList ID="ddlt_sblx_txsb" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
               状态：
               <asp:DropDownList ID="ddlt_zt_txsb" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
               <asp:Button ID="Button3" runat="server" class="btn  radius" Text="查询"   BackColor="#60B1D7" ForeColor="White"   OnClick="btn_SelectTXSB_Click" />
            </div>
                <div class="mt-20">
                <asp:Repeater ID="Repeater_txsb" runat="server"  OnItemDataBound="Repeater_TXSB_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">设备列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="60" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">设备编号
                                    </th>
                                    <th width="100" style="text-align: center; vertical-align: middle;">台站名称
                                    </th>
                                    <th width="100" style="text-align: center; vertical-align: middle;">所属机场
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">设备状态
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">数据所属部门
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">初审人
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">终审人
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">调拨时间
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">录入人
                                    </th>
                                    <th width="40" style="text-align: center; vertical-align: middle;">设备保管人
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">状态
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">
                                <td>
                                    <%#(cpage_txsb-1)*psize_txsb+(Container.ItemIndex + 1)%>
                                </td>
                                <td>
                                    <asp:HyperLink ID="hlnk_sbbh" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"TXSB_Detail_JS.aspx?id=" + Eval("id")%>' Text='<%# Eval("sbbh") %>'></asp:HyperLink> 
                                </td>
                                <td>
                                    <asp:Label ID="lbl_tzmcmc" runat="server" Text='<%#Eval("tzmcmc")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_ssjcmc" runat="server" Text='<%#Eval("ssjcmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sbzt" runat="server" Text='<%#Eval("sbztmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sjssbm" runat="server" Text='<%#Eval("sjssbmmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_csr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_zsr" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_dbsj" runat="server" Text='<%#Eval("dbsj") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_lrr" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sbbgrxm" runat="server" Text='<%#Eval("sbbgrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_zt_txsb" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
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
                            <cc1:Pager ID="pg_txsb" runat="server" Width="98%" OnPageChanged="pg_txsb_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
            </div>
        </div>

        <%--气象设备--%>
        <div id="div_qxsb" style="text-align:center" runat="server">
            <div>
                <div class="text-c">
                 出厂编号：
             <asp:TextBox ID="tbx_ccbh" runat="server" Style="width: 80px;height:24px;"></asp:TextBox>
                 运行情况：
                <asp:DropDownList ID="ddlt_yxqk" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
                 设备状态：
                <asp:DropDownList ID="ddlt_sbzt" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
                 设备用途：
                <asp:DropDownList ID="ddlt_sbyt" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
                 所属支线：
               <asp:DropDownList ID="ddlt_sszx" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
                 检定方式：
               <asp:DropDownList ID="ddlt_jdfs" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
               <td  style="width:7%">状态：</td>
               <td  style="width:13%"> 
               <asp:DropDownList ID="ddlt_zt_qxsb" runat="server" class="select-box" Style="width: 80px; height: 28px;" >
            </asp:DropDownList></td>
                <asp:Button ID="Button5" runat="server" class="btn  radius" Text="查询"   BackColor="#60B1D7" ForeColor="White"   OnClick="btn_SelectQXSB_Click" />
            </div>
                <div class="mt-20">
                <asp:Repeater ID="Repeater_qxsb" runat="server" OnItemDataBound="Repeater_QXSB_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>                                  
                                <tr>
                                    <th scope="col" colspan="16">气象设备列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                     <th width="60" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">设备名称
                                    </th>                                    
                                    <th width="60" style="text-align: center; vertical-align: middle;">启用时间
                                    </th>
                                    <th width="40" style="text-align: center; vertical-align: middle;">运行情况
                                    </th>
                                    <th width="40" style="text-align: center; vertical-align: middle;">设备状态
                                    </th>
                                    <th width="40" style="text-align: center; vertical-align: middle;">设备用途
                                    </th>
                                    <th width="40" style="text-align: center; vertical-align: middle;">所属支线
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">出厂编号
                                    </th>
                                     <th width="40"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                     <th width="30"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th>
                                     <th width="30"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                     <th width="30"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                <th width="30" style="text-align: center; vertical-align: middle;">状态
                                </th>     
                              </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">                                                                         
                                <td>
                                      <%#(cpage_qxsb-1)*psize_qxsb+(Container.ItemIndex + 1)%>
                                </td>
                                <td>
                    <asp:HyperLink ID="hlnk_sbmc" runat="server" ForeColor="Blue"  style="TEXT-DECORATION:underline" NavigateUrl='<%#"QXSB_Detail_JS.aspx?id=" + Eval("id")%>' Text='<%# Eval("sbmc") %>'></asp:HyperLink> 
                    </td>
                                
                                <td>
                                    <asp:Label ID="lbl_qysj" runat="server" Text='<%#Eval("qysj") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_yxqk" runat="server" Text='<%#Eval("yxqkmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sbzt" runat="server" Text='<%#Eval("sbztmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sbyt" runat="server" Text='<%#Eval("sbytmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sszx" runat="server" Text='<%#Eval("sszxmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_ccbh" runat="server" Text='<%#Eval("ccbh") %>'></asp:Label>
                                </td> 
                                <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                            </td>
                                <td>
                                <asp:Label ID="lbl_lrr" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>  
                                 <td>
                                 <asp:Label ID="lbl_csr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_zsr" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>                               
                            <td>
                                <asp:Label  ID="lbl_zt_qxsb" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
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
                            <cc1:Pager ID="pg_qxsb" runat="server" Width="98%" OnPageChanged="pg_qxsb_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
            </div>
        </div>

        <%--台站管理--%>
        <div id="div_tzgl" runat="server">
            <div >
        <div class="text-c">
           
            台站名称：
              <asp:DropDownList ID="ddlt_jc_tzgl" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>  
               <asp:DropDownList ID="ddlt_wz_tzgl" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
               <asp:DropDownList ID="ddlt_sblx_tzgl" runat="server" class="select-box" Style="width: 100px">
            </asp:DropDownList>
            房屋信息：
             <asp:TextBox ID="tbx_fwxx_tzgl" runat="server" style="width:100px;height:25px;" MaxLength="10"></asp:TextBox>
             状态：
            <asp:DropDownList ID="ddlt_zt_tzgl" runat="server" class="select-box" Style="width: 100px">
                </asp:DropDownList>
            <td  style="width:6%"  align="center">
            <asp:Button ID="Button1" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_SelectTZGL_Click" />
                  </td>
              
        </div>
        
        <div class="mt-20">
            <asp:Repeater ID="Repeater_tzgl" runat="server" OnItemDataBound="Repeater_TZGL_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="20">
                                    台站设备列表
                                </th>
                            </tr>
                            <tr class="text-c">
                             
                              
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    台站名称
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                  <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    房屋信息
                                </th>
                           
                                 <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    楼层
                                </th>
                              
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    房间号
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    结构
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    竣工时间
                                </th>
                                 <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    台站位置信息
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    机房输入线路情况
                                </th>
                               <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    机房总输出
                                </th>
                               <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    台站温度是否达标
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                               
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                           
                            <td>
                                  <%#(cpage_tzgl-1)*psize_tzgl+(Container.ItemIndex + 1)%>
                            
                            </td>
                            <td>
                                 <asp:Label  runat="server" Text='<%#Eval("jcmc")+" "+ Eval("wz")+" "+ Eval("sblxmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("fwxx") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("lc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("fjh") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("jg") %>'></asp:Label>
                            </td>
                           </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("jgsj") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("tzwzxx") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("jfsrxlqk") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("jfzsc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("tzwdsfdbmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_zt_tzgl" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
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
                        <cc1:Pager ID="pg_tzgl" runat="server" Width="98%" OnPageChanged="pg_tzgl_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
        </div>

        <%--备件管理--%>
        <div  id="div_bjgl" runat="server">
            <div class="text-c">
                备件编号：
             <asp:TextBox ID="tbx_sbbh_bjgl" runat="server" Style="width: 80px;height:26px" MaxLength="12"></asp:TextBox>
                备件名称：
               <asp:TextBox ID="tbx_sbmc_bjgl" runat="server" Style="width: 80px;height:26px" MaxLength="50"></asp:TextBox>

               设备型号：
                   <asp:TextBox ID="tbx_sbxh_bjgl" runat="server" Style="width: 80px;height:26px" MaxLength="10"></asp:TextBox>
                 备件分类：
               <asp:DropDownList ID="ddlt_bjfl_bjgl" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
                 适用：
               <asp:DropDownList ID="ddlt_sy_bjgl" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
            <td style="width:4%; " align="left">
                   状态：
             <asp:DropDownList ID="ddlt_zt_bjgl" runat="server" class="select-box" Style="width: 80px; height: 28px;" >
            </asp:DropDownList></td>
                <asp:Button ID="Button2" runat="server" class="btn  radius" Text="查询"   BackColor="#60B1D7" ForeColor="White"   OnClick="btn_SelectBJGL_Click" />
            </div>
            <div class="mt-20">
                <asp:Repeater ID="Repeater_bjgl" runat="server" OnItemDataBound="Repeater_BJGL_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">备件列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="40" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件编号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件名称
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">设备型号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件分类
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">板件中文名称
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">数据所属部门
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">初审人
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">终审人
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">录入人
                                    </th>
                                  <th width="80" style="text-align: center; vertical-align: middle;">状态
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">
                                <td>
                                    <%#(cpage_bjgl-1)*psize_bjgl+(Container.ItemIndex + 1)%>
                                  
                                </td>
                            <td>
                          <asp:HyperLink ID="hlnk_bjbh" runat="server"    ForeColor="Blue"  style="TEXT-DECORATION:underline"      NavigateUrl='<%#"BJ_Detail_JS.aspx?id=" + Eval("id")%>' Text='<%# Eval("BJBH") %>'></asp:HyperLink> 
                              </td>
                                  <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("BJMC") %>'></asp:Label>
                                </td>
                             
                                <td>
                                    <asp:Label ID="lbl_sbxh" runat="server" Text='<%#Eval("SBXH") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bjfl" runat="server" Text='<%#Eval("bjflmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_xb" runat="server" Text='<%#Eval("BJZWMC") %>'></asp:Label>
                                </td>
                                <td>
                                <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td> 


                                <td>
                                 <asp:Label ID="lbl_csr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_zsr" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                            </td>
                                <td>
                                <asp:Label ID="lbl_lrr" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                            </td> 

                            <td>
                                <asp:Label ID="lbl_zt_bjgl" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
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
                            <cc1:Pager ID="pg_bjgl" runat="server" Width="98%" OnPageChanged="pg_bjgl_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 

        <%--备件出库--%>
        <div  id="div_bjck" runat="server">
<%--          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> --%>

            <div>
         <div>
             <table style="width:100%;text-align:left">
                 <tr style="width:100%">
                     <td style="width:7%;letter-spacing:3px"> 备件名称：</td>
                     <td style="width:13%"><asp:DropDownList ID="ddlt_bjmc_bjck" runat="server" class="select-box" Style="width: 95%;height:26px">
               </asp:DropDownList></td>
                     <td style="width:7%;letter-spacing:3px">  备件分类：</td>
                     <td style="width:13%"><asp:DropDownList ID="ddlt_bjfl_bjck" runat="server" class="select-box" Style="width: 95%;height:26px">
               </asp:DropDownList></td>
                      <td style="width:7%;letter-spacing:3px">开始时间：</td>
                     <td style="width:13%"> <asp:TextBox ID="tbx_kssj_bjck" runat="server"  class="Wdate"    Height="26px" Width="95%"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox></td>
                     <td style="width:7%;letter-spacing:3px">结束时间：</td>
                     <td style="width:13%"> <asp:TextBox ID="tbx_jssj_bjck" runat="server"  class="Wdate" Width="95%"   Height="26px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox></td>
                         <td style="width:20%;text-align:left">&nbsp;<asp:Button ID="Button4" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7"  ForeColor="White"  OnClick="btn_SelectBJCK_Click" /></td>
                   </tr>
                 <tr>
                    <td style="width:7%"> 经办人部门：</td>
                     <td style="width:13%">
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate> 
                          <asp:DropDownList ID="ddlt_jbrbm_bjck" runat="server" class="select-box" Style="width: 95%;height:26px" OnSelectedIndexChanged="ddlt_jbrbm_SelectedIndexChanged_bjck"  AutoPostBack="True">
               </asp:DropDownList>
                        </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:7%"> 经办人岗位：</td>
                     <td style="width:13%"> 
                          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate> 
                          <asp:DropDownList ID="ddlt_jbrgw_bjck" runat="server" class="select-box" Style="width: 95%;height:26px">
                      </asp:DropDownList>
                        </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:7%">负责人部门：</td>
                     <td style="width:13%"> 
                         <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                  <ContentTemplate> 
                           <asp:DropDownList ID="ddlt_fzrbm_bjck" runat="server" class="select-box" Style="width:  95%;height:26px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_fzrbm_SelectedIndexChanged_bjck">
               </asp:DropDownList>
                        </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:7%">负责人岗位：</td>
                     <td style="width:13%">
                          <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                  <ContentTemplate> 
                          <asp:DropDownList ID="ddlt_fzrgw_bjck" runat="server" class="select-box" Style="width: 95%;height:26px">
                       </asp:DropDownList>
                         </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:20%"></td>
                 </tr>
                 <tr>
                     <td style="width:7%;letter-spacing:3px">  备件适用：</td>
                     <td  style="width:13%"> <asp:DropDownList ID="ddlt_bjsy_bjck" runat="server" class="select-box" Style="width: 95%;height:26px">
                     </asp:DropDownList></td>
                     <td  style="width:7%">出库经办人：</td>
                     <td  style="width:13%"><asp:TextBox ID="tbx_jbr_bjck" runat="server" Style="width: 95%;height:26px;" MaxLength="10"></asp:TextBox></td>
                     <td style="width:7%">库房负责人：</td>
                     <td  style="width:13%"><asp:TextBox ID="tbx_fzr_bjck" runat="server" Style="width: 95%;height:26px;" MaxLength="10"></asp:TextBox></td>
                    <td  style="width:7%">状态：</td>
                    <td  style="width:13%"> 
             <asp:DropDownList ID="ddlt_zt_bjck" runat="server" class="select-box" Style="width: 95%; height: 28px;" >
            </asp:DropDownList></td>
                      </tr>
             </table>
            </div>
        <div class="mt-20">
                <asp:Repeater ID="Repeater_bjck" runat="server" OnItemDataBound="Repeater_BJCK_ItemDataBound" >
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">备件出库列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="40" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="90" style="text-align: center; vertical-align: middle;">备件名称
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件分类
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">备件适用
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">出库经办人
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">库房负责人
                                    </th>
                                      <th width="60" style="text-align: center; vertical-align: middle;">数据所在部门
                                    </th>
                                      <th width="50" style="text-align: center; vertical-align: middle;">录入人
                                    </th>
                                     <th width="60" style="text-align: center; vertical-align: middle;">初审人
                                    </th>
                                     <th width="60" style="text-align: center; vertical-align: middle;">终审人
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">出库数量
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">出库时间
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">状态
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">  
                               <td>
                                     <%#(cpage_bjck-1)*psize_bjck+(Container.ItemIndex + 1)%>                           
                                </td> 
                               <td> 
                    <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"   style="TEXT-DECORATION:underline"    NavigateUrl='<%#"BJCK_Detail_JS.aspx?id=" + Eval("id")%>' Text='<%# Eval("bjmc") %>'></asp:HyperLink> 
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
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_jg" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("cksl") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("cksjz") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_zt_bjck" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
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
                    <td   align="center" width="100%" >
                        <cc1:Pager ID="pg_bjck" runat="server" Width="95%" OnPageChanged="pg_bjck_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
        </div>

        <%--备件入库--%>
        <div  id="div_bjrk" runat="server">
<%--            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager> --%>
        <div >
         <div >
                <table style="width:100%;text-align:left">
                 <tr style="width:100%">
                     <td style="width:7%;letter-spacing:3px">备件名称：</td>
                     <td style="width:13%"><asp:DropDownList ID="ddlt_bjmc_bjrk" runat="server" class="select-box" Style="width: 95%;height:26px"> </asp:DropDownList></td>
                     <td style="width:7%;letter-spacing:3px">备件分类：</td>
                     <td style="width:13%"><asp:DropDownList ID="ddlt_bjfl_bjrk" runat="server" class="select-box" Style="width: 95%;height:26px"></asp:DropDownList></td>
                         <td style="width:7%;letter-spacing:3px">开始时间：</td>
                     <td style="width:13%"><asp:TextBox ID="tbx_kssj_bjrk" runat="server"  class="Wdate"  Width="95%"   Height="26px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox></td>
                         <td style="width:7%;letter-spacing:3px">结束时间：</td>
                     <td style="width:13%"><asp:TextBox ID="tbx_jssj_bjrk" runat="server"  class="Wdate"  Width="95%"   Height="26px"  onclick="lhgcalendar({format:'yyyy-MM-dd'})" ></asp:TextBox></td>
                       <td style="width:20%;text-align:left">
                       &nbsp;<asp:Button ID="Button6" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7"  ForeColor="White"  OnClick="btn_SelectBJRK_Click" />
                     </td>
                      </tr>
                         <tr style="width:100%">
                       <td style="width:7%">经办人部门：</td>
                     <td style="width:13%">
                           <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                  <ContentTemplate> 
                         <asp:DropDownList ID="ddlt_jbrbm_bjrk" runat="server" class="select-box" Style="width: 95%;height:26px" OnSelectedIndexChanged="ddlt_jbrbm_SelectedIndexChanged_bjrk" AutoPostBack="True"></asp:DropDownList>
                           </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:7%">经办人岗位：</td>
                     <td style="width:13%">
                           <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                  <ContentTemplate> 
                         <asp:DropDownList ID="ddlt_jbrgw_bjrk" runat="server" class="select-box" Style="width: 95%;height:26px">
                      </asp:DropDownList>
                         </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:7%">负责人部门：</td>
                     <td style="width:13%">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                  <ContentTemplate> 
                         <asp:DropDownList ID="ddlt_fzrbm_bjrk" runat="server" class="select-box" Style="width: 95%;height:26px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_fzrbm_SelectedIndexChanged_bjrk"> </asp:DropDownList>
                         </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:7%">负责人岗位：</td>
                     <td style="width:13%">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                  <ContentTemplate> 
                         <asp:DropDownList ID="ddlt_fzrgw_bjrk" runat="server" class="select-box" Style="width: 95%;height:26px"></asp:DropDownList>
                            </ContentTemplate>
               </asp:UpdatePanel>
                     </td>
                     <td style="width:20%;text-align:left"></td>
                  </tr>
                      <tr style="width:100%">
                       <td style="width:7%;letter-spacing:3px">备件适用：</td>
                     <td style="width:13%"><asp:DropDownList ID="ddlt_bjsy_bjrk" runat="server" class="select-box" Style="width: 95%;height:26px"></asp:DropDownList></td>
                     <td style="width:7%">入库经办人：</td>
                     <td style="width:13%"><asp:TextBox ID="tbx_jbr_bjrk" runat="server" Style="width:95%;height:26px;" MaxLength="10"></asp:TextBox></td>
                     <td style="width:7%">库房负责人：</td>
                     <td style="width:13%"><asp:TextBox ID="tbx_fzr_bjrk" runat="server" Style="width:95%;height:26px;" MaxLength="10"></asp:TextBox></td>
                    <td  style="width:7%">状态：</td>
                             <td  style="width:13%"> 
             <asp:DropDownList ID="ddlt_zt_bjrk" runat="server" class="select-box" Style="width: 80px; height: 28px;" >
            </asp:DropDownList></td>
                      </tr>
             </table>
            </div>
        <div class="mt-20">
                <asp:Repeater ID="Repeater_bjrk" runat="server" OnItemDataBound="Repeater_BJRK_ItemDataBound" >
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
                                     <th width="60" style="text-align: center; vertical-align: middle;">数据所在部门
                                    </th>
                                      <th width="50" style="text-align: center; vertical-align: middle;">录入人
                                    </th>
                                     <th width="60" style="text-align: center; vertical-align: middle;">初审人
                                    </th>
                                     <th width="60" style="text-align: center; vertical-align: middle;">终审人
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">入库数量
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">入库时间
                                    </th>
                                    <th width="30" style="text-align: center; vertical-align: middle;">状态
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">  
                               <td>
                                     <%#(cpage_bjrk-1)*psize_bjrk+(Container.ItemIndex + 1)%>                           
                                </td> 
                               <td> 
                    <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"   style="TEXT-DECORATION:underline"    NavigateUrl='<%#"BJRK_Detail_JS.aspx?id=" + Eval("id")%>' Text='<%# Eval("bjmc") %>'></asp:HyperLink> 
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
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("bmmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_csrq" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_jg" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("rksl") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("rksjz") %>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_zt_bjrk" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
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
                        <cc1:Pager ID="pg_bjrk" runat="server" Width="95%" OnPageChanged="pg_bjrk_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
    </div> 
    </div>

        <%--设备故障--%>
        <div  id="div_sbgz" runat="server">
<%--            <asp:ScriptManager ID="ScriptManager3" runat="server"></asp:ScriptManager> --%>
        <div>
            <table style="width:100%;text-align:left">

                <tr style="width:100%">
                    <td style="width:7%;letter-spacing:3px">设备编号：</td>
            <td style="width:14%"> <asp:TextBox ID="tbx_sbbh_sbgz" runat="server" Style="width: 95%;height:26px;"></asp:TextBox></td>
                    
                    <td style="width:7%;letter-spacing:3px">
                         设备类型：</td>
                    <td style="width:14%">
                         <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                         <ContentTemplate>
                        <asp:DropDownList ID="ddlt_sblx_sbgz" runat="server" class="select-box" Style="width:  95%;height:26px" OnSelectedIndexChanged="ddlt_sblx_SelectedIndexChanged_sbgz" AutoPostBack="True">
               </asp:DropDownList>
                                </ContentTemplate>
                         </asp:UpdatePanel>

                    </td>
                    <td style="width:7%;">设备种类：</td>
                    <td style="width:14%"> 
                          <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                         <ContentTemplate>
                        <asp:DropDownList ID="ddlt_sbzl_sbgz" runat="server" class="select-box" Style="width:  95%;height:26px">
               </asp:DropDownList>
                        </ContentTemplate>
                         </asp:UpdatePanel>
                    </td>
                    <td style="width:16%">   &nbsp;<asp:Button ID="Button7" runat="server" class="btn  radius" Text="查询"   BackColor="#60B1D7" ForeColor="White"   OnClick="btn_SelectSBGZ_Click" />
               </td>
                </tr>
                <tr>
                    <td style="width:7%;">维修人：</td>
                    <td style="width:14%"> <asp:TextBox ID="tbx_wxr_sbgz" runat="server" Style="width:  98%;height:26px;"></asp:TextBox></td>
                    
                    <td style="width:7%;">维修人部门：</td>
                    <td style="width:14%"> 
                           <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                         <ContentTemplate>
                         <asp:DropDownList ID="ddlt_wxrbm_sbgz" runat="server" class="select-box" Style="width:  95%;height:26px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_whrbm_SelectedIndexChanged_sbgz">
               </asp:DropDownList>
                                 </ContentTemplate>
                         </asp:UpdatePanel>
                    </td>
                    <td style="width:7%;">  维修人岗位：</td>
                    <td  style="width:14%">
                         <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                         <ContentTemplate>
                         <asp:DropDownList ID="ddlt_wxrgw_sbgz" runat="server" class="select-box" Style="width:  95%;height:26px">
                           </asp:DropDownList>
                           </ContentTemplate>
                         </asp:UpdatePanel>
                    </td>                   
                </tr>
            </table>
            <div class="mt-20">
                <asp:Repeater ID="Repeater_sbgz" runat="server" OnItemDataBound="Repeater_SBGZ_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">设备故障列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="5%" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">设备编号
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">设备种类
                                    </th>
                                      <th width="8%" style="text-align: center; vertical-align: middle;">设备类型
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">维修人
                                    </th>
                                     <th width="7%" style="text-align: center; vertical-align: middle;">维修人部门
                                    </th>
                                     <th width="7%" style="text-align: center; vertical-align: middle;">维修人岗位
                                    </th>
                                    <th width="7%" style="text-align: center; vertical-align: middle;">累计时长
                                    </th>
                                      <th width="7%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                    <th width="7%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th>
                                <th width="7%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                <th width="7%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                <th width="7%"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">
                               
                                <td>
                                    <%#(cpage_sbgz-1)*psize_sbgz+(Container.ItemIndex + 1)%>
                                  
                                </td>
                                       <td>
                    <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="Blue"  style="TEXT-DECORATION:underline"      NavigateUrl='<%#"SBGZ_Detail_JS.aspx?id=" + Eval("id") %>' Text='<%# Eval("SBBH") %>'></asp:HyperLink> 
           
                    </td>
                             
                                <td>
                                    <asp:Label ID="lbl_xm" runat="server" Text='<%#Eval("SBZLMC") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sfzh" runat="server" Text='<%#Eval("SBLXMC") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_xb" runat="server" Text='<%#Eval("wxr") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("wxrbmmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("wxrgwmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_csrq" runat="server" Text='<%#Eval("LJSC") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                                </td>
                                <td>
                                <asp:Label ID="lbl_zt_sbgz" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
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
                            <cc1:Pager ID="pg_sbgz" runat="server" Width="98%" OnPageChanged="pg_sbgz_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        </div>

        <%--设备维护--%>
        <div  id="div_sbwh" runat="server">
<%--         <asp:ScriptManager ID="ScriptManager4" runat="server"></asp:ScriptManager> --%>
        <div>
            <table style="width:100%;text-align:left">
                <tr style="width:100%">
                    <td style="width:6%;">设备编号：</td>
            <td style="width:12%"> <asp:TextBox ID="tbx_sbbh_sbwh" runat="server" Style="width: 95%;height:26px;"></asp:TextBox></td>
                    <td style="width:6%;">设备类型：</td>
                    <td style="width:12%">
                          <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                         <ContentTemplate>
                        <asp:DropDownList ID="ddlt_sblx_sbwh" runat="server" class="select-box" Style="width:  95%;height:26px" OnSelectedIndexChanged="ddlt_sblx_SelectedIndexChanged_sbwh" AutoPostBack="True">
               </asp:DropDownList>
                             </ContentTemplate>
                         </asp:UpdatePanel>  
                             </td>
                    <td style="width:6%;">设备种类：</td>
                    <td style="width:12%"> 
                         <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                         <ContentTemplate>
                        <asp:DropDownList ID="ddlt_sbzl_sbwh" runat="server" class="select-box" Style="width:  95%;height:26px">
               </asp:DropDownList>
                                </ContentTemplate>
                         </asp:UpdatePanel>  
                             </td>
                    
                  <td style="width:10%">&nbsp;<asp:Button ID="Button8" runat="server" class="btn  radius" Text="查询"   BackColor="#60B1D7" ForeColor="White"   OnClick="btn_SelectSBWH_Click" />
                </td>
                </tr>
                <tr>
                    <td style="width:6%;letter-spacing:4px">维护人：</td>
                    <td style="width:12%"> <asp:TextBox ID="tbx_whr_sbwh" runat="server" Style="width:  95%;height:26px;"></asp:TextBox></td>
                        <td style="width:6%;"> 维护状态：</td>
                    <td style="width:12%"><asp:DropDownList ID="ddlt_whzt_sbwh" runat="server" class="select-box" Style="width:  95%;height:26px">
               </asp:DropDownList></td>
                    <td style="width:8%;"> 维护人部门：</td>
                    <td style="width:12%"> 
                           <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                         <ContentTemplate>
                         <asp:DropDownList ID="ddlt_whrbm_sbwh" runat="server" class="select-box" Style="width:  95%;height:26px" AutoPostBack="True" OnSelectedIndexChanged="ddlt_whrbm_SelectedIndexChanged_sbwh">
               </asp:DropDownList>
                                 </ContentTemplate>
                         </asp:UpdatePanel>
                    </td>
                    <td style="width:8%;">  维护人岗位：</td>
                    <td  style="width:12%">
                         <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                         <ContentTemplate>
                         <asp:DropDownList ID="ddlt_whrgw_sbwh" runat="server" class="select-box" Style="width:  95%;height:26px">
                           </asp:DropDownList>
                           </ContentTemplate>
                         </asp:UpdatePanel>
                    </td>                   
                </tr>
            </table>
            <div class="mt-20">
                <asp:Repeater ID="Repeater_sbwh" runat="server" OnItemDataBound="Repeater_SBWH_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">设备维护列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="60" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">设备编号
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">设备种类
                                    </th>
                                      <th width="80" style="text-align: center; vertical-align: middle;">设备类型
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">维护人
                                    </th>
                                     <th width="80" style="text-align: center; vertical-align: middle;">维护人部门
                                    </th>
                                     <th width="80" style="text-align: center; vertical-align: middle;">维护人岗位
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">维护状态
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">维护时间
                                    </th>
                                 

                                    <th width="50" style="text-align: center; vertical-align: middle;">维护记录
                                    </th>
                                     <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    数据所属部门
                                </th>
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    录入人
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    初审人
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    终审人
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">
                               
                                <td>
                                    <%#(cpage_sbwh-1)*psize_sbwh+(Container.ItemIndex + 1)%>
                                  
                                </td>
                                       <td>
                    <asp:HyperLink ID="hlnk_xm" runat="server"    ForeColor="blue"  style="TEXT-DECORATION:underline"      NavigateUrl='<%#"SBWH_Detail_JS.aspx?id=" + Eval("id")%>' Text='<%# Eval("SBBH") %>'></asp:HyperLink> 
           
                    </td>
                             
                                <td>
                                    <asp:Label ID="lbl_xm" runat="server" Text='<%#Eval("SBZLMC") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sfzh" runat="server" Text='<%#Eval("SBLXMC") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_xb" runat="server" Text='<%#Eval("xm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bmdm" runat="server" Text='<%#Eval("whrbmmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_gwdm" runat="server" Text='<%#Eval("whrgwmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_csrq" runat="server" Text='<%#Eval("WHZTMC") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_jg" runat="server" Text='<%#Eval("whsjmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_xl"  title='<%# Eval("WHJL") %>'  style="word-break:break-all;" runat="server" Text='<%#Eval("WHJL") %>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                                </td>
                                <td >
                                <asp:Label ID="lbl_zt_sbwh" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
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
                            <cc1:Pager ID="pg_sbwh" runat="server" Width="98%" OnPageChanged="pg_sbwh_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        </div>

        <%--监视设备--%>
        <div id="div_jssb" style="text-align:center" runat="server" >
            <div>
            <div class="text-c">
                所属机场：
               <asp:DropDownList ID="ddlt_ssjc_jssb" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
                位置：
                 <asp:DropDownList ID="ddlt_wz_jssb" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
                设备类型：
               <asp:DropDownList ID="ddlt_sblx_jssb" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
               设备状态：
               <asp:DropDownList ID="ddlt_sbzt_jssb" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>
                <%-- 所属支线：
               <asp:DropDownList ID="ddlt_zxdm" runat="server" class="select-box" Style="width: 80px;height:26px">
               </asp:DropDownList>--%>
                <asp:Button ID="Button9" runat="server" class="btn  radius" Text="查询"   BackColor="#60B1D7" ForeColor="White"   OnClick="btn_SelectJSSB_Click" />
            </div>
            <div class="mt-20">
                <asp:Repeater ID="Repeater_jssb" runat="server" OnItemDataBound="Repeater_JSSB_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">设备列表
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="60" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">设备编号
                                    </th>
                                    <th width="100" style="text-align: center; vertical-align: middle;">台站名称
                                    </th>
                                    <th width="100" style="text-align: center; vertical-align: middle;">所属机场
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">设备状态
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">数据所属部门
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">初审人
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">终审人
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">录入人
                                    </th>
                                    <th width="80" style="text-align: center; vertical-align: middle;">状态
                                    </th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-c">
                                <td>
                                    <%#(cpage_jssb-1)*psize_jssb+(Container.ItemIndex + 1)%>
                                </td>
                                <td>
                                    <asp:HyperLink ID="hlnk_sbbh" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"JSSB_Detail_JS.aspx?id=" + Eval("id")%>' Text='<%# Eval("sbbh") %>'></asp:HyperLink> 
                                </td>
                                <td>
                                    <asp:Label ID="lbl_tzmcmc" runat="server" Text='<%#Eval("tzmczlmc")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_ssjcmc" runat="server" Text='<%#Eval("ssjcmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sbzt" runat="server" Text='<%#Eval("sbztmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sjssbm" runat="server" Text='<%#Eval("sjssbmmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_csr" runat="server" Text='<%#Eval("csrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_zsr" runat="server" Text='<%#Eval("zsrxm") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_lrr" runat="server" Text='<%#Eval("lrrxm") %>'></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="lbl_zt_jssb" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
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
                            <cc1:Pager ID="pg_jssb" runat="server" Width="98%" OnPageChanged="pg_jssb_PageChanged" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        </div>

    </form>
</body>
</html>
