<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="guestbook_view.aspx.cs" Inherits="web_rizhi_view" Title="文章浏览" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
  <%--      <asp:DataList ID="DataList1" runat="server" Width="806px">
   <ItemTemplate>
标题： <asp:Label ID="Label1" runat="server" Text='<%# Eval("title")%>'></asp:Label><br />
作者： <asp:Label ID="Label2" runat="server" Text='<%# Eval("author")%>'></asp:Label><br />
类别：<asp:Label ID="Label_lb" runat="server" Text='<%# Eval("author")%>'></asp:Label><br />
时间：<asp:Label ID="Label3" runat="server" Text='<%# Eval("addtime")%>'></asp:Label><br />
内容：<br />
<asp:Label ID="Label4" runat="server" Text='<%# Eval("content")%>'></asp:Label><br /> 
 参考网址：
<asp:Label ID="Label5" runat="server" Text='<%# Eval("link")%>'></asp:Label><br />

</ItemTemplate>
           </asp:DataList>--%>
           

编号： <asp:Label ID="Label_id" runat="server" Text=""></asp:Label>
        <br />
        用户名：<asp:Label ID="Label_username" runat="server"></asp:Label><br />
        昵称： <asp:Label ID="Label_nickname" runat="server" Text=""></asp:Label><br />
联系QQ：<asp:Label ID="Label_QQ" runat="server" Text=""></asp:Label><br />
留言时间：<asp:Label ID="Label_time" runat="server" Text=""></asp:Label><br />
内容：<br />
        <asp:Panel ID="Panel_content"
            runat="server" BorderStyle="Dotted" Direction="LeftToRight" 
            ScrollBars="Auto" Width="100%" Wrap="true">
            <asp:Label ID="Label_content" 
                runat="server" EnableTheming="False" ></asp:Label>
        </asp:Panel>
<br />

<asp:Panel ID="Panel_reply" runat="server" Visible="False" BackColor="#66CCFF" 
            ScrollBars="Auto">

 管理员回复：<asp:Label ID="Label_reply" runat="server" ForeColor="Red"></asp:Label>  <br />
        回复时间：<asp:Label ID="Label_replytime" runat="server" ></asp:Label> <br />
               
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:TextBox ID="TextBox_reply" runat="server"></asp:TextBox><br />
           <asp:Button ID="Button1" runat="server" Text="删除" onclick="Button1_Click" />
            <asp:Button ID="Button2"
            runat="server" Text="回复" onclick="Button2_Click" />
            <br />
        
        
        </asp:Panel>
     <hr />


   <a href="guestbook_list.aspx">留言列表</a>    -  <a href="default.aspx">返回首页</a>        
        
    
    </div>

</asp:Content>

