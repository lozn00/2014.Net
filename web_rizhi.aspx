<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="web_rizhi.aspx.cs" Inherits="web_rizhi" Title="日志" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
<asp:HyperLink id="lnkPrev" runat="server"><< 上一页</asp:HyperLink> 
<asp:HyperLink id="lnkNext" runat="server">下一页 >></asp:HyperLink>
      <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>-
      <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
      <asp:DataList ID="DataList1" runat="server" Width="951px">
      <ItemTemplate>
          ★ <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("title") %>' CommandArgument='<%#Eval("id") %>' OnCommand ="link"></asp:LinkButton><br />
          </ItemTemplate>
        
    </asp:DataList>
    </div>
</asp:Content>

