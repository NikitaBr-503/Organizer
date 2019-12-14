using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
      class MainMenu: IMenu
    {
        public void Menu()
        {
            bool exit = true;
            string numberOfOperation;
            while (exit)
            {
                Output("1 - Open Notepad");
                Output("2 - Work with files");
                Output("3 - Get current weather");
                Output("4 - Send Email message");
                Output("5 - Exit...");
                Output("Input number of operation:");

                numberOfOperation = Convert.ToString(Console.ReadLine());

                switch (numberOfOperation)
                {
                    case "1":
                        CallWindowsApp notepad = new CallWindowsApp();
                        notepad.Menu();
                        break;
                    case "2":
                        WorkingWithFiles files = new WorkingWithFiles();
                        files.Menu();
                        break;
                    case "3":
                        WeatherClass weather = new WeatherClass();
                        weather.Menu();
                        break;
                    case "4":
                        SendMail mail = new SendMail();
                        mail.StartSendMail();
                        break;
                    case "5":
                        Output("Exit...");
                        exit = false;
                        break;
                    default:
                        Output("Invalid data, try again!");
                        break;
                }
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
            
        }
    }
}
