<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="user_info_modify.aspx.cs" Inherits="user_info_modify" Title="资料修改" %>

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
            <td class="style4" colspan ="2" width="100%">Ｉ　Ｄ： <asp:Label ID="Label_id" runat="server" Text="Label"></asp:Label><br /> 用户名： <asp:Label ID="Label_username" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td class="style4" bgcolor="Gray">
                昵称：</td>
            <td class="style2">
                <asp:TextBox ID="TextBox_nickname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox_nickname" ErrorMessage="昵称必须填写"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                地址：</td>
            <td>
                <asp:TextBox ID="TextBox_city" runat="server" MaxLength="15" Width="494px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                手机：</td>
            <td>
                <asp:TextBox ID="TextBox_mobile" runat="server" MaxLength="11"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextBox_mobile" ErrorMessage="手机号填写错误" 
                    ValidationExpression="^\d{3,11}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                兴趣：</td>
            <td>
                <asp:TextBox ID="TextBox_interest" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <td class="style5" bgcolor="Gray">
                ＱＱ：</td>
            <td>
                <asp:TextBox ID="TextBox＿qq" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox＿qq" Display="Dynamic" ErrorMessage="QQ号填写错误" 
                    ValidationExpression="^\d{5,11}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
                        <tr>
            <td class="style5" bgcolor="Gray">
                邮箱：</td>
            <td>
                <asp:TextBox ID="TextBox_email" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator_email" runat="server" 
                    ControlToValidate="TextBox_email" Display="Dynamic" ErrorMessage="邮箱格式错误" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        
        
               <tr>
            <td class="style5" bgcolor="Gray">
                性别：</td>
            <td>
                <asp:DropDownList ID="DropDownList_sex" runat="server">
                    <asp:ListItem Selected="True" Value="1">男</asp:ListItem>
                    <asp:ListItem Value="0">女</asp:ListItem>
                </asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td class="style5"bgcolor="Gray">
                年龄：</td>
            <td>
                <asp:TextBox ID="TextBox_age" runat="server" MaxLength="3" Width="73px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="TextBox_age" ErrorMessage="年龄填写错误" 
                    ValidationExpression="^\d{1,3}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                密码：(为空不修改)</td>
            <td>
                <asp:TextBox ID="TextBox_pwd" runat="server" MaxLength="11"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TextBox_repwd" ControlToValidate="TextBox_pwd" 
                    ErrorMessage="两次密码不一致"></asp:CompareValidator>
            </td>
        </tr>
                <tr>
            <td class="style5" bgcolor="Gray">
                再次输入密码：</td>
            <td>
                <asp:TextBox ID="TextBox_repwd" runat="server" MaxLength="11"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td class="style5" align="center" bgcolor="Gray" colspan="2">
                <asp:Button ID="Button_sure" runat="server" Text="保存" 
                    onclick="Button_sure_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_canel" runat="server" Text="预览资料" 
                    onclick="Button_canel_Click" />
                    </td>
        </tr>
    </table>
</asp:Content>

