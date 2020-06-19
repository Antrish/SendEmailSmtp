using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendingEmailUsingSMTP
{
    public class Program
    {
       static string newLine = Environment.NewLine; // helps to drop the sentences to next line.
        static string emailStaus = string.Empty;
        public static void Main(string[] args)
        {
           
            string mailBody = "Hi," +newLine +
                               "Well Done !!" + newLine +
                               "\t You have learnt how to send email using .net C#."+ newLine +
                               "!!...HAPPY CODING...!!";
            SendEmail(mailBody);
            Console.WriteLine(newLine+"Email Status:"+" "+emailStaus);
            Console.Read();

        }
        public static void SendEmail(string mailBody)
        {
            //1. MailMessage is a class which helps to frame mail information like 'from,To,Body' for smtp client server.
            MailMessage mailMessage = new MailMessage("antrishm@gmail.com", "antrish.mishra14@gmail.com");
            mailMessage.Subject = "Congratulations!!";
            mailMessage.Body = mailBody;

            //2. Instantiate SMTPClient class to pass server host,port and account credentials.
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
          
            smtpClient.UseDefaultCredentials = false;                          //Not mandatory but prefrable to avoid picking default creds.
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "antrishm@gmail.com",
                Password = "Enter_Valid_Password_Here"                       // provide email account password, I have not given mine :)

            };
        //3. Since gmail opereates on SSL(secured Socket Layer), please enable SSL
            smtpClient.EnableSsl = true;

        //4. It's better to have try-catch, it helps to cature the reason in case email eas not sent or SMTP server rejects the request for any reason.
            try {
                smtpClient.Send(mailMessage);
                emailStaus = "Email was sent successfully..!";
            }
            catch (Exception ex) 
            {
                Console.WriteLine("===========EXCEPTION:=========="+ newLine +
                                "Check you email account authentication configuration, Turn off 2-factor authentication if enabled."+ newLine +
                                "Navigate to this url - https://myaccount.google.com/lesssecureapps" + newLine +
                                "Then allow less secureapps." + newLine +
                                "This exceptions occures because"+" "+ ex.Message);
                emailStaus = "Email was not sent.";
            }
           

        }
             
    }
}
