<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="web_login.aspx.cs" Inherits="web_login" Title="登录网站" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 44px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table  cellspacing="1" cellpadding="3" align="center" border="0" bgcolor="black" 
            style="width: 100%; height: 50px; margin-top:30px" >
<tr>
<td colspan="2" height="10">
<b style="text-align: left"><font color="white">用户登录</font></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <b style="text-align:right"><asp:Label ID="Label_Show" runat="server" ForeColor="Red"></asp:Label></b>
</td>
</tr>
 
<tr bgcolor="#f6f6f6">
<td bgcolor="#f6f6f6" class="style1"> <b>&nbsp;账号:</b>  </td>
 <td width="160" style=" height:auto" bgcolor="#f6f6f6" colspan="0"> &nbsp;<asp:TextBox 
         ID="TextBox1" runat="server" Width="270px" style=" margin-bottom: 5px" 
        ></asp:TextBox></td>
</tr>

 <tr>
<td bgcolor="#ffffff" class="style1"><b>&nbsp;密码:</b></td>
 <td width="160" bgcolor="#ffffff">&nbsp; 
     <asp:TextBox ID="TextBox2" runat="server" 
         Width="270px" TextMode="Password"></asp:TextBox></td>
</tr>

 <tr align="center" bgcolor="#FFFFFF">
   <td bgcolor="#FFFFFF" colspan="2" height="10">
      <asp:Button ID="Button_login" runat="server" Text="登录" onclick="Button_login_Click" />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
       <asp:Button ID="Button_reg" runat="server" onclick="Button_reg_Click" Text="注册" />
     &nbsp;</td>
 </tr>
                                                 
  </table>
</asp:Content>

