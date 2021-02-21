<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BJRK_Detail.aspx.cs" Inherits="CUST.WKG.BJRK_Detail" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>备件详情</title>
      <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>
    <script type="text/javascript" src="../lib/respond.min.js"></script>
    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
    <script src="../../Content/js/jquery.js"=></script>
    <script src="../../Content/js/lhgcalendar/lhgcalendar.js"=></script>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/blue/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
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
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
       <table  style="border-top:2px solid #C0D9D9;border:2px solid #C0D9D9;">
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件编号：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc">
                
                 <asp:Label ID="lbl_bjbh" runat="server" ></asp:Label>
            </td>
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件名称：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 <asp:Label ID="lbl_bjmc" runat="server"  ></asp:Label>
            </td> 
        </tr>
            <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件类型：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_bjfl" runat="server"></asp:Label>
            </td>
           <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               备件适用：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_bjsy" runat="server"></asp:Label>
            </td> 
        </tr>
              
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                
                 经办人部门：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               
                 
                <asp:Label ID="lbl_jbrbm" runat="server"></asp:Label>
               
            </td>
                 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                经办人岗位：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
            
                  
                <asp:Label ID="lbl_jbrgw" runat="server"></asp:Label>
                
            </td>
        </tr> 
             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                负责人部门：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                 
              
                <asp:Label ID="lbl_fzrbm" runat="server"></asp:Label>
                    
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                负责人岗位： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                   
                <asp:Label ID="lbl_fzrgw" runat="server"></asp:Label>
                      
            </td>
        </tr> 
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
                <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
               入库经办人：
            </td>
            <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                 
          
                   
                <asp:Label ID="lbl_jbr" runat="server"></asp:Label>
             
            </td> 
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                库房负责人： 
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
              
                  
               
                <asp:Label ID="lbl_fzr" runat="server"></asp:Label>
                  
            </td>
        </tr> 
        <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                现有备件数量：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                
                <asp:Label ID="lbl_rksl" runat="server"></asp:Label>
            </td>
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                首次入库时间：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                
                <asp:Label ID="lbl_rksj" runat="server"></asp:Label>
            </td>
        </tr> 
         <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              存放位置 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               
                <asp:Label ID="lbl_cfwz" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
             驳回原因：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_bhyy" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              初审人 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               
                <asp:Label ID="lbl_csr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
             终审人 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_zsr" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
              <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
              录入人 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
               
                <asp:Label ID="lbl_lrr" runat="server"></asp:Label>
            </td>
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
             数据所在部门 ：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                 <asp:Label ID="lbl_sjszbm" runat="server"></asp:Label>
            </td>
        </tr>
           <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
             
            <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                入库备注：
            </td>
            <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" colspan="3">
                 <asp:Label ID="lbl_bz" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
   <br />

            <div class="mt-20">
                <asp:Repeater ID="Repeater1" runat="server"  >
                    <HeaderTemplate>
                        <table class="table table-border table-bordered table-hover table-bg table-sort">
                            <thead>
                                <tr>
                                    <th scope="col" colspan="16">备件出入库清单
                                                         <asp:Button ID="btn_dc" runat="server" class="btn  radius" Text="导出" ForeColor="White" BackColor="#60B1D7"
                OnClick="btn_dc_Click" />
                                    </th>
                                </tr>
                                <tr class="text-c">
                                    <th width="20" style="text-align: center; vertical-align: middle;">序号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件编号
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">备件出入库操作人
                                    </th>
                                    <th width="60" style="text-align: center; vertical-align: middle;">操作类型
                                    </th>
                                    <th width="50" style="text-align: center; vertical-align: middle;">操作数量
                                    </th>
                                     <th width="60" style="text-align: center; vertical-align: middle;">操作时间
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
                               <asp:Label ID="lbl_bjbh" runat="server"   Text='<%#Eval("bjbh") %>'></asp:Label> 
                               </td>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bjcrkczr_mc" runat="server" Text='<%#Eval("bjcrkczr_mc") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_czlx" runat="server" Text='<%#Eval("czlx") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_czsl" runat="server" Text='<%#Eval("czsl") %>'></asp:Label>
                                </td>
                                   <td>
                                    <asp:Label ID="lbl_czsj" runat="server" Text='<%#Eval("czsjz") %>'></asp:Label>
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
                        <cc1:Pager ID="pg_fy" runat="server" Width="95%" OnPageChanged="pg_fy_PageChanged" />
                    </td>
                </tr>
            </table>
        </div>
	<div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
        <table>
            <tr>
                  
               <td style="text-align:center">
                   <asp:Button ID="btn_fh" runat="server"  Text="返回" class="btn radius"   Width="199px"  BackColor="#60B1D7" ForeColor="White"  OnClick="btn_back_Click">
                   </asp:Button>
               </td>
            </tr>
        </table>
	</div>

        
  </form>

                 </article>
   
</body>
</html>
