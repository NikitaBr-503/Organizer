using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = true;
            string numberOfOperation;
            while (exit)
            {
                Console.WriteLine("1 - Open Notepad");
                Console.WriteLine("2 - Work with files");
                Console.WriteLine("3 - Get current weather");
                Console.WriteLine("4 - Send Email message");
                Console.WriteLine("5 - Exit...");
                Console.WriteLine("Input number of operation:");
                numberOfOperation = Convert.ToString(Console.ReadLine());

                switch (numberOfOperation)
                {
                    case "1":
                        CallWindowsApp notepad = new CallWindowsApp();
                        notepad.OpenNotepadApp();
                        break;
                    case "2":
                        WorkingWithFiles files = new WorkingWithFiles();
                        files.FilesMenu();
                        break;
                    case "3":
                        WeatherClass weather = new WeatherClass();
                        weather.WeatherMenu();
                        break;
                    case "4":
                        SendMail mail = new SendMail();
                        mail.MailMenu();
                        break;
                    case "5":
                        Console.WriteLine("Exit...");
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Incorect data, try again!");
                        break;
                }
            }


        }
    }
}
