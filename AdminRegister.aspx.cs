using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class insertcustomer : System.Web.UI.Page
{
    private string username;
    private string password;
    private string status;
    private string nama;
    private string email;
    private string phone;
    private string tlp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginstatus"] != "true")
        {
            Response.Write("<script>alert('Anda harus login')</script>");
            Response.Redirect("AdminLogin.aspx");
        }
        
        if (!IsPostBack)
        {
            DropDownList1.Items.Add("Actived");
            DropDownList1.Items.Add("Deactived");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        username = TextBox1.Text;
        password = TextBox2.Text;
        status = DropDownList1.Text;
        nama = TextBox3.Text;
        email = TextBox4.Text;
        phone = TextBox5.Text;
        tlp = TextBox6.Text;

        AdminProcess ap = new AdminProcess();
        int result = ap.insertAdmin(username, password, status, nama, email, phone, tlp);

        if (result != 0)
        {
            Response.Write("<script>alert('Data Has Been Saved')</script>");
            clear();
        }
    }
    private void clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        DropDownList1.SelectedIndex = 0;
    }
}