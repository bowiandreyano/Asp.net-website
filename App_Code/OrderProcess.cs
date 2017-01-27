using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Summary description for OrderProcess
/// </summary>
public class OrderProcess
{
    public StringBuilder getOrderByID1(string id)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        StringBuilder html = new StringBuilder();
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_order where OrderID = @id";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@id", id);
                SqlDataReader dr = sqlcom.ExecuteReader();
                while (dr.Read())
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
        return html;
    }
    public StringBuilder getOrderByID(string id)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        StringBuilder html = new StringBuilder();
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_order where OrderID = @id";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@id", id);
                SqlDataReader dr = sqlcom.ExecuteReader();
                while (dr.Read())
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
                    html.Append("</tr>");
                }
            }
            sqlcon.Close();
        }
        return html;
    }
    public string[] findAdminByid(string id)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        string[] data = new string[8];
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "select * from tb_order where OrderID = @oid";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                if (String.IsNullOrEmpty(id))
                {
                    sqlcom.Parameters.Add("@oid", DBNull.Value);
                }
                sqlcom.Parameters.Add("@oid", id);
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
                    data[7] = dr.GetString(7);
                }
            }
            sqlcon.Close();
        }
        return data;
    }
    public int UpdateOrder(string id, string tittle, string user, string ordertype, string desc, string company, string email, string status)
    {
        Koneksi kon = new Koneksi();
        SqlConnection sqlcon = kon.openConnection();
        int result = 0;
        using (sqlcon)
        {
            sqlcon.Open();
            string sql = "update tb_order set Projecttittle = @tittle, username = @user, ordertype = @ordertype, orderdesc = @desc, company = @company, email = @email, status = @status where OrderID = @id";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            using (sqlcom)
            {
                sqlcom.Parameters.Add("@id", id);
                sqlcom.Parameters.Add("@tittle", tittle);
                sqlcom.Parameters.Add("@user", user);
                sqlcom.Parameters.Add("@ordertype", ordertype);
                sqlcom.Parameters.Add("@desc", desc);
                sqlcom.Parameters.Add("@company", company);
                sqlcom.Parameters.Add("@email", email);
                sqlcom.Parameters.Add("@status", status);
                result = sqlcom.ExecuteNonQuery();
            }
            sqlcon.Close();
        }
        return result;
    }
}