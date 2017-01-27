using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAdminDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //mengambil value dari parameter di url
        string username = Request.QueryString["username"];

        //passing value parameter ke deleteproduct()
        AdminProcess ap = new AdminProcess();
        int result = ap.deleteAdmin(username);

        //apabila berhasil, redirect ke viewproduct.aspx
        if (result != 0)
        {
            Response.Redirect("AdminAdminData.aspx");
        }

    }
}