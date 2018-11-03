<%@ Page Language="C#" MasterPageFile="admin.master" AutoEventWireup="true" CodeFile="usermanager.aspx.cs" Inherits="zheng_modifysort" Title="用户管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style1
        {
            width: 182px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  
        Height="16px" Width="960px" 
OnRowEditing="edit" 
OnRowCancelingEdit="cancel"
OnRowUpdating="update" 
OnRowDeleting="delete"
DataKeyNames ="id" BackColor="White" BorderColor="#999999" 
    BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" 
        BorderStyle="Solid"
 >

        <FooterStyle BackColor="#CCCCCC" />

        <Columns>
            <asp:TemplateField HeaderText="ID">
        
                <ItemTemplate>
                    <asp:Label ID="Label_id" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox_id" runat="server" Text='<%# Eval("id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="用户名">
                <EditItemTemplate>
                   
                    <asp:TextBox ID="TextBox_username" runat="server"   Text='<%# Eval("username") %>'></asp:TextBox>
                   
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label_username" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="昵称">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox_nickname" runat="server"    Text='<%#Eval("nickname")%>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label_nickname" runat="server" Text='<%# Eval("nickname") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="权限">
                <ItemTemplate>
                    <asp:Label ID="Label_root" runat="server" Text='<%# Eval("dj") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox_root" runat="server"  Text='<%# Eval("dj") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑">
                <ItemTemplate>
                    <asp:Button ID="Button_edit" runat="server" CommandName="edit" Text="编辑" />
                    <asp:Button ID="Button_del" runat="server" CommandName="delete" Text="删除" />
                    &nbsp;<asp:Button ID="Button_more" runat="server" Text="更多"  CommandArgument='<% # Eval("id") %>'  OnCommand ="Button_edit_more_Click" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="Button_update" runat="server" CommandName="update" Text="更新" />
                    <asp:Button ID="Button_cancle" runat="server" CommandName="cancel" Text="取消" />
                    <asp:Button ID="Button_edit_more" runat="server" Text="更多"  CommandArgument='<% # Eval("id") %>'  OnCommand="Button_edit_more_Click" />
                </EditItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle ForeColor="Black" HorizontalAlign="Center" 
            BackColor="#999999" />
        <SelectedRowStyle BackColor="#000099" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#CCCCCC" />
    </asp:GridView>
    
    
  <table border =1  width="100%" cellpadding =0 cellspacing =0 bordercolor="black">
  <tr><td colspan ="2"><asp:HyperLink id="lnkPrev" runat="server"><< 上一页</asp:HyperLink>-<asp:HyperLink id="lnkNext" runat="server">下一页 >></asp:HyperLink></td></tr>
  <tr><td colspan ="2">  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>-  <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td></tr>
  <tr><td class="style1">
   Ｉ　Ｄ：<asp:TextBox ID="TextBox_id_add" runat="server"></asp:TextBox><br />
   用户名：<asp:TextBox ID="TextBox_username_add" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button_add" runat="server" Text="添加账号"  OnCommand="insert" />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
          ControlToValidate="TextBox_id_add" Display="Dynamic" ErrorMessage="ID填写错误" 
          ValidationExpression="^\d{1,8}$"></asp:RegularExpressionValidator>
      </td>
      <td>
        <asp:Label ID="Label_show" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label></td></tr>
</table>
</asp:Content>

