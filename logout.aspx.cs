﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginstatus"] == "true")
        {
            Session.RemoveAll();
            Response.Redirect("AdminLogin.aspx");
        }

    }
}