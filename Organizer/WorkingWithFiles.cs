using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Organizer
{
    class WorkingWithFiles
    {
        private string path = @"D:\test.txt";
        public void FilesMenu()
        {
            bool exit = true;
            while (exit)
            {
                Console.WriteLine("1 - Create file");
                Console.WriteLine("2 - Open file for reading");
                Console.WriteLine("3 - Open file for writing (If file doesn't exist, it will be created)");
                Console.WriteLine("4 - Open file for rewriting");
                Console.WriteLine("5 - Delete existing file");
                Console.WriteLine("6 - Exit to Main Menu");
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
                        OpenForWriting(InputContentForFile(), false);
                        break;
                    case "4":
                        OpenForWriting(InputContentForFile(), true);
                        break;
                    case "5":
                        DeleteFile();
                        break;
                    case "6":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid data, try again..");
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
                Console.WriteLine("Запись выполнена");
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
            Console.WriteLine("Input your text: ");
            return Console.ReadLine();
        }
    }
}
