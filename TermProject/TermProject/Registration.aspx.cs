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

using System.Net.Mail;
using System.Net;


namespace TermProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        int intSession = 0;
        String code = "";
        Validation validate = new Validation();
        EmailSender email = new EmailSender();

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

            if (txtUsername.Text.All(char.IsLetterOrDigit))
            {
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
                            else
                            {

                                Session["Username"] = txtUsername.Text;
                                lblStatus.ForeColor = Color.Green;
                                lblStatus.Text = "Success: New user was created";

                                if (EmailVerification(txtEmail.Text))
                                { // get user ID and sen it to send the verification email

                                    Response.Redirect("/CreateProfile.aspx");

                                }

                            }

                        }
                        else
                        {

                            lblSecQuestion.ForeColor = Color.Red;
                            lblSecQuestion2.ForeColor = Color.Red;
                            lblSecQuestion3.ForeColor = Color.Red;
                            lblSecQuestion.Text = "Please pick three different questions and respond each one:";

                        }


                    else
                    {

                        lblEmail.ForeColor = Color.Red;
                        lblEmail.Text = "Email wont match please verify:";

                    }

                }
                else
                {

                    lblPassword.ForeColor = Color.Red;
                    lblPassword.Text = "Password wont match please verify:";

                }
            }
            else {

                lblPassword.ForeColor = Color.Red;
                lblPassword.Text = "Username is only allow to have numbers and letters:";

            }

        }

        public Boolean EmailVerification(string strEmail) {

            int val = 0;
            objDB = new DBConnect();
            objCommand = new SqlCommand();

            //----------Email verification -------------//
            Random random = new Random();
            code = random.Next(10001, 99999).ToString();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_sp_UpdateEmailVerificationCode";

            objCommand.Parameters.AddWithValue("@Email", strEmail);
            objCommand.Parameters.AddWithValue("@ConfirmationCode", code);

            val = objDB.DoUpdateUsingCmdObj(objCommand);

            if (val > 0)
            {

                String msg = "This is your verification code: " + code;

                if (email.SendEmail(txtEmail.Text, "match564586@gmail.com", msg, "Verification email"))
                {

                    lblStatus.Text = "Please check your email for your verification code.";
                    return true;
                }
                else
                {

                    lblStatus.Text = "Problem sending the email.";
                    return false;
                }



            }
            else
            {

                lblStatus.Text = "Unable to add verification code.";
                return false;

            }
            


        }

      
    }

        
}