using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //XSS: Cross Site Scripting
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        LabelComments.Text = TextBoxComment.Text;
    }
}