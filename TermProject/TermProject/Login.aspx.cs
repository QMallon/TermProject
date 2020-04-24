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
    public partial class WebForm1 : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["LoginCookie"] != null)
            {
                HttpCookie cookie = Request.Cookies["LoginCookie"];

                txtUserName.Text = cookie.Values["User"].ToString();

                txtPassword.Text = cookie.Values["pass"].ToString();
            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            if (username != "" || password != "")
            {

                try
                {
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    //Login
                    objCommand.CommandText = "TP_Login";

                    SqlParameter user = new SqlParameter("@username", username);

                    user.Direction = ParameterDirection.Input;
                    user.SqlDbType = SqlDbType.VarChar;
                    objCommand.Parameters.Add(user);

                    SqlParameter Password = new SqlParameter("@password", password);
                    Password.Direction = ParameterDirection.Input;
                    Password.SqlDbType = SqlDbType.VarChar;

                    objCommand.Parameters.Add(Password);

                    DataSet loginFound = dBConnect.GetDataSetUsingCmdObj(objCommand);
                    int loginset = Convert.ToInt32(loginFound.Tables[0].Rows[0][0].ToString());
                    if (loginset  !=  0)
                    {
                        Session["Username"] = txtUserName.Text;
                        Session["UserID"] = loginset;
                        Session["CurrentUserID"] = loginset;
                        if (chkRemember.Checked == true)
                        {
                            //Cookie
                            HttpCookie loginCookie = new HttpCookie("LoginCookie");



                            //values
                            loginCookie.Values["User"] = username;
                            loginCookie.Values["pass"] = password;
                            loginCookie.Expires = new DateTime();

                            
                            //add
                            Response.Cookies.Add(loginCookie);


                        }
                        Response.Redirect("ProfileView.aspx");
                    }
                    else
                    {
                        txtUserName.Text = "";
                        txtPassword.Text = "";
                    }




                }
                catch
                {
                    //Label1.Text = "Login failed";
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                }
                // Code to get
                //getAccount( username, password);
            }


        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {

        }
    }
}
    
