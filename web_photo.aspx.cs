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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
           // Response.Write("<a href=web_uploadfile.aspx>上传图片页面</a><br>");

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
                page.PageSize = 12;//每页显示的条数
                int currentpage;//当前页面
                if (Request.QueryString["page"] != "")//如果获得url为空强制为0页否则获取参数
                {
                    currentpage = Convert.ToInt32(Request.QueryString["page"]);
                }
                else
                { currentpage = 0; }//默认显示第一页，
                page.CurrentPageIndex = currentpage;
                Label1.Text = "每页显示" + page.PageSize + "条,共"+page.PageCount.ToString();
                Label2.Text = "条,当前:第" + (page.CurrentPageIndex) + "页";

                if (!page.IsFirstPage)
                {
                    lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage - 1);
                }
                if (!page.IsLastPage)
                { lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage + 1); }





                //if (page.CurrentPageIndex > 0)
                //{
                //    Response.Write("<a href=" + Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage - 1) + "><<上页</a>");
                //}
                //else { Response.Write("<<上页"); }
                //Response.Write("----");

                //if (!page.IsLastPage)
                //{ Response.Write("<a href=" + Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage + 1) + ">下页>></a>"); }
                //else { Response.Write("下页>>"); }
                DataList1.DataSource = page;
                DataList1.DataKeyField = "id";
                DataList1.DataBind();
                conn.Close();

               // Response.Write("<br><a href=web_modifyphoto.aspx>管理/查看全部图片</a>");

            }



 




    }

    protected void good(object sender, CommandEventArgs e)
    {
       

        Response.Redirect(e.CommandArgument.ToString ());
//Response.Write("<br>嘿嘿，原始大图就在这里，右击即可保存！<img src =\"" +""+ e.CommandArgument + "\">");
    }

}
