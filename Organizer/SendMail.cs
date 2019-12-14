using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    public class SendMail
    {

        public void StartSendMail()
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
                Console.Write(
                    "1. Send email from default account\n" +
                    "2. Send email from own account\n" +
                    "3. Exit to main menu\n" +
                    "Input number of operations: ");
                string i = Console.ReadLine();
                Console.Clear();
                switch (i)
                {
                    case "1":
                        SendMessage(defaultEmailAddr, defaultPassword, defaultUserName);
                        break;
                    case "2":
                        Console.WriteLine("Warning!Your account must have permission enabled for <<Untrusted Applications>>");
                        Console.Write("Input your gmail address: ");
                        ownEmailAddr = Console.ReadLine();
                        Console.Write("Input your name: ");
                        ownUserName = Console.ReadLine();
                        Console.Write("Input your password: ");
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
        public void SendMessage(string emailAddr, string password, string userName)
        {
           string recipientEmail;
           Console.Write("Input recipient's gmail address: ");
           recipientEmail = Console.ReadLine();
           try
            {
                MailAddress fromMailAddress = new MailAddress(emailAddr, userName);
                MailAddress toMailAddress = new MailAddress(recipientEmail);
                using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    Console.Write("Input subject: ");
                    mailMessage.Subject = Console.ReadLine();
                    Console.Write("Input your message: ");
                    mailMessage.Body = Console.ReadLine();
                    Console.Clear();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, password);
                    smtpClient.Send(mailMessage);
                    Console.WriteLine();
                    Console.WriteLine("Message has send!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine();
            }
        }
    }
}
