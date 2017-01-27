using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class FrontEnd_CustomerLogin_Order : System.Web.UI.Page

{
    protected void ManggilTutor()
    {
        StringBuilder html = new StringBuilder();
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_tutor";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                SqlDataReader dr = sqlcom.ExecuteReader();
                while (dr.Read()) //selama didalam tabel masih ada data
                {
                    html.Append("<tr>");
                    //html.Append("<td>" + dr.GetString(1) + "</td>");
                    html.Append("<td>");
                    //html.Append("<div class='box'>");
                    html.Append("<div class='boximg w3-margin'>");
                    //html.Append("<img src='PortoImg/" + dr.GetString(3) + "' width='200px' height='100px' margin='5px'/>");
                    html.Append("</div>");
                    html.Append("</td>");
                    html.Append("<h2 class='w3-text-light-grey'>" + dr.GetString(1) + "</h2>");
                    html.Append("<hr style='width:200px' class='w3-opacity'>");
                    html.Append("<td>" + dr.GetString(2) + "</td>");
                    html.Append("</tr>");

                }
            }
            sqlcon.Close();
        }
        Label2.Controls.Add(new Literal { Text = html.ToString() });//mengambil value dari string builder yang ditempel ke placeholder 
    }
    protected void AutoGenerateID()
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        using (sqlcon)
        {
            sqlcon.Open();
            string query = "select top 1 OrderID from tb_order order by OrderID desc";
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
        ManggilTutor();
        AutoGenerateID();
        if (!IsPostBack)
        {
            DropDownList1.Items.Add("Only Design");
            DropDownList1.Items.Add("Content & Design");
            StringBuilder a = new StringBuilder();
            a.Append("<tr>");
            a.Append("<td colspan='8'>Data belum di set.</td>");
            a.Append("</tr>");
            PlaceHolder2.Controls.Add(new Literal { Text = a.ToString() });
        }

        if (Session["loginstatus"] != "true")
        {
            Response.Write("<script>alert('Anda harus login')</script>");
            Server.Transfer("index.aspx");
        }
        else
        {
            
            Label1.Text = Session["username"].ToString();
            Label4.Text = Session["username"].ToString();
        }

        StringBuilder html = new StringBuilder();
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_order where username=@uname";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@uname", Label1.Text);
                SqlDataReader dr = sqlcom.ExecuteReader();
                while (dr.Read()) //selama didalam tabel masih ada data
                {
                    html.Append("<tr>");
                    html.Append("<td style='color: black;'>" + dr.GetString(0) + "</td>");
                    html.Append("<td style='color: black;'>" + dr.GetString(1) + "</td>");
                    html.Append("<td style='color: black;'>" + dr.GetString(2) + "</td>");
                    html.Append("<td style='color: black;'>" + dr.GetString(3) + "</td>");
                    html.Append("<td style='color: black;'>" + dr.GetString(4) + "</td>");
                    html.Append("<td style='color: black;'>" + dr.GetString(5) + "</td>");
                    html.Append("<td style='color: black;'>" + dr.GetString(6) + "</td>");
                    html.Append("<td style='color: black;'>" + dr.GetString(7) + "</td>");
                    //html.Append("<td>");
                    //html.Append("<img src='/FrontEnd/CustomerLogin/PortoImg/" + dr.GetString(3) + "' width='200px'/>");
                    //html.Append("</td>");
                    //html.Append("<td>" + dr.GetString(1) + "</td>");

                    //html.Append("<a href='PortofolioAdminDelete.aspx?id=" + dr.GetString(0) + "' onclick='return confirmation();'>Delete</a></br><br/>");
                    //html.Append("<a href='ordersupdate.aspx?oid=" + dr.GetString(0) + "' onclick='return confirmation();'>Update</a>");
                    //html.Append("</td>");
                    html.Append("</tr>");

                }
            }
        }
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });//mengambil value dari string builder yang ditempel ke placeholder 
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        string protittle = TextBox2.Text;
        string user = Label4.Text;
        string ordtype = DropDownList1.Text;
        string orddesc = TextBox3.Text;
        string company = TextBox4.Text;
        string email = TextBox5.Text;
        string status = "NEW ORDER";
        if (TextBox2.Text == "" || TextBox3.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "")
        {
            Response.Write("<script>alert('isi')</script>");
        }
        else
        {
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.openConnection();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "insert tb_order values(@id, @protittle, @user, @ordtype, @orddesc, @company, @email, @status)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add("@id", id);
                    sqlcom.Parameters.Add("@protittle", protittle);
                    sqlcom.Parameters.Add("@user", user);
                    sqlcom.Parameters.Add("@ordtype", ordtype);
                    sqlcom.Parameters.Add("@orddesc", orddesc);
                    sqlcom.Parameters.Add("@company", company);
                    sqlcom.Parameters.Add("@email", email);
                    sqlcom.Parameters.Add("@status", status);
                    int result = sqlcom.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Response.Write("<script>alert('Success!')</script>");
                        Server.Transfer("Order.aspx");
                    }
                }
                sqlcon.Close();
            }
            sqlcon.Close();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string id = TextBox7.Text;
        OrderProcess pp = new OrderProcess();
        StringBuilder a = pp.getOrderByID(id);
        PlaceHolder2.Controls.Add(new Literal { Text = a.ToString() });
    }
}