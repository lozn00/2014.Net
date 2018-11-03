using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class default_admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["login"] != "admin")
        {
           

            //Response.Write("登录超时或已掉线，2秒后跳转到登录界面<meta http-equiv='refresh' content='2;url=../web_login.aspx'><a href=../web_login.aspx>等不及了，马上进入</a>");
            Response.Redirect("../web_login.aspx");
            //  Response.Write("用户已掉线或非法进入，请重新<a href=zheng_login.aspx>登录</a>");

        }
        else
        { Label1.Text = Session["username"].ToString(); }

        
        

    }
}
