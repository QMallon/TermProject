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
    public partial class Login : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && Request.Cookies["LoginCookie"] != null)
            {
                HttpCookie cookie = Request.Cookies["LoginCookie"];

                txtLoginUserName.Text = cookie.Values["User"].ToString();

                txtLoginPassword.Text = cookie.Values["pass"].ToString();
            }
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUserName.Text;
            string password = txtLoginPassword.Text;
            if(username != "" || password != "")
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
                    if(loginset >0 )
                    {
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
                        //Response.Redirect("plsvrholfrt.aspx");
                    }
                    else
                    {
                        txtLoginUserName.Text = "";
                        txtLoginPassword.Text = "";
                    }
                    
                    


                }
                catch
                {
                    //Label1.Text = "Login failed";
                    txtLoginUserName.Text = "";
                    txtLoginPassword.Text = "";
                }
                // Code to get
                //getAccount( username, password);
            }

            
        }
    }
}