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
            if (!IsPostBack)
            {
                try
                {


                    gvPendingDates.DataSource = getPDates(Convert.ToInt32(Session["UserID"]));
                    gvPendingDates.DataBind();
                    gvPlannedDates.DataSource = getCDates(Convert.ToInt32(Session["UserID"]));
                    gvPlannedDates.DataBind();
                }
                catch
                {
                    
                }
            }
            

        }

        private DataSet getCDates(int UserID)
        {

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            //Login
            objCommand.CommandText = "TP_GetCDates";
            SqlParameter ID = new SqlParameter("@UserId", Convert.ToInt32(Session["UserId"].ToString()));
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
            SqlParameter ID = new SqlParameter("@UserId", Convert.ToInt32(Session["UserId"].ToString()));
            objCommand.Parameters.Add(ID);
            DataSet potentialDates = objDB.GetDataSetUsingCmdObj(objCommand);

            return potentialDates;
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string name = row.Cells[1].Text;
            //int rowIndex = e.Item.ItemIndex;
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            //Login
            objCommand.CommandText = "TP_ConfirmDate";
            objCommand.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"].ToString()));
            objCommand.Parameters.AddWithValue("@PassConfirm", 1);
            objCommand.Parameters.AddWithValue("@UserName", name);
            objDB.DoUpdateUsingCmdObj(objCommand);
        }
        protected void btnPass_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string name = row.Cells[1].Text; 

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            //Login
            objCommand.CommandText = "TP_ConfirmDate";
            objCommand.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"].ToString()));
            objCommand.Parameters.AddWithValue("@PassConfirm", 2);
            objCommand.Parameters.AddWithValue("@UserName", name);
            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        protected void gvPendingDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}