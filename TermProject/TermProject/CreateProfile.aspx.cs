using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

using System.Device.Location;

namespace TermProject
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strUsername = "";
        string strUserID = "";
        int val = 0;

        Validation validate = new Validation();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSudmit_Click(object sender, EventArgs e)
        {
            strUsername = Session["Username"].ToString();

            if (strUsername != ""){

                objDB = new DBConnect();
                objCommand = new SqlCommand();

                strUsername = Session["Username"].ToString();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetUserIDByUSername";

                objCommand.Parameters.AddWithValue("@Username", strUsername);

                DataSet ds = new DataSet();

                ds = objDB.GetDataSetUsingCmdObj(objCommand);

                strUserID = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]); // get the userID using the username

                if (strUserID == "")
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "[Server:Error]";

                } // if dataset is empty userID wont exist  
                else // create new profile
                {

                    CreateNewProfile();

                }

            } //If user try to access create profile without a valid User
            else {

               //display error message 

            }
            
        }
        
        
        private void CreateNewProfile() {


            objDB = new DBConnect();
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_sp_addNewProfile";


            objCommand.Parameters.AddWithValue("@UserID", strUserID); // need a int value 
            objCommand.Parameters.AddWithValue("@UserImage", "jk"); // userimage
            objCommand.Parameters.AddWithValue("@FisrtName", txtFirstName.Text);


            objCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);
            objCommand.Parameters.AddWithValue("@StreetAddress", txtStreetAddress.Text);

            objCommand.Parameters.AddWithValue("@City", txtCity.Text);
            objCommand.Parameters.AddWithValue("@State", txtState.Text);

            objCommand.Parameters.AddWithValue("@ZipCode", txtZipcode.Text);



            val = objDB.DoUpdateUsingCmdObj(objCommand);

            if (val < 0)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "[Server:Error new profile was not created]" + strUserID;

            }
            else
            {

                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Success: New user was created";

            }








        } //method gather all the required information for the new profile and save into the database

    }
}