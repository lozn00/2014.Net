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

public partial class userreg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void userexist(object source, ServerValidateEventArgs args)
    {
        string username = args.Value;
        SqlConnection conn = new SqlConnection(diy.getconnstring());
        conn.Open();
        string sql = "select 1 from users where username='" + username + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        if (count > 0)
        {   args.IsValid = false;        }
        else
        {     args.IsValid = true;}
        conn.Close();
    }
    protected void Button_login_Click(object sender, EventArgs e)
    {
        Response.Redirect("./web_login.aspx");
    }
    protected void Button_reg_Click(object sender, EventArgs e)
    {
        Page.Validate();//此语句不加会报错
        if (this.IsValid == true)
        {   SqlConnection conn = new SqlConnection(diy.getconnstring());
            conn.Open();
            string sex = "1";
            if (RadioButton_woman.Checked)
            {sex = "0";}
            string sql = "insert into users (username,password,email,dj,nickname,qq,sex) values('" + TextBox_username.Text + "','" + TextBox_pwd.Text + "','" + TextBox_email.Text + "','2','" + TextBox_nickname.Text + "','" + TextBox_qq.Text + "'," + sex + ")";
            SqlCommand run = new SqlCommand(sql, conn);
            int result = run.ExecuteNonQuery();//如果结果为1则注册成功了，否则失败
            if (result == 1)
            {  Label_show.Text = "恭喜您，注册成功！<a href=web_login.aspx>马上登陆</a>";    }
            else
            {  Label_show.Text = "注册失败，数据库出现错误";}
        }


    }
}
