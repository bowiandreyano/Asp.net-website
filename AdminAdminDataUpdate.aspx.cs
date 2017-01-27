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
        if (!IsPostBack)
        {
            DropDownList1.Items.Add("Actived");
            DropDownList1.Items.Add("Inactive");

            string username = Request.QueryString["id"];

            AdminProcess pp = new AdminProcess();
            string[] data = pp.findAdminByUsername(username);
            TextBox1.Text = data[0];
            TextBox2.Text = data[1];
            DropDownList1.SelectedValue = data[2];
            TextBox3.Text = data[3];
            TextBox4.Text = data[4];
            TextBox5.Text = data[5];
            TextBox6.Text = data[6];
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = TextBox1.Text;
        string password = TextBox2.Text;
        string status = DropDownList1.SelectedValue;
        string nama = TextBox3.Text;
        string email = TextBox4.Text;
        string phonenum = TextBox5.Text;
        string telephone = TextBox6.Text;

        AdminProcess pp = new AdminProcess();
        int result = pp.Updateadmin(username, password, status, nama, email, phonenum, telephone);

        if (result != 0)
        {
            Response.Write("<script>alert('Data has been saved!')</script>");
            Server.Transfer("AdminAdminData.aspx");
        }
    }
}
