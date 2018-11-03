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

public partial class user_info_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["username"] 
    
        // string sql = "select * from news where id=" + urlid;

        string urlid = Request.QueryString["id"];
        if (urlid == null || Session ["id"]==null)//传递id或者 登陆者id为空强制跳转到首页
        { Response.Redirect("default.aspx"); }

        SqlConnection conn = new SqlConnection(diy.getconnstring());
        conn.Open();
        string sql = "select * from users where id=" + urlid;
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader sqlread = cmd.ExecuteReader();
        sqlread.Read();//不读取会报错
        //不强制转换为string为报错！
        Label_id.Text = sqlread["id"].ToString();

        Label_username.Text = sqlread["username"].ToString();
      
      Label_city.Text = sqlread["city"].ToString();

      Label_interest.Text = sqlread["interest"].ToString();
     
      Label_nickname.Text = sqlread["nickname"].ToString();

      if (Label_id.Text.ToString () != Session["id"].ToString ())
      {
          if (diy.root() != true)
          {
              Label_age.Text = "保密";
              Label_mobile.Text = "保密";
              Label_qq.Text = "保密";
              Label_regtime.Text = "保密";
              Label_sex.Text = "保密";
              Label_email.Text = "保密";
              return;
              conn.Close();
          }
      }
      Label_age.Text = sqlread["age"].ToString();
      Label_mobile.Text = sqlread["mobile"].ToString();
      Label_qq.Text = sqlread["qq"].ToString();
      Label_email.Text = sqlread["email"].ToString();
   string sex = sqlread["sex"].ToString();

   if (sex== "1")
   {
       Label_sex.Text = "男";
   }
   else
   {
       Label_sex.Text = "女";
   }


 
        Label_regtime .Text =sqlread["regtime"].ToString();
        conn.Close();

    }


    protected void Button_edit_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_info_modify.aspx?id="+Request.QueryString["id"]);
    }
    protected void Button_index_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
}
