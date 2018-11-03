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

public partial class rizhi_add : System.Web.UI.Page
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
                string sql = "select * from sort";
                SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                DataSet set = new DataSet();
                ad.Fill(set, "zheng");
                DropDownList1.DataSource = set.Tables["zheng"].DefaultView;
                DropDownList1.DataValueField = "sort_id";
                DropDownList1.DataTextField = "sort_name";
                DropDownList1.DataBind();
                conn.Close();
            }


        }
        else
        {

            Response.Redirect("../web_login.aspx");
            //  Response.Write("登录超时，3秒后跳转到登录界面<meta http-equiv='refresh' content='3;url=../web_login.aspx'><a href=../web_login.aspx>等不及了，马上进入</a>");     
        
        
        
        }
        
        
        
        
     

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string a=ConfigurationSettings.AppSettings["db"];
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
        int sort = Convert.ToInt32(DropDownList1.SelectedValue);
        string sql = "insert into rizhi(title,content,author,link,password,sort)values('" + TextBox1.Text + "','" + WebEditor1.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox_pwd.Text + "'," + sort + ")";
        //Response.Write(sql);
        SqlCommand cmd = new SqlCommand(sql,conn);
        int result = cmd.ExecuteNonQuery();//返回结果为1则插入成功
        if (result == 1)
        {
            Label1.Text = "发布文章成功，<a href=../web_rizhi.aspx>预览该文章</a>";
            conn.Close();
        }
        else
        { Label1.Text = "发布文章失败，请检查数据库！"; }
         
    }
}
