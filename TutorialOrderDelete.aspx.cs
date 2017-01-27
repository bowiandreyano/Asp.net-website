using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TutorialOrderDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];

        //passing value parameter ke deleteproduct()
        TutorialOrdersProcess top = new TutorialOrdersProcess();
        int result = top.deleteTutor(id);

        //apabila berhasil, redirect ke viewproduct.aspx
        if (result != 0)
        {
            Response.Redirect("TutorialOrderData.aspx");
        }
    }
}