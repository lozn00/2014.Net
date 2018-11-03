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

public partial class guestbook_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (Session["login"]== null)
        {
            Response.Redirect("web_login.aspx");
            return;
        }


      TextBox_nickname .Text   = Session["nickname"].ToString () ;


        

    }
    protected void Button_index_click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
    protected void Button_add_Click(object sender, EventArgs e)
    {

        if (Page.IsValid  == false)
        {
            return;
            //说明验证控件有验证不通过！
        }
        
        
        
        string connstr = diy.getconnstring ();
       SqlConnection conn = new SqlConnection(connstr);
       conn.Open();
       string sql = "insert into guestbook(nickname,content,qq,username)values('" + TextBox_nickname.Text.Trim() + "','" + TextBox_content.Text + "','" + TextBox_qq.Text + "','" + Session ["username"]+ "')";

      SqlCommand cmd = new SqlCommand(sql,conn);

     int i= cmd.ExecuteNonQuery();
     if (i > 0)
     {
         Response.Write("<script>alert(\"留言成功\")</script>");

         Response.Redirect("guestbook_list.aspx");


     }
     else
     {
         Response.Write("<script>alert(\"留言失败！请联系管理员:"+diy.contact ()+"\")</script>");
     }
       // Response.Write(connstr);
     conn.Close();
       
    }
 
    protected void Button_guestbook_Click(object sender, EventArgs e)
    {
        Response.Redirect("guestbook_list.aspx");
    }
}
