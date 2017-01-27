using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
/// <summary>
/// Summary description for CustomerProcess
/// </summary>
public class CustomerProcess
{
    //public string Encrypt(string plainText)
    //{
    //    if (plainText == null) throw new ArgumentNullException("plainText");

    //    //encrypt data
    //    var data = Encoding.Unicode.GetBytes(plainText);
    //    byte[] encrypted = ProtectedData.Protect(data, null, Scope);

    //    //return as base64 string
    //    return Convert.ToBase64String(encrypted);
    //}

    public int deleteCustomer(string username)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        int result = 0;
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "delete from tb_customer1 where username = @username";
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

    public StringBuilder getAllCustomer()
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        StringBuilder html = new StringBuilder();
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_customer1";
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
                    html.Append("<td>");
                    //html.Append("<a href='updateproduct.aspx?id=" + dr.GetString(0) + "'>Edit  </a>");
                    ////html.Append("<br>");
                    html.Append("<a href='AdminCustomerDelete.aspx?username=" + dr.GetString(0) + "' onclick='return confirmation();'>Delete</a>");
                    html.Append("</td>");
                    html.Append("</tr>");
                }
            }
            sqlcon.Close();
        }
        return html;
    }

    public int insertCustomer(string username, string pass, string address, string email, string tlp, string phone)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        int result = 0;
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "insert tb_customer1 values(@username, @pass, @address, @email, @tlp, @phone)";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@username", username);
                sqlcom.Parameters.Add("@pass", pass);
                sqlcom.Parameters.Add("@address", address);
                sqlcom.Parameters.Add("@email", email);
                sqlcom.Parameters.Add("@tlp", tlp);
                sqlcom.Parameters.Add("@phone", phone);
                result = sqlcom.ExecuteNonQuery();
            }
            sqlcon.Close();
        }
        return result;
    }
}