using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

public partial class PortofolioAdminData : System.Web.UI.Page
{
    protected void AutoGenerateID()
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
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        using (sqlcon)
        {
            sqlcon.Open();
            string query = "select top 1 PortID from tb_portofolio order by PortID desc";
            SqlCommand sqlcom = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcom.ExecuteReader();
            if (dr.Read())
            {
                string no = dr[0].ToString(); //index kolom di table
                int number = Convert.ToInt32(no.Substring(1, 2));
                number = number + 1;
                if (number > 9)
                {
                    TextBox1.Text = "P" + number.ToString();
                }
                else
                {
                    TextBox1.Text = "P0" + number.ToString();
                }
            }
            else
            {
                TextBox1.Text = "P01";
            }
            dr.Close();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AutoGenerateID();
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
                    html.Append("<td>" + dr.GetString(0) + "</td>");
                    html.Append("<td>");
                    html.Append("<img src='/FrontEnd/CustomerLogin/PortoImg/" + dr.GetString(3) + "' width='200px'/>");
                    html.Append("</td>");
                    html.Append("<td>" + dr.GetString(1) + "</td>");
                    html.Append("<td>");
                    html.Append("<a href='PortofolioAdminDelete.aspx?id=" + dr.GetString(0) + "' onclick='return confirmation();'>Delete</a></br><br/>");
                    html.Append("<a href='PortofolioAdminUpdate.aspx?idp=" + dr.GetString(0) + "' onclick='return confirmation();'>Update</a>");
                    html.Append("</td>");
                    html.Append("</tr>");

                }
            }
            sqlcon.Close();
        }
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });//mengambil value dari string builder yang ditempel ke placeholder 
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        string nama = TextBox2.Text;
        string deskripsi = TextBox3.Text;
        string imgName = FileUpload1.FileName;
        if (TextBox2.Text == "" || TextBox3.Text == "" || TextBox3.Text == "" || FileUpload1.FileName == "" || TextBox1.Text == "")
        {
            Response.Write("<script>alert('isi')</script>");
        }
        else
        {
            // upload image ke direktori yang telah disediakan
            string imgPath = "/FrontEnd/CustomerLogin/PortoImg/" + imgName;
            FileUpload1.SaveAs(Server.MapPath(imgPath));

            // simpan data ke database
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.openConnection();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "insert tb_portofolio values(@id, @nama, @desc, @imgname)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add("@id", id);
                    sqlcom.Parameters.Add("@nama", nama);
                    sqlcom.Parameters.Add("@desc", deskripsi);
                    sqlcom.Parameters.Add("@imgname", imgName);
                    int result = sqlcom.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Response.Write("<script>alert('Success!')</script>");
                    }
                }
                sqlcon.Close();
            }
        }
    }
}