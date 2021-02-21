<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_SKJS.aspx.cs" Inherits="CUST.WKG.JS_SKJS" %>
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

   <div id="div1" style="text-align:center" runat="server" >
                   请选择子模块：
            <asp:DropDownList ID="ddlt_zxt" runat="server" CssClass="select-box" Style="width: 100px" AutoPostBack="true" OnSelectedIndexChanged="Authority">
            </asp:DropDownList>
         </div>

   <div id="div_sbblk" style="text-align:center" runat="server" >

        <div class="text-c">

            保养频次：
            <asp:DropDownList ID="ddlt_bypc" runat="server" CssClass="select-box" Style="width: 100px">
            </asp:DropDownList>
            设备名称：
              <asp:TextBox ID="tbx_sbmc" runat="server" Height="20px"></asp:TextBox>
            <asp:Button ID="btn_select" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White"
  OnClick="btn_select_Click_sbblk"      />
            &nbsp;
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater_sbblk" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="18">
                                   设备病例库 
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    设备名称
                                </th>
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                   地点 
                                </th>
                                  <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    使用岗位
                                </th>
                           
                                 <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    使用人
                                </th>
                              
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    使用年限
                                </th>
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                   故障时间
                                </th>
                                  <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    排故时间
                                </th>
                                  <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    保养频次
                                </th>
                                  <th width="5%"  style="text-align:center;vertical-align:middle;">
                                     维修人员
                                </th>
                                  <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    备注
                                </th>
                                <th width="4%"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>

                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                           
                            <td>
                              <%#(cpage_sbblk-1)*psize_sbblk+(Container.ItemIndex + 1)%>
                            </td>
                       
                            <td>
                                <asp:HyperLink ID="hlnk_sbmc" runat="server" ForeColor="#60B1D7" Style="text-decoration: underline" NavigateUrl='<%#"JS_SKJS_SBBLK.aspx?id=" + Eval("id")%>' Text='<%# Eval("sbmc") %>'></asp:HyperLink>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%#Eval("dd") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label runat="server" Text='<%#Eval("sygw") %>'></asp:Label>
                            </td>
                         
                             <td>
                                <asp:Label  runat="server" Text='<%# Eval("syrxm") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("synx") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("gzsjs") %>'></asp:Label>
                            </td>
                           
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("pgsjs") %>'></asp:Label>
                            </td>
                           <td>
                                <asp:Label  runat="server" Text='<%#Eval("bypcmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("wxryxm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("bz") %>'></asp:Label>
                            </td> 
                            <td title='<%# Eval("ztmc_sbblk") %>'>
                                <asp:Label ID="lbl_byyx" runat="server" Text='<%#Eval("ztmc_sbblk") %>'></asp:Label>
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
                        <cc1:Pager ID="Pager_sbblk" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged_sbblk" />
                        </td>
                    </tr>
                </table>
        </div>
        </div>



   <div id="div_wxy" style="text-align:center" runat="server" >
      <div class="text-c"   style="text-align: center; width: 100%; margin: 0 auto;">
         
            危险源名称：
             <asp:TextBox ID="tbx_mc" runat="server" Width="123px"></asp:TextBox>
            岗位：
            <asp:DropDownList ID="ddlt_gw" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList> 
            状态：
            <asp:DropDownList ID="ddlt_zt_wxy" runat="server" class="select-box" Style="width: 80px"></asp:DropDownList>
            控制状态：
              <asp:DropDownList ID="ddlt_kzzt" runat="server" class="select-box" Style="width: 80px">
            </asp:DropDownList> 
             <asp:Button ID="Button3" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click_wxy"   />

         
             
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater_wxy" runat="server" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="27">
                                   风险源分析
                                </th>
                            </tr>
                            <tr>
                                <th width="30"   style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="100"  style="text-align:center;vertical-align:middle;">
                                    危险源名称
                                </th>
                                <th width="70"   style="text-align:center;vertical-align:middle;">
                                    岗位
                                </th>
                                <th width="50"   style="text-align:center;vertical-align:middle;">
                                    时态
                                </th>

                                <th width="80"   style="text-align:center;vertical-align:middle;">
                                    发生的可能性
                                </th>
                                <th width="80"   style="text-align:center;vertical-align:middle;">
                                   控制状态
                                </th>
                               <th width="50"   style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                           
                            <td>
                                  <%#(cpage_wxy-1)*psize_wxy+(Container.ItemIndex + 1)%>
                            </td>
                            <td>
                                <asp:HyperLink ID="hlnk_xm" runat="server" ForeColor="#60B1D7" Font-Underline="true"        NavigateUrl='<%#"../JianSuo/JS_SKJS_WXY.aspx?id=" + Eval("id")%>' Text='<%# Eval("mc") %>'></asp:HyperLink> 
                            </td>
                         
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("gwmc") %>'></asp:Label>
                            </td>
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("stmc") %>'></asp:Label>
                            </td>

                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("knxmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("kzztmc") %>'></asp:Label>
                            </td>
                               
                              <td>
                                <asp:Label  runat="server" Text='<%#Eval("ztmc_wxy") %>'></asp:Label>
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
                        <cc1:Pager ID="Pager_wxy" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged_wxy"  />
                    </td>
                </tr>
            </table>
        </div>
    </div>


           <div id="div_aqyhk" style="text-align:center" runat="server">
      <div class="text-c"   style="text-align: center; width: 100%; margin: 0 auto;">
            隐患等级:
            <asp:DropDownList ID="ddlt_yhdj" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
            来源:
            <asp:DropDownList ID="ddlt_ly_aqyhk" runat="server" Style="width: 100px"  Height="24px"></asp:DropDownList>
                               状态:
              <asp:DropDownList ID="ddlt_zt_aqyhk" runat="server" class="select-box" Style="width: 80px"  AutoPostBack="true">
            </asp:DropDownList>
            填表日期:
             <asp:TextBox ID="tbx_tbrq_ks" runat="server" style="width:80px;height:24px;" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
           <asp:TextBox ID="tbx_tbrq_js" runat="server" style="width:80px;height:24px;" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
               
            <asp:Button ID="Button5" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click_aqyhk" />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater_aqyhk" runat="server"  >
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
                                    隐患等级
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    来源
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
                              <th width="40"  style="text-align:center;vertical-align:middle;">
                                   状态
                                </th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                       <tr class="text-c">
                           
                            <td>
                              <%#(cpage_aqyhk-1)*psize_aqyhk+(Container.ItemIndex + 1)%>
                            </td>

                            <td>
                                <asp:HyperLink ID="hlnk_tbdw" runat="server" ForeColor="#60B1D7" Style="text-decoration: underline" NavigateUrl='<%#"JS_SKJS_AQYHK.aspx?id=" + Eval("id")%>' Text='<%# Eval("tbdwmc") %>'></asp:HyperLink>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("yhdjmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("lymc") %>'></asp:Label>
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
                                <asp:Label  runat="server" Text='<%#Eval("ztmc_aqyhk") %>'></asp:Label>
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
                        <cc1:Pager ID="Pager_aqyhk" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged_aqyhk"  />
                    </td>
                </tr>
            </table>
        </div>
    </div>


       <div id="div_aqwtk" runat="server">
      <div class="text-c"   style="text-align: center; width: 100%; margin: 0 auto;">
            责任部门:
            <asp:DropDownList ID="ddlt_zrbm" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
            涉及范畴:
            <asp:DropDownList ID="ddlt_sjfc" runat="server" class="select-box" Style="width: 100px"></asp:DropDownList>
            来源:
            <asp:DropDownList ID="ddlt_ly_aqwtk" runat="server" Style="width: 100px"  Height="24px"></asp:DropDownList>
            状态:
            <asp:DropDownList ID="ddlt_zt_aqwtk" runat="server" class="select-box" Style="width: 80px"  AutoPostBack="true">
            </asp:DropDownList>
            发生时间:
             <asp:TextBox ID="tbx_fssj_ks" runat="server" style="width:80px;height:24px;" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
           <asp:TextBox ID="tbx_fssj_js" runat="server" style="width:80px;height:24px;" onclick="lhgcalendar({format:'yyyy-MM-dd'})"></asp:TextBox>
               
            <asp:Button ID="Button1" runat="server" class="btn  radius" Text="查询"  BackColor="#60B1D7" ForeColor="White" OnClick="btn_select_Click_aqwtk" />
        </div>
        <div class="mt-20">
            <asp:Repeater ID="Repeater_aqwtk" runat="server"   >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="23">
                                    安全问题库
                                </th>
                            </tr>
                            <tr>
                                 <th width="30"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    安全问题名称
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    发生时间
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    来源
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                    涉及范畴
                                </th>
                                 <th width="80"  style="text-align:center;vertical-align:middle;">
                                   整改完成时限
                                </th>
                                <th width="80"  style="text-align:center;vertical-align:middle;">
                                   问题控制状态
                                </th>
                                  <th width="80"  style="text-align:center;vertical-align:middle;">
                                   责任部门
                                </th>
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                   状态
                                </th>  



                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                       <tr class="text-c">
                           
                            <td>
                              <%#(cpage_aqwtk-1)*psize_aqwtk+(Container.ItemIndex + 1)%>
                            </td>

                            <td>
                                <asp:HyperLink ID="hlnk_tbdw" runat="server" ForeColor="#60B1D7" Style="text-decoration: underline" NavigateUrl='<%#"JS_SKJS_AQWTK.aspx?id=" + Eval("id")%>' Text='<%# Eval("aqwtmc") %>'></asp:HyperLink>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("fssjz") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("lymc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("sjfcmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("zgsxz") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("wtkzztmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%#Eval("zrbmmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label  runat="server" Text='<%#Eval("ztmc_aqwtk") %>'></asp:Label>
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
                        <cc1:Pager ID="Pager_aqwtk" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged_aqwtk"  />
                    </td>
                </tr>
            </table>
        </div>
    </div>



          <div  id="div_zjk" runat="server">
         <table><tr>           

              <td align="left" class="auto-style9">姓名：
             <asp:TextBox ID="tbx_xm" runat="server" Width="90px"></asp:TextBox></td>

             <td align="left" class="auto-style10">专家类型：
             <asp:DropDownList ID="ddlt_zjlx" runat="server" class="select-box" Style="width: 70px; height: 28px;" >
            </asp:DropDownList></td>

          <td align="left" class="auto-style4">
                   状态：
             <asp:DropDownList ID="ddlt_zt_zjk" runat="server" class="select-box" Style="width: 80px; height: 28px;" >
            </asp:DropDownList></td>

            <td  style="width:6%"  align="center">
            <asp:Button ID="Button2" runat="server" class="btn  radius" Text="查询" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_select_Click_zjk" />
           
                  </td>
              </tr>
           
         </table> 
         
        <div class="mt-20">
            <asp:Repeater ID="Repeater_zjk" runat="server" >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    专家信息
                                </th>
                            </tr>
                            <tr class="text-c">
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                   专家姓名 
                                </th>
                                 <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    专家类型
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    驻地
                                </th>
                
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    从事工作
                                </th>
                                 <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    专业
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    专长
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    联系方式
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
                                  <%#(cpage_zjk-1)*psize_zjk+(Container.ItemIndex + 1)%>
                             
                            </td>
                            
                            <td>
                                <asp:HyperLink ID="hlnk_sjr" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"JS_SKJS_ZJK.aspx?id=" + Eval("id")%>' Text='<%# Eval("xm") %>'></asp:HyperLink> 

                            </td>           
                            <td>
                                <asp:Label ID="lbl_zjlx" runat="server" Text='<%#Eval("zjlxmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_zd" runat="server" Text='<%#Eval("zd") %>'></asp:Label>
                            </td>
  
                             <td>
                                 <asp:Label ID="lbl_csgz" runat="server" Text='<%#Eval("csgz") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_zy" runat="server" Text='<%#Eval("zy") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_zc" runat="server" Text='<%#Eval("zc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_lxfs" runat="server" Text='<%#Eval("lxfs") %>'></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lbl_byyx" runat="server" Text='<%#Eval("ZTMC") %>'></asp:Label>
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
                        <cc1:Pager ID="Pager_zjk" runat="server" Width="98%" OnPageChanged="pg_fy_PageChanged_zjk" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
