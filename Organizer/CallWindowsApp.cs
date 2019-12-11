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
                String i = Convert.ToString(Console.ReadLine());
                if (i == "1"){
                    notepadProcess.CloseMainWindow();
                    exit = false;
                }
                else 
                    Console.WriteLine("Invalid data, try again: ");
                
            }
        }

        public void OpenNotepadApp(String message)
        {
            Process.Start("notepad.exe", message);
        }
    }
}
