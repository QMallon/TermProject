using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProject
{
    public class Profile
    {
        
        public int ProfileID { get; set; }
        public int UserID { get; set; }
        public String UserImage { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        //---------address -----------

        public String StreetAddress { get; set; }
        public String StreetAddressLn2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public int ZipCode { get; set; }

        //------- Physical -----------

        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        //--------- About ------------------------

        public String Ocupation { get; set; }
        public String Interest { get; set; }
        public String LikesDislikes { get; set; }
        public String Favorites { get; set; }
        public String Goals { get; set; }
        public String Commitment { get; set; }
        public bool Kids { get; set; }
        public bool WantKids { get; set; }
        public String Religion { get; set; }




        public Profile() { }

        public Profile(String name)
        {

            this.FirstName = name;

        }

        public Profile(String firstname, String lastname, String streetaddress, String streetaddressln2, String city, String state, int zipcode, int age, double height, double weight, string ocupation, string interest, string likesdislikes, string favorites, string goals, string commitment, bool kids, bool wantkids, string religion)

        {

            this.FirstName = firstname;
            this.LastName = lastname;

            this.StreetAddress = streetaddress;
            this.StreetAddressLn2 = streetaddressln2;
            this.City = city;
            this.State = state;
            this.ZipCode = zipcode;

            this.Age = age;
            this.Height = height;
            this.Weight = weight;

            this.Ocupation = ocupation;
            this.Interest = interest;
            this.LikesDislikes = likesdislikes;
            this.Favorites = favorites;
            this.Goals = goals;
            this.Commitment = commitment;
            this.Kids = kids;
            this.WantKids = wantkids;
            this.Religion = religion;
            
        }

    }
}