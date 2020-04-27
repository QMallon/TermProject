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
using System.Windows;
using Utilities;

namespace TermProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        LikePassFunctions Function = new LikePassFunctions();
        Profile currentProfile;

        protected void Page_Load(object sender, EventArgs e)
        {
            //string Username = Session["Username"].ToString();
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objDB = new DBConnect();
                objCommand = new SqlCommand();
                
                int ID = Convert.ToInt32(Session["CurrentUserID"].ToString());
                if(Session["UserId"].ToString() == Session["CurrentUserID"].ToString())
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_GetProfileByUserID";


                    objCommand.Parameters.AddWithValue("@UserId", ID);
                    DataSet ProfileID = objDB.GetDataSetUsingCmdObj(objCommand);

                    int profileID = Convert.ToInt32(ProfileID.Tables[0].Rows[0][0].ToString());
                    viewProfilenonUser(profileID);
                }
                else
                {
                    viewProfilenonUser(ID);
                }

               


                //int ID = 0 ;


               
            }
            catch
            {
                lblName.Text = "Error loading Profile";
            }


        }

        public void viewProfilenonUser(int ID)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44345/api/profile/" + ID);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(theDataStream);

            String data = reader.ReadToEnd();

            reader.Close();

            response.Close();



            // Deserialize a JSON string into a Team object.

            JavaScriptSerializer js = new JavaScriptSerializer();

            currentProfile = js.Deserialize<Profile>(data);

            string Name = currentProfile.FirstName + " " + currentProfile.LastName;

            if(Session["UserID"].ToString() == Session["CurrentUserID"].ToString())
            {
                Session["UsersName"] = currentProfile.FirstName;
            }

            string personalInfo = getProfilePI(currentProfile);
            //PersonalInfo.InnerHtml = getProfilePI(currentProfile);



            string values = getProfileValues(currentProfile);

            string interests = currentProfile.Interest;

            string likes_Dislikes = currentProfile.LikesDislikes;


            string Favorites = currentProfile.Favorites;

            imgProfilePicture.ImageUrl = currentProfile.UserImage;

            lblName.Text = Name;
            lblFavorites.Text = Favorites;
            lblInterests.Text = interests;
            lblLikes.Text = likes_Dislikes;
            lblPersonalInfo.Text = personalInfo;
            lblValues.Text = values;
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            Function.updateLikes(Convert.ToInt32(Session["UserID"].ToString()), currentProfile.ProfileID);


        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            Function.updatePass(Convert.ToInt32(Session["UserID"].ToString()), currentProfile.ProfileID);
        }

        private string getProfilePI(Profile x)
        {
            string PI = "";
            if (x.Age != 0 )
            {
                PI += "Age: " + x.Age;
            }
            if (x.Weight != 0)
            {
                PI += "\nWeight:  " + x.Weight;
            }
            if (x.Height != 0)
            {
                PI += "\nHeight: " + x.Height;
            }
            if (x.City != "" && x.City != null)
            {
                PI += "\nCity: " + x.City;
            }
            if (x.Ocupation != "" && x.Ocupation != null)
            {
                PI += "\nOccupation: " + x.Ocupation;
            }




            return PI;
        }
        private string getProfileValues(Profile x)
        {
            string PV = "";
            
            if (x.Religion != "" && x.Religion != null)
            {
                PV +=  "Religion: " + x.Religion;
            }
            if (x.Commitment != "" && x.Commitment != null)
            {
                PV +=   "\nCommitment: " + x.Commitment;
            }
            if(x.Kids != "" && x.Kids != null)
            {
                PV +=    "\nKids: " + x.Kids;
            }
            if(x.WantKids != "" && x.WantKids != null)
            {
                PV += "\nWant Kids: " + x.WantKids;
            }





            //MessageBox.Show(PV);
            return PV;
        }

        protected void btnDateRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void btnDateRequest_Click1(object sender, EventArgs e)
        {
            pnlDateRequest.Visible = true;
        }

        protected void btnDateSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(Session["UsersName"].ToString() != currentProfile.FirstName)
                {
                    DateTime date = Convert.ToDateTime(txtDate.Text);
                    string location = txtLocation.Text;
                    string desc = txtDescription.Text;

                    SqlCommand objCommand = new SqlCommand();
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    int ID1 = Convert.ToInt32(Session["UserID"]);
                    int ID2 = currentProfile.UserID;

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_CreateDate";
                    objCommand.Parameters.AddWithValue("@UserId1", ID1);
                    objCommand.Parameters.AddWithValue("@UserId2", ID2);
                    objCommand.Parameters.AddWithValue("@Location", ID2);
                    objCommand.Parameters.AddWithValue("@Date", ID2);
                    objCommand.Parameters.AddWithValue("@Description", ID2);
                    objCommand.Parameters.AddWithValue("@UserName1", Session["UsersName"].ToString());
                    objCommand.Parameters.AddWithValue("@UserName2", currentProfile.FirstName);
                    objDB.DoUpdateUsingCmdObj(objCommand);



                }
                else
                {
                    MessageBox.Show("Cannot Date yourself Error");
                }







                pnlDateRequest.Visible = false;
            }
            catch
            {
                MessageBox.Show("Date Request Error");
                pnlDateRequest.Visible = false;
            }
            

        }

        protected void btnBlock_click(object sender, EventArgs e)
        {
            //Add current profile to block
            SqlCommand objCommand = new SqlCommand();
            //objCommand  = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetBlocks";

            objCommand.Parameters.AddWithValue("@UserId", Session["CurrentUserID"].ToString());

            objDB.GetDataSetUsingCmdObj(objCommand);



            Byte[] byteArray = (Byte[])objDB.GetField("BlockList", 0);



            BinaryFormatter deSerializer = new BinaryFormatter();

            MemoryStream memStream = new MemoryStream(byteArray);



            List<int> BlockList = (List<int>)deSerializer.Deserialize(memStream);

            BlockList.Add(Convert.ToInt32(Session["CurrentUserID"]));

            BinaryFormatter serializer = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();

            Byte[] Store;

            serializer.Serialize(stream, BlockList);

            Store = memStream.ToArray();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_StoreBlocks";

            objCommand.Parameters.AddWithValue("@UserId", Session["CurrentUserID"].ToString());
            objCommand.Parameters.AddWithValue("@BlockList", Store);
            objDB.DoUpdateUsingCmdObj(objCommand);
        }
    }
    
}