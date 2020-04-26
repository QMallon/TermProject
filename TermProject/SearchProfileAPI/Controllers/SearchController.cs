using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Utilities;

using System.Data;
using System.Data.SqlClient;

namespace SearchProfileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        
        [HttpGet("GetProfilesByName/{Name}")]
        public List<Profile> GetProfilesByName(string Name) // get profiles by Name 
        {

            List<Profile> profiles = new List<Profile>();

            DBConnect objDB = new DBConnect();


            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "TP_sp_FindProfileByName";
            objCommand.Parameters.AddWithValue("@Name", Name);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            Profile profile;

            foreach (DataRow record in ds.Tables[0].Rows)
            {


                profile = new Profile();

                profile.ProfileID = int.Parse(record["ProfileId"].ToString());
                profile.UserID = int.Parse(record["UserID"].ToString());
                profile.UserImage = record["UserImage"].ToString();
                profile.FirstName = record["FirstName"].ToString();
                profile.LastName = record["LastName"].ToString();

                profile.StreetAddress = record["StreetAddress"].ToString();
                profile.StreetAddressLn2 = record["StreetAddressLn2"].ToString();
                profile.City = record["City"].ToString();
                profile.State = record["State"].ToString();

                profile.ZipCode = int.Parse(record["Zipcode"].ToString());

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


                profiles.Add(profile);

            }

            return profiles;

        }

        [HttpGet("GetProfilesByLocation/{city}/{state}")]
        public List<Profile> GetProfilesByLocation(string city, string state) // get profiles by city and state 
        {

            List<Profile> profiles = new List<Profile>();

            DBConnect objDB = new DBConnect();


            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "TP_sp_FindProfilesByLocation";
            objCommand.Parameters.AddWithValue("@city", city);
            objCommand.Parameters.AddWithValue("@state", state);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            Profile profile;

            foreach (DataRow record in ds.Tables[0].Rows)
            {


                profile = new Profile();

                profile.ProfileID = int.Parse(record["ProfileId"].ToString());
                profile.UserID = int.Parse(record["UserID"].ToString());
                profile.UserImage = record["UserImage"].ToString();
                profile.FirstName = record["FirstName"].ToString();
                profile.LastName = record["LastName"].ToString();

                profile.StreetAddress = record["StreetAddress"].ToString();
                profile.StreetAddressLn2 = record["StreetAddressLn2"].ToString();
                profile.City = record["City"].ToString();
                profile.State = record["State"].ToString();

                profile.ZipCode = int.Parse(record["Zipcode"].ToString());

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


                profiles.Add(profile);

            }

            return profiles;

        }

        [HttpGet("GetProfilesByAge/{MinAge}/{MaxAge}")]
        public List<Profile> GetProfilesByAge(int MinAge, int MaxAge) // get all profiles withing the range of age 
        {

            List<Profile> profiles = new List<Profile>();

            DBConnect objDB = new DBConnect();

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "TP_sp_FindProfilesByAge";

            objCommand.Parameters.AddWithValue("@MinAge", MinAge);
            objCommand.Parameters.AddWithValue("@MaxAge", MaxAge);


            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            Profile profile;

            foreach (DataRow record in ds.Tables[0].Rows)
            {


                profile = new Profile();

                profile.ProfileID = int.Parse(record["ProfileId"].ToString());
                profile.UserID = int.Parse(record["UserID"].ToString());
                profile.UserImage = record["UserImage"].ToString();
                profile.FirstName = record["FirstName"].ToString();
                profile.LastName = record["LastName"].ToString();

                profile.StreetAddress = record["StreetAddress"].ToString();
                profile.StreetAddressLn2 = record["StreetAddressLn2"].ToString();
                profile.City = record["City"].ToString();
                profile.State = record["State"].ToString();

                profile.ZipCode = int.Parse(record["Zipcode"].ToString());

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


                profiles.Add(profile);

            }

            return profiles;

        }
        
        [HttpGet("GetProfilesByOptions/{Commitment}/{Kids}/{WantKids}")]
        public List<Profile> GetProfilesByOptions(string Commitment, string Kids, string WantKids) // get all profiles 
        {

            List<Profile> profiles = new List<Profile>();

            DBConnect objDB = new DBConnect();

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "TP_sp_FindProfilesByOptions";

            objCommand.Parameters.AddWithValue("@Commitment", Commitment);
            objCommand.Parameters.AddWithValue("@Kids", Kids);
            objCommand.Parameters.AddWithValue("@WantKids", WantKids);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            Profile profile;

            foreach (DataRow record in ds.Tables[0].Rows)
            {


                profile = new Profile();

                profile.ProfileID = int.Parse(record["ProfileId"].ToString());
                profile.UserID = int.Parse(record["UserID"].ToString());
                profile.UserImage = record["UserImage"].ToString();
                profile.FirstName = record["FirstName"].ToString();
                profile.LastName = record["LastName"].ToString();

                profile.StreetAddress = record["StreetAddress"].ToString();
                profile.StreetAddressLn2 = record["StreetAddressLn2"].ToString();
                profile.City = record["City"].ToString();
                profile.State = record["State"].ToString();

                profile.ZipCode = int.Parse(record["Zipcode"].ToString());

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


                profiles.Add(profile);

            }

            return profiles;

        }

        [HttpGet("GetProfilesByReligion/{Religion}")]
        public List<Profile> GetProfilesByReligion(string Religion) // get profiles by Name 
        {

            List<Profile> profiles = new List<Profile>();

            DBConnect objDB = new DBConnect();


            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "TP_sp_FindProfilesByReligion";
            objCommand.Parameters.AddWithValue("@Religion", Religion);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            Profile profile;

            foreach (DataRow record in ds.Tables[0].Rows)
            {


                profile = new Profile();

                profile.ProfileID = int.Parse(record["ProfileId"].ToString());
                profile.UserID = int.Parse(record["UserID"].ToString());
                profile.UserImage = record["UserImage"].ToString();
                profile.FirstName = record["FirstName"].ToString();
                profile.LastName = record["LastName"].ToString();

                profile.StreetAddress = record["StreetAddress"].ToString();
                profile.StreetAddressLn2 = record["StreetAddressLn2"].ToString();
                profile.City = record["City"].ToString();
                profile.State = record["State"].ToString();

                profile.ZipCode = int.Parse(record["Zipcode"].ToString());

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


                profiles.Add(profile);

            }

            return profiles;

        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)

        {

        }




    }
}
