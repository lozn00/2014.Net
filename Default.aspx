<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="情随事迁个人博客" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

.zheng_a
{
	width:100%;
clear:both;
float : left;	
text-align:center;
background-color:Black;
color:#ffffff;
margin-right:10px;

	
	
	}
	

	.zheng_b
{
	width:100%;
 /*margin-left:10px;*/
float : left;
text-align:center;
background-color:Black;
color:#ffffff;

	
	
	}

  
	.xiangce
{
	
width:300px;
height:422px;
overflow: hidden;
 margin-top:10px;
float : left;
position:relative;

	
	} 
	  
	.page123
{
	
width:300px;
height:auto;
margin-top:10px;
float : left;
background-color:Black;
color:White;
position:relative;

	
	} 
	
.newrizhi
{
margin-top:10px;
width:300px;
float : left;
position:relative;
border: 1px solid #000000;
	}  
	
	
	 
.rizhi
{
	
height:auto;
width:100%;
 margin-top:10px;
 margin-left:10px;
float : left;
position:relative;

	
	}   
	
 	
	
	#navleft {

}
			.zuo
{
	 margin-top:10px;
	 float: left;
    width: 300px;
    height: auto;
     border: 1px solid #FFF;
	}  
	
.you
{
float: left;
/*width: 65%;*/
width:626px;
/*height: auto;*/
height:693px;
margin-left: 10px;
 margin-top:10px;
display: inline;
overflow: hidden;
border: 1px solid #000000;
	}  


.link1 a:visidted{color:White}
.link1 a:hover{color:White}
.link1 a:active{color:White}
.link1 a:;link{color:White}
/*A:link 是有连接的文字的颜色
/A:visited 已经访问的连接的颜色
/A:active 活动连接的颜色
/A:hover 鼠标经过的颜色
-/*

	
	
	
    
        
    </style>
        <!--http://douguimei.qhfx.edu.cn/user1/douguimei/index.html!--></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="zuo">



<div class="zheng_a"><b>个人相册</b></div>



<div class="xiangce">
 <asp:DataList ID="DataList_photo" runat="server"><ItemTemplate>
    
              <table align="center"  border ="1"  bordercolor="green" cellpadding="0" cellspacing="0">
            <tr>
                <td><asp:ImageButton ID="ImageButton1" runat="server"  CommandArgument='<%#Eval("pic") %>'   OnCommand="good"  ImageUrl='<% #Eval("pic") %>'  Width="300" ImageAlign="Top" Height="400" /></td>
            </tr>
            <tr bgcolor="green">
                <td><asp:Label ID="Label_jieshao" runat="server" Text='<%#Eval("remark") %>'>&#39;&gt;</asp:Label></td>
            </tr>
                   </table>
 
 </ItemTemplate>  </asp:DataList>
   
    </div>
       <div class="link1">
   <div class="page123"> 

   <asp:HyperLink id="shang" runat="server">上页</asp:HyperLink> 
<asp:HyperLink id="xia" runat="server">下页</asp:HyperLink>-
    <asp:Label ID="Label_xianshi" runat="server" Text="Label"></asp:Label>  
        </div>
        </div> 

<div class="newrizhi">
<marquee direction="up" scrollamount="4" onmouseover="this.stop()" onmouseout="this.start()" behavior="alternate" > 
<asp:DataList ID="DataList_newrizhi" runat="server"   Width="300px">
 <ItemTemplate>
 <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# getsubstring(Eval("content").ToString(),20) %>' CommandArgument='<%#Eval("id") %>' OnCommand ="photo_link"></asp:LinkButton><br />
</ItemTemplate>        

 </asp:DataList></marquee>
 </div>

</div>

<div class="you">

<div class="zheng_b"><b>最新博文</b></div>

<div class="rizhi">
      <asp:DataList ID="DataList_rizhi" runat="server" Width="100%" 
           BackColor="White" 
          BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
          ForeColor="Black" GridLines="Horizontal">
          <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
          <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
      <ItemTemplate>
          ★ <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("title") %>' CommandArgument='<%#Eval("id") %>' OnCommand ="rizhi_link"></asp:LinkButton>
          <br />
          <asp:Label ID="Label2" runat="server" Text='<%# getsubstring(Eval("content").ToString(),50) %>'></asp:Label><br /> 
           </ItemTemplate>
        
    </asp:DataList>
</div>
</div>





</asp:Content>

