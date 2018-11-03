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
using System.IO;

public partial class image_del : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        if (Request.QueryString["id"] == null)
        {

            Response.Redirect("../default.aspx");
            // Response.Write("没有传递ID,，请返回 <br><a href=web_modifyphoto.aspx>相册管理首页</a>");
            return;
        }




        if (Session["login"] .ToString ()== "admin" && Session["username"].ToString () != null)
        {



            int id = Convert.ToInt32(Request.QueryString["id"]);


            string a = ConfigurationSettings.AppSettings["DB"];
            SqlConnection conn = new SqlConnection(a);
            conn.Open();
            string sql = "select * from photo where id=" + id;
            string sql1 = "delete from photo where id=" + id;
            SqlCommand cmd = new SqlCommand(sql, conn);//获取图片地址用的
            SqlCommand cmd1 = new SqlCommand(sql1, conn);//删除记录集用的
            SqlDataReader read = cmd.ExecuteReader();//获取记录集
            read.Read();
            //读取记录集后需要把查询的结果 url地址获取出来
            string path = ".."+read["pic"].ToString();//..返回上级
            read.Close();
            int result = cmd1.ExecuteNonQuery();//执行删除记录集语句 返回结果为1说明执行成功
            if (result == 1)
            { diy.alert ("数据库的图片资料已清除！"); }
            else
            { diy.alert ("数据库执行删除失败，请检查数据库连接,或此图片已经删除！");
           
            }
            conn.Close();
            path = Server.MapPath(path);
            //服务器路径加图片相对地址获得完整地址()里不加变量则只获得服务器的物理路径根目录
            FileInfo info = new FileInfo(path);


            if (info.Exists)//如果文件存在则删除
            {
                info.Delete();
                diy.alert("操作完成");
                Response.Redirect("web_modifyphoto.aspx");

                // Response.Redirect("image_view1.aspx");
            }
            else
            {
              diy.alert ("文件不存在，执行文件删除操作失败！");
        
            }

            Response.Redirect("web_modifyphoto.aspx");
            
        }


        else


        {

            Response.Redirect("../web_login.aspx");
            //diy.alert ("登录超时，3秒后跳转到登录界面<meta http-equiv='refresh' content='3;url=../web_login.aspx'><a href=../web_login.aspx>等不及了，马上进入</a>");
        
        }








    }
}
