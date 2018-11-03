<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="userreg.aspx.cs" Inherits="userreg" Title="用户注册" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 168px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" cellpadding="0" cellspacing="0" class="style1" bordercolor="black">
        <tr>
            <td class="style2">
                &nbsp;用户名：&nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox_username" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Required_username" runat="server" 
                    ErrorMessage="用户名必须填写" ControlToValidate="TextBox_username" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextBox_username" Display="Dynamic" ErrorMessage="用户名长度不合法" 
                    ValidationExpression="^[\u4e00-\u9fa5]{1,10}$|^[\dA-Za-z_]{1,20}$"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                    ControlToValidate="TextBox_username" ErrorMessage="用户名已存在" 
                    onservervalidate="userexist"></asp:CustomValidator>
            </td>
        </tr>
                <tr>
            <td class="style2">
                昵称：</td>
            <td>
                <asp:TextBox ID="TextBox_nickname" runat="server"  Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="昵称必须填写" ControlToValidate="TextBox_nickname"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="TextBox_nickname" Display="Dynamic" ErrorMessage="昵称填写不合法" 
                    ValidationExpression="^[\u4e00-\u9fa5]{1,10}$|^[\dA-Za-z_]{1,20}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        
        
        <tr>
            <td class="style2">
                密码：</td>
            <td>
                <asp:TextBox ID="TextBox_pwd" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Required_pwd" runat="server" 
                    ErrorMessage="密码必须填写" ControlToValidate="TextBox_pwd"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="TextBox_pwd" Display="Dynamic" ErrorMessage="密码长度不合法" 
                    ValidationExpression="^[\dA-Za-z_]{1,30}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        
        <tr>
            <td class="style2">
                重新输入密码：</td>
            <td>
                <asp:TextBox ID="TextBox_rewpd" runat="server" TextMode="Password" 
                    Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Required_repwd" runat="server" 
                    ErrorMessage="二次密码必须填写" ControlToValidate="TextBox_pwd"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TextBox_pwd" ControlToValidate="TextBox_rewpd" 
                    ErrorMessage="二次密码不相同"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                邮箱：</td>
            <td>
                <asp:TextBox ID="TextBox_email" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Required_reg" runat="server" 
                    ErrorMessage="邮箱必须填写" ControlToValidate="TextBox_email"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox_email" Display="Dynamic" ErrorMessage="邮箱格式不正确" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
                <tr>
            <td class="style2">
                 ＱＱ：</td>
            <td>
                <asp:TextBox ID="TextBox_qq" runat="server" Width="250px"></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="TextBox_qq" Display="Dynamic" ErrorMessage="qq号填写错误" 
                    ValidationExpression="^\d{5,11}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        
                    <td class="style2">
                 性别：</td>
            <td>
                <asp:RadioButton ID="RadioButton_man" runat="server" Checked =true  GroupName="sex"  Text ="男"/> <asp:RadioButton ID="RadioButton_woman" runat="server"  GroupName="sex"   Text="女"/>
      
            </td>
        </tr>
        
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;
                <asp:Button ID="Button_reg" runat="server" Text="注册" 
                    onclick="Button_reg_Click" />                 <asp:Button ID="Button_login" 
                    runat="server" Text="登录" CausesValidation="False" 
                    onclick="Button_login_Click" />

                <asp:Label ID="Label_show" runat="server" Text=""></asp:Label>

            </td>
        </tr>
    </table>
</asp:Content>

