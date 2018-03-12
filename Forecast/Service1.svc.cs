using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Forecast
{

    public class Service1 : IService1
    {
        /* The purpose of this function is to return the five day forceast of a given zipcode
         * from today's date, an array[] will be returned. array[0-4] will contain the maximums
         * and array[5-9] will contain the minimums
         * 
         * input: string zipcode
         * 
         * output: array 
         * 
         */ 
        public string[] Weather5day(string zipcode)
        {
            
            // creates a new WebWeatherService object
            WebWeatherService.ndfdXML newWeather = new WebWeatherService.ndfdXML();
            

            // calls LatLonListZipCode function to convert the zipString to latitude and
            // longitude coordinates. These coordinates will be contained within the returned xml
            // which will be stored as a string
            string zipCodeString = newWeather.LatLonListZipCode(zipcode);
            
            string latLongString = "";

            // XMLReader object is created to read the string in xml format
            XmlReader zipReader = XmlReader.Create(new StringReader(zipCodeString));
            
            //reads through the xml in order to get the latitude and longitude coordinates
            while (zipReader.Read())
            {
                if ((zipReader.NodeType == XmlNodeType.Element) && zipReader.Name == "latLonList")
                {
                    //stores lat and long coordinates into the latLongString variable
                    latLongString = zipReader.ReadElementContentAsString();
                }
            }

            // parses through latLongString to put the value of latitude into index 0 and longitude to index 1
            string[] words = latLongString.Split(',');
            
            //converts the obtained longitude and latitude to decimals
            decimal latitude = Convert.ToDecimal(words[0]);
            decimal longitude = Convert.ToDecimal(words[1]);

         

            WebWeatherService.weatherParametersType wtp = new WebWeatherService.weatherParametersType();
            wtp.temp = true;

            string temperatureValues = "";
            string weatherDescription = "";
            string xml = newWeather.NDFDgenByDay(latitude,longitude,DateTime.Now,"7",WebWeatherService.unitType.e,WebWeatherService.formatType.Item24hourly);

            //creates an XMLReader object to read through xml 
            XmlReader reader = XmlReader.Create(new StringReader(xml));

            string[] tempArray = new string[7];
            string[] descriptionArray = new string[14];
            while (reader.Read())
            {
                //obtains the content of an element named  "value" - used to gather high/lows
                if((reader.NodeType == XmlNodeType.Element) && (reader.Name == "value"))
                {
                        temperatureValues = temperatureValues + " " + reader.ReadElementContentAsString();
                        
                }
                // obtain weather description
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "weather-conditions"))
                {
                    if (weatherDescription == "")
                    {
                        weatherDescription = reader.GetAttribute(0);
                    }
                    else
                    {
                        weatherDescription = weatherDescription + "^" + reader.GetAttribute(0);
                    }

                }
                // obtain url for weather icon image
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "icon-link"))
                {
                    
                    weatherDescription = weatherDescription + "^" + reader.ReadElementContentAsString();

                } 

            }


            //splits the strings based on either '-' or space
            tempArray = temperatureValues.Split(null);
            descriptionArray = weatherDescription.Split('^');

           

            //only need first ten obtained values from myArray
            string[] temp = new string[14];
            Array.Copy(tempArray,1,temp,0,14);
            
            // combines the array containing the high/lows with the weather description array
            string[] forecast = new string[20];
            forecast = temp.Concat(descriptionArray).ToArray();
         
            return forecast;
            
            
    
        }

    }
}
