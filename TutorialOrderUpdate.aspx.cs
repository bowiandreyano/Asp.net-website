using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

public partial class TutorialOrderInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["tid"];

            TutorialOrdersProcess pp = new TutorialOrdersProcess();
            string[] data = pp.findtutorByid(id);
            TextBox1.Text = data[0];
            TextBox2.Text = data[1];
            TextBox3.Text = data[2];
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        string name = TextBox2.Text;
        string desc = TextBox3.Text;
        if (TextBox2.Text == "" || TextBox3.Text == "" || TextBox3.Text == "" || TextBox1.Text == "")
        {
            Response.Write("<script>alert('isi')</script>");
        }
        else
        {
            TutorialOrdersProcess op = new TutorialOrdersProcess();
            int result = op.Updatetutor(id, name, desc);
            if (result != 0)
            {
                Response.Write("<script>alert('Data has been saved!')</script>");
                Server.Transfer("Tutorialorders.aspx");
            }
        }
    }
}