using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class TutorialOrderData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TutorialOrdersProcess top = new TutorialOrdersProcess();
        StringBuilder html = top.getAllTutor();
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }
}