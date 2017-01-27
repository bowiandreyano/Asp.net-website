using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
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
        if (!IsPostBack)
        {
            DropDownList1.Items.Add("Only Design");
            DropDownList1.Items.Add("Content & Design");
            DropDownList2.Items.Add("NEW ORDER");
            DropDownList2.Items.Add("Process");
            DropDownList2.Items.Add("Review");
            DropDownList2.Items.Add("Done");
            string id = Request.QueryString["oid"];

            OrderProcess pp = new OrderProcess();
            string[] data = pp.findAdminByid(id);
            TextBox1.Text = data[0];
            TextBox2.Text = data[1];
            TextBox3.Text = data[2];
            DropDownList1.SelectedValue = data[3];
            TextBox4.Text = data[4];
            TextBox5.Text = data[5];
            TextBox6.Text = data[6];
            DropDownList2.Text = data[7];
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        string tittle = TextBox2.Text;
        string user = TextBox3.Text;
        string ordertype = DropDownList1.SelectedValue;
        string desc = TextBox4.Text;
        string company = TextBox5.Text;
        string email = TextBox6.Text;
        string status = DropDownList2.SelectedValue;
        if (TextBox2.Text == "" || TextBox3.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "")
        {
            Response.Write("<script>alert('isi')</script>");
        }
        else
        {
            OrderProcess op = new OrderProcess();
            int result = op.UpdateOrder(id, tittle, user, ordertype, desc, company, email, status);
            if (result != 0)
            {
                Response.Write("<script>alert('Data has been saved!')</script>");
                Response.Redirect("orders.aspx");
            }
        }
    }
}   
