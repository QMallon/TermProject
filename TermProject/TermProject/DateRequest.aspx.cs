using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProject
{
    public partial class DateRequest : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvPendingDates.DataSource = getPDates(Convert.ToInt32(Session["UserID"]));
            gvPendingDates.DataBind();
            gvPlannedDates.DataSource = getCDates(Convert.ToInt32(Session["UserID"]));
            gvPlannedDates.DataBind();

        }

        private DataSet getCDates(int UserID)
        {

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            //Login
            objCommand.CommandText = "TP_GetCDates";
            SqlParameter ID = new SqlParameter("@UserId", Session["UserId"]);
            objCommand.Parameters.Add(ID);
            DataSet confirmedDates = objDB.GetDataSetUsingCmdObj(objCommand);

            return confirmedDates;
        }
        private DataSet getPDates(int UserID)
        {

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            //Login
            objCommand.CommandText = "TP_GetPDates";
            SqlParameter ID = new SqlParameter("@UserId", Session["UserId"]);
            objCommand.Parameters.Add(ID);
            DataSet potentialDates = objDB.GetDataSetUsingCmdObj(objCommand);

            return potentialDates;
        }
    }
}