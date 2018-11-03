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

public partial class user_info_modify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack )
        {
            string urlid = Request.QueryString["id"];
            if (urlid == null || Session["id"] == null)//传递id或者 登陆者id为空强制跳转到首页
            { Response.Redirect("default.aspx"); }
            SqlConnection conn = new SqlConnection(diy.getconnstring());
            conn.Open();
            string sql = "select * from users where id=" + urlid;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sqlread = cmd.ExecuteReader();
            sqlread.Read();//不读取会报错
            Label_id.Text = sqlread["id"].ToString();
      
         if (urlid.ToString () != Session["id"].ToString ())
            {
                if (diy.root() != true)
                {
                    diy.alert("您无权限修改ID" + urlid + "用户信息，您的ID" + Session["id"]);
                    Response.Redirect("default.aspx");
                    return;
                }
            }

            Label_username.Text = sqlread["username"].ToString();

            TextBox_age.Text = sqlread["age"].ToString();
            TextBox_city.Text = sqlread["city"].ToString();
            TextBox_interest.Text = sqlread["interest"].ToString();
            TextBox_mobile.Text = sqlread["mobile"].ToString();
            TextBox_nickname.Text = sqlread["nickname"].ToString();
            TextBox＿qq.Text = sqlread["qq"].ToString();
            TextBox_email.Text = sqlread["email"].ToString();
            string sex = sqlread["sex"].ToString();

            if (sex == "1")
            {
                DropDownList_sex.Items[0].Selected = true;
                DropDownList_sex.Items[1].Selected = false;
            }
            else
            {
                DropDownList_sex.Items[0].Selected = false;
                DropDownList_sex.Items[1].Selected = true;
            }

            // sqlread["regtime"].ToString();
        
        
        
        
        
        
        
        
        }

    }

    protected void Button_sure_Click(object sender, EventArgs e)
    {


       /* string id = Request.QueryString["id"]; 在载入页面的时候已经强制跳转了，

        if (id != Session["id"] )
        {
            if (diy.root() != true)
            {
                diy.alert("未登录用户或其它用户无法修改此id信息！");
                return;
            }
        }
        */
        string id = Request.QueryString["id"];
        string a = diy.getconnstring();
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
        string sex = DropDownList_sex.SelectedItem.Value;
       //diy.alert(sex);
     
        // int sort = Convert.ToInt32(DropDownList1.SelectedValue);
        string sql = "update users set nickname='" + TextBox_nickname.Text.Trim() + "',age='" + TextBox_age.Text.Trim() + "',sex='" + sex + "',email='"+ TextBox_email.Text+ "',city='" + TextBox_city.Text + "',interest='" + TextBox_interest.Text + "',mobile='" + TextBox_mobile.Text + "',qq='" + TextBox＿qq.Text + "' where id=" + Convert.ToInt32(id);

  //Response.Write(sql);
  //return;
        
        //Label_id.Text = sqlread["id"].ToString();
        //Label_nickname.Text = sqlread["nickname"].ToString();

        //TextBox_age.Text = sqlread["age"].ToString();
        //TextBox_city.Text = sqlread["city"].ToString();
        //TextBox_interest.Text = sqlread["interest"].ToString();
        //TextBox_mobile.Text = sqlread["mobile"].ToString();
        //TextBox_nickname.Text = sqlread["nickname"].ToString();
        //TextBox＿qq.Text = sqlread["qq"].ToString();
        //// sqlread["regtime"].ToString();






        //Response.Write(sql);
        SqlCommand cmd = new SqlCommand(sql, conn);
        int result = Convert.ToInt32(cmd.ExecuteNonQuery());//返回结果为1则插入成功
        string str;
        if (result == 1)
        {
            str = "基本信息更新成功！";
        }
        else
        { str = "基本信息更新失败！"; }


        if (TextBox_pwd.Text.Trim () != null && TextBox_pwd.Text.Trim ()!="")//已经初始化了切 初始化 不是空填写了，但是为空，也应该拒绝修改！
        {
            sql="update users set password='"+TextBox_pwd .Text .Trim ()+"' where id="+id;
            
           SqlCommand cmd_update_pwd=new SqlCommand(sql,conn);
         result = Convert.ToInt32(cmd_update_pwd .ExecuteNonQuery ());

           if (result == 1)
           {
               str += "密码更新成功！请牢记您修改的密码,密码是："+TextBox_pwd .Text.Trim () ;
           }
           else
           { str = "密码更新基本信息更新失败！"; }
        
        }
        diy.alert(str );
        conn.Close();
        diy.Redirect("user_info_view.aspx?id="+id);
        // Response.Redirect("user_info_view.aspx?id="+id);

    }
    protected void Button_canel_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_info_view.aspx?id="+Request.QueryString ["id"]);
    }
}
