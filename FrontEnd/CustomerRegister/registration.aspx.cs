using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class preview_dotnet_templates_registration_Form_index : System.Web.UI.Page
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
    
    protected void btnSubmit_Click(object sender, EventArgs e)
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
            Server.Transfer("/FrontEnd/CustomerLogin/index.aspx");
        }
    }
}