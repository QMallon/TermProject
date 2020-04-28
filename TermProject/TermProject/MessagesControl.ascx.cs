using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace TermProject
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
       
            
            string userID = "";
            string matchID = "";
            string username = "";


            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();


            protected void Page_Load(object sender, EventArgs e)
            {
                userID = Session["UserID"].ToString();
                username = Session["Username"].ToString();

                objDB = new DBConnect();
                objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_sp_GetMessages";
                objCommand.Parameters.AddWithValue("@ReceiverID", userID);
                objCommand.Parameters.AddWithValue("@SenderID", userID);
                DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

                rpMessages.DataSource = ds;
                rpMessages.DataBind();

                ddlMatches.DataTextField = "SenderID";
                ddlMatches.DataSource = ds;
                ddlMatches.DataBind();


            }


            public void Bind()
            {

                objDB = new DBConnect();
                objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_sp_GetMessages";
            objCommand.Parameters.AddWithValue("@ReceiverID", userID);
            objCommand.Parameters.AddWithValue("@SenderID", userID);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

                rpMessages.DataSource = ds;

                rpMessages.DataBind();

            }

            protected void Button1_Click(object sender, EventArgs e)
            {

            }

            protected void btnSend_Click(object sender, EventArgs e)
            {
                objDB = new DBConnect();
                objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_sp_SendMessage";
                
                objCommand.Parameters.AddWithValue("@SenderID", userID);
                objCommand.Parameters.AddWithValue("@Username", username);
                objCommand.Parameters.AddWithValue("@ReceiverID", ddlMatches.SelectedValue);
                objCommand.Parameters.AddWithValue("@Message", txtMessage.Text);
                
                objDB.DoUpdateUsingCmdObj(objCommand);
                Bind();

            }

            protected void ddlMatches_SelectedIndexChanged(object sender, EventArgs e)
            {

                matchID = ddlMatches.SelectedValue.ToString();
                Bind();

                objDB = new DBConnect();
                objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_sp_GetMessages";
            objCommand.Parameters.AddWithValue("@ReceiverID", userID);
            objCommand.Parameters.AddWithValue("@SenderID", userID);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

                rpMessages.DataSource = ds;

                rpMessages.DataBind();

            }

            



        }


    }
