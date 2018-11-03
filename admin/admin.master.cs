using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class admin_master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Label1.Text = Application["count"].ToString();
        Label2.Text = Application["counter"].ToString();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Response.Redirect("../web_login.aspx");

    }
}
