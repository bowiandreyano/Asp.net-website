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

        StringBuilder html = new StringBuilder();
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_order";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                SqlDataReader dr = sqlcom.ExecuteReader();
                while (dr.Read()) //selama didalam tabel masih ada data
                {
                    html.Append("<tr>");
                    html.Append("<td>" + dr.GetString(0) + "</td>");
                    html.Append("<td>" + dr.GetString(1) + "</td>");
                    html.Append("<td>" + dr.GetString(2) + "</td>");
                    html.Append("<td>" + dr.GetString(3) + "</td>");
                    html.Append("<td>" + dr.GetString(4) + "</td>");
                    html.Append("<td>" + dr.GetString(5) + "</td>");
                    html.Append("<td>" + dr.GetString(6) + "</td>");
                    html.Append("<td>" + dr.GetString(7) + "</td>");
                    html.Append("<td>");
                    //html.Append("<img src='/FrontEnd/CustomerLogin/PortoImg/" + dr.GetString(3) + "' width='200px'/>");
                    //html.Append("</td>");
                    //html.Append("<td>" + dr.GetString(1) + "</td>");

                    //html.Append("<a href='PortofolioAdminDelete.aspx?id=" + dr.GetString(0) + "' onclick='return confirmation();'>Delete</a></br><br/>");
                    html.Append("<a href='ordersupdates.aspx?oid=" + dr.GetString(0) + "' onclick='return confirmation();'>Update</a>");
                    html.Append("</td>");
                    html.Append("</tr>");

                }
            }
            sqlcon.Close();
        }
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });//mengambil value dari string builder yang ditempel ke placeholder 
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        OrderProcess pp = new OrderProcess();
        StringBuilder a = pp.getOrderByID1(id);
        PlaceHolder1.Controls.Add(new Literal { Text = a.ToString() });
    }
}

