using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = Session["Username"].ToString();
           
            SqlCommand objCommand = new SqlCommand();
            objDB = new DBConnect();
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUserIDByUSername";

            objCommand.Parameters.AddWithValue("@Username", Username);
            DataSet UserID = objDB.GetDataSetUsingCmdObj(objCommand);
            int ID = Convert.ToInt32(UserID.Tables[0].Rows[0][0].ToString());
            Session["CurrentUserID"] = ID;
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
            SqlCommand objCommand = new SqlCommand();
            //objCommand  = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_getLikes";

            objCommand.Parameters.AddWithValue("@UserId", Session["CurrentUserID"].ToString());

            objDB.GetDataSetUsingCmdObj(objCommand);



            Byte[] byteArray = (Byte[])objDB.GetField("Likes", 0);



            BinaryFormatter deSerializer = new BinaryFormatter();

            MemoryStream memStream = new MemoryStream(byteArray);



            List<int> likeList = (List<int>)deSerializer.Deserialize(memStream);

            likeList.Add(Convert.ToInt32(Session["CurrentUserID"]));

            BinaryFormatter serializer = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();

            Byte[] Store;

            serializer.Serialize(stream, likeList);

            Store = memStream.ToArray();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_StoreLikes";

            objCommand.Parameters.AddWithValue("@UserId", Session["CurrentUserID"].ToString());
            objCommand.Parameters.AddWithValue("@Likes", Store);
            objDB.DoUpdateUsingCmdObj(objCommand);


        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            //Add current profile to dislike
            SqlCommand objCommand = new SqlCommand();
            //objCommand  = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPass";

            objCommand.Parameters.AddWithValue("@UserId", Session["CurrentUserID"].ToString());

            objDB.GetDataSetUsingCmdObj(objCommand);



            Byte[] byteArray = (Byte[])objDB.GetField("Passes", 0);



            BinaryFormatter deSerializer = new BinaryFormatter();

            MemoryStream memStream = new MemoryStream(byteArray);



            List<int> passList = (List<int>)deSerializer.Deserialize(memStream);

            passList.Add(Convert.ToInt32(Session["CurrentUserID"]));

            BinaryFormatter serializer = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();

            Byte[] Store;

            serializer.Serialize(stream, passList);

            Store = memStream.ToArray();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_StorePass";

            objCommand.Parameters.AddWithValue("@UserId", Session["CurrentUserID"].ToString());
            objCommand.Parameters.AddWithValue("@Pass", Store);
            objDB.DoUpdateUsingCmdObj(objCommand);
        }
    }
    
}