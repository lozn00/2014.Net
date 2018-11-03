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

public partial class rizhi_modify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["login"].ToString () == "admin" && Session["username"].ToString () != null)
        {



            if (!IsPostBack)
            {


                string id = Request.QueryString["id"];






             string a = ConfigurationSettings.AppSettings["DB"];
           SqlConnection conn = new SqlConnection(a);
            conn.Open();
             string  sql = "select * from sort";
           SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataSet set = new DataSet();
              ad.Fill(set, "zheng");
                DropDownList1.DataSource = set.Tables["zheng"].DefaultView;
                DropDownList1.DataValueField = "sort_id";
                DropDownList1.DataTextField = "sort_name";
                DropDownList1.DataBind();//绑定数据库


                //通过查询sort表的sort然后和下拉框进行比对！
               
                sql = "select * from rizhi,sort  where rizhi.sort=sort.sort_id and rizhi.id=" + id;
                SqlCommand sqlcmd = new SqlCommand(sql, conn);
                SqlDataReader sqlread = sqlcmd.ExecuteReader();
                sqlread.Read();//不读取会报错
                string leibie = sqlread["sort_id"].ToString();
                select_item(DropDownList1,leibie );//调用程序！
                sqlread.Close();




              //  DataSet set = new DataSet();//方便下面2个使用
              
                //  Response.Write(id);

                string sql1 = "select * from rizhi where id=" + Convert.ToInt32(id);
                //Response.Write(sql1);
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataReader read = cmd.ExecuteReader();




                             if (read.Read() == true)
                {
                    TextBox_title.Text = read["title"].ToString();
                    TextBox_content.Text = read["content"].ToString();
                    TextBox_author.Text = read["author"].ToString();
                    TextBox_link.Text = read["link"].ToString();
                    TextBox_pwd .Text =read["password"].ToString();

                }
                else
                {
                    diy.alert("查询失败！");
                }
  
            }


        }

        else

        {



            Response.Redirect("../web_login.aspx");
            // Response.Write("登录超时，3秒后跳转到登录界面<meta http-equiv='refresh' content='3;url=../web_login.aspx'><a href=../web_login.aspx>等不及了，马上进入</a>");
        }




    }

    protected void Button1_Click(object sender, EventArgs e)

    {

        string value;//存储只的变量
        int index = DropDownList1.SelectedIndex;

        value = DropDownList1.Items[index].Value;//取得值给新闻表id

        //Response.Write(value);
        
        string id = Request.QueryString["id"];
        string a=ConfigurationSettings.AppSettings["db"];
        SqlConnection conn = new SqlConnection(a);
        conn.Open();
       // int sort = Convert.ToInt32(DropDownList1.SelectedValue);
        string sql = "update rizhi set title='" + TextBox_title.Text +  "',password='" + TextBox_pwd.Text.Trim ()+"',content='" + TextBox_content.Text + "',author='" + TextBox_author.Text + "',link='" + TextBox_link.Text + "',sort='" +value + "' where id=" + Convert.ToInt32(id);

        
        //Response.Write(sql);
        SqlCommand cmd = new SqlCommand(sql,conn);
        int result = Convert .ToInt32( cmd.ExecuteNonQuery());//返回结果为1则插入成功
        if (result == 1)
        {
            Label1.Text = "修改文章成功，<a href=../web_rizhi_view.aspx?id="+id.ToString() +">预览该文章</a>";
            conn.Close();
        }
        else
        { Label1.Text = "修改文章失败，请检查数据库！"; }
         
    }

    public static void select_item(DropDownList DropDownList1, string nowValue)//初始化下拉框中时 通过value定位下拉列表框选择项
    {
        bool check = false;
        foreach (ListItem item in DropDownList1.Items)
        {
            item.Selected = false;
            if (nowValue == item.Value.Trim())
            {
                item.Selected = true;
                check = true;
                break;
            }
        }
        if (!check)
            DropDownList1.SelectedIndex = 0;
    }






}
