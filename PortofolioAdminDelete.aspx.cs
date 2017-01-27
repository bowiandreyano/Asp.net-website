using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PortofolioAdminDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //mengambil value dari parameter di url
        string id = Request.QueryString["id"];

        //passing value parameter ke deleteproduct()
        PortProcess cp = new PortProcess();
        int result = cp.deleteport(id);

        //apabila berhasil, redirect ke viewproduct.aspx
        if (result != 0)
        {
            Response.Redirect("PortofolioAdminData.aspx");
        }
    }
}