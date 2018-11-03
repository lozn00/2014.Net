<%@ Page Language="C#" MasterPageFile="admin.master" AutoEventWireup="true" CodeFile="rizhi_modify.aspx.cs" Inherits="rizhi_modify" Title="修改文章" validateRequest=false  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style6
    {
        width: 100%;
        border-bottom-color:Black;
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
        .style10
        {
            width: 99px;
            height: 28px;
        }
        .style11
        {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style6" border="1" bordercolor="black" dir="ltr" width="700px" cellpadding="0">
    <tr>
        <td class="style10">
            文章标题：</td>
        <td class="style11">
            <asp:TextBox ID="TextBox_title" runat="server" Width="700px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style7">
            文章内容：</td>
        <td>
            <asp:TextBox ID="TextBox_content" runat="server"   Rows="8" 
                TextMode="MultiLine" Width="100%" Height="700px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style7">
            文章类别：</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="17px" Width="700px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="style7">
            作者</td>
        <td>
            <asp:TextBox ID="TextBox_author" runat="server" Width="700px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style7">
            相关链接：</td>
        <td>
            <asp:TextBox ID="TextBox_link" runat="server" Width="700px"></asp:TextBox>
        </td>
    </tr>
        <tr>
        <td class="style7">
            设置密码：</td>
        <td>
            <asp:TextBox ID="TextBox_pwd" runat="server" Width="177px" MaxLength="10"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style8">
            <asp:Button ID="Button1" runat="server" Text="修改文章" onclick="Button1_Click" />
        </td>
        <td class="style9">
            <asp:Label ID="Label1" runat="server" Text="请选择一个操作"></asp:Label>
            </td>
    </tr>
</table>
</asp:Content>

