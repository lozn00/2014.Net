<%@ Page Language="C#" MasterPageFile="admin.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="default_admin" Title="后台管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" EnableViewState="False">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="管理员" Font-Bold="True" 
            ForeColor="Red"></asp:Label> ,欢迎来到管理后台！<br /></p>
            博客目前支持的功能如下：<br />
            <b>博文功能：</b><br />
            1.博文发表 博文分页浏览 博文类别管理 博文修改(包括类别修改.定义查看密码) 博文删除 <br />
            <b>相册功能：</b><br />
            2.定义相册备注 上传相片 删除相片 分页显示相片<br />
             <b>留言功能：</b><br />
            2.需要注册登录才能发表留言 管理员可以回复用户发表的留言 留言分页查看列表 <br />
             <b>登录注册功能：</b><br />
            2.强制输入联系方式方可注册。严格检查邮箱.QQ号书写是否正确！<br />
</asp:Content>

