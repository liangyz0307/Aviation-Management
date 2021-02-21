<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JS_SBTX.aspx.cs" Inherits="CUST.WKG.JSuo.main.JS_SBTX" %>

<!DOCTYPE html>
<%@ Register Assembly="CUST.Pager" Namespace="CUST" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <!--[if lt IE 9]> 
    <script type="text/javascript" src="../lib/html5.js"></script>

    <script type="text/javascript" src="../lib/respond.min.js"></script>

    <script src="../lib/PIE-2.0beta1/PIE_IE678.js" type="text/javascript"></script>
     <![endif]-->
   <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/H-ui.admin.css"  />
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
    <form id="form1" runat="server">
             <asp:Repeater ID="Repeater1" runat="server"  >
                <HeaderTemplate>
                    <table class="table table-border table-bordered table-hover table-bg table-sort">
                        <thead>
                            <tr>
                                <th scope="col" colspan="16">
                                    设备过期提醒
                                </th>
                            </tr>
                            <tr class="text-c">
                               
                                 <th width="80"  style="text-align:left;vertical-align:middle;">
                                   设备编号
                                </th>
                                <th width="80"  style="text-align:left;vertical-align:middle;">
                                   详细描述
                                </th>
                               
                              
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="text-c" >
                            
                             <td style="width:27%;text-align:left;vertical-align:middle;">
                               
                           <asp:Label  runat="server" Text='<%#Eval("sbbh") %>'></asp:Label>
                                
                           
                            </td>
                             <td style="width:73%;text-align:left;vertical-align:middle;">
                                
                                <asp:Label  runat="server" Text='<%#Eval("ms") %>'></asp:Label>
                                
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
                            <cc1:Pager ID="pg_fy" runat="server" Width="98%"  />
                    </td>
                </tr>
            </table>
        </form>
</body>
</html>
