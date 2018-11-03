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

public partial class web_rizhi_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null)
        {
            if (diy.root () == true)
            {
                Panel1.Visible = true;
            }




            int urlid = Convert.ToInt32(Request.QueryString["id"]);
            SqlConnection conn = new SqlConnection(diy.getconnstring());
            conn.Open();
            // string sql = "select * from news where id=" + urlid;

            string sql = "select * from guestbook where id=" + urlid;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sqlread = cmd.ExecuteReader();
            sqlread.Read();//不读取会报错
            //不强制转换为string为报错！
           Label_id .Text   = sqlread["id"].ToString();
            Label_nickname.Text = sqlread["nickname"].ToString();
            Label_username.Text = "<a href=user_info_view.aspx?id=" + diy.UsernametoGetid(sqlread["username"].ToString()) + ">" + sqlread["username"].ToString() + "</a>";
            //Label_username.Text = sqlread["username"].ToString();
            Label_QQ.Text = sqlread["qq"].ToString();
            Label_time.Text = sqlread["addtime"].ToString();
            Label_content.Text = sqlread["content"].ToString();
            Label_reply.Text = sqlread["reply"].ToString();
            Label_replytime.Text = sqlread["replytime"].ToString();
           
            if (Label_replytime.Text != "")
            {
                Panel_reply.Visible = true;
            
            }



            // SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            //   DataSet set = new DataSet();
            // adapter.Fill(set, "zheng_view");

            // DataList1.DataSource = set.Tables["zheng_view"].DefaultView;
            //DataList1.DataBind();

        }
        else
        {
            Response.Redirect("guestbook_list.aspx");
            //Label6.Text = "非法操作，请返回首页打开 故障联系qq694886526";
        }
    }






             protected void Button1_Click(object sender, EventArgs e)
             {
           
                 int id = Convert.ToInt32(Label_id .Text );
             
                 SqlConnection conn = new SqlConnection(diy.getconnstring ());
                 conn.Open();
                 string sql = "delete from guestbook where id=" + id;
                 SqlCommand cmd = new SqlCommand(sql, conn);
                 int c = cmd.ExecuteNonQuery();
                 if (c >0)
                 {
                     diy.alert("删除成功！受影响的行："+Convert .ToString (c));
                     Response.Redirect("guestbook_list.aspx");
                 }
                 else
                 { diy.alert("删除失败！可能是数据库出现问题"); }

             }
             protected void Button2_Click(object sender, EventArgs e)
             {

                 DateTime date = DateTime .Now;
                 string time = date.ToString();
                 // Response.Write(date );
                 // return;
                 SqlConnection conn = new SqlConnection(diy.getconnstring ());
                 conn.Open();
                 // int sort = Convert.ToInt32(DropDownList1.SelectedValue);
                 string sql = "update guestbook set reply='" + TextBox_reply .Text  + "',replytime='"+date +"' where id=" + Convert.ToInt32(Label_id .Text );


                 //Response.Write(sql);
                 SqlCommand cmd = new SqlCommand(sql, conn);
                 int result = Convert.ToInt32(cmd.ExecuteNonQuery());//返回结果为1则插入成功
                 if (result == 1)
                 {
                     diy.alert("回复成功！");
                     Response.Redirect("guestbook_view.aspx?id=" + Label_id.Text);
                     conn.Close();
                 }
                 else
                 {
                     diy.alert("回复失败！");
                 Response.Redirect("guestbook_view.aspx?id=" + Label_id.Text);
                 }


                 conn.Close();
             }
}
