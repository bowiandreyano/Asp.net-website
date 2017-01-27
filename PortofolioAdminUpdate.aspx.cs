using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class PortofolioAdminUpdate : System.Web.UI.Page
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
        string id = Request.QueryString["idp"];

        PortProcess pp = new PortProcess();
        string[] data = pp.findPortById(id);
        TextBox1.Text = data[0];
        TextBox2.Text = data[1];
        TextBox3.Text = data[2];
        //FileUpload1 = data[3];

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        string name = TextBox2.Text;
        string desc = TextBox3.Text;
        string img = FileUpload1.FileName;
        if (TextBox2.Text == "" || TextBox3.Text == "" || TextBox3.Text == "" || FileUpload1.FileName == "" || TextBox1.Text == "")
        {
            Response.Write("<script>alert('isi')</script>");
        }
        else
        {
            PortProcess pp = new PortProcess();
            int result = pp.Updateport(id, name, desc, img);
            if (result != 0)
            {
                Response.Write("<script>alert('Data has been saved!')</script>");
                Server.Transfer("PortofolioAdminData.aspx");
            }

        }
    }
}