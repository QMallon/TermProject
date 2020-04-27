using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Utilities
{
    public class EmailSender
    {
            /*
         
             This method help you to send emails to users by imputing the proper values. 
             
             */

        public Boolean SendEmail(String toAddress, String fromAddress, String EmailBody, String EmailSubject) {
            
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("match564586@gmail.com", "@Green1993");
            smtp.EnableSsl = true;

            MailMessage emailMsg = new MailMessage();
            emailMsg.Subject = EmailSubject;
            emailMsg.Body = EmailBody;
            emailMsg.To.Add(toAddress);
            emailMsg.From = new MailAddress(fromAddress);

            try
            {

                smtp.Send(emailMsg);
                return true;

            }
            catch
            {

                return false;
                throw;
               
            }


        }


    }
}
