<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="user_info_modify.aspx.cs" Inherits="user_info_modify" Title="�����޸�" %>

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
                ��������</td>
        </tr>
             <tr>
            <td class="style4" colspan ="2" width="100%">�ɡ��ģ� <asp:Label ID="Label_id" runat="server" Text="Label"></asp:Label><br /> �û����� <asp:Label ID="Label_username" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td class="style4" bgcolor="Gray">
                �ǳƣ�</td>
            <td class="style2">
                <asp:TextBox ID="TextBox_nickname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox_nickname" ErrorMessage="�ǳƱ�����д"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                ��ַ��</td>
            <td>
                <asp:TextBox ID="TextBox_city" runat="server" MaxLength="15" Width="494px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                �ֻ���</td>
            <td>
                <asp:TextBox ID="TextBox_mobile" runat="server" MaxLength="11"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextBox_mobile" ErrorMessage="�ֻ�����д����" 
                    ValidationExpression="^\d{3,11}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                ��Ȥ��</td>
            <td>
                <asp:TextBox ID="TextBox_interest" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <td class="style5" bgcolor="Gray">
                �ѣѣ�</td>
            <td>
                <asp:TextBox ID="TextBox��qq" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox��qq" Display="Dynamic" ErrorMessage="QQ����д����" 
                    ValidationExpression="^\d{5,11}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
                        <tr>
            <td class="style5" bgcolor="Gray">
                ���䣺</td>
            <td>
                <asp:TextBox ID="TextBox_email" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator_email" runat="server" 
                    ControlToValidate="TextBox_email" Display="Dynamic" ErrorMessage="�����ʽ����" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        
        
               <tr>
            <td class="style5" bgcolor="Gray">
                �Ա�</td>
            <td>
                <asp:DropDownList ID="DropDownList_sex" runat="server">
                    <asp:ListItem Selected="True" Value="1">��</asp:ListItem>
                    <asp:ListItem Value="0">Ů</asp:ListItem>
                </asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td class="style5"bgcolor="Gray">
                ���䣺</td>
            <td>
                <asp:TextBox ID="TextBox_age" runat="server" MaxLength="3" Width="73px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="TextBox_age" ErrorMessage="������д����" 
                    ValidationExpression="^\d{1,3}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                ���룺(Ϊ�ղ��޸�)</td>
            <td>
                <asp:TextBox ID="TextBox_pwd" runat="server" MaxLength="11"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TextBox_repwd" ControlToValidate="TextBox_pwd" 
                    ErrorMessage="�������벻һ��"></asp:CompareValidator>
            </td>
        </tr>
                <tr>
            <td class="style5" bgcolor="Gray">
                �ٴ��������룺</td>
            <td>
                <asp:TextBox ID="TextBox_repwd" runat="server" MaxLength="11"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td class="style5" align="center" bgcolor="Gray" colspan="2">
                <asp:Button ID="Button_sure" runat="server" Text="����" 
                    onclick="Button_sure_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_canel" runat="server" Text="Ԥ������" 
                    onclick="Button_canel_Click" />
                    </td>
        </tr>
    </table>
</asp:Content>

