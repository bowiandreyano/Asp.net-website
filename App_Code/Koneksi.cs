using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Koneksi
/// </summary>
public class Koneksi
{
    public SqlConnection openConnection()
    {
        SqlConnection sqlcon = new SqlConnection(
            "Data Source = BOWI-PC\\SQLEXPRESS;" +
            "Initial Catalog = ToserbaDB;" +
            "User Id = sa; Password = 123456"
        );

        return sqlcon;
    }
}