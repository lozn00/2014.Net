<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="photo_upload.aspx.cs" Inherits="admin_photo_upload" Title="上传图片" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        说明：
        <asp:TextBox ID="TextBox1" runat="server">图片说明</asp:TextBox><br />
       
        <asp:Button ID="Button1" runat="server"
            Text="上传文件" onclick="Button1_Click" />
        <br />
        <asp:Label ID="Label_show" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>

