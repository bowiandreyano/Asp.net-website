using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Summary description for TutorialOrdersProcess
/// </summary>
public class TutorialOrdersProcess
{
    public int Updatetutor(string id, string name, string desc)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        int result = 0;
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "update tb_order set TutorderName = @name, TutorderDesc = @desc where TutorderID = @id";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@id", id);
                sqlcom.Parameters.Add("@name", name);
                sqlcom.Parameters.Add("@desc", desc);
                result = sqlcom.ExecuteNonQuery();
            }
            sqlcon.Close();
        }
        return result;
    }
    public string[] findtutorByid(string id)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        string[] data = new string[3];
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_tutor where TutorderID = @tid";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                if (String.IsNullOrEmpty(id))
                {
                    sqlcom.Parameters.Add("@tid", DBNull.Value);
                }
                sqlcom.Parameters.Add("@tid", id);
                SqlDataReader dr = sqlcom.ExecuteReader();
                while (dr.Read())
                {
                    data[0] = dr.GetString(0);
                    data[1] = dr.GetString(1);
                    data[2] = dr.GetString(2);
                }
            }
            sqlcon.Close();
        }
        return data;
    }

    public int deleteTutor(string id)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        int result = 0;
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "delete from tb_tutor where TutorderID = @id";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@id", id);
                result = sqlcom.ExecuteNonQuery();
            }
            sqlcon.Close();
        }
        return result;
    }

    public StringBuilder getAllTutor()
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        StringBuilder html = new StringBuilder();
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_tutor";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                SqlDataReader dr = sqlcom.ExecuteReader();
                while (dr.Read())
                {
                    html.Append("<tr>");
                    html.Append("<td>" + dr.GetString(0) + "</td>");
                    html.Append("<td>" + dr.GetString(1) + "</td>");
                    html.Append("<td>" + dr.GetString(2) + "</td>");
                    html.Append("<td>");
                    html.Append("<a href='TutorialOrderUpdate.aspx?tid=" + dr.GetString(0) + "'>Edit  </a>");
                    ////html.Append("<br>");
                    html.Append("<a href='TutorialOrderDelete.aspx?id=" + dr.GetString(0) + "' onclick='return confirmation();'>Delete</a>");
                    html.Append("</td>");
                    html.Append("</tr>");   
                }
            }
            sqlcon.Close();
        }
        return html;
    }
    public int insertTutor(string id, string name, string desc)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        int result = 0;
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "insert tb_tutor values(@id, @name, @desc)";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@id", id);
                sqlcom.Parameters.Add("@name", name);
                sqlcom.Parameters.Add("@desc", desc);
                result = sqlcom.ExecuteNonQuery();
            }
            sqlcon.Close();
        }
        return result;
    }
}