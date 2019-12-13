using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Organizer
{
    class WorkingWithFiles : IMenu
    {
        private string path = @"D:\test.txt";
        public void Menu()
        {
            bool exit = true;
            while (exit)
            {
                Output("1 - Create file");
                Output("2 - Open file for reading");
                Output("3 - Open file for writing (If file doesn't exist, it will be created)");
                Output("4 - Open file for rewriting");
                Output("5 - Delete existing file");
                Output("6 - Exit to Main Menu");
                string i = Console.ReadLine();
                switch (i)
                {
                    case "1":
                        CreateFile();
                        break;
                    case "2":
                        ReadingFile();
                        break;
                    case "3":
                        OpenForWriting(InputContentForFile(), true);
                        break;
                    case "4":
                        OpenForWriting(InputContentForFile(), false);
                        break;
                    case "5":
                        DeleteFile();
                        break;
                    case "6":
                        exit = false;
                        break;
                    default:
                        Output("Invalid data, try again..");
                        break;
                }
            }
        }

        private void CreateFile() {
            try {
                FileStream createFile = new FileStream(path, FileMode.CreateNew);
                createFile.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private void ReadingFile()
        {
            try
            {
                using (StreamReader readFile = new StreamReader(path))
                {
                    Console.WriteLine(readFile.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void OpenForWriting(String text, bool modeWrite)
        {
            try
            {
                using (StreamWriter writeToFile = new StreamWriter(path, modeWrite, Encoding.Default))
                {
                    writeToFile.WriteLine(text);
                }
                Output("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void DeleteFile()
        {
            try
            {
                File.Delete(path);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private string InputContentForFile()
        {
            Output("Input your text: ");
            return Console.ReadLine();
        }

       

        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}
