using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace ForeCastWebApp
{
    public partial class _Default : Page
    {

        //creating a WeatherSrevice object to access throughout application
        WeatherService.Service1Client myforecastService = new WeatherService.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            // need to obtain the day, such as Monday,Tuesday,etc
            DateTime thisDay = DateTime.Today;
            string date = thisDay.ToString("D");
            //will parse through date string to just obtain the actual day
            string[] tempArray = date.Split(',');

            //dateArray will hold the seven days
            string[] dateArray = new string[7];

            switch (tempArray[0])
            {
                case "Monday":
                    dateArray[0]= tempArray[0];
                    dateArray[1] = "Tuesday";
                    dateArray[2] = "Wednesday";
                    dateArray[3] = "Thursday";
                    dateArray[4] = "Friday";
                    dateArray[5] = "Saturday";
                    dateArray[6] = "Sunday";
                    break;

                case "Tuesday":
                    dateArray[0]= tempArray[0];
                    dateArray[1] = "Wednesday";
                    dateArray[2] = "Thursday";
                    dateArray[3] = "Friday";
                    dateArray[4] = "Saturday";
                    dateArray[5] = "Sunday";
                    dateArray[6] = "Monday";
                    break;

                case "Wednesday":
                    dateArray[0]= tempArray[0];
                    dateArray[1] = "Thursday";
                    dateArray[2] = "Friday";
                    dateArray[3] = "Saturday";
                    dateArray[4] = "Sunday";
                    dateArray[5] = "Monday";
                    dateArray[6] = "Tuesday";
                    break;

                case "Thursday":
                    dateArray[0]= tempArray[0];
                    dateArray[1] = "Friday";
                    dateArray[2] = "Saturday";
                    dateArray[3] = "Sunday";
                    dateArray[4] = "Monday";
                    dateArray[5] = "Tuesday";
                    dateArray[6] = "Wednesday";
                    break;

                case "Friday":
                    dateArray[0]= tempArray[0];
                    dateArray[1] = "Saturday";
                    dateArray[2] = "Sunday";
                    dateArray[3] = "Monday";
                    dateArray[4] = "Tuesday";
                    dateArray[5] = "Wednesday";
                    dateArray[6] = "Thursday";
                    break;

                case "Saturday":
                    dateArray[0]= tempArray[0];
                    dateArray[1] = "Sunday";
                    dateArray[2] = "Monday";
                    dateArray[3] = "Tuesday";
                    dateArray[4] = "Wednesday";
                    dateArray[5] = "Thursday";
                    dateArray[6] = "Friday";
                    break;

                case "Sunday":
                    dateArray[0]= tempArray[0];
                    dateArray[1] = "Monday";
                    dateArray[2] = "Tuesday";
                    dateArray[3] = "Wednesday";
                    dateArray[4] = "Thursday";
                    dateArray[5] = "Friday";
                    dateArray[6] = "Saturday";
                    break;

                default:
                    break;

            }

            //assign each date to it's corresponding label
            day1Lbl.Text = dateArray[0];
            day2Lbl.Text = dateArray[1];
            day3Lbl.Text = dateArray[2];
            day4Lbl.Text = dateArray[3];
            day5Lbl.Text = dateArray[4];
            day6Lbl.Text = dateArray[5];
            day7Lbl.Text = dateArray[6];

            // will assign returned string array to present string array
            string[] returnedArray = myforecastService.Weather5day(ZipCodeBox.text);
            
            Image1.ImageUrl = returnedArray[21];
            Image2.ImageUrl = returnedArray[22];
            Image3.ImageUrl = returnedArray[23];
            Image4.ImageUrl = returnedArray[24];
            Image5.ImageUrl = returnedArray[25];
            Image6.ImageUrl = returnedArray[26];
            Image7.ImageUrl = returnedArray[27];

            // assigning weather description
            Des1Lbl.Text = returnedArray[14];
            Des2Lbl.Text = returnedArray[15];
            Des3Lbl.Text = returnedArray[16];
            Des4Lbl.Text = returnedArray[17];
            Des5Lbl.Text = returnedArray[18];
            Des6Lbl.Text = returnedArray[19];
            Des7Lbl.Text = returnedArray[20];
            
             
        }
    }
}