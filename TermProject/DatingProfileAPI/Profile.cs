using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingProfileAPI
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public int UserID { get; set; }
        public String UserImage { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String StreetAddress { get; set; }
        public String StreetAddressLn2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public int ZipCode { get; set; }

        public Profile(){}

        public Profile(String name) {
            
            this.FirstName = name;

        }

        public Profile(String firstname, String lastname, String streetaddress, String streetaddressln2, String city, String state, int zipcode) {

            this.FirstName = firstname;
            this.LastName = lastname;
            this.StreetAddress = streetaddress;
            this.StreetAddressLn2 = streetaddressln2;
            this.City = city;
            this.State = state;
            this.ZipCode = zipcode;
            
        }
        


    }
}
