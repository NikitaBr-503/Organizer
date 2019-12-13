using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    class CallWindowsApp : IMenu
    {
        public void Menu()
        {
            Process notepadProcess = Process.Start("notepad.exe");
            bool exit = true;
            while (exit)
            {
                Output("1 - Close Notepad");
                Output("2 - Exit to main menu");
                Output("Input number of operation:");
                string i = Convert.ToString(Console.ReadLine());
                switch (i)
                {
                    case "1":
                        try
                        {
                            notepadProcess.CloseMainWindow();
                            exit = false;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case "2":
                        exit = false;
                        break;
                    default:
                        Output("Invalid data, try again:");
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
