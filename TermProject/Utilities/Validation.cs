using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
        public class Validation
        {
            public bool IsText(string s)
            {


                if (s.All(Char.IsLetter))
                {

                    return true;

                }
                else
                {

                    return false;

                }

            } // validate that the string only contain letters
        
            public bool IsNumberPhoneNumber(string s)
            {


                if (s.All(Char.IsNumber) && s.Length == 10)
                {

                    return true;

                }
                else
                {

                    return false;

                }

            } // validate that is a proper phone number

            public bool IsNotNull(string s)
            {

                if (s != "")
                {

                    return true;

                }
                else
                {

                    return false;

                }

            } // validate that the string is not null 

            public bool IsValidDecimal(string s)
            {

                if (s.All(Char.IsDigit))
                {

                    return true;

                }

                else
                {

                    return false;

                }


            } // validate that the string is a decimal

            public bool IsValidInt(string s){

                bool boolValue = false ;
                int val = 0;

                boolValue = int.TryParse(s, out val);

                return boolValue;

             }  // validate is a valid integer
        
            public bool IsValidEmail(string s)
        {
            try
            {

                var validEmail = new System.Net.Mail.MailAddress(s);
                return validEmail.Address == s;

            }
            catch
            {

                 return false;

            }
        } // validate email address
        
    }


}

