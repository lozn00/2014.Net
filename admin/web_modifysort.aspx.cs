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

public partial class zheng_modifysort : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["login"].ToString () == "admin" && Session["username"].ToString () != null)
        {

            if (!IsPostBack)
            {
                sqlconn();

            }


        }

        else
        {
            Response.Redirect("../web_login.aspx");
     //       Response.Write("登录超时，3秒后跳转到登录界面<meta http-equiv='refresh' content='3;url=../web_login.aspx'><a href=../web_login.aspx>等不及了，马上进入</a>");
        }
        
        
        
        
       
        
    }
     //              <!---     OnRowEditing="edit" 
     //OnRowCancelingEdit="cancel"
     // OnRowUpdating="update" 
     // OnRowDeleting="delete"
     //  OnRowDataBound="databound"!->
    protected void sqlconn()
    {
        string a = ConfigurationSettings.AppSettings["DB"];
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
        string sql = "select * from sort";
        SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
        DataSet set = new DataSet();
        ad.Fill(set, "zheng");
      //这里不使用分页  GridView1.DataSource = set.Tables["zheng"].DefaultView;


        //分页实现头
        

        PagedDataSource page = new PagedDataSource();
        page.DataSource = set.Tables["zheng"].DefaultView;
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
        Label1.Text = "共" + page.Count + "/" + page.PageSize + "条";
        Label2.Text = "共" + page.PageCount.ToString() + "页/当页为第" + (page.CurrentPageIndex + 1) + "页";



        if (!page.IsFirstPage)
        {
            lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage - 1);
        }
        if (!page.IsLastPage)
        { lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage + 1); }



        GridView1.DataSource = page;

        GridView1.DataBind();
        conn.Close();
    }
    protected void edit(object sender,GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex;
        sqlconn();
    }
    protected void cancel(object sender, GridViewCancelEditEventArgs e)
    {
        this.GridView1.EditIndex = -1;
        sqlconn();
    }
    //    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    protected void update(object sender,GridViewUpdateEventArgs e)
    {
         string a = ConfigurationSettings.AppSettings["DB"];
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
          int id=Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value);
          string sort = ((TextBox)this.GridView1.Rows[e.RowIndex].FindControl("TextBox_sort")).Text.ToString();//
        string shortname = ((TextBox)this.GridView1.Rows[e.RowIndex].FindControl("TextBox_shortname")).Text.ToString();
          string sql = "update sort set sort_name='" + sort + "',short_name='" + shortname + "' where sort_id="+id;
          
        
        //Response.Write(sql);
          SqlCommand cmd = new SqlCommand(sql,conn);
          int result=cmd.ExecuteNonQuery();
          if (result >= 1)
          {
              this.GridView1.EditIndex = -1;
              sqlconn();
             // Response.Write("<script>alert('更新失败')</script>");
              Response.Write("<script>alert('更新成功！受影响行：" + Convert.ToString(result) + "')</script>");
          }
          else
          {
              Response.Write("<script>alert('更新失败')</script>");
          }

    }
   
    protected void delete(object sender,GridViewDeleteEventArgs s)
    {
        string a = ConfigurationSettings.AppSettings["DB"];
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
        int id = Convert.ToInt32(this.GridView1.DataKeys[s.RowIndex].Value);
        string sql = "delete from sort where sort_id=" + id;
                //Response.Write(sql);
        SqlCommand cmd = new SqlCommand(sql,conn);
            int result = cmd.ExecuteNonQuery();
        if (result >= 1)
        {
            this.GridView1.EditIndex = -1;
            sqlconn();
            // Response.Write("<script>alert('更新失败')</script>");
            Response.Write("<script>alert('删除成功！受影响行：" + Convert.ToString(result) + "')</script>");
        }
        else
        {
            Response.Write("<script>alert('删除失败，可能此条目已经删除')</script>");
        }
        conn.Close();
    }
    protected void databound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void insert(object sender,CommandEventArgs s)
    {
        string a=ConfigurationSettings.AppSettings["db"];
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
        string sql = "insert into sort (sort_name,short_name)values('" + TextBox_sorts.Text + "','" + TextBox_shorts.Text + "')";
       //Response.Write(sql);
        SqlCommand cmd = new SqlCommand(sql,conn);
        int result = cmd.ExecuteNonQuery();
        if (result >= 1)
        {
            this.GridView1.EditIndex = -1;
            sqlconn();
            // Response.Write("<script>alert('更新失败')</script>");
            Response.Write("<script>alert('添加成功！受影响行：" + Convert.ToString(result) + "')</script>");
        }
        else
        {
            Response.Write("<script>alert('添加失败')</script>");
        }
        conn.Close();

       // Response.Write("<script>alert('"+sql+"')</script>");

    }
}
