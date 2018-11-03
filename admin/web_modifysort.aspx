<%@ Page Language="C#" MasterPageFile="admin.master" AutoEventWireup="true" CodeFile="web_modifysort.aspx.cs" Inherits="zheng_modifysort" Title="类别管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 219px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  
        Height="20px" Width="100%" 
OnRowEditing="edit" 
OnRowCancelingEdit="cancel"
OnRowUpdating="update" 
OnRowDeleting="delete"
DataKeyNames ="sort_id" BackColor="White" BorderColor="#999999" 
    BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" 
        BorderStyle="Solid"
 >

        <FooterStyle BackColor="#CCCCCC" />

        <Columns>
            <asp:TemplateField HeaderText="编号">
        
                <ItemTemplate>
                    <asp:Label ID="Label_bianhao" runat="server" Text='<%#Eval("sort_id")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="类别标题">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox_sort" runat="server" Text='<%#Eval("sort_name")%>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label_sort" runat="server" Text='<%#Eval("sort_name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="类别短名">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox_shortname" runat="server" Text='<%#Eval("short_name")%>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label_shortname" runat="server" Text='<%#Eval("short_name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑">
                <EditItemTemplate>
                    <asp:Button ID="Button_update" runat="server" CommandName="update" Text="更新" />
                    <asp:Button ID="Button_cancle" runat="server" CommandName="cancel"  Text="取消" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="Button_edit" runat="server"  CommandName="edit" Text="编辑"  />
                    <asp:Button ID="Button_del" runat="server" CommandName="delete"  Text="删除" />
                </ItemTemplate>
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
   类别全名：<asp:TextBox ID="TextBox_sorts" runat="server"></asp:TextBox><br />
   类别简称：<asp:TextBox ID="TextBox_shorts" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button_insert" runat="server" Text="添加类别"  OnCommand="insert" /></td><td></td>
    </tr>
    </table>

</asp:Content>

