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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string con = ConfigurationSettings.AppSettings["DB"];
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            string sql = "select top 20 * from rizhi order by id desc";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataSet set = new DataSet();
            ad.Fill(set, "rizhi");
            PagedDataSource page1 = new PagedDataSource();
            page1.DataSource = set.Tables["rizhi"].DefaultView;
            page1.AllowPaging = true;
            page1.PageSize = 15;//每页显示的条数
            DataList_rizhi.DataSource = page1;
            DataList_rizhi.DataKeyField = "id";
            DataList_rizhi.DataBind();
                        sql = "select top 50 *  from guestbook order by id desc";//查10条
            SqlDataAdapter adnew = new SqlDataAdapter(sql, conn);
            adnew.Fill(set, "new_rizhi");
            DataList_newrizhi.DataSource = set.Tables["new_rizhi"];
            DataList_newrizhi.DataBind();
                        sql = "select * from photo order by id desc";
                        SqlDataAdapter ad1 = new SqlDataAdapter(sql, conn);
            //DataSet set = new DataSet();
            ad1.Fill(set, "photo");
            DataList_photo.DataSource = set.Tables["photo"];
            DataList_photo.DataBind();
            PagedDataSource page = new PagedDataSource();
            page.DataSource = set.Tables["photo"].DefaultView;
            page.AllowPaging = true;//允许分页
            page.PageSize = 1;//每页显示的条数
            int currentpage;//当前页面
            if (Request.QueryString["page"] != "")//如果获得url为空强制为0页否则获取参数
            {
                currentpage = Convert.ToInt32(Request.QueryString["page"]);
            }
            else
            { currentpage = 0; }//默认显示第一页，

            page.CurrentPageIndex = currentpage;

            string tishi = "第" + (page.CurrentPageIndex) + "页-共" + page.PageCount.ToString() + "页";
            Label_xianshi.Text = tishi;


            if (!page.IsFirstPage)
            {

                shang.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage - 1);
            }
            if (!page.IsLastPage)
            { xia.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage + 1); }

            DataList_photo.DataSource = page;
            DataList_photo.DataKeyField = "id";
            DataList_photo.DataBind();
            conn.Close();


        }



    }

    protected void rizhi_link(object sender, CommandEventArgs e)
    {
        string urlid = Convert.ToString(e.CommandArgument);
        // Label1.Text = "zheng_view.aspx?id=" + urlid;
        Response.Redirect("web_rizhi_view.aspx?id=" + urlid);

    }
    protected void photo_link(object sender, CommandEventArgs e)
    {
        string urlid = Convert.ToString(e.CommandArgument);
        // Label1.Text = "zheng_view.aspx?id=" + urlid;
        Response.Redirect("guestbook_view.aspx?id=" + urlid);

    }

    protected void good(object sender, CommandEventArgs e)
    {
        //Response.Redirect(e.CommandArgument);
        string url = e.CommandArgument.ToString();

        Response.Redirect(url);
    }

    protected string getsubstring(string a, int length)
    {
        /* string b;
         if (a.Length > 50)
             b = a.Substring(0, 50);
         else
             b = a;
         return b;
         * */


        string ls;
        if (a.Length > length)
            ls = a.Substring(0, length);
        else
            ls = a;
        return ls;
    }



}
