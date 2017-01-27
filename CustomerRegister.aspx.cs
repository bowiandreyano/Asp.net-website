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
    private string address;
    private string email;
    private string tlp;
    private string phone;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        username = TextBox1.Text;
        password = TextBox2.Text;
        address = TextBox3.Text;
        email = TextBox4.Text;
        tlp = TextBox5.Text;
        phone = TextBox6.Text;

        CustomerProcess cp = new CustomerProcess();
        int result = cp.insertCustomer(username, password, address, email, tlp, phone);

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
    }
}