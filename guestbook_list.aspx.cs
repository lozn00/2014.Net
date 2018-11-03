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

public partial class web_rizhi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string con = ConfigurationSettings.AppSettings["DB"];
        SqlConnection conn = new SqlConnection(con);
        conn.Open();
        string sql = "select * from guestbook order by id desc";
        SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
        DataSet set = new DataSet();
        ad.Fill(set, "guestbook");
        PagedDataSource page = new PagedDataSource();
        page.DataSource = set.Tables["guestbook"].DefaultView;
        page.AllowPaging = true;
        page.PageSize = 10;//每页显示的条数
        int currentpage;
        if (Request.QueryString["page"] != "")
        {
            currentpage = Convert.ToInt32(Request.QueryString["page"]);
        }
        else
        { currentpage = 0; }//默认显示第一页，



        page.CurrentPageIndex = currentpage;
        Label1.Text = "共" + page.Count + "条，每页显示" + page.PageSize + "条";
        Label2.Text = "当前为第" + (page.CurrentPageIndex + 1) + "页";



        if (!page.IsFirstPage)
        {
            lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage - 1);
        }
        if (!page.IsLastPage)
        { lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage + 1); }
 

        
        DataList1.DataSource = page;
        DataList1.DataKeyField = "id";
        DataList1.DataBind();
        conn.Close();






      








    }
    protected void link(object sender, CommandEventArgs e)
    {
        string urlid = Convert.ToString(e.CommandArgument);
        // Label1.Text = "zheng_view.aspx?id=" + urlid;
        Response.Redirect("guestbook_view.aspx?id=" + urlid);
    }
    #region 截取字符
    static public string Left(string str, int L)
    {
        string tmpStr;
        tmpStr = str;
        if (str.Length > L)
        {

            tmpStr = str.Substring(0, L) + "...";
        }
        return tmpStr;
    }
    #endregion



    protected void Button_addguestbook_Click(object sender, EventArgs e)
    {
        Response.Redirect("guestbook_add.aspx");
    }
}
