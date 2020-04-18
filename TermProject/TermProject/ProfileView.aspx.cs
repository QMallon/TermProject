using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            strUsername = Session["Username"].ToString();
            if(strUsername == "")
            {
                viewProfilenonUser();
            }
        }
    }
}