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

public partial class web_rizhi_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null)
        {

            int urlid = Convert.ToInt32(Request.QueryString["id"]);
            SqlConnection conn = new SqlConnection("server=localhost; database=zheng_website;Integrated Security=SSPI;");
            conn.Open();
           // string sql = "select * from rizhi where id=" + urlid;

            string sql = "select * from rizhi,sort  where rizhi.sort=sort.sort_id and rizhi.id=" + urlid;
           SqlCommand cmd = new SqlCommand(sql,conn);
           SqlDataReader sqlread = cmd.ExecuteReader();



           sqlread.Read();//不读取会报错


             string pwd = sqlread["password"].ToString();

             if (pwd != "")//pwd表示的是数据库中的密码，


             {
                 if (diy.root() == false)//检查没有密码，也没管理权限，将无权限查看。
                 {


                     if (Request.QueryString["password"] != null)//这是url中的密码！
                     {


                         if (Request.QueryString["password"] != pwd)
                         {
                             Panel_pwd.Visible = true;
                             Label_tip.Text = "密码错误！请尝试联系管理员：" + diy.contact() + "url=" + Request.QueryString["password"] + "---" + pwd + "--";
                             return;
                         }
                     }
                     else
                     {

                         Panel_pwd.Visible = true;
                         Label_tip.Text = "本博文需要密码，帮助信息：" + diy.contact();
                         return;
                     }

             
                 
                 
                 
                 
                 
                 
                 
                 }
             
             
             }


   

            





            //不强制转换为string为报错！
            Label_title.Text=sqlread["title"].ToString();
            Label_hit.Text = sqlread["hit"].ToString();

            SqlConnection conn1 = new SqlConnection(diy.getconnstring());
            conn1.Open();
            if (Label_hit.Text == "")//解决默认值不为1，切以前已经创建了数据但是为空的问题。
            {
                sql = "update rizhi set hit=1 where id=" + Request.QueryString["id"];
            }
            else
            {
                sql = "update rizhi set hit=hit+1 where id=" + Request.QueryString["id"];
            }

            SqlCommand cmd1 = new SqlCommand(sql, conn1);
            int i = Convert.ToInt32(cmd1.ExecuteNonQuery());//返回结果为1则插入成功
            if (i == 0)
            { diy.alert("更新访问量出错！"); }
     
                 Label_author.Text=sqlread["author"].ToString();
            //string liebie=sqlread["sort"].ToString();
                 Label_lb.Text = sqlread["sort_name"].ToString();
            Label_time.Text=sqlread["addtime"].ToString();
            Label_link.Text=sqlread["link"].ToString();
            Label_content.Text=sqlread["content"].ToString();
           
      
            
           // SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
        //   DataSet set = new DataSet();
           // adapter.Fill(set, "zheng_view");

           // DataList1.DataSource = set.Tables["zheng_view"].DefaultView;
           //DataList1.DataBind();
            conn1.Close();
            conn.Close();
         
        }

        else
        {


            Response.Redirect("web_rizhi.aspx");
            // Response.Write("非法操作，请返回首页打开 故障联系qq694886526<br><a href=web_rizhi.aspx>返回首页</a>");
            //Label6.Text = "非法操作，请返回首页打开 故障联系qq694886526";
        }






    }
    protected void Button_sub_Click(object sender, EventArgs e)
    {


        Response.Redirect("web_rizhi_view.aspx?id=" + Request.QueryString["id"]+"&password="+TextBox_pwd .Text.Trim () );
    }
}
