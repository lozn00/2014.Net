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
using System.IO;
using System.Data.SqlClient;

public partial class admin_photo_upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["login"].ToString () != "admin")
        {
            //
            Response.Redirect("../web_login.aspx");
            return;
            // Response.Write("登录超时!<meta http-equiv='refresh' content='1;url=../web_login.aspx'><a href=../web_login.aspx>等不及了，马上进入</a>");
            //Response.Redirect("../web_login.aspx");
            //  Response.Write("用户已掉线或非法进入，请重新<a href=zheng_login.aspx>登录</a>");

        }
       
  

    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpPostedFile post = FileUpload1.PostedFile;//实例化获取文件路径+文件名。
        string path = post.FileName.ToString();//然后把实例化后的路径转化为字符串数据）
        if (path == "")
        {

 diy.alert("你没有选择文件!");
           
            return;
        }
        FileInfo fileinfo = new FileInfo(path);//用来读取文件后缀名，文件名等。
        string name = fileinfo.Name.ToString();//分割出文件名
        string extension = fileinfo.Extension.ToString();//分割出扩展名
        int filelength = Convert.ToInt32(FileUpload1.PostedFile.ContentLength);

        // int filelength = (int)fileinfo.Length;//无法将类型“long”隐式转换为“int”。因此需要强制转换，获取的不是文件名长度，而是上传的内容长度！
        long fileSize = (filelength / 1024) / 1024;        //获取文件大小
        if (fileSize > 10)
        {
            diy.alert("fuck！ 你上传的图片超过了10M你想搞爆服务器吗？");
           // Response.Write("<br>fuck！ 你上传的图片超过了10M你想搞爆服务器吗？");
            return;


            //调试输出

        }





       Label_show .Text = "<br>上传的文件名【变量name】为" + name;//调试输出
       Label_show.Text =  Label_show .Text +"<br>文件长度为【变量filelength】" + filelength;//调试输出
     Label_show .Text =  Label_show .Text +"<br>文件长度为【变量extension】" + extension;//扩展名



        if (name != null)
        {

            string imagename;
            DateTime now = DateTime.Now;//把时间日期类实例化
            imagename = now.Year.ToString() + now.Month.ToString() + now.Day.ToString() + now.Hour.ToString() + now.Second.ToString() + now.Minute.ToString();
            //把文件名改成日期的。【此处无后缀】
            Label_show .Text =  Label_show .Text +"<br>【变量imagename】" + imagename;//输出年月日时期
            string filename = imagename + "_" + name;//本文件为无路径的保存在网络上的纯文件名

            post.SaveAs(System.Web.HttpContext.Current.Request.MapPath("../images/") + filename);//保存在上级目录下的images文件夹下。
            //保存为日期时间+本地获取的名字如2014428153446_1.txt
               Label_show .Text =  Label_show .Text +"<br>文件服务器路径保存在【Server .MapPath方法获取服务器路径】" + Server.MapPath("images");//


                   Label_show .Text =  Label_show .Text +"<br>网址路径为【HttpContext.Current.Request.Url.Host获取域名】" + Convert.ToString(HttpContext.Current.Request.Url.Host) + "../images";

            string webpath = Convert.ToString(HttpContext.Current.Request.Url.Host);//获取当前域名
            string a = ConfigurationSettings.AppSettings["DB"];
            SqlConnection conn = new SqlConnection(a);
            conn.Open();
            imagename = "images/" + filename;//存入相对路径的文件地址
            string sql = "insert into photo(pic,remark) values ('" + imagename + "','" + TextBox1.Text + "')";

            SqlCommand cmd = new SqlCommand(sql, conn);

            int result = cmd.ExecuteNonQuery();//如果返回结果是1则说明执行成功！

            //数据库判断是否上传成功

            if (result == 1)
            {
                if (extension == ".jpg" || extension == ".gif" || extension == ".bmp" || extension == ".png" || extension == "JPG")
                {

                            Label_show .Text =  Label_show .Text +"<br>预览图片<img src =\"" + "../images/" + filename + "\" alt=\"" + TextBox1.Text + "\">";
                }
                else
                {
                           Label_show .Text =  Label_show .Text +"<br>数据库写入图片路径资料成功！";
                          Label_show .Text =  Label_show .Text +"<br><a href=../images/" + filename + ">打开/浏览文件</a>";
                }//判断扩展名结尾
                //插入的时候图片是在admin目录下，所以图片要加2个//

            }



            else
            {
                       Label_show .Text =  Label_show .Text +"<br>文件上传成功，但是数据库插入图片路径资料与说明失败！请检查数据库问题";

            }//判断result结尾
            conn.Close();










            //将附件路径
            //string str = this.FileUpload1.PostedFile.FileName;
            //判断附件不能为空！
            //if (str == string.Empty)
            //{
            //    Response.Write(bc.MessageBox("上传文件不能为空！"));
            //    return;
            //}
            //获取附件名称 
            //string fileName = str.Substring(str.LastIndexOf("\\") + 1);
            //path = "..\\file\\" + fileName;                         //设置附件上传到的服务器路径
            //FileInfo fileInfo = new FileInfo(str);                  //获取文件信息
            //long fileSize = (fileInfo.Length / 1024) / 1024;        //获取文件大小
            //if (fileSize > 10)                                      //控制文件大小不能超过10M
            //{
            //    Response.Write(bc.MessageBox("文件大小不能超过10M ！"));
            //    return;                                             //不能继续执行
            //}
            //上传送文件的相关信息保存到服务器中
            //bool bl = bc.ExecSQL("INSERT INTO tb_file (fileSender, fileAccepter, fileTitle, fileTime, fileContent, path,examine,fileName) VALUES('" + Convert.ToString(Session["loginName"]) + "','" + ddlName.Text + "','" + txtTitle.Text + "','" + DateTime.Today.ToString() + "','" + txtContent.Text + "','" + path + "','未接收','" + fileName + "')");
            //if (bl)
            //{
            //    Response.Write(bc.MessageBox("文件传送成功！"));
            //}
            //else
            //{
            //    Response.Write(bc.MessageBox("网络故障，文件传送失败！"));
            //    return;
            //}
            //this.FileUpload1.PostedFile.SaveAs(Server.MapPath(path));    




        }
        else
        {
                    Label_show .Text ="<br>获取文件名为空，因此上传文件失败或你没有选择一个文件进行上传！";//调试输出  
        }
        //判断文件名name结尾


    } //被单击文件结尾


}
