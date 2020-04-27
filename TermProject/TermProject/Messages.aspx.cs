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

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "TP_sp_GetListOfMessages";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            rpMessages.DataSource = myDS;

            rpMessages.DataBind();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}