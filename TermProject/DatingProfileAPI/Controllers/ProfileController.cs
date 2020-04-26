using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;

using System.Data;
using System.Data.SqlClient;

namespace DatingProfileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        // GET: api/Profile
        [HttpGet]
        public List<Profile> Get() // get all profiles 
        {

            List<Profile> profiles = new List<Profile>();
            DBConnect objDB = new DBConnect();


            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "TP_GetAllProfiles";

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            Profile profile;

            foreach (DataRow record in ds.Tables[0].Rows)
            {


                profile = new Profile();

                profile.ProfileID = int.Parse(record["ProfileId"].ToString());
                profile.UserID = int.Parse(record["UserID"].ToString());
                //profile.UserImage 
                profile.FirstName = record["FirstName"].ToString();
                profile.LastName = record["LastName"].ToString();

                profile.StreetAddress = record["StreetAddress"].ToString();
                profile.StreetAddressLn2 = record["StreetAddressLn2"].ToString();
                profile.City = record["City"].ToString();
                profile.State = record["State"].ToString();

                profile.ZipCode = int.Parse(record["Zipcode"].ToString());

                /*

                profile.Age = int.Parse(record["Age"].ToString());

                profile.Height = double.Parse(record["Height"].ToString());

                profile.Weight = double.Parse(record["Weight"].ToString());

                profile.Ocupation = record["Ocupation"].ToString();
                profile.Interest = record["Interest"].ToString();
                profile.LikesDislikes = record["LikesDislikes"].ToString();
                profile.Favorites = record["Favorites"].ToString();
                profile.Goals = record["Goals"].ToString();
                profile.Kids = record["Kids"].ToString();
                profile.WantKids = record["WantKids"].ToString();
                profile.Religion = record["Religion"].ToString();
                */

                profiles.Add(profile);

            }

            return profiles;

        }


        // GET: api/Profile/5
        [HttpGet("{id}", Name = "Get")]
        public Profile Get(int id) // get the profile by user ID
        {

            DBConnect objDB = new DBConnect();

            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;


            objCommand.CommandText = "TP_GetProfileByID";

            objCommand.Parameters.AddWithValue("@ProfileID", id);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);



            Profile profile = new Profile();

            if (ds.Tables[0].Rows.Count != 0)
            {


                DataRow record = ds.Tables[0].Rows[0];

                profile.ProfileID = int.Parse(record["ProfileId"].ToString());
                profile.UserID = int.Parse(record["UserID"].ToString());
                //profile.UserImage 

                profile.FirstName = record["FirstName"].ToString();

                profile.LastName = record["LastName"].ToString();

                profile.StreetAddress = record["StreetAddress"].ToString();
                profile.StreetAddressLn2 = record["StreetAddressLn2"].ToString();
                profile.City = record["City"].ToString();
                profile.State = record["State"].ToString();
                profile.ZipCode = int.Parse(record["Zipcode"].ToString());

                profile.Age = int.Parse(record["Age"].ToString());
                profile.Height = int.Parse(record["Height"].ToString());
                profile.Weight = double.Parse(record["Weight"].ToString());

                profile.Ocupation = record["Ocupation"].ToString();
                profile.Interest = record["Interest"].ToString();
                profile.LikesDislikes = record["LikesDislikes"].ToString();
                profile.Favorites = record["Favorites"].ToString();
                profile.Goals = record["Goals"].ToString();
                profile.Kids = record["Kids"].ToString();
                profile.WantKids = record["WantKids"].ToString();
                profile.Religion = record["Religion"].ToString();
                profile.Commitment = record["Commitment"].ToString();


            }

            return profile;


        }


        // POST: api/Profile
        [HttpPost]
        public Boolean AddProfile([FromBody] Profile profile) // insert new profile 
        {
            
            objDB = new DBConnect();
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_sp_addNewProfile";


            objCommand.Parameters.AddWithValue("@UserID", profile.UserID); // need a int value 


            objCommand.Parameters.AddWithValue("@UserImage", profile.UserImage);

            objCommand.Parameters.AddWithValue("@FirstName", profile.FirstName);
            objCommand.Parameters.AddWithValue("@LastName", profile.LastName);

            objCommand.Parameters.AddWithValue("@StreetAddress", profile.StreetAddress);
            objCommand.Parameters.AddWithValue("@StreetAddressLn2", profile.StreetAddressLn2);
            objCommand.Parameters.AddWithValue("@City", profile.City);
            objCommand.Parameters.AddWithValue("@State", profile.State);
            objCommand.Parameters.AddWithValue("@ZipCode", profile.ZipCode);
            /*
            objCommand.Parameters.AddWithValue("@Age", profile.Age);
            objCommand.Parameters.AddWithValue("@Height", profile.Height);
            objCommand.Parameters.AddWithValue("@Weight", profile.Weight);

            objCommand.Parameters.AddWithValue("@Ocupation", profile.Ocupation);
            objCommand.Parameters.AddWithValue("@Interest", profile.Interest);
            objCommand.Parameters.AddWithValue("@LikesDislikes", profile.LikesDislikes);
            objCommand.Parameters.AddWithValue("@Favorites", profile.Favorites);
            objCommand.Parameters.AddWithValue("@Goals", profile.Goals);
            objCommand.Parameters.AddWithValue("@Kids", profile.Kids);
            objCommand.Parameters.AddWithValue("@WantKids", profile.WantKids);
            objCommand.Parameters.AddWithValue("@Religion", profile.Religion);
           */
            int result = objDB.DoUpdateUsingCmdObj(objCommand);

            if (result > 0)
            {

                return true;

            }

            return false;



        }


        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Boolean Delete(int id) //delete profiles
        {

            DBConnect objDB = new DBConnect();

            int result = 0;

            string strSQL = "DELETE FROM TP_Profiles Where ProfileID = '" + id.ToString() + "'";

            result = objDB.DoUpdate(strSQL);

            if (result > 0)
            {

                return true;

            }

            return false;


        }

    }
}
