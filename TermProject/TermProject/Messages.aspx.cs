using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace TermProject
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string UserID = Session["UserID"].ToString();

                if (UserID == "")
                {
                    divMessageControl.Visible = false;
                    Response.Write("<h2>Please login before try to opening your profile</h2>");

                }
            }
            catch {

                divMessageControl.Visible = false;
                Response.Write("<h2>Please login before try to opening your profile</h2>");


            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}