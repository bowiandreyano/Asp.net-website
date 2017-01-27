using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

public partial class FrontEnd_CustomerLogin_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //buat event keyboard Enter
        if (!IsPostBack)
        {
            TextBox2.Attributes.Add("onKeyPress",
                           "doClick('" + Button1.ClientID + "',event)");
        }

        StringBuilder html = new StringBuilder();

        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_portofolio";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                SqlDataReader dr = sqlcom.ExecuteReader();
                while (dr.Read()) //selama didalam tabel masih ada data
                {
                    html.Append("<tr>");
                    //html.Append("<td>" + dr.GetString(0) + "</td>");
                    html.Append("<td>");
                    //html.Append("<div class='box'>");
                    html.Append("<div class='boximg w3-margin'>");
                    html.Append("<img src='PortoImg/" + dr.GetString(3) + "' width='200px' height='100px' margin='5px'/>");
                    html.Append("</div>");
                    html.Append("</td>");
                   // html.Append("<td>" + dr.GetString(1) + "</td>");
                   // html.Append("<td>" + dr.GetString(2) + "</td>");
                    html.Append("</tr>");

                }
            }
            sqlcon.Close();
        }
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });//mengambil value dari string builder yang ditempel ke placeholder 
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_customer1 where username = @uname and password = @pass";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@uname", TextBox1.Text);
                sqlcom.Parameters.Add("@pass", TextBox2.Text);

                SqlDataReader dr = sqlcom.ExecuteReader();
                if (dr.Read())
                {
                    Session["loginstatus"] = "true";
                    Session["username"] = TextBox1.Text;

                    Response.Write("<script>alert('Berhasil Login')</script>");
                    Server.Transfer("Order.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Gagal Login')</script>");
                    TextBox1.Text = "";
                }
            }
            sqlcon.Close();
        }
    }
}