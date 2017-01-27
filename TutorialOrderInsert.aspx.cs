using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

public partial class TutorialOrderInsert : System.Web.UI.Page
{
    string id;
    string name;
    string desc;
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
            string query = "select top 1 TutorderID from tb_tutor order by TutorderID desc";
            SqlCommand sqlcom = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcom.ExecuteReader();
            if (dr.Read())
            {
                string no = dr[0].ToString(); //index kolom di table
                int number = Convert.ToInt32(no.Substring(1, 2));
                number = number + 1;
                if (number > 9)
                {
                    TextBox1.Text = "T" + number.ToString();
                }
                else
                {
                    TextBox1.Text = "T0" + number.ToString();
                }
            }
            else
            {
                TextBox1.Text = "T01";
            }
            dr.Close();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AutoGenerateID();
        TutorialOrdersProcess top = new TutorialOrdersProcess();
        StringBuilder html = top.getAllTutor();
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        id = TextBox1.Text;
        name = TextBox2.Text;
        desc = TextBox3.Text;
        if (TextBox2.Text == "" || TextBox3.Text == "" || TextBox3.Text == "" || TextBox1.Text == "")
        {
            Response.Write("<script>alert('isi')</script>");
        }
        else
        {
            TutorialOrdersProcess top = new TutorialOrdersProcess();
            int result = top.insertTutor(id, name, desc);
            if (result != 0)
            {
                Response.Write("<script>alert('Data Has Been Saved')</script>");
                clear();
            }
        }
    }
    private void clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }

}