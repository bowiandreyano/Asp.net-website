using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class linklogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginstatus"] != "true")
        {
            Response.Write("<script>alert('Anda harus login')</script>");
            Response.Redirect("AdminLogin.aspx");
        }
        else
        {
            Label1.Text = Session["username"].ToString();
        }
        AdminProcess ap = new AdminProcess();
        StringBuilder html = ap.getAllAdmin();
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }
}
