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

public partial class rizhi_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["login"].ToString () == "admin" && Session["username"] != null)
        {

            if (!IsPostBack)
            {
                string a = ConfigurationSettings.AppSettings["DB"];
                SqlConnection conn = new SqlConnection(a);
                conn.Open();
                string sql = "select * from rizhi order by id desc";
                SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                DataSet set = new DataSet();
                ad.Fill(set, "zheng");
                DataList1.DataSource = set.Tables["zheng"];
                DataList1.DataBind();
                conn.Close();
            }




        }
        else
        {
Response.Write("../web_login.aspx");   
     
//    Response.Write("登录超时，3秒后跳转到登录界面<meta http-equiv='refresh' content='3;url=../web_login.aspx'><a href=../web_login.aspx>等不及了，马上进入</a>");
        
        
        }
  
      // Button_search_Click();
        
    }
    protected void del(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        string a = ConfigurationSettings.AppSettings["DB"];
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
        string sql = "delete from rizhi where id="+id;
        SqlCommand cmd = new SqlCommand(sql,conn);
        int c=cmd.ExecuteNonQuery();
        if (c == 1)
        {
            Response.Redirect("rizhi_list.aspx");
        }
        else
        { diy.alert ("删除失败！"); }
     
    }
    protected void modify(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
     
            Response.Redirect("rizhi_modify.aspx?id="+Convert .ToString(id));
   

    }
    protected void Button_search_Click(object sender, EventArgs e)
    {
       // Response.Write("ffff");
        string a=ConfigurationSettings.AppSettings["DB"];
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
        string sql = "select * from rizhi where id like '%" + TextBox_search.Text + "%' or title like '%" + TextBox_search.Text + "%' or content like '%" +  TextBox_search.Text + "%' or author like '%"+TextBox_search.Text + "%'";;
       // Response.Write(sql);
        SqlDataAdapter ad = new SqlDataAdapter(sql,conn);
        DataSet set = new DataSet();
        ad.Fill(set,"a");
        DataList1.DataSource= set.Tables["a"].DefaultView;
        DataList1.DataBind();
        conn.Close();
        




    }
}
