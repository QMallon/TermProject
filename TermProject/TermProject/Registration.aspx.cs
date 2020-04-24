using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace TermProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        int intSession = 0;
        Validation validate = new Validation();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }
        
        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            string strEmail = txtEmail.Text;
            string strConfirmEmail = txtConfirmEmail.Text;
            string strPassword = txtPassword.Text;
            string strConfirmPassword = txtConfirmPassword.Text;

            string strQuestion = ddlSecurityQuestion.SelectedValue;
            string strQuestion2 = ddlSecurityQuestion2.SelectedValue;
            string strQuestion3 = ddlSecurityQuestion3.SelectedValue;

            int val = 0;

            
            if (strPassword == strConfirmPassword && validate.IsNotNull(strPassword)) // Validate password
            {
                if (validate.IsValidEmail(strEmail) && strEmail == strConfirmEmail && validate.IsNotNull(strEmail)) // validate email

                    if (strQuestion != strQuestion2 && strQuestion2 != strQuestion3 && strQuestion3 != strQuestion) // validate questions 

                    {

                        objDB = new DBConnect();
                        objCommand = new SqlCommand();

                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "sp_addNewUser";

                        objCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                        objCommand.Parameters.AddWithValue("@password", txtPassword.Text);
                        objCommand.Parameters.AddWithValue("@email", txtEmail.Text);


                        objCommand.Parameters.AddWithValue("@SecurityQuestion", ddlSecurityQuestion.SelectedValue);
                        objCommand.Parameters.AddWithValue("@SecurityResponse", txtSecurityResponse.Text);

                        objCommand.Parameters.AddWithValue("@SecurityQuestion2", ddlSecurityQuestion2.SelectedValue);
                        objCommand.Parameters.AddWithValue("@SecurityResponse2", txtSecurityResponse2.Text);

                        objCommand.Parameters.AddWithValue("@SecurityQuestion3", ddlSecurityQuestion3.SelectedValue);
                        objCommand.Parameters.AddWithValue("@SecurityResponse3", txtSecurityResponse3.Text);



                        val = objDB.DoUpdateUsingCmdObj(objCommand);

                        if (val < 0)
                        {
                            
                            lblStatus.ForeColor = Color.Red;
                            lblStatus.Text = "[Server:Error]";

                        }
                        else {

                            Session["Username"] = txtUsername.Text;
                            Response.Redirect("/CreateProfile.aspx");
                            lblStatus.ForeColor = Color.Green;
                            lblStatus.Text = "Success: New user was created";

                        }

                    }
                    else {

                        lblSecQuestion.ForeColor = Color.Red;
                        lblSecQuestion2.ForeColor = Color.Red;
                        lblSecQuestion3.ForeColor = Color.Red;
                        lblSecQuestion.Text = "Please pick three different questions and respond each one:";
                        
                    }


                else {

                    lblEmail.ForeColor = Color.Red;
                    lblEmail.Text = "Email wont match please verify:";
                    
                }

            }
            else {

                lblPassword.ForeColor = Color.Red;
                lblPassword.Text = "Password wont match please verify:";
                
            }

        }
        

    }

        
}