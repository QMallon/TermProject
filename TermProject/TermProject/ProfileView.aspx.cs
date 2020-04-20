using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = Session["Username"].ToString();
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objDB = new DBConnect();
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUserIDByUSername";

            objCommand.Parameters.AddWithValue("@Username", Username);
            DataSet UserID = objDB.GetDataSetUsingCmdObj(objCommand);
            int ID = Convert.ToInt32(UserID.Tables[0].Rows[0][0].ToString());
           
            viewProfilenonUser(ID);
            
            
        }

        public void viewProfilenonUser(int ID)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("api/Profile");
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(theDataStream);

            String data = reader.ReadToEnd();

            reader.Close();

            response.Close();



            // Deserialize a JSON string into a Team object.

            JavaScriptSerializer js = new JavaScriptSerializer();

            Profile currentProfile = js.Deserialize<Profile>(data);
            
            string Name = currentProfile.FirstName + ", " + currentProfile.LastName;
            string personalInfo = "Age: " + currentProfile.Age + "\nWeight:  " +
                currentProfile.Weight + "\nHeight: " + currentProfile.Height + "\nLocation: " + currentProfile.City;
            string values = "Occupation: " + currentProfile.Ocupation + "\nReligion: "+ currentProfile.Religion+ "\nCommitment: " + currentProfile.Commitment + "\nKids: " + currentProfile.Kids
                +"\nWant Kids: " + currentProfile.WantKids;
            string interests = currentProfile.Interest;
            string likes_Dislikes = currentProfile.LikesDislikes;
            string Favorites = currentProfile.Favorites;

            //imgProfilePicture.ImageUrl = currentProfile.UserImage;

            lblName.Text = Name;
            lblFavorites.Text = Favorites;
            lblInterests.Text = interests;
            lblLikes.Text = likes_Dislikes;
            lblPersonalInfo.Text = personalInfo;
            lblValues.Text = values;
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            //Add current profile to like
            Session["CurrentUserID"].ToString();

        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            //Add current profile to dislike
        }
    }
    
}