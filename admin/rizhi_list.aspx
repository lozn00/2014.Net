<%@ Page Language="C#" MasterPageFile="admin.master" AutoEventWireup="true" CodeFile="rizhi_list.aspx.cs" Inherits="rizhi_list" Title="管理文章" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:DataList ID="DataList1" runat="server" Height="204px" Width="100%" 
        GridLines="Horizontal" RepeatColumns="1" BorderWidth="1px" 
        RepeatDirection="Horizontal" style="margin-left: 72px; margin-right: 51px" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" CellPadding="4" 
        ForeColor="Black">
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <ItemTemplate>
       标题: <asp:Label ID="Label1" runat="server" Text='<%#Eval("title") %>'></asp:Label>
        <br />
        相关链接:<asp:Label ID="Label2" runat="server" Text='<%#Eval("link") %>'></asp:Label>
        <br />
         作者:<asp:Label ID="Label3" runat="server" Text='<%#Eval("author") %>'></asp:Label>
         <br />          
        <asp:Button ID="Button1"
            runat="server" OnCommand="del" CommandArgument='<%#Eval("id") %>' Text="删除" />-<asp:Button ID="Button_modify"
            runat="server" OnCommand="modify" CommandArgument='<%#Eval("id") %>' Text="修改" />
        

    </ItemTemplate>
        <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
    <asp:TextBox ID="TextBox_search" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button_search" runat="server" Text="搜索  显示" 
        onclick="Button_search_Click" /><br />
    <asp:Label ID="Label4" runat="server" Text="筛选出标题、内容、作者或ID关键字"></asp:Label>
</asp:Content>

