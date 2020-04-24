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
using System.IO;

using System.Web.Script.Serialization; //Json serialization
using System.IO; // Stream reader and Stream
using System.Net; // Web Request 

namespace TermProject
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        Profile profile = new Profile();
        string strUsername = "";
        string strUserImage = "";
        
        string strUserID = "";
  
        Validation validate = new Validation();


        protected void Page_Load(object sender, EventArgs e)
        {

            strUsername = Session["Username"].ToString();
           

            if (strUsername != "")
            {

                divMain.Visible = true;

            }
            else {

                divMain.Visible = false;

            }


        }


        /*****************************************
         This method validates that the user has a
         account before allow him to create the 
         new porfile, after the validation the 
         createnewprofile() method is called. 
        *****************************************/

        protected void btnSudmit_Click(object sender, EventArgs e)
        {

            if (strUsername != "") {

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

                lblStatus.Text = "You need to create account first first be able to create a profile";//display error message 

            }

        }
        
       /*****************************************
        This method updload a img, jpg, bmp or gif
        image to the server for be used as a 
        profile image.
       *****************************************/
        protected void UploadFile(object sender, EventArgs e)
        {
            int imgSize = 0;
            string fileExt,imgName,imgType;
            string folderPath = Server.MapPath("~/Img/Profiles");


            
            if (!Directory.Exists(folderPath)) //if directory wont exist
            {
                
                Directory.CreateDirectory(folderPath); // if directory wont exist create the directory

            }

            FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName)); // save file to the directory img/profiles


            if (FileUpload1.HasFile) { 

                imgSize = FileUpload1.PostedFile.ContentLength;

                byte[] imgData = new byte[imgSize];

                FileUpload1.PostedFile.InputStream.Read(imgData, 0, imgSize);
                imgName = FileUpload1.PostedFile.FileName;
                imgType = FileUpload1.PostedFile.ContentType;

                fileExt = imgName.Substring(imgName.LastIndexOf("."));
                fileExt = fileExt.ToLower();

                if (fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".bmp" || fileExt == ".gif")

                {
                    
                    Image1.BorderColor = Color.Green;

                }

                else

                {

                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Wrong File";
                    
                }
                
            } 
            
            Image1.ImageUrl = "~/Img/Profiles/" + Path.GetFileName(FileUpload1.FileName);


        }


        /*****************************************
         This method creates a new profile saving
         the new profile user info into a Profile()
         Object and send it to the WebApi to be
         Stored.   
        *****************************************/
        private void CreateNewProfile() {
            
            profile = new Profile();

            if (validate.IsText(txtFirstName.Text)
                && validate.IsText(txtLastName.Text)
                 && validate.IsNotNull(txtStreetAddress.Text)
                  && validate.IsNotNull(txtStreetAddressLn2.Text)
                   && validate.IsText(txtCity.Text)
                    && validate.IsValidInt(txtZipcode.Text)

                    )
            {
                //---------- Main info ----------//

                profile.UserID = int.Parse(strUserID);
                profile.FirstName = txtFirstName.Text;
                profile.LastName = txtLastName.Text;
                profile.UserImage = strUserImage;


                //----------- address ------------//

                profile.StreetAddress = txtStreetAddress.Text;
                profile.StreetAddressLn2 = txtStreetAddressLn2.Text;
                profile.City = txtCity.Text;
                profile.State = ddlState.SelectedValue;
                profile.ZipCode = int.Parse(txtZipcode.Text);

            }  else
            {

                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Please verity your imputs for your address.";

            }


            //--------- Physical --------------//
            if (validate.IsValidInt(txtAge.Text)
                    && validate.IsValidDecimal(txtHeight.Text)
                     && validate.IsValidDecimal(txtWeight.Text)
                    )
                {
                    profile.Age = int.Parse(txtAge.Text);
                    profile.Height = double.Parse(txtHeight.Text);
                    profile.Weight = double.Parse(txtWeight.Text);

                }
                else {

                    txtAge.ForeColor = Color.Red;
                    txtHeight.ForeColor = Color.Red;
                    txtAge.ForeColor = Color.Red;

                    lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Verify your imputs there is something invalid.";

                }

                //---------- About ------------
                if (validate.IsNotNull(txtOcupation.Text)
                    && validate.IsNotNull(txtInterest.Text)
                     && validate.IsNotNull(txtLikesDislikes.Text)
                      && validate.IsNotNull(txtFavorites.Text)
                        && validate.IsNotNull(txtGoals.Text)
                           && validate.IsNotNull(rblCommitment.SelectedValue)
                            && validate.IsNotNull(rbKids.SelectedValue)
                             && validate.IsNotNull(rbWantKids.SelectedValue)
                              && validate.IsNotNull(rbWantKids.SelectedValue)
                               && validate.IsNotNull(ddlReligion.SelectedValue)
                               )
                {

                    profile.Ocupation = txtOcupation.Text;
                    profile.Interest = txtInterest.Text;
                    profile.LikesDislikes = txtLikesDislikes.Text;
                    profile.Favorites = txtFavorites.Text;
                    profile.Goals = txtGoals.Text;
                    profile.Commitment = rblCommitment.SelectedValue;
                    profile.Kids = rbKids.SelectedValue;
                    profile.WantKids = rbWantKids.SelectedValue;
                    profile.Religion = ddlReligion.SelectedValue;
                }
                else {

                    txtOcupation.ForeColor = Color.Red;
                    txtInterest.ForeColor = Color.Red;
                    txtLikesDislikes.ForeColor = Color.Red;
                    txtFavorites.ForeColor = Color.Red;
                    txtGoals.ForeColor = Color.Red;
                    rblCommitment.ForeColor = Color.Red;
                    rbKids.ForeColor = Color.Red;
                    rbWantKids.ForeColor = Color.Red;
                    ddlReligion.ForeColor = Color.Red;

                    lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Verify your imputs there is something invalid.";

                }
           

            JavaScriptSerializer js = new JavaScriptSerializer();
            String JsonTeam = js.Serialize(profile);

            try
            {

                WebRequest request = WebRequest.Create("https://localhost:44345/api/profile/"); //webrequest for the api localhost
                //WebRequest request = WebRequest.Create(""); //webrequest for the api published version

                request.Method = "POST";
                request.ContentLength = JsonTeam.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(JsonTeam);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);

                String data = reader.ReadToEnd();
                reader.Close();

                response.Close();

                if (data == "true")
                {

                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "Success: New user was created";

                }
                else
                {

                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "[Server:Error new profile was not created]";

                }

            }

            catch(Exception ex){

                lblStatus.Text = "Error " + ex.Message;

            }

            CleanTextFields();

        }

        /*****************************************
         This cleans all the text fields.
        *****************************************/
        private void CleanTextFields() {

            txtCity.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            ddlState.SelectedValue = "";
            txtStreetAddress.Text = "";
            txtStreetAddressLn2.Text = "";
            txtZipcode.Text = "";




            
        }
        
        
    }
     
}