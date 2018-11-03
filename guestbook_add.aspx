<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="guestbook_add.aspx.cs" Inherits="guestbook_add" Title="给我留言" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 100%;
        }
        .style2
        {
            width: 135px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style1" border="1" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td class="style2">
                内容：</td>
            <td>
                <asp:TextBox ID="TextBox_content" runat="server" Width="100%" 
                    TextMode="MultiLine"></asp:TextBox>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextBox_content" ErrorMessage="输入的内容过多" 
                    ValidationExpression="^([\s\S]*){1,500}$" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox_content" Display="Dynamic" ErrorMessage="内容必须填写"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                联系QQ：</td>
            <td>
                <asp:TextBox ID="TextBox_qq" runat="server" Width="20%" MaxLength="12"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox_qq" Display="Dynamic" ErrorMessage="QQ号填写错误" 
                    ValidationExpression="^\d{5,11}$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox_qq" Display="Dynamic" ErrorMessage="QQ号必须填写"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style2">
                称呼：</td>
            <td>
                <asp:TextBox ID="TextBox_nickname" runat="server" 
                    Width="20%"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="TextBox_nickname" ErrorMessage="输入的昵称过长" 
                    ValidationExpression="^.{1,10}$" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox_nickname" Display="Dynamic" ErrorMessage="昵称必须填写"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button_add" runat="server" Text="添加留言" 
                    onclick="Button_add_Click" />
            &nbsp;&nbsp;
                <asp:Button ID="Button_add_guestbook" runat="server" Text="留言首页" 
                    onclick="Button_guestbook_Click" CausesValidation="False" />
            &nbsp;
                <asp:Button ID="Button_index" runat="server" CausesValidation="False" 
                    onclick="Button_index_click" Text="返回首页" />
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
    
    
    </asp:Panel>
</asp:Content>

