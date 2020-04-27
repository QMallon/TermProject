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
    public partial class WebForm6 : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        LikePassFunctions Function = new LikePassFunctions();
        List<Profile> Likes = new List<Profile>();
        List<Profile> Passes = new List<Profile>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Likes = getLikedProfiles();
                Passes = getPassedProfiles();

                gvLikes.DataSource = Likes;
                gvLikes.DataBind();

                gvDislikes.DataSource = Passes;
                gvDislikes.DataBind();
            }
            catch
            {
                //NoUserID / error
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // 

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //Get current ID then go to profile view using it
        }

        private List<Profile> getLikedProfiles()
        {
            List<Profile> LikedProfiles = new List<Profile>();
            


            List<int> likeList = Function.getLikes(Convert.ToInt32(Session["UserID"].ToString()));

            foreach (int x in likeList)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44345/api/profile/" + x);
                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(theDataStream);

                String data = reader.ReadToEnd();

                reader.Close();

                response.Close();



                // Deserialize a JSON string into a Team object.

                JavaScriptSerializer js = new JavaScriptSerializer();

                Profile currentProfile = js.Deserialize<Profile>(data);
                LikedProfiles.Add(currentProfile);
            }

            return LikedProfiles;
        }
        private List<Profile> getPassedProfiles()
        {
            List<Profile> passedProfiles = new List<Profile>();
            


            List<int> passList = Function.getPasses(Convert.ToInt32(Session["UserID"].ToString()));
            foreach(int x in passList)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44345/api/profile/" + x);
                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(theDataStream);

                String data = reader.ReadToEnd();

                reader.Close();

                response.Close();



                // Deserialize a JSON string into a Team object.

                JavaScriptSerializer js = new JavaScriptSerializer();

                Profile currentProfile = js.Deserialize<Profile>(data);
                passedProfiles.Add(currentProfile);
            }


            return passedProfiles;
        }

        protected void gvLikes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedrow = gvLikes.SelectedRow.RowIndex;
            Likes.RemoveAt(selectedrow);
            updateLikes();

        }

        private void updateLikes()
        {
            SqlCommand objCommand = new SqlCommand();
            BinaryFormatter serializer = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();
            List<int> likesints = new List<int>();
            foreach (Profile x in Likes)
            {
                likesints.Add(x.ProfileID);
            }
            Byte[] Store;

            serializer.Serialize(stream, likesints);

            Store = stream.ToArray();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_StoreLikes";

            objCommand.Parameters.AddWithValue("@UserId", Session["UserID"].ToString());
            objCommand.Parameters.AddWithValue("@Pass", Store);
            objDB.DoUpdateUsingCmdObj(objCommand);
        }
        private void updatePasses()
        {
            SqlCommand objCommand = new SqlCommand();
            BinaryFormatter serializer = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();
            List<int> passesints= new List<int>();
            foreach(Profile x in Passes)
            {
                passesints.Add(x.ProfileID);
            }
            Byte[] Store;

            serializer.Serialize(stream, passesints);

            Store = stream.ToArray();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_StorePass";

            objCommand.Parameters.AddWithValue("@UserId", Session["UserID"].ToString());
            objCommand.Parameters.AddWithValue("@Pass", Store);
            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        protected void gvDislikes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedrow = gvLikes.SelectedRow.RowIndex;
           
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {

            int selectedRow = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            Session["CurrentUserId"] = selectedRow;
            Response.Redirect("ProfileView.aspx");
            
        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            int selectedRow = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            Likes.RemoveAt(selectedRow);
            updateLikes();

        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            int selectedRow = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            Passes.RemoveAt(selectedRow);
            updatePasses();
        }
    }
}