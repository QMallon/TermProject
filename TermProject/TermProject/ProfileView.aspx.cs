﻿using System;
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
            string Username = Session["Username"].ToString();

            if(Username == "")
            {
                viewProfilenonUser();
            }
            
        }

        public void viewProfilenonUser()
        {

        }
    }
    
}