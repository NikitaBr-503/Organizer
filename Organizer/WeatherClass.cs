using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    class WeatherClass : IMenu
    {
        public void Menu()
        {
            string city;
            bool exit = true;
            while (exit)
            {
                Output("Choose a city:");
                Output("1 - Kiev");
                Output("2 - Lviv");
                Output("3 - Kharkiv");
                Output("4 - Chuhuiv");
                Output("5 - Exit to Main Menu");
                string i = Console.ReadLine();
                switch (i)
                {
                    case "1":
                        city = "Kiev";
                        WeatherAPICall(city);
                        break;
                    case "2":
                        city = "Lviv";
                        WeatherAPICall(city);
                        break;
                    case "3":
                        city = "Kharkiv";
                        WeatherAPICall(city);
                        break;
                    case "4":
                        city = "Chuhuiv";
                        WeatherAPICall(city);
                        break;
                    case "5":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid data, try again..");
                        break;
                }
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }
        private void WeatherAPICall(string city)
        {
            string responseText;
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=94c407e32527ad21602519b1bfa90d4b";

            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
   
                using (StreamReader stream = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = stream.ReadToEnd();
                }

                Rootobject response = JsonConvert.DeserializeObject<Rootobject>(responseText);

                Console.WriteLine("Temperature in {0}: {1} *C", response.name, response.main.temp);
                Console.Write("Description: ");
                for(int i= 0; i < response.weather.Length; i++) {
                    Console.WriteLine(response.weather[i].description);
                } 
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public class Rootobject
        {
            public Weather[] weather { get; set; }
            public Main main { get; set; }
            public string name { get; set; }
        }
        public class Main
        {
            public float temp { get; set; }
        }
        public class Weather
        {
            public string description { get; set; }
        }
    }
}
