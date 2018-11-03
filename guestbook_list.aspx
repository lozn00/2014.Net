<%@ Page Language="C#" MasterPageFile="~/51bwn.master" AutoEventWireup="true" CodeFile="guestbook_list.aspx.cs" Inherits="web_rizhi" Title="日志" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
<asp:HyperLink id="lnkPrev" runat="server" BorderStyle="Outset"><< 上一页</asp:HyperLink> &nbsp; 
<asp:HyperLink id="lnkNext" runat="server" BorderStyle="Outset">下一页 >></asp:HyperLink>
<hr />
        <asp:Button ID="Button_addguestbook" runat="server" Text="添加留言" 
            onclick="Button_addguestbook_Click" />
        <hr />
      <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>-
      <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
            <asp:DataList ID="DataList1" runat="server" Width="950px" BorderWidth="1px">
      <ItemTemplate>
      
          ★ <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Left(Eval("content").ToString(), 20) %>' CommandArgument='<%#Eval("id") %>' OnCommand ="link"></asp:LinkButton><br />
         
          称呼： <asp:Label ID="Label_nickname" runat="server" Text='<%# Eval("nickname") %>'></asp:Label> 时间： <asp:Label ID="Label_time" runat="server" Text='<%# Eval("addtime") %>'></asp:Label> <br />          
          </ItemTemplate>
        
                <ItemStyle BorderStyle="Outset" />
        
    </asp:DataList>
      <a href="default.aspx">返回首页</a>   
    </div>
</asp:Content>

