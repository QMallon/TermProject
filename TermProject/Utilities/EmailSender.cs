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
            
        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        bool enableSSL = true;
         string emailFromAddress = "match564586@gmail.com"; 
         string password = "@Green1993"; 
         string emailToAddress = toAddress;   
         string subject = EmailSubject;
         string body = EmailBody;

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFromAddress);
                    mail.To.Add(emailToAddress);
                    mail.Subject = subject;
                    mail.Body = body;

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {

                        smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                        return true;
                    }
                }
            }
            catch {


                return false;

            }        
    }



    }
}
