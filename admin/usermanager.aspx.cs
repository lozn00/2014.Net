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
        Label_show.Text = "";
   
        if (Session["login"]== "admin" && Session["username"] != null)
        {


            if (!IsPostBack)
            {
                sqlconn();

            }
            else
            { 
            
            
            }


        }

        else
        {

            Response.Redirect("../web_login.aspx");
        }
        
        
        
        
       
        
    }
     //              <!---     OnRowEditing="edit" 
     //OnRowCancelingEdit="cancel"
     // OnRowUpdating="update" 
     // OnRowDeleting="delete"
     //  OnRowDataBound="databound"!->
    protected void sqlconn()
    {
        Label_show.Text="";
        string a = diy.getconnstring();
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
        string sql = "select * from users";
        SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
        DataSet set = new DataSet();
        ad.Fill(set, "users");

        PagedDataSource page = new PagedDataSource();
        page.DataSource = set.Tables["users"].DefaultView;
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
        Label2.Text = "共"+page.PageCount.ToString() + "页/当页为第" + (page.CurrentPageIndex + 1) + "页";



        if (!page.IsFirstPage)
        {
            lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage - 1);
        }
        if (!page.IsLastPage)
        { lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentpage + 1); }


        GridView1.DataSource = page;

        //GridView1.DataSource = set.Tables["users"].DefaultView;





        //DropDownList dd_root;

        //for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        //{
        //    DataRowView setindex = set.Tables["users"].DefaultView[i];
        //    if (Convert.ToString(setindex["dj"]).Trim() == "1")
        //    {
        //        dd_root = (DropDownList)GridView1.Rows[i].FindControl("DropDownList_root");
        //        dd_root.SelectedIndex = 1;
        //    }
        //    if (Convert.ToString(setindex["dj"]).Trim() == "2")
        //    {
        //        dd_root = (DropDownList)GridView1.Rows[i].FindControl("DropDownList_root");
        //        dd_root.SelectedIndex = 2;
        //    }
        //}










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
            // ((TextBox)this.GridView1.Rows[e.RowIndex].FindControl("TextBox_username")).Text.ToString();
         string userid = ((TextBox)this.GridView1.Rows[e.RowIndex].FindControl("TextBox_id")).Text.ToString();//
         string username = ((TextBox)this.GridView1.Rows[e.RowIndex].FindControl("TextBox_username")).Text.ToString();//
        string nickname = ((TextBox)this.GridView1.Rows[e.RowIndex].FindControl("TextBox_nickname")).Text.ToString();
        string root = ((TextBox)this.GridView1.Rows[e.RowIndex].FindControl("TextBox_root")).Text.ToString();
       // string id = ((TextBox)this.GridView1.Rows[e.RowIndex].FindControl("TextBox_id")).Text.ToString();
        //string root = ((DropDownList)this.GridView1.Rows[e.RowIndex].FindControl("DropDownList_root")).SelectedItem.Value;

         string sql ;
         string addsql="";
        if ( diy.UserNameExist (username)==false )//不存在则修改
        {
             addsql = ",username='" + username + "'";
           
        }


        if (diy.UserIdExist(userid.ToString()) == false)//不存在则修改
        {
   
            Label_show.Text = "<script>alert('更新失败你不能更改ID，本人暂时没有技术修改ID，您只能添加ID！')</script>";
            return;
            
            //  addsql = addsql + ",id="+ userid.ToString();
           
        }
        if (addsql != "")
            //开启主键插入
        {

           // SqlCommand cmd_index = new SqlCommand("set identity_insert users ON", conn);
          //  cmd_index.ExecuteNonQuery();
        
        }



        

      sql = "update users set nickname='" + nickname + "',dj='" + root + "'"+addsql  +" where id="+id;
    //  Response.Write(sql);
     // return;  
        
        //Response.Write(sql);
          SqlCommand cmd = new SqlCommand(sql,conn);
          int result=cmd.ExecuteNonQuery();
          string str;
          if (result >= 1)
          {
              this.GridView1.EditIndex = -1;
              sqlconn();
             // Response.Write("<script>alert('更新失败')</script>");
            str = "<script>alert('更新成功！受影响行：" + Convert.ToString(result) + "')</script> "+sql ;
          }
          else
          {
              str = "<script>alert('更新失败')</script>";
          }
          Label_show.Text = str;
      
    }
   
    protected void delete(object sender,GridViewDeleteEventArgs s)
    {
        string a = ConfigurationSettings.AppSettings["DB"];
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
        int id = Convert.ToInt32(this.GridView1.DataKeys[s.RowIndex].Value);
        string sql = "delete from users where id=" + id;
                //Response.Write(sql);
        SqlCommand cmd = new SqlCommand(sql,conn);
            int result = cmd.ExecuteNonQuery();
        if (result >= 1)
        {
            this.GridView1.EditIndex = -1;
            sqlconn();
            // Response.Write("<script>alert('更新失败')</script>");
           Label_show .Text  = "<script>alert('删除成功！受影响行：" + Convert.ToString(result) + "')</script>";
        }
        else
        {
            Label_show.Text = "<script>alert('删除失败，可能此条目已经删除')</script>";
        }
        conn.Close();
    }
    protected void databound(object sender, GridViewRowEventArgs e)
    {

    //    DropDownList DropDownList_new = (DropDownList)e.Row.FindControl("DropDownList_root");
    //    string root = ((TextBox)this.GridView1.Rows[e.RowIndex].FindControl("TextBox_root")).Text.ToString();

    //     if (root = "1")
    //     {

    //         DropDownList_new.SelectedIndex = 0;
    //     }
    //     else
    //     {
    //         DropDownList_new.SelectedIndex = 1;
    //     }
       
    }

    protected void insert(object sender,CommandEventArgs s)

    {
        if (TextBox_id_add .Text .ToString () == "")
        {
            Label_show.Text = "用户名必须填写";
            return;
        }

        if (TextBox_username_add .Text.ToString () == "")
        {
            Label_show.Text = "用户名必须填写";
            return;
        }


        Label_show.Text = "";
        if (diy.UserIdExist(TextBox_id_add.Text.ToString()))
        {

            Label_show.Text = "ＩＤ已经存在！";
            return;

        }



        if (diy.UserNameExist (TextBox_username_add.Text.ToString()))
        {

            Label_show.Text = "用户名已经存在！";
            return;
        
        }
        
        
        string a=ConfigurationSettings.AppSettings["db"];

                SqlConnection conn = new SqlConnection(a);
        conn.Open();

        SqlCommand cmd_index = new SqlCommand("set identity_insert users ON",conn);
        cmd_index.ExecuteNonQuery();
          string sql = "insert into users (username,id)values('" + TextBox_username_add .Text + "','" + TextBox_id_add .Text  + "')";
     //   string sql = "insert into users (username)values('" + TextBox_username_add .Text + "')";

       //Response.Write(sql);
        SqlCommand cmd = new SqlCommand(sql,conn);
        

        int result = cmd.ExecuteNonQuery();
        if (result >= 1)
        {
            this.GridView1.EditIndex = -1;
            sqlconn();
            // Response.Write("<script>alert('更新失败')</script>");
            Label_show.Text = "添加成功<script>alert('添加成功！受影响行：" + Convert.ToString(result).ToString() + "')</script>";
        }
        else
        {
            Label_show.Text = "<script>alert('添加失败')</script>添加成功";
        }
        conn.Close();

       // Response.Write("<script>alert('"+sql+"')</script>");

    }

    protected void Button_edit_more_Click(object sender, CommandEventArgs e)

    {
        string id = e.CommandArgument.ToString();
       
   Response.Redirect("../user_info_modify.aspx?id="+id);
    }


}
