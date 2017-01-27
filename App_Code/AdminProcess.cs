using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Summary description for AdminProcess
/// </summary>
public class AdminProcess
{
    public StringBuilder getAllAdmin()
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        StringBuilder html = new StringBuilder();
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_admin1";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                SqlDataReader dr = sqlcom.ExecuteReader();
                while (dr.Read())
                {
                    html.Append("<tr>");
                    html.Append("<td>" + dr.GetString(0) + "</td>");
                    //html.Append("<td>" + dr.GetString(1) + "</td>");
                    html.Append("<td>" + dr.GetString(2) + "</td>");
                    html.Append("<td>" + dr.GetString(3) + "</td>");
                    html.Append("<td>" + dr.GetString(4) + "</td>");
                    html.Append("<td>" + dr.GetString(5) + "</td>");
                    html.Append("<td>" + dr.GetString(6) + "</td>");
                    html.Append("<td>");
                    html.Append("<a href='AdminAdminDataUpdate.aspx?id=" + dr.GetString(0) + "'>Edit  </a>");
                    html.Append("<br>");
                    html.Append("<a href='AdminAdminDelete.aspx?username=" + dr.GetString(0) + "' onclick='return confirmation();'>Delete</a>");
                    //html.Append("<br>");
                    //html.Append("<a href='updatestatusactivate.aspx?id=" + dr.GetString(0) + "' onclick='return confirmation();'>Activation</a><a> | </a>");
                    //html.Append("<a href='updatestatusdeactivate.aspx?id=" + dr.GetString(0) + "' onclick='return confirmation();'>Deactivate</a><a> | </a>");
                    html.Append("</td>");
                    html.Append("</tr>");
                }
            }
            sqlcon.Close();
        }
        return html;
    }
    //public int Updateuserstatusdeactivation(string username)
    //{
    //    Koneksi kon = new Koneksi();
    //    SqlConnection sqlcon = kon.openConnection();
    //    int result = 0;
    //    using (sqlcon)
    //    {
    //        sqlcon.Open();
    //        string sql = "update tb_admin1 set status = 'INACTIVE' where username = @username";
    //        SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
    //        using (sqlcom)
    //        {
    //            sqlcom.Parameters.Add("@username", username);
    //            result = sqlcom.ExecuteNonQuery();
    //        }
    //        sqlcon.Close();
    //    }
    //    return result;
    //}
    //public int Updateuserstatusactivation(string username)
    //{
    //    Koneksi kon = new Koneksi();
    //    SqlConnection sqlcon = kon.openConnection();
    //    int result = 0;
    //    using (sqlcon)
    //    {
    //        sqlcon.Open();
    //        string sql = "update tb_admin1 set status = 'ACTIVE' where username = @username";
    //        SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
    //        using (sqlcom)
    //        {
    //            sqlcom.Parameters.Add("@username", username);
    //            result = sqlcom.ExecuteNonQuery();
    //        }
    //        sqlcon.Close();
    //    }
    //    return result;
    //}
    public string[] findAdminByUsername(string username)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        string[] data = new string[7];
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_admin1 where username = @id";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                if(String.IsNullOrEmpty(username))
                {
                    sqlcom.Parameters.Add("@id", DBNull.Value);
                }
                sqlcom.Parameters.Add("@id", username);
                SqlDataReader dr = sqlcom.ExecuteReader();
                while (dr.Read())
                {
                    data[0] = dr.GetString(0);
                    data[1] = dr.GetString(1);
                    data[2] = dr.GetString(2);
                    data[3] = dr.GetString(3);
                    data[4] = dr.GetString(4);
                    data[5] = dr.GetString(5);
                    data[6] = dr.GetString(6);
                }
            }
            sqlcon.Close();
        }
        return data;
    }
    //        if (String.IsNullOrEmpty(units))
    //        {
    //            command.Parameters.AddWithValue("@units", DBNull.Value); 
    //        }
    public int Updateadmin(string username, string password, string status, string nama, string email, string phonenum, string telephone)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        int result = 0;
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "update tb_admin1 set password = @password, status = @status, nama = @nama, email = @email, phonenum = @phonenum, telephone = @telephone where username = @username";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@username", username);
                sqlcom.Parameters.Add("@password", password);
                sqlcom.Parameters.Add("@status", status);
                sqlcom.Parameters.Add("@nama", nama);
                sqlcom.Parameters.Add("@email", email);
                sqlcom.Parameters.Add("@phonenum", phonenum);
                sqlcom.Parameters.Add("@telephone", telephone);
                result = sqlcom.ExecuteNonQuery();
            }
            sqlcon.Close();
        }
        return result;
    }
    public int deleteAdmin(string username)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        int result = 0;
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "delete from tb_admin1 where username = @username";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@username", username);
                result = sqlcom.ExecuteNonQuery();
            }
            sqlcon.Close();
        }
        return result;
    }

    public int insertAdmin(string username, string pass, string status, string nama, string email, string phone, string tlp)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        int result = 0;
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "insert tb_admin1 values(@username, @pass, @status, @nama, @email, @phone, @tlp)";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@username", username);
                sqlcom.Parameters.Add("@pass", pass);
                sqlcom.Parameters.Add("@status", status);
                sqlcom.Parameters.Add("@nama", nama);
                sqlcom.Parameters.Add("@email", email);
                sqlcom.Parameters.Add("@phone", phone);
                sqlcom.Parameters.Add("@tlp", tlp);
                result = sqlcom.ExecuteNonQuery();
            }
            sqlcon.Close();
        }
        return result;
    }
}