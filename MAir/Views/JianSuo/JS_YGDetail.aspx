<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_YGDetail.aspx.cs" Inherits="CUST.WKG.JS_YGDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

 <head id="Head1" runat="server">
    <title></title>
    <link rel="Bookmark" href="../favicon.ico" />
    <link rel="Shortcut Icon" href="../favicon.ico" />
   
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
	<form id="Form1" runat="server" >
	 <div class="panel-head" style="text-align:center">
            <strong class="icon-reorder">员工详情</strong>
        </div>
    <table >
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   员 工 编 号：</td>
                <td style="width:30%;text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_ygbh" runat="server" ></asp:Label>
                      </td>
               <td rowspan="5" style=" width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">员 工 照 片：<span class="c-red">*</span></td>
             <td rowspan="5" style=" width:30%; text-align: center; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                 <asp:Image ID="img_ygzp" style="width:150px;height:200px"  runat="server" />
                
             </td>
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="width:20%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     员 工 姓 名：</td>
                <td style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_xm" runat="server" ></asp:Label>
                    </td>
              
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   性 别：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_xb" runat="server" ></asp:Label>
                      </td>
                
               
              
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                     身 份 证 号：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_sfzh" runat="server" ></asp:Label>
                    </td>
             </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
              <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   出 生 日 期：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_csrq" runat="server" ></asp:Label>
                      </td>
             </tr>
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                    <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    民 族：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_mz" runat="server" ></asp:Label>
                    </td>
                  <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   联 系 电 话：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_lxdh" runat="server" ></asp:Label>
                      </td>
                 </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   部 门：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_bm" runat="server" ></asp:Label>
                      </td>
                 <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    岗 位：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_gw" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
               
                 <td  style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    工 作 地：</td>
                <td colspan="3" style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_gzd" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   详 细 地 址：</td>
                <td colspan="3" style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_xxdz" runat="server" ></asp:Label>
                      </td>
                
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   籍 贯：</td>
                <td colspan="3" style="text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_jg" runat="server" ></asp:Label>
                      </td>
                
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td colspan="4" style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                 </td>
               
                
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   毕 业 院 校：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_byyx" runat="server" ></asp:Label>
                      </td>
                 <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    专 业：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zy" runat="server" ></asp:Label>
                    </td>
            </tr>
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   学 历：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_xl" runat="server" ></asp:Label>
                      </td>
                 <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    毕 业 时 间：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_bysj" runat="server" ></asp:Label>
                    </td>
            </tr>
          <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                   入 职 时 间：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc"> 
                   <asp:Label ID="lbl_rzsj" runat="server" ></asp:Label>
                      </td>
                 <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    政 治 面 貌：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">  
                   <asp:Label ID="lbl_zzmm" runat="server" ></asp:Label>
                    </td>
            </tr>
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    合 同 关 系：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_htgx" runat="server" ></asp:Label></td>
                
                 <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    合 同 类 型：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_htlx" runat="server" ></asp:Label></td>
            </tr>

        <tr  style="vertical-align: top;   width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    备 注：</td>
                <td   colspan="3" style="width:40%;  text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_bz" runat="server" ></asp:Label></td>
                
            </tr>

                 <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    初 审 人：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_csr" runat="server" ></asp:Label></td>
                
                 <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    终 审 人：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_zsr" runat="server" ></asp:Label></td>
            </tr>



                 <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    录 入 人：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_lrr" runat="server" ></asp:Label></td>
                
                 <td style="  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                    审核时间：</td>
                <td style=" text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                      <asp:Label ID="lbl_shsj" runat="server" ></asp:Label></td>
            </tr>
        </table>
        <br />

         <%-- 资质--%>
         <div id="div">
     <strong class="icon-reorder">英语资质列表</strong><br /><asp:Repeater ID="Repeater1" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                          <%--  <tr>
                                <th scope="col" colspan="16">
                                    员工履历列表
                                </th>
                            </tr>--%>
                            <tr class="text-c">
                               
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                   英语等级
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   英语有效期
                                </th>
                               
                                <%-- <th width="50"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>--%>
                                
                              
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
                                  <%#(cpage1-1)*psize1+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("yydjmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("yyyxqmc") %>'></asp:Label>
                            </td>
                             
                            
                           <%--   <td title='<%# Eval("bhyy") %>'>
                                <asp:Label ID="lbl_zt" runat="server" Text='<%#Eval("ztmc") %>'></asp:Label>
                            </td>--%>
                             
                     
                       
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

    <br />
        
         <strong class="icon-reorder">执照资质列表</strong><asp:Repeater ID="Repeater2" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr class="text-c">
                               
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                   执照文件号码
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   执照编号
                                </th>
                                 <th width="90"  style="text-align:center;vertical-align:middle;">
                                   执照颁发日期
                                </th>
                                <%-- <th width="50"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>--%>
                                
                              
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
                                  <%#(cpage2-1)*psize2+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("zzwjhm") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("zzbh") %>'></asp:Label>
                            </td>
                              <td>
                                 <asp:Label ID="Label2" runat="server" Text='<%#Eval("bfrq") %>'></asp:Label>
                            </td>                                                                        
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        <br />
          <strong class="icon-reorder">签注资质列表</strong><asp:Repeater ID="Repeater3" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                          <%--  <tr>
                                <th scope="col" colspan="16">
                                    员工履历列表
                                </th>
                            </tr>--%>
                            <tr class="text-c">
                               
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                   签注专业
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   签注类别
                                </th>
                               <th width="60"  style="text-align:center;vertical-align:middle;">
                                   签注项
                                </th>
                                  <th width="60"  style="text-align:center;vertical-align:middle;">
                                   签注有效期
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   签注地
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   异地签注
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   异地签注项
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   异地签注有效期
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   异地签注地
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   体检等级
                                </th>
                                 <th width="60"  style="text-align:center;vertical-align:middle;">
                                   体检有效期
                                </th>
                                <%-- <th width="50"  style="text-align:center;vertical-align:middle;">
                                    状态
                                </th>--%>
                                
                              
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                  <%#(cpage3-1)*psize3+(Container.ItemIndex + 1)%>
                             
                            </td>
                            <td>
                                <asp:Label ID="lbl_bh" runat="server" Text='<%#Eval("qzzymc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("qzlbmc") %>'></asp:Label>
                            </td>
                              <td>
                                 <asp:Label ID="Label3" runat="server" Text='<%#Eval("qzxmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label4" runat="server" Text='<%#Eval("qzyxqmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label5" runat="server" Text='<%#Eval("qzd") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label6" runat="server" Text='<%#Eval("ydqzmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label7" runat="server" Text='<%#Eval("ydqzxmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label8" runat="server" Text='<%#Eval("ydqzyxqmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label9" runat="server" Text='<%#Eval("ydqzd") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label10" runat="server" Text='<%#Eval("tjdjmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="Label11" runat="server" Text='<%#Eval("tjyxqmc") %>'></asp:Label>
                            </td>                                    
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
	</div>

         <%-- 员工履历--%>
	     <div id="div_ll">
         <strong class="icon-reorder">员工履历详情</strong> <asp:Repeater ID="Repeater4" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr class="text-c">
                               
                                <th width="40"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="90"  style="text-align:center;vertical-align:middle;">
                                   工作单位
                                </th>
                                <th width="60"  style="text-align:center;vertical-align:middle;">
                                   工作部门
                                </th>
                                  
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                   工作岗位
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    工作地点
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    起止日期
                                </th>
                                 <th width="50"  style="text-align:center;vertical-align:middle;">
                                    截止日期
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
                            <td>
                                <asp:Label ID="lbl_gzdw" runat="server" Text='<%#Eval("jzrq") %>'></asp:Label>
                            </td>                      
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

        
</div>


        
         <%-- 员工奖励--%>
         <div id="div_JL">
     <strong class="icon-reorder">员工奖励列表</strong><br />
        <asp:Repeater ID="Repeater_ygjl" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr class="text-c">
                               
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                   受奖人 
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    奖励种类
                                </th>               
                                </th>
                                <th width="6%"  style="text-align:center;vertical-align:middle;">
                                    奖励等级
                                </th>
                                <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    奖励原因
                                </th>
                                 <th width="10%"  style="text-align:center;vertical-align:middle;">
                                    奖励内容
                                </th>
                                  <th width="8%"  style="text-align:center;vertical-align:middle;">
                                    日期
                                </th>                                                               
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                  <%#(cpage1-1)*psize1+(Container.ItemIndex + 1)%>                      
                            </td>
                            <td>
                                <asp:HyperLink ID="hlnk_sjr" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"JS_YGJL_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("sjrxm") %>'></asp:HyperLink> 
                            </td>           
                            <td>
                                <asp:Label ID="lbl_jlzl" runat="server" Text='<%#Eval("jlzlmc") %>'></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="lbl_jldj" runat="server" Text='<%#Eval("jldjmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_jlyy" runat="server" Text='<%#Eval("jlyy") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_jlnr" runat="server" Text='<%#Eval("jlnr") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_rq" runat="server" Text='<%#Eval("rqmc") %>'></asp:Label>
                            </td>                      
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
         </div>

         <%-- 员工惩罚--%>
         <div id="div_CF">
     <strong class="icon-reorder">员工惩罚列表</strong><br />
        <asp:Repeater ID="Repeater_ygcf" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr class="text-c">
                               
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                 <th width="6%"  style="text-align:center;vertical-align:middle;">
                                        受罚人
                                    </th>
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                        事件种类
                                    </th>
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                        承担责任
                                    </th>
                                    <th width="6%"  style="text-align:center;vertical-align:middle;">
                                        处理意见
                                    </th>
                                  <th width="8%"  style="text-align:center;vertical-align:middle;">
                                         日期
                                  </th>                                                         
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                  <%#(cpage1-1)*psize1+(Container.ItemIndex + 1)%>                      
                            </td>
                                <td>
                                    <asp:HyperLink ID="hlnk_sfr" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"JS_YGCF_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("sfrxm") %>'></asp:HyperLink> 
                                </td>
                                <td>
                                    <asp:Label ID="lbl_sjzl" runat="server" Text='<%#Eval("sjzlmc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cdzr" runat="server" Text='<%#Eval("cdzr") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_clyj" runat="server" Text='<%#Eval("clyj") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cfsj" runat="server" Text='<%#Eval("cfsjmc") %>'></asp:Label>
                                </td>              
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

         <%-- 员工培训--%>
         <div id="div_PX">
     <strong class="icon-reorder">员工培训列表</strong><br />
        <asp:Repeater ID="Repeater_ygpx" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr class="text-c">
                               
                                <th width="5%"  style="text-align:center;vertical-align:middle;">
                                    序号
                                </th>
                                   <th width="8%" style="text-align: center; vertical-align: middle;">受教育者
                                    </th>                                   
                                    <th width="6%" style="text-align: center; vertical-align: middle;">类型
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">部门
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">考核方式
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">考核结果
                                    </th>
                                    <th width="8%" style="text-align: center; vertical-align: middle;">日期
                                    </th>
                                    <th width="6%" style="text-align: center; vertical-align: middle;">培训师
                                    </th>                           
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                  <%#(cpage1-1)*psize1+(Container.ItemIndex + 1)%>                      
                            </td>
                            <td>
                                <asp:HyperLink ID="hlnk_SJYZ" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"JS_YGPX_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("SJYZ") %>'></asp:HyperLink>
                            </td>
                            <td>
                                <asp:Label  ID="lbl_type" runat="server" Text='<%#Eval("typemc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  ID="lbl_bm" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  ID="lbl_khfs" runat="server" Text='<%#Eval("KHFS") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label  ID="lbl_khjgmc" runat="server" Text='<%#Eval("khjgmc") %>'></asp:Label>
                            </td>                                                        
                            <td>
                                <asp:Label  ID="lbl_rq" runat="server" Text='<%#Eval("rqsjmc") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lbl_pxs" runat="server" Text='<%#Eval("pxs") %>'></asp:Label>
                            </td>                        
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

         <%-- 员工职称--%>
         <div id="div_ZC">
     <strong class="icon-reorder">员工职称列表</strong><br />
        <asp:Repeater ID="Repeater_ygzc" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr class="text-c">                              
                                <th width="5%"  style="text-align:center;vertical-align:middle;">序号
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">受聘人 
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">部门
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">类别 
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">级别
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">资格
                                </th>                  
                                <th width="5%"  style="text-align:center;vertical-align:middle;">是否聘任
                                </th>
                                <th width="5%"  style="text-align:center;vertical-align:middle;">资格审权单位
                                </th>
                                <th width="8%"  style="text-align:center;vertical-align:middle;">获得时间
                                </th>                                                     
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c">
                            <td>
                                  <%#(cpage1-1)*psize1+(Container.ItemIndex + 1)%>                      
                            </td>
                                <td>
                                <asp:HyperLink ID="hlnk_spr" runat="server" ForeColor="Blue" Font-Underline="true" NavigateUrl='<%#"JS_YGZC_Detail.aspx?id=" + Eval("id")%>' Text='<%# Eval("sprxm") %>'></asp:HyperLink> 
                            </td>           
                            <td>
                                <asp:Label ID="lbl_bm" runat="server" Text='<%#Eval("bm") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_lb" runat="server" Text='<%#Eval("qzzydmmc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_jb" runat="server" Text='<%#Eval("jbmc") %>'></asp:Label>
                            </td>  
                             <td>
                                 <asp:Label ID="lbl_zg" runat="server" Text='<%#Eval("zgmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_pr" runat="server" Text='<%#Eval("prmc") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_zgsqdw" runat="server" Text='<%#Eval("zgsqdw") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_hdsj" runat="server" Text='<%#Eval("hdsjmc") %>'></asp:Label>
                            </td>           
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>


        <%-- 返回--%>
		<div  style="text-align:center">
		    
              &nbsp;  
              <asp:Button ID="btn_fh" runat="server" 
                Text="返回" class="btn  radius" ForeColor="White" BackColor="#60B1D7"
                Width="199px"  onclick="btn_fh_Click"></asp:Button>  
		</div>
	</form>
</article>
  

    <script type="text/javascript" src="../../Content/js/H-ui.js"></script>

    <script type="text/javascript" src="../../Content/js/H-ui.admin.js"></script>

   
      <script src="../../Content/js/jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            //英语有效期
            $("#tbx_yyyxq").blur(function() {
                if ($("#tbx_yyyxq").val() != "") {
                    $("#lbl_yyyxq").text("正确");
                    $("#lbl_yyyxq").css("color", "#00ff00");
                } else {
                    $("#lbl_yyyxq").text("错误");
                    $("#lbl_yyyxq").css("color", "#ff0000");
                }
            });
            //执照文件号码
            $("#tbx_zzwjhm").blur(function () {
                if ($("#tbx_zzwjhm").val() != "") {
                    $("#lbl_zzwjhm").text("正确");
                    $("#lbl_zzwjhm").css("color", "#00ff00");
                } else {
                    $("#lbl_zzwjhm").text("错误");
                    $("#lbl_zzwjhm").css("color", "#ff0000");
                }
            });
            //执照编号
            $("#tbx_zzbh").blur(function () {
                if ($("#tbx_zzbh").val() != "") {
                    $("#lbl_zzbh").text("正确");
                    $("#lbl_zzbh").css("color", "#00ff00");
                } else {
                    $("#lbl_zzbh").text("错误");
                    $("#lbl_zzbh").css("color", "#ff0000");
                }
            });
            //颁发日期
            $("#tbx_bfrq").blur(function () {
                if ($("#tbx_bfrq").val() != "") {
                    $("#lbl_bfrq").text("正确");
                    $("#lbl_bfrq").css("color", "#00ff00");
                } else {
                    $("#lbl_bfrq").text("错误");
                    $("#lbl_bfrq").css("color", "#ff0000");
                }
            });
            //注册类别有效期
            $("#tbx_zclbyxq").blur(function () {
                if ($("#tbx_zclbyxq").val() != "") {
                    $("#lbl_zclbyxq").text("正确");
                    $("#lbl_zclbyxq").css("color", "#00ff00");
                } else {
                    $("#lbl_zclbyxq").text("错误");
                    $("#lbl_zclbyxq").css("color", "#ff0000");
                }
            });
            //异地签注有效期
            $("#tbx_ydqzyxq").blur(function () {
                if ($("#tbx_ydqzyxq").val() != "") {
                    $("#lbl_ydqzyxq").text("正确");
                    $("#lbl_ydqzyxq").css("color", "#00ff00");
                } else {
                    $("#lbl_ydqzyxq").text("错误");
                    $("#lbl_ydqzyxq").css("color", "#ff0000");
                }
            });
            //体检有效期
            $("#tbx_tjyxq").blur(function () {
                if ($("#tbx_tjyxq").val() != "") {
                    $("#lbl_tjyxq").text("正确");
                    $("#lbl_tjyxq").css("color", "#00ff00");
                } else {
                    $("#lbl_tjyxq").text("错误");
                    $("#lbl_tjyxq").css("color", "#ff0000");
                }
            });
            $("#btn_save").click(function () {

                if ($("#tbx_mc").val() == "") {
                    $("#lbl_mc").text("错误：名称不能为空！");
                    $("#lbl_mc").css("color", "#ff0000");
                    return false;
                }

            });
           
        });
    </script>
  

</body>


</html>
