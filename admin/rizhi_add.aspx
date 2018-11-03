<%@ Page Language="C#" MasterPageFile="admin.master" AutoEventWireup="true" CodeFile="rizhi_add.aspx.cs" Inherits="rizhi_add" Title="添加文章"  validateRequest=false  %>

<%@ Register assembly="DotNetTextBox" namespace="DotNetTextBox" tagprefix="DNTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style6
    {
        width: 100%;
    }
    .style7
    {
        width: 99px;
    }
        .style8
        {
            width: 99px;
            height: 66px;
        }
        .style9
        {
            height: 66px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style6" border="1" bordercolor="black" width="100%" cellpadding =0 cellpadding cellspacing =0>
    <tr>
        <td class="style7">
            文章标题：</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="700px">今天是个好日子</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style7">
            文章内容：</td>
        <td>
            <DNTB:WebEditor ID="WebEditor1" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="style7">
            文章类别：</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="17px" Width="173px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style7">
            作者</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server" Width="700px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style7">
            相关链接：</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server" Width="700px"></asp:TextBox>
        </td>
    </tr>
        <tr>
        <td class="style7">
            访问密码：</td>
        <td>
            <asp:TextBox ID="TextBox_pwd" runat="server" Width=100px MaxLength="10"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style8">
            <asp:Button ID="Button1" runat="server" Text="发布文章" onclick="Button1_Click" />
        </td>
        <td class="style9">
            <asp:Label ID="Label1" runat="server" Text="请选择一个操作"></asp:Label>
            </td>
    </tr>
</table>
</asp:Content>

