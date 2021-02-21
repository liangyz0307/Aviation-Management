<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="MAir.Views.Test" %>
<!DOCTYPE html>
<html>
<head>
	<meta charset="UTF-8">
	<title>后台管理系统</title>
	<link rel="stylesheet" type="text/css" href="../../EasyUI/themes/default/easyui.css">
	<link rel="stylesheet" type="text/css" href="../../EasyUI/themes/icon.css">
    <link rel="stylesheet" type="text/css" href="../../EasyUI/demo/admin.css">
	<script type="text/javascript" src="../../EasyUI/jquery.min.js"></script>
	<script type="text/javascript" src= "../../EasyUI/jquery.easyui.min.js"></script>
</head>	
   
<body class="easyui-layout">
     <form id="Form1" runat="server">
         <div data-options="region:'north',border:false" style="height: 74px; background: #2596ea; padding: 10px">
        <%--<img src="../../Content/images/houtai.jpg" />--%>
    </div>   
         <div data-options="region:'west',split:true" title="后台管理系统" style="width: 170px;">
        <div class="easyui-accordion" data-options="fit:true,border:false">
            <div title="" data-options="selected:true">
                <div style="margin: 5px">
                    <ul class="tree easyui-tree" data-options="animate:true,lines:true" id="tree"  >
               
                    </ul>
                    
                </div>
            </div>
        </div>
    </div>
         <div data-options="region:'south',border:false" style="height: 23px;">
    <div class="footer" style="margin: 0 auto ;width:50%" > CopyRight</div>
         
    </div>
         <div data-options="region:'center',title:'您好，欢迎进入后台管理系统'">          
        <div id="tabs" class="easyui-tabs" style="width:100%" data-options="tools:'#tab-tools'">
               
           <div title="返回首页" style="width:50px;height:50px;" onclick="window.location.href='../MenHu/Sys_Index.aspx'">	   
               	  
	       </div>
       </div>          
    </div>
         <script type="text/javascript">      
        $(function () {
            //动态菜单数据 
            var treeData = [{
                text: "系统列表",
                state: "open",
          children: 
               [{
                    text: "字典管理",
                    state: "",
                    attributes: {
                        url: "ZDGL.aspx"
                    }
                }, {
                    text: "用户管理",
                    attributes: {
                        url: "YHGL.aspx"
                    }             
                }
              
                ]
            }
            ];
            
        
            //实例化树形菜单 
            $("#tree").tree({
                data: treeData,
                lines: true,
                onClick: function (node) {
                    if (node.attributes) {
                        Open(node.text, node.attributes.url);
                    }
                }
            });
            //在右边center区域打开菜单，新增tab 
            function Open(text, url) {
                var content = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
                if ($("#tabs").tabs('exists', text)) {
                    $('#tabs').tabs('select', text);
                } else {
                    $('#tabs').tabs('add', {
                        title: text,
                        closable: true,
                        content: content
                    });
                }
               
            }

            //绑定tabs的右键菜单 
            $("#tabs").tabs({
                onContextMenu: function (e, title) {
                    e.preventDefault();
                    $('#tabsMenu').menu('show', {
                        left: e.pageX,
                        top: e.pageY
                    }).data("tabTitle", title);
                }
            });
        });
    </script>
    </form>
</body>    
</html>
