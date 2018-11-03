<%@ Page Language="C#" MasterPageFile="admin.master" AutoEventWireup="true" CodeFile="web_modifyphoto.aspx.cs" Inherits="web_modifyphoto" Title="相册管理" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" 
            RepeatDirection="Horizontal">
        <ItemTemplate>
            
              <table align="center"  border ="1"  bordercolor="green" cellpadding="0" 
                  cellspacing="0" class="style1" style="width: 150px">
            <tr>
                <td class="style6">
                <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<% #"../"+Eval("pic") %>'  OnCommand="bwn"  ImageUrl='<% #"../"+Eval("pic") %>' Height="150"  Width="150"/></td>
            </tr>
            <tr bgcolor="green">
                <td class="style6"><asp:Label ID="Label1" runat="server" Text='<%#Eval("remark") %>'>&#39;&gt;</asp:Label></td>
            </tr>
            <tr>
                <td class="style6"><a href="image_del.aspx?id=<%#Eval("id") %>">删除此图片</a></td>
            </tr>
          <!--  <tr><td><asp:Label ID="Label2" runat="server" Text='<%#Eval("pic") %>'>&#39;&gt;</asp:Label></td></tr>-->
        </table>
        
           <!-- <asp:Image ID="Image1" runat="server" Width="100" Height="100" ImageUrl='<% #Eval("pic") %>' />-->
        </ItemTemplate>
        </asp:DataList>
        <hr color="red" />
        <asp:LinkButton ID="LinkButton1" runat="server"
            PostBackUrl="~/admin/photo_upload.aspx">上传图片</asp:LinkButton>
             <asp:LinkButton ID="LinkButton2" runat="server"  PostBackUrl="~/admin/page_photo.aspx">分页管理</asp:LinkButton>
            
            
            
</asp:Content>

