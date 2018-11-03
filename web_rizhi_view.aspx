<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="web_rizhi_view.aspx.cs" Inherits="web_rizhi_view" Title="文章浏览" %>

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
           

标题： <asp:Label ID="Label_title" runat="server" Text=""></asp:Label><br />
访问量： <asp:Label ID="Label_hit" runat="server" Text=""></asp:Label><br />
作者： <asp:Label ID="Label_author" runat="server" Text=""></asp:Label><br />
类别：<asp:Label ID="Label_lb" runat="server" Text=""></asp:Label><br />
时间：<asp:Label ID="Label_time" runat="server" Text=""></asp:Label><br />
 参考网址：<asp:Label ID="Label_link" runat="server" Text=""></asp:Label><br />
内容：<br /><asp:Label ID="Label_content" runat="server" Text=""></asp:Label>
        <asp:Panel ID="Panel_pwd" runat="server" BackColor="Red" Visible="False">
            <asp:TextBox ID="TextBox_pwd" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
            <asp:Button ID="Button_sub" runat="server" onclick="Button_sub_Click" 
                Text="提交密码进行查看" />
            <asp:Label ID="Label_tip" runat="server" Text="若不知道密码可以联系管理员索要"></asp:Label>
        </asp:Panel>
        <br /> 


   <a href="web_rizhi.aspx">返回上级</a>        
           <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
    
    </div>

</asp:Content>

