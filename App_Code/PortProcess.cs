using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Summary description for PortProcess
/// </summary>
public class PortProcess
{
    public string[] findPortById(string id)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        string[] data = new string[4];
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_portofolio where PortID = @idp";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                if (String.IsNullOrEmpty(id))
                {
                    sqlcom.Parameters.Add("@idp", DBNull.Value);
                }
                sqlcom.Parameters.Add("@idp", id);
                SqlDataReader dr = sqlcom.ExecuteReader();
                while (dr.Read())
                {
                    data[0] = dr.GetString(0);
                    data[1] = dr.GetString(1);
                    data[2] = dr.GetString(2);
                    data[3] = dr.GetString(3);
                }
            }
            sqlcon.Close();
        }
        return data;
    }
    public int Updateport(string id, string name, string desc, string img)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        int result = 0;
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "update tb_portofolio set PortName = @name, PortDescription = @desc, PortImage = @img where PortID = @id";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@id", id);
                sqlcom.Parameters.Add("@name", name);
                sqlcom.Parameters.Add("@desc", desc);
                sqlcom.Parameters.Add("@img", img);
                result = sqlcom.ExecuteNonQuery();
            }
            sqlcon.Close();
        }
        return result;
    }
    public int deleteport(string id)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        int result = 0;
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "delete from tb_portofolio where PortID = @id";
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
}