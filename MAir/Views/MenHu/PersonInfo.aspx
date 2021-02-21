<%@ Page Language="C#"  MasterPageFile="Sys.Master"  AutoEventWireup="true" CodeBehind="PersonInfo.aspx.cs" Inherits="MAir.Views.MenHu.PersonInfo" %>
<asp:Content ID="KG_head" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="../../Content/css/h-ui.admin/css/style.css" />

     <link rel="stylesheet" type="text/css" href="../../Content/MenHu/index.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/MenHu/bootstrap.min.css" />
    <script src="../../Content/MenHu/jquery-1.11.0.min.js"  type="text/javascript"></script>
    <script src="../../Content/MenHu/bootstrap.min.js"></script>

    <script src="../css/js/jquery.js" type="text/javascript"></script>
    <!--[if IE 6]> <script type="text/javascript" src="../lib/DD_belatedPNG_0.0.8a-min.js"></script>
    <script>DD_belatedPNG.fix('*');</script> <![endif]-->
    <style type="text/css">
        td.td_sjsc
            {
                background:#F6FAFD;
              
            }    
       
    </style>
</asp:Content>
<asp:Content ID="KG_content" ContentPlaceHolderID="kg_content" runat="server" >     
    <form id="form1" runat="server">
        <div class="container">
	<div class="row">
		<div  >
			<div class="tab" style="width:980px" role="tabpanel">
		        	<!-- Nav tabs -->
		        	<ul class="nav nav-tabs"  role="tablist">
		        		<li role="presentation" class="active" ><a href="#Section1" aria-controls="home" role="tab" data-toggle="tab">员工基本信息</a></li>
		        		<li role="presentation"><a href="#Section2" aria-controls="profile" role="tab" data-toggle="tab">员工履历</a></li>
		        		<li role="presentation"><a href="#Section3" aria-controls="messages" role="tab" data-toggle="tab">员工资质</a></li>
		        	</ul>
		         	<!-- Tab panes -->
                   <div class="tab-content tabs">
                      <div role="tabpanel" class="tab-pane fade in active" id="Section1">
                           <table  style="border:1px solid #C0D9D9;" id="t_ygxx" runat="server">
                              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" class="td_sjsc">
                                 <td style=" width:10%;  text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">编号：</td>
                                    <td style=" width:10%; text-align: left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                                       <asp:Label ID="lbl_ygbh" runat="server" ></asp:Label> 
                                   </td>
                                 <td rowspan="4" style=" width:10%; text-align: right; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">员工照片</td>
                                 <td rowspan="4" style=" width:10%; text-align:left; vertical-align: middle;border:1px solid #C0D9D9;" class="td_sjsc">
                                    <asp:Image ID="img_ygzp"   runat="server" Width="120px" Height="150px" />
                                 </td>
                              </tr>
                              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
                                <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >姓名 ：</td>
                                <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                                    <asp:Label ID="lbl_xm" runat="server"></asp:Label>
                                </td>
                              </tr>
                              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" > 
                                      <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                     性别： 
                                  </td>
                                  <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                                   
                                      <asp:Label ID="lbl_xb" runat="server"></asp:Label>
                                  </td> 
                                   
                                 
                              </tr>
                           
                              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                                  <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                                      联系电话：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                                    
                                      <asp:Label ID="lbl_lxdh" runat="server"></asp:Label>
                                  </td>
                                 
                              </tr> 
                              <tr style="vertical-align: top;  width:100%; height:30px; border:1px solid #C0D9D9;" >
                                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                      身份证号：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                                     
                                      <asp:Label ID="lbl_sfzh" runat="server"></asp:Label>
                                  </td>
                                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                     部门名称：
                                  </td>
                                  <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                                     
                                      <asp:Label ID="lbl_bmdm" runat="server"></asp:Label>
                                  </td>            
                              </tr>
                                 <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                                  <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                                       签注专业 ： 
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">      
                                      <asp:Label ID="lbl_qzzy" runat="server"></asp:Label>
                                  </td>
                                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                      岗位名称：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >                
                                      <asp:Label ID="lbl_gwdm" runat="server"></asp:Label>
                                  </td>
                              </tr> 
                        
                              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                     详细地址：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                                    
                                      <asp:Label ID="lbl_xxdz" runat="server"></asp:Label>
                                  </td>
                                    <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                     籍贯：
                                  </td>
                                  <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                                     
                                      <asp:Label ID="lbl_jg" runat="server"></asp:Label>
                                  </td>
                              </tr> 
                           
                             <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                                 <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                                      毕业院校：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                                  
                                      <asp:Label ID="lbl_byyx" runat="server"></asp:Label>
                                  </td>
                                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                                      专业：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                                    
                                      <asp:Label ID="lbl_zy" runat="server"></asp:Label>
                                  </td>
                              </tr>
                              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >   
                                  <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                      学历：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                                      
                                      <asp:Label ID="lbl_xl" runat="server"></asp:Label>
                                  </td>
                                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                                      毕业时间：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                                     
                                      <asp:Label ID="lbl_bysj" runat="server"></asp:Label>
                                  </td>
                              </tr>  
                              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                                 
                                  <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                      入职时间：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                                        
                                      <asp:Label ID="lbl_rzsj" runat="server"></asp:Label>
                                  </td>
                                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc" >
                                      政治面貌：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                                      
                                      <asp:Label ID="lbl_zzmm" runat="server"></asp:Label>
                                  </td>
                              </tr> 
                                  <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                                  <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                     入党时间： 
                                  </td>
                                  <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                                     
                                      <asp:Label ID="lbl_rdsj" runat="server"></asp:Label>
                                  </td>
                                  <td style="width:20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                     工作地：
                                  </td>
                                  <td style="width: 30%; text-align: left; vertical-align: middle;" class="td_sjsc" >
                                    
                                      <asp:Label ID="lbl_gzd" runat="server"></asp:Label>
                                  </td>
                              
                              </tr>
                            
                               <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                      合同关系 ：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                                      <asp:Label ID="lbl_htgx" runat="server"></asp:Label>
                                  </td>
                                    <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                       合同类型 ：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                                     
                                      <asp:Label ID="lbl_htlx" runat="server"></asp:Label>
                                  </td>
                              </tr>   
                              <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                     民族：
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc"  >
                                      <asp:Label ID="lbl_mz" runat="server"></asp:Label>
                                  </td>
                                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                       出生日期： 
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc" >
                                      
                                      <asp:Label ID="lbl_csrq" runat="server"></asp:Label>
                                  </td>
                              </tr>  
                               <tr style="vertical-align: top;  width:100%;height:30px;  border-top:2px solid #C0D9D9;border:1px solid #C0D9D9;" >         
                                     <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                                        状态：
                                    </td>
                                    <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                                       <asp:Label ID="lbl_zt" runat="server"></asp:Label>
                                    </td>
                                      <td style="width: 20%;  text-align: right; vertical-align: middle;" class="td_sjsc">
                                        
                                  </td>
                                  <td style="width: 30%;  text-align: left; vertical-align: middle;" class="td_sjsc">
                                        
                                    </td>
                              </tr>
                               <tr style="vertical-align: top;  width:100%;height:30px;  border:1px solid #C0D9D9;" >
                                   <td style="width: 20%; text-align: right; vertical-align: middle;" class="td_sjsc">
                                     备注：
                                  </td>
                                  <td style="width: 30%; text-align: left; vertical-align: middle;height:50px;" class="td_sjsc"
                                     colspan="3"  >
                                      <asp:Label ID="lbl_ygbz" runat="server"></asp:Label>
                                  </td>
                      </table>
                      </div>
              
                 </div>
			</div>
		</div>
	</div>
</div>
         <div class="row cl" style="text-align:center;width:80%;margin:0 auto;">
           <br />
    	</div>
    </form>
</asp:Content>
