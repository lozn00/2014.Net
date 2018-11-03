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

public partial class web_modifyphoto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"].ToString () == "admin" && Session["username"].ToString () != null)
        {

          

            if (!IsPostBack)
            {
                string a = ConfigurationSettings.AppSettings["DB"];
                SqlConnection conn = new SqlConnection(a);
                conn.Open();
                string sql = "select * from photo order by id desc";

                SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                DataSet set = new DataSet();
                ad.Fill(set, "hello");
                DataList1.DataSource = set.Tables["hello"];
                DataList1.DataBind();
                conn.Close();
            }
   


        }


        else


        {



            Response.Redirect("../web_login.aspx");
            //Response.Write("登录超时，3秒后跳转到登录界面<meta http-equiv='refresh' content='3;url=../web_login.aspx'><a href=../web_login.aspx>等不及了，马上进入</a>");
        
        }
 
        
        
        
        
        
     
    }



    protected void bwn(object sender, CommandEventArgs e)
    {

        Response.Redirect(e.CommandArgument .ToString ());
        //  Response.Write("<br>预览图片<img src =\"" +e.CommandArgument + "\">");//后台目录需要返回上一级
    }


    

}
