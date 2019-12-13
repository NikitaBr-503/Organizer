using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    public class SendMail: IMenu
    {

        public void Menu()
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
                Output("1 - Send email from default account");
                Output("2 - Send email from own account");
                Output("3 - Exit to main menu");
                string i = Console.ReadLine();
                switch (i)
                {
                    case "1":
                        SendMessage(defaultEmailAddr, defaultPassword, defaultUserName);
                        break;
                    case "2":
                        Output("Warning!Your account must have permission enabled for <<Untrusted Applications>>");
                        Output("Input your gmail address: ");
                        ownEmailAddr = Console.ReadLine();
                        Output("Input your Name: ");
                        ownUserName = Console.ReadLine();
                        Output("Input your password: ");
                        ownPasswd = Console.ReadLine();

                        SendMessage(ownEmailAddr, ownPasswd, ownUserName);
                        break;
                    case "3":
                        exit = false;
                        break;
                    default:
                        Output("Invalid data, try again..");
                        break;
                }
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }

        private void SendMessage(string emailAddr, string password, string userName)
        {
            string recipientEmail;
            Output("Input recipient's gmail address: ");
            recipientEmail = Console.ReadLine();
            
           try
            {
                MailAddress fromMailAddress = new MailAddress(emailAddr, userName);
                MailAddress toMailAddress = new MailAddress(recipientEmail);

                using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    Output("Input subject: ");
                    mailMessage.Subject = Console.ReadLine();
                    Output("Input your message: ");
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
