using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json.Linq;
using Stocks.Services;

namespace Stocks.Models
{
    namespace Stocks.Models
    {
        public class Stock
        {
            public enum eProviderType { None = 0, Finnhub = 1 }

            public string Symbol { get; set; }
            public decimal CurrentPrice { get; set; }
            public decimal Change { get; set; }
            public decimal Percent { get; set; }
            public decimal Low { get; set; }
            public decimal OpenPrice { get; set; }
            public decimal PreviousClose { get; set; }
            public string Description { get; set; }
            public bool IsLoaded { get; set; }

            public Stock(string symbol, string description)
            {
                Symbol = symbol;
                Description = description;
            }

            public async Task LoadAsync(eProviderType providerType)
            {
                string cacheKey = $"stock:{Symbol}";


                var cachedStock = RedisHelper.GetObject<Stock>(cacheKey);
                if (cachedStock != null)
                {

                    CurrentPrice = cachedStock.CurrentPrice;
                    Change = cachedStock.Change;
                    Percent = cachedStock.Percent;
                    Low = cachedStock.Low;
                    OpenPrice = cachedStock.OpenPrice;
                    PreviousClose = cachedStock.PreviousClose;
                    return;
                }


                JObject data = providerType switch
                {
                    eProviderType.Finnhub => await GetStockDataFromFinnhub(Symbol),
                    _ => throw new NotImplementedException("Provider not implemented")
                };


                if (data != null)
                {
                    CurrentPrice = data.Value<decimal>("c");
                    Change = data.Value<decimal>("d");
                    Percent = data.Value<decimal>("dp");
                    Low = data.Value<decimal>("l");
                    OpenPrice = data.Value<decimal>("o");
                    PreviousClose = data.Value<decimal>("pc");
                }



                RedisHelper.SetObject(cacheKey, this, TimeSpan.FromMinutes(2));
            }

            private async Task<JObject> GetStockDataFromFinnhub(string symbol)
            {
                string apiKey = "d431ai1r01qvk0j9nnigd431ai1r01qvk0j9nnj0";
                using var client = new HttpClient();
                var response = await client.GetAsync($"https://finnhub.io/api/v1/quote?symbol={symbol}&token={apiKey}");

                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    Console.WriteLine($"Finnhub API limit reached for {symbol}. Waiting 1 seconds before retry...");
                    await Task.Delay(1000);
                    return await GetStockDataFromFinnhub(symbol);
                }

                var json = await response.Content.ReadAsStringAsync();
                return JObject.Parse(json);
            }
        }
    }


}
