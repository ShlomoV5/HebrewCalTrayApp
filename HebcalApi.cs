using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HebrewCalendarTrayApp
{
    public class HebcalApi
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<HebrewDate> GetHebrewDate(DateTime gregorianDate)
        {
            string url = $"https://www.hebcal.com/converter?cfg=json&gy={gregorianDate.Year}&gm={gregorianDate.Month}&gd={gregorianDate.Day}&g2h=1";
            string response = await client.GetStringAsync(url);
            JObject json = JObject.Parse(response);

            return new HebrewDate
            {
                DayNumber = (string)json["hebrew"],
                FullDate = $"{json["hebrew"]} {json["hm"]} {json["hy"]}"
            };
        }

        public static async Task<JObject> GetHebrewCalendarEvents(int year, int month)
        {
            string url = $"https://www.hebcal.com/hebcal?cfg=json&v=1&maj=on&mod=on&year={year}&month={month}&geo=geoname&geonameid=293397";
            string response = await client.GetStringAsync(url);
            return JObject.Parse(response);
        }
    }

    public class HebrewDate
    {
        public string DayNumber { get; set; }
        public string FullDate { get; set; }
    }
}
