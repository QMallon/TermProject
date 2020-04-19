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
        

        string strUserID = "";
        int val = 0;

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

                //display error message 

            }

        }

        protected void UploadFile(object sender, EventArgs e)
        {
            int imgSize = 0;
            string fileExt,imgName,imgType;
            string folderPath = Server.MapPath("~/Files/");


            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath);
            }

            //Save the File to the Directory (Folder).
            FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));


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

                    imgData = profile.UserImage;
                    Image1.BorderColor = Color.Green;

                }

                else

                {

                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Wrong File";
                    
                }
                
            } 
            
            Image1.ImageUrl = "~/Files/" + Path.GetFileName(FileUpload1.FileName);

        }

        private void CreateNewProfile() {
            
            profile.UserID = int.Parse(strUserID);
            profile.FirstName = txtFirstName.Text;
            profile.LastName = txtLastName.Text;

            //----------- address ------------//

            profile.StreetAddress = txtStreetAddress.Text;
            profile.StreetAddressLn2 = txtStreetAddressLn2.Text;
            profile.City = txtCity.Text;
            profile.State = ddlState.SelectedValue;
            profile.ZipCode = int.Parse(txtZipcode.Text);

            //--------- Physical --------------//

            profile.Age = int.Parse(txtAge.Text);
            profile.Height = double.Parse(txtWeight.Text);
            profile.Weight = double.Parse(txtWeight.Text);
            
            //---------- About ------------

            profile.Ocupation = txtOcupation.Text;
            profile.Interest = txtInterest.Text;
            profile.LikesDislikes = txtLikesDislikes.Text;
            profile.Favorites = txtFavorites.Text;
            profile.Goals = txtGoals.Text;
            profile.Commitment = rblCommitment.SelectedValue;
            profile.Kids = rbKids.SelectedValue;
            profile.WantKids = rbWantKids.SelectedValue;
            profile.Religion = ddlReligion.SelectedValue;
            
            JavaScriptSerializer js = new JavaScriptSerializer();
            String JsonTeam = js.Serialize(profile);

            try
            {

                WebRequest request = WebRequest.Create(""); //webrequest for the api localhost
                //WebRequest request = WebRequest.Create(""); //webrequest for the api published version

                request.Method = "Post";
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

                response.Close();

                if (data == "true")
                {

                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "Success: New user was created";

                }
                else
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "[Server:Error new profile was not created]" + strUserID;
                }


            }

            catch(Exception ex){

                lblStatus.Text = "Error " + ex.Message;

            }

            CleanTextFields();
        }

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