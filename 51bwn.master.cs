using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class admin_master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

       // Label1.Text = Application["count"].ToString();
       // Label2.Text = Application["counter"].ToString();

        if (Session["username"] != null)
        {

            if (Session["login"] == "admin")
            {

                Label_login.Text = "亲爱的管理员 " + Session["username"] + "您好，<b>【<a href=user_info_view.aspx?id=" + Session["id"] + ">我的信息</a>|<a href=admin/default.aspx>后台管理</a>|<a href=exit.aspx>退出</a>】";
                    
            
            
            
            
            
            
            }

            else

            {


                Label_login.Text = "亲爱的用户" + Session["username"] + " 欢迎您的到来【<a href=user_info_view.aspx?id="+Session ["id"]+">我的信息</a>|<a href=exit.aspx>退出登录</a>】";
                    
            
            
            
            
            
            
            
            
            }
        
        
        
        
        
        
        }






 Label_online .Text = Application["count"].ToString();
      Label_count .Text = Application["counter"].ToString();








    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Response.Redirect("../web_login.aspx");

    }
}
