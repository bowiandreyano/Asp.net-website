using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class FrontEnd_CustomerLogin_CustomerLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Key Press Enter
        if (!IsPostBack)
        {
            TextBox2.Attributes.Add("onKeyPress",
                           "doClick('" + Button1.ClientID + "',event)");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_admin1 where username = @uname and password = @pass and status = 'Actived'";
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
                    Server.Transfer("overview.aspx");
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