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

            public bool IsProperString(string s)
            {


                foreach (char c in s)  // for every character in the string 
                {

                    if (!Char.IsLetter(c) && c != ',') // if the character is not a letter or "," 
                    {

                        return false;

                    }

                }

                return true;

            } // validate that the string only has letter or , 

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


    }


}

