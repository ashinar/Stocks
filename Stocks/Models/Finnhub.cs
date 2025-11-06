using Newtonsoft.Json.Linq;

namespace Stocks.Models
{
    public class Finnhub
    {
        private static int finnhuCount = 0;
        private static string apiKey = "d431ai1r01qvk0j9nnigd431ai1r01qvk0j9nnj0";   
        

        static DateTime LastTime { get; set; } 
        

        public static async Task<JObject> GetFinnhubData(string symbol)
        {
            finnhuCount++;
            if (finnhuCount % 30 == 0 && LastTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(1000);
            }

            LastTime = DateTime.Now;


            using var client = new HttpClient();
            var response = await client.GetStringAsync($"https://finnhub.io/api/v1/quote?&token={apiKey}&symbol={symbol}");
            return JObject.Parse(response);
        }


        public static decimal GetPrice(JObject data)
        {
            return data["c"]?.Value<decimal>() ?? 0;
        }

        public static decimal GetPercent(JObject data)
        {
            return data["dp"]?.Value<decimal>() ?? 0;
        }


    }
}
