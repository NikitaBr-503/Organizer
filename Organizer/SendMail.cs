using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    class SendMail
    {
        public void MailMenu()
        {
            string defaultEmailAddr = "t.testeracc1@gmail.com";
            string defaultPassword = "Test#Test1";
            string defaultUserName = "Tester";

            string ownEmailAddr;
            string ownPasswd;
            string ownUserName;
            bool exit = true;
            while (exit)
            {
                Console.WriteLine("1 - Send email from default account");
                Console.WriteLine("2 - Send email from own account");
                Console.WriteLine("3 - Exit to main menu");
                string i = Console.ReadLine();
                switch (i)
                {
                    case "1":
                        SendMessage(defaultEmailAddr, defaultPassword, defaultUserName);
                        break;
                    case "2":
                        Console.WriteLine("Warning!Your account must have permission enabled for <<Untrusted Applications>>");
                        Console.WriteLine("Input your gmail address: ");
                        ownEmailAddr = Console.ReadLine();
                        Console.WriteLine("Input your Name: ");
                        ownUserName = Console.ReadLine();
                        Console.WriteLine("Input your password: ");
                        ownPasswd = Console.ReadLine();
                        SendMessage(ownEmailAddr, ownPasswd, ownUserName);
                        break;
                    case "3":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid data, try again..");
                        break;
                }
            }
        }



        private void SendMessage(string emailAddr, string password, string userName)
        {
            string recipientEmail;
            Console.WriteLine("Input recipient's gmail address: ");
            recipientEmail = Console.ReadLine();
            
           try
            {
                MailAddress fromMailAddress = new MailAddress(emailAddr, userName);
                MailAddress toMailAddress = new MailAddress(recipientEmail);

                using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    Console.WriteLine("Input subject: ");
                    mailMessage.Subject = Console.ReadLine();
                    Console.WriteLine("Input your message: ");
                    mailMessage.Body = Console.ReadLine();

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, password);

                    smtpClient.Send(mailMessage);

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
