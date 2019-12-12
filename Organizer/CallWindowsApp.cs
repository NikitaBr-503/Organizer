using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    class CallWindowsApp
    {
        
        public void OpenNotepadApp()
        {
            Process notepadProcess = Process.Start("notepad.exe");
            bool exit = true;
            while (exit) {

                Console.WriteLine("1 - Close Notepad");
                Console.WriteLine("2 - Exit to main menu");
                Console.WriteLine("Input number of operation:");
                string i = Convert.ToString(Console.ReadLine());
                switch (i)
                {
                    case "1":
                        try {
                            notepadProcess.CloseMainWindow();
                            exit = false;
                        }    
                        catch(Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case "2":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid data, try again:");
                        break;
                }         
            }
        }
       

        public void OpenNotepadApp(String message)
        {
            Process.Start("notepad.exe", message);
        }
    }
}
