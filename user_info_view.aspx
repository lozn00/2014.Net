<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="user_info_view.aspx.cs" Inherits="user_info_view" Title="���ϲ鿴" %>

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
         <td class="style5" bgcolor="Gray">  �ɡ��ģ� </td>    <td>        
               <asp:Label ID="Label_id" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        
     <tr>
         <td class="style5" bgcolor="Gray">
                �û����� </td>
            <td>
                
                <asp:Label ID="Label_username" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4" bgcolor="Gray">
                �ǳƣ�</td>
            <td class="style2">
                <asp:Label ID="Label_nickname" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                ��ַ��</td>
            <td>
             <asp:Label ID="Label_city" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                �ֻ���</td>
            <td><asp:Label ID="Label_mobile" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td class="style5" bgcolor="Gray">
                ��Ȥ��</td>
            <td><asp:Label ID="Label_interest" runat="server" Text="Label"></asp:Label></td>
        </tr>
                <tr>
            <td class="style5" bgcolor="Gray">
                �ѣѣ�</td>
            <td><asp:Label ID="Label_qq" runat="server" Text="Label"></asp:Label></td>
        </tr>
                 <tr>     <td  class="style5" bgcolor="Gray">  ���䣺</td>
            <td><asp:Label ID="Label_email" runat="server" Text=""></asp:Label></td>
        </tr>
               <tr>
            <td class="style5" bgcolor="Gray">
                �Ա�</td>
            <td><asp:Label ID="Label_sex" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td class="style5"bgcolor="Gray">  ���䣺</td>
            <td><asp:Label ID="Label_age" runat="server" Text="Label"></asp:Label></td>
        </tr>

                <tr>
            <td class="style5" bgcolor="Gray">
                ע��ʱ�䣺</td>
            <td><asp:Label ID="Label_regtime" runat="server" Text=""></asp:Label></td>
        </tr>
                <tr>
            <td class="style5" align="center" bgcolor="Gray" colspan="2">
                <asp:Button ID="Button_edit" runat="server" Text="�༭" 
                    onclick="Button_edit_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_index" runat="server" Text="��ҳ" 
                    onclick="Button_index_Click" />
                    </td>
        </tr>
    </table>
</asp:Content>

