<%@ Page Title="" Language="C#" MasterPageFile="Sys_DQZC.Master" AutoEventWireup="true" CodeBehind="DQZC_DYIndex.aspx.cs" Inherits="CUST.WKG.DQZC_DYIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/ext-all.css"/>
    <link type="text/css" rel="stylesheet" href="../../Content/css/main.css"/>
    <link type="text/css" rel="stylesheet" href="../../Content/css/xtheme.css"/>
    <link rel="stylesheet" type="text/css" href="../../Content/css/highslide.css"/>
    <!--[if lt IE 7]>
    <link rel="stylesheet" type="text/css" href="highslide/highslide-ie6.css" />
    <![endif]-->	
    <title>党群之窗</title>
    <link rel="stylesheet" type="text/css" href="../../Content/css/rss.css"/>
    <link rel="stylesheet" href="../../Content/css/index.css"/>
    <link rel="stylesheet" href="../../Content/css/qczc_index.css"/>
    <style type="text/css">
	#box{
		width:380px;
		height:240px;
		border:1px solid black;
		position:relative;
		overflow:hidden;
        margin-right:50px;
	}
	#red{
		background-color:red;
		width:380px;
	}
	#green{
		background-color:green;
		width:380px;
	}
	#blue{
		background-color:blue;
		width:380px;
	}
	.slide{
		width:380px;
		height:240px;
		position:absolute;
	}
        .auto-style1 {
            width: 380px;
        }
        .auto-style2 {
            float: left;
            height: 28px;
            width: 265px;
            overflow: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
      <div id="container" >
   <div  style="height:790px"> 
         <div class="dqzc" >
             <div class="dqzc_l fl">
                 <div >
                   <h3 style="font-weight:bold;color:#b90601;float:left;height:28px;width:265px; line-height:28px;margin:0 5px 5px;border-bottom:1px solid #b90601;clear:both;overflow:hidden">
                       <asp:Image ID="Image22" runat="server"  src="../../Content/images/bt_ico.gif"/>
                        <span>&nbsp&nbsp 入党誓词</span>
                   </h3>
           
                 <br />
                 <div>
                     <table>
                         <tr>
                            <td  style="text-align:left;line-height:20px;" >
                               &nbsp&nbsp &nbsp&nbsp &nbsp  我志愿加入中国共产党，拥护党的纲领，遵守党的章程，履行党员义务，执行党的决定，严守党的纪律，保守党的秘密，对党忠诚，积极工作，为共产主义奋斗终身，随时准备为党和人民牺牲一切，永不叛党。
                            </td>
                         </tr>
                     </table>
                    
                 </div> 
            </div>
                 <br />
            
                 <div >              
                   <h3 style="font-weight:bold;color:#b90601;line-height:28px;margin:0 5px 5px;border-bottom:1px solid #b90601;clear:both;" class="auto-style2">
                       <asp:Image ID="Image25" runat="server"  src="../../Content/images/bt_ico.gif"/>
                        <span>组织机构</span>
                      <%-- <span style="margin-left: 150px;">
                       <asp:ImageButton ID="more_zzjg" runat="server" src="../../Content/images/more.gif" OnClick="more_zzjg_Click" style="height: 11px" />
                      </span>--%>
                   </h3>
               <br />
                 <div>
                        <table>
                         <tr>
                             <td> <img  src="../../Content/images/zdz_fzz.jpg" usemap="#zzjg"/>
                                 <map name="zzjg" id="zzjg"> 
                                     <a ><area shape="rect" coords="29, 76, 54, 216" href="DQZC_ZZJGDetail.aspx?lx=-1" target="_blank"  runat="server" /> </a>
                                     <a ><area shape="rect" coords="81, 75, 224, 99" href="DQZC_ZZJGDetail.aspx?lx=1" target="_blank"  runat="server" /> </a>
                                      <a ><area shape="rect" coords="81, 134, 224, 160" href="DQZC_ZZJGDetail.aspx?lx=2" target="_blank"  runat="server" /> </a>
                                      <a ><area shape="rect" coords="81, 192, 224, 216" href="DQZC_ZZJGDetail.aspx?lx=3" target="_blank"  runat="server" /> </a>
                                    <%--  <a ><area shape="rect" coords="82,218,223,241" href="DQZC_ZZJGDetail.aspx?lx=4" target="_blank"  runat="server" /> </a>--%>
                                 </map>
                             </td>
                          </tr>
                      </table>
                 </div> 
            </div>
            </div>
            <div  class="dqzc_c fl">                                             
                <h3 style="font-weight:bold;color:#b90601;float:left;width:390px;height:26px; line-height:26px; background:url(../../Content/images/c_title_bg.gif); margin:0 5px 5px;clear:both;overflow:hidden">
                    
                <span style="color:white">&nbsp&nbsp 图片展示</span></h3>
                   <div id="box" class="dqzc_c fl" onmouseover="stop()" onmouseout="start()">
                <table class="auto-style1">                                        
                    <tr>
                        <td style="height:20px;text-align:center">
                         <asp:Image ID="red" class="slide" runat="server" Width="380px" Height="240px" src="../../Content/images/timg.jpg"/>
                         <asp:Image ID="green" class="slide" runat="server" Width="380px" Height="240px" src="../../Content/images/xjp1.jpg"/>
                         <asp:Image ID="blue" class="slide" runat="server" Width="380px" Height="240px" src="../../Content/images/xjp2.jpg"/>
                        </td>
                   </tr>                 
               </table> 
                </div>
               
               <table style="width:380px;height:200px">
                          <tr>   
                          <td style="height:28px">
                              <h3 style="font-weight:bold;color:#b90601;float:left;height:28px;width:390px; line-height:28px;margin:0 5px 5px;border-bottom:1px solid #b90601;clear:both;overflow:hidden">
                                 <asp:Image ID="Image10" runat="server"  src="../../Content/images/bt_ico.gif"/>
                                  <span>&nbsp&nbsp 学习教育</span>
                                  <span style="margin-left: 250px;">
                       <asp:ImageButton ID="more_dszs" runat="server" src="../../Content/images/more.gif" OnClick="more_dszs_Click" style="height: 11px" />
                      </span>
                              </h3> </td>
                          </tr>
                           <tr>
                              <td style="height:200px">
                               <div style="height:200px;width:380px; margin-left:5px;color:red">
                                    <asp:Label ID="lbl_dszs" runat="server" ></asp:Label> 
                                </div>                                            
                              </td>
                           </tr>                                             
                             </table>                                                                                    
           </div>
                <div  class="dqzc_r fr">
                                         
                    <div style="width:280px;height:475px">      
                     
                        <div style="height:28px">
                          <h3 style="font-weight:bold;color:#b90601;float:left;width:280px;line-height:28px;margin:0 0 0;border-bottom:1px solid #b90601;clear:both;overflow:hidden">
                             <asp:Image ID="Image32" runat="server"  src="../../Content/images/bt_ico.gif"/>
                              <span>&nbsp&nbsp 工会管理</span>
                              <span style="margin-left: 120px;">
                       <asp:ImageButton ID="more_dqghdt" runat="server" src="../../Content/images/more.gif" OnClick="more_dqghdt_Click" style="height: 11px" />
                      </span>
                          </h3>
                        </div>
                    
                         
                            <div style="width:280px;height:209px" >          
                                     
                                            <asp:Label ID="lbl_gg" runat="server"></asp:Label>

                            </div>
                        
                         
                        <div style="height:28px">
                          <h3 style="font-weight:bold;color:#b90601;float:left;width:280px;line-height:28px;margin:0 0 0;border-bottom:1px solid #b90601;clear:both;overflow:hidden">
                             <asp:Image ID="Image9" runat="server"  src="../../Content/images/bt_ico.gif"/>
                              <span>&nbsp&nbsp 党员学习平台</span>
                          </h3>
                        </div>
                     <tr>
                        <td style="height:20px; width:280px" text-align:center">
                         <asp:ImageButton ID="Image30" Height="150px" width="280px" runat="server"  OnClick="more_dyxx_Click" src="../../Content/images/logo.png"/>
                        </td>
                    </tr>
                    </div>   
               </div>                                                                                
        </div> 
    <br />
       <div class="dqzc" style="height:310px" >
             <div class="dqzc_l " style="width:975px;height:310px">
                 <div style="height:29px">
                   <h3 style="font-weight:bold;color:#b90601;float:left;height:28px;width:970px; line-height:28px;margin:0 5px 5px;border-bottom:1px solid #b90601;clear:both;overflow:hidden">
                       <asp:Image ID="Image1" runat="server"  src="../../Content/images/bt_ico.gif"/>
                        <span>&nbsp&nbsp 党员在线</span>
                       <span style="margin-left: 830px;">
                       <asp:ImageButton ID="more_dyzx" runat="server" src="../../Content/images/more.gif" OnClick="more_dyzx_Click" style="height: 11px" />
                      </span>
                   </h3>
                </div>
                 <div>                                            
                          <div class="p_l_t_product1 fl" style="height:100px;width:25%">
                              <div class="buy fl" style="height:100px;width:39%">
                                  <div class="img"  >
                                      <asp:Image ID="Image3"   Width="80px"  Height="95px" runat="server" />
                                  </div>                                        
                              </div>
                              <div class="explain fl "  style="height:120px;width:60%">
                                  
                                    <li style="height:33%;Width:100%">  
                                 姓名：<asp:Label ID="Labe_xm1" runat="server" ></asp:Label>
                                </li>
                                <li style="height:33%;Width:100%">  
                                  部门： <asp:Label ID="Labe_bm1" runat="server" ></asp:Label> 
                                </li>
                               <li style="height:33%;Width:100%">  
                                   岗位：<asp:Label ID="Labe_gw1" runat="server" ></asp:Label> 
                                   </li>                              
                              </div>
                        </div>
                        <div class="p_l_t_product1 fl" style="height:120px;width:24%">
                                    
                             <div class="explain fl " style="height:100px;width:100%">
                                 <div style="height:30px;line-height:30px;">
                                      <a href="#"><h3 style="color:#9c1f00">主要事迹： </h3></a> 
                                 </div>
                                <div style="height:70px;width:210px; margin-left:5px;color:red">
                                    <asp:Label ID="Labe_zysj1" runat="server" ></asp:Label> 
                                </div>            
                             </div>
                         </div>
                        <div class="p_l_t_product1 fl" style="height:100px;width:25%">
                              <div class="buy fl" style="height:100px;width:39%">
                                  <div class="img"  >
                                      <asp:Image ID="Image4"   Width="80px"  Height="95px" runat="server" />
                                  </div>                                        
                              </div>
                              <div class="explain fl "  style="height:120px;width:60%">
                                  
                                    <li style="height:33%;Width:100%">  
                                 姓名：<asp:Label ID="Labe_xm2" runat="server" ></asp:Label>
                                </li>
                                <li style="height:33%;Width:100%">  
                                  部门： <asp:Label ID="Labe_bm2" runat="server" ></asp:Label> 
                                </li>
                               <li style="height:33%;Width:100%">  
                                   岗位：<asp:Label ID="Labe_gw2" runat="server" ></asp:Label>  
                                   </li>                             
                              </div>
                        </div>
                        <div class="p_l_t_product1 fl" style="height:120px;width:25%">
                                    
                             <div class="explain fl " style="height:100px;width:100%">
                                 <div style="height:30px;line-height:30px;">
                                      <a href="#"><h3 style="color:#9c1f00">主要事迹： </h3></a> 
                                 </div>
                                <div style="height:70px;width:210px; margin-left:5px">
                                    <asp:Label ID="Labe_zysj2" runat="server" ></asp:Label> 
                                </div>            
                             </div>
                         </div>
                         <div class="p_l_t_product1 fl" style="height:100px;width:25%">
                              <div class="buy fl" style="height:100px;width:39%">
                                  <div class="img"  >
                                      <asp:Image ID="Image5"   Width="80px"  Height="95px" runat="server" />
                                  </div>                                        
                              </div>
                              <div class="explain fl "  style="height:120px;width:60%">
                                  
                                    <li style="height:33%;Width:100%">  
                                 姓名：<asp:Label ID="Labe_xm3" runat="server" ></asp:Label>
                                </li>
                                <li style="height:33%;Width:100%">  
                                  部门： <asp:Label ID="Labe_bm3" runat="server" ></asp:Label> 
                                </li>
                               <li style="height:33%;Width:100%">  
                                   岗位：<asp:Label ID="Labe_gw3" runat="server" ></asp:Label>
                                </li>
                                 
                                       
                              </div>
                        </div>
                        <div class="p_l_t_product1 fl" style="height:120px;width:24%">
                                    
                             <div class="explain fl " style="height:100px;width:100%">
                                 <div style="height:30px;line-height:30px;">
                                      <a href="#"><h3 style="color:#9c1f00">主要事迹： </h3></a> 
                                 </div>
                                <div style="height:70px;width:210px; margin-left:5px">
                                    <asp:Label ID="Labe_zysj3" runat="server" ></asp:Label> 
                                </div>            
                             </div>
                         </div>
                         <div class="p_l_t_product1 fl" style="height:120px;width:25%">
                              <div class="buy fl" style="height:100px;width:39%">
                                  <div class="img"  >
                                      <asp:Image ID="Image6"   Width="80px"  Height="95px" runat="server" />
                                  </div>                                        
                              </div>
                              <div class="explain fl "  style="height:120px;width:60%">
                                  
                                    <li style="height:33%;Width:100%">  
                                 姓名：<asp:Label ID="Labe_xm4" runat="server" ></asp:Label>
                                </li>
                                <li style="height:33%;Width:100%">  
                                  部门： <asp:Label ID="Labe_bm4" runat="server" ></asp:Label> 
                                </li>
                               <li style="height:33%;Width:100%">  
                                   岗位：<asp:Label ID="Labe_gw4" runat="server" ></asp:Label>
                                </li>
                                 
                                       
                              </div>
                        </div>
                        <div class="p_l_t_product1 fl" style="height:120px;width:25%">
                                    
                             <div class="explain fl " style="height:100px;width:100%">
                                 <div style="height:30px;line-height:30px;">
                                      <a href="#"><h3 style="color:#9c1f00">主要事迹： </h3></a> 
                                 </div>
                                <div style="height:70px;width:210px; margin-left:5px;color:#F00">
                                    <asp:Label ID="Labe_zysj4" runat="server"  ></asp:Label> 
                                </div>            
                             </div>
                         </div>                                                       
                 </div>
            </div>                                                                                      
        </div> 
   </div>
           <div id="footer" style="margin-top:50px;"> 
               <div id="footerMsg" style="background:url(../../Content/images/nav_bg.gif) repeat-x;">
                 <div style="color:white;font-size:15px;" > Copyright&copy;吉林省民航机场集团公司</div>
               </div>
            </div>
</div>
<script type="text/javascript">
	onload=function(){
		var arr = document.getElementsByClassName("slide");
		for(var i=0;i<arr.length;i++){
			arr[i].style.left = i*380+"px";
		}
	}
	function LeftMove(){
		var arr = document.getElementsByClassName("slide");//获取三个子div
		for(var i=0;i<arr.length;i++){
			var left = parseFloat(arr[i].style.left);
			left-=2;
			var width = 380;//图片的宽度
			if(left<=-width){
				left=(arr.length-1)*width;//当图片完全走出显示框，拼接到末尾
				clearInterval(moveId);
			}
			arr[i].style.left = left+"px";
		}
	}
	function divInterval(){
		moveId=setInterval(LeftMove,10);//设置一个10毫秒定时器
	}
	
	
	timeId=setInterval(divInterval,2000);//设置一个3秒的定时器。
	
	function stop(){
		clearInterval(timeId);
	}
	function start(){
		clearInterval(timeId);
		timeId=setInterval(divInterval,2000);
	}
	
	//页面失去焦点停止
	onblur = function(){
		stop();
	}
	//页面获取焦点时开始
	onfocus = function(){
		start();
	}
</script>
    </form>
</asp:Content>
