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
using System.Data.SqlClient;

public partial class web_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_reg_Click(object sender, EventArgs e)
    {
        Response.Redirect("userreg.aspx");
    }

    protected void Button_login_Click(object sender, EventArgs e)
    {

        if (TextBox1.Text.Trim() == "")
        {


            Label_Show.Text = "用户名不能为空！";
            return;
        }




        if (TextBox2.Text.Trim() == "")
        {


            Label_Show.Text = "密码不能为空！";
            return;
        }
        
        
        
        
        
        
        
        
        
        
        // string b = "server = localhost; database = zheng_website; Integrated Security = SSPI;";
        string a=ConfigurationSettings .AppSettings["DB"];
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
       
        string sql = "select * from users where username='" + TextBox1.Text +"'";
      
        SqlCommand cmd = new SqlCommand(sql,conn);
        SqlDataReader dw = cmd.ExecuteReader();
        if (dw.Read()) 
        {
            dw.Close();
            sql = "select * from users where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            //Response.Write(sql);
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            SqlDataReader dw1 = cmd1.ExecuteReader();
            if (dw1.Read())
            {
                Session["nickname"] = dw1["nickname"].ToString();
                Session["username"] = TextBox1.Text;
                Session ["id"]=dw1["id"].ToString();//用户用户名修改进行判断，如果是非法修改别人信息，需要管理员权限！
                Session["passwrod"] = TextBox2.Text;
                Session["dj"] = dw1["dj"];
                Session.Timeout =12;//12小时超时
                if (Convert.ToInt32(dw1["dj"]) == 1)//注册用户的时候强制设置普通用户为2，但是管理员则等级为1
                {
                    Session["login"] = "admin";
                    Label_Show.Text = "管理员,你好！<a href=admin/default.aspx>进入后台</a>";
                   // Response.Write("亲爱的管理员，你已登录成功！<a href=admin/default.aspx>马上进入后台</a>");

                }
                else
                {
                    Session["login"] = "user";
                    Label_Show.Text = "亲爱的用户,你好！<a href=default.aspx>进入首页</a>";
                   // Response.Write("登录成功！<a href=default.aspx>马上返回首页</a>");

                }

            }//如果查询为空，则说明用户名或密码错误。
            else
            {
                Label_Show.Text = "密码错误！不登录了,[<a href=default.aspx>首页</a>]";
                // Response.Write("密码错误！");
            }


        }
        else

        {
            Label_Show.Text = "用户名不存在！";
        
                
        }
        
       
    
    }




}
