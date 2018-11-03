<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="user_info_view.aspx.cs" Inherits="user_info_view" Title="资料查看" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 24px;
        }
        .style3
        {
        }
        .style4
        {
            height: 24px;
            width: 115px;
        }
        .style5
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td align="center" bgcolor="Black" class="style3" colspan="2" 
                style="font-size: 15px; color: #FFFFFF;" valign="middle">
                个人资料</td>
        </tr>

             <tr>
         <td class="style5" bgcolor="Gray">  Ｉ　Ｄ： </td>    <td>        
               <asp:Label ID="Label_id" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        
     <tr>
         <td class="style5" bgcolor="Gray">
                用户名： </td>
            <td>
                
                <asp:Label ID="Label_username" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4" bgcolor="Gray">
                昵称：</td>
            <td class="style2">
                <asp:Label ID="Label_nickname" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                地址：</td>
            <td>
             <asp:Label ID="Label_city" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                手机：</td>
            <td><asp:Label ID="Label_mobile" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                兴趣：</td>
            <td><asp:Label ID="Label_interest" runat="server" Text="Label"></asp:Label></td>
        </tr>
                <tr>
            <td class="style5" bgcolor="Gray">
                ＱＱ：</td>
            <td><asp:Label ID="Label_qq" runat="server" Text="Label"></asp:Label></td>
        </tr>
                 <tr>     <td  class="style5" bgcolor="Gray">  邮箱：</td>
            <td><asp:Label ID="Label_email" runat="server" Text=""></asp:Label></td>
        </tr>
               <tr>
            <td class="style5" bgcolor="Gray">
                性别：</td>
            <td><asp:Label ID="Label_sex" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td class="style5"bgcolor="Gray">  年龄：</td>
            <td><asp:Label ID="Label_age" runat="server" Text="Label"></asp:Label></td>
        </tr>

                <tr>
            <td class="style5" bgcolor="Gray">
                注册时间：</td>
            <td><asp:Label ID="Label_regtime" runat="server" Text=""></asp:Label></td>
        </tr>
                <tr>
            <td class="style5" align="center" bgcolor="Gray" colspan="2">
                <asp:Button ID="Button_edit" runat="server" Text="编辑" 
                    onclick="Button_edit_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_index" runat="server" Text="首页" 
                    onclick="Button_index_Click" />
                    </td>
        </tr>
    </table>
</asp:Content>

