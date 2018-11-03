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

public partial class page_photo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["login"] == "admin" && Session["username"] != null)
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

                //SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                //DataSet set = new DataSet();
                //ad.Fill(set, "news");
                PagedDataSource page = new PagedDataSource();
                page.DataSource = set.Tables["hello"].DefaultView;
                page.AllowPaging = true;//允许分页
                page.PageSize = 25;//每页显示的条数
                int currentpage;//当前页面
                if (Request.QueryString["page"] != "")//如果获得url为空强制为0页否则获取参数
                {
                    currentpage = Convert.ToInt32(Request.QueryString["page"]);
                }
                else
                { currentpage = 0; }//默认显示第一页，
                page.CurrentPageIndex = currentpage;
                Label1.Text = "共" + page.Count + "条，每页显示" + page.PageSize + "条";
                Label2.Text = "当前为第" + (page.CurrentPageIndex + 1) + "页";
                if (page.CurrentPageIndex > 0)
                {
                  Label_show_page .Text = "<a href=" + Request.CurrentExecutionFilePath.ToString ()+ "?page=" + Convert.ToString(currentpage - 1) + "><<上页</a>";

                   // Response.Write("<a href=" + Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage - 1) + "><<上页</a>");
                }
                else 
                {
                    Label_show_page.Text = "<<上页";
                    //Response.Write("<<上页");
                }
                Label_show_page.Text = Label_show_page.Text + "-----";
                // Response.Write("----");

                if (!page.IsLastPage)

                { 
                  // Response.Write("<a href=" + Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage + 1) + ">下页>></a>");
                    Label_show_page.Text = Label_show_page.Text + "<a href=" + Request.CurrentExecutionFilePath.ToString() + "?page=" + Convert.ToString(currentpage + 1) + ">下页>></a>"; 
                }
                else
                {
                    Label_show_page.Text =Label_show_page .Text +"下页>>";
                  //  Response.Write("下页>>"); 
                
                                
                }
                DataList1.DataSource = page;
                DataList1.DataKeyField = "id";
                DataList1.DataBind();
                conn.Close();

                Label_link.Text = "<hr><b><a href=web_modifyphoto.aspx>管理/查看全部图片</a><br/><a href=photo_upload.aspx>上传图片页面</a></b><br>";

            }



        }
        else

        {

            Response.Redirect("../web_login.aspx");
            
            // Response.Write("登录超时，2秒后跳转到登录界面<meta http-equiv='refresh' content='2;url=../web_login.aspx'><a href=../web_login.aspx>等不及了，马上进入</a>");
        
        
        
        }




    }

    protected void good(object sender,CommandEventArgs e)
    {
     //   Response.Write("<br>预览图片<img src =\"" + e.CommandArgument +"\">");

        Response.Redirect(e.CommandArgument.ToString ());
    }
}
