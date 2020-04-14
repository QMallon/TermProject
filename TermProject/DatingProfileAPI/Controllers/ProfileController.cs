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
        // GET: api/Profile
        [HttpGet]
        public List<Profile> Get() // get all profiles 
        {

            List<Profile> profiles = new List<Profile>();
            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet("SELECT * FROM TP_Profiles");
            Profile profile;

            foreach (DataRow record in ds.Tables[0].Rows) {


                profile = new Profile();

                profile.ProfileID = int.Parse(record["ProfileId"].ToString());
                profile.UserID = int.Parse(record["UserID"].ToString());
                profile.UserImage = record["UserImage"].ToString();
                profile.FirstName = record["FisrtName"].ToString();
                profile.LastName = record["LastName"].ToString();
                profile.StreetAddress = record["StreetAddress"].ToString();
                profile.StreetAddressLn2 = record["StreetAddressLn2"].ToString();
                profile.City = record["City"].ToString();
                profile.State = record["State"].ToString();
                profile.ZipCode = int.Parse(record["Zipcode"].ToString());

                profiles.Add(profile);

            }

            return profiles;

        }
        

        // GET: api/Profile/5
        [HttpGet("{id}", Name = "Get")]
public Profile Get(int id) // get the profile by user ID
        {

            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet("SELECT * FROM TP_Profiles WHERE ProfileId = " + id.ToString());

            Profile profile = new Profile();

            if (ds.Tables[0].Rows.Count != 0) {


                DataRow record = ds.Tables[0].Rows[0];

                profile.ProfileID = int.Parse(record["ProfileId"].ToString());
                profile.FirstName = record["FistName"].ToString();
                profile.LastName = record["LastName"].ToString();
                profile.StreetAddress = record["StreetAddress"].ToString();
                profile.StreetAddressLn2 = record["StreetAddressLn2"].ToString();
                profile.City = record["City"].ToString();
                profile.State = record["State"].ToString();
                profile.ZipCode = int.Parse(record["Zipcode"].ToString());


            }

            return profile;


        }

        // POST: api/Profile
        [HttpPost]
        public Boolean Post([FromBody] Profile profile) // insert new profile 
        {

            DBConnect objDb = new DBConnect();

            string strSQL = "INSERT Into TP_Profiles(FisrtName, LastName, StreetAddress, StreetAddressLn2, City, State, ZipCode)" + "Values('" + profile.FirstName + "', '" + profile.LastName + "', '" + profile.StreetAddress + "', '" + profile.StreetAddressLn2 + "', '" + profile.City + "', '" + profile.State + "', '" + profile.ZipCode + ")";

            int result = objDb.DoUpdate(strSQL);

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

            if(result > 0){

                return true;

            }

            return false;


        }
    }
}
