<%@ Page Language="C#" MasterPageFile="admin.master" AutoEventWireup="true" CodeFile="page_photo.aspx.cs" Inherits="page_photo" Title="相册分页管理" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" 
            RepeatDirection="Horizontal" Width="100%">
        <ItemTemplate>
            
              <table align="center"  border ="1"  bordercolor="green" cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td><asp:ImageButton ID="ImageButton1" runat="server"  CommandArgument='<% #"../"+Eval("pic") %>'  OnCommand="good" ImageUrl='<% #"../"+Eval("pic") %>' Height="150"  Width="150"/></td>
            </tr>
            <tr bgcolor="green">
                <td><asp:Label ID="Label1" runat="server" Text='<%#Eval("remark") %>'>&#39;&gt;</asp:Label></td>
            </tr>
            <tr>
                <td><a href="image_del.aspx?id=<%#Eval("id") %>">删除此图片</a></td>
            </tr>
          <!--  <tr><td><asp:Label ID="Label2" runat="server" Text='<%#Eval("pic") %>'>&#39;&gt;</asp:Label></td></tr>-->
        </table>
        
           <!-- <asp:Image ID="Image1" runat="server" Width="100" Height="100" ImageUrl='<% #Eval("pic") %>' />-->
        </ItemTemplate>
        </asp:DataList>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label_link" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label_show_page" runat="server" Text=""></asp:Label>
    

</asp:Content>

