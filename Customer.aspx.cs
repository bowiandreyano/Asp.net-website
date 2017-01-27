using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class linklogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginstatus"] != "true")
        {
            Response.Write("<script>alert('Anda harus login')</script>");
            Server.Transfer("AdminLogin.aspx");
        }
        else
        {
            Label1.Text = Session["username"].ToString();
        }
    }
}
