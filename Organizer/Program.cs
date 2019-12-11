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
            String numberOfOperation;
            while (exit)
            {
                Console.WriteLine("1 - Open Notepad");
                Console.WriteLine("2 - Using files");
                Console.WriteLine("3 - Watching News from news.com");
                Console.WriteLine("4 - In developing...");
                Console.WriteLine("5 - Exit...");
                Console.WriteLine("Input number of operation:");
                numberOfOperation = Convert.ToString(Console.ReadLine());

                switch (numberOfOperation)
                {
                    case "1":
                        Console.WriteLine("Windows app");
                        CallWindowsApp notepad = new CallWindowsApp();
                        notepad.OpenNotepadApp();
                        break;
                    case "2":
                        Console.WriteLine("Read and write of file");
                        break;
                    case "3":
                        Console.WriteLine("API call");
                        break;
                    case "4":
                        Console.WriteLine("Here will be something amazing");
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
