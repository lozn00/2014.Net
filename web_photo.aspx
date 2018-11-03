<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="web_photo.aspx.cs" Inherits="Default2" Title="相册" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
      <asp:HyperLink id="lnkPrev" runat="server"><< 上一页</asp:HyperLink> 
<asp:HyperLink id="lnkNext" runat="server">下一页 >></asp:HyperLink> <br />
 <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />

    <asp:DataList ID="DataList1" runat="server" RepeatColumns="6" 
            RepeatDirection="Horizontal" 
         >
        <ItemTemplate>
            
              <table align="center"  border ="1"  bordercolor="green" cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td><asp:ImageButton ID="ImageButton1" runat="server"  CommandArgument='<%#Eval("pic") %>'  OnCommand="good" ImageUrl='<% #Eval("pic") %>' Height="153"  Width="153"/></td>
            </tr>
            <tr bgcolor="green">
                <td><asp:Label ID="Label1" runat="server" Text='<%#Eval("remark") %>'>&#39;&gt;</asp:Label></td>
            </tr>
                   </table>
        
           <!-- <asp:Image ID="Image1" runat="server" Width="100" Height="100" ImageUrl='<% #Eval("pic") %>' />-->
        </ItemTemplate>
        </asp:DataList>
 









</asp:Content>

