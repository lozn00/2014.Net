using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient ;


//System.Web.HttpContext

/// <summary>
///diy 包含 连接字符串，联系方式 弹出信息框
/// </summary>
public class diy
{

    /// <summary>
    /// 返回连接字符串
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>

	public static  string  getconnstring()
	{
		//
        ///将返回server=localhost;database=zheng_website;Integrated Security=SSPI; 数据库连接字符串
        return ("server=localhost;database=zheng_website;Integrated Security=SSPI;");
		//
	}



    /// <summary>
    /// 输出联系方式
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    public static string contact()
    {
        ///qq:694886526 手机:15576334267 

        return ("qq:694886526 手机:15576334267 ");
        //
    }



    /// <summary>
    /// 弹窗确认与否信息框
    /// </summary>
    /// <param name="alert"></param>
    /// <returns></returns>
    public static void  confirm(string str)
    {
        //
      
        /// 传递str将返回： return ("<script language=\"javascript\">\""+str+"\"<script>");   
        //TODO: 在此处添加构造函数逻辑
       string hello ="<script language=\"javascript\">window.confirm(\""+str+"\");</script>";
        //
       System.Web.HttpContext.Current.Response.Write(hello );

//string hello="<Script Language='JavaScript'>if ( window.confirm('" + strMsg + "')) { window.location.href='" + strUrl_Yes +
//"' } else {window.location.href='" + strUrl_No + "' };</script>"; 






    }

    /// <summary>
    /// 快捷呼出信息框窗口
    /// </summary>
    /// <param name="alert"></param>
    /// <returns></returns>

    public static void alert(string str)
    {
        //

        /// 传递str将返回： return ("<script language=\"javascript\">\""+str+"\"<script>");   
        //TODO: 在此处添加构造函数逻辑
        string hello = "<script language=\"javascript\">alert(\"" + str + "\");</script>";
        //
        System.Web.HttpContext.Current.Response.Write(hello);

        //string hello="<Script Language='JavaScript'>if ( window.confirm('" + strMsg + "')) { window.location.href='" + strUrl_Yes +
        //"' } else {window.location.href='" + strUrl_No + "' };</script>"; 



    }
    /// <summary>
    /// 判断用户是否有权限，有权限返回真！
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool root()
    {
        //
        if (System.Web.HttpContext.Current.Session["login"] == "admin")
                    { return true; }
        else
        { return false; }
        //
    }
    /// <summary>
    /// 注销用户名的登录！
    /// </summary>
    /// <param name="exit"></param>
    /// <returns></returns>
    public static  void exit()

    {
        System.Web.HttpContext.Current.Session .Abandon ();
       
        System.Web.HttpContext.Current.Response.Redirect ("default.aspx");
    
    
    
    }

    /// <summary>
    /// 采用html的 跳转 refresh,貌似只能刷新当前页面
    /// </summary>
    /// <param name="Redirect"></param>
    /// <returns></returns>
    public static void Redirect(string url)
    {
        System.Web.HttpContext.Current.Response.Write("<meta http-equiv='refresh' content=0';url="+url +"'/>");
        //><Meta http-equiv="refresh" content="2; url=http://www.baidu.com">
    
       /* refresh示例
5秒之后刷新本页面:

<meta http-equiv="refresh" content="5" />
5秒之后转到梦之都首页:

<meta http-equiv="refresh" content="5; url=http://www.dreamdu.com/" />
        */
    
    }


    /// <summary>
    /// 通过用户名来取用户ID
    /// </summary>
    /// <param name="UsernametoGetid"></param>
    /// <returns></returns>
    public static  string UsernametoGetid(string username)
    {
    
    
       SqlConnection conn = new SqlConnection(diy.getconnstring());
        
            conn.Open();
            // string sql = "select * from news where id=" + urlid;

            string sql = "select * from users where username='" + username+"'" ;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sqlread = cmd.ExecuteReader();
            sqlread.Read();//不读取会报错
            //不强制转换为string为报错！
            string str = sqlread["id"].ToString();
            conn.Close();
        return str ;
     
    
  
    
    
    }

    /// <summary>
    /// 成功返回真
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public static bool UserNameExist(string str)
    {
        string username = str;

        SqlConnection conn = new SqlConnection(diy.getconnstring());
        conn.Open();
        string sql = "select 1 from users where username='" + username + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        if (count > 0)
        {
            conn.Close();
            return true;
        }
        else
        {
            conn.Close();
            return false;

        }
    
    
    
    }
    /// <summary>
    /// 成功返回真
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>

    public static bool UserIdExist(string str)
    {
        string userid = str;

        SqlConnection conn = new SqlConnection(diy.getconnstring());
        conn.Open();
        string sql = "select 1 from users where id=" + userid + "";
        SqlCommand cmd = new SqlCommand(sql, conn);
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        if (count > 0)
        {
            conn.Close();
            return true;
        }
        else
        {
            conn.Close();
            return false;

        }


        
    }


   
}
